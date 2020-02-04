using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class PNCSpec
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

        public PNCSpec( Dictionary<string, bool> Preferencje)
        {
            this.Preferencje = Preferencje;
        }

        public void PrepareANCSpec(DataRow ActionRow, ref DataTable Devision, int MonthEnd, bool CarryOver, string Status)
        {
            DataRow RowtoAdd = Devision.NewRow();

            string[] IDCO = IDCOAction(ActionRow);

            RowtoAdd["Name"] = ActionRow["Name"];

            if (Preferencje["Description"])
                RowtoAdd["Description"] = ActionRow["Description"];

            if (Preferencje["Status"])
                RowtoAdd["Status"] = Status;

            if (Preferencje["Platform"])
                RowtoAdd["Platform"] = ActionRow["Platform"];

            if (Preferencje["Minimum"])
            {
                AddMinimum(ref RowtoAdd, ActionRow, MonthEnd, CarryOver, IDCO);
                Devision.Rows.Add(RowtoAdd);
            }
            else if (Preferencje["Medium"])
            {
                AddMedium(ref RowtoAdd, ActionRow, ref Devision, MonthEnd, CarryOver);
            }
            else if (Preferencje["Maximum"])
            {
                AddMaximum(ref RowtoAdd, ActionRow, ref Devision, MonthEnd, CarryOver);
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
                    RowtoAdd["ANC Old"] = ActionRow["Old ANC"];

                if (Preferencje["Old IDCO"])
                    if (IDCO != null)
                        RowtoAdd["Old IDCO"] = IDCO[0];

                if (Preferencje["Old STK"])
                    RowtoAdd["Old STK"] = ActionRow["Old STK"];
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                    RowtoAdd["ANC New"] = ActionRow["New ANC"];

                if (Preferencje["New IDCO"])
                    if (IDCO != null)
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
                        if(Help[counter-1] != "")
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

        private void AddMedium(ref DataRow RowtoAdd, DataRow Rewizion, ref DataTable Devision, int MonthEnd, bool CarryOver)
        {
            string Rewizja = "";
            int RevStart = 0;
            int RefFinish = 12;
            string[] Delta;
            string[] Calc;
            string[] PNC;
            string over = "";
            int Start = 1;
            int Finish = 0;
            int CounterPNC = 0;
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
                        if(Help[counter-1] !="")
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

            PNC = Rewizion["PNC"].ToString().Split('|');
            Calc= Rewizion["PNCSumSTK"].ToString().Split('|');
            Delta = Rewizion["PNCSumDelta"].ToString().Split('|');

            foreach (string PNCOne in PNC)
            {
                if (PNCOne != "")
                {
                    DataRow PNCRow = Devision.NewRow();
                    if (Preferencje["ANC Old"])
                        PNCRow["ANC Old"] = PNCOne;
                    else if (Preferencje["ANC New"])
                        PNCRow["ANC New"] = PNCOne;

                    string[] CalcPNC = Calc[CounterPNC].Split(':');
                    if (Preferencje["Old STK"])
                        PNCRow["Old STK"] = CalcPNC[0];
                    if(Preferencje["New STK"])
                        PNCRow["New STK"] = CalcPNC[1];

                    if (Preferencje["Delta"])
                        PNCRow["Delta"] = Delta[CounterPNC];

                    CounterPNC++;

                    if (PerANCUSE.Rows.Count != 0)
                    {
                        DataRow PNCActual = PerANCUSE.Select(string.Format("Name LIKE '%{0}%'", PNCOne)).FirstOrDefault();
                        if (PNCActual != null)
                        {
                            for (int counter2 = Start; counter2 <= Finish; counter2++)
                            {
                                string[] Help = PNCActual[counter2.ToString()].ToString().Split(':');

                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        PNCRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString());
                                    if (Preferencje["Savings"])
                                        PNCRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString());
                                }
                            }
                        }
                    }
                    if (!Preferencje["Actual"])
                    {
                        DataRow PNCRew = PerANCRew.Select(string.Format("Name LIKE '%{0}%'", PNCOne)).FirstOrDefault();
                        if (PNCRew != null)
                        {
                            for (int counter2 = RevStart; counter2 <= RefFinish; counter2++)
                            {
                                string[] Help = PNCRew[counter2.ToString()].ToString().Split(':');

                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        PNCRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString());
                                    if (Preferencje["Savings"])
                                        PNCRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString());
                                }
                            }
                        }
                    }

                    double sum = 0;
                    if (Preferencje["Quantity"])
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (PNCRow["Q" + counter2.ToString()].ToString() != "")
                                sum += double.Parse(PNCRow["Q" + counter2.ToString()].ToString());
                        }
                        PNCRow["Q13"] = sum;
                        sum = 0;
                    }
                    if (Preferencje["Savings"])
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (PNCRow["S" + counter2.ToString()].ToString() != "")
                                sum += double.Parse(PNCRow["S" + counter2.ToString()].ToString());
                        }
                        PNCRow["S13"] = sum;
                        sum = 0;
                    }
                    Devision.Rows.Add(PNCRow);
                }
            }

        }

        private void AddMaximum(ref DataRow RowtoAdd, DataRow Rewizion, ref DataTable Devision, int MonthEnd, bool CarryOver)
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
            string[] ANCSpec;
            string[] STKSpec;
            string[] DeltaSpec;
            string[] PNC;
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
                RevStart = 0;
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
            ANCSpec = Rewizion["PNC/ANC"].ToString().Split('|');
            STKSpec = Rewizion["PNCSTK"].ToString().Split('|');
            DeltaSpec = Rewizion["PNCDelta"].ToString().Split('|');

            if (YearAction == DateTime.Now.Year)
            {
                if (Monthstart < MonthEnd)
                {
                    Delta = Rewizion["Delta"].ToString().Split('|');
                }
                else
                {
                    Delta = Rewizion["STKCal"].ToString().Split('|');
                }
            }
            else if (YearAction < DateTime.Now.Year)
            {
                Delta = Rewizion["Delta"].ToString().Split('|');
            }
            else
            {
                Delta = Rewizion["STKCal"].ToString().Split('|');
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
                        if(Help[counter-1] != "")
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

                Devision.Rows.Add(NewRow);
            }

            PNC = Rewizion["PNC"].ToString().Split('|');

            foreach (string PNCOne in PNC)
            {
                if (PNCOne != "")
                {
                    DataRow PNCRow = Devision.NewRow();
                    if (Preferencje["ANC Old"])
                        PNCRow["ANC Old"] = PNCOne;
                    else if (Preferencje["ANC New"])
                        PNCRow["ANC New"] = PNCOne;
                    if (PerANCUSE.Rows.Count != 0)
                    {
                        DataRow PNCActual = PerANCUSE.Select(string.Format("Name LIKE '%{0}%'", PNCOne)).First();
                        if (PNCActual != null)
                        {
                            for (int counter2 = Start; counter2 <= Finish; counter2++)
                            {
                                string[] Help = PNCActual[counter2.ToString()].ToString().Split(':');

                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        PNCRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString());
                                    if (Preferencje["Savings"])
                                        PNCRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString());
                                }
                            }
                        }
                    }
                    if (!Preferencje["Actual"])
                    {
                        DataRow PNCRew = PerANCRew.Select(string.Format("Name LIKE '%{0}%'", PNCOne)).First();
                        if (PNCRew != null)
                        {
                            for (int counter2 = RevStart; counter2 <= RefFinish; counter2++)
                            {
                                string[] Help = PNCRew[counter2.ToString()].ToString().Split(':');

                                if (Help[0] != "")
                                {
                                    if (Preferencje["Quantity"])
                                        PNCRow["Q" + counter2.ToString()] = double.Parse(Help[0].ToString());
                                    if (Preferencje["Savings"])
                                        PNCRow["S" + counter2.ToString()] = double.Parse(Help[1].ToString());
                                }
                            }
                        }
                    }
                    double sum = 0;
                    if (Preferencje["Quantity"])
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (PNCRow["Q" + counter2.ToString()].ToString() != "")
                                sum += double.Parse(PNCRow["Q" + counter2.ToString()].ToString());
                        }
                        PNCRow["Q13"] = sum;
                        sum = 0;
                    }
                    if (Preferencje["Savings"])
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (PNCRow["S" + counter2.ToString()].ToString() != "")
                                sum += double.Parse(PNCRow["S" + counter2.ToString()].ToString());
                        }
                        PNCRow["S13"] = sum;
                    }
                    Devision.Rows.Add(PNCRow);

                    string[] ANCSpecHelp = ANCSpec[PNCOne.IndexOf(PNCOne)].ToString().Split('/');
                    string[] STKSpecHelp = STKSpec[PNCOne.IndexOf(PNCOne)].ToString().Split('/');
                    string[] DeltaSpecHelp = DeltaSpec[PNCOne.IndexOf(PNCOne)].ToString().Split('/');
                    for (int counter3 = 0; counter3< ANCSpecHelp.Length-1; counter3++)
                    {
                        string[] ANCSpecHelp2 = ANCSpecHelp[counter3].Split(':');
                        string[] STKSpecHelp2 = STKSpecHelp[counter3].Split(':');
                        
                        DataRow PNCSpecANCRow = Devision.NewRow();
                        if (Preferencje["Old ANC"])
                        {
                            if (Preferencje["ANC Old"])
                                PNCSpecANCRow["ANC Old"] = ANCSpecHelp2[0];

                            if (Preferencje["Old IDCO"])
                                if (IDCOTabela.ContainsKey(ANCSpecHelp2[0].ToString()))
                                    PNCSpecANCRow["Old IDCO"] = IDCOTabela[ANCSpecHelp2[0].ToString()];

                            if (Preferencje["Old STK"])
                                PNCSpecANCRow["Old STK"] = STKSpecHelp2[0];
                        }
                        if (Preferencje["New ANC"])
                        {
                            if (Preferencje["ANC New"])
                                PNCSpecANCRow["ANC New"] = ANCSpecHelp2[1];

                            if (Preferencje["New IDCO"])
                                if (IDCOTabela.ContainsKey(ANCSpecHelp2[1].ToString()))
                                    PNCSpecANCRow["New IDCO"] = IDCOTabela[ANCSpecHelp2[1].ToString()];

                            if (Preferencje["New STK"])
                                PNCSpecANCRow["New STK"] = STKSpecHelp2[1];
                        }
                        if(Preferencje["Delta"])
                        {
                            PNCSpecANCRow["Delta"] = DeltaSpecHelp[counter3];
                        }

                        Devision.Rows.Add(PNCSpecANCRow);
                    }
                }
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
