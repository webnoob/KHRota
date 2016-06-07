using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHRota.Properties;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FSettings : BaseForm
    {
        public FSettings()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Settings.Default.SendEmailUsername = tbUsername.Text;
            Settings.Default.SendEmailPassword = tbPassword.Text;
            DbService.Save();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
