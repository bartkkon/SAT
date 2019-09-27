using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace Saving_Accelerator_Tool
{
    class MultiRaport
    {
        private readonly Data_Import ImportData;
        private readonly decimal Year;
        private readonly Dictionary<string, bool> Preferencje = new Dictionary<string, bool> { };
        private readonly Dictionary<string, bool> Akcje = new Dictionary<string, bool> { };
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

        public MultiRaport(Data_Import ImportData, Dictionary<string, bool> Akcje, Dictionary<string, bool> Preferencje, decimal Year)
        {
            this.ImportData = ImportData;
            this.Preferencje = Preferencje;
            this.Akcje = Akcje;
            this.Year = Year;
        }

        public void GeneretedMutliRaport()
        {
            Excel.Application Raport;
            Excel.Workbook RaportWorkBook;
            Excel.Worksheet MultiAction;
            Excel.Worksheet MultiSum;
            DataTable ElectronicActual = new DataTable();
            DataTable MechanicActual = new DataTable();
            DataTable NVRActual = new DataTable();
            DataTable ElectronicCarry = new DataTable();
            DataTable MechanicalCarry = new DataTable();
            DataTable NVRCarry = new DataTable();
            DataTable Action = new DataTable();
            DataRow[] ActionRewizion = null;
            DataRow[] ActionMonth = null;
            DataTable ActionM = new DataTable();
            DataTable ActionR = new DataTable();
            DataTable History = new DataTable();
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            string Link;
            int Month = 0;
            string Rew = "";

            Link = ImportData.Load_Link("Frozen");
            ImportData.Load_TxtToDataTable(ref Frozen, Link);
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            Link = ImportData.Load_Link("History");
            ImportData.Load_TxtToDataTable(ref History, Link);

            for (int counter = 12; counter > 1; counter--)
            {
                if (FrozenRow[counter.ToString()].ToString() == "Approve")
                {
                    Month = counter;
                    break;
                }
            }

            if (Month == 0)
            {
                Preferencje["Actual"] = false;
            }
            else
            {
                ActionMonth = History.Select(string.Format("History LIKE '%{0}%'", Month.ToString() + "/" + Year.ToString())).ToArray();
            }

            if (Preferencje["BU"])
            {
                if (FrozenRow["BU"].ToString() == "Approve")
                {
                    Rew = "BU";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "BU/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA1"])
            {
                if (FrozenRow["EA1"].ToString() == "Approve")
                {
                    Rew = "EA1";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA1/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA2"])
            {
                if (FrozenRow["EA2"].ToString() == "Approve")
                {
                    Rew = "EA2";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA2/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA3"])
            {
                if (FrozenRow["EA3"].ToString() == "Approve")
                {
                    Rew = "EA3";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA3/" + Year.ToString())).ToArray();
                }
            }

            if (Month == 0 && Rew == "")
            {
                MessageBox.Show("NO Data avalible for Report");
                return;
            }

            if (Year > DateTime.Now.Year)
            {
                Preferencje["Actual"] = false;
            }

            ActionM = History.Clone();
            ActionR = History.Clone();

            ActionM.Rows.Add(ActionMonth);
            ActionR.Rows.Add(ActionRewizion);

            //Link = ImportData.Load_Link("Action");
            //ImportData.Load_TxtToDataTable(ref Action, Link);

            if (Preferencje["Electronic"] && Preferencje["Current Action"])
            {
                CreateColumn(ref ElectronicActual);
                AddActiontoTable(ref ActionM, ref ActionR, ref ElectronicActual, "Electronic", Year, true, Month);
            }
            if (Preferencje["Mechanic"] && Preferencje["Current Action"])
            {
                CreateColumn(ref MechanicActual);
            }
            if (Preferencje["NVR"] && Preferencje["Current Action"])
            {
                CreateColumn(ref NVRActual);
            }
            if (Preferencje["Electronic"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref ElectronicCarry);
            }
            if (Preferencje["Mechanic"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref MechanicalCarry);
            }
            if (Preferencje["NVR"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref NVRCarry);
            }

            Create_Excel_Application _Application = new Create_Excel_Application();
            Raport = _Application.Create_Application();

            Create_Excel_WorkBooks _WorkBooks = new Create_Excel_WorkBooks();
            RaportWorkBook = _WorkBooks.Create_WorkBooks(Raport);

            if (Preferencje["WS Action"])
            {
                Create_Excel_WorkSheet _WorkSheet = new Create_Excel_WorkSheet();
                MultiAction = _WorkSheet.Create_WorkSheet(RaportWorkBook, "DM " + Year.ToString());
                MultiAction.Application.ActiveWindow.Zoom = 85;
                Excel.Range Cells = MultiAction.Range["A1:ZZ10000"];
                Cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                Cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
                Cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
                Cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;

                MultiActionColumn(MultiAction);
            }
            if (Preferencje["WS Action"])
            {
                Create_Excel_WorkSheet _WorkSheet = new Create_Excel_WorkSheet();
                MultiSum = _WorkSheet.Create_WorkSheet(RaportWorkBook, "Chart PLN");
                MultiSum.Application.ActiveWindow.Zoom = 85;
                MultiSum.Application.ActiveWindow.DisplayGridlines = false;
            }

        }

        //Dodanie akcji do odpowiednich tabel
        private void AddActiontoTable(ref DataTable ActionMonth, ref DataTable ActionRewizion,  ref DataTable Tabela, string Devision, decimal YearToCalc, bool Actual, int Month)
        {
            foreach (KeyValuePair<string, bool> Akcja in Akcje)
            {
                DataRow ActionRow = ActionMonth.NewRow();
                if(Preferencje["Actual"])
                {
                    foreach (DataRow ActionRows in ActionMonth.Rows)
                    {
                        if (ActionRows["Name"].ToString() == Akcja.Key)
                        {
                            ActionRow.ItemArray = ActionRows.ItemArray;
                        }
                    }
                }
                else
                {
                    foreach (DataRow ActionRows in ActionRewizion.Rows)
                    {
                        if (ActionRows["Name"].ToString() == Akcja.Key)
                        {
                            ActionRow.ItemArray = ActionRows.ItemArray;
                        }
                    }
                }
                if(Akcja.Value)
                {
                    if (ActionRow["StartYear"].ToString() == YearToCalc.ToString())
                    {
                        if (Preferencje[Devision] && ActionRow["Group"].ToString() == Devision)
                        {
                            if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                            {
                                if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, false);
                                    }
                                }
                                else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, false);
                                    }
                                }
                            }
                            else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                            {
                                if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, false);
                                    }
                                }
                                else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, false);
                                    }
                                }
                            }
                        }
                    }
                    if (!Actual)
                    {
                        if (ActionRow["StartYear"].ToString() == "BU/" + Year.ToString())
                        {
                            if (Preferencje[Devision] && ActionRow["Group"].ToString() == Devision)
                            {
                                if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, true);
                                        }
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, true);
                                        }
                                    }
                                }
                                else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, true);
                                        }
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref Tabela, "Ongoing", Month, true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        //Dodanie pojedynczej akcji do tabli która jest już zdefiniowana przez wybór użytkownika
        private void CreateRowAction(DataRow ActionRow, ref DataTable ActionMonth, ref DataTable ActionRewizion, ref DataTable FinalActions, string Status, int Month, bool CarryOver)
        {
            if (ActionRow["Calculate"].ToString() == "ANC")
            {
                //ANC_AddAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref FinalActions, Status, Month, CarryOver);

                ANC _ANC = new ANC(ImportData, Preferencje);
            }
            else if (ActionRow["Calculate"].ToString() == "ANCSpec")
            {
                //ANCSpec_AddAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref FinalActions, Status, CarryOver);
            }
            else if (ActionRow["Calculate"].ToString() == "PNC")
            {
                //PNC_AddAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref FinalActions, Status, CarryOver);
            }
            else if (ActionRow["Calculate"].ToString() == "PNCSpec")
            {
                //PNCSpec_AddAction(ActionRow, ref ActionMonth, ref ActionRewizion, ref FinalActions, Status, CarryOver);
            }

        }

        private void ANC_AddAction(DataRow ActionRow, ref DataRow[] ActionMonth, ref DataRow[] ActionRewizion, ref DataTable FinalActions, string Status, int MonthFinishActual, bool CarryOver)
        {
            //DataRow Row = FinalActions.NewRow();
            //DataRow Months = ActionMonth[0];
            //DataRow Rewizion = ActionRewizion[0];
            //bool OneRow = false;

            //if (ActionMonth != null)
            //{
            //    foreach (DataRow Rows in ActionMonth)
            //    {
            //        if (ActionRow["Name"].ToString() == Rows["Name"].ToString())
            //        {
            //            Months.ItemArray = Rows.ItemArray;
            //            break;
            //        }
            //    }
            //}
            //if (ActionRewizion != null)
            //{
            //    foreach (DataRow Rows in ActionRewizion)
            //    {
            //        if (ActionRow["Name"].ToString() == Rows["Name"].ToString())
            //        {
            //            Rewizion.ItemArray = Rows.ItemArray;
            //        }
            //    }
            //}

            //if (ActionRow["IloscANC"].ToString() == "1")
            //    OneRow = true;

            //Row["Name"] = ActionRow["Name"];

            //if (Preferencje["Description"])
            //    Row["Description"] = ActionRow["Description"];

            //if (Preferencje["Status"])
            //    Row["Status"] = Status;

            //if (Preferencje["Platform"])
            //    Row["Platform"] = ActionRow["Platform"];

            //if (Preferencje["Minimum"] || OneRow)
            //{
            //    if (Preferencje["Old ANC"])
            //    {
            //        if (Preferencje["ANC Old"])
            //            Row["ANC Old"] = ActionRow["Old ANC"];

            //        if (Preferencje["Old IDCO"])
            //        { //Dodać IDCO
            //        }

            //        if (Preferencje["Old STK"])
            //            Row["Old STK"] = ActionRow["Old STK"];
            //    }
            //    if (Preferencje["New ANC"])
            //    {
            //        if (Preferencje["ANC New"])
            //            Row["ANC New"] = ActionRow["New ANC"];

            //        if (Preferencje["New IDCO"])
            //        { //Dodać IDCO
            //        }

            //        if (Preferencje["New STK"])
            //            Row["New STK"] = ActionRow["New STK"];
            //    }

            //    if (Preferencje["Delta"])
            //    {
            //        if (decimal.Parse(ActionRow["StartYear"].ToString()) == DateTime.Today.Year)
            //        {
            //            int MonthStart = Month[ActionRow["StartMonth"].ToString()];
            //            if (MonthStart <= DateTime.Today.Month)
            //            {
            //                string[] Help = ActionRow["Delta"].ToString().Split('|');
            //                decimal Delta = 0;
            //                for (int counter = 0; counter < Help.Length - 1; counter++)
            //                {
            //                    Delta = Delta + decimal.Parse(Help[counter]);
            //                }
            //                Row["Delta"] = Delta;
            //            }
            //            else if (MonthStart > DateTime.Today.Month)
            //            {
            //                string[] Help = ActionRow["STKCal"].ToString().Split('|');
            //                decimal Delta = 0;
            //                for (int counter = 0; counter < Help.Length - 1; counter++)
            //                {
            //                    Delta = Delta + decimal.Parse(Help[counter]);
            //                }
            //                Row["Delta"] = Delta;
            //            }
            //        }
            //        else if (decimal.Parse(ActionRow["StartYear"].ToString()) < DateTime.Today.Year)
            //        {
            //            string[] Help = ActionRow["Delta"].ToString().Split('|');
            //            decimal Delta = 0;
            //            for (int counter = 0; counter < Help.Length - 1; counter++)
            //            {
            //                Delta = Delta + decimal.Parse(Help[counter]);
            //            }
            //            Row["Delta"] = Delta;
            //        }
            //        else if (decimal.Parse(ActionRow["StartYear"].ToString()) > DateTime.Today.Year)
            //        {
            //            string[] Help = ActionRow["STKCalc"].ToString().Split('|');
            //            decimal Delta = 0;
            //            for (int counter = 0; counter < Help.Length - 1; counter++)
            //            {
            //                Delta = Delta + decimal.Parse(Help[counter]);
            //            }
            //            Row["Delta"] = Delta;
            //        }
            //    }

            //    if (Preferencje["Quantity"])
            //    {
            //        string[] Help;
            //        string Rewizja = "";
            //        if (Preferencje["Actual"])
            //        {

            //            if (!CarryOver)
            //            {
            //                Help = Months["CalcUSEQuantity"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Months["CalcUSEQuantityCarry"].ToString().Split('/');
            //            }

            //            for (int counter = 1; counter <= MonthFinishActual; counter++)
            //            {
            //                Row["Q" + counter] = Help[counter - 1];
            //            }
            //        }
            //        if (Preferencje["BU"])
            //            Rewizja = "BU";
            //        else if (Preferencje["EA1"])
            //            Rewizja = "EA1";
            //        else if (Preferencje["EA2"])
            //            Rewizja = "EA2";
            //        else if (Preferencje["EA3"])
            //            Rewizja = "EA3";
            //        if (Rewizja != "")
            //        {
            //            if (!CarryOver)
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "Quantity"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "QuantityCarry"].ToString().Split('/');
            //            }

            //            for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //            {
            //                Row["Q" + counter] = Help[counter - 1];
            //            }
            //        }
            //        decimal sum = 0;
            //        for (int counter = 1; counter < 13; counter++)
            //        {
            //            if (Row["Q" + counter.ToString()].ToString() != "")
            //            {
            //                sum = sum + decimal.Parse(Row["Q" + counter.ToString()].ToString());
            //            }
            //        }
            //        Row["Q13"] = sum;
            //    }
            //    if (Preferencje["Savings"])
            //    {
            //        string[] Help;
            //        string Rewizja = "";
            //        if (Preferencje["Actual"])
            //        {

            //            if (!CarryOver)
            //            {
            //                Help = Months["CalcUSESaving"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Months["CalcUSESavingCarry"].ToString().Split('/');
            //            }

            //            for (int counter = 1; counter <= MonthFinishActual; counter++)
            //            {
            //                Row["S" + counter] = Help[counter - 1];
            //            }
            //        }
            //        if (Preferencje["BU"])
            //            Rewizja = "BU";
            //        else if (Preferencje["EA1"])
            //            Rewizja = "EA1";
            //        else if (Preferencje["EA2"])
            //            Rewizja = "EA2";
            //        else if (Preferencje["EA3"])
            //            Rewizja = "EA3";
            //        if (Rewizja != "")
            //        {
            //            if (!CarryOver)
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "Saving"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "SavingCarry"].ToString().Split('/');
            //            }

            //            for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //            {
            //                Row["S" + counter] = Help[counter - 1];
            //            }
            //        }
            //        decimal sum = 0;
            //        for (int counter = 1; counter < 13; counter++)
            //        {
            //            if (Row["S" + counter.ToString()].ToString() != "")
            //            {
            //                sum = sum + decimal.Parse(Row["S" + counter.ToString()].ToString());
            //            }
            //        }
            //        Row["S13"] = sum;
            //    }
            //    if (Preferencje["ECCC"])
            //    {
            //        string[] Help;
            //        string Rewizja = "";
            //        if (Preferencje["Actual"])
            //        {
            //            if (!CarryOver)
            //            {
            //                Help = Months["CalcUSEECCC"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Months["CalcUSEECCCCarry"].ToString().Split('/');
            //            }

            //            for (int counter = 1; counter <= MonthFinishActual; counter++)
            //            {
            //                Row["E" + counter] = Help[counter - 1];
            //            }
            //        }
            //        if (Preferencje["BU"])
            //            Rewizja = "BU";
            //        else if (Preferencje["EA1"])
            //            Rewizja = "EA1";
            //        else if (Preferencje["EA2"])
            //            Rewizja = "EA2";
            //        else if (Preferencje["EA3"])
            //            Rewizja = "EA3";
            //        if (Rewizja != "")
            //        {
            //            if (!CarryOver)
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "ECCC"].ToString().Split('/');
            //            }
            //            else
            //            {
            //                Help = Rewizion["Calc" + Rewizja + "ECCCCarry"].ToString().Split('/');
            //            }

            //            for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //            {
            //                Row["E" + counter] = Help[counter - 1];
            //            }
            //        }
            //        decimal sum = 0;
            //        for (int counter = 1; counter < 13; counter++)
            //        {
            //            if (Row["E" + counter.ToString()].ToString() != "")
            //            {
            //                sum = sum + decimal.Parse(Row["E" + counter.ToString()].ToString());
            //            }
            //        }
            //        Row["E13"] = sum;
            //    }
            //    FinalActions.Rows.Add(Row);
            //}
            //else if (Preferencje["Medium"] || Preferencje["Maximum"])
            //{
            //    DataTable ANCMonths = new DataTable();
            //    DataTable ANCRewizion = new DataTable();
            //    string Link;
            //    int IloscANC = int.Parse(ActionRow["IloscANC"].ToString());

            //    Link = ImportData.Load_Link("ANCMonth");
            //    ImportData.Load_TxtToDataTable(ref ANCMonths, Link);
            //    Link = ImportData.Load_Link("ANC");
            //    ImportData.Load_TxtToDataTable(ref ANCRewizion, Link);

            //    FinalActions.Rows.Add(Row);

            //    string[] OLDANC;
            //    string[] NEWANC;
            //    string[] OLDSTK;
            //    string[] NEWSTK;
            //    string[] Delta;

            //    if (Preferencje["Actual"])
            //    {
            //        OLDANC = Month["Old ANC"].ToString().Split('|');
            //        NEWANC = Month["New ANC"].ToString().Split('|');
            //        OLDSTK = Month["Old STK"].ToString().Split('|');
            //        NEWSTK = Month["New STK"].ToString().Split('|');
            //        Delta = Month["Delta"].ToString().Split('|');
            //    }
            //    else
            //    {
            //        OLDANC = Rewizion["Old ANC"].ToString().Split('|');
            //        NEWANC = Rewizion["New ANC"].ToString().Split('|');
            //        OLDSTK = Rewizion["Old STK"].ToString().Split('|');
            //        NEWSTK = Rewizion["New STK"].ToString().Split('|');
            //        Delta = Rewizion["STKCal"].ToString().Split('|');
            //    }


            //    for (int counter = 0; counter < IloscANC; counter++)
            //    {
            //        DataRow RowSmall = FinalActions.NewRow();
            //        if (Preferencje["Old ANC"])
            //        {
            //            if (Preferencje["ANC Old"])
            //                RowSmall["ANC Old"] = OLDANC[counter];

            //            if (Preferencje["Old IDCO"])
            //            { //Dodać IDCO
            //            }

            //            if (Preferencje["Old STK"])
            //                RowSmall["Old STK"] = OLDSTK[counter];
            //        }

            //        if (Preferencje["New ANC"])
            //        {
            //            if (Preferencje["ANC New"])
            //                RowSmall["ANC New"] = NEWANC[counter];

            //            if (Preferencje["New IDCO"])
            //            { //Dodać IDCO
            //            }

            //            if (Preferencje["New STK"])
            //                RowSmall["New STK"] = NEWSTK[counter];
            //        }

            //        if (Preferencje["Delta"])
            //        {
            //            RowSmall["Delta"] = Delta[counter];
            //        }

            //        if(Preferencje["Quantity"])
            //        {
            //            DataRow ANCMonthQuantity;
            //            DataRow ANCRewisionQuantity;

            //            ANCMonthQuantity = ANCMonths.Select(string.Format("ANC LIKE '%{0}%'", NEWANC[counter])).First();
            //            ANCRewisionQuantity = ANCRewizion.Select(string.Format("BUANC LIKE '%{0}%'", OLDANC[counter])).First();

            //            for(int counter2 = 1; counter2<MonthFinishActual; counter2++)
            //            {

            //            }
            //        }
            //    }

            //    if (Preferencje["Minimum"])
            //    {
            //        if (Preferencje["Old ANC"])
            //        {
            //            if (Preferencje["ANC Old"])
            //                Row["ANC Old"] = ActionRow["Old ANC"];

            //            if (Preferencje["Old IDCO"])
            //            { //Dodać IDCO
            //            }

            //            if (Preferencje["Old STK"])
            //                Row["Old STK"] = ActionRow["Old STK"];
            //        }
            //        if (Preferencje["New ANC"])
            //        {
            //            if (Preferencje["ANC New"])
            //                Row["ANC New"] = ActionRow["New ANC"];

            //            if (Preferencje["New IDCO"])
            //            { //Dodać IDCO
            //            }

            //            if (Preferencje["New STK"])
            //                Row["New STK"] = ActionRow["New STK"];
            //        }

            //        if (Preferencje["Delta"])
            //        {
            //            if (decimal.Parse(ActionRow["StartYear"].ToString()) == DateTime.Today.Year)
            //            {
            //                int MonthStart = Month[ActionRow["StartMonth"].ToString()];
            //                if (MonthStart <= DateTime.Today.Month)
            //                {
            //                    string[] Help = ActionRow["Delta"].ToString().Split('|');
            //                    decimal Delta = 0;
            //                    for (int counter = 0; counter < Help.Length - 1; counter++)
            //                    {
            //                        Delta = Delta + decimal.Parse(Help[counter]);
            //                    }
            //                    Row["Delta"] = Delta;
            //                }
            //                else if (MonthStart > DateTime.Today.Month)
            //                {
            //                    string[] Help = ActionRow["STKCal"].ToString().Split('|');
            //                    decimal Delta = 0;
            //                    for (int counter = 0; counter < Help.Length - 1; counter++)
            //                    {
            //                        Delta = Delta + decimal.Parse(Help[counter]);
            //                    }
            //                    Row["Delta"] = Delta;
            //                }
            //            }
            //            else if (decimal.Parse(ActionRow["StartYear"].ToString()) < DateTime.Today.Year)
            //            {
            //                string[] Help = ActionRow["Delta"].ToString().Split('|');
            //                decimal Delta = 0;
            //                for (int counter = 0; counter < Help.Length - 1; counter++)
            //                {
            //                    Delta = Delta + decimal.Parse(Help[counter]);
            //                }
            //                Row["Delta"] = Delta;
            //            }
            //            else if (decimal.Parse(ActionRow["StartYear"].ToString()) > DateTime.Today.Year)
            //            {
            //                string[] Help = ActionRow["STKCalc"].ToString().Split('|');
            //                decimal Delta = 0;
            //                for (int counter = 0; counter < Help.Length - 1; counter++)
            //                {
            //                    Delta = Delta + decimal.Parse(Help[counter]);
            //                }
            //                Row["Delta"] = Delta;
            //            }
            //        }

            //        if (Preferencje["Quantity"])
            //        {
            //            string[] Help;
            //            string Rewizja = "";
            //            if (Preferencje["Actual"])
            //            {

            //                if (!CarryOver)
            //                {
            //                    Help = Months["CalcUSEQuantity"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Months["CalcUSEQuantityCarry"].ToString().Split('/');
            //                }

            //                for (int counter = 1; counter <= MonthFinishActual; counter++)
            //                {
            //                    Row["Q" + counter] = Help[counter - 1];
            //                }
            //            }
            //            if (Preferencje["BU"])
            //                Rewizja = "BU";
            //            else if (Preferencje["EA1"])
            //                Rewizja = "EA1";
            //            else if (Preferencje["EA2"])
            //                Rewizja = "EA2";
            //            else if (Preferencje["EA3"])
            //                Rewizja = "EA3";
            //            if (Rewizja != "")
            //            {
            //                if (!CarryOver)
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "Quantity"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "QuantityCarry"].ToString().Split('/');
            //                }

            //                for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //                {
            //                    Row["Q" + counter] = Help[counter - 1];
            //                }
            //            }
            //            decimal sum = 0;
            //            for (int counter = 1; counter < 13; counter++)
            //            {
            //                if (Row["Q" + counter.ToString()].ToString() != "")
            //                {
            //                    sum = sum + decimal.Parse(Row["Q" + counter.ToString()].ToString());
            //                }
            //            }
            //            Row["Q13"] = sum;
            //        }
            //        if (Preferencje["Savings"])
            //        {
            //            string[] Help;
            //            string Rewizja = "";
            //            if (Preferencje["Actual"])
            //            {

            //                if (!CarryOver)
            //                {
            //                    Help = Months["CalcUSESaving"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Months["CalcUSESavingCarry"].ToString().Split('/');
            //                }

            //                for (int counter = 1; counter <= MonthFinishActual; counter++)
            //                {
            //                    Row["S" + counter] = Help[counter - 1];
            //                }
            //            }
            //            if (Preferencje["BU"])
            //                Rewizja = "BU";
            //            else if (Preferencje["EA1"])
            //                Rewizja = "EA1";
            //            else if (Preferencje["EA2"])
            //                Rewizja = "EA2";
            //            else if (Preferencje["EA3"])
            //                Rewizja = "EA3";
            //            if (Rewizja != "")
            //            {
            //                if (!CarryOver)
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "Saving"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "SavingCarry"].ToString().Split('/');
            //                }

            //                for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //                {
            //                    Row["S" + counter] = Help[counter - 1];
            //                }
            //            }
            //            decimal sum = 0;
            //            for (int counter = 1; counter < 13; counter++)
            //            {
            //                if (Row["S" + counter.ToString()].ToString() != "")
            //                {
            //                    sum = sum + decimal.Parse(Row["S" + counter.ToString()].ToString());
            //                }
            //            }
            //            Row["S13"] = sum;
            //        }
            //        if (Preferencje["ECCC"])
            //        {
            //            string[] Help;
            //            string Rewizja = "";
            //            if (Preferencje["Actual"])
            //            {
            //                if (!CarryOver)
            //                {
            //                    Help = Months["CalcUSEECCC"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Months["CalcUSEECCCCarry"].ToString().Split('/');
            //                }

            //                for (int counter = 1; counter <= MonthFinishActual; counter++)
            //                {
            //                    Row["E" + counter] = Help[counter - 1];
            //                }
            //            }
            //            if (Preferencje["BU"])
            //                Rewizja = "BU";
            //            else if (Preferencje["EA1"])
            //                Rewizja = "EA1";
            //            else if (Preferencje["EA2"])
            //                Rewizja = "EA2";
            //            else if (Preferencje["EA3"])
            //                Rewizja = "EA3";
            //            if (Rewizja != "")
            //            {
            //                if (!CarryOver)
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "ECCC"].ToString().Split('/');
            //                }
            //                else
            //                {
            //                    Help = Rewizion["Calc" + Rewizja + "ECCCCarry"].ToString().Split('/');
            //                }

            //                for (int counter = MonthFinishActual + 1; counter <= 12; counter++)
            //                {
            //                    Row["E" + counter] = Help[counter - 1];
            //                }
            //            }
            //            decimal sum = 0;
            //            for (int counter = 1; counter < 13; counter++)
            //            {
            //                if (Row["E" + counter.ToString()].ToString() != "")
            //                {
            //                    sum = sum + decimal.Parse(Row["E" + counter.ToString()].ToString());
            //                }
            //            }
            //            Row["E13"] = sum;
            //        }
            //        FinalActions.Rows.Add(Row);


            //    }
            //}
        }

        private void ANCSpec_AddAction(DataRow ActionRow, ref DataRow[] ActionMonth, ref DataRow[] ActionRewizion, ref DataTable FinalActions, string Status, bool CarryOver)
        {

        }

        private void PNC_AddAction(DataRow ActionRow, ref DataRow[] ActionMonth, ref DataRow[] ActionRewizion, ref DataTable FinalActions, string Status, bool CarryOver)
        {

        }

        private void PNCSpec_AddAction(DataRow ActionRow, ref DataRow[] ActionMonth, ref DataRow[] ActionRewizion, ref DataTable FinalActions, string Status, bool CarryOver)
        {

        }

        //Tworzenie column do DataTable dla poszczególnych devizji
        private void CreateColumn(ref DataTable Devision)
        {
            Devision.Columns.Add("Name");
            if (Preferencje["Description"])
            {
                Devision.Columns.Add("Description");
            }
            if (Preferencje["Status"])
            {
                Devision.Columns.Add("Status");
            }
            if (Preferencje["Platform"])
            {
                Devision.Columns.Add("Platform");
            }
            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                {
                    Devision.Columns.Add("ANC Old");
                }
                if (Preferencje["Old IDCO"])
                {
                    Devision.Columns.Add("Old IDCO");
                }
                if (Preferencje["Old STK"])
                {
                    Devision.Columns.Add("Old STK");
                }
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                {
                    Devision.Columns.Add("ANC New");
                }
                if (Preferencje["New IDCO"])
                {
                    Devision.Columns.Add("New IDCO");
                }
                if (Preferencje["New STK"])
                {
                    Devision.Columns.Add("New STK");
                }
            }
            if (Preferencje["Delta"])
            {
                Devision.Columns.Add("Delta");
            }

            if (Preferencje["Quantity"])
            {
                Devision.Columns.Add("Empty1");
                Devision.Columns.Add("Empty2");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("Q" + counter.ToString());
                }
            }

            if (Preferencje["Savings"])
            {
                Devision.Columns.Add("Empty3");
                Devision.Columns.Add("Empty4");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("S" + counter.ToString());
                }
            }

            if (Preferencje["ECCC"])
            {
                Devision.Columns.Add("Empty5");
                Devision.Columns.Add("Empty6");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("E" + counter.ToString());
                }
            }
        }

        //Ustawianie szerokości kolumn w Worksheet z akcjami 
        private void MultiActionColumn(Excel.Worksheet MultiAction)
        {
            int Column = 3;
            MultiAction.Columns[1].ColumnWidth = 4.88;
            MultiAction.Columns[2].ColumnWidth = 52.38;

            if (Preferencje["Description"])
            {
                MultiAction.Columns[Column].ColumnWidth = 43.75;
                Column++;
            }
            if (Preferencje["Status"])
            {
                MultiAction.Columns[Column].ColumnWidth = 10.88;
                Column++;
            }
            if (Preferencje["Platform"])
            {
                MultiAction.Columns[Column].ColumnWidth = 8.88;
                Column++;
            }
            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    Column++;
                }
                if (Preferencje["Old IDCO"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    Column++;
                }
                if (Preferencje["Old STK"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.75;
                    Column++;
                }
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    Column++;
                }
                if (Preferencje["New IDCO"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    Column++;
                }
                if (Preferencje["New STK"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.75;
                    Column++;
                }
            }
            if (Preferencje["Delta"])
            {
                MultiAction.Columns[Column].ColumnWidth = 8.75;
                Column++;
            }

            if (Preferencje["Quantity"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.25;
                    Column++;
                }
            }

            if (Preferencje["Savings"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.25;
                    Column++;
                }
            }

            if (Preferencje["ECCC"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.25;
                    Column++;
                }
            }
        }
    }
}
