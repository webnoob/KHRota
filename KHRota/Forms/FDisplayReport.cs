using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Properties;
using KHRota.Services;
using BorderStyle = System.Windows.Forms.BorderStyle;

//NOTE: Pretty much all the code in this file sucks :) It's quite specific to our needs for the reporting.

namespace KHRota.Forms
{
    public partial class FDisplayReport : Form
    {
        private readonly MeetingSchedule _meetingSchedule;
        private readonly ScheduleService _scheduleService;
        private readonly BrotherService _brotherService;

        private readonly ArrayList arrColumnLefts = new ArrayList(); //Used to save left coordinates of columns
        private readonly ArrayList arrColumnWidths = new ArrayList(); //Used to save column widths
        private bool _printing;
        private bool bFirstPage; //Used to check whether we are printing first page
        private bool bNewPage; // Used to check whether we are printing a new page
        private int iCellHeight; //Used to get/set the datagridview cell height
        private int iHeaderHeight; //Used for the header height
        private int iTotalWidth; //
        private int _topMargin = 20;
        private StringFormat strFormat; //Used to format the grid rows.
        private SmtpClient _smtpClient;

        public FDisplayReport(MeetingSchedule meetingSchedule)
        {
            _meetingSchedule = meetingSchedule;
            _scheduleService = new ScheduleService();
            _brotherService = new BrotherService();

            InitializeComponent();
            LoadJobGroups();

            _smtpClient = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(Settings.Default.SendEmailUsername, Settings.Default.SendEmailPassword)
            };

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
            grid.CellDoubleClick += GridOnCellDoubleClick;

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

        private List<Brother> GetAllowedBrothersForPopup(Job jobAssignment)
        {
            return _brotherService.Get().Where(b => b.AssignedJobs.Select(j => j.Guid).Contains(jobAssignment.Guid)).ToList();
        }

        private void GridOnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            var fullName = grid.SelectedCells[0].Value;
            var meetingSchedule = _meetingSchedule.ScheduledMeetings[e.RowIndex];
            var assignmentName = grid.Columns[e.ColumnIndex].HeaderText;
            var jobAssignment = meetingSchedule.JobAssignments.Select(ja => ja.Job).FirstOrDefault(j => j.Name.Equals(assignmentName));
            using (var form = new FSelectBrother(GetAllowedBrothersForPopup(jobAssignment)))
            {
                form.ShowDialog(this);
                if (form.DialogResult != DialogResult.OK)
                    return;

                var assignmentsForThisBrother = meetingSchedule.JobAssignments.Where(ja => ja.Brother.Equals(form.Brother));
                if (assignmentsForThisBrother.Any())
                {
                    MessageBox.Show(String.Format("This brother is already assigned to [{0}]. Please select a different brother.", assignmentsForThisBrother.FirstOrDefault().Job.Name));
                    return;
                }

                Cursor = Cursors.WaitCursor;
                try
                {
                    _scheduleService.ReplaceBrother(meetingSchedule, form.Brother, fullName.ToString(), (cbJobGroups.SelectedItem as JobGroup).Name, assignmentName);
                    _scheduleService.SaveGeneratedMeetingSchedule(_meetingSchedule);
                    LoadDataGrid(cbJobGroups.SelectedItem as JobGroup);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
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

                currentRow.Cells["day"].Value = scheduledMeeting.Meeting.DayOfWeek.ToString().Substring(0, 3);
                currentRow.Cells["date"].Value = scheduledMeeting.DateTime.ToString("dd/MM");

                foreach (var jobAssignment in scheduledMeeting.JobAssignments)
                {
                    if ((sender as DataGridView).Columns.Contains(MakeColumnName(jobAssignment.Job.Name)))
                        currentRow.Cells[MakeColumnName(jobAssignment.Job.Name)].Value = jobAssignment.Brother != null
                            ? jobAssignment.Brother.FullName
                            : "Volunteer Required";
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
            const int baseHeightSpace = 30;
            _printing = true;
            try
            {
                var jobGroups = GetJobGroups();
                Font font = null;

                foreach (var jobGroup in jobGroups.OrderBy(j => j.Name))
                {
                    var grid = GetGrid(jobGroup);
                    pReport.Controls.Add(grid);
                    font = grid.Font;
                    PrintGrid(sender, e, grid);
                    pReport.Controls.Remove(grid);
                }
                
                var stringsToPrint = new Dictionary<string, bool>
                {
                    {"Please ensure that you arrive for the meeting at least 20 minutes before it starts.", true},
                    {"If you can not complete your assignment please contact as follows:", true},
                    {"Bro Pawel Kulda - 07545 757889 (Attendants / Garage)", false},
                    {"Bro Kevin Normington - 07429 326193 (Sound Team)", false}
                };

                var boldFont = new Font(font, FontStyle.Bold);
                for (var i = 0; i < stringsToPrint.Count; i++)
                {
                    var printBold = stringsToPrint.Values.ToList()[i];
                    var text = stringsToPrint.Keys.ToList()[i];

                    e.Graphics.DrawString(text, printBold ? boldFont : font, Brushes.Black, 0, _topMargin + (i + 1) * baseHeightSpace);
                }
            }
            finally
            {
                _printing = false;
                _topMargin = 20;
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

        private void PrintGrid(object sender, PrintPageEventArgs e, DataGridView grid)
        {
            try
            {
                //Set the left margin
                var iLeftMargin = e.MarginBounds.Left;
                
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
                                new RectangleF((int) arrColumnLefts[iCount], _topMargin,
                                    (int) arrColumnWidths[iCount], iHeaderHeight), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        _topMargin += iHeaderHeight;
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
                                    _topMargin,
                                    (int) arrColumnWidths[iCount], iCellHeight),
                                strFormat);
                        }

                        if (iCount > 1)
                        {
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int) arrColumnLefts[iCount], _topMargin,
                                    (int) arrColumnWidths[iCount], iCellHeight));
                        }
                        iCount++;
                    }
                    iRow++;
                    _topMargin += iCellHeight;
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

        private void bEmailToAllBrothers_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var gridString = GetEmailGrid();
                var footerString = GetEmailFooterString();

                var brothersWithEmailAddresses = _meetingSchedule.ScheduledMeetings.SelectMany(
                    m =>
                        m.JobAssignments.Select(j => j.Brother)
                            .Where(b => !string.IsNullOrEmpty(b.EmailAddress)));
                foreach (var brother in brothersWithEmailAddresses.Distinct(new BrotherEqualityComparator()))
                {
                    SendEmailToBrother(brother, HighlightBrother(gridString, brother) + footerString);
                }
            }
            finally
            {
                Cursor = DefaultCursor;
            }
        }

        private string GetEmailFooterString()
        {
            var sb = new StringBuilder();
            sb.Append("<p><b>Please ensure you arrive for the meeting at least 20 minutes before it starts.</b></p><br/>");
            sb.Append("<p><b>If you cannot complete your assignment please contact as follows:</b></p><br/>");
            sb.Append("<p>Bro Jim Cambage - 07757 712663 (Attendants / Garage)</p><br/>");
            sb.Append("<p>Bro Kevin Normington - 07429 326193 (Sound Team)</p><br/>");
            var footerString = sb.ToString();
            return footerString;
        }

        private string GetEmailGrid()
        {
            var sb = new StringBuilder();
            var jobGroups = GetJobGroups();
            foreach (var jobGroup in jobGroups.OrderBy(j => j.Name))
            {
                sb.Append("<table width='99%' style='border-collapse:collapse;'>");

                var grid = GetGrid(jobGroup);
                pReport.Controls.Add(grid);

                sb.Append("<tr>");
                for (var i = 0; i < grid.Columns.Count; i++)
                {
                    DataGridViewColumn column = grid.Columns[i];
                    sb.Append(string.Format("<th align='left' border='none'>{0}</th>", column.HeaderText));
                }
                sb.Append("<tr>");

                for (var i = 0; i < grid.Rows.Count; i++)
                {
                    DataGridViewRow row = grid.Rows[i];
                    sb.Append("<tr>");
                    for (var j = 0; j < row.Cells.Count; j++)
                    {
                        DataGridViewCell cell = row.Cells[j];
                        if (j > 1)
                            sb.Append(string.Format("<td style='border:1px solid black;border-right:1px solid black; '>{0}</td>", cell.FormattedValue));
                        else
                            sb.Append(string.Format("<td>{0}</td>", cell.FormattedValue));
                    }
                    sb.Append("<tr>");
                }

                pReport.Controls.Remove(grid);
                sb.Append("</table>");
                sb.Append("<br/>");
            }

            var gridString = sb.ToString();
            return gridString;
        }

        private string HighlightBrother(string gridString, Brother brother)
        {
            return gridString.Replace(brother.FullName,
                string.Format("<span style='background-color: #ffff66;width:100%'><b>{0}</b></span>", brother.FullName));
        }

        private void bEmailToBrother_Click(object sender, EventArgs e)
        {
            using (var form = new FSelectBrother(_brotherService.Get().Where(b => !string.IsNullOrEmpty(b.EmailAddress)).ToList()))
            {
                form.ShowDialog(this);
                if (form.DialogResult != DialogResult.OK)
                    return;
                Cursor = Cursors.WaitCursor;
                try
                {
                    SendEmailToBrother(form.Brother,
                        HighlightBrother(GetEmailGrid(), form.Brother) + GetEmailFooterString());
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void SendEmailToBrother(Brother brother, string body)
        {
            if (brother.EmailAddress == null)
                return;

            var mail = new MailMessage("KHRota@no-reply.com", brother.EmailAddress)
            {
                Subject =
                    string.Format("Sound / Attendant Rota for Month [{0}]",
                        _meetingSchedule.StartDate.ToString("dd-MM-yyyy")),
                Body =
                    string.Format(
                        "Hi {0},<br/><br/>Here is the rota for your Kingdom Hall assignments. If you have any problems, please see the contact details at the bottom of the email.<br/><br/><b>Please Note:</b> Replies to this email are not read.<br/><br/>{1}",
                        brother.FirstName, body),
                IsBodyHtml = true
            };
            _smtpClient.Send(mail);
        }
    }

    internal class BrotherEqualityComparator : IEqualityComparer<Brother>
    {
        public bool Equals(Brother x, Brother y)
        {
            return x.Guid == y.Guid;
        }

        public int GetHashCode(Brother obj)
        {
            return base.GetHashCode();
        }
    }
}