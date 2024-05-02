namespace Enrollment_System
{
    partial class StudentEnrollmentEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.CourseTextBox = new System.Windows.Forms.TextBox();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.EDPCodeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EDPCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EncodedByTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalUnitsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Course:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Year:";
            // 
            // IDNumberTextBox
            // 
            this.IDNumberTextBox.Location = new System.Drawing.Point(130, 43);
            this.IDNumberTextBox.Multiline = true;
            this.IDNumberTextBox.Name = "IDNumberTextBox";
            this.IDNumberTextBox.Size = new System.Drawing.Size(126, 20);
            this.IDNumberTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(130, 82);
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(126, 20);
            this.NameTextBox.TabIndex = 5;
            // 
            // CourseTextBox
            // 
            this.CourseTextBox.Location = new System.Drawing.Point(130, 111);
            this.CourseTextBox.Multiline = true;
            this.CourseTextBox.Name = "CourseTextBox";
            this.CourseTextBox.Size = new System.Drawing.Size(78, 20);
            this.CourseTextBox.TabIndex = 6;
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(270, 110);
            this.YearTextBox.Multiline = true;
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(78, 20);
            this.YearTextBox.TabIndex = 7;
            // 
            // EDPCodeTextBox
            // 
            this.EDPCodeTextBox.Location = new System.Drawing.Point(130, 193);
            this.EDPCodeTextBox.Multiline = true;
            this.EDPCodeTextBox.Name = "EDPCodeTextBox";
            this.EDPCodeTextBox.Size = new System.Drawing.Size(148, 20);
            this.EDPCodeTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "EDP Code:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDPCodeColumn,
            this.SubjectCodeColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.DaysColumn,
            this.RoomColumn,
            this.UnitsColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 117);
            this.dataGridView1.TabIndex = 10;
            // 
            // EDPCodeColumn
            // 
            this.EDPCodeColumn.HeaderText = "EDP Code";
            this.EDPCodeColumn.Name = "EDPCodeColumn";
            // 
            // SubjectCodeColumn
            // 
            this.SubjectCodeColumn.HeaderText = "Subject Code";
            this.SubjectCodeColumn.Name = "SubjectCodeColumn";
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.HeaderText = "Start Time";
            this.StartTimeColumn.Name = "StartTimeColumn";
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.HeaderText = "End Time";
            this.EndTimeColumn.Name = "EndTimeColumn";
            // 
            // DaysColumn
            // 
            this.DaysColumn.HeaderText = "Days";
            this.DaysColumn.Name = "DaysColumn";
            // 
            // RoomColumn
            // 
            this.RoomColumn.HeaderText = "Room";
            this.RoomColumn.Name = "RoomColumn";
            // 
            // UnitsColumn
            // 
            this.UnitsColumn.HeaderText = "Units";
            this.UnitsColumn.Name = "UnitsColumn";
            // 
            // EncodedByTextBox
            // 
            this.EncodedByTextBox.Location = new System.Drawing.Point(92, 355);
            this.EncodedByTextBox.Multiline = true;
            this.EncodedByTextBox.Name = "EncodedByTextBox";
            this.EncodedByTextBox.Size = new System.Drawing.Size(148, 20);
            this.EncodedByTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Encoded By:";
            // 
            // TotalUnitsTextBox
            // 
            this.TotalUnitsTextBox.Location = new System.Drawing.Point(618, 352);
            this.TotalUnitsTextBox.Multiline = true;
            this.TotalUnitsTextBox.Name = "TotalUnitsTextBox";
            this.TotalUnitsTextBox.Size = new System.Drawing.Size(106, 20);
            this.TotalUnitsTextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(554, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Total Units:";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(718, 413);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(70, 25);
            this.BackButton.TabIndex = 15;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // StudentEnrollmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.TotalUnitsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EncodedByTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EDPCodeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.CourseTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.IDNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudentEnrollmentEntry";
            this.Text = "StudentEnrollmentEntry";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IDNumberTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox CourseTextBox;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.TextBox EDPCodeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDPCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn;
        private System.Windows.Forms.TextBox EncodedByTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalUnitsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BackButton;
    }
}