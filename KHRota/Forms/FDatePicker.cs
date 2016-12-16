using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHRota.Forms
{
    public partial class FDatePicker : Form
    {
        public DateTime DateTimeResult { get; set; }
        public DateTime DateTimeResultAlt { get; set; }

        public FDatePicker()
        {
            InitializeComponent();
            var year = DateTime.Now.AddMonths(1).Year;
            var month = DateTime.Now.AddMonths(1).Month;
            dtDateAlt.Text = new DateTime(year, month, DateTime.DaysInMonth(year, month)).ToString("dd/MM/yyyy");
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DateTimeResult = dtDate.Value;
            DateTimeResultAlt = dtDateAlt.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
