﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using KHRota.Classes;

namespace KHRota.Forms
{
    public partial class FDisplayReport : Form
    {
        private readonly MeetingSchedule _meetingSchedule;
        private readonly ArrayList arrColumnLefts = new ArrayList(); //Used to save left coordinates of columns
        private readonly ArrayList arrColumnWidths = new ArrayList(); //Used to save column widths
        private bool _printing;
        private bool bFirstPage; //Used to check whether we are printing first page
        private bool bNewPage; // Used to check whether we are printing a new page
        private int iCellHeight; //Used to get/set the datagridview cell height
        private int iHeaderHeight; //Used for the header height
        private int iTotalWidth; //
        private StringFormat strFormat; //Used to format the grid rows.

        public FDisplayReport(MeetingSchedule meetingSchedule)
        {
            _meetingSchedule = meetingSchedule;

            InitializeComponent();
            LoadJobGroups();
            //LoadReport();
        }

        private void LoadJobGroups()
        {
            var jobGroups = GetJobGroups();
            cbJobGroups.DataSource = jobGroups;
            cbJobGroups.DisplayMember = "Name";
            cbJobGroups.ValueMember = "Guid";
        }

        private void cbJobGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid(cbJobGroups.SelectedItem as JobGroup);
        }

        private void LoadDataGrid(JobGroup jobGroup)
        {
            pReport.Controls.Clear();
            var grid = GetGrid(jobGroup);
            pReport.Controls.Add(grid);
        }

        private DataGridView GetGrid(JobGroup jobGroup)
        {
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                RowHeadersVisible = false,
                AutoSize = true,
                BackgroundColor = Color.White,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    Font = new Font(Font, FontStyle.Bold)
                },
                //CellBorderStyle = DataGridViewCellBorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                BorderStyle = BorderStyle.None,
                Width = 1000
            };

            grid.DefaultCellStyle.Font = new Font("Tahoma", 13);
            grid.Font = new Font("Tahoma", 13);
            grid.DataBindingComplete += GridOnDataBindingComplete;
            grid.CellPainting += GridOnCellPainting;

            var jobsInThisGroup =
                _meetingSchedule.ScheduledMeetings.SelectMany(
                    s => s.JobAssignments.Where(j => j.Job.JobGroup == jobGroup).Select(j => j.Job));

            grid.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Day", Name = "day"});
            grid.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = "Date", Name = "date"});

            foreach (var job in jobsInThisGroup.Distinct().ToList())
                grid.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = job.Name, Name = MakeColumnName(job.Name)});

            var bindingList = new BindingList<ScheduledMeeting>();
            foreach (var scheduledMeeting in _meetingSchedule.ScheduledMeetings)
            {
                bindingList.Add(scheduledMeeting);
            }

            grid.DataSource = bindingList;
            return grid;
        }

        private void GridOnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*var grid = sender as DataGridView;
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All ^ DataGridViewPaintParts.Border ^ DataGridViewPaintParts.Background);
                e.Handled = true;
            }*/
        }

        private string MakeColumnName(string name)
        {
            return name.ToLower().Replace(" ", "");
        }

        private void GridOnDataBindingComplete(object sender,
            DataGridViewBindingCompleteEventArgs dataGridViewBindingCompleteEventArgs)
        {
            var grid = (sender as DataGridView);
            if (_printing)
            {
                if (grid != null)
                {
                    grid.ColumnHeadersHeight = 60;
                    grid.DefaultCellStyle = new DataGridViewCellStyle
                    {
                        SelectionBackColor = Color.Transparent,
                        SelectionForeColor = Color.Transparent
                    };
                }
            }

            foreach (DataGridViewRow currentRow in grid.Rows)
            {
                var scheduledMeeting = currentRow.DataBoundItem as ScheduledMeeting;
                if (scheduledMeeting == null)
                    return;

                currentRow.Cells["day"].Value = scheduledMeeting.Meeting.DayOfWeek.ToString();
                currentRow.Cells["date"].Value = scheduledMeeting.DateTime.ToString("d");

                foreach (var jobAssignment in scheduledMeeting.JobAssignments)
                {
                    if ((sender as DataGridView).Columns.Contains(MakeColumnName(jobAssignment.Job.Name)))
                        currentRow.Cells[MakeColumnName(jobAssignment.Job.Name)].Value = jobAssignment.Brother.FullName;
                }
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDoc1;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printDoc1.OriginAtMargins = true;
                printDoc1.DefaultPageSettings = new PageSettings
                {
                    Margins = new Margins(20, 20, 20, 20)
                };
                printDoc1.Print();
            }
        }

        private void printDoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            const int baseHeightSpace = 70;
            _printing = true;
            try
            {
                var jobGroups = GetJobGroups();
                DataGridView previousGrid = null;

                var totalHeight = 0;
                Font font = null;
                var index = 0;
                foreach (var jobGroup in jobGroups.OrderBy(j => j.Name))
                {
                    var grid = GetGrid(jobGroup);
                    pReport.Controls.Add(grid);
                    totalHeight += grid.Height;
                    font = grid.Font;
                    PrintGrid(sender, e, grid, index);
                    index++;
                    pReport.Controls.Remove(grid);
                }

                totalHeight += baseHeightSpace;
                var stringsToPrint = new Dictionary<string, bool>
                {
                    {"Please ensure that you arrive for the meeting at least 20 minutes before it starts.", true},
                    {"If you can not complete your assignment please contact as follows:", true},
                    {"Bro Kevin Normington - 07429 326193 (Sound Team)", false},
                    {"Bro Jim Cambage - 07757 712663 (Attendants)", false}
                };

                var boldFont = new Font(font, FontStyle.Bold);
                for (var i = 0; i < stringsToPrint.Count; i++)
                {
                    var printBold = stringsToPrint.Values.ToList()[i];
                    var text = stringsToPrint.Keys.ToList()[i];

                    e.Graphics.DrawString(text, printBold ? boldFont : font, Brushes.Black, 0,
                        totalHeight + (baseHeightSpace*i));
                }
            }
            finally
            {
                _printing = false;
            }
        }

        private void printDoc1_BeginPrint(object sender, PrintEventArgs e)
        {
            var jobGroups = GetJobGroups();
            foreach (var jobGroup in jobGroups)
            {
                var grid = GetGrid(jobGroup);
                pReport.Controls.Add(grid);

                try
                {
                    strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Near;
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Trimming = StringTrimming.EllipsisCharacter;

                    arrColumnLefts.Clear();
                    arrColumnWidths.Clear();
                    iCellHeight = 0;
                    //iCount = 0;
                    bFirstPage = true;
                    bNewPage = true;

                    // Calculating Total Widths
                    iTotalWidth = 0;
                    foreach (DataGridViewColumn dgvGridCol in grid.Columns)
                    {
                        iTotalWidth += dgvGridCol.Width;
                    }
                    iTotalWidth += 30;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintGrid(object sender, PrintPageEventArgs e, DataGridView grid, int gridIndex)
        {
            try
            {
                //Set the left margin
                var iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                var iTopMargin = gridIndex == 0 ? e.MarginBounds.Top : grid.Height + e.MarginBounds.Top + 20;
                //Whether more pages have to print or not
                var iTmpWidth = 0;
                var iRow = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in grid.Columns)
                    {
                        iTmpWidth = (int) (Math.Floor(GridCol.Width/
                                                      (double) iTotalWidth*iTotalWidth*
                                                      (e.MarginBounds.Width/(double) iTotalWidth)));

                        iHeaderHeight = (int) (e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 30;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= grid.Rows.Count - 1)
                {
                    var GridRow = grid.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    var iCount = 0;
                    if (iRow == 0)
                    {
                        var columnFont = new Font(grid.Font, FontStyle.Bold);
                        //Draw Columns                 
                        foreach (DataGridViewColumn GridCol in grid.Columns)
                        {
                            e.Graphics.DrawString(GridCol.HeaderText,
                                columnFont,
                                new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                new RectangleF((int) arrColumnLefts[iCount], iTopMargin,
                                    (int) arrColumnWidths[iCount], iHeaderHeight), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight;
                    }
                    iCount = 0;
                    //Draw Columns Contents                
                    foreach (DataGridViewCell Cel in GridRow.Cells)
                    {
                        if (Cel.Value != null)
                        {
                            e.Graphics.DrawString(Cel.Value.ToString(),
                                Cel.InheritedStyle.Font,
                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                new RectangleF((int) arrColumnLefts[iCount],
                                    iTopMargin,
                                    (int) arrColumnWidths[iCount], iCellHeight),
                                strFormat);
                        }

                        if (iCount > 1)
                        {
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int) arrColumnLefts[iCount], iTopMargin,
                                    (int) arrColumnWidths[iCount], iCellHeight));
                        }
                        iCount++;
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private IEnumerable<JobGroup> GetJobGroups()
        {
            return
                new List<JobGroup>(
                    _meetingSchedule.ScheduledMeetings.SelectMany(s => s.JobAssignments.Select(j => j.Job.JobGroup)))
                    .Distinct().ToList();
        }
    }
}