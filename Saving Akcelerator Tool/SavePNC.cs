using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    public class SavePNC
    {
        public SavePNC()
        {
            Save();
        }

        private void Save()
        {
            Excel.Application Raport;
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            bool PNC = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNC", true).First()).Checked;
            bool PNCSpec = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked;
            DataGridView PNCList = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();
            string FileName = Name();

            if (PNCList.Rows.Count > 0)
            {
                Create_Excel_Application _Application = new Create_Excel_Application();
                Raport = _Application.Create_Application();
                Raport.Visible = false;
                Raport.DisplayAlerts = false;
                Raport.ScreenUpdating = false;
                Raport.DisplayStatusBar = false;
                Raport.EnableEvents = false;

                Create_Excel_WorkBooks _Excel_WorkBooks = new Create_Excel_WorkBooks();
                workbook = _Excel_WorkBooks.Create_WorkBooks(Raport);

                Create_Excel_WorkSheet _Excel_WorkSheet = new Create_Excel_WorkSheet();
                worksheet = _Excel_WorkSheet.Create_WorkSheet(workbook, "Action");

                if (PNC)
                {
                    CreatePNC(worksheet);
                    Save_Excel_WorkBook_All Save = new Save_Excel_WorkBook_All();
                    Save.Save_WorkBook(Raport, workbook, FileName);
                }
                else if (PNCSpec)
                {
                    CreatePNCSpec(worksheet);
                }
            }
            else
            {
                MessageBox.Show("No data to save!", "Save Data");
            }
        }

        private void CreatePNC(Excel.Worksheet worksheet)
        {
            DataGridView PNCList = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();
            int counter = 2;

            worksheet.Cells[1, 1].Value2 = "PNC";

            foreach (DataGridViewRow Row in PNCList.Rows)
            {
                if (Row.Cells[0].Value != null)
                    worksheet.Cells[counter, 1].Value2 = Row.Cells[0].Value;

                counter++;
            }

        }

        private void CreatePNCSpec(Excel.Worksheet worksheet)
        {
            DataGridView PNCList = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();
            DataTable Table = new DataTable();
            DataRow Row;
            int Column;
            int Column2;
            bool WithSTK = false;
            

            Table.Columns.Add("PNC");
            Table.Columns.Add("ECCC");
            if (PNCList.Columns.Count > 5)
            {
                Table.Columns.Add("Minus");
                Table.Columns.Add("Plus");
                Table.Columns.Add("Delta");
            }

            Column = CheckANC(PNCList);
            for (int counter = 1; counter <= Column; counter++)
            {
                Table.Columns.Add("O" + counter.ToString());
                Table.Columns.Add("O" + counter.ToString() + "Q");
                Table.Columns.Add("N" + counter.ToString());
                Table.Columns.Add("N" + counter.ToString() + "Q");
            }

            foreach (DataGridViewRow RowView in PNCList.Rows)
            {
                if (RowView.Cells[0].Value != null)
                {
                    Row = Table.NewRow();
                    Row["PNC"] = RowView.Cells[0].Value;


                    Column2 = 1;
                }
            }
        }

        private int CheckANC(DataGridView PNCList)
        {
            int ANCCount = 1;
            int ANCtest = 0; ;

            foreach (DataGridViewRow Row in PNCList.Rows)
            {
                if (Row.Cells[0].Value != null)
                {
                    if (ANCtest > ANCCount)
                        ANCCount = ANCtest;
                    ANCtest = 0;
                }
                else
                {
                    ANCtest++;
                }

                if (Row.Index == PNCList.Rows.Count - 1)
                {
                    if (ANCtest > ANCCount)
                        ANCCount = ANCtest;
                }
            }

            return ANCCount;
        }

        private string Name()
        {
            string FileName = ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text;

            FileName = FileName.Replace("/", "_");

            FileName = FileName + "_" + DateTime.Today.Year.ToString();
            FileName = FileName + DateTime.Today.Month.ToString();
            FileName = FileName + DateTime.Today.Day.ToString();
            FileName = FileName + DateTime.Now.Hour.ToString();
            FileName = FileName + DateTime.Now.Minute.ToString();
            FileName = FileName + DateTime.Now.Second.ToString();

            return FileName;
        }
    }
}
