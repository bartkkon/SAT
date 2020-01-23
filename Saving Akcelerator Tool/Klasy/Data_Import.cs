using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool
{
    public class Data_Import
    {
        private static Data_Import instance;
        private readonly string Link_Access = @"\\PLWS4031\Project\CAD\Work\bartkkon\EC_Accelerator_Data\Links.txt";
        public static bool FinalBase;

        public Data_Import()
        {
            FinalBase = true;
            if (Environment.UserName.ToString() == "BartkKon")
            {
                DialogResult Results = MessageBox.Show("Czy chcesz zmienić baze danych na Testową?", "Czy baza danych testowa?", MessageBoxButtons.YesNo);
                if (Results == DialogResult.Yes)
                {
                    Link_Access = @"C:\Moje\EC_Accelerator_Data\Links.txt";
                    FinalBase = false;
                }
            }
        }

        public static Data_Import Singleton()
        {
                if(instance == null)
                {
                    instance = new Data_Import();
                }
                return instance;
        }

        public Data_Import (string Link)
        {
            Link_Access = Link;
        }

        public bool CheckConnectionToDataBase()
        {
            bool Status = false;
            if(!File.Exists(Link_Access))
            {
                MessageBox.Show("Brak dostępu do bazy danych. Proszę uruchomić dyski sieciowe lub połączyć się z siecią lub skontaktować się z Adminem.");
            }
            else
            {
                Status = true;
            }
            return Status;
        }

        public string CheckLink ()
        {
            return Link_Access;
        }

        /// <summary>
        /// Automatyczny odczyt danych z Bazy TXT z wskazanego linku i załadowanie ich do DataTable. 
        /// </summary>
        /// <param name="Table">DataTabel do której mają być ładowane dane</param>
        /// <param name="Link">Wskazany link pod którym znajduje się baza TXT</param>
        public void Load_TxtToDataTable(ref DataTable Table, string Link)
        {
            Load_File(ref Table, Link);
        }

        /// <summary>
        /// Load DataBase from .txt file to DataTable. Version 2 put where not use link
        /// </summary>
        /// <param name="Table">Ref to DataTable</param>
        /// <param name="Where">What DataBase you want load</param>
        public void Load_TxtToDataTable2(ref DataTable Table, string Where)
        {
            Load_File(ref Table, Load_Link(Where));
        }

        public void Load_TxtToDataTableYear(ref DataTable Table, string Link, decimal Year)
        {
            DataTable Table2;

            Load_File(ref Table, Link);

            Table2 = Table.Clone();

            string nazwa;
            foreach (DataColumn Column in Table.Columns)
            {
                nazwa = Column.ColumnName;
                if (nazwa.Length >= 4)
                {
                    string[] Nazwa2 = nazwa.Split('/');
                    if(Nazwa2[Nazwa2.Length-1] != Year.ToString())
                    {
                        Table2.Columns.Remove(Column.ColumnName);
                    }
                }
            }
            Table = Table2.Clone();
        }

        public DataTable Load_Access()
        {
            //string Link = @"I:\CAD\Work\bartkkon\EC_Akcelerator_Data\Access\Access.txt";
            string Link;
            string[] Access;
            string User;
            DataTable dataTable = new DataTable();
            DataTable dataTable2;
            DataRow FoundRow;

            Link = Load_Link("Access");

            Load_File(ref dataTable, Link);

            dataTable2 = dataTable.Clone();

            User = Environment.UserName.ToLower();
            FoundRow = dataTable.Select(string.Format("Name LIKE '%{0}%'", User)).FirstOrDefault();
            if (FoundRow == null)
            {
                MessageBox.Show("You don't have access to this application. Please contact with administrator.");
                Environment.Exit(0);
                Access = new string[1];
                Access[0] = "";

            }
            else
            {
                //foreach (DataRow Row in dataTable.Rows)
                //{
                    if (FoundRow["Name"].ToString() == User)
                    {
                        dataTable2.Rows.Add(FoundRow.ItemArray);
                    }
                    else
                    {
                        MessageBox.Show("You don't have access to this application. Please contact with administrator.");
                        Environment.Exit(0);
                        Access = new string[1];
                        Access[0] = "";
                    }
                //}
            }

            return dataTable2;
        }

        /// <summary>
        /// Automatyczny zapis danych z DataTable do bazy TXT pod wskazanym linkiem.
        /// Dodatkowo wykonany BackUp Bazy TXT przed wprowadzeniem zmian.
        /// </summary>
        /// <param name="Table">DataTable z której mają być pobrane dane</param>
        /// <param name="Link">Wskazany link do bazy TXT</param>
        public void Save_DataTableToTXT(ref DataTable Table, string Link)
        {
            Save_File(ref Table, Link);
        }
        public void Save_DataTableToTXT2(ref DataTable Table, string Where)
        {
            Save_File(ref Table, Load_Link(Where));
        }

        public void Create_Log()
        {

        }

        public string Load_Link(string What)
        {
            string Link;
            DataTable LinkTabela = new DataTable();
            DataRow FoundRow;

            Load_File(ref LinkTabela, Link_Access);
            FoundRow = LinkTabela.Select(string.Format("What LIKE '%{0}%'", What)).FirstOrDefault();
            if (FoundRow != null)
            {
                Link = FoundRow["Link"].ToString();
                return Link;
            }
            else
            {
                return "";
            }
        }

        private void Load_File(ref DataTable Table, string Link)
        {
            string[] Data;
            int counter = 0;
            string[] Row;


            Data = File.ReadAllLines(Link);
            foreach (string line in Data)
            {
                Row = line.Split(';');
                if (counter == 0)
                {
                    for (int counter2 = 0; counter2 < (Row.Length - 1); counter2++)
                    {
                        Table.Columns.Add(new DataColumn(Row[counter2]));
                    }
                }
                else
                {
                    DataRow DaneRow = Table.NewRow();
                    for (int counter2 = 0; counter2 < (Row.Length - 1); counter2++)
                    {
                        DaneRow[counter2] = Row[counter2];
                    }
                    Table.Rows.Add(DaneRow);
                }
                counter++;
            }

            //Log("Load Txt Base to program:  " + Link);
        }

        private void Save_File(ref DataTable Table, string Link)
        {
            string Backup;
            string RowToSave = "";

            Backup = Link.Remove(Link.Length - 4);
            Backup = Backup + "_" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") +DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".txt";
            File.Move(Link, Backup);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Link))
            {
                foreach (DataColumn Column in Table.Columns)
                {
                    RowToSave += Column.ColumnName.ToString() + ";";
                }

                file.WriteLine(RowToSave);

                foreach (DataRow Rows in Table.Rows)
                {
                    RowToSave = "";
                    foreach (DataColumn Column in Table.Columns)
                    {
                        RowToSave += Rows[Column].ToString() + ";";
                    }
                    file.WriteLine(RowToSave);
                }
            }

            //Log("Save DataTable to Baze TXT, backup file: " + Link);
        }
    }
}
