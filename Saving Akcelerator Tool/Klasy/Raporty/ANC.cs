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
        Data_Import ImportData;
        private readonly Dictionary<string, bool> Preferencje = new Dictionary<string, bool> { };
        private readonly Dictionary<string, string> IDCOTabela = new Dictionary<string, string> { };
        private readonly Dictionary<string, int> Month = new Dictionary<string, int>()
        {
            {"January", 1},
            {"Febuary", 2},
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

        public ANC(Data_Import ImportData, Dictionary<string, bool> Preferencje)
        {
            this.Preferencje = Preferencje;
            this.ImportData = ImportData;
        }
        public void PrepareANC(DataRow ActionRow, DataTable ActionMonth, DataTable ActionRewizion, ref DataTable Devision, int MonthEnd, bool CarryOver, string Status)
        {
            DataRow RowtoAdd = Devision.NewRow();
            DataRow ActionMonthRow;
            DataRow ActionRewizionRow;
            bool OnlyOneRow = false;

            ActionMonthRow = FindAction(ActionMonth, ActionRow["Name"].ToString());
            ActionRewizionRow = FindAction(ActionRewizion, ActionRow["Name"].ToString());

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
                AddMinimum(ref RowtoAdd, ActionRow, ActionMonthRow, ActionRewizionRow, MonthEnd, CarryOver, Status, IDCO);
            }
            else if (Preferencje["Medium"] || Preferencje["Maximum"])
            {
                Devision.Rows.Add(RowtoAdd);
                AddMediumMaximum(ref RowtoAdd, ActionRow, ActionMonthRow, ActionRewizionRow, ref Devision, MonthEnd, CarryOver, Status);
            }

        }

        private DataRow FindAction(DataTable Action, string Name)
        {
            foreach (DataRow ActionRow in Action.Rows)
            {
                if (ActionRow["Name"].ToString() == Name)
                {
                    return ActionRow;
                }
            }

            return null;
        }

        private string[] IDCOAction(DataRow ActionRow)
        {
            string[] IDCO;
            string OLDIDCO = "";
            string NEWIDCO = "";
            string[] Help = ActionRow["IDCO"].ToString().Split('/');

            foreach (string OneIDCO in Help)
            {
                string[] Help2 = OneIDCO.Split('|');
                IDCOTabela.Add(Help2[0], Help2[1]);
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

            return IDCO;
        }

        private void AddMinimum(ref DataRow RowtoAdd, DataRow ActionRow, DataRow ActionMonth, DataRow Rewizion, int MonthEnd, bool CarryOver, string Status, string[] IDCO)
        {
            int Monthstart = Month[ActionRow["StartMonth"].ToString()];
            decimal YearAction = decimal.Parse(ActionRow["StartYear"].ToString());

            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                    RowtoAdd["ANC Old"] = ActionRow["Old ANC"];

                if (Preferencje["Old IDCO"])
                    RowtoAdd["Old IDCO"] = IDCO[0];

                if (Preferencje["Old STK"])
                    RowtoAdd["Old STK"] = ActionRow["Old STK"];
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                    RowtoAdd["ANC New"] = ActionRow["New ANC"];

                if (Preferencje["New IDCO"])
                    RowtoAdd["New IDCO"] = IDCO[1];

                if (Preferencje["New STK"])
                    RowtoAdd["New STK"] = ActionRow["New STK"];
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
                        RowtoAdd["Delta"] = Delta(ActionRow["ToCal"].ToString());
                    }
                }
                else if (YearAction < DateTime.Now.Year)
                {
                    RowtoAdd["Delta"] = Delta(ActionRow["Delta"].ToString());
                }
                else
                {
                    RowtoAdd["Delta"] = Delta(ActionRow["ToCal"].ToString());
                }
            }

            if (Preferencje["Quantity"])
            {
                string[] Help;
                string Rewizja = "";
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
                if (Rewizja != "")
                {
                    if (!CarryOver)
                    {
                        Help = Rewizion["CalcUSEQuantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["CalcUSEQuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        RowtoAdd["Q" + counter] = Help[counter - 1];
                    }

                    if (!CarryOver)
                    {
                        Help = Rewizion["Calc" + Rewizja + "Quantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["Calc" + Rewizja + "QuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        RowtoAdd["Q" + counter] = Help[counter - 1];
                    }
                }

                if (Preferencje["Actual"])
                {

                    if (!CarryOver)
                    {
                        Help = ActionMonth["CalcUSEQuantity"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionMonth["CalcUSEQuantityCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        RowtoAdd["Q" + counter] = Help[counter - 1];
                    }
                }

                decimal sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["Q" + counter.ToString()].ToString() != "")
                    {
                        sum = sum + decimal.Parse(RowtoAdd["Q" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["Q13"] = sum;
            }
            if (Preferencje["Savings"])
            {
                string[] Help;
                string Rewizja = "";
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
                if (Rewizja != "")
                {
                    if (!CarryOver)
                    {
                        Help = Rewizion["CalcUSESavings"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["CalcUSESavingsCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter < RevStart; counter++)
                    {
                        RowtoAdd["S" + counter] = Help[counter - 1];
                    }

                    if (!CarryOver)
                    {
                        Help = Rewizion["Calc" + Rewizja + "Savings"].ToString().Split('/');
                    }
                    else
                    {
                        Help = Rewizion["Calc" + Rewizja + "SavingsCarry"].ToString().Split('/');
                    }

                    for (int counter = RevStart; counter <= 12; counter++)
                    {
                        RowtoAdd["S" + counter] = Help[counter - 1];
                    }
                }

                if (Preferencje["Actual"])
                {

                    if (!CarryOver)
                    {
                        Help = ActionMonth["CalcUSESavings"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionMonth["CalcUSESavingsCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        RowtoAdd["S" + counter] = Help[counter - 1];
                    }
                }

                decimal sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["S" + counter.ToString()].ToString() != "")
                    {
                        sum = sum + decimal.Parse(RowtoAdd["S" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["S13"] = sum;
            }
            if (Preferencje["ECCC"])
            {
                string[] Help;
                string Rewizja = "";
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
                if (Rewizja != "")
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
                        RowtoAdd["E" + counter] = Help[counter - 1];
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
                        RowtoAdd["E" + counter] = Help[counter - 1];
                    }
                }

                if (Preferencje["Actual"])
                {

                    if (!CarryOver)
                    {
                        Help = ActionMonth["CalcUSEECCC"].ToString().Split('/');
                    }
                    else
                    {
                        Help = ActionMonth["CalcUSEECCCCarry"].ToString().Split('/');
                    }

                    for (int counter = 1; counter <= MonthEnd; counter++)
                    {
                        RowtoAdd["E" + counter] = Help[counter - 1];
                    }
                }

                decimal sum = 0;
                for (int counter = 1; counter < 13; counter++)
                {
                    if (RowtoAdd["E" + counter.ToString()].ToString() != "")
                    {
                        sum = sum + decimal.Parse(RowtoAdd["E" + counter.ToString()].ToString());
                    }
                }
                RowtoAdd["E13"] = sum;
            }

        }

        private void AddMediumMaximum(ref DataRow RowtoAdd, DataRow ActionRow, DataRow ActionMonth, DataRow Rewizion, ref DataTable Devision, int MonthEnd, bool CarryOver, string Status)
        {
            int Monthstart = Month[ActionRow["StartMonth"].ToString()];
            decimal YearAction = decimal.Parse(ActionRow["StartYear"].ToString());
            string Rewizja = "";
            int RevStart = 0;
            string[] OldANC;
            string[] NewANC;
            string[] OLDSTK;
            string[] NEWSTK;
            string[] Delta;
            string[] Next;
            DataTable ANC = new DataTable();
            DataTable BUANC = new DataTable();
            string Link;
            bool NewtoCalc = false;
            decimal[] Quantity = new decimal[12];
            string over = "";
            int Start =0;
            int Finish = 0;



            Link = ImportData.Load_Link("ANCMonth");
            ImportData.Load_TxtToDataTable(ref ANC, Link);
            Link = ImportData.Load_Link("ANC");
            ImportData.Load_TxtToDataTable(ref BUANC, Link);

            if(YearAction == DateTime.Now.Year || YearAction > DateTime.Now.Year)
            {
                Start = Monthstart;
                Finish = 12;
            }
            else if(YearAction < DateTime.Now.Year)
            {
                Start = 1;
                Finish = Monthstart - 1;
            }

            if (CarryOver)
                over = "Carry";

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

            OldANC = ActionRow["Old ANC"].ToString().Split('|');
            NewANC = ActionRow["New ANC"].ToString().Split('|');
            OLDSTK = ActionRow["Old STK"].ToString().Split('|');
            NEWSTK = ActionRow["New STK"].ToString().Split('|');
            Next = ActionRow["Next"].ToString().Split('|');

            if (YearAction == DateTime.Now.Year)
            {
                if (Monthstart < MonthEnd)
                {
                    Delta = ActionRow["Delta"].ToString().Split('|');
                    NewtoCalc = true;
                }
                else
                {
                    Delta = ActionRow["ToCal"].ToString().Split('|');
                    NewtoCalc = false;
                }
            }
            else if (YearAction < DateTime.Now.Year)
            {
                Delta = ActionRow["Delta"].ToString().Split('|');
                NewtoCalc = true;
            }
            else
            {
                Delta = ActionRow["ToCal"].ToString().Split('|');
                NewtoCalc = false;
            }



            for (int counter = 0; counter < OldANC.Length - 1; counter++)
            {
                DataRow NewRow = Devision.NewRow();
                if (Preferencje["Old ANC"])
                {
                    if (Preferencje["ANC Old"])
                        NewRow["ANC Old"] = OldANC[counter];

                    if (Preferencje["Old IDCO"])
                        NewRow["Old IDCO"] = IDCOTabela[OldANC[counter].ToString()];

                    if (Preferencje["Old STK"])
                        NewRow["Old STK"] = OLDSTK[counter];
                }
                if (Preferencje["New ANC"])
                {
                    if (Preferencje["ANC New"])
                        NewRow["ANC New"] = NewANC[counter];

                    if (Preferencje["New IDCO"])
                        NewRow["New IDCO"] = IDCOTabela[NewANC[counter].ToString()];

                    if (Preferencje["New STK"])
                        NewRow["New STK"] = NEWSTK[counter];
                }

                if (Preferencje["Delta"])
                {
                    NewRow["Delta"] = Delta[counter];
                }


                DataRow BaseANCNEW;
                DataRow BaseANCOLD;
                DataRow BaseNEXTRew;
                DataRow BaseNEXTMonth;

                if (OldANC[counter] != "")
                    BaseANCOLD = BUANC.Select(string.Format("BUANC LIKE '%{0}%'", OldANC[counter])).First();

                if (NewANC[counter] != "")
                    BaseANCNEW = ANC.Select(string.Format("ANC LIKE '%{0}%'", NewANC[counter])).First();

                if (Next[counter] != "")
                {
                    BaseNEXTRew = BUANC.Select(string.Format("BUANC LIKE '%{0}%'", Next[counter])).First();
                    BaseNEXTMonth = ANC.Select(string.Format("ANC LIKE '%{0}%'", Next[counter])).First();
                }

                for (int counter2 = Start; counter2 <= Finish; counter2++)
                {
                    string[] Results = new string[2]; 
                    if(YearAction <= DateTime.Now.Year)
                    {
                        if(counter2 < MonthEnd)
                        {
                            //Use
                            Results = CalculationUSEANC(counter2, YearAction, ref ActionRow, ref ANC, NewANC[counter], Next[counter], Delta[counter]);
                        }
                        else
                        {
                            //Res
                            //Results = CalculationANC(counter2, Rewizja,  ref ActionRow, ref BUANC, OldANC[counter], Ne  )
                        }
                    }
                    else
                    {
                        //Tylko rew
                    }
                }


                Devision.Rows.Add(NewRow);
            }

        }

        private string Delta(string DeltaToCalc)
        {
            decimal DeltaSum = 0;
            string[] Help = DeltaToCalc.Split('|');

            foreach (string HelpRow in Help)
            {
                if (HelpRow != "")
                {
                    DeltaSum = DeltaSum + decimal.Parse(HelpRow);
                }
            }

            return DeltaSum.ToString();
        }

        private string[] CalculationUSEANC(int Month, decimal YearToCalc, ref DataRow Action, ref DataTable QuantityANCTableMonth, string ANC, string ANCNext, string Delta)
        {
            DataTable QuantityANCTable = new DataTable();
            DataRow QuantityRow;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal DeltaCost;
            string[] Results = new string[2];



            //Znalezienie ilości do odpowiednich ANC
            if (ANC != "")
            {
                QuantityRow = QuantityANCTableMonth.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                QuantityANC = decimal.Parse(QuantityRow[Month.ToString() + "/" + YearToCalc.ToString()].ToString());

            }
            if (ANCNext != "")
            {
                QuantityRow = QuantityANCTableMonth.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                QuantityANC = QuantityANC + decimal.Parse(QuantityRow[Month.ToString() + "/" + YearToCalc.ToString()].ToString());
            }


            //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 
            DeltaCost = decimal.Parse(Delta);
            Savings = (QuantityANC * DeltaCost);
            Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

            Results[0] = QuantityANC.ToString();
            Results[1] = Savings.ToString();

            return Results;
        }

        private string[] CalculationANC(int Month, string Revision, ref DataRow Action, ref DataTable QuantityANCTableRewizion, string ANC, string ANCNext, string Delta)
        {
            DataTable QuantityANCTable = new DataTable();
            DataRow QuantityRow;
            decimal Quantity = 0;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal DeltaCost;
            decimal QuantityPercent;
            string[] Results = new string[2];

            string[] Help;
            //int RevisionStart = RevisionStartMonth[Revision];

            Help = Action["Percent"].ToString().Split('|');

            QuantityPercent = decimal.Parse(Help[0]) / 100;

            if (ANC != "")
            {
                QuantityRow = QuantityANCTableRewizion.Select(string.Format("BUANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
            }
            if (ANCNext != "")
            {
                QuantityRow = QuantityANCTableRewizion.Select(string.Format("BUANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                QuantityANC = QuantityANC + (decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent);
            }


            //Dodanie Ilości nadego ANC dla Quantity wykorzystywanego w danym miesiącu 
            Quantity = QuantityANC;

            //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 

            DeltaCost = decimal.Parse(Delta);
            Savings = (QuantityANC * DeltaCost);
            Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

            Results[0] = QuantityANC.ToString();
            Results[1] = Savings.ToString();

            return Results;
        }
    }
}