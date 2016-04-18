namespace KHRota.Forms
{
    partial class FDatePicker
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
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(12, 12);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(202, 20);
            this.dtDate.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 67);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(202, 22);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Close";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 38);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(202, 22);
            this.bSave.TabIndex = 10;
            this.bSave.Text = "Ok";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // FDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 100);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.dtDate);
            this.Name = "FDatePicker";
            this.Text = "Select a Date";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
    }
}