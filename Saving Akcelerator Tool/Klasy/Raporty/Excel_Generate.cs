﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    public class Create_Excel_Application
    {

        public Excel.Application Create_Application()
        {
            Excel.Application excel;

            excel = new Microsoft.Office.Interop.Excel.Application();

            return excel;
        }
    }

    public class Create_Excel_WorkBooks
    {
        public Excel.Workbook Create_WorkBooks(Excel.Application application)
        {
            Excel.Workbook WorkBook;

            WorkBook = application.Workbooks.Add(Type.Missing);

            return WorkBook;
        }
    }

    public class Save_Excel_WorkBook
    {
        MainProgram mainProgram;

        public Save_Excel_WorkBook(MainProgram mainProgram)
        {
            this.mainProgram = mainProgram;
        }

        public void Save_WorkBook(Excel.Application application, Excel.Workbook workbook)
        {
            string FileName;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            FileName = Name();

            saveFileDialog.FileName = FileName;
            saveFileDialog.DefaultExt = "Xlsx";
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                application.Quit();
            }
        }

        private string Name()
        {
            string Name;
            decimal Year;
            decimal Month;
            decimal Day;
            string Hour;
            string Minute;
            string Secound;

            ComboBox DevisionCB = (ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDevision", true).First();
            string Devision = DevisionCB.Text;
            decimal YearRep = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYearSum", true).First()).Value;

            if (Devision == "All")
            {
                Name = "ProductCare_";
            }
            else
            {
                Name = Devision;
                Name = Name + "_";
            }

            Name = Name + YearRep.ToString();
            Name = Name + "_";

            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
            Hour = DateTime.Now.Hour.ToString("d2");
            Minute = DateTime.Now.Minute.ToString("d2");
            Secound = DateTime.Now.Second.ToString("d2");

            Name = Name + Year.ToString();
            Name = Name + Month.ToString();
            Name = Name + Day.ToString();
            Name = Name + "_";
            Name = Name + Hour;
            Name = Name + Minute;
            Name = Name + Secound;

            return Name;
        }
    }

    public class Create_Excel_WorkSheet
    {
        public Excel.Worksheet Create_WorkSheet(Excel.Workbook workbook, string Name)
        {
            Excel.Worksheet worksheet;

            worksheet = (Excel.Worksheet)workbook.Worksheets.Add();
            worksheet.Name = Name;

            return worksheet;
        }
    }

    public class Remove_Empty_Sheet
    {
        public void Remove_Empty(Excel.Application application, Excel.Workbook workbook)
        {
            if (workbook.Sheets.Count > 1)
            {
                application.DisplayAlerts = false;
                workbook.Worksheets["Sheet1"].Delete();
                application.DisplayAlerts = true;
            }
        }
    }

}
