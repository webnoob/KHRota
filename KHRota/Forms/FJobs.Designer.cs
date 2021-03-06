﻿namespace KHRota.Forms
{
    partial class FJobs
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
            this.lJobName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbEditJob = new System.Windows.Forms.ComboBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.lJobGroup = new System.Windows.Forms.Label();
            this.cbJobGroups = new System.Windows.Forms.ComboBox();
            this.bAddJobGroup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bEditGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDisabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lJobName
            // 
            this.lJobName.AutoSize = true;
            this.lJobName.Location = new System.Drawing.Point(13, 46);
            this.lJobName.Name = "lJobName";
            this.lJobName.Size = new System.Drawing.Size(55, 13);
            this.lJobName.TabIndex = 0;
            this.lJobName.Text = "Job Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(144, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(172, 20);
            this.tbName.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(13, 152);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(304, 23);
            this.bSave.TabIndex = 9;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(13, 181);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(304, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Close";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbEditJob
            // 
            this.cbEditJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditJob.FormattingEnabled = true;
            this.cbEditJob.Location = new System.Drawing.Point(13, 12);
            this.cbEditJob.Name = "cbEditJob";
            this.cbEditJob.Size = new System.Drawing.Size(222, 21);
            this.cbEditJob.TabIndex = 11;
            this.cbEditJob.SelectedIndexChanged += new System.EventHandler(this.cbEditMeeting_SelectedIndexChanged);
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
            // lJobGroup
            // 
            this.lJobGroup.AutoSize = true;
            this.lJobGroup.Location = new System.Drawing.Point(12, 73);
            this.lJobGroup.Name = "lJobGroup";
            this.lJobGroup.Size = new System.Drawing.Size(56, 13);
            this.lJobGroup.TabIndex = 13;
            this.lJobGroup.Text = "Job Group";
            // 
            // cbJobGroups
            // 
            this.cbJobGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJobGroups.FormattingEnabled = true;
            this.cbJobGroups.Location = new System.Drawing.Point(144, 65);
            this.cbJobGroups.Name = "cbJobGroups";
            this.cbJobGroups.Size = new System.Drawing.Size(172, 21);
            this.cbJobGroups.TabIndex = 14;
            // 
            // bAddJobGroup
            // 
            this.bAddJobGroup.Location = new System.Drawing.Point(127, 123);
            this.bAddJobGroup.Name = "bAddJobGroup";
            this.bAddJobGroup.Size = new System.Drawing.Size(91, 23);
            this.bAddJobGroup.TabIndex = 15;
            this.bAddJobGroup.Text = "Add Group";
            this.bAddJobGroup.UseVisualStyleBackColor = true;
            this.bAddJobGroup.Click += new System.EventHandler(this.bAddJobGroup_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bEditGroup
            // 
            this.bEditGroup.Location = new System.Drawing.Point(13, 123);
            this.bEditGroup.Name = "bEditGroup";
            this.bEditGroup.Size = new System.Drawing.Size(91, 23);
            this.bEditGroup.TabIndex = 17;
            this.bEditGroup.Text = "Edit Group";
            this.bEditGroup.UseVisualStyleBackColor = true;
            this.bEditGroup.Click += new System.EventHandler(this.bEditGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Disabled?";
            // 
            // cbDisabled
            // 
            this.cbDisabled.AutoSize = true;
            this.cbDisabled.Location = new System.Drawing.Point(144, 93);
            this.cbDisabled.Name = "cbDisabled";
            this.cbDisabled.Size = new System.Drawing.Size(15, 14);
            this.cbDisabled.TabIndex = 19;
            this.cbDisabled.UseVisualStyleBackColor = true;
            // 
            // FJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 213);
            this.Controls.Add(this.cbDisabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bEditGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bAddJobGroup);
            this.Controls.Add(this.cbJobGroups);
            this.Controls.Add(this.lJobGroup);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cbEditJob);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lJobName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FJobs";
            this.Text = "Add / Edit Jobs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lJobName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cbEditJob;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Label lJobGroup;
        private System.Windows.Forms.ComboBox cbJobGroups;
        private System.Windows.Forms.Button bAddJobGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bEditGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDisabled;
    }
}