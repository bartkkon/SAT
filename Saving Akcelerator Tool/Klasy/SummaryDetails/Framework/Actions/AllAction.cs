using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Klasy.Acton;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework.Actions
{
    public class AllAction : Acton.Action
    {
        public readonly DataRow _action;
        public AllAction(DataRow action)
        {
            _action = action;

            BasicData();
            ANCChange();
            PNCChange();
            CalcSum();
            Per();
            IDCOList();
        }


        private void IDCOList()
        {
            
            IDCO = IDCOTable(_action["IDCO"].ToString());
        }

        private DataTable IDCOTable(string IDCOBase)
        {
            DataTable IDCO = new DataTable();

            if (IDCOBase == "")
                return null;

            IDCO.Columns.Add("ANC");
            IDCO.Columns.Add("IDCO");

            string[] IDCOtogether = IDCOBase.Split('/');

            foreach (string IDCOone in IDCOtogether)
            {
                if (IDCOone != "")
                {
                    string[] Final = IDCOone.Split('|');
                    DataRow NewRow = IDCO.NewRow();
                    NewRow["ANC"] = Final[0];
                    NewRow["IDCO"] = Final[1];
                    IDCO.Rows.Add(NewRow);
                }
            }

            return IDCO;
        }

        private void BasicData()
        {
            Name = _action["Name"].ToString();
            Description = _action["Description"].ToString();
            Group = _action["Group"].ToString();
            Status = _action["Status"].ToString();
            AddYear(_action["StartYear"].ToString());
            StartMonth = _action["StartMonth"].ToString();
            Factory = _action["Factory"].ToString();
            Calculate = _action["Calculate"].ToString();
            Leader = _action["Leader"].ToString();
            Platform = PlatformInstallation(_action["Platform"].ToString());
            Installation = PlatformInstallation(_action["Installation"].ToString());
            Comment = _action["Comment"].ToString();
        }

        private void ANCChange()
        {
            IloscANC = int.Parse(_action["IloscANC"].ToString());

            OldANC = ANCList(_action["Old ANC"].ToString());
            OldANCQ = ANCQList(_action["Old ANCQ"].ToString());
            OldSTK = ANCDecimalList(_action["Old STK"].ToString());

            NewANC = ANCList(_action["New ANC"].ToString());
            NewANCQ = ANCQList(_action["New ANCQ"].ToString());
            NewSTK = ANCDecimalList(_action["New STK"].ToString());

            Delta = ANCDecimalList(_action["Delta"].ToString());
            STKEst = ANCDecimalList(_action["STKEst"].ToString());
            Percent = ANCDecimalList(_action["Percent"].ToString());
            STKCal = ANCDecimalList(_action["STKCal"].ToString());

            ECCC = ANCDecimalList(_action["ECCC"].ToString());
            Next = ANCList(_action["Next"].ToString());
            //Next2 = ANCList(_action["Next2"].ToString());

            Calc = ToBoolTable(_action["Calc"].ToString());
            CalcMass = ToStringTable(_action["CalcMass"].ToString());
        }

        private string[] ToStringTable(string Base)
        {
            if (Base != "")
            {
                return Base.Split('/');
            }
            else
            {
                string[] Status = new string[11];
                return Status;
            }
        }

        private bool[] ToBoolTable(string Base)
        {
            string[] BaseOne = Base.Split('|');
            bool[] Status = new bool[BaseOne.Length];

            for (int counter = 0; counter < BaseOne.Length; counter++)
            {
                if (BaseOne[counter] == "true")
                    Status[counter] = true;
            }

            return Status;
        }

        private void PNCChange()
        {
            PNC = PNCList(_action["PNC"].ToString());
            PNCANC = PNCInsideTable(_action["PNC/ANC"].ToString());
            PNCANCQ = PNCInsideTable(_action["PNC/ANC Q"].ToString());
            PNCSTK = PNCInsideTable(_action["PNCSTK"].ToString());
            PNCDelta = PNCInsideTable2(_action["PNCDelta"].ToString());
            PNCSumSTK = PNCInsideTable3(_action["PNCSumSTK"].ToString());
            PNCSumDelta = PNCInsideTable4(_action["PNCSumDelta"].ToString());
            PNCANCPersent = decimal.Parse(_action["PNCANCPersent"].ToString());
            PNCEstyma = ToDecimal(_action["PNCEstyma"].ToString());
        }

        private void Per()
        {
            PerUSE = PerTable(_action["PerUSE"].ToString(), "USE");
            PerUSECarry = PerTable(_action["PerUSECarry"].ToString(), "USE");
            PerBU = PerTable(_action["PerBU"].ToString(), "BU");
            PerBUCarry = PerTable(_action["PerBUCarry"].ToString(), "BU");
            PerEA1 = PerTable(_action["PerEA1"].ToString(), "EA1");
            PerEA1Carry = PerTable(_action["PerEA1Carry"].ToString(), "EA1");
            PerEA2 = PerTable(_action["PerEA2"].ToString(), "EA2");
            PerEA2Carry = PerTable(_action["PerEA2Carry"].ToString(), "EA2");
            PerEA3 = PerTable(_action["PerEA3"].ToString(), "EA3");
            PerEA3Carry = PerTable(_action["PerEA3Carry"].ToString(), "EA3");
        }

        private DataTable PerTable(string Base, string Revision)
        {
            DataTable Table;
            decimal RevStart;

            RevStart = RevisionStart(Revision);

            Table = CreateColumnsTable(Revision);
            if (Base == "")
                return Table;

            string[] PNC = Base.Split('/');
            for (int counter = 0; counter <= PNC.Length - 1; counter++)
            {
                DataRow NewRow = Table.NewRow();

                string[] One = PNC[counter].Split('|');
                NewRow["PNC"] = One[0];


                for (int counter2 = 1; counter2 <= One.Length - 1; counter2++)
                {
                    if (One[counter2] != "")
                    {
                        string[] Single = One[counter2].Split(':');
                        if (Single[0] != "")
                            NewRow[(RevStart + counter2).ToString() + "Q"] = decimal.Parse(Single[0]);

                        if (Single[1] != "")
                            NewRow[(RevStart + counter2).ToString()] = decimal.Parse(Single[1]);
                    }
                }
                Table.Rows.Add(NewRow);
            }

            return Table;
        }

        private decimal RevisionStart(string revision)
        {
            switch (revision)
            {
                case "USE":
                    return 0;
                case "BU":
                    return 0;
                case "EA1":
                    return 2;
                case "EA2":
                    return 5;
                case "EA3":
                    return 8;
                default:
                    return 0;
            }
        }

        private DataTable CreateColumnsTable(string Revision)
        {
            DataTable Table = new DataTable();
            Table.Columns.Add("PNC", Type.GetType("System.String"));

            if (Revision == "USE" || Revision == "BU")
            {
                Table.Columns.Add("1Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("1", Type.GetType("System.Decimal"));
                Table.Columns.Add("2Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("2", Type.GetType("System.Decimal"));
            }

            if (Revision != "EA2" || Revision != "EA3")
            {
                Table.Columns.Add("3Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("3", Type.GetType("System.Decimal"));
                Table.Columns.Add("4Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("4", Type.GetType("System.Decimal"));
                Table.Columns.Add("5Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("5", Type.GetType("System.Decimal"));
            }
            if (Revision != "EA3")
            {
                Table.Columns.Add("6Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("6", Type.GetType("System.Decimal"));
                Table.Columns.Add("7Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("7", Type.GetType("System.Decimal"));
                Table.Columns.Add("8Q", Type.GetType("System.Decimal"));
                Table.Columns.Add("8", Type.GetType("System.Decimal"));
            }
            Table.Columns.Add("9Q", Type.GetType("System.Decimal"));
            Table.Columns.Add("9", Type.GetType("System.Decimal"));
            Table.Columns.Add("10Q", Type.GetType("System.Decimal"));
            Table.Columns.Add("10", Type.GetType("System.Decimal"));
            Table.Columns.Add("11Q", Type.GetType("System.Decimal"));
            Table.Columns.Add("11", Type.GetType("System.Decimal"));
            Table.Columns.Add("12Q", Type.GetType("System.Decimal"));
            Table.Columns.Add("12", Type.GetType("System.Decimal"));

            return Table;
        }

        private decimal ToDecimal(string Base)
        {
            if (Base == "")
                return 0;
            else
                return decimal.Parse(Base);
        }

        private void CalcSum()
        {
            CalcUSEQuantity = CalcSumToDecimal(_action["CalcUseQuantity"].ToString());
            CalcBUQuantity = CalcSumToDecimal(_action["CalcBUQuantity"].ToString());
            CalcEA1Quantity = CalcSumToDecimal(_action["CalcEA1Quantity"].ToString());
            CalcEA2Quantity = CalcSumToDecimal(_action["CalcEA2Quantity"].ToString());
            CalcEA3Quantity = CalcSumToDecimal(_action["CalcEA3Quantity"].ToString());

            CalcUSEQuantityCarry = CalcSumToDecimal(_action["CalcUseQuantityCarry"].ToString());
            CalcBUQuantityCarry = CalcSumToDecimal(_action["CalcBUQuantityCarry"].ToString());
            CalcEA1QuantityCarry = CalcSumToDecimal(_action["CalcEA1QuantityCarry"].ToString());
            CalcEA2QuantityCarry = CalcSumToDecimal(_action["CalcEA2QuantityCarry"].ToString());
            CalcEA3QuantityCarry = CalcSumToDecimal(_action["CalcEA3QuantityCarry"].ToString());

            CalcUSESaving = CalcSumToDecimal(_action["CalcUseSaving"].ToString());
            CalcBUSaving = CalcSumToDecimal(_action["CalcBUSaving"].ToString());
            CalcEA1Saving = CalcSumToDecimal(_action["CalcEA1Saving"].ToString());
            CalcEA2Saving = CalcSumToDecimal(_action["CalcEA2Saving"].ToString());
            CalcEA3Saving = CalcSumToDecimal(_action["CalcEA3Saving"].ToString());

            CalcUSESavingCarry = CalcSumToDecimal(_action["CalcUseSavingCarry"].ToString());
            CalcBUSavingCarry = CalcSumToDecimal(_action["CalcBUSavingCarry"].ToString());
            CalcEA1SavingCarry = CalcSumToDecimal(_action["CalcEA1SavingCarry"].ToString());
            CalcEA2SavingCarry = CalcSumToDecimal(_action["CalcEA2SavingCarry"].ToString());
            CalcEA3SavingCarry = CalcSumToDecimal(_action["CalcEA3SavingCarry"].ToString());

            CalcUSEECCC = CalcSumToDecimal(_action["CalcUseECCC"].ToString());
            CalcBUECCC = CalcSumToDecimal(_action["CalcBUECCC"].ToString());
            CalcEA1ECCC = CalcSumToDecimal(_action["CalcEA1ECCC"].ToString());
            CalcEA2ECCC = CalcSumToDecimal(_action["CalcEA2ECCC"].ToString());
            CalcEA3ECCC = CalcSumToDecimal(_action["CalcEA3ECCC"].ToString());

            CalcUSEECCCCarry = CalcSumToDecimal(_action["CalcUseECCCCarry"].ToString());
            CalcBUECCCCarry = CalcSumToDecimal(_action["CalcBUECCCCarry"].ToString());
            CalcEA1ECCCCarry = CalcSumToDecimal(_action["CalcEA1ECCCCarry"].ToString());
            CalcEA2ECCCCarry = CalcSumToDecimal(_action["CalcEA2ECCCCarry"].ToString());
            CalcEA3ECCCCarry = CalcSumToDecimal(_action["CalcEA3ECCCCarry"].ToString());
        }

        private decimal[] CalcSumToDecimal(string Base)
        {
            string[] List;
            decimal[] Table = new decimal[13];

            if (Base == "")
                return null;

            List = Base.Split('/');
            for (int counter = 0; counter < 13; counter++)
            {
                if (List[counter] != "")
                {
                    Table[counter] = decimal.Parse(List[counter]);
                }
            }

            return Table;
        }

        private DataTable PNCInsideTable4(string Base)
        {
            DataTable List = new DataTable();
            string[] BaseArry;

            if (Base == "")
            {
                return null;
            }

            BaseArry = Base.Split('|');
            List.Columns.Add("PNC");
            List.Columns.Add("Delta");

            for (int counter = 0; counter < BaseArry.Length - 1; counter++)
            {
                DataRow NewRow = List.NewRow();
                NewRow["PNC"] = counter;
                NewRow["Delta"] = BaseArry[counter];
                List.Rows.Add(NewRow);
            }

            return List;
        }

        private DataTable PNCInsideTable3(string Base)
        {
            DataTable List = new DataTable();
            string[] BaseArry;

            if (Base == "")
            {
                return null;
            }

            BaseArry = Base.Split('|');
            List.Columns.Add("PNC");
            List.Columns.Add("Old");
            List.Columns.Add("New");

            for (int counter = 0; counter < BaseArry.Length - 1; counter++)
            {
                string[] OldNew = BaseArry[counter].Split(':');
                DataRow NewRow = List.NewRow();
                NewRow["PNC"] = counter;
                NewRow["Old"] = OldNew[0];
                NewRow["New"] = OldNew[1];
                List.Rows.Add(NewRow);
            }

            return List;
        }

        private DataTable PNCInsideTable2(string Base)
        {
            DataTable List = new DataTable();
            string[] BaseArry;

            if (Base == "")
            {
                return null;
            }

            BaseArry = Base.Split('|');
            List.Columns.Add("PNC");
            List.Columns.Add("Delta");


            for (int counter = 0; counter <= BaseArry.Length - 1; counter++)
            {
                string[] PNCArry = BaseArry[counter].Split('/');
                for (int counter2 = 0; counter2 < PNCArry.Length - 1; counter2++)
                {
                    //string[] OldNew = PNCArry[counter2].Split(':');
                    DataRow NewRow = List.NewRow();
                    NewRow["PNC"] = counter;
                    NewRow["Delta"] = PNCArry[counter2];
                    List.Rows.Add(NewRow);
                }
            }

            return List;
        }

        private DataTable PNCInsideTable(string Base)
        {
            DataTable List = new DataTable();
            string[] BaseArry;

            if (Base == "")
            {
                return null;
            }

            BaseArry = Base.Split('|');
            List.Columns.Add("PNC");
            List.Columns.Add("Old");
            List.Columns.Add("New");

            for (int counter = 0; counter <= BaseArry.Length - 1; counter++)
            {
                string[] PNCArry = BaseArry[counter].Split('/');
                for (int counter2 = 0; counter2 < PNCArry.Length - 1; counter2++)
                {
                    string[] OldNew = PNCArry[counter2].Split(':');
                    DataRow NewRow = List.NewRow();
                    NewRow["PNC"] = counter;
                    NewRow["Old"] = OldNew[0];
                    NewRow["New"] = OldNew[1];
                    List.Rows.Add(NewRow);
                }
            }

            return List;
        }

        private DataTable PNCList(string PNCListBase)
        {
            DataTable Lista = new DataTable();
            string[] PNCList;

            if (PNCListBase == "")
            {
                return null;
            }

            PNCList = PNCListBase.Split('|');
            Lista.Columns.Add("PNC");

            foreach (string PNC in PNCList)
            {
                if (PNC != "")
                {
                    DataRow PNCRow = Lista.NewRow();
                    PNCRow["PNC"] = PNC;
                    Lista.Rows.Add(PNCRow);
                }
            }

            return Lista;
        }

        private decimal[] ANCDecimalList(string ANCSTKBase)
        {
            if (ANCSTKBase != "")
            {
                decimal[] List;
                string[] ANCSTK = ANCSTKBase.Split('|');
                List = new decimal[ANCSTK.Length];

                for (int counter = 0; counter <= ANCSTK.Length - 1; counter++)
                {
                    if (ANCSTK[counter].ToString() != "")
                    {
                        List[counter] = decimal.Parse(ANCSTK[counter].ToString());
                    }
                }
                return List;
            }
            else
                return null;
        }

        private decimal[] ANCQList(string ANCQBase)
        {
            decimal[] List;
            string[] ANCQ = ANCQBase.Split('|');
            List = new decimal[ANCQ.Length - 1];

            for (int counter = 0; counter <= ANCQ.Length - 1; counter++)
            {
                if (ANCQ[counter].ToString() != "")
                {
                    List[counter] = decimal.Parse(ANCQ[counter].ToString());
                }
            }
            return List;
        }

        private string[] PlatformInstallation(string Base)
        {
            string[] Platform = Base.Split('/');

            return Platform.Take(Platform.Count() - 1).ToArray();
        }

        private string[] ANCList(string ANCBase)
        {
            string[] ANCList = ANCBase.Split('|');

            return ANCList.Take(ANCList.Count() - 1).ToArray();
        }

        private void AddYear(string Year)
        {
            if (Year.Length == 4)
            {
                StatusYear = "";
                StartYear = decimal.Parse(_action["StartYear"].ToString());
            }
            else
            {
                StatusYear = _action["StartYear"].ToString().Substring(0, 2);
                StartYear = decimal.Parse(_action["StartYear"].ToString().Substring(3, 4));
            }
        }
    }
}
