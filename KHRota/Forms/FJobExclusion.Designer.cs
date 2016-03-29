namespace KHRota.Forms
{
    partial class FJobExclusion
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
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lJob = new System.Windows.Forms.Label();
            this.cbJobs = new System.Windows.Forms.ComboBox();
            this.cbDaysOfWeek = new System.Windows.Forms.ComboBox();
            this.lDayOfWeek = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 66);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(304, 23);
            this.bSave.TabIndex = 9;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 95);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(304, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Close";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lJob
            // 
            this.lJob.AutoSize = true;
            this.lJob.Location = new System.Drawing.Point(12, 19);
            this.lJob.Name = "lJob";
            this.lJob.Size = new System.Drawing.Size(24, 13);
            this.lJob.TabIndex = 13;
            this.lJob.Text = "Job";
            // 
            // cbJobs
            // 
            this.cbJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJobs.FormattingEnabled = true;
            this.cbJobs.Location = new System.Drawing.Point(144, 12);
            this.cbJobs.Name = "cbJobs";
            this.cbJobs.Size = new System.Drawing.Size(172, 21);
            this.cbJobs.TabIndex = 14;
            // 
            // cbDaysOfWeek
            // 
            this.cbDaysOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDaysOfWeek.FormattingEnabled = true;
            this.cbDaysOfWeek.Location = new System.Drawing.Point(144, 39);
            this.cbDaysOfWeek.Name = "cbDaysOfWeek";
            this.cbDaysOfWeek.Size = new System.Drawing.Size(172, 21);
            this.cbDaysOfWeek.TabIndex = 16;
            // 
            // lDayOfWeek
            // 
            this.lDayOfWeek.AutoSize = true;
            this.lDayOfWeek.Location = new System.Drawing.Point(12, 46);
            this.lDayOfWeek.Name = "lDayOfWeek";
            this.lDayOfWeek.Size = new System.Drawing.Size(72, 13);
            this.lDayOfWeek.TabIndex = 15;
            this.lDayOfWeek.Text = "Day Of Week";
            // 
            // FJobExclusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 131);
            this.Controls.Add(this.cbDaysOfWeek);
            this.Controls.Add(this.lDayOfWeek);
            this.Controls.Add(this.cbJobs);
            this.Controls.Add(this.lJob);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "FJobExclusion";
            this.Text = "Add Job Exclusion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lJob;
        private System.Windows.Forms.ComboBox cbJobs;
        private System.Windows.Forms.ComboBox cbDaysOfWeek;
        private System.Windows.Forms.Label lDayOfWeek;
    }
}