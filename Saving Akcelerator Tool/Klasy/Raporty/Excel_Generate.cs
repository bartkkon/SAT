using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    public class Create_Excel_Application
    {

        public Microsoft.Office.Interop.Excel.Application Create_Application()
        {
            Microsoft.Office.Interop.Excel.Application excel;

            excel = new Microsoft.Office.Interop.Excel.Application();

            return excel;
        }
    }

    public class Create_Excel_WorkBooks
    {
        public Workbook Create_WorkBooks(Microsoft.Office.Interop.Excel.Application application)
        {
            Workbook WorkBook;

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

        public void Save_WorkBook(Microsoft.Office.Interop.Excel.Application application, Workbook workbook)
        {
            string FileName;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            FileName = Name();

            saveFileDialog.FileName = FileName;
            saveFileDialog.DefaultExt = "Xlsx";
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
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
            decimal Hour;
            decimal Minute;
            decimal Secound;

            ComboBox DevisionCB = (ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDevision", true).First();
            string Devision = DevisionCB.Text;
            decimal YearRep = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYearSum", true).First()).Value;

            if(Devision == "All")
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
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Secound = DateTime.Now.Second;

            Name = Name + Year.ToString();
            Name = Name + Month.ToString();
            Name = Name + Day.ToString();
            Name = Name + "_";
            Name = Name + Hour.ToString();
            Name = Name + Minute.ToString();

            return Name;
        }
    }

    public class Create_Excel_WorkSheet
    {
        public Worksheet Create_WorkSheet(Workbook workbook, string Name)
        {
            Worksheet worksheet;

            worksheet = (Worksheet)workbook.Worksheets.Add();
            worksheet.Name = Name;

            return worksheet;
        }
    }

}
