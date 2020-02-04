using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    public class Level1
    {
        MainProgram mainProgram;
        Data_Import data_Import;

        Dictionary<string, int> Rev = new Dictionary<string, int>()
        {
            {"USE", 0},
            {"EA3", 1},
            {"EA2", 2},
            {"EA1", 3},
            {"BU", 4},
        };
        Dictionary<string, int> RevMonth = new Dictionary<string, int>()
        {
            {"USE", 0},
            {"EA3", 8},
            {"EA2", 5},
            {"EA1", 2},
            {"BU", 0},
        };

        public Level1(MainProgram mainProgram, Data_Import data_Import)
        {
            this.mainProgram = mainProgram;
            this.data_Import = data_Import;
        }

        public void Genereted_Level1()
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Workbook workbook;
            decimal YearGenereted;

            YearGenereted = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            Create_Excel_Application Application = new Create_Excel_Application();
            excel = Application.Create_Application();

            Create_Excel_WorkBooks Workbooks = new Create_Excel_WorkBooks();
            workbook = Workbooks.Create_WorkBooks(excel);

            Sum(workbook, YearGenereted);
            Remove_Empty_Sheets(excel, workbook);

            Save_Excel_WorkBook Save = new Save_Excel_WorkBook();
            Save.Save_WorkBook(excel, workbook);

        }

        private void Sum(Workbook workbook, decimal Year)
        {
            Worksheet worksheet;
            DataRow Frozen;
            string Revision;
            int Month;

            Frozen = Load_Frozen(Year);
            Revision = CheckRevision(Year, Frozen);
            Month = CheckMonth(Year, Frozen);

            Create_Excel_WorkSheet excel_WorkSheet = new Create_Excel_WorkSheet();
            worksheet = excel_WorkSheet.Create_WorkSheet(workbook, "Tabela");
            worksheet.Application.ActiveWindow.DisplayGridlines = false;
            worksheet.Application.ActiveWindow.Zoom = 85;

            //Generowanie Tabeli
            Sum_Text(worksheet, Revision);

            //Ładowanie danych do tabeli SUM
            ActionSum(worksheet, Revision, Month);
        }

        private void ActionSum(Worksheet worksheet, string Revison, int Month)
        {
            DataGridView NewAction;
            DataGridView CarryOver;
            DataGridView ECCC;
            int RowUse;
            int RowRev;

            NewAction = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();
            CarryOver = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();

            RowUse = Rev["USE"];
            RowRev = Rev[Revison];

            for (int counter = 0; counter < 13; counter++)
            {
                worksheet.Cells[10, 3 + counter] = NewAction.Rows[RowUse].Cells[counter].Value.ToString();
                worksheet.Cells[20, 3 + counter] = CarryOver.Rows[RowUse].Cells[counter].Value.ToString();
                worksheet.Cells[30, 3 + counter] = ECCC.Rows[RowUse].Cells[counter].Value.ToString();
            }

            for (int counter = 0; counter < 13; counter++)
            {
                worksheet.Cells[11, 3 + counter] = NewAction.Rows[RowRev].Cells[counter].Value.ToString();
                worksheet.Cells[21, 3 + counter] = CarryOver.Rows[RowRev].Cells[counter].Value.ToString();
                worksheet.Cells[31, 3 + counter] = ECCC.Rows[RowRev].Cells[counter].Value.ToString();
            }

            CheckDelta(worksheet, NewAction, CarryOver, ECCC);
            Range Cell = worksheet.Range["C10:N10"];
            Cell.Font.Bold = true;
            Cell = worksheet.Range["O10:O12"];
            Cell.Font.Bold = true;
            Cell = worksheet.Range["C20:N20"];
            Cell.Font.Bold = true;
            Cell = worksheet.Range["O20:O22"];
            Cell.Font.Bold = true;
            Cell = worksheet.Range["C30:N30"];
            Cell.Font.Bold = true;
            Cell = worksheet.Range["O30:O32"];
            Cell.Font.Bold = true;
        }

        private void CheckDelta(Worksheet worksheet, DataGridView NewAction, DataGridView CarryOver, DataGridView ECCC)
        {
            decimal delta;

            for (int counter = 3; counter < 15; counter++)
            {
                if (worksheet.Cells[10, counter].Value2 != null && worksheet.Cells[11, counter].Value2 != null)
                {
                    worksheet.Cells[12, counter] = decimal.Parse(worksheet.Cells[10, counter].Value.ToString()) - decimal.Parse(worksheet.Cells[11, counter].Value.ToString());
                    delta = decimal.Parse(worksheet.Cells[12, counter].Value.ToString());
                    if (delta > 0)
                    {
                        worksheet.Cells[12, counter].Font.Color = Color.Green;
                        worksheet.Cells[12, counter].Interior.Color = Color.LightGreen;
                    }
                    else if (delta < 0)
                    {
                        worksheet.Cells[12, counter].Font.Color = Color.Red;
                        worksheet.Cells[12, counter].Interior.Color = Color.LightSalmon;
                    }
                    else
                    {
                        worksheet.Cells[12, counter].Font.Color = Color.Black;
                        worksheet.Cells[12, counter].Interior.Color = Color.White;
                    }
                }
                if (worksheet.Cells[20, counter].Value2 != null && worksheet.Cells[21, counter].Value2 != null)
                {
                    worksheet.Cells[22, counter] = decimal.Parse(worksheet.Cells[20, counter].Value.ToString()) - decimal.Parse(worksheet.Cells[21, counter].Value.ToString());
                    delta = decimal.Parse(worksheet.Cells[22, counter].Value.ToString());
                    if (delta > 0)
                    {
                        worksheet.Cells[22, counter].Font.Color = Color.Green;
                        worksheet.Cells[22, counter].Interior.Color = Color.LightGreen;
                    }
                    else if (delta < 0)
                    {
                        worksheet.Cells[22, counter].Font.Color = Color.Red;
                        worksheet.Cells[22, counter].Interior.Color = Color.LightSalmon;
                    }
                    else
                    {
                        worksheet.Cells[22, counter].Font.Color = Color.Black;
                        worksheet.Cells[22, counter].Interior.Color = Color.White;
                    }
                }
                if (worksheet.Cells[30, counter].Value2 != null && worksheet.Cells[31, counter].Value2 != null)
                {
                    worksheet.Cells[32, counter] = decimal.Parse(worksheet.Cells[30, counter].Value.ToString()) - decimal.Parse(worksheet.Cells[31, counter].Value.ToString());
                    delta = decimal.Parse(worksheet.Cells[32, counter].Value.ToString());
                    if (delta > 0)
                    {
                        worksheet.Cells[32, counter].Font.Color = Color.Green;
                        worksheet.Cells[32, counter].Interior.Color = Color.LightGreen;
                    }
                    else if (delta < 0)
                    {
                        worksheet.Cells[32, counter].Font.Color = Color.Red;
                        worksheet.Cells[32, counter].Interior.Color = Color.LightSalmon;
                    }
                    else
                    {
                        worksheet.Cells[32, counter].Font.Color = Color.Black;
                        worksheet.Cells[32, counter].Interior.Color = Color.White;
                    }
                }
            }

            worksheet.Range["O10:O11"].Interior.Color = Color.Yellow;
            worksheet.Range["O20:O21"].Interior.Color = Color.Yellow;
            worksheet.Range["O30:O31"].Interior.Color = Color.Yellow;
        }

        private string CheckRevision(decimal Year, DataRow Frozen)
        {
            if (Year == DateTime.Today.Year)
            {
                if (Frozen["EA3"].ToString() == "Approve" || Frozen["EA3"].ToString() == "Open")
                {
                    return "EA3";
                }
                else if (Frozen["EA2"].ToString() == "Approve" || Frozen["EA2"].ToString() == "Open")
                {
                    return "EA2";
                }
                else if (Frozen["EA1"].ToString() == "Approve" || Frozen["EA1"].ToString() == "Open")
                {
                    return "EA1";
                }
                else
                {
                    return "BU";
                }
            }
            else if (Year == DateTime.Today.Year + 1)
            {
                return "BU";
            }
            else if (Year == DateTime.Today.Year - 1)
            {
                return "EA3";
            }
            else
            {
                return "";
            }
        }

        private int CheckMonth(decimal Year, DataRow Frozen)
        {
            if (Year == DateTime.Today.Year)
            {
                for (int counter = 12; counter > 0; counter--)
                {
                    if (Frozen[counter.ToString()].ToString() == "Approve" || Frozen[counter.ToString()].ToString() == "Open")
                    {
                        return counter;
                    }
                }
                return 0;
            }
            else if (Year == DateTime.Today.Year - 1)
            {
                return 12;
            }
            else
            {
                return 0;
            }

        }

        private DataRow Load_Frozen(decimal Year)
        {
            System.Data.DataTable Frozen = new System.Data.DataTable();
            DataRow Frozen_Row;
            string Link;

            Link = data_Import.Load_Link("Frozen");
            data_Import.Load_TxtToDataTable(ref Frozen, Link);

            Frozen_Row = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            return Frozen_Row;
        }

        private void Remove_Empty_Sheets(Microsoft.Office.Interop.Excel.Application application, Workbook workbook)
        {
            if (workbook.Sheets.Count > 1)
            {
                application.DisplayAlerts = false;
                workbook.Worksheets["Sheet1"].Delete();
                application.DisplayAlerts = true;
            }
        }

        private void Sum_Text(Worksheet worksheet, string Revision)
        {
            Excel_Function Function = new Excel_Function(worksheet);

            Function.Add_Cells(7, 2, "New Action", 11, true, "Calibri", false);
            Function.Add_Cells(8, 2, "Podsumowanie:", 11, true, "Calibri", false);
            Function.Add_Cells(17, 2, "Carry Over", 11, true, "Calibri", false);
            Function.Add_Cells(18, 2, "Podsumowanie:", 11, true, "Calibri", false);
            Function.Add_Cells(27, 2, "ECCC", 11, true, "Calibri", false);
            Function.Add_Cells(28, 2, "Podsumowanie:", 11, true, "Calibri", false);
            for (int counter = 1; counter <= 3; counter++)
            {
                Function.Add_Cells(10 * counter, 2, "Use:", 11, true, "Calibri", false);
                Function.Add_Cells((10 * counter) + 1, 2, Revision + ":", 11, true, "Calibri", false);
                Function.Add_Cells((10 * counter) + 2, 2, "Diff:", 11, true, "Calibri", false);
            }
            Function.Range_Borders("B10", "B12", true, false);
            Function.Range_Borders("B20", "B22", true, false);
            Function.Range_Borders("B30", "B32", true, false);

            for (int counter = 1; counter <= 3; counter++)
            {
                Function.Add_Cells((10 * counter) - 1, 3, "I", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 4, "II", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 5, "III", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 6, "IV", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 7, "V", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 8, "VI", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 9, "VII", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 10, "VIII", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 11, "IX", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 12, "X", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 13, "XI", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 14, "XII", 11, true, "Calibri", true);
                Function.Add_Cells((10 * counter) - 1, 15, "Suma", 11, true, "Calibri", true);
            }
            Function.Range_Borders("C9", "O9", true, false);
            Function.Range_Borders("C19", "O19", true, false);
            Function.Range_Borders("C29", "O29", true, false);

            Function.Range_Borders("C10", "O12", true, false);
            Function.Range_Borders("C20", "O22", true, false);
            Function.Range_Borders("C30", "O32", true, false);
            Function.Columns_Width("B:B", 16.43);
            Function.Columns_Width("C:N", 11.29);
            Function.Columns_Width("O:O", 17.29);
        }

    }
}
