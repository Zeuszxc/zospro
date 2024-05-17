using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class StudentEnrollmentEntry : Form
    {
        public StudentEnrollmentEntry()
        {
            InitializeComponent();
        }

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ZEUSSSS\zospro-main\Caballes.accdb";

        private void BackButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry subjectScheduleEntry = new SubjectScheduleEntry();
            subjectScheduleEntry.Show();
            this.Hide();
        }

        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM StudentFile";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;

                string name = "";
                string course = "";
                string year = "";

                while ( thisDataReader.Read())
                {
                    if (thisDataReader["STFSTUDID"].ToString().Trim().ToUpper() == IDNumberTextBox.Text.Trim().ToUpper())
                    {
                        found = true;

                        name = thisDataReader["STFSTUDLNAME"].ToString() + " " +
                               thisDataReader["STFSTUDFNAME"].ToString() + " " +
                               thisDataReader["STFSTUDMNAME"].ToString().ToString().Substring(0, 1);
                        course = thisDataReader["STFSTUDCOURSE"].ToString();
                        year = thisDataReader["STFSTUDYEAR"].ToString();
                        break;
                    }
                }

                if (found == false)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    NameLabel.Text = name;
                    CourseLabel.Text = course; 
                    YearLabel.Text = year;
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM EnrollmentHeaderFile";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "EnrollmentHeaderFile");

            DataRow findRow = thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Find(IDNumberTextBox.Text);
            if (findRow == null)
            {
                DataRow thisRow = thisDataSet.Tables["EnrollmentHeaderFile"].NewRow();
                thisRow["ENRHFSTUDID"] = IDNumberTextBox.Text;
                thisRow["ENRHFSTUDDATEENROLL"] = DateTimePicker.Text;
                thisRow["ENRHFSTUDENCODER"] = EncodedByTextBox.Text;
                thisRow["ENRHFSTUDTOTALUNITS"] = Convert.ToInt16(TotalUnitsTextBox.Text);
                thisRow["ENRHFSTUDSTATUS"] = "EN";

                thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "EnrollmentHeaderFile");

                MessageBox.Show("Entries Recorded");
            }
        }

        int totalUnits = 0;
        private void EDPCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    OleDbConnection thisConnection = new OleDbConnection(connectionString);
                    thisConnection.Open();
                    OleDbCommand thisCommand = thisConnection.CreateCommand();

                    string sql = "SELECT * FROM SUBJECTSCHEDFILE";
                    thisCommand.CommandText = sql;

                    OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                    bool found = false;
                    string edp = "";
                    string subject = "";
                    string start = "";
                    string end = "";
                    string days = "";
                    string room = "";
                    string max = "";
                    string size = "";
                    string status = "";
                    string fxm = "";
                    string section = "";
                    string school = "";

                    while (thisDataReader.Read())
                    {
                        //MessageBox.Show(thisDataReader["SSFEDPCODE"].ToString());
                        if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == EDPCodeTextBox.Text.Trim().ToUpper())
                        {
                            found = true;
                            edp = thisDataReader["SSFEDPCODE"].ToString();
                            subject = thisDataReader["SSFSUBJCODE"].ToString();
                            start = thisDataReader["SSFSTARTTIME"].ToString();
                            end = thisDataReader["SSFENDTIME"].ToString();
                            days = thisDataReader["SSFDAYS"].ToString();
                            room = thisDataReader["SSFROOM"].ToString();
                            max = thisDataReader["SSFMAXSIZE"].ToString();
                            size = thisDataReader["SSFCLASSSIZE"].ToString();
                            status = thisDataReader["SSFSTATUS"].ToString();
                            fxm = thisDataReader["SSFXM"].ToString();
                            section = thisDataReader["SSFSECTION"].ToString();
                            school = thisDataReader["SSFSCHOOLYEAR"].ToString();
                            break;
                            //
                        }

                    }
                int row, units;
                    if (found == false)
                {
                    row = SubjectDataGridView.Rows.Add();
                    units = Convert.ToInt16(SubjectDataGridView.Rows[row].Cells["UnitsColumn"].Value);
                    totalUnits = totalUnits + units;
                }
   
                    else
                    {
                        
                    MessageBox.Show("Subject Code Not Found");
                }

                }     
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            IDNumberTextBox.Text = "";
            NameLabel.Text = "";
            CourseLabel.Text = "";
            YearLabel.Text = "";
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
