using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Framework
{
    public class AutoUpdateSTK
    {
        private readonly Data_Import _Import;
        private DataTable _STK;
        private readonly decimal Year;
        private readonly Dictionary<string, decimal> _STKActionList = new Dictionary<string, decimal>();

        public AutoUpdateSTK()
        {
            DataTable STK = new DataTable();

            _Import = Data_Import.Singleton();
            _Import.Load_TxtToDataTable2(ref STK, "STK");
            Year = ((NumericUpDown)MainProgram.Self.Controls.Find("num_Admin_AutoUpdateSTK_Year", true).First()).Value;

            UpdateSTKTable(STK);
            UpdateSTKAction();
        }

        private void UpdateSTKAction()
        {
            DataTable Actions = new DataTable();

            _Import.Load_TxtToDataTable2(ref Actions, "Action");

            foreach (DataRow Action in Actions.Rows)
            {
                if (Action["StartYear"].ToString() == Year.ToString())
                {
                    ChangeSTKForAction(Action);
                    if (Action["Calculate"].ToString() == "PNCSpec")
                        ChangeSTKforPNCSpec(Action);
                }
            }

            _Import.Save_DataTableToTXT2(ref Actions, "Action");
        }

        private void ChangeSTKforPNCSpec(DataRow action)
        {
            decimal SumDeltaOld = 0;
            decimal SumDeltaNew = 0;
            string[] PNC_ANC = action["PNC/ANC"].ToString().Split('|');
            string[] PNC_ANCQ = action["PNC/ANC Q"].ToString().Split('|');
            string[] PNC_STK = action["PNCSTK"].ToString().Split('|');
            string[] PNCDelta = action["PNCDelta"].ToString().Split('|');
            string[] PNCSumSTK = action["PNCSumSTK"].ToString().Split('|');
            string[] PNCSumDelta = action["PNCSumDelta"].ToString().Split('|');

            action["PNCSTK"] = "";
            action["PNCDelta"] = "";
            action["PNCSumSTK"] = "";
            action["PNCSumDelta"] = "";

            for (int counter1 = 0; counter1 < PNC_ANC.Length - 1; counter1++)
            {
                string[] PNC_ANC1 = PNC_ANC[counter1].Split('/');
                string[] PNC_ANCQ1 = PNC_ANCQ[counter1].Split('/');
                string[] PNC_STK1 = PNC_STK[counter1].Split('/');
                string[] PNCDelta1 = PNCDelta[counter1].Split('/');

                PNC_STK[counter1] = "";
                PNCDelta[counter1] = "";

                for (int counter2 = 0; counter2 < PNC_ANC1.Length - 1; counter2++)
                {
                    string[] PNC_ANC2 = PNC_ANC1[counter2].Split(':');
                    string[] PNC_ANCQ2 = PNC_ANCQ1[counter2].Split(':');
                    string[] PNC_STK2 = PNC_STK1[counter2].Split(':');
                    for (int counter3 = 0; counter3 < 2; counter3++)
                    {
                        if (PNC_ANC2[counter3] != "")
                        {
                            if (!_STKActionList.ContainsKey(PNC_ANC2[counter3]))
                            {
                                DataRow Row = _STK.Select(string.Format("ANC LIKE '%{0}%'", PNC_ANC2[counter3])).First();
                                if (Row[1] != null && Row[1].ToString() != "")
                                {
                                    _STKActionList.Add(PNC_ANC2[counter3], decimal.Parse(Row[1].ToString()));
                                    PNC_STK2[counter3] = (_STKActionList[PNC_ANC2[counter3]] * decimal.Parse(PNC_ANCQ2[counter3])).ToString();
                                }
                            }
                            else
                            {
                                PNC_STK2[counter3] = (_STKActionList[PNC_ANC2[counter3]] * decimal.Parse(PNC_ANCQ2[counter3])).ToString();
                            }
                        }
                    }
                    PNCDelta1[counter2] = CalcDelta(PNC_STK2[0], PNC_STK2[1]) + "/";
                    SumDeltaOld += CoonverToDecimal(PNC_STK2[0]);
                    SumDeltaNew += CoonverToDecimal(PNC_STK2[1]);
                    PNC_STK1[counter2] = PNC_STK2[0] + ":" + PNC_STK2[1];
                    PNC_STK[counter1] += PNC_STK1[counter2] + "/";
                    PNCDelta[counter1] += PNCDelta1[counter2];
                    if (counter2 == (PNC_ANC1.Length - 2))
                    {
                        PNCSumSTK[counter1] = SumDeltaOld.ToString() + ":" + SumDeltaNew.ToString();
                        PNCSumDelta[counter1] = (SumDeltaOld - SumDeltaNew).ToString();
                        SumDeltaOld = 0;
                        SumDeltaNew = 0;
                    }
                }
                action["PNCSTK"] += PNC_STK[counter1] + "|";
                action["PNCDelta"] += PNCDelta[counter1] + "|";
                action["PNCSumSTK"] += PNCSumSTK[counter1] + "|";
                action["PNCSumDelta"] += PNCSumDelta[counter1] + "|";
            }
        }

        private decimal CoonverToDecimal(string Number)
        {
            if (Number != "")
            {
                return decimal.Parse(Number);
            }
            else
            {
                return 0;
            }
        }

        private string CalcDelta(string Old, string New)
        {
            decimal STK1;
            decimal STK2;

            if (Old != "")
                STK1 = decimal.Parse(Old);
            else
                STK1 = 0;

            if (New != "")
                STK2 = decimal.Parse(New);
            else
                STK2 = 0;

            return (STK1 - STK2).ToString();

        }

        private void ChangeSTKForAction(DataRow action)
        {
            string[] OldANC;
            string[] OldANCQ;
            string[] OldSTK;
            string[] NewANC;
            string[] NewANCQ;
            string[] NewSTK;

            string[] Delta;
            string[] STKEst;
            string[] Percent;
            string[] STKCal;


            OldANC = action["Old ANC"].ToString().Split('|');
            OldANCQ = action["Old ANCQ"].ToString().Split('|');
            OldSTK = action["Old STK"].ToString().Split('|');
            NewANC = action["New ANC"].ToString().Split('|');
            NewANCQ = action["New ANCQ"].ToString().Split('|');
            NewSTK = action["New STK"].ToString().Split('|');

            Delta = action["Delta"].ToString().Split('|');
            STKEst = action["STKEst"].ToString().Split('|');
            Percent = action["Percent"].ToString().Split('|');
            STKCal = action["STKCal"].ToString().Split('|');

            for (int counter = 0; counter < OldANC.Length - 1; counter++)
            {
                if (OldANC[counter] != "")
                    OldSTK[counter] = FindSTK(OldANC[counter]);
                if (NewANC[counter] != "")
                    NewSTK[counter] = FindSTK(NewANC[counter]);

                Delta[counter] = CalcDelta(OldSTK[counter], OldANCQ[counter], NewSTK[counter], NewANCQ[counter]);

                if (STKEst[counter] == "")
                    STKCal[counter] = CalcSTKForCalculation(Delta[counter], Percent[counter]);
            }

            action["Old ANC"] = ToDataBase(OldANC);
            action["Old ANCQ"] = ToDataBase(OldANCQ);
            action["Old STK"] = ToDataBase(OldSTK);
            action["New ANC"] = ToDataBase(NewANC);
            action["New ANCQ"] = ToDataBase(NewANCQ);
            action["New STK"] = ToDataBase(NewSTK);
            action["Delta"] = ToDataBase(Delta);
            action["STKEst"] = ToDataBase(STKEst);
            action["Percent"] = ToDataBase(Percent);
            action["STKCal"] = ToDataBase(STKCal);
        }

        private string ToDataBase(string[] Split)
        {
            string Final = "";

            for (int counter = 0; counter < Split.Length - 1; counter++)
            {
                Final += Split[counter] + "|";
            }

            return Final;
        }

        private string CalcSTKForCalculation(string Delta, string Percent)
        {
            decimal Calc;

            Calc = decimal.Parse(Delta) * (decimal.Parse(Percent) / 100);
            Calc = Math.Round(Calc, 4, MidpointRounding.AwayFromZero);

            return Calc.ToString();
        }

        private string CalcDelta(string Old, string OldQ, string New, string NewQ)
        {
            decimal Delta;
            if (Old == "")
                Old = "0";
            if (OldQ == "")
                OldQ = "0";
            if (New == "")
                New = "0";
            if (NewQ == "")
                NewQ = "0";

            Delta = (decimal.Parse(Old) * decimal.Parse(OldQ)) - (decimal.Parse(New) * decimal.Parse(NewQ));
            Delta = Math.Round(Delta, 4, MidpointRounding.AwayFromZero);

            return Delta.ToString();
        }

        private string FindSTK(string ANC)
        {
            DataRow Row;

            Row = _STK.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();

            if (Row != null)
                return Row["STK/" + Year.ToString()].ToString();
            else
                return "";
        }

        private void UpdateSTKTable(DataTable STK)
        {
            _STK = STK.Copy();

            foreach (DataColumn Column in STK.Columns)
            {
                if (Column.ColumnName != "ANC" && Column.ColumnName != "STK/" + Year.ToString())
                {
                    _STK.Columns.Remove(Column.ColumnName);
                }
            }
        }
    }
}
