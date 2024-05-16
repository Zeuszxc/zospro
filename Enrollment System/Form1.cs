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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\APPSDEV\zospro\Caballes.accdb";

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                string subjectCode = "";
                string description = "";
                string units = "";

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

                int index;
                if (found == false)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
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
            mainForm.Show();
            this.Hide();
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();

            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            thisAdapter.Fill(thisDataSet, "SubjectFile");

            DataRow findRow = thisDataSet.Tables["SubjectFile"].NewRow();
            if (findRow == null)
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

                //--------------------- NEW DATABASE-------------------------------\\

                OleDbConnection RequisiteConnection = new OleDbConnection(connectionString);
                string requisite = "SELECT * FROM SUBJECTPREQFILE";
                OleDbDataAdapter requisiteAdapter = new OleDbDataAdapter(requisite, RequisiteConnection);
                OleDbCommandBuilder RequisiteCB = new OleDbCommandBuilder(requisiteAdapter);

                requisiteAdapter.Fill(thisDataSet, "SUBJECTPREQFILE");

                DataColumn[] subjectPreqKeys = new DataColumn[2];
                subjectPreqKeys[0] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJCODE"];
                subjectPreqKeys[1] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJPRECODE"];
                thisDataSet.Tables["SUBJECTPREQFILE"].PrimaryKey = subjectPreqKeys;

                string[] valuesToSearch = new string[2];
                valuesToSearch[0] = SubjCodeTextBox.Text;
                valuesToSearch[1] = RequisiteTextBox.Text;

                DataRow findRequisiteRow = thisDataSet.Tables["SUBJECTPREQFILE"].Rows.Find(valuesToSearch);

                if (findRequisiteRow == null)
                {
                    DataRow thisRequisite = thisDataSet.Tables["SUBJECTPREQFILE"].NewRow();
                    thisRequisite["SUBJCODE"] = SubjCodeTextBox.Text;

                    if (PreRequisiteRadioButton.Checked == true)
                    {
                        thisRequisite["SUBJPRECODE"] = RequisiteTextBox.Text;
                        thisRequisite["SUBJCATEGORY"] = "PR";
                    }
                    else if (CoRequisiteRadioButton.Checked == true)
                    {
                        thisRequisite["SUBJCATEGORY"] = "CO";
                    }
                
                    MessageBox.Show("Entries Recorded!");
                }

                //thisDataSet.Tables["SUBJECTPREQ"].Rows.Add(thisRequisite);
                //requisiteAdapter.Update(thisDataSet, "SUBJECTPREQ");
                 
            }
            else
            {
                MessageBox.Show("Duplicate Entries!");
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

   
