using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class Budget
    {
        //Dodac filtrowanie
        //Dodać uprawnienia
        //Sprawdzić jak działa
        //Logi
        public void BU_AddPNC(MainProgram form)
        {
            BU_LoadFile(form, "BUPNC");
        }

        public void BU_AddANC(MainProgram form)
        {
            BU_LoadFile(form, "BUANC");
        }

        private void BU_LoadFile(MainProgram form, string what)
        {
            //string linkBaza = @"I:\CAD\Work\bartkkon\EC_Akcelerator_Data\" + what + @"\" + what + ".txt";
            //string linkAdd = @"I:\CAD\Work\bartkkon\EC_Akcelerator_Data\zuzycie_" + what + ".txt";
            //string linkNew = @"I:\CAD\Work\bartkkon\EC_Akcelerator_Data\" + what + @"\" + what + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + ".txt";
            //string Rewizja = form.cb_BUKwartal.SelectedItem.ToString();
            //decimal Year = form.num_BUYear.Value;
            //string Columna;
            //int counter2 = 0;
            //int counter3;

            //DataTable Baza = new DataTable();
            //DataTable Data = new DataTable();

            ////ładowanie bazy do datatable
            //Data_Import ImportData = new Data_Import();
            //ImportData.Load_TxtToDataTable(ref Baza, linkBaza);

            ////Sprwdzenie czy dane istnieją
            //Columna = Rewizja + "/12/" + Year.ToString();
            //if (Baza.Columns.Contains(Columna))
            //{
            //    DialogResult MessageBoxResult = MessageBox.Show("Dane już istnieją czy je zmienić?", "Uwaga !!!", MessageBoxButtons.YesNo);
            //    if (MessageBoxResult == DialogResult.Yes)
            //    {
            //        int counter = 0;
            //        switch (Rewizja)
            //        {
            //            case "BU":
            //                counter = 1;
            //                break;
            //            case "EA1":
            //                counter = 3;
            //                break;
            //            case "EA2":
            //                counter = 6;
            //                break;
            //            case "EA3":
            //                counter = 9;
            //                break;
            //        }
            //        for (; counter < 13; counter++)
            //        {
            //            Columna = Rewizja + "/" + counter + "/" + Year.ToString();
            //            Baza.Columns.Remove(Columna);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            //switch (Rewizja)
            //{
            //    case "BU":
            //        counter2 = 13;
            //        break;
            //    case "EA1":
            //        counter2 = 11;
            //        break;
            //    case "EA2":
            //        counter2 = 8;
            //        break;
            //    case "EA3":
            //        counter2 = 5;
            //        break;
            //}
            ////Ładowanie nowych danych do datatable
            //ImportData.Load_TxtToDataTable(ref Data, linkAdd);
            ////Sprawdzenie czy dane są zgodne
            //if (Data.Columns.Count != counter2)
            //{
            //    MessageBox.Show("Dane się nie zgadzają - sprawdz je!");
            //    return;
            //}

            ////Dodanie wartości do bazy
            //switch (Rewizja)
            //{
            //    case "BU":
            //        counter2 = 1;
            //        break;
            //    case "EA1":
            //        counter2 = 3;
            //        break;
            //    case "EA2":
            //        counter2 = 6;
            //        break;
            //    case "EA3":
            //        counter2 = 9;
            //        break;
            //}
            //counter3 = counter2;
            ////Dodanie kolumn do bazy
            //for (; counter3 < 13; counter3++)
            //{
            //    Columna = Rewizja + "/" + counter3 + "/" + Year.ToString();
            //    Baza.Columns.Add(Columna);
            //}

            //string komp;
            //foreach (DataRow row in Data.Rows)
            //{
            //    DataRow FoundRow;
            //    counter3 = counter2;
            //    komp = row[what].ToString();
            //    if (what == "BUANC")
            //    {
            //        FoundRow = Baza.Select(string.Format("BUANC LIKE '%{0}%'", komp)).FirstOrDefault();
            //    }
            //    else
            //    {
            //        FoundRow = Baza.Select(string.Format("BUPNC LIKE '%{0}%'", komp)).FirstOrDefault();
            //    }

            //    if (FoundRow == null)
            //    {
            //        DataRow Row = Baza.NewRow();
            //        Row[what] = row[what];
            //        for (; counter3 < 13; counter3++)
            //        {
            //            Columna = Rewizja + "/" + counter3 + "/" + Year.ToString();
            //            Row[Columna] = row[counter3.ToString()];
            //        }
            //        Baza.Rows.Add(Row);
            //    }
            //    else
            //    {
            //        for (; counter3 < 13; counter3++)
            //        {
            //            Columna = Rewizja + "/" + counter3 + "/" + Year.ToString();
            //            FoundRow[Columna] = row[counter3.ToString()];
            //        }
            //    }

            //}
            ////Zapisanie danych plus wyświetlenie ich
            //ImportData.Save_DataTableToTXT(ref Baza, linkBaza);

            //form.dg_BU.DataSource = Baza;
            //form.dg_BU.Refresh();
        }
    }
}
