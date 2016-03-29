namespace KHRota.Forms
{
    partial class FBrothers
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
            this.lFirstName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbEditBrother = new System.Windows.Forms.ComboBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lLastName = new System.Windows.Forms.Label();
            this.lJobsPerPeriod = new System.Windows.Forms.Label();
            this.numJobsPerPeriod = new System.Windows.Forms.NumericUpDown();
            this.numStandInsPerPeriod = new System.Windows.Forms.NumericUpDown();
            this.lStandInsPerPeriod = new System.Windows.Forms.Label();
            this.numMinMeetingsBetweenJobs = new System.Windows.Forms.NumericUpDown();
            this.lMinMeetingsBetweenJobs = new System.Windows.Forms.Label();
            this.cblAssignedJobs = new System.Windows.Forms.CheckedListBox();
            this.lAssignedJobs = new System.Windows.Forms.Label();
            this.lExclusions = new System.Windows.Forms.Label();
            this.bAddExclusion = new System.Windows.Forms.Button();
            this.bDeleteExclusion = new System.Windows.Forms.Button();
            this.lvJobExclusions = new System.Windows.Forms.ListView();
            this.colDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.numJobsPerPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStandInsPerPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMeetingsBetweenJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // lFirstName
            // 
            this.lFirstName.AutoSize = true;
            this.lFirstName.Location = new System.Drawing.Point(11, 46);
            this.lFirstName.Name = "lFirstName";
            this.lFirstName.Size = new System.Drawing.Size(57, 13);
            this.lFirstName.TabIndex = 0;
            this.lFirstName.Text = "First Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(144, 39);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(171, 20);
            this.tbFirstName.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 399);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(304, 22);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 428);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(304, 22);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Close";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbEditBrother
            // 
            this.cbEditBrother.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBrother.FormattingEnabled = true;
            this.cbEditBrother.Location = new System.Drawing.Point(13, 12);
            this.cbEditBrother.Name = "cbEditBrother";
            this.cbEditBrother.Size = new System.Drawing.Size(222, 21);
            this.cbEditBrother.TabIndex = 11;
            this.cbEditBrother.SelectedIndexChanged += new System.EventHandler(this.cbEditMeeting_SelectedIndexChanged);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(241, 11);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 12;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(144, 65);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(171, 20);
            this.tbLastName.TabIndex = 2;
            // 
            // lLastName
            // 
            this.lLastName.AutoSize = true;
            this.lLastName.Location = new System.Drawing.Point(11, 72);
            this.lLastName.Name = "lLastName";
            this.lLastName.Size = new System.Drawing.Size(58, 13);
            this.lLastName.TabIndex = 13;
            this.lLastName.Text = "Last Name";
            // 
            // lJobsPerPeriod
            // 
            this.lJobsPerPeriod.AutoSize = true;
            this.lJobsPerPeriod.Location = new System.Drawing.Point(11, 98);
            this.lJobsPerPeriod.Name = "lJobsPerPeriod";
            this.lJobsPerPeriod.Size = new System.Drawing.Size(81, 13);
            this.lJobsPerPeriod.TabIndex = 15;
            this.lJobsPerPeriod.Text = "Jobs Per Period";
            // 
            // numJobsPerPeriod
            // 
            this.numJobsPerPeriod.Location = new System.Drawing.Point(241, 91);
            this.numJobsPerPeriod.Name = "numJobsPerPeriod";
            this.numJobsPerPeriod.Size = new System.Drawing.Size(74, 20);
            this.numJobsPerPeriod.TabIndex = 3;
            this.numJobsPerPeriod.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numStandInsPerPeriod
            // 
            this.numStandInsPerPeriod.Location = new System.Drawing.Point(241, 117);
            this.numStandInsPerPeriod.Name = "numStandInsPerPeriod";
            this.numStandInsPerPeriod.Size = new System.Drawing.Size(74, 20);
            this.numStandInsPerPeriod.TabIndex = 4;
            this.numStandInsPerPeriod.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lStandInsPerPeriod
            // 
            this.lStandInsPerPeriod.AutoSize = true;
            this.lStandInsPerPeriod.Location = new System.Drawing.Point(11, 124);
            this.lStandInsPerPeriod.Name = "lStandInsPerPeriod";
            this.lStandInsPerPeriod.Size = new System.Drawing.Size(104, 13);
            this.lStandInsPerPeriod.TabIndex = 18;
            this.lStandInsPerPeriod.Text = "Stand Ins Per Period";
            // 
            // numMinMeetingsBetweenJobs
            // 
            this.numMinMeetingsBetweenJobs.Location = new System.Drawing.Point(241, 143);
            this.numMinMeetingsBetweenJobs.Name = "numMinMeetingsBetweenJobs";
            this.numMinMeetingsBetweenJobs.Size = new System.Drawing.Size(74, 20);
            this.numMinMeetingsBetweenJobs.TabIndex = 5;
            this.numMinMeetingsBetweenJobs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lMinMeetingsBetweenJobs
            // 
            this.lMinMeetingsBetweenJobs.AutoSize = true;
            this.lMinMeetingsBetweenJobs.Location = new System.Drawing.Point(11, 150);
            this.lMinMeetingsBetweenJobs.Name = "lMinMeetingsBetweenJobs";
            this.lMinMeetingsBetweenJobs.Size = new System.Drawing.Size(140, 13);
            this.lMinMeetingsBetweenJobs.TabIndex = 20;
            this.lMinMeetingsBetweenJobs.Text = "Min Meetings Between Jobs";
            // 
            // cblAssignedJobs
            // 
            this.cblAssignedJobs.FormattingEnabled = true;
            this.cblAssignedJobs.Location = new System.Drawing.Point(143, 299);
            this.cblAssignedJobs.Name = "cblAssignedJobs";
            this.cblAssignedJobs.Size = new System.Drawing.Size(173, 94);
            this.cblAssignedJobs.TabIndex = 7;
            // 
            // lAssignedJobs
            // 
            this.lAssignedJobs.AutoSize = true;
            this.lAssignedJobs.Location = new System.Drawing.Point(10, 299);
            this.lAssignedJobs.Name = "lAssignedJobs";
            this.lAssignedJobs.Size = new System.Drawing.Size(75, 13);
            this.lAssignedJobs.TabIndex = 24;
            this.lAssignedJobs.Text = "Assigned Jobs";
            // 
            // lExclusions
            // 
            this.lExclusions.AutoSize = true;
            this.lExclusions.Location = new System.Drawing.Point(11, 169);
            this.lExclusions.Name = "lExclusions";
            this.lExclusions.Size = new System.Drawing.Size(57, 13);
            this.lExclusions.TabIndex = 26;
            this.lExclusions.Text = "Exclusions";
            // 
            // bAddExclusion
            // 
            this.bAddExclusion.Location = new System.Drawing.Point(143, 270);
            this.bAddExclusion.Name = "bAddExclusion";
            this.bAddExclusion.Size = new System.Drawing.Size(80, 23);
            this.bAddExclusion.TabIndex = 28;
            this.bAddExclusion.Text = "Add";
            this.bAddExclusion.UseVisualStyleBackColor = true;
            this.bAddExclusion.Click += new System.EventHandler(this.bAddExclusion_Click);
            // 
            // bDeleteExclusion
            // 
            this.bDeleteExclusion.Location = new System.Drawing.Point(236, 270);
            this.bDeleteExclusion.Name = "bDeleteExclusion";
            this.bDeleteExclusion.Size = new System.Drawing.Size(80, 23);
            this.bDeleteExclusion.TabIndex = 29;
            this.bDeleteExclusion.Text = "Delete";
            this.bDeleteExclusion.UseVisualStyleBackColor = true;
            this.bDeleteExclusion.Click += new System.EventHandler(this.bDeleteExclusion_Click);
            // 
            // lvJobExclusions
            // 
            this.lvJobExclusions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDay,
            this.colJob});
            this.lvJobExclusions.Location = new System.Drawing.Point(143, 169);
            this.lvJobExclusions.MultiSelect = false;
            this.lvJobExclusions.Name = "lvJobExclusions";
            this.lvJobExclusions.Size = new System.Drawing.Size(172, 95);
            this.lvJobExclusions.TabIndex = 30;
            this.lvJobExclusions.UseCompatibleStateImageBehavior = false;
            this.lvJobExclusions.View = System.Windows.Forms.View.Details;
            // 
            // colDay
            // 
            this.colDay.Text = "Day";
            this.colDay.Width = 53;
            // 
            // colJob
            // 
            this.colJob.Text = "Job";
            this.colJob.Width = 114;
            // 
            // FBrothers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 465);
            this.Controls.Add(this.lvJobExclusions);
            this.Controls.Add(this.bDeleteExclusion);
            this.Controls.Add(this.bAddExclusion);
            this.Controls.Add(this.lExclusions);
            this.Controls.Add(this.cblAssignedJobs);
            this.Controls.Add(this.lAssignedJobs);
            this.Controls.Add(this.numMinMeetingsBetweenJobs);
            this.Controls.Add(this.lMinMeetingsBetweenJobs);
            this.Controls.Add(this.numStandInsPerPeriod);
            this.Controls.Add(this.lStandInsPerPeriod);
            this.Controls.Add(this.numJobsPerPeriod);
            this.Controls.Add(this.lJobsPerPeriod);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.lLastName);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cbEditBrother);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FBrothers";
            this.Text = "Add / Edit Brother";
            ((System.ComponentModel.ISupportInitialize)(this.numJobsPerPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStandInsPerPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMeetingsBetweenJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFirstName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cbEditBrother;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lLastName;
        private System.Windows.Forms.Label lJobsPerPeriod;
        private System.Windows.Forms.NumericUpDown numJobsPerPeriod;
        private System.Windows.Forms.NumericUpDown numStandInsPerPeriod;
        private System.Windows.Forms.Label lStandInsPerPeriod;
        private System.Windows.Forms.NumericUpDown numMinMeetingsBetweenJobs;
        private System.Windows.Forms.Label lMinMeetingsBetweenJobs;
        private System.Windows.Forms.CheckedListBox cblAssignedJobs;
        private System.Windows.Forms.Label lAssignedJobs;
        private System.Windows.Forms.Label lExclusions;
        private System.Windows.Forms.Button bAddExclusion;
        private System.Windows.Forms.Button bDeleteExclusion;
        private System.Windows.Forms.ListView lvJobExclusions;
        private System.Windows.Forms.ColumnHeader colDay;
        private System.Windows.Forms.ColumnHeader colJob;
    }
}