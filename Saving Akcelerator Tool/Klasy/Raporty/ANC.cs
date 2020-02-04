using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class ANC
    {
        private readonly Dictionary<string, bool> Preferencje = new Dictionary<string, bool> { };
        private readonly Dictionary<string, string> IDCOTabela = new Dictionary<string, string> { };
        private readonly Dictionary<string, int> Month = new Dictionary<string, int>()
        {
            {"January", 1},
            {"February", 2},
            {"March", 3},
            {"April", 4},
            {"May", 5},
            {"June",6},
            {"July", 7},
            {"August",8},
            {"September",9},
            {"October",10},
            {"November",11},
            {"December",12},
        };

        public ANC(Dictionary<string, bool> Preferencje)
        {
            this.Preferencje = Preferencje;
        }
        public void PrepareANC(DataRow ActionRow, ref DataTable Devision, int MonthEnd, bool CarryOver, string Status)
        {
            DataRow RowtoAdd = Devision.NewRow();
            bool OnlyOneRow = false;

            string[] IDCO = IDCOAction(ActionRow);

            if (ActionRow["IloscANC"].ToString() == "1")
                OnlyOneRow = true;

            RowtoAdd["Name"] = ActionRow["Name"];

            if (Preferencje["Description"])
                RowtoAdd["Description"] = ActionRow["Description"];

            if (Preferencje["Status"])
                RowtoAdd["Status"] = Status;

            if (Preferencje["Platform"])
                RowtoAdd["Platform"] = ActionRow["Platform"];

            if (Preferencje["Minimum"] || OnlyOneRow)
            {
                AddMinimum(ref RowtoAdd, ActionRow, MonthEnd, CarryOver, IDCO);
                Devision.Rows.Add(RowtoAdd);
            }
            else if (Preferencje["Medium"] || Preferencje["Maximum"])
            {
                AddMediumMaximum(ref RowtoAdd, ActionRow, ref Devision, MonthEnd, CarryOver);
            }

        }

        private string[] IDCOAction(DataRow ActionRow)
        {
            string[] IDCO;
            string OLDIDCO = "";
            string NEWIDCO = "";
            string[] Help = ActionRow["IDCO"].ToString().Split('/');

            if (Help[0] != "")
            {
                foreach (string OneIDCO in Help)
                {
                    if (OneIDCO != "")
                    {
                        string[] Help2 = OneIDCO.Split('|');
                        IDCOTabela.Add(Help2[0], Help2[1]);
                    }
                }

                string[] OLDANC = ActionRow["Old ANC"].ToString().Split('|');
                string[] NEWANC = ActionRow["New ANC"].ToString().Split('|');

                foreach (string old in OLDANC)
                {
                    if (old != "")
                    {
                        if (IDCOTabela.ContainsKey(old))
                        {
                            OLDIDCO = IDCOTabela[old] + "/";
                        }
                    }
                }

                foreach (string old in NEWANC)
                {
                    if (old != "")
                    {
                        if (IDCOTabela.ContainsKey(old))
                        {
                            NEWIDCO = IDCOTabela[old] + "/";
                        }
                    }
                }

                IDCO = new string[] { OLDIDCO, NEWIDCO };

            }
            else
            {
                IDCO = null;
            }
            return IDCO;
        }

        private void AddMinimum(ref DataRow RowtoAdd, DataRow ActionRow, int MonthEnd, bool CarryOver, string[] IDCO)
        {
            int Monthstart = Month[ActionRow["StartMonth"].ToString()];
            decimal YearAction;
            if (ActionRow["StartYear"].ToString().Length == 4)
                YearAction = decimal.Parse(ActionRow["StartYear"].ToString());
            else
                YearAction = decimal.Parse(ActionRow["StartYear"].ToString().Remove(0, 3));

            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                    RowtoAdd["ANC Old"] = ActionRow["Old ANC"].ToString().Replace("|", "");

                if (Preferencje["Old IDCO"])
                    if (IDCO != null)
                        RowtoAdd["Old IDCO"] = IDCO[0];

                if (Preferencje["Old STK"])
                    RowtoAdd["Old STK"] = ActionRow["Old STK"].ToString().Replace("|", "");
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                    RowtoAdd["ANC New"] = ActionRow["New ANC"].ToString().Replace("|", "");

                if (Preferencje["New IDCO"])
                    if (IDCO != null)
                        RowtoAdd["New IDCO"] = IDCO[1];

                if (Preferencje["New STK"])
                    RowtoAdd["New STK"] = ActionRow["New STK"].ToString().Replace("|", "");
            }

            if (Preferencje["Delta"])
            {
                if (YearAction == DateTime.Now.Year)
                {
                    if (Monthstart < MonthEnd)
                    {
                        RowtoAdd["Delta"] = Delta(ActionRow["Delta"].ToString());
                    }
                    else
                    {
                        RowtoAdd["Delta"] = Delta(ActionRow["STKCal"].ToString());
                    }
                }
                else if (YearAction < DateTime.Now.Year)
                {
                    RowtoAdd["Delta"] = Delta(ActionRow["Delta"].ToString());
                }
                else
                {
                    RowtoAdd["Delta"] = Delta(ActionRow["STKCal"].ToString());
                }
            }

            if (Preferencje["Quantity"])
            {
                string[] Help;
                string Rewizja = "Actual";
                int RevStart = 0;

                if (Preferencje["BU"])
                {
                    Rewizja = "BU";
                    RevStart = 1;
                }
                else if (Preferencje["EA1"])
                {
                    Rewizja = "EA1";
                    RevStart = 3;
                }
                else if (Preferencje["EA2"])
                {
                    Rewizja = "EA2";
                    RevStart = 6;
                }
                else if (Preferencje["EA3"])
                {
                    Rewizja = "EA3";
                    RevStart = 9;
                }
                if (Rewizja != "Actual")
                {
                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSEQuantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSEQuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["Q" + counter] = double.Parse(Help[counter - 1]);
                    }

                    if (!CarryOver)
                    {
                        Help = ActionRow["Calc" + Rewizja + "Quantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["Calc" + Rewizja + "QuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["Q" + counter] = double.Parse(Help[counter - 1]);
                    }
                }

                if (Preferencje["Actual"])
                {

                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSEQuantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSEQuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["Q" + counter] = double.Parse(Help[counter - 1]);
                    }
                }

                double sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["Q" + counter.ToString()].ToString() != "")
                    {
                        sum += double.Parse(RowtoAdd["Q" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["Q13"] = sum;
            }
            if (Preferencje["Savings"])
            {
                string[] Help;
                string Rewizja = "Actual";
                int RevStart = 0;

                if (Preferencje["BU"])
                {
                    Rewizja = "BU";
                    RevStart = 1;
                }
                else if (Preferencje["EA1"])
                {
                    Rewizja = "EA1";
                    RevStart = 3;
                }
                else if (Preferencje["EA2"])
                {
                    Rewizja = "EA2";
                    RevStart = 6;
                }
                else if (Preferencje["EA3"])
                {
                    Rewizja = "EA3";
                    RevStart = 9;
                }
                if (Rewizja != "Actual")
                {
                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSESaving"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSESavingCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["S" + counter] = double.Parse(Help[counter - 1]);
                    }

                    if (!CarryOver)
                    {
                        Help = ActionRow["Calc" + Rewizja + "Saving"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["Calc" + Rewizja + "SavingCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["S" + counter] = double.Parse(Help[counter - 1]);
                    }
                }
                else
                {

                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSESaving"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSESavingCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["S" + counter] = double.Parse(Help[counter - 1]);
                    }
                }

                double sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["S" + counter.ToString()].ToString() != "")
                    {
                        sum += double.Parse(RowtoAdd["S" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["S13"] = sum;
            }
            if (Preferencje["ECCC"])
            {
                string[] Help;
                string Rewizja = "Actual";
                int RevStart = 0;

                if (Preferencje["BU"])
                {
                    Rewizja = "BU";
                    RevStart = 1;
                }
                else if (Preferencje["EA1"])
                {
                    Rewizja = "EA1";
                    RevStart = 3;
                }
                else if (Preferencje["EA2"])
                {
                    Rewizja = "EA2";
                    RevStart = 6;
                }
                else if (Preferencje["EA3"])
                {
                    Rewizja = "EA3";
                    RevStart = 9;
                }
                if (Rewizja != "Actual")
                {
                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSEECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSEECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }

                    if (!CarryOver)
                    {
                        Help = ActionRow["Calc" + Rewizja + "ECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["Calc" + Rewizja + "ECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }
                }
                else
                {

                    if (!CarryOver)
                    {
                        Help = ActionRow["CalcUSEECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionRow["CalcUSEECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }
                }

                double sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["E" + counter.ToString()].ToString() != "")
                    {
                        sum += double.Parse(RowtoAdd["E" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["E13"] = sum;
            }
        }

        private void AddMediumMaximum(ref DataRow RowtoAdd, DataRow Rewizion, ref DataTable Devision, int MonthEnd, bool CarryOver)
        {
            int Monthstart = Month[Rewizion["StartMonth"].ToString()];
            decimal YearAction;
            if (Rewizion["StartYear"].ToString().Length == 4)
                YearAction = decimal.Parse(Rewizion["StartYear"].ToString());
            else
                YearAction = decimal.Parse(Rewizion["StartYear"].ToString().Remove(0, 3));
            string Rewizja = "";
            int RevStart = 0;
            int RefFinish = 12;
            string[] OldANC;
            string[] NewANC;
            string[] OLDSTK;
            string[] NEWSTK;
            string[] Delta;
            string[] Next;
            bool NewtoCalc;
            string over = "";
            int Start = 1;
            int Finish = 0;
            DataTable PerANCUSE = new DataTable();
            DataTable PerANCRew = new DataTable();

            if (CarryOver)
                over = "Carry";

            CreateColumnPerANC("USE", PerANCUSE);
            PerANC_PNCToTable(Rewizion, "USE", ref PerANCUSE, over, 1);


            if (Preferencje["Actual"])
            {
                Finish = 12;
                RevStart = 0;
                RefFinish = 0;
            }
            else if (Preferencje["BU"])
            {
                RevStart = 1;
                Finish = 0;
                CreateColumnPerANC("BU", PerANCRew);
                PerANC_PNCToTable(Rewizion, "BU", ref PerANCRew, over, 1);
            }
            else if (Preferencje["EA1"])
            {
                RevStart = 3;
                Finish = 2;
                CreateColumnPerANC("EA1", PerANCRew);
                PerANC_PNCToTable(Rewizion, "EA1", ref PerANCRew, over, 3);
            }
            else if (Preferencje["EA2"])
            {
                RevStart = 6;
                Finish = 5;
                CreateColumnPerANC("EA2", PerANCRew);
                PerANC_PNCToTable(Rewizion, "EA2", ref PerANCRew, over, 6);
            }
            else if (Preferencje["EA3"])
            {
                RevStart = 9;
                Finish = 8;
                CreateColumnPerANC("EA3", PerANCRew);
                PerANC_PNCToTable(Rewizion, "EA3", ref PerANCRew, over, 9);
            }


            OldANC = Rewizion["Old ANC"].ToString().Split('|');
            NewANC = Rewizion["New ANC"].ToString().Split('|');
            OLDSTK = Rewizion["Old STK"].ToString().Split('|');
            NEWSTK = Rewizion["New STK"].ToString().Split('|');
            Next = Rewizion["Next"].ToString().Split('|');

            if (YearAction == DateTime.Now.Year)
            {
                if (Monthstart < DateTime.Now.Month)
                {
                    Delta = Rewizion["Delta"].ToString().Split('|');
                    NewtoCalc = true;
                }
                else
                {
                    Delta = Rewizion["STKCal"].ToString().Split('|');
                    NewtoCalc = false;
                }
            }
            else if (YearAction < DateTime.Now.Year)
            {
                Delta = Rewizion["Delta"].ToString().Split('|');
                NewtoCalc = true;
            }
            else
            {
                Delta = Rewizion["STKCal"].ToString().Split('|');
                NewtoCalc = false;
            }
            if (Preferencje["ECCC"])
            {
                string[] Help;
                if (Rewizja != "Actual")
                {
                    if (!CarryOver)
                    {
                        Help = Rewizion["CalcUSEECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["CalcUSEECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }

                    if (!CarryOver)
                    {
                        Help = Rewizion["Calc" + Rewizja + "ECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["Calc" + Rewizja + "ECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }
                }
                else
                {

                    if (!CarryOver)
                    {
                        Help = Rewizion["CalcUSEECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["CalcUSEECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        if (Help[counter - 1] != "")
                            RowtoAdd["E" + counter] = double.Parse(Help[counter - 1]);
                    }
                }

                double sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["E" + counter.ToString()].ToString() != "")
                    {
                        sum += double.Parse(RowtoAdd["E" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["E13"] = sum;
            }

            Devision.Rows.Add(RowtoAdd);

            for (int counter = 0; counter < OldANC.Length - 1; counter++)
            {
                DataRow NewRow = Devision.NewRow();
                if (Preferencje["Old ANC"])
                {
                    if (Preferencje["ANC Old"])
                        NewRow["ANC Old"] = OldANC[counter];

                    if (Preferencje["Old IDCO"])
                        if (IDCOTabela.ContainsKey(OldANC[counter].ToString()))
                            NewRow["Old IDCO"] = IDCOTabela[OldANC[counter].ToString()];

                    if (Preferencje["Old STK"])
                        NewRow["Old STK"] = OLDSTK[counter];
                }
                if (Preferencje["New ANC"])
                {
                    if (Preferencje["ANC New"])
                        NewRow["ANC New"] = NewANC[counter];

                    if (Preferencje["New IDCO"])
                        if (IDCOTabela.ContainsKey(NewANC[counter].ToString()))
                            NewRow["New IDCO"] = IDCOTabela[NewANC[counter].ToString()];

                    if (Preferencje["New STK"])
                        NewRow["New STK"] = NEWSTK[counter];
                }

                if (Preferencje["Delta"])
                {
                    NewRow["Delta"] = Delta[counter];
                }

                if (Preferencje["Actual"])
                {
                    if (NewANC[counter] != "")
                    {

                        for (int counter2 = Start; counter2 <= Finish; counter2++)
                        {
                            DataRow ANC = PerANCUSE.Select(string.Format("Name LIKE '%{0}%'", NewANC[counter])).FirstOrDefault();

                            if (ANC != null)
                            {
                                string[] Help = ANC[counter2.ToString()].ToString().Split(':');
                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        if (Help[0] != "")
                                            NewRow["Q" + counter2.ToString()] = double.Parse(Help[0]);
                                    if (Preferencje["Savings"])
                                        if (Help[1] != "")
                                            NewRow["S" + counter2.ToString()] = double.Parse(Help[1]);
                                }
                            }
                        }

                    }
                    if (Next[counter] != "")
                    {

                        for (int counter2 = Start; counter2 <= Finish; counter2++)
                        {
                            DataRow ANC = PerANCUSE.Select(string.Format("Name LIKE '%{0}%'", NewANC[counter])).FirstOrDefault();

                            if (ANC != null)
                            {
                                string[] Help = ANC[counter2.ToString()].ToString().Split(':');

                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        if (Help[0] != "")
                                            NewRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString()) + double.Parse(NewRow["Q" + counter2.ToString()].ToString());
                                    if (Preferencje["Savings"])
                                        if (Help[1] != "")
                                            NewRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString()) + double.Parse(NewRow["S" + counter2.ToString()].ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!NewtoCalc)
                    {
                        if (OldANC[counter] != "")
                        {
                            DataRow ANC = PerANCRew.Select(string.Format("Name LIKE '%{0}%'", OldANC[counter])).FirstOrDefault();

                            if (ANC != null)
                            {
                                for (int counter2 = RevStart; counter2 <= RefFinish; counter2++)
                                {
                                    string[] Help = ANC[counter2.ToString()].ToString().Split(':');

                                    if (Help[0] != "")
                                    {
                                        if (Preferencje["Quantity"])
                                            if (Help[0] != "")
                                                NewRow["Q" + counter2.ToString()] = double.Parse(Help[0]);
                                        if (Preferencje["Savings"])
                                            if (Help[1] != "")
                                                NewRow["S" + counter2.ToString()] = double.Parse(Help[1]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (NewANC[counter] != "")
                        {

                            for (int counter2 = RevStart; counter2 <= RefFinish; counter2++)
                            {
                                DataRow ANC = PerANCRew.Select(string.Format("Name LIKE '%{0}%'", NewANC[counter])).FirstOrDefault();

                                if (ANC != null)
                                {
                                    string[] Help = ANC[counter2.ToString()].ToString().Split(':');
                                    if (Help[0] != "")
                                    {
                                        if (Preferencje["Quantity"])
                                            if (Help[0] != "")
                                                NewRow["Q" + counter2.ToString()] = double.Parse(Help[0]);
                                        if (Preferencje["Savings"])
                                            if (Help[1] != "")
                                                NewRow["S" + counter2.ToString()] = double.Parse(Help[1]);
                                    }
                                }
                            }

                        }
                        if (Next[counter] != "")
                        {

                            for (int counter2 = RevStart; counter2 <= RefFinish; counter2++)
                            {
                                DataRow ANC = PerANCRew.Select(string.Format("Name LIKE '%{0}%'", NewANC[counter])).FirstOrDefault();

                                if (ANC != null)
                                {
                                    string[] Help = ANC[counter2.ToString()].ToString().Split(':');

                                    if (Help[0] != "")
                                    {
                                        if (Preferencje["Quantity"])
                                            if (Help[0] != "")
                                                NewRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString()) + double.Parse(NewRow["Q" + counter2.ToString()].ToString());
                                        if (Preferencje["Savings"])
                                            if (Help[1] != "")
                                                NewRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString()) + double.Parse(NewRow["S" + counter2.ToString()].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                double sum = 0;
                if (Preferencje["Quantity"])
                {
                    for (int counter2 = 1; counter2 <= 12; counter2++)
                    {
                        if (NewRow["Q" + counter2.ToString()].ToString() != "")
                            sum += double.Parse(NewRow["Q" + counter2.ToString()].ToString());
                    }
                    NewRow["Q13"] = sum;
                    sum = 0;
                }
                if (Preferencje["Savings"])
                {
                    for (int counter2 = 1; counter2 <= 12; counter2++)
                    {
                        if (NewRow["S" + counter2.ToString()].ToString() != "")
                            sum += double.Parse(NewRow["S" + counter2.ToString()].ToString());
                    }
                    NewRow["S13"] = sum;
                }
                Devision.Rows.Add(NewRow);
            }
        }

        private double Delta(string DeltaToCalc)
        {
            double DeltaSum = 0;
            string[] Help = DeltaToCalc.Split('|');

            foreach (string HelpRow in Help)
            {
                if (HelpRow != "")
                {
                    DeltaSum += double.Parse(HelpRow);
                }
            }

            return DeltaSum;
        }

        //private string[] CalculationUSEANC(int Month, decimal YearToCalc, ref DataRow Action, ref DataTable QuantityANCTableMonth, string ANC, string ANCNext, string Delta)
        //{
        //    DataTable QuantityANCTable = new DataTable();
        //    DataRow QuantityRow;
        //    decimal QuantityANC = 0;
        //    decimal Savings = 0;
        //    decimal DeltaCost;
        //    string[] Results = new string[2];



        //    //Znalezienie ilości do odpowiednich ANC
        //    if (ANC != "")
        //    {
        //        QuantityRow = QuantityANCTableMonth.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
        //        QuantityANC = decimal.Parse(QuantityRow[Month.ToString() + "/" + YearToCalc.ToString()].ToString());

        //    }
        //    if (ANCNext != "")
        //    {
        //        QuantityRow = QuantityANCTableMonth.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
        //        QuantityANC += decimal.Parse(QuantityRow[Month.ToString() + "/" + YearToCalc.ToString()].ToString());
        //    }


        //    //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 
        //    DeltaCost = decimal.Parse(Delta);
        //    Savings = (QuantityANC * DeltaCost);
        //    Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

        //    Results[0] = QuantityANC.ToString();
        //    Results[1] = Savings.ToString();

        //    return Results;
        //}

        //private string[] CalculationANC(int Month, string Revision, ref DataRow Action, ref DataTable QuantityANCTableRewizion, string ANC, string ANCNext, string Delta)
        //{
        //    DataRow QuantityRow;
        //    decimal Quantity;
        //    decimal QuantityANC = 0;
        //    decimal Savings;
        //    decimal DeltaCost;
        //    decimal QuantityPercent;
        //    string[] Results = new string[2];

        //    string[] Help;
        //    //int RevisionStart = RevisionStartMonth[Revision];

        //    Help = Action["Percent"].ToString().Split('|');

        //    QuantityPercent = decimal.Parse(Help[0]) / 100;

        //    if (ANC != "")
        //    {
        //        QuantityRow = QuantityANCTableRewizion.Select(string.Format("BUANC LIKE '%{0}%'", ANC)).FirstOrDefault();
        //        QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
        //    }
        //    if (ANCNext != "")
        //    {
        //        QuantityRow = QuantityANCTableRewizion.Select(string.Format("BUANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
        //        QuantityANC += (decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent);
        //    }


        //    //Dodanie Ilości nadego ANC dla Quantity wykorzystywanego w danym miesiącu 
        //    Quantity = QuantityANC;

        //    //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 

        //    DeltaCost = decimal.Parse(Delta);
        //    Savings = (Quantity * DeltaCost);
        //    Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

        //    Results[0] = QuantityANC.ToString();
        //    Results[1] = Savings.ToString();

        //    return Results;
        //}

        private void CreateColumnPerANC(string Rew, DataTable Table)
        {
            DataColumn Name = new DataColumn("Name");
            DataColumn M1 = new DataColumn("1");
            DataColumn M2 = new DataColumn("2");
            DataColumn M3 = new DataColumn("3");
            DataColumn M4 = new DataColumn("4");
            DataColumn M5 = new DataColumn("5");
            DataColumn M6 = new DataColumn("6");
            DataColumn M7 = new DataColumn("7");
            DataColumn M8 = new DataColumn("8");
            DataColumn M9 = new DataColumn("9");
            DataColumn M10 = new DataColumn("10");
            DataColumn M11 = new DataColumn("11");
            DataColumn M12 = new DataColumn("12");

            if (Rew == "USE")
            {
                Table.Columns.Add(Name);
                Table.Columns.Add(M1);
                Table.Columns.Add(M2);
                Table.Columns.Add(M3);
                Table.Columns.Add(M4);
                Table.Columns.Add(M5);
                Table.Columns.Add(M6);
                Table.Columns.Add(M7);
                Table.Columns.Add(M8);
                Table.Columns.Add(M9);
                Table.Columns.Add(M10);
                Table.Columns.Add(M11);
                Table.Columns.Add(M12);
            }
            else if (Rew == "BU")
            {
                Table.Columns.Add(Name);
                Table.Columns.Add(M1);
                Table.Columns.Add(M2);
                Table.Columns.Add(M3);
                Table.Columns.Add(M4);
                Table.Columns.Add(M5);
                Table.Columns.Add(M6);
                Table.Columns.Add(M7);
                Table.Columns.Add(M8);
                Table.Columns.Add(M9);
                Table.Columns.Add(M10);
                Table.Columns.Add(M11);
                Table.Columns.Add(M12);
            }
            else if (Rew == "EA1")
            {
                Table.Columns.Add(Name);
                Table.Columns.Add(M3);
                Table.Columns.Add(M4);
                Table.Columns.Add(M5);
                Table.Columns.Add(M6);
                Table.Columns.Add(M7);
                Table.Columns.Add(M8);
                Table.Columns.Add(M9);
                Table.Columns.Add(M10);
                Table.Columns.Add(M11);
                Table.Columns.Add(M12);
            }
            else if (Rew == "EA2")
            {
                Table.Columns.Add(Name);
                Table.Columns.Add(M6);
                Table.Columns.Add(M7);
                Table.Columns.Add(M8);
                Table.Columns.Add(M9);
                Table.Columns.Add(M10);
                Table.Columns.Add(M11);
                Table.Columns.Add(M12);
            }
            else if (Rew == "EA3")
            {
                Table.Columns.Add(Name);
                Table.Columns.Add(M9);
                Table.Columns.Add(M10);
                Table.Columns.Add(M11);
                Table.Columns.Add(M12);
            }
        }

        private void PerANC_PNCToTable(DataRow Action, string Rew, ref DataTable PerANC, string Carry, int MonthStart)
        {

            if (Action["Per" + Rew + Carry].ToString() != "")
            {
                string[] Help = Action["Per" + Rew + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = PerANC.NewRow();
                        string[] Help3 = Help2.Split('|');
                        NewRow["Name"] = Help3[0];
                        for (int counter = MonthStart; counter <= 12; counter++)
                        {
                            NewRow[counter.ToString()] = Help3[counter];
                        }
                        PerANC.Rows.Add(NewRow);
                    }
                }
            }
        }
    }
}