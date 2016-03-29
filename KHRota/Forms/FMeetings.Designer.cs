namespace KHRota.Forms
{
    partial class FMeetings
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
            this.lMeetingName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lDateTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.lMeetingDay = new System.Windows.Forms.Label();
            this.lMeetingType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbEditMeeting = new System.Windows.Forms.ComboBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.cblRequiredJobs = new System.Windows.Forms.CheckedListBox();
            this.lRequiredJobs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lMeetingName
            // 
            this.lMeetingName.AutoSize = true;
            this.lMeetingName.Location = new System.Drawing.Point(11, 46);
            this.lMeetingName.Name = "lMeetingName";
            this.lMeetingName.Size = new System.Drawing.Size(76, 13);
            this.lMeetingName.TabIndex = 0;
            this.lMeetingName.Text = "Meeting Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(144, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(171, 20);
            this.tbName.TabIndex = 1;
            // 
            // lDateTime
            // 
            this.lDateTime.AutoSize = true;
            this.lDateTime.Location = new System.Drawing.Point(11, 72);
            this.lDateTime.Name = "lDateTime";
            this.lDateTime.Size = new System.Drawing.Size(71, 13);
            this.lDateTime.TabIndex = 3;
            this.lDateTime.Text = "Meeting Time";
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(144, 65);
            this.dtpTime.MinDate = new System.DateTime(2016, 2, 26, 0, 0, 0, 0);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(171, 20);
            this.dtpTime.TabIndex = 4;
            // 
            // cbDayOfWeek
            // 
            this.cbDayOfWeek.DisplayMember = "Monday";
            this.cbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayOfWeek.FormattingEnabled = true;
            this.cbDayOfWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbDayOfWeek.Location = new System.Drawing.Point(144, 91);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(171, 21);
            this.cbDayOfWeek.TabIndex = 5;
            // 
            // lMeetingDay
            // 
            this.lMeetingDay.AutoSize = true;
            this.lMeetingDay.Location = new System.Drawing.Point(11, 99);
            this.lMeetingDay.Name = "lMeetingDay";
            this.lMeetingDay.Size = new System.Drawing.Size(67, 13);
            this.lMeetingDay.TabIndex = 6;
            this.lMeetingDay.Text = "Meeting Day";
            // 
            // lMeetingType
            // 
            this.lMeetingType.AutoSize = true;
            this.lMeetingType.Location = new System.Drawing.Point(11, 126);
            this.lMeetingType.Name = "lMeetingType";
            this.lMeetingType.Size = new System.Drawing.Size(72, 13);
            this.lMeetingType.TabIndex = 8;
            this.lMeetingType.Text = "Meeting Type";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Regular"});
            this.cbType.Location = new System.Drawing.Point(144, 118);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(171, 21);
            this.cbType.TabIndex = 7;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 245);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(302, 23);
            this.bSave.TabIndex = 9;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 274);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(302, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Close";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbEditMeeting
            // 
            this.cbEditMeeting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditMeeting.FormattingEnabled = true;
            this.cbEditMeeting.Location = new System.Drawing.Point(13, 12);
            this.cbEditMeeting.Name = "cbEditMeeting";
            this.cbEditMeeting.Size = new System.Drawing.Size(222, 21);
            this.cbEditMeeting.TabIndex = 11;
            this.cbEditMeeting.SelectedIndexChanged += new System.EventHandler(this.cbEditMeeting_SelectedIndexChanged);
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
            // cblRequiredJobs
            // 
            this.cblRequiredJobs.FormattingEnabled = true;
            this.cblRequiredJobs.Location = new System.Drawing.Point(145, 145);
            this.cblRequiredJobs.Name = "cblRequiredJobs";
            this.cblRequiredJobs.Size = new System.Drawing.Size(169, 94);
            this.cblRequiredJobs.TabIndex = 25;
            // 
            // lRequiredJobs
            // 
            this.lRequiredJobs.AutoSize = true;
            this.lRequiredJobs.Location = new System.Drawing.Point(12, 145);
            this.lRequiredJobs.Name = "lRequiredJobs";
            this.lRequiredJobs.Size = new System.Drawing.Size(75, 13);
            this.lRequiredJobs.TabIndex = 26;
            this.lRequiredJobs.Text = "Required Jobs";
            // 
            // FMeetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 309);
            this.Controls.Add(this.cblRequiredJobs);
            this.Controls.Add(this.lRequiredJobs);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cbEditMeeting);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lMeetingType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lMeetingDay);
            this.Controls.Add(this.cbDayOfWeek);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lDateTime);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lMeetingName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FMeetings";
            this.Text = "Add / Edit Meeting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMeetingName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lDateTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label lMeetingDay;
        private System.Windows.Forms.Label lMeetingType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cbEditMeeting;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.CheckedListBox cblRequiredJobs;
        private System.Windows.Forms.Label lRequiredJobs;
    }
}