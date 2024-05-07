using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SubjectScheduleEntry : Form
    {
        public SubjectScheduleEntry()
        {
            InitializeComponent();
        }

        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \\Server2\second semester 2023-2024\LAB802\79866_CC_APPSDEV22_1200_0130_PM_TTH\79866-23232127\Desktop\FINALS\Enrollment System\Caballes.accdb";
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
            thisRow["SSFSCHOOLYEAR"] = Convert.ToInt16(SchoolYearTextBox.Text);

            thisDataSet.Tables["SUBJECTSCHEDFILE"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "SUBJECTSCHEDFILE");

            MessageBox.Show("Entries Recorded");

        }

    }
}
