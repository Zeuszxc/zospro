namespace Enrollment_System
{
    partial class MainForm
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
            this.SubjectEntryButton = new System.Windows.Forms.Button();
            this.SubjectScheduleEntryButton = new System.Windows.Forms.Button();
            this.StudentEnrollmentEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubjectEntryButton
            // 
            this.SubjectEntryButton.Location = new System.Drawing.Point(281, 73);
            this.SubjectEntryButton.Name = "SubjectEntryButton";
            this.SubjectEntryButton.Size = new System.Drawing.Size(210, 55);
            this.SubjectEntryButton.TabIndex = 0;
            this.SubjectEntryButton.Text = "Subject Entry";
            this.SubjectEntryButton.UseVisualStyleBackColor = true;
            this.SubjectEntryButton.Click += new System.EventHandler(this.SubjectEntryButton_Click);
            // 
            // SubjectScheduleEntryButton
            // 
            this.SubjectScheduleEntryButton.Location = new System.Drawing.Point(281, 161);
            this.SubjectScheduleEntryButton.Name = "SubjectScheduleEntryButton";
            this.SubjectScheduleEntryButton.Size = new System.Drawing.Size(210, 55);
            this.SubjectScheduleEntryButton.TabIndex = 1;
            this.SubjectScheduleEntryButton.Text = "Subject Schedule Entry";
            this.SubjectScheduleEntryButton.UseVisualStyleBackColor = true;
            this.SubjectScheduleEntryButton.Click += new System.EventHandler(this.SubjectScheduleEntryButton_Click);
            // 
            // StudentEnrollmentEntryButton
            // 
            this.StudentEnrollmentEntryButton.Location = new System.Drawing.Point(281, 253);
            this.StudentEnrollmentEntryButton.Name = "StudentEnrollmentEntryButton";
            this.StudentEnrollmentEntryButton.Size = new System.Drawing.Size(210, 55);
            this.StudentEnrollmentEntryButton.TabIndex = 2;
            this.StudentEnrollmentEntryButton.Text = "Student Enrollment Entry";
            this.StudentEnrollmentEntryButton.UseVisualStyleBackColor = true;
            this.StudentEnrollmentEntryButton.Click += new System.EventHandler(this.StudentEnrollmentEntryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudentEnrollmentEntryButton);
            this.Controls.Add(this.SubjectScheduleEntryButton);
            this.Controls.Add(this.SubjectEntryButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SubjectEntryButton;
        private System.Windows.Forms.Button SubjectScheduleEntryButton;
        private System.Windows.Forms.Button StudentEnrollmentEntryButton;
    }
}