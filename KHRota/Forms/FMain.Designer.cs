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
            this.lSchedule = new System.Windows.Forms.Label();
            this.lViewing = new System.Windows.Forms.Label();
            this.bPrint = new System.Windows.Forms.Button();
            this.bExportAsCSV = new System.Windows.Forms.Button();
            this.bGenerateSchedule = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brothersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bViewPreviousSchedule = new System.Windows.Forms.Button();
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
            this.pScheduleGenerated.Controls.Add(this.lSchedule);
            this.pScheduleGenerated.Controls.Add(this.lViewing);
            this.pScheduleGenerated.Controls.Add(this.bPrint);
            this.pScheduleGenerated.Controls.Add(this.bExportAsCSV);
            this.pScheduleGenerated.Location = new System.Drawing.Point(12, 109);
            this.pScheduleGenerated.Name = "pScheduleGenerated";
            this.pScheduleGenerated.Size = new System.Drawing.Size(228, 91);
            this.pScheduleGenerated.TabIndex = 8;
            this.pScheduleGenerated.Visible = false;
            // 
            // lSchedule
            // 
            this.lSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSchedule.Location = new System.Drawing.Point(3, 13);
            this.lSchedule.Name = "lSchedule";
            this.lSchedule.Size = new System.Drawing.Size(222, 20);
            this.lSchedule.TabIndex = 12;
            this.lSchedule.Text = "label1";
            this.lSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lViewing
            // 
            this.lViewing.AutoSize = true;
            this.lViewing.Location = new System.Drawing.Point(3, 0);
            this.lViewing.Name = "lViewing";
            this.lViewing.Size = new System.Drawing.Size(157, 13);
            this.lViewing.TabIndex = 11;
            this.lViewing.Text = "Currently Viewing Schedule For:";
            // 
            // bPrint
            // 
            this.bPrint.Location = new System.Drawing.Point(0, 65);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(228, 23);
            this.bPrint.TabIndex = 10;
            this.bPrint.Text = "Print Schedule (Opens Report Window)";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bExportAsCSV
            // 
            this.bExportAsCSV.Location = new System.Drawing.Point(0, 36);
            this.bExportAsCSV.Name = "bExportAsCSV";
            this.bExportAsCSV.Size = new System.Drawing.Size(228, 23);
            this.bExportAsCSV.TabIndex = 8;
            this.bExportAsCSV.Text = "Export as CSV (Excel Compatable)";
            this.bExportAsCSV.UseVisualStyleBackColor = true;
            this.bExportAsCSV.Click += new System.EventHandler(this.bExportAsCSV_Click);
            // 
            // bGenerateSchedule
            // 
            this.bGenerateSchedule.Location = new System.Drawing.Point(12, 27);
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
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(252, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.importExportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.exportDataToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.importExportToolStripMenuItem.Text = "Import / Export";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meetingsToolStripMenuItem,
            this.jobsToolStripMenuItem,
            this.brothersToolStripMenuItem,
            this.emailSettingsToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // meetingsToolStripMenuItem
            // 
            this.meetingsToolStripMenuItem.Name = "meetingsToolStripMenuItem";
            this.meetingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.meetingsToolStripMenuItem.Text = "Meetings";
            this.meetingsToolStripMenuItem.Click += new System.EventHandler(this.meetingsToolStripMenuItem_Click);
            // 
            // jobsToolStripMenuItem
            // 
            this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
            this.jobsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jobsToolStripMenuItem.Text = "Jobs";
            this.jobsToolStripMenuItem.Click += new System.EventHandler(this.jobsToolStripMenuItem_Click);
            // 
            // brothersToolStripMenuItem
            // 
            this.brothersToolStripMenuItem.Name = "brothersToolStripMenuItem";
            this.brothersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.brothersToolStripMenuItem.Text = "Brothers";
            this.brothersToolStripMenuItem.Click += new System.EventHandler(this.brothersToolStripMenuItem_Click);
            // 
            // emailSettingsToolStripMenuItem
            // 
            this.emailSettingsToolStripMenuItem.Name = "emailSettingsToolStripMenuItem";
            this.emailSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emailSettingsToolStripMenuItem.Text = "Email Settings";
            this.emailSettingsToolStripMenuItem.Click += new System.EventHandler(this.emailSettingsToolStripMenuItem_Click);
            // 
            // bViewPreviousSchedule
            // 
            this.bViewPreviousSchedule.Location = new System.Drawing.Point(12, 80);
            this.bViewPreviousSchedule.Name = "bViewPreviousSchedule";
            this.bViewPreviousSchedule.Size = new System.Drawing.Size(228, 23);
            this.bViewPreviousSchedule.TabIndex = 9;
            this.bViewPreviousSchedule.Text = "View Previous Schedule";
            this.bViewPreviousSchedule.UseVisualStyleBackColor = true;
            this.bViewPreviousSchedule.Click += new System.EventHandler(this.bViewPreviousSchedule_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 212);
            this.Controls.Add(this.bViewPreviousSchedule);
            this.Controls.Add(this.pScheduleGenerated);
            this.Controls.Add(this.bGenerateSchedule);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "KHRota";
            this.pScheduleGenerated.ResumeLayout(false);
            this.pScheduleGenerated.PerformLayout();
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
        private System.Windows.Forms.Panel pScheduleGenerated;
        private System.Windows.Forms.Button bExportAsCSV;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.SaveFileDialog sfDlgExportCsv;
        private System.Windows.Forms.SaveFileDialog sfDlgExportSettings;
        private System.Windows.Forms.OpenFileDialog ofDlgImportData;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brothersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSettingsToolStripMenuItem;
        private System.Windows.Forms.Button bViewPreviousSchedule;
        private System.Windows.Forms.Label lSchedule;
        private System.Windows.Forms.Label lViewing;
    }
}

