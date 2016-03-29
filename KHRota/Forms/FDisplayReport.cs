using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHRota.Data;
using Microsoft.Reporting.WinForms;

namespace KHRota.Forms
{
    public partial class FDisplayReport : Form
    {
        private readonly string _csvData;

        public FDisplayReport(string csvData)
        {
            _csvData = csvData;
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            var ds = new DataSet1();
            var dt = new DataTable();
            var tableData = _csvData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var col = from cl in tableData[0].Replace(" ", "").Split(",".ToCharArray())
                      select new DataColumn(cl);
            dt.Columns.AddRange(col.ToArray());

            (from st in tableData.Skip(1) select dt.Rows.Add(st.Split(",".ToCharArray()))).ToList();
            ds.Tables.Add(dt);

            var rds = new ReportDataSource("DataSet1", ds.Tables[1]);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = @"Z:\SourceCode\KHRota\KHRota\Forms\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();            
        }
    }
}
