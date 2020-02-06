using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class CalculationMass
    {
        private readonly Dictionary<string, int> RevisionStartMonth = new Dictionary<string, int>()
        {
            {"USE", 0},
            {"BU" , 1},
            {"EA1" , 3},
            {"EA2" , 6},
            {"EA3" , 9},
        };
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

        private readonly decimal _Year;

        public CalculationMass(string Revision, decimal Year)
        {
            _Year = Year;

            MassCalculation(Revision, 0);
        }

        public CalculationMass(int Month, decimal Year)
        {
            _Year = Year;
            MassCalculation("USE", Month);
        }

        private void MassCalculation(string Revision, int MonthCalc)
        {
            DataTable ActionList;
            DataTable ANCQ;
            DataTable PNCQ;
            DataTable ECCCQ;

            ActionList = LoadActionTable();

            if (Revision == "USE") // ładuje Zużycie
            {
                ANCQ = LoadTable(false, "ANC");
                PNCQ = LoadTable(false, "PNC");
                ECCCQ = LoadTable(false, "ECCC");
            }
            else //ładuje forcast
            {
                ANCQ = LoadTable(true, "ANC");
                PNCQ = LoadTable(true, "PNC");
                ECCCQ = LoadTable(true, "ECCC");
            }

            foreach (DataRow ActionRow in ActionList.Rows)
            {
                if (ActionRow["StartYear"].ToString() == _Year.ToString() && ActionRow["Status"].ToString() == "Active")
                {
                    int RevStart = RevisionStartMonth[Revision];
                    int MonthStart = Month[ActionRow["StartMonth"].ToString()];
                    int RevFinish = 12;
                    bool Estymation = false;
                    string Calcby = ActionRow["Calculate"].ToString();

                    if (Revision == "USE")
                    {
                        if (MonthCalc >= MonthStart)
                        {
                            RevStart = MonthCalc;
                            RevFinish = MonthCalc;
                        }
                        else
                        {
                            RevStart = MonthCalc;
                            RevFinish = 0;
                        }
                    }
                    else
                    {
                        if (MonthStart >= RevStart)
                        {
                            RevStart = MonthStart;
                            Estymation = true;
                        }
                        else
                        {
                            Estymation = false;
                        }
                    }

                    if (Calcby == "ANC")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = ANC(ActionRow, Revision, Estymation, RevStart, "", ref ANCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "ANCSpec")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = ANCSpec(ActionRow, Revision, Estymation, RevStart, "", ref ANCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "PNC")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = PNC(ActionRow, Revision, Estymation, RevStart, "", ref PNCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "PNCSpec")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = PNCSpec(ActionRow, Revision, Estymation, RevStart, "", ref PNCQ, ref ECCCQ).ItemArray;
                        }
                        //}
                    }
                }
                if (ActionRow["StartYear"].ToString() == (_Year - 1).ToString() && ActionRow["Status"].ToString() == "Active")
                {
                    int RevStart = RevisionStartMonth[Revision];
                    int MonthStart = Month[ActionRow["StartMonth"].ToString()];
                    int RevFinish = 12;
                    //bool IfCalc = false;
                    bool Estymation = false;
                    string Calcby = ActionRow["Calculate"].ToString();

                    if (Revision == "USE")
                    {
                        if (MonthCalc < MonthStart)
                        {
                            RevStart = MonthCalc;
                            RevFinish = MonthCalc;
                        }
                        else
                        {
                            RevStart = 13;
                        }
                    }
                    else
                    {
                        if ((MonthStart - 1) < RevFinish)
                        {
                            RevFinish = MonthStart - 1;
                        }
                        if ((MonthStart - 1) < RevStart)
                        {
                            RevFinish = 0;
                        }

                        if (_Year - 1 == DateTime.Now.Year)
                        {
                            if (MonthStart >= DateTime.Now.Month)
                                Estymation = true;
                            else
                                Estymation = false;
                        }
                    }


                    if (Calcby == "ANC")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = ANC(ActionRow, Revision, Estymation, RevStart, "Carry", ref ANCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "ANCSpec")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = ANCSpec(ActionRow, Revision, Estymation, RevStart, "Carry", ref ANCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "PNC")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = PNC(ActionRow, Revision, Estymation, RevStart, "Carry", ref PNCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    else if (Calcby == "PNCSpec")
                    {
                        for (; RevStart <= RevFinish; RevStart++)
                        {
                            ActionRow.ItemArray = PNCSpec(ActionRow, Revision, Estymation, RevStart, "Carry", ref PNCQ, ref ECCCQ).ItemArray;
                        }
                    }
                    //}
                }
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref ActionList, "Action");
        }

        //Funkcje pomocnicze

        private DataTable LoadTable(bool Revision, string What)
        {
            DataTable Table = new DataTable();

            if (What == "ECCC")
            {
                Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "Kurs");
                return Table;
            }
            else if (Revision)
            {
                if (What == "ANC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "ANC");
                    return Table;
                }
                else if (What == "PNC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "PNC");
                    return Table;
                }

            }
            else
            {
                if (What == "ANC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "ANCMonth");
                    return Table;
                }
                else if (What == "PNC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Table, "PNCMonth");
                    return Table;
                }
            }
            return Table;
        }

        private DataTable LoadActionTable()
        {
            DataTable ActionTable = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref ActionTable, "Action");

            return ActionTable;
        }

        private DataTable LoadTableWithQuantityPerANC_PNC(DataRow Action, string Rewizion, string Carry)
        {
            DataTable QuantityPerANC_PNC = new DataTable();
            string[] Help;

            LoadTableWithQuantityPerANC_PNC_Columns(ref QuantityPerANC_PNC, Rewizion);

            Help = Action["Per" + Rewizion + Carry].ToString().Split('/');
            foreach (string Help2 in Help)
            {
                if (Help2 != "")
                {
                    DataRow NewRow = QuantityPerANC_PNC.NewRow();
                    string[] Help3 = Help2.Split('|');
                    for (int counter = 0; counter < Help3.Length - 1; counter++)
                    {
                        NewRow[counter] = Help3[counter];
                    }
                    QuantityPerANC_PNC.Rows.Add(NewRow);
                }
            }


            return QuantityPerANC_PNC;
        }

        private void LoadTableWithQuantityPerANC_PNC_Columns(ref DataTable dataTable, string Rewizion)
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

            if (Rewizion == "USE")
            {
                dataTable.Columns.Add(Name);
                dataTable.Columns.Add(M1);
                dataTable.Columns.Add(M2);
                dataTable.Columns.Add(M3);
                dataTable.Columns.Add(M4);
                dataTable.Columns.Add(M5);
                dataTable.Columns.Add(M6);
                dataTable.Columns.Add(M7);
                dataTable.Columns.Add(M8);
                dataTable.Columns.Add(M9);
                dataTable.Columns.Add(M10);
                dataTable.Columns.Add(M11);
                dataTable.Columns.Add(M12);
            }
            else if (Rewizion == "BU")
            {
                dataTable.Columns.Add(Name);
                dataTable.Columns.Add(M1);
                dataTable.Columns.Add(M2);
                dataTable.Columns.Add(M3);
                dataTable.Columns.Add(M4);
                dataTable.Columns.Add(M5);
                dataTable.Columns.Add(M6);
                dataTable.Columns.Add(M7);
                dataTable.Columns.Add(M8);
                dataTable.Columns.Add(M9);
                dataTable.Columns.Add(M10);
                dataTable.Columns.Add(M11);
                dataTable.Columns.Add(M12);
            }
            else if (Rewizion == "EA1")
            {
                dataTable.Columns.Add(Name);
                dataTable.Columns.Add(M3);
                dataTable.Columns.Add(M4);
                dataTable.Columns.Add(M5);
                dataTable.Columns.Add(M6);
                dataTable.Columns.Add(M7);
                dataTable.Columns.Add(M8);
                dataTable.Columns.Add(M9);
                dataTable.Columns.Add(M10);
                dataTable.Columns.Add(M11);
                dataTable.Columns.Add(M12);
            }
            else if (Rewizion == "EA2")
            {
                dataTable.Columns.Add(Name);
                dataTable.Columns.Add(M6);
                dataTable.Columns.Add(M7);
                dataTable.Columns.Add(M8);
                dataTable.Columns.Add(M9);
                dataTable.Columns.Add(M10);
                dataTable.Columns.Add(M11);
                dataTable.Columns.Add(M12);
            }
            else if (Rewizion == "EA3")
            {
                dataTable.Columns.Add(Name);
                dataTable.Columns.Add(M9);
                dataTable.Columns.Add(M10);
                dataTable.Columns.Add(M11);
                dataTable.Columns.Add(M12);
            }
        }

        private DataTable AddValueToPerANC_PNC(DataTable QuantityPerANC, string ANC, decimal Quantity, decimal Savings, int Month)
        {
            DataRow Row = null;

            if (ANC != "")
                Row = QuantityPerANC.Select(string.Format("Name LIKE '%{0}%'", ANC)).FirstOrDefault();


            if (Row != null)
            {
                Row[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Savings, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                Row = QuantityPerANC.NewRow();
                Row["Name"] = ANC;
                Row[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Savings, 4, MidpointRounding.AwayFromZero);
                QuantityPerANC.Rows.Add(Row);
            }

            return QuantityPerANC;
        }

        private string SaveTablePerANC_PNC(DataTable QuantityPerANC)
        {
            string Results = "";
            if (QuantityPerANC != null)
            {
                foreach (DataRow Row in QuantityPerANC.Rows)
                {
                    for (int counter = 0; counter < QuantityPerANC.Columns.Count; counter++)
                    {
                        Results = Results + Row[counter].ToString() + "|";
                    }
                    Results += "/";
                }
            }

            return Results;
        }

        private DataRow ANC(DataRow ActionRow, string Revision, bool Estymacja, int Month, string Carry, ref DataTable ANC, ref DataTable ECCCCost)
        {
            string[] ANCCalc;
            string[] Delta;
            string[] Next;
            string[] QuantityTable;
            string[] SavingTable;
            string[] ECCCTable;
            decimal PercentQuantity;
            decimal Quantity = 0;
            decimal QuantityNext = 0;
            decimal Saving;
            //decimal SavingNext = 0;
            decimal ECCC;
            decimal ECCCSek = 0;
            decimal ECCCSekCost = 0;
            decimal QuantitySum = 0;
            decimal SavingSum = 0;
            decimal ECCCSum = 0;
            bool ECCCCalc = false;
            DataRow QuantityBase;
            DataRow QuantityBaseNext;
            DataTable QuantityPerANC;

            QuantityPerANC = LoadTableWithQuantityPerANC_PNC(ActionRow, Revision, Carry);
            ClearColumnPer(ref QuantityPerANC, Month);

            if (Estymacja)
            {
                ANCCalc = ActionRow["Old ANC"].ToString().Split('|');
                Delta = ActionRow["STKCal"].ToString().Split('|');
                PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
                Next = ActionRow["Next"].ToString().Split('|');
            }
            else
            {
                ANCCalc = ActionRow["New ANC"].ToString().Split('|');
                Delta = ActionRow["Delta"].ToString().Split('|');
                if (Revision == "USE")
                    PercentQuantity = 1;
                else
                    PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
                Next = ActionRow["Next"].ToString().Split('|');
            }

            if (ActionRow["ECCC"].ToString() != "")
            {
                ECCCCalc = true;
                ECCCSek = decimal.Parse(ActionRow["ECCC"].ToString());
                if (Carry == "")
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
                else
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", (_Year - 1).ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
            }

            QuantityTable = ActionRow["Calc" + Revision + "Quantity" + Carry].ToString().Split('/');
            SavingTable = ActionRow["Calc" + Revision + "Saving" + Carry].ToString().Split('/');
            ECCCTable = ActionRow["Calc" + Revision + "ECCC" + Carry].ToString().Split('/');



            for (int counter = 0; counter < ANCCalc.Length - 1; counter++)
            {
                if (Revision != "USE")
                {

                    QuantityBase = ANC.Select(string.Format("BUANC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString());
                        }
                    }

                    Quantity *= PercentQuantity;
                    Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                    QuantitySum += Quantity;
                    Saving = decimal.Parse(Delta[counter].ToString()) * Quantity;
                    Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                    SavingSum += Saving;

                    if (ECCCCalc)
                    {
                        ECCC = Quantity * ECCCSek * ECCCSekCost;
                        ECCCSum += ECCC;
                    }

                    QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                }
                else
                {
                    QuantityBase = ANC.Select(string.Format("ANC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Month + "/" + _Year.ToString()].ToString());
                        }
                    }

                    if (Next[counter].ToString() != "")
                    {
                        QuantityBaseNext = ANC.Select(string.Format("ANC LIKE '%{0}%'", Next[counter].ToString())).FirstOrDefault();

                        if (QuantityBaseNext != null)
                        {
                            if (QuantityBaseNext[Month + "/" + _Year.ToString()].ToString() != "")
                            {
                                QuantityNext = decimal.Parse(QuantityBaseNext[Month + "/" + _Year.ToString()].ToString());
                            }
                        }
                    }
                    Quantity += QuantityNext;
                    Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                    Quantity *= PercentQuantity;
                    QuantitySum += Quantity;
                    Saving = decimal.Parse(Delta[counter].ToString()) * Quantity;
                    Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                    SavingSum += Saving;

                    if (ECCCCalc)
                    {
                        ECCC = Quantity * ECCCSek * ECCCSekCost;
                        ECCCSum += ECCC;
                    }

                    QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                }
                QuantityNext = 0;
                Quantity = 0;
            }

            QuantitySum = Math.Round(QuantitySum, MidpointRounding.AwayFromZero);
            SavingSum = Math.Round(SavingSum, MidpointRounding.AwayFromZero);
            ECCCSum = Math.Round(ECCCSum, MidpointRounding.AwayFromZero);

            QuantityTable[Month - 1] = QuantitySum.ToString();
            SavingTable[Month - 1] = SavingSum.ToString();
            if (ECCCSum != 0)
            {
                ECCCTable[Month - 1] = ECCCSum.ToString();
            }
            else
            {
                ECCCTable[Month - 1] = "";
            }

            SumRow(ref QuantityTable);
            SumRow(ref SavingTable);
            SumRow(ref ECCCTable);
            ActionRow["Calc" + Revision + "Quantity" + Carry] = ReturnValue(QuantityTable);
            ActionRow["Calc" + Revision + "Saving" + Carry] = ReturnValue(SavingTable);
            ActionRow["Calc" + Revision + "ECCC" + Carry] = ReturnValue(ECCCTable);
            ActionRow["Per" + Revision + Carry] = SaveTablePerANC_PNC(QuantityPerANC);

            return ActionRow;
        }

        private DataRow ANCSpec(DataRow ActionRow, string Revision, bool Estymacja, int Month, string Carry, ref DataTable ANC, ref DataTable ECCCCost)
        {
            string[] ANCCalc;
            string[] Delta;
            string[] Next;
            string[] QuantityTable;
            string[] SavingTable;
            string[] ECCCTable;
            string[] CalcBy;
            decimal PercentQuantity;
            decimal Quantity = 0;
            decimal DeltaSum = 0;
            decimal Saving;
            decimal ECCC;
            decimal ECCCSek = 0;
            decimal ECCCSekCost = 0;
            decimal QuantitySum = 0;
            decimal SavingSum = 0;
            decimal ECCCSum = 0;
            bool ECCCCalc = false;
            bool Mass = true;
            DataRow QuantityBase;
            DataTable QuantityPerANC;
            DataTable QuantityMass;

            QuantityPerANC = LoadTableWithQuantityPerANC_PNC(ActionRow, Revision, Carry);
            ClearColumnPer(ref QuantityPerANC, Month);
            QuantityMass = LoadQuantityACNSpecMass(Revision, _Year);

            if (Estymacja)
            {
                ANCCalc = ActionRow["Old ANC"].ToString().Split('|');
                Delta = ActionRow["STKCal"].ToString().Split('|');
                PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
                Next = ActionRow["Next"].ToString().Split('|');
            }
            else
            {
                ANCCalc = ActionRow["New ANC"].ToString().Split('|');
                Delta = ActionRow["Delta"].ToString().Split('|');
                if (Revision == "USE")
                    PercentQuantity = 1;
                else
                    PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
                Next = ActionRow["Next"].ToString().Split('|');
            }

            if (ActionRow["ECCC"].ToString() != "")
            {
                ECCCCalc = true;
                ECCCSek = decimal.Parse(ActionRow["ECCC"].ToString());
                if (Carry == "")
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
                else
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", (_Year - 1).ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
            }

            QuantityTable = ActionRow["Calc" + Revision + "Quantity" + Carry].ToString().Split('/');
            SavingTable = ActionRow["Calc" + Revision + "Saving" + Carry].ToString().Split('/');
            ECCCTable = ActionRow["Calc" + Revision + "ECCC" + Carry].ToString().Split('/');

            for (int counter = 0; counter < Delta.Length; counter++)
            {
                if (Delta[counter].ToString() != "")
                    DeltaSum += decimal.Parse(Delta[counter].ToString());
            }

            CalcBy = ActionRow["Calc"].ToString().Split('|');

            for (int counter = 0; counter < CalcBy.Length - 1; counter++)
            {
                if (CalcBy[counter].ToString() == "true")
                {
                    Mass = false;
                    if (Revision != "USE")
                    {
                        QuantityBase = ANC.Select(string.Format("BUANC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();
                        if (QuantityBase != null)
                        {
                            if (QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString() != "")
                                Quantity = decimal.Parse(QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString()) * PercentQuantity;
                        }

                        if (ECCCCalc)
                        {
                            ECCC = Quantity * ECCCSek * ECCCSekCost;
                            ECCCSum += ECCC;
                        }
                        Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                        QuantitySum += Quantity;
                        Saving = Quantity * DeltaSum;
                        Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                        SavingSum += Saving;
                        QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                    }
                    else
                    {
                        QuantityBase = ANC.Select(string.Format("ANC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();
                        if (QuantityBase != null)
                        {
                            if (QuantityBase[Month + "/" + _Year.ToString()].ToString() != "")
                                Quantity = decimal.Parse(QuantityBase[Month + "/" + _Year.ToString()].ToString()) * PercentQuantity;
                        }

                        QuantityBase = ANC.Select(string.Format("ANC LIKE '%{0}%'", Next[counter].ToString())).FirstOrDefault();
                        if (QuantityBase != null)
                        {
                            if (QuantityBase[Month + "/" + _Year.ToString()].ToString() != "")
                                Quantity += (decimal.Parse(QuantityBase[Month + "/" + _Year.ToString()].ToString()) * PercentQuantity);
                        }

                        if (ECCCCalc)
                        {
                            ECCC = Quantity * ECCCSek * ECCCSekCost;
                            ECCCSum += ECCC;
                        }

                        Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                        QuantitySum += Quantity;
                        Saving = Quantity * DeltaSum;
                        Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                        SavingSum += Saving;

                        QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                    }
                    Quantity = 0;
                }
            }
            if (Mass)
            {
                string[] CalcMass = ActionRow["CalcMass"].ToString().Split('/');

                foreach (string CalcMassOne in CalcMass)
                {
                    if (CalcMassOne != "")
                    {
                        QuantityBase = QuantityMass.Select(string.Format("PNC Like '%{0}%'", CalcMassOne)).First();
                        if (Revision == "USE")
                        {
                            Quantity = decimal.Parse(QuantityBase[Month.ToString() + "/" + _Year.ToString()].ToString()) * PercentQuantity;
                        }
                        else
                        {
                            Quantity = decimal.Parse(QuantityBase[Revision.ToString() + "/" + Month.ToString() + "/" + _Year.ToString()].ToString()) * PercentQuantity;
                        }
                        Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                        QuantitySum += Quantity;
                        Saving = Quantity * DeltaSum;
                        Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                        SavingSum += Saving;

                        if (ECCCCalc)
                        {
                            ECCC = Quantity * ECCCSek * ECCCSekCost;
                            ECCCSum += ECCC;
                        }

                        QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, CalcMassOne, Quantity, Saving, Month);
                    }
                    Quantity = 0;
                    Saving = 0;
                }
            }


            QuantitySum = Math.Round(QuantitySum, MidpointRounding.AwayFromZero);
            SavingSum = Math.Round(SavingSum, MidpointRounding.AwayFromZero);
            ECCCSum = Math.Round(ECCCSum, MidpointRounding.AwayFromZero);

            QuantityTable[Month - 1] = QuantitySum.ToString();
            SavingTable[Month - 1] = SavingSum.ToString();
            if (ECCCSum != 0)
            {
                ECCCTable[Month - 1] = ECCCSum.ToString();
            }
            else
            {
                ECCCTable[Month - 1] = "";
            }

            SumRow(ref QuantityTable);
            SumRow(ref SavingTable);
            SumRow(ref ECCCTable);

            ActionRow["Calc" + Revision + "Quantity" + Carry] = ReturnValue(QuantityTable);
            ActionRow["Calc" + Revision + "Saving" + Carry] = ReturnValue(SavingTable);
            ActionRow["Calc" + Revision + "ECCC" + Carry] = ReturnValue(ECCCTable);
            ActionRow["Per" + Revision + Carry] = SaveTablePerANC_PNC(QuantityPerANC);

            return ActionRow;
        }

        private DataRow PNC(DataRow ActionRow, string Revision, bool Estymacja, int Month, string Carry, ref DataTable ANC, ref DataTable ECCCCost)
        {
            string[] ANCCalc;
            string[] Delta;
            string[] QuantityTable;
            string[] SavingTable;
            string[] ECCCTable;
            string[] CalcBy;
            decimal PercentQuantity;
            decimal Quantity;
            decimal Saving;
            decimal DeltaSum = 0;
            decimal ECCC;
            decimal ECCCSek = 0;
            decimal ECCCSekCost = 0;
            decimal QuantitySum = 0;
            decimal SavingSum = 0;
            decimal ECCCSum = 0;
            bool ECCCCalc = false;
            DataRow QuantityBase;
            DataTable QuantityPerANC;

            QuantityPerANC = LoadTableWithQuantityPerANC_PNC(ActionRow, Revision, Carry);
            ClearColumnPer(ref QuantityPerANC, Month);

            if (Estymacja)
            {
                ANCCalc = ActionRow["PNC"].ToString().Split('|');
                Delta = ActionRow["STKCal"].ToString().Split('|');
                PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
            }
            else
            {
                ANCCalc = ActionRow["PNC"].ToString().Split('|');
                Delta = ActionRow["Delta"].ToString().Split('|');
                if (Revision == "USE")
                    PercentQuantity = 1;
                else
                    PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
            }

            if (ActionRow["ECCC"].ToString() != "")
            {
                ECCCCalc = true;
                ECCCSek = decimal.Parse(ActionRow["ECCC"].ToString());
                if (Carry == "")
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
                else
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", (_Year - 1).ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
            }

            QuantityTable = ActionRow["Calc" + Revision + "Quantity" + Carry].ToString().Split('/');
            SavingTable = ActionRow["Calc" + Revision + "Saving" + Carry].ToString().Split('/');
            ECCCTable = ActionRow["Calc" + Revision + "ECCC" + Carry].ToString().Split('/');

            for (int counter = 0; counter < Delta.Length; counter++)
            {
                if (Delta[counter].ToString() != "")
                    DeltaSum += decimal.Parse(Delta[counter].ToString());
            }

            CalcBy = ActionRow["PNC"].ToString().Split('|');
            for (int counter = 0; counter < CalcBy.Length - 1; counter++)
            {
                if (Revision != "USE")
                {
                    QuantityBase = ANC.Select(string.Format("BUPNC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString());
                            Quantity *= PercentQuantity;
                            Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                            QuantitySum += Quantity;
                            Saving = Quantity * DeltaSum;
                            Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                            SavingSum += Saving;

                            if (ECCCCalc)
                            {
                                ECCC = Quantity * ECCCSek * ECCCSekCost;
                                ECCCSum += ECCC;
                            }

                            QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                        }
                    }
                }
                else
                {
                    QuantityBase = ANC.Select(string.Format("PNC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Month + "/" + _Year.ToString()].ToString());
                            Quantity *= PercentQuantity;
                            Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                            QuantitySum += Quantity;
                            Saving = Quantity * DeltaSum;
                            Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                            SavingSum += Saving;

                            if (ECCCCalc)
                            {
                                ECCC = Quantity * ECCCSek * ECCCSekCost;
                                ECCCSum += ECCC;
                            }

                            QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                        }
                    }
                }
            }

            QuantitySum = Math.Round(QuantitySum, MidpointRounding.AwayFromZero);
            SavingSum = Math.Round(SavingSum, MidpointRounding.AwayFromZero);
            ECCCSum = Math.Round(ECCCSum, MidpointRounding.AwayFromZero);

            QuantityTable[Month - 1] = QuantitySum.ToString();
            SavingTable[Month - 1] = SavingSum.ToString();
            if (ECCCSum != 0)
            {
                ECCCTable[Month - 1] = ECCCSum.ToString();
            }
            else
            {
                ECCCTable[Month - 1] = "";
            }

            SumRow(ref QuantityTable);
            SumRow(ref SavingTable);
            SumRow(ref ECCCTable);

            ActionRow["Calc" + Revision + "Quantity" + Carry] = ReturnValue(QuantityTable);
            ActionRow["Calc" + Revision + "Saving" + Carry] = ReturnValue(SavingTable);
            ActionRow["Calc" + Revision + "ECCC" + Carry] = ReturnValue(ECCCTable);
            ActionRow["Per" + Revision + Carry] = SaveTablePerANC_PNC(QuantityPerANC);

            return ActionRow;
        }

        private DataRow PNCSpec(DataRow ActionRow, string Revision, bool Estymacja, int Month, string Carry, ref DataTable ANC, ref DataTable ECCCCost)
        {
            string[] ANCCalc;
            string[] Delta = null;
            decimal DeltaEst = 0;
            string[] QuantityTable;
            string[] SavingTable;
            string[] ECCCTable;
            string[] CalcBy;
            string[] ECCCTemp = null;
            decimal PercentQuantity;
            decimal Quantity;
            decimal Saving;
            decimal ECCC;
            decimal ECCCSek = 0;
            decimal ECCCSekCost = 0;
            decimal QuantitySum = 0;
            decimal SavingSum = 0;
            decimal ECCCSum = 0;
            bool ECCCCalc = false;
            bool EstymacjaDelta = false;
            bool ECCCEstym = false;
            DataRow QuantityBase;
            DataTable QuantityPerANC;

            QuantityPerANC = LoadTableWithQuantityPerANC_PNC(ActionRow, Revision, Carry);
            ClearColumnPer(ref QuantityPerANC, Month);

            if (Estymacja)
            {
                ANCCalc = ActionRow["PNC"].ToString().Split('|');
                if (ActionRow["PNCEstyma"].ToString() != "")
                {
                    DeltaEst = decimal.Parse(ActionRow["PNCEstyma"].ToString());
                    EstymacjaDelta = true;
                }
                else
                    Delta = ActionRow["PNCSumDelta"].ToString().Split('|');
                PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
            }
            else
            {
                ANCCalc = ActionRow["PNC"].ToString().Split('|');
                Delta = ActionRow["PNCSumDelta"].ToString().Split('|');
                if (Revision == "USE")
                    PercentQuantity = 1;
                else
                    PercentQuantity = decimal.Parse(ActionRow["PNCANCPersent"].ToString()) / 100;
            }

            if (ActionRow["ECCC"].ToString() != "")
            {
                ECCCCalc = true;
                ECCCTemp = ActionRow["ECCC"].ToString().Split('|');
                if (ECCCTemp.Length == 1)
                {
                    ECCCSek = decimal.Parse(ActionRow["ECCC"].ToString());
                    ECCCEstym = true;
                }
                if (Carry == "")
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
                else
                {
                    QuantityBase = ECCCCost.Select(string.Format("Year LIKE '%{0}%'", (_Year - 1).ToString())).FirstOrDefault();
                    ECCCSekCost = decimal.Parse(QuantityBase["ECCC"].ToString());
                }
            }

            QuantityTable = ActionRow["Calc" + Revision + "Quantity" + Carry].ToString().Split('/');
            SavingTable = ActionRow["Calc" + Revision + "Saving" + Carry].ToString().Split('/');
            ECCCTable = ActionRow["Calc" + Revision + "ECCC" + Carry].ToString().Split('/');

            CalcBy = ActionRow["PNC"].ToString().Split('|');
            for (int counter = 0; counter < CalcBy.Length - 1; counter++)
            {
                if (Revision != "USE")
                {
                    QuantityBase = ANC.Select(string.Format("BUPNC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Revision + "/" + Month + "/" + _Year.ToString()].ToString());
                            Quantity *= PercentQuantity;
                            Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                            QuantitySum += Quantity;
                            if (EstymacjaDelta)
                            {
                                Saving = Quantity * DeltaEst;
                                Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                                SavingSum += Saving;
                            }
                            else
                            {
                                Saving = Quantity * decimal.Parse(Delta[counter].ToString());
                                Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                                SavingSum += Saving;
                            }

                            if (ECCCCalc)
                            {
                                if (ECCCEstym)
                                {
                                    ECCC = Quantity * ECCCSek * ECCCSekCost;
                                    ECCCSum += ECCC;
                                }
                                else
                                {
                                    ECCC = Quantity * decimal.Parse(ECCCTemp[counter].ToString()) * ECCCSekCost;
                                    ECCCSum += ECCC;
                                }
                            }

                            QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                        }
                    }
                }
                else
                {
                    QuantityBase = ANC.Select(string.Format("PNC LIKE '%{0}%'", ANCCalc[counter].ToString())).FirstOrDefault();

                    if (QuantityBase != null)
                    {
                        if (QuantityBase[Month + "/" + _Year.ToString()].ToString() != "")
                        {
                            Quantity = decimal.Parse(QuantityBase[Month + "/" + _Year.ToString()].ToString());
                            Quantity = Math.Round(Quantity, 0, MidpointRounding.AwayFromZero);
                            Quantity *= PercentQuantity;
                            QuantitySum += Quantity;
                            if (EstymacjaDelta)
                            {
                                Saving = Quantity * DeltaEst;
                                Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                                SavingSum += Saving;
                            }
                            else
                            {
                                Saving = Quantity * decimal.Parse(Delta[counter].ToString());
                                Saving = Math.Round(Saving, 4, MidpointRounding.AwayFromZero);
                                SavingSum += Saving;
                            }

                            if (ECCCCalc)
                            {
                                if (ECCCEstym)
                                {
                                    ECCC = Quantity * ECCCSek * ECCCSekCost;
                                    ECCCSum += ECCC;
                                }
                                else
                                {
                                    ECCC = Quantity * decimal.Parse(ECCCTemp[counter].ToString()) * ECCCSekCost;
                                    ECCCSum += ECCC;
                                }
                            }

                            QuantityPerANC = AddValueToPerANC_PNC(QuantityPerANC, ANCCalc[counter].ToString(), Quantity, Saving, Month);
                        }
                    }
                }
            }

            QuantitySum = Math.Round(QuantitySum, MidpointRounding.AwayFromZero);
            SavingSum = Math.Round(SavingSum, MidpointRounding.AwayFromZero);
            ECCCSum = Math.Round(ECCCSum, MidpointRounding.AwayFromZero);

            QuantityTable[Month - 1] = QuantitySum.ToString();
            SavingTable[Month - 1] = SavingSum.ToString();
            if (ECCCSum != 0)
            {
                ECCCTable[Month - 1] = ECCCSum.ToString();
            }
            else
            {
                ECCCTable[Month - 1] = "";
            }

            SumRow(ref QuantityTable);
            SumRow(ref SavingTable);
            SumRow(ref ECCCTable);

            ActionRow["Calc" + Revision + "Quantity" + Carry] = ReturnValue(QuantityTable);
            ActionRow["Calc" + Revision + "Saving" + Carry] = ReturnValue(SavingTable);
            ActionRow["Calc" + Revision + "ECCC" + Carry] = ReturnValue(ECCCTable);
            ActionRow["Per" + Revision + Carry] = SaveTablePerANC_PNC(QuantityPerANC);

            return ActionRow;
        }

        private DataTable LoadQuantityACNSpecMass(string Revision, decimal YearToCalc)
        {
            DataTable Quantity = new DataTable();
            DataTable QuantityFinal;


            if (Revision == "USE")
            {
                Data_Import.Singleton().Load_TxtToDataTable2(ref Quantity, "SumPNC");
            }
            else
            {
                Data_Import.Singleton().Load_TxtToDataTable2(ref Quantity, "SumPNCBU");
            }

            QuantityFinal = Quantity.Copy();

            foreach (DataColumn column in Quantity.Columns)
            {
                string Name = column.ColumnName;
                if (Name != "PNC")
                {
                    string Year = Name.Remove(0, Name.Length - 4);
                    if (Year != YearToCalc.ToString())
                    {
                        QuantityFinal.Columns.Remove(Name);
                    }
                }
            }

            return QuantityFinal;
        }

        private void SumRow(ref string[] Row)
        {
            decimal Sum = 0;
            for (int counter = 0; counter < 12; counter++)
            {
                if (Row[counter].ToString() != "")
                {
                    Sum += decimal.Parse(Row[counter].ToString());
                }
            }
            if (Sum != 0)
            {
                Row[12] = Sum.ToString();
            }
            else
            {
                Row[12] = "";
            }
        }

        private string ReturnValue(string[] Row)
        {
            string Results = "";
            foreach (string Row1 in Row)
            {
                Results = Results + Row1 + "/";
            }

            return Results;
        }

        private void ClearColumnPer(ref DataTable Table, int month)
        {
            foreach (DataRow Row in Table.Rows)
            {
                Row[month.ToString()] = "";
            }
        }
    }
}
