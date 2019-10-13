﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;


namespace Saving_Accelerator_Tool
{
    class STK
    {
        //Dodać
        //Dodać uprawnienia 
        //Logi przy zmianach i aktualizacji
        //Filtrowanie tylko na wybrany rok (połączone z counterem który jest dodany na Form)
        //Zmienić linka do ładowania nowych STK z raportów- jest ustawione na dysk
        MainProgram form;
        Data_Import ImportData;
        string link;
        string LinkBaza;

        public STK(MainProgram mainProgram, Data_Import ImportData)
        {
            form = mainProgram;
            this.ImportData = ImportData;
            link = ImportData.Load_Link("STK");
            LinkBaza = link;
        }

        public void STK_LoadFile()
        {
            //string link;

            //link = @"\\PLWS4031\Project\CAD\Work\bartkkon\EC_Akcelerator_Data\STK\STK.txt";

            if (File.Exists(link))
            {
                DataTable Table = new DataTable();
                //Data_Import ImportData = new Data_Import();
                ImportData.Load_TxtToDataTable(ref Table, link);
                //form.dg_ToSTK.DataSource = Table;
                //form.dg_ToSTK.Show();
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

        private void LoadNewSTKFile(string linkFile)
        {
            DataTable STKTable = new DataTable();
            //string LinkBaza = @"I:\CAD\Work\bartkkon\EC_Akcelerator_Data\STK\STK.txt";
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


            //Data_Import ImportData = new Data_Import();
            ImportData.Load_TxtToDataTable(ref STKTable, LinkBaza);

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
                            if(FoundRow["IDCO"].ToString() != IDCO)
                            {
                                FoundRow["IDCO"] = IDCO;
                            }
                        }
                        else
                        {
                            //Dodać kolumne z nowym rokiem i dopisać wartość
                            STKTable.Columns.Add(new DataColumn(Year.ToString()));
                            STKTable.Columns.Add(new DataColumn("STK/" + Year));
                            FoundRow[Year] = STK.ToString();

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
                            FoundRow["STK/" + Year] = day + "/" + month + "/" + Year.ToString();
                        }
                    }
                }

                ImportData.Save_DataTableToTXT(ref STKTable, LinkBaza);

                //form.dg_ToSTK.DataSource = STKTable;
                //form.dg_ToSTK.Refresh();
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
                    day = day - 1;
                    CheckDateSTK(ref year, ref month, ref day);
                    linkFile = GeneratedLinkSTK(year, month, day);
                    if (File.Exists(linkFile))
                    {
                        return linkFile;
                    }
                }
                return linkFile = "0";
            }
        }

        private void CheckDateSTK(ref int year, ref int month, ref int day)
        {
            if (day == 0)
            {
                month = month - 1;
                if (month == 0)
                {
                    month = 12;
                    year = year - 1;
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
