namespace KHRota.Forms
{
    partial class FSelectHistoricSchedule
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
            this.cbMeetingSchedule = new System.Windows.Forms.ComboBox();
            this.bViewSchedule = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMeetingSchedule
            // 
            this.cbMeetingSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeetingSchedule.FormattingEnabled = true;
            this.cbMeetingSchedule.Location = new System.Drawing.Point(12, 12);
            this.cbMeetingSchedule.Name = "cbMeetingSchedule";
            this.cbMeetingSchedule.Size = new System.Drawing.Size(179, 21);
            this.cbMeetingSchedule.TabIndex = 0;
            // 
            // bViewSchedule
            // 
            this.bViewSchedule.Location = new System.Drawing.Point(12, 39);
            this.bViewSchedule.Name = "bViewSchedule";
            this.bViewSchedule.Size = new System.Drawing.Size(260, 23);
            this.bViewSchedule.TabIndex = 1;
            this.bViewSchedule.Text = "View Schedule";
            this.bViewSchedule.UseVisualStyleBackColor = true;
            this.bViewSchedule.Click += new System.EventHandler(this.bViewSchedule_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(12, 68);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(260, 23);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(197, 12);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 13;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // FSelectHistoricSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bViewSchedule);
            this.Controls.Add(this.cbMeetingSchedule);
            this.Name = "FSelectHistoricSchedule";
            this.Text = "FSelectHistoricSchedule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMeetingSchedule;
        private System.Windows.Forms.Button bViewSchedule;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bDelete;
    }
}