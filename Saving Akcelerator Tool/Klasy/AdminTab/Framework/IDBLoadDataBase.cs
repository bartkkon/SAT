using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DataSystem = System.Data;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Framework
{
    public class IDBLoadDataBase
    {
        private DataSystem.DataTable IDB;
        private readonly Data_Import _Import;


        /// <summary>
        /// Ładowanie Zrzutu z IDB do DataTable i zapis tej Tabeli do Bazy danych
        /// </summary>
        public IDBLoadDataBase()
        {
            _Import = Data_Import.Singleton();
            
            LoadDataBase();
        }

        /// <summary>
        /// Ładowanie Zrzutu z IDB do DataTable i zapis tej Tabeli do Bazy danych
        /// </summary>
        private void LoadDataBase()
        {
            string FileLink;

            Cursor.Current = Cursors.Default;
            FileLink = IDBLoadLink();
            Cursor.Current = Cursors.WaitCursor;

            if (FileLink != string.Empty)
            {
                Excel.Application app = new Excel.Application();
                Workbook workbook = app.Workbooks.Open(FileLink, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Visible = false;
                app.DisplayAlerts = false;
                app.ScreenUpdating = false;
                app.DisplayStatusBar = false;
                app.EnableEvents = false;

                foreach (Worksheet worksheet in workbook.Worksheets)
                {
                    ReadTableToDataTable(worksheet);
                    SaveDataTableToDataBase();
                }

                workbook.Close();
                app.Visible = true;
                app.DisplayAlerts = true;
                app.ScreenUpdating = true;
                app.DisplayStatusBar = true;
                app.EnableEvents = true;
                app.Quit();
            }
        }

        /// <summary>
        /// Zapis Tabeli IDB do bazy danych  
        /// </summary>
        private void SaveDataTableToDataBase()
        {
            string Link;

            Link = _Import.Load_Link("IDB");
            _Import.Save_DataTableToTXT(ref IDB, Link);
        }

        /// <summary>
        /// Odczytuje zawartość z pliku i przenosi do DataTable
        /// </summary>
        /// <param name="worksheet">Zrzut z IDB</param>
        private void ReadTableToDataTable(Worksheet worksheet)
        {
            Range xlRange = worksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            CreateColum(worksheet, colCount);
            LoadRows(worksheet, colCount, rowCount);
        }

        /// <summary>
        /// Ładowanie danych do DataTable z zrzutu z IDB
        /// </summary>
        /// <param name="worksheet">Zrzut z IDB</param>
        /// <param name="colCount">Ilość kolumn</param>
        /// <param name="rowCount">Ilość wierszy</param>
        private void LoadRows(Worksheet worksheet, int colCount, int rowCount)
        {
            Range CellStart = worksheet.Cells[2, 1];
            Range CellFinish = worksheet.Cells[rowCount, colCount - 1];
            var ArryRow = worksheet.Range[CellStart, CellFinish].Value2;

            for(int rows = 1; rows<rowCount; rows++)
            {
                DataSystem.DataRow NewRow = IDB.NewRow();
                for(int column = 1; column< colCount; column++)
                {
                    NewRow[column-1] = ArryRow[rows, column];
                }
                IDB.Rows.Add(NewRow);
            }
        }

        /// <summary>
        /// Tworzenie kolumn w DataTable zgodnie z Zrzutem z IDB
        /// </summary>
        /// <param name="worksheet">Zrzut IDB</param>
        /// <param name="colCount"> Ilość Kolumn</param>
        private void CreateColum(Worksheet worksheet, int colCount)
        {
            IDB = new DataSystem.DataTable();
            for (int counter = 1; counter < colCount; counter++)
            {
                IDB.Columns.Add(worksheet.Cells[1, counter].Value.ToString(), typeof(String));
            }
        }

        /// <summary>
        /// Zwraca link do Zrzutu z IDB. Wybierany przez użytkowanika
        /// </summary>
        /// <returns></returns>
        private string IDBLoadLink()
        {
            string Link;
            OpenFileDialog LoadFile = new OpenFileDialog
            {
                DefaultExt = "Xlsx",
                Filter = "Excel Files (*.xls)|*xls",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (LoadFile.ShowDialog() == DialogResult.OK)
            {
                Link = LoadFile.FileName;
            }
            else
            {
                Link = string.Empty;
            }

            return Link;
        }
    }
}
