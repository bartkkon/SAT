using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Saving_Accelerator_Tool
{
    class STK
    {
        private readonly string link;
        public STK()
        {
            link = Data_Import.Singleton().Load_Link("STK");
        }

        public void STK_LoadFile()
        {
            if (File.Exists(link))
            {
                DataTable Table = new DataTable();
                Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "STK");
            }
            else
            {
                MessageBox.Show("Brak Bazy danych, proszę skontaktować się z administratorem");
            }

            //Dodać odrazu filtrowanie na bierzący rok, chyba przelicza wszystkie - sprawdzić 
        }

        public void STK_LoadNewSTK()
        {
            string linkFile;

            linkFile = STK_FileData();
            //linkFile = @"C:\Users\bartkkon\Desktop\stdcosts.txt";

            if (linkFile == "0")
            {
                MessageBox.Show("Plik z STK nie był generowany od ponad miesiąca");
            }
            else
            {
                LoadNewSTKFile(linkFile);
            }
        }

        //Czyszczenie ręczne dla wybranego roku aby Admin mógł wyczyścic dane jeśli jakieś okażą się błędne lub są ręcznie wrzucone i estymowane
        public void STK_ClearYear(decimal Year)
        {
            ClearYear(Year);
        }

        //Dodanie STK dla następnego roku manualnie 
        public void STK_ManualUpdateFromFile(decimal Year)
        {
            ManulaUpadte(Year);
        }

        private void ManulaUpadte(decimal Year)
        {
            DataTable STKTable = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref STKTable, "STK");

            if (STKTable.Columns.Contains(Year.ToString()))
            {
                DialogResult Results = MessageBox.Show("Dane STK na rok " + Year.ToString() + " istnieją!. Czy zamienić je ?", "Uwaga", MessageBoxButtons.YesNo);
                if (Results == DialogResult.Yes)
                {
                    STKTable.Columns.Remove(Year.ToString());
                    STKTable.Columns.Remove("STK/" + Year.ToString());
                }
                else
                {
                    return;
                }
            }

            STKTable.Columns.Add(Year.ToString());
            STKTable.Columns.Add("STK/" + Year.ToString());

            Data_Import.Singleton().Save_DataTableToTXT2(ref STKTable, "STK");
            _ = new AddData("Sprowadz dane dla STK", Year);
            //Data.Show();

        }

        private void ClearYear(decimal Year)
        {
            DataTable STKTable = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref STKTable, "STK");

            if (STKTable.Columns.Contains(Year.ToString()))
            {
                STKTable.Columns.Remove(Year.ToString());
                STKTable.Columns.Remove("STK/" + Year.ToString());

                Data_Import.Singleton().Save_DataTableToTXT2(ref STKTable, "STK");
            }

        }

        private void LoadNewSTKFile(string linkFile)
        {
            DataTable STKTable = new DataTable();
            string line_help;
            string ANC;
            int Year;
            int Month;
            int Day;
            float STK;
            string Name;
            string day;
            string month;
            string IDCO;

            Data_Import.Singleton().Load_TxtToDataTable2(ref STKTable, "STK");
            
            if (linkFile == "0")
            {
                MessageBox.Show("Plik nie był generowany od ponad miesiąca!");
            }
            else
            {
                string[] STKFileupdate = File.ReadAllLines(linkFile);

                foreach (string line in STKFileupdate)
                {
                    line_help = line;

                    line_help = line_help.Remove(0, 2);
                    ANC = line_help.Remove(9);
                    line_help = line_help.Remove(0, 11);
                    Year = int.Parse(line_help.Remove(2));
                    line_help = line_help.Remove(0, 2);
                    Month = int.Parse(line_help.Remove(2));
                    line_help = line_help.Remove(0, 2);
                    Day = int.Parse(line_help.Remove(2));
                    line_help = line_help.Remove(0, 2);
                    STK = float.Parse(line_help.Remove(9)) / 10000;
                    line_help = line_help.Remove(0, 154);
                    Name = line_help.Remove(30).Trim();
                    line_help = line_help.Remove(0, 31);
                    IDCO = line_help.Remove(4);


                    Year = 2000 + Year;

                    DataRow FoundRow = STKTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();

                    if (FoundRow == null)
                    {
                        DataRow NewRow = STKTable.NewRow();
                        NewRow["ANC"] = ANC;
                        NewRow["Description"] = Name;
                        NewRow["IDCO"] = IDCO;
                        if (Day < 10)
                        {
                            day = "0" + Day.ToString();
                        }
                        else
                        {
                            day = Day.ToString();
                        }
                        if (Month < 10)
                        {
                            month = "0" + Month.ToString();
                        }
                        else
                        {
                            month = Month.ToString();
                        }

                        if (!STKTable.Columns.Contains(Year.ToString()))
                        {
                            STKTable.Columns.Add(new DataColumn(Year.ToString()));
                            STKTable.Columns.Add(new DataColumn("STK/" + Year));
                        }

                        NewRow[Year.ToString()] = day + "/" + month + "/" + Year.ToString();
                        NewRow["STK/" + Year] = STK.ToString();
                        STKTable.Rows.Add(NewRow);
                    }
                    else
                    {
                        if (STKTable.Columns.Contains(Year.ToString()))
                        {
                            if (FoundRow["STK/" + Year].ToString() != STK.ToString())
                            {
                                //Co się stanie jak nie jest równy.
                                FoundRow["STK/" + Year] = STK.ToString();
                                if (Day < 10)
                                {
                                    day = "0" + Day.ToString();
                                }
                                else
                                {
                                    day = Day.ToString();
                                }
                                if (Month < 10)
                                {
                                    month = "0" + Month.ToString();
                                }
                                else
                                {
                                    month = Month.ToString();
                                }
                                FoundRow[Year.ToString()] = day + "/" + month + "/" + Year.ToString();
                            }
                            if (FoundRow["IDCO"].ToString() != IDCO)
                            {
                                FoundRow["IDCO"] = IDCO;
                            }
                        }
                        else
                        {
                            //Dodać kolumne z nowym rokiem i dopisać wartość
                            STKTable.Columns.Add(new DataColumn(Year.ToString()));
                            STKTable.Columns.Add(new DataColumn("STK/" + Year));

                            if (Day < 10)
                            {
                                day = "0" + Day.ToString();
                            }
                            else
                            {
                                day = Day.ToString();
                            }
                            if (Month < 10)
                            {
                                month = "0" + Month.ToString();
                            }
                            else
                            {
                                month = Month.ToString();
                            }
                            FoundRow[Year.ToString()] = day + "/" + month + "/" + Year.ToString();
                            FoundRow["STK/" + Year] = STK.ToString();
                        }
                    }
                }
                Data_Import.Singleton().Save_DataTableToTXT2(ref STKTable, "STK");
            }
        }

        private string STK_FileData()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int day = DateTime.Today.Day;
            string linkFile;

            linkFile = GeneratedLinkSTK(year, month, day);
            if (File.Exists(linkFile))
            {
                return linkFile;
            }
            else
            {
                for (int counter = 1; counter < 31; counter++)
                {
                    day -= 1;
                    CheckDateSTK(ref year, ref month, ref day);
                    linkFile = GeneratedLinkSTK(year, month, day);
                    if (File.Exists(linkFile))
                    {
                        return linkFile;
                    }
                }
                return "0";
            }
        }

        private void CheckDateSTK(ref int year, ref int month, ref int day)
        {
            if (day == 0)
            {
                month -= 1;
                if (month == 0)
                {
                    month = 12;
                    year -= 1;
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

        private string GeneratedLinkSTK(int year, int month, int day)
        {
            string linkFile;
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

            linkFile = @"I:\raporty Copics\" + Year + @"\" + Year + Month + @"\" + Year + Month + Day + @"\stdcosts.txt";

            return linkFile;
        }
    }
}
