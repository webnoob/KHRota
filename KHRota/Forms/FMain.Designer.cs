namespace KHRota.Forms
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.sfDlgExportCsv = new System.Windows.Forms.SaveFileDialog();
            this.sfDlgExportSettings = new System.Windows.Forms.SaveFileDialog();
            this.ofDlgImportData = new System.Windows.Forms.OpenFileDialog();
            this.pScheduleGenerated = new System.Windows.Forms.Panel();
            this.bPrint = new System.Windows.Forms.Button();
            this.bEditGeneratedSchdule = new System.Windows.Forms.Button();
            this.bExportAsCSV = new System.Windows.Forms.Button();
            this.lScheduleGenerated = new System.Windows.Forms.Label();
            this.bImportData = new System.Windows.Forms.Button();
            this.bExportData = new System.Windows.Forms.Button();
            this.bEditBrothers = new System.Windows.Forms.Button();
            this.bEditJobs = new System.Windows.Forms.Button();
            this.bEditMeetings = new System.Windows.Forms.Button();
            this.bGenerateSchedule = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pScheduleGenerated.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfDlgExportCsv
            // 
            this.sfDlgExportCsv.DefaultExt = "csv";
            this.sfDlgExportCsv.FileOk += new System.ComponentModel.CancelEventHandler(this.sfDlgExportCsv_FileOk);
            // 
            // sfDlgExportSettings
            // 
            this.sfDlgExportSettings.FileOk += new System.ComponentModel.CancelEventHandler(this.sfDlgExportSettings_FileOk);
            // 
            // ofDlgImportData
            // 
            this.ofDlgImportData.FileName = "openFileDialog1";
            this.ofDlgImportData.FileOk += new System.ComponentModel.CancelEventHandler(this.ofDlgImportData_FileOk);
            // 
            // pScheduleGenerated
            // 
            this.pScheduleGenerated.Controls.Add(this.bPrint);
            this.pScheduleGenerated.Controls.Add(this.bEditGeneratedSchdule);
            this.pScheduleGenerated.Controls.Add(this.bExportAsCSV);
            this.pScheduleGenerated.Controls.Add(this.lScheduleGenerated);
            this.pScheduleGenerated.Location = new System.Drawing.Point(12, 225);
            this.pScheduleGenerated.Name = "pScheduleGenerated";
            this.pScheduleGenerated.Size = new System.Drawing.Size(228, 123);
            this.pScheduleGenerated.TabIndex = 8;
            this.pScheduleGenerated.Visible = false;
            // 
            // bPrint
            // 
            this.bPrint.Location = new System.Drawing.Point(0, 92);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(228, 23);
            this.bPrint.TabIndex = 10;
            this.bPrint.Text = "Print Schedule (Opens Report Window)";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bEditGeneratedSchdule
            // 
            this.bEditGeneratedSchdule.Enabled = false;
            this.bEditGeneratedSchdule.Location = new System.Drawing.Point(0, 34);
            this.bEditGeneratedSchdule.Name = "bEditGeneratedSchdule";
            this.bEditGeneratedSchdule.Size = new System.Drawing.Size(228, 23);
            this.bEditGeneratedSchdule.TabIndex = 9;
            this.bEditGeneratedSchdule.Text = "Edit / View Generated Schedule";
            this.bEditGeneratedSchdule.UseVisualStyleBackColor = true;
            // 
            // bExportAsCSV
            // 
            this.bExportAsCSV.Location = new System.Drawing.Point(0, 63);
            this.bExportAsCSV.Name = "bExportAsCSV";
            this.bExportAsCSV.Size = new System.Drawing.Size(228, 23);
            this.bExportAsCSV.TabIndex = 8;
            this.bExportAsCSV.Text = "Export as CSV (Excel Compatable)";
            this.bExportAsCSV.UseVisualStyleBackColor = true;
            this.bExportAsCSV.Click += new System.EventHandler(this.bExportAsCSV_Click);
            // 
            // lScheduleGenerated
            // 
            this.lScheduleGenerated.Location = new System.Drawing.Point(3, 0);
            this.lScheduleGenerated.Name = "lScheduleGenerated";
            this.lScheduleGenerated.Size = new System.Drawing.Size(222, 31);
            this.lScheduleGenerated.TabIndex = 0;
            this.lScheduleGenerated.Text = "Your schedule has been generated, please select an option below.";
            // 
            // bImportData
            // 
            this.bImportData.Location = new System.Drawing.Point(12, 143);
            this.bImportData.Name = "bImportData";
            this.bImportData.Size = new System.Drawing.Size(228, 23);
            this.bImportData.TabIndex = 7;
            this.bImportData.Text = "Import Data";
            this.bImportData.UseVisualStyleBackColor = true;
            this.bImportData.Click += new System.EventHandler(this.bImportData_Click);
            // 
            // bExportData
            // 
            this.bExportData.Location = new System.Drawing.Point(12, 114);
            this.bExportData.Name = "bExportData";
            this.bExportData.Size = new System.Drawing.Size(228, 23);
            this.bExportData.TabIndex = 6;
            this.bExportData.Text = "Export Data";
            this.bExportData.UseVisualStyleBackColor = true;
            this.bExportData.Click += new System.EventHandler(this.bExportData_Click);
            // 
            // bEditBrothers
            // 
            this.bEditBrothers.Location = new System.Drawing.Point(12, 85);
            this.bEditBrothers.Name = "bEditBrothers";
            this.bEditBrothers.Size = new System.Drawing.Size(228, 23);
            this.bEditBrothers.TabIndex = 5;
            this.bEditBrothers.Text = "Setup Brothers";
            this.bEditBrothers.UseVisualStyleBackColor = true;
            this.bEditBrothers.Click += new System.EventHandler(this.bEditBrothers_Click);
            // 
            // bEditJobs
            // 
            this.bEditJobs.Location = new System.Drawing.Point(12, 56);
            this.bEditJobs.Name = "bEditJobs";
            this.bEditJobs.Size = new System.Drawing.Size(228, 23);
            this.bEditJobs.TabIndex = 4;
            this.bEditJobs.Text = "Setup Jobs";
            this.bEditJobs.UseVisualStyleBackColor = true;
            this.bEditJobs.Click += new System.EventHandler(this.bEditJobs_Click);
            // 
            // bEditMeetings
            // 
            this.bEditMeetings.Location = new System.Drawing.Point(12, 27);
            this.bEditMeetings.Name = "bEditMeetings";
            this.bEditMeetings.Size = new System.Drawing.Size(228, 23);
            this.bEditMeetings.TabIndex = 3;
            this.bEditMeetings.Text = "Setup Meetings";
            this.bEditMeetings.UseVisualStyleBackColor = true;
            this.bEditMeetings.Click += new System.EventHandler(this.bEditMeetings_Click);
            // 
            // bGenerateSchedule
            // 
            this.bGenerateSchedule.Location = new System.Drawing.Point(12, 172);
            this.bGenerateSchedule.Name = "bGenerateSchedule";
            this.bGenerateSchedule.Size = new System.Drawing.Size(228, 47);
            this.bGenerateSchedule.TabIndex = 0;
            this.bGenerateSchedule.Text = "Generate Schedule";
            this.bGenerateSchedule.UseVisualStyleBackColor = true;
            this.bGenerateSchedule.Click += new System.EventHandler(this.bGenerateSchedule_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(252, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 351);
            this.Controls.Add(this.pScheduleGenerated);
            this.Controls.Add(this.bImportData);
            this.Controls.Add(this.bExportData);
            this.Controls.Add(this.bEditBrothers);
            this.Controls.Add(this.bEditJobs);
            this.Controls.Add(this.bEditMeetings);
            this.Controls.Add(this.bGenerateSchedule);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "KHRota";
            this.pScheduleGenerated.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGenerateSchedule;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button bEditMeetings;
        private System.Windows.Forms.Button bEditJobs;
        private System.Windows.Forms.Button bEditBrothers;
        private System.Windows.Forms.Button bExportData;
        private System.Windows.Forms.Button bImportData;
        private System.Windows.Forms.Panel pScheduleGenerated;
        private System.Windows.Forms.Button bEditGeneratedSchdule;
        private System.Windows.Forms.Button bExportAsCSV;
        private System.Windows.Forms.Label lScheduleGenerated;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.SaveFileDialog sfDlgExportCsv;
        private System.Windows.Forms.SaveFileDialog sfDlgExportSettings;
        private System.Windows.Forms.OpenFileDialog ofDlgImportData;
    }
}

