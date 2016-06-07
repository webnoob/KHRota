namespace KHRota.Forms
{
    partial class FDisplayReport
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
            this.pReport = new System.Windows.Forms.Panel();
            this.cbJobGroups = new System.Windows.Forms.ComboBox();
            this.lChooseGroup = new System.Windows.Forms.Label();
            this.printDoc1 = new System.Drawing.Printing.PrintDocument();
            this.bPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.bEmailToAllBrothers = new System.Windows.Forms.Button();
            this.bEmailToBrother = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pReport
            // 
            this.pReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pReport.Location = new System.Drawing.Point(0, 39);
            this.pReport.Name = "pReport";
            this.pReport.Size = new System.Drawing.Size(866, 413);
            this.pReport.TabIndex = 4;
            // 
            // cbJobGroups
            // 
            this.cbJobGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJobGroups.FormattingEnabled = true;
            this.cbJobGroups.Location = new System.Drawing.Point(145, 12);
            this.cbJobGroups.Name = "cbJobGroups";
            this.cbJobGroups.Size = new System.Drawing.Size(262, 21);
            this.cbJobGroups.TabIndex = 5;
            this.cbJobGroups.SelectedIndexChanged += new System.EventHandler(this.cbJobGroups_SelectedIndexChanged);
            // 
            // lChooseGroup
            // 
            this.lChooseGroup.AutoSize = true;
            this.lChooseGroup.Location = new System.Drawing.Point(12, 18);
            this.lChooseGroup.Name = "lChooseGroup";
            this.lChooseGroup.Size = new System.Drawing.Size(127, 13);
            this.lChooseGroup.TabIndex = 6;
            this.lChooseGroup.Text = "Show Data for Job Group";
            // 
            // printDoc1
            // 
            this.printDoc1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc1_BeginPrint);
            this.printDoc1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc1_PrintPage);
            // 
            // bPrint
            // 
            this.bPrint.Location = new System.Drawing.Point(413, 12);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(136, 21);
            this.bPrint.TabIndex = 7;
            this.bPrint.Text = "Print";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // bEmailToAllBrothers
            // 
            this.bEmailToAllBrothers.Location = new System.Drawing.Point(555, 12);
            this.bEmailToAllBrothers.Name = "bEmailToAllBrothers";
            this.bEmailToAllBrothers.Size = new System.Drawing.Size(136, 21);
            this.bEmailToAllBrothers.TabIndex = 8;
            this.bEmailToAllBrothers.Text = "Email To All Brothers";
            this.bEmailToAllBrothers.UseVisualStyleBackColor = true;
            this.bEmailToAllBrothers.Click += new System.EventHandler(this.bEmailToAllBrothers_Click);
            // 
            // bEmailToBrother
            // 
            this.bEmailToBrother.Location = new System.Drawing.Point(697, 12);
            this.bEmailToBrother.Name = "bEmailToBrother";
            this.bEmailToBrother.Size = new System.Drawing.Size(136, 21);
            this.bEmailToBrother.TabIndex = 9;
            this.bEmailToBrother.Text = "Email To Brother";
            this.bEmailToBrother.UseVisualStyleBackColor = true;
            this.bEmailToBrother.Click += new System.EventHandler(this.bEmailToBrother_Click);
            // 
            // FDisplayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 452);
            this.Controls.Add(this.bEmailToBrother);
            this.Controls.Add(this.bEmailToAllBrothers);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.lChooseGroup);
            this.Controls.Add(this.cbJobGroups);
            this.Controls.Add(this.pReport);
            this.Name = "FDisplayReport";
            this.Text = "Display Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pReport;
        private System.Windows.Forms.ComboBox cbJobGroups;
        private System.Windows.Forms.Label lChooseGroup;
        private System.Drawing.Printing.PrintDocument printDoc1;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button bEmailToAllBrothers;
        private System.Windows.Forms.Button bEmailToBrother;
    }
}