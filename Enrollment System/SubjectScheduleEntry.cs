using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SubjectScheduleEntry : Form
    {
        public SubjectScheduleEntry()
        {
            InitializeComponent();
        }

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\APPSDEV\zospro\Caballes.accdb";
        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTSCHEDFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "SUBJECTSCHEDFILE");

            DataRow thisRow = thisDataSet.Tables["SUBJECTSCHEDFILE"].NewRow();
            thisRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
            thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SSFSTARTTIME"] = TimeStartTextBox.Text;
            thisRow["SSFENDTIME"] = TimeEndTextBox.Text;
            thisRow["SSFDAYS"] = DaysTextBox.Text;
            thisRow["SSFROOM"] = RoomTextBox.Text;

            thisRow["SSFXM"] = AMPMComboBox.Text.Substring(0, 2);
            thisRow["SSFSECTION"] = SectionTextBox.Text;
            thisRow["SSFSCHOOLYEAR"] = SchoolYearTextBox.Text;

            thisDataSet.Tables["SUBJECTSCHEDFILE"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "SUBJECTSCHEDFILE");

            MessageBox.Show("Entries Recorded");

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            StudentEnrollmentEntry studentEnrollmenEntry = new StudentEnrollmentEntry();
            studentEnrollmenEntry.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void SubjectCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;
                string description = "";

                while (thisDataReader.Read())
                {
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper());
                    {
                        found = true;

                        description = thisDataReader["SFSUBJDESC"].ToString();
                        break;
                    }
                }

                if (found == false)
                
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    DescriptionLabel.Text = description;
                }
                

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SubjectEDPCodeTextBox.Text = "";
            SubjectCodeTextBox.Text = "";
            DescriptionLabel.Text = "";
            TimeStartTextBox.Text = "";
            TimeEndTextBox.Text = "";
            DaysTextBox.Text = "";
            SectionTextBox.Text = "";
            RoomTextBox.Text = "";
            SchoolYearTextBox.Text = "";
            AMPMComboBox.Text = "";

        }
    }
}
