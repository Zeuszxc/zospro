using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = //@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\ZEUSSSS\zospro-main\Caballes.accdb";
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ZEUSSSS\zospro-main\Caballes.accdb";

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                OleDbCommand thisCommandPreq = thisConnection.CreateCommand();
                string sqlP = "SELECT * FROM SUBJECTPREQFILE";
                thisCommandPreq.CommandText = sqlP;

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
                OleDbDataReader thisDataReaderP = thisCommandPreq.ExecuteReader();


                bool found = false;
                string subjectCode = "";
                string description = "";
                string units = "";
                string requisite = "";

                while (thisDataReader.Read())
                {
                    // MessageBox.Show(thisDataReader["SFSUBJCODE"].ToString());
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                        
                    {
                        found = true;
                        subjectCode = thisDataReader["SFSUBJCODE"].ToString();
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        units = thisDataReader["SFSUBJUNITS"].ToString();
                        break;
                        //
                    }

                }
                while (thisDataReaderP.Read()) {
                    if ((thisDataReaderP["SUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())) { 
                        requisite = thisDataReaderP["SUBJPRECODE"].ToString();
                        break;
                    }
                }

                int index;
                if (found == false)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
                    SubjectDataGridView.Rows[index].Cells["CoPreColumn"].Value = requisite;

                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SubjCodeTextBox.Text = "";
            DescriptionTextBox.Text = "";
            UnitsTextBox.Text = "";
            CategoryComboBox.Text = "";
            OfferingComboBox.Text = "";
            CourseCodeComboBox.Text = "";
            CurriculumCodeTextBox.Text = "";
            RequisiteTextBox.Text = "";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry subjectScheduleEntry = new SubjectScheduleEntry();
            subjectScheduleEntry.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
          
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "SELECT * FROM SubjectFile";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();
            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "SubjectFile");

            DataRow findRow = thisDataSet.Tables["SubjectFile"].Rows.Find(SubjCodeTextBox.Text);

            if (findRow==null)
            {
                DataRow thisRow = thisDataSet.Tables["SubjectFile"].NewRow();
                thisRow["SFSUBJCODE"] = SubjCodeTextBox.Text;
                thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
                thisRow["SFSUBJUNITS"] = UnitsTextBox.Text;
                thisRow["SFSUBJREOFRNG"] = OfferingComboBox.Text.Substring(0, 1);
                thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text;
                thisRow["SFSUBJSTATUS"] = "AC";
                thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
                thisRow["SFSUBJCURRCODE"] = CurriculumCodeTextBox.Text;

                thisDataSet.Tables["SubjectFile"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "SubjectFile");

                //SAVE DATA TO SUBJPREQFILE//

                thisConnection = new OleDbConnection(connectionString);
                Ole = "SELECT * FROM SUBJECTPREQFILE";
                thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
                thisBuilder = new OleDbCommandBuilder(thisAdapter);
                thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "SubjectPreqFile");

                thisRow = thisDataSet.Tables["SubjectPreqFile"].NewRow();

                if (RequisiteTextBox.Text != string.Empty)
                {
                    thisRow["SUBJCODE"] = SubjCodeTextBox.Text;
                    thisRow["SUBJPRECODE"] = RequisiteTextBox.Text;
                    if (PreRequisiteRadioButton.Checked == true)
                    {
                        thisRow["SUBJPRECATEGORY"] = "PR";
                    }

                    else if (CoRequisiteRadioButton.Checked == true)
                    {
                        thisRow["SUBJPRECATEGORY"] = "CR";
                    }

                    thisDataSet.Tables["SubjectPreqFile"].Rows.Add(thisRow);
                    thisAdapter.Update(thisDataSet, "SubjectPreqFile");
                }

                MessageBox.Show("RECORDED");
            }
            else {
                MessageBox.Show("Duplicate Entry!");
            }

            


            //OleDbConnection requisiteConnection = new OleDbConnection(connectionString);
            //string requisite = "SELECT * FROM SUBJECTPREQFILE";
            //OleDbDataAdapter requisiteAdapter = new OleDbDataAdapter(requisite, requisiteConnection);
            //OleDbCommandBuilder requisiteBuilder = new OleDbCommandBuilder(requisiteAdapter);

            //thisAdapter.Fill(thisDataSet, "SUBJECTPREQFILE");

            ////setup primary key
            //DataColumn[] keys = new DataColumn[2];

            //keys[0] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJCODE"];
            //keys[1] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJPRECODE"];

            //String[] valuesToSearch = new string[2];
            //valuesToSearch[0] = SubjCodeTextBox.Text;
            //valuesToSearch[1] = RequisiteTextBox.Text;

            //DataRow findRequisiteRow = thisDataSet.Tables["SUBJECTPREQFILE"].Rows.Find(valuesToSearch);
            //if (findRequisiteRow == null)
            //{

            //    DataRow thisRequisiteRow = thisDataSet.Tables["SUBJECTPREQFILE"].NewRow();

            //    thisRequisiteRow["SUBJCODE"] = SubjCodeTextBox.Text;
            //    thisRequisiteRow["SUBJPRECODE"] = RequisiteTextBox.Text;
            //    thisDataSet.Tables["SUBJECTPREQFILE"].Rows.Add(thisRequisiteRow);
            //    thisAdapter.Update(thisDataSet, "SUBJECTPREQFILE");
            //    MessageBox.Show("Entries Recorded");
            //}
            //else
            //{
            //    MessageBox.Show("Duplicate Entry!");
            //}



        }
    }
}

   
