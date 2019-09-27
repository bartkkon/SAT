using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;


namespace Saving_Accelerator_Tool
{
    public partial class Outliv
    {
        /// <summary>
        /// Methods to Load File Outliv to Programs for OUTLIV file
        /// </summary>
        /// <param name="form"></param>
        public void Outliv_LoadFile(MainProgram form)
        {
            ClearDataGridTable(form);
            string link;

            //link = Outliv_FileDate();
            link = @"C:\Users\bartkkon\Desktop\outliv.txt";
            if (link == "0")
            {
                MessageBox.Show("Od ponad miesiąca plik nie jest generowany");
            }
            else
            {
                string[,] table_Outliv = new string[20, 2];
                table_Outliv = Outliv_table();
                LoadTable(link, ref table_Outliv, form);
                TextBoxEnable(ref table_Outliv, form);
            }

            //form.pb_LoadFileOutliv.Text = "Refresh";
            //form.pb_ClearOutliv.Enabled = true;

        }

        /// <summary>
        /// Remove data from Data Grid in OULTIV
        /// </summary>
        /// <param name="form"></param>
        public void OutlivClearButton(MainProgram form)
        {
            ClearDataGridTable(form);
            //form.pb_LoadFileOutliv.Text = "Load File";
            //form.pb_ClearOutliv.Enabled = false;
            //form.TB_PNC_Outliv.Enabled = false;
            //form.TB_ANC_Outliv.Enabled = false;
            //form.TB_ANCDes_Outliv.Enabled = false;
            //form.PB_Search_Outliv.Enabled = false;
        }

        public void OutlivSearchButton(MainProgram form)
        {
            //string rowFilter = "";
            //if (form.TB_PNC_Outliv.Enabled)
            //{
            //    string Pnc = form.TB_PNC_Outliv.Text;
            //    rowFilter = string.Format("[{0}] = '{1}'", "PNC", Pnc);
            //}

            //if (form.TB_ANC_Outliv.Enabled)
            //{
            //    string ANC = form.TB_ANC_Outliv.Text;
            //    if (ANC != "")
            //    {
            //        if (rowFilter == "")
            //        {
            //            rowFilter = string.Format("AND [{0}] = '{1}'", "ANC", ANC);
            //        }
            //        else
            //        {
            //            rowFilter += string.Format("AND [{0}] = '{1}'", "ANC", ANC);
            //        }
            //    }
            //}
            //if (form.TB_ANCDes_Outliv.Enabled)
            //{
            //    string ANCDes = form.TB_ANCDes_Outliv.Text;
            //    if (ANCDes != "")
            //    {
            //        if (rowFilter == "")
            //        {
            //            rowFilter = string.Format("AND [{0}] = '{1}'", "ANC DESCRIPTION", ANCDes);
            //        }
            //        else
            //        {
            //            rowFilter += string.Format("AND [{0}] = '{1}'", "ANC DESCRIPTION", ANCDes);
            //        }
            //    }

            //}
            //(form.dg_ToOutliv.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            //form.dg_ToOutliv.Refresh();
        }

        /// <summary>
        /// According to status Check list Box, Text box are change Enable status. If in Check List Box is Checked, Text Box are enable.
        /// </summary>
        /// <param name="table_Outliv"></param>
        /// <param name="form"></param>
        private void TextBoxEnable(ref string[,] table_Outliv, MainProgram form)
        {
            //if (table_Outliv[0, 1] == "1")
            //{
            //    form.TB_PNC_Outliv.Enabled = true;
            //    form.PB_Search_Outliv.Enabled = true;
            //}
            //else
            //{
            //    form.TB_PNC_Outliv.Enabled = false;
            //}
            //if (table_Outliv[3, 1] == "1")
            //{
            //    form.TB_ANC_Outliv.Enabled = true;
            //    form.PB_Search_Outliv.Enabled = true;
            //}
            //else
            //{
            //    form.TB_ANC_Outliv.Enabled = false;
            //}
            //if (table_Outliv[4, 1] == "1")
            //{
            //    form.TB_ANCDes_Outliv.Enabled = true;
            //    form.PB_Search_Outliv.Enabled = true;
            //}
            //else
            //{
            //    form.TB_ANCDes_Outliv.Enabled = false;
            //}
        }

        /// <summary>
        /// Clear Data Grid Table in Outlive. Remove all Rows and columns
        /// </summary>
        /// <param name="form"></param>
        private void ClearDataGridTable(MainProgram form)
        {
            //form.dg_ToOutliv.DataSource = null;
            //form.dg_ToOutliv.Refresh();
        }


        /// <summary>
        /// Load File Outliv to Data Grid
        /// </summary>
        /// <param name="link"> Link to File</param>
        /// <param name="OutliveTable">Check box Status</param>
        /// <param name="form"></param>
        private void LoadTable(string link, ref string[,] OutliveTable, MainProgram form)
        {
            int counter = 0;
            int counter3 = 0;


            DataTable Table = new DataTable();
            string[] OutlivFile = File.ReadAllLines(link);

            CheckListCheckbox(ref OutliveTable, form);
            OutlivCreateColumsTable(ref OutliveTable, ref Table);


            foreach (string line in OutlivFile)
            {
                var columns = line.Split(';');

                if (counter != 0)
                {
                    int counter4 = 1;
                    DataRow OutlivRow = Table.NewRow();
                    for (int counter2 = 0; counter2 < 20; counter2++)
                    {
                        if (counter2 == 2)
                        {
                            counter4++;
                        }
                        if (OutliveTable[counter2, 1] == "1")
                        {
                            OutlivRow[counter3] = columns[counter4];
                            counter3++;
                        }
                        counter4++;
                    }
                    counter3 = 0;
                    Table.Rows.Add(OutlivRow);
                }
                counter++;
            }

            //form.dg_ToOutliv.DataSource = Table;
            //form.dg_ToOutliv.Show();

        }

        /// <summary>
        /// Create Colums in Data Grid Table Outliv according to Check box status
        /// </summary>
        /// <param name="OutlivTable"></param>
        /// <param name="Table"></param>
        private void OutlivCreateColumsTable(ref string[,] OutlivTable, ref DataTable Table)
        {
            for (int counter = 0; counter < 20; counter++)
            {
                if (OutlivTable[counter, 1] == "1")
                {
                    Table.Columns.Add(new DataColumn(OutlivTable[counter, 0]));
                }
            }
        }

        /// <summary>
        /// Check Status of Check List Box in Outliv
        /// </summary>
        /// <param name="OutlivTable"></param>
        /// <param name="form"></param>
        private void CheckListCheckbox(ref string[,] OutlivTable, MainProgram form)
        {
            for (int counter = 0; counter < 20; counter++)
            {
                //if (form.clb_ToOutliv.GetItemCheckState(counter) == CheckState.Checked)
                //{
                //    OutlivTable[counter, 1] = 1.ToString();
                //}
            }
        }


        /// <summary>
        /// Table to Check Box List for Outlive 
        /// </summary>
        /// <returns>Table with paramiters</returns>
        private string[,] Outliv_table()
        {
            string[,] table_Outliv = new string[20, 2];
            table_Outliv[0, 0] = "PNC";
            table_Outliv[0, 1] = "0";
            table_Outliv[1, 0] = "Description";
            table_Outliv[1, 1] = "0";
            table_Outliv[2, 0] = "LEVEL";
            table_Outliv[2, 1] = "0";
            table_Outliv[3, 0] = "ANC";
            table_Outliv[3, 1] = "0";
            table_Outliv[4, 0] = "ANC DESCRIPTION";
            table_Outliv[4, 1] = "0";
            table_Outliv[5, 0] = "QTY USED";
            table_Outliv[5, 1] = "0";
            table_Outliv[6, 0] = "UM";
            table_Outliv[6, 1] = "0";
            table_Outliv[7, 0] = "BC";
            table_Outliv[7, 1] = "0";
            table_Outliv[8, 0] = "RS";
            table_Outliv[8, 1] = "0";
            table_Outliv[9, 0] = "DEF";
            table_Outliv[9, 1] = "0";
            table_Outliv[10, 0] = "IDCO";
            table_Outliv[10, 1] = "0";
            table_Outliv[11, 0] = "PQ";
            table_Outliv[11, 1] = "0";
            table_Outliv[12, 0] = "BUYER";
            table_Outliv[12, 1] = "0";
            table_Outliv[13, 0] = "PERFIX";
            table_Outliv[13, 1] = "0";
            table_Outliv[14, 0] = "SUFX";
            table_Outliv[14, 1] = "0";
            table_Outliv[15, 0] = "SEC";
            table_Outliv[15, 1] = "0";
            table_Outliv[16, 0] = "START DATE";
            table_Outliv[16, 1] = "0";
            table_Outliv[17, 0] = "EEC";
            table_Outliv[17, 1] = "0";
            table_Outliv[18, 0] = "END DATE";
            table_Outliv[18, 1] = "0";
            table_Outliv[19, 0] = "A";
            table_Outliv[19, 1] = "0";

            return table_Outliv;
        }

        /// <summary>
        /// Method to create string with link to Outliv file in serwer. If file not exist with current date, method check if file was genereted before (max 30 day back)
        /// </summary>
        /// <returns>Links to Outliv File in Serwer</returns>
        private string Outliv_FileDate()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int day = DateTime.Today.Day;
            string link;


            link = GeneratedLinkOutliv(year, month, day);
            if (File.Exists(link))
            {
                return link;
            }
            else
            {
                for (int counter = 1; counter < 31; counter++)
                {
                    day = day - 1;
                    CheckDateOutliv(ref year, ref month, ref day);
                    link = GeneratedLinkOutliv(year, month, day);
                    if (File.Exists(link))
                    {
                        return link;
                    }
                }
                return link = "0";
            }
        }

        /// <summary>
        /// Method to check if date is correct
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        private void CheckDateOutliv(ref int year, ref int month, ref int day)
        {
            if (day == 0)
            {
                month = month - 1;
                if (month == 0)
                {
                    month = 12;
                    year = year - 1;
                }
                if (month % 2 == 0)
                {
                    day = 30;
                }
                else
                {
                    if (month == 2)
                    {
                        day = 28;
                    }
                    else
                    {
                        day = 31;
                    }
                }
            }
        }

        /// <summary>
        /// Method to genereted final link to Outliv file in serwer
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private string GeneratedLinkOutliv(int year, int month, int day)
        {
            string link;
            string Year;
            string Month;
            string Day;

            Year = year.ToString();

            if (month < 10)
            {
                Month = "0" + month.ToString();
            }
            else
            {
                Month = month.ToString();
            }

            if (day < 10)
            {
                Day = "0" + day.ToString();
            }
            else
            {
                Day = day.ToString();
            }

            link = @"I:\raporty Copics\" + Year + @"\" + Year + Month + @"\" + Year + Month + Day + @"\outliv.txt";

            return link;
        }
    }
}
