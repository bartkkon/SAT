using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.Firmwork
{
    class SaveDataDisplay
    {
        private readonly DataGridView _data;
        public SaveDataDisplay(DataGridView data)
        {
            _data = data;

            Excel.Application Raport;
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            string FileName;

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

            FileName = Name();

            CreateList(worksheet);
            Save_Excel_WorkBook_All Save = new Save_Excel_WorkBook_All();
            Save.Save_WorkBook(Raport, workbook, FileName);


        }

        private void CreateList(Worksheet worksheet)
        {
            int Row = 1;
            int Column = 1;
            for (int columns = 0; columns < _data.Columns.Count; columns++)
            {
                worksheet.Cells[Row, Column + columns].Value2 = _data.Columns[columns].Name;
            }

            for (int Rows = 0; Rows < _data.Rows.Count; Rows++)
            {
                for(int column = 0; column <_data.Columns.Count; column++)
                {
                    worksheet.Cells[Rows + 2, 1 + column].Value2 = _data.Rows[Rows].Cells[column].Value;
                }
            }
        }

        private string Name()
        {
            string FileName = "AdminData";

            FileName += "_" + DateTime.Today.Year.ToString();
            FileName += DateTime.Today.Month.ToString();
            FileName += DateTime.Today.Day.ToString();
            FileName += DateTime.Now.Hour.ToString();
            FileName += DateTime.Now.Minute.ToString();
            FileName += DateTime.Now.Second.ToString();

            return FileName;
        }
    }
}
