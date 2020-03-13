using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework
{
    class STKUpdate
    {
        public STKUpdate()
        {
            string FileName;
            string[] STKFile;
            int Add = 0;
            int Update = 0;

            FileName = FindLink();

            if(FileName == string.Empty)
            {
                MessageBox.Show("Brak pliku z STK od 10 dni lub w tym roku");
                return;
            }

             var STKDataBase = STKController.Load_By_Year(DateTime.UtcNow.Year);

            STKFile = File.ReadAllLines(FileName);
            
            foreach(string OneLine in STKFile)
            {
                string ANC;
                int Year;
                int Month;
                int Day;
                double STK;
                string Name;
                string IDCO;

                string line_help = OneLine;

                line_help = line_help.Remove(0, 2);
                ANC = line_help.Remove(9);
                line_help = line_help.Remove(0, 11);
                Year = 2000 + Convert.ToInt32(line_help.Remove(2));
                line_help = line_help.Remove(0, 2);
                Month = Convert.ToInt32(line_help.Remove(2));
                line_help = line_help.Remove(0, 2);
                Day = Convert.ToInt32(line_help.Remove(2));
                line_help = line_help.Remove(0, 2);
                STK = Convert.ToDouble(line_help.Remove(9)) / 10000;
                line_help = line_help.Remove(0, 154);
                Name = line_help.Remove(30).Trim();
                line_help = line_help.Remove(0, 31);
                IDCO = line_help.Remove(4);

                if(Skip(Name))
                {
                    STKDB Find = STKDataBase.Where(u => u.ANC == ANC).FirstOrDefault();

                    if(Find == null)
                    {
                        var NewRow = new STKDB
                        {
                            ANC = ANC,
                            Description = Name,
                            IDCO = IDCO,
                            Day = Day,
                            Month = Month,
                            Year = Year,
                            Value = STK,
                        };
                        STKController.AddNewValue(NewRow);
                        Add++;
                    }
                    else
                    {
                        if(STK != Find.Value)
                        {
                            Find.Description = Name;
                            Find.IDCO = IDCO;
                            Find.Day = Day;
                            Find.Month = Month;
                            Find.Year = Year;
                            Find.Value = STK;
                            STKController.UpdateValue(Find);
                            Update++;
                        }
                    }
                }
            }
            MessageBox.Show("Dodano: " + Add.ToString() + Environment.NewLine + "Zaktualizwoano: " + Update.ToString());
        }


        private bool Skip(string name)
        {
            if (name == "SOFTWARE")
                return false;
            if (name == "INSTRUCTION BOOKL SOURCE")
                return false;
            if (name == "ELECTRICAL DIAGRAM")
                return false;

            if (name.Length > 1)
                if (name.Remove(0, 2) == "MM")
                    return false;
            if (name.Length > 2)
            {
                if (name.Remove(0, 3) == "ELC")
                    return false;
                if (name.Remove(0, 3) == "CCF")
                    return false;
                if (name.Remove(name.Length - 3, 3) == "PDF")
                    return false;
            }
            if (name.Length > 3)
            {
                if (name.Remove(0, 4) == "RULE")
                    return false;
                if (name.Remove(0, 4) == "PROXY")
                    return false;
            }
            if (name.Length > 4)
            {
                if (name.Remove(0, 5) == "FAIRY")
                    return false;
            }
            return true;
        }

        private string FindLink()
        {
            string FileName;
            string Year;
            string Month;
            string Day;

            for (int counter = 0; counter >= -10; counter--)
            {
                Year = DateTime.UtcNow.AddDays(counter).Year.ToString();
                Month = DateTime.UtcNow.AddDays(counter).Month.ToString("d2");
                Day = DateTime.UtcNow.AddDays(counter).Day.ToString("d2");

                if(Year == (DateTime.UtcNow.Year -1).ToString())
                {
                    return string.Empty;
                }

                FileName = @"I:\raporty Copics\" + Year + @"\" + Year + Month + @"\" + Year + Month + Day + @"\stdcosts.txt";
                
                if(File.Exists(FileName))
                {
                    return FileName;
                }
            }

            return string.Empty;
        }
    }

    class STKUpdateRemove
    {
        public STKUpdateRemove(int Year)
        {
            STKController.Remove_Year(Year);
        }
    }

    class STKUpdate_ManualUpdate
    {
        public STKUpdate_ManualUpdate(int Year)
        {
            var List = STKController.Load_By_Year(Year);

            if (List != null)
            {
                DialogResult Results = MessageBox.Show("Dane STK na rok " + Year.ToString() + " istnieją!. Czy zamienić je ?", "Uwaga", MessageBoxButtons.YesNo);
                if (Results == DialogResult.Yes)
                {
                    STKController.Remove_Year(Year);
                }
                else
                {
                    return;
                }
            }

            _ = new AddData("Wprowadz dane STK dla Manualanego zaktualizowania", Year);

        }
    }
}
