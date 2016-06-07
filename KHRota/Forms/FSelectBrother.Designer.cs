namespace KHRota.Forms
{
    partial class FSelectBrother
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
            this.cbEditBrother = new System.Windows.Forms.ComboBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEditBrother
            // 
            this.cbEditBrother.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBrother.FormattingEnabled = true;
            this.cbEditBrother.Location = new System.Drawing.Point(12, 12);
            this.cbEditBrother.Name = "cbEditBrother";
            this.cbEditBrother.Size = new System.Drawing.Size(282, 21);
            this.cbEditBrother.TabIndex = 14;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 67);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(282, 22);
            this.bCancel.TabIndex = 13;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(12, 39);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(282, 22);
            this.bSelect.TabIndex = 12;
            this.bSelect.Text = "Select";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // FSelectBrother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 99);
            this.Controls.Add(this.cbEditBrother);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSelect);
            this.Name = "FSelectBrother";
            this.Text = "FSelectBrother";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEditBrother;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSelect;
    }
}