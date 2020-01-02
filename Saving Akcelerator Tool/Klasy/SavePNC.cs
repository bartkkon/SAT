using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

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
                worksheet.Application.ActiveWindow.Zoom = 85;

                if (PNC)
                {
                    CreatePNC(worksheet);
                    Save_Excel_WorkBook_All Save = new Save_Excel_WorkBook_All();
                    Save.Save_WorkBook(Raport, workbook, FileName);
                }
                else if (PNCSpec)
                {
                    CreatePNCSpec(worksheet);
                    Save_Excel_WorkBook_All Save = new Save_Excel_WorkBook_All();
                    Save.Save_WorkBook(Raport, workbook, FileName);
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
            DataRow Row = null;
            int Column;
            int Column2 = 0;
            bool WithSTK = false;
            CheckBox ECCC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCCSpec", true).First();


            Table.Columns.Add("PNC");
            if (ECCC.Checked)
            {
                Table.Columns.Add("ECCC");
            }
            else
                Table.Columns.Add("");

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
                Table.Columns.Add("O" + counter.ToString() + "STK3");
                Table.Columns.Add("N" + counter.ToString());
                Table.Columns.Add("N" + counter.ToString() + "Q");
                Table.Columns.Add("N" + counter.ToString() + "STK3");
            }

            foreach (DataGridViewRow RowView in PNCList.Rows)
            {
                if (RowView.Cells[0].Value != null)
                {
                    if (Row != null)
                    {
                        Table.Rows.Add(Row);
                    }
                    Row = Table.NewRow();
                    Row["PNC"] = RowView.Cells[0].Value;
                    if (ECCC.Checked)
                    {
                        Row["ECCC"] = RowView.Cells[1].Value.ToString().Replace("ECCC(", "").Replace(")", "");
                    }
                    if (PNCList.Columns.Count > 5)
                    {
                        Row["Minus"] = RowView.Cells[5].Value;
                        Row["Plus"] = RowView.Cells[6].Value;
                        Row["Delta"] = RowView.Cells[7].Value;
                    }

                    Column2 = 1;
                }
                else
                {
                    Row["O" + Column2.ToString()] = RowView.Cells[1].Value;
                    Row["O" + Column2.ToString() + "Q"] = RowView.Cells[2].Value;
                    Row["O" + Column2.ToString() + "STK3"] = RowView.Cells[5].Value;
                    Row["N" + Column2.ToString()] = RowView.Cells[3].Value;
                    Row["N" + Column2.ToString() + "Q"] = RowView.Cells[4].Value;
                    Row["N" + Column2.ToString() + "STK3"] = RowView.Cells[6].Value;

                    Column2++;

                    int indexRow = PNCList.Rows.IndexOf(RowView);
                    if (indexRow == PNCList.Rows.Count - 1)
                    {
                        Table.Rows.Add(Row);
                    }
                }
            }

            CreateColumnsForPNCSpec(worksheet, ECCC.Checked, Column);
            //AddValueforPNCSpec(worksheet, ECCC.Checked, Column, Table);
            AddValueforPNCSpecFast(worksheet, ECCC.Checked, Column, Table);
            ColorColumnForPNCSpec(worksheet, Column);
        }

        private void ColorColumnForPNCSpec(Excel.Worksheet worksheet, int column)
        {
            Excel.Range Start = worksheet.Cells[1, 2];
            Excel.Range Finish = worksheet.Cells[1000, 2 + (2 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Red;

            Start = worksheet.Cells[1, 3 + (2 * column)];
            Finish = worksheet.Cells[1000, 3 + (4 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Green;

            Start = worksheet.Cells[1, 4 + (4 * column)];
            Finish = worksheet.Cells[1000, 4 + (5 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Red;

            Start = worksheet.Cells[1, 5 + (5 * column)];
            Finish = worksheet.Cells[1000, 5 + (6 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Green;

            Start = worksheet.Cells[1, 7 + (6 * column)];
            Finish = worksheet.Cells[1000, 7 + (6 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Red;

            Start = worksheet.Cells[1, 8 + (6 * column)];
            Finish = worksheet.Cells[1000, 8 + (6 * column)];

            worksheet.Range[Start, Finish].Font.Color = Color.Green;

            Start = worksheet.Cells[2, 9 + (6 * column)];
            Finish = worksheet.Cells[1000, 9 + (6 * column)];

            Excel.FormatCondition format = (Excel.FormatCondition)worksheet.Range[Start, Finish].FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreater, 0);
            format.Font.Color = Color.Green;
            format = (Excel.FormatCondition)worksheet.Range[Start, Finish].FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLess, 0);
            format.Font.Color = Color.Red;

            Start = worksheet.Cells[2,1];
            Finish = worksheet.Cells[1000, 9 + (6 * column)];

            worksheet.Range[Start, Finish].NumberFormat = "0";
        }

        private void AddValueforPNCSpec(Excel.Worksheet worksheet, bool Eccc, int column, DataTable Table)
        {
            int ExcelRow = 2;

            foreach (DataRow Row in Table.Rows)
            {
                worksheet.Cells[ExcelRow, 1].Value2 = Row["PNC"];
                if (Eccc)
                    worksheet.Cells[ExcelRow, 2].Value2 = double.Parse(Row["ECCC"].ToString());

                for (int counter = 1; counter <= column; counter++)
                {
                    worksheet.Cells[ExcelRow, (2 * counter) + 1].Value2 = Row["O" + counter.ToString()];
                    worksheet.Cells[ExcelRow, (2 * counter) + 2].Value2 = Row["O" + counter.ToString() + "Q"];
                    worksheet.Cells[ExcelRow, (2 * counter) + (2 * column) + 2].Value2 = Row["N" + counter.ToString()];
                    worksheet.Cells[ExcelRow, (2 * counter) + (2 * column) + 3].Value2 = Row["N" + counter.ToString() + "Q"];
                    if (Row["O" + counter.ToString() + "STK3"].ToString() != "")
                        worksheet.Cells[ExcelRow, counter + (column * 4) + 4].Value2 = double.Parse(Row["O" + counter.ToString() + "STK3"].ToString());
                    if (Row["N" + counter.ToString() + "STK3"].ToString() != "")
                        worksheet.Cells[ExcelRow, counter + (column * 5) + 5].Value2 = double.Parse(Row["N" + counter.ToString() + "STK3"].ToString());
                }
                worksheet.Cells[ExcelRow, (column * 6) + 7].Value2 = double.Parse(Row["Minus"].ToString());
                worksheet.Cells[ExcelRow, (column * 6) + 8].Value2 = double.Parse(Row["Plus"].ToString());
                worksheet.Cells[ExcelRow, (column * 6) + 9].Value2 = double.Parse(Row["Delta"].ToString());

                ExcelRow++;
            }
        }

        private void AddValueforPNCSpecFast(Excel.Worksheet worksheet, bool Eccc, int column, DataTable Table)
        {
            int ExcelRow = 2;

            Excel.Range Start;
            Excel.Range Finish;


            foreach (DataRow Row in Table.Rows)
            {
                string[] RowData = new string[6 * column + 9];

                Start = worksheet.Cells[ExcelRow, 1];
                Finish = worksheet.Cells[ExcelRow, 6 * column + 9];

                RowData[0] = Row["PNC"].ToString();
                if (Eccc)
                    RowData[1] = Row["ECCC"].ToString();

                for (int counter = 1; counter <= column; counter++)
                {
                    RowData[2 * counter] = Row["O" + counter.ToString()].ToString();
                    RowData[2 * counter + 1] = Row["O" + counter.ToString() + "Q"].ToString();

                    RowData[(2 * counter) + (2 * column) + 1] = Row["N" + counter.ToString()].ToString();
                    RowData[(2 * counter) + (2 * column) + 2] = Row["N" + counter.ToString() + "Q"].ToString();

                    if (Row["O" + counter.ToString() + "STK3"].ToString() != "")
                        if (Row["O" + counter.ToString() + "STK3"].ToString() != "0" && Row["O" + counter.ToString()].ToString() != "")
                            RowData[counter + (column * 4) + 3] = Row["O" + counter.ToString() + "STK3"].ToString();

                    if (Row["N" + counter.ToString() + "STK3"].ToString() != "")
                        if(Row["N" + counter.ToString() + "STK3"].ToString() != "0" && Row["N" + counter.ToString()].ToString() != "")
                        RowData[counter + (column * 5) + 4] = Row["N" + counter.ToString() + "STK3"].ToString();

                }
                RowData[(column * 6) + 6] = Row["Minus"].ToString();
                RowData[(column * 6) + 7] = Row["Plus"].ToString();
                RowData[(column * 6) + 8] = Row["Delta"].ToString();

                worksheet.Range[Start, Finish].Value2 = RowData;

                ExcelRow++;
            }
        }

        private void CreateColumnsForPNCSpec(Excel.Worksheet worksheet, bool Eccc, int Columns)
        {
            worksheet.Cells[1, 1].Value2 = "PNC";
            if (Eccc)
                worksheet.Cells[1, 2].Value2 = "ECCC";

            for (int counter = 1; counter <= Columns; counter++)
            {
                worksheet.Cells[1, (2 * counter) + 1].Value2 = "OLD ANC " + counter.ToString();
                worksheet.Cells[1, (2 * counter) + 2].Value2 = "OLD ANC " + counter.ToString() + " Quantity";
                worksheet.Cells[1, (2 * counter) + (2 * Columns) + 2].Value2 = "NEW ANC " + counter.ToString();
                worksheet.Cells[1, (2 * counter) + (2 * Columns) + 3].Value2 = "NEW ANC " + counter.ToString() + " Quantity";
                worksheet.Cells[1, counter + (Columns * 4) + 4].Value2 = "OLD ANC " + counter.ToString() + " STK";
                worksheet.Cells[1, counter + (Columns * 5) + 5].Value2 = "NEW ANC " + counter.ToString() + " STK";
            }

            worksheet.Cells[1, (Columns * 6) + 7].Value2 = "Minus";
            worksheet.Cells[1, (Columns * 6) + 8].Value2 = "Plus";
            worksheet.Cells[1, (Columns * 6) + 9].Value2 = "Delta";

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
