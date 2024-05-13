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

        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\APPSDEV\zospro-main\Caballes.accdb";
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

            thisRow["SSFXM"] = AMPMComboBox.Text.Substring(0,2);
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
    }
}
