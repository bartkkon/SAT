using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    public class Calculation
    {
        MainProgram mainProgram;
        Data_Import ImportData;
        private readonly int ANCChangeNumber;

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

        private readonly Dictionary<string, int> RevisionStartMonth = new Dictionary<string, int>()
        {
            {"BU", 1},
            {"EA1", 3},
            {"EA2", 6},
            {"EA3", 9},
        };

        private readonly Dictionary<string, int> DataGridViewRowsNumber = new Dictionary<string, int>()
        {
            {"BU", 4},
            {"EA1", 3},
            {"EA2", 2},
            {"EA3", 1},
            {"USE",0}
        };

        DataTable USE = new DataTable();
        DataTable BU = new DataTable();
        DataTable EA1 = new DataTable();
        DataTable EA2 = new DataTable();
        DataTable EA3 = new DataTable();

        public Calculation(MainProgram mainProgram, Data_Import ImportData, int ANCChangeNumber, DataTable USE, DataTable BU, DataTable EA1, DataTable EA2, DataTable EA3)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            this.ANCChangeNumber = ANCChangeNumber;
            this.USE = USE;
            this.BU = BU;
            this.EA1 = EA1;
            this.EA2 = EA2;
            this.EA3 = EA3;
        }

        public void SavingCalculation()
        {
            CalculateDisplayedAction();
        }

        //Czy Wyświetlaną akcje można przeliczyć  - Czy dany miesiąc czy daną rewizje Budżetu i czy już nie jest tany działa zablokowany przez Approval przez Działowego Menager
        private void CalculateDisplayedAction()
        {
            //Tabele
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;

            //Stałe Elementy które są brane z Formy
            decimal YearToCalc = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;

            //Zmienne 
            string LinkFrozen;
            string TypeofCalc;
            bool DevisionCalculate;
            bool RevisionBU;
            bool RevisionEA1;
            bool RevisionEA2;
            bool RevisionEA3;
            bool USEBool;
            bool CurrentYear;
            bool CarryOver;
            int ActionStart;

            //Ładowanie tablicy która mówi co jest zamrożone a no można przeliczyć
            LinkFrozen = ImportData.Load_Link("Frozen");
            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", YearToCalc.ToString())).FirstOrDefault();

            //Sprawdzenie czy rok przeliczenia jest taki sam jak rok rozpoczęcia akcji - New Action
            CurrentYear = CheckYearNewAction(YearToCalc);

            //Sprawdzenie czy rok przeliczenia jest taki sam jak rok rozpoczęcia akcji -1 - Carry Over
            CarryOver = CheckYearCarryOver(YearToCalc);

            //Jeśli rok przeliczenia się nie zgadza z danym rokiem 
            if (!CurrentYear && !CarryOver)
            {
                return;
            }

            //Sprawdzenie czy odpowiednia Dewizja może być przeliczona
            DevisionCalculate = DevisionPermision(FrozenRow);

            //Jeśli dany Dewizja nie ma pozwolenia na zmianę to kończy sprawdzanie
            if (!DevisionCalculate)
            {
                return;
            }

            //Sprawdzenie czy dana Rewizja może być przeliczona
            RevisionBU = RevisionPermission(FrozenRow, "BU");
            RevisionEA1 = RevisionPermission(FrozenRow, "EA1");
            RevisionEA2 = RevisionPermission(FrozenRow, "EA2");
            RevisionEA3 = RevisionPermission(FrozenRow, "EA3");

            //Sprawdzenie jakiego typu jest akcja
            TypeofCalc = CalculationTypeCheck();



            //Przeliczenie Rewizji
            if (RevisionBU)
            {
                BU.Rows.Clear();
                ClearDataGridViewForRevision("BU");
                CalculationRevisionSaving(TypeofCalc, "BU", CarryOver, YearToCalc);
            }
            if (RevisionEA1)
            {
                EA1.Rows.Clear();
                ClearDataGridViewForRevision("EA1");
                CalculationRevisionSaving(TypeofCalc, "EA1", CarryOver, YearToCalc);
            }
            if (RevisionEA2)
            {
                EA2.Rows.Clear();
                ClearDataGridViewForRevision("EA2");
                CalculationRevisionSaving(TypeofCalc, "EA2", CarryOver, YearToCalc);
            }
            if (RevisionEA3)
            {
                EA3.Rows.Clear();
                ClearDataGridViewForRevision("EA3");
                CalculationRevisionSaving(TypeofCalc, "EA3", CarryOver, YearToCalc);
            }

            //Przeliczanie miesięcy dozwolonych do przeliczenia
            for (int Month = 1; Month <= 12; Month++)
            {
                USEBool = RevisionPermission(FrozenRow, Month.ToString());
                ActionStart = MonthActionStart();
                if (USEBool)
                {
                    if (!CarryOver)
                    {
                        if (Month >= ActionStart)
                        {
                            ClearColumnInUSE(Month);
                            CalculationUSESaving(TypeofCalc, Month, CarryOver, YearToCalc);
                        }
                    }
                    else
                    {
                        if (Month < ActionStart)
                        {
                            ClearColumnInUSE(Month);
                            CalculationUSESaving(TypeofCalc, Month, CarryOver, YearToCalc);
                        }
                    }
                }
            }
        }

        //Przeliczanie akcji dla danego miesiąca
        private void CalculationUSESaving(string TypeofCalc, int Month, bool CarryOver, decimal YearToCalc)
        {
            if (TypeofCalc == "ANC")
            {
                CalculationUSEANC(Month, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "ANCSpec")
            {
                CalculationUSEANCSpec(Month, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "PNC")
            {
                CalculationUSEPNC(Month, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "PNCSpec")
            {
                CalculationUSEPNCSpec(Month, CarryOver, YearToCalc);
            }
        }

        //Przeliczanie akcji dla danej rewizji
        private void CalculationRevisionSaving(string TypeofCalc, string Revision, bool CarryOver, decimal YearToCalc)
        {
            //int MonthStart;
            int MonthCalcStart;
            int MonthCalcFinish;

            //Od którego miesiąca trzeba zacząć przeliczać
            MonthCalcStart = CalcStart_Revision(Revision, CarryOver);
            //Do którego miesiaąca należy zakończyć liczenie
            MonthCalcFinish = CalcFinish_Revision(Revision, CarryOver);

            if (TypeofCalc == "ANC")
            {
                CalculationANC(MonthCalcStart, MonthCalcFinish, Revision, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "ANCSpec")
            {
                CalculationANCSpec(MonthCalcStart, MonthCalcFinish, Revision, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "PNC")
            {
                CalculationPNC(MonthCalcStart, MonthCalcFinish, Revision, CarryOver, YearToCalc);
            }
            else if (TypeofCalc == "PNCSpec")
            {
                CalculationPNCSpec(MonthCalcStart, MonthCalcFinish, Revision, CarryOver, YearToCalc);
            }
        }

        // Kalkulacja do przeliczenia po kodach ANC
        private void CalculationANC(int MonthCalcStart, int MonthCalcFinish, string Revision, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityANCTable = new DataTable();
            DataRow QuantityRow;
            decimal Quantity = 0;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            string ANC = "";
            string ANCNext = "";
            decimal QuantityPercent;
            bool Delta;
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            DataRow ResultsRow = null;
            DataTable Per = new DataTable();
            int RevisionStart;
            int MonthAction;

            ComboBox MonthCombo = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First();
            MonthAction = Month[MonthCombo.SelectedItem.ToString()];


            if (Revision == "BU")
                Per = BU;
            else if (Revision == "EA1")
                Per = EA1;
            else if (Revision == "EA2")
                Per = EA2;
            else
                Per = EA3;

            RevisionStart = RevisionStartMonth[Revision];

            Delta = DeltaIFcanCalculate(CarryOver, MonthCalcStart, RevisionStart, MonthAction);

            QuantityPercent = decimal.Parse(((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text) / 100;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityANCTable = LoadQuantityANCTable(Revision, YearToCalc);

            for (int Month = MonthCalcStart; Month <= MonthCalcFinish; Month++)
            {

                for (int counter = 1; counter <= ANCChangeNumber; counter++)
                {
                    //Sprawdzenie które ANC mamy wziąśc do liczenie
                    if (Delta)
                    {
                        ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First()).Text;
                        ANCNext = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First()).Text;
                        Delta = true;
                    }
                    else
                    {
                        ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First()).Text;
                    }

                    //Znalezienie ilości do odpowiednich ANC
                    if (Delta)
                    {
                        if (ANC != "")
                        {
                            QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                            QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
                        }
                        if (ANCNext != "")
                        {
                            QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                            QuantityANC = QuantityANC + (decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent);
                        }
                    }
                    else
                    {
                        QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                        QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
                    }

                    //Dodanie Ilości nadego ANC dla Quantity wykorzystywanego w danym miesiącu 
                    Quantity = Quantity + QuantityANC;

                    //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 
                    if (Delta)
                    {
                        DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_Delta" + counter.ToString(), true).First()).Text);
                        Savings = Savings + (QuantityANC * DeltaCost);
                    }
                    else
                    {
                        DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_Calc" + counter.ToString(), true).First()).Text);
                        Savings = Savings + (QuantityANC * DeltaCost);
                    }

                    if (Per != null)
                    {
                        if (ANC != "")
                            ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", ANC)).FirstOrDefault();
                        else if (ANCNext != "")
                            ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                    }
                    if (ResultsRow == null)
                    {
                        ResultsRow = Per.NewRow();
                        if (ANC != "")
                            ResultsRow["Name"] = ANC;
                        else
                            ResultsRow["Name"] = ANCNext;

                        ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        Per.Rows.Add(ResultsRow);
                    }
                    else
                    {
                        ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    }

                    if (ECCCtoCalc)
                    {
                        ECCC = ECCC + (QuantityANC * ECCCSeconds * ECCCCost);
                    }

                    QuantityANC = 0;
                }

                AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, Revision);
                Quantity = 0;
                QuantityANC = 0;
                Savings = 0;
                ECCC = 0;
            }

            if (Revision == "BU")
                BU = Per;
            else if (Revision == "EA1")
                EA1 = Per;
            else if (Revision == "EA2")
                EA2 = Per;
            else
                EA3 = Per;

            SumDataGridView();
        }

        //Kalkulacje po przeliczania po kodach ANC przy wybranym tylko jednym ANC
        private void CalculationANCSpec(int MonthCalcStart, int MonthCalcFinish, string Revision, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityANCTable = new DataTable();
            DataTable QuantityMassTable = new DataTable();
            DataRow QuantityRow;
            decimal Quantity = 0;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            string ANC = "";
            string ANCNext = "";
            decimal QuantityPercent;
            bool Delta;
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            bool ToCalc;
            bool Mass = true;
            DataRow ResultsRow = null;
            DataTable Per = new DataTable();
            int MonthAction;

            ComboBox MonthCombo = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First();
            MonthAction = Month[MonthCombo.SelectedItem.ToString()];


            if (Revision == "BU")
            {
                Per = BU;
            }
            else if (Revision == "EA1")
            {
                Per = EA1;
            }
            else if (Revision == "EA2")
            {
                Per = EA2;
            }
            else
            {
                Per = EA3;
            }

            int RevisionStart = RevisionStartMonth[Revision];

            Delta = DeltaIFcanCalculate(CarryOver, MonthCalcStart, RevisionStart, MonthAction);

            QuantityPercent = decimal.Parse(((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text) / 100;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityANCTable = LoadQuantityANCTable(Revision, YearToCalc);
            QuantityMassTable = LoadQuantityACNSpecMass(Revision, YearToCalc);

            for (int Month = MonthCalcStart; Month <= MonthCalcFinish; Month++)
            {
                for (int counter = 1; counter <= ANCChangeNumber; counter++)
                {
                    //Sprawdzenie dla którego ANC mają być brane ilości
                    ToCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ANCby" + counter.ToString(), true).First()).Checked;
                    if (ToCalc)
                    {
                        Mass = false;
                        //Sprawdzenie które ANC mamy wziąśc do liczenie
                        if (Delta)
                        {
                            ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First()).Text;
                            ANCNext = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First()).Text;
                            Delta = true;
                        }
                        else
                        {
                            ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First()).Text;
                        }

                        //Znalezienie ilości do odpowiednich ANC
                        if (Delta)
                        {
                            QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                            QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
                            if (ANCNext != "")
                            {
                                QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                                QuantityANC = QuantityANC + (decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent);
                            }
                        }
                        else
                        {
                            QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                            QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString()) * QuantityPercent;
                        }

                        //Dodanie Ilości danego ANC dla Quantity wykorzystywanego w danym miesiącu 
                        Quantity = Quantity + QuantityANC;

                        //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 
                        if (Delta)
                        {
                            DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_DeltaSum", true).First()).Text);
                            Savings = Savings + (QuantityANC * DeltaCost);
                        }
                        else
                        {
                            DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_CalcSum", true).First()).Text);
                            Savings = Savings + (QuantityANC * DeltaCost);
                        }

                        if (Per != null)
                        {
                            if (ANC != "")
                                ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", ANC)).FirstOrDefault();
                            else if (ANCNext != "")
                                ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                        }
                        if (ResultsRow == null)
                        {
                            ResultsRow = Per.NewRow();
                            if (ANC != "")
                                ResultsRow["Name"] = ANC;
                            else
                                ResultsRow["Name"] = ANCNext;

                            ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                            Per.Rows.Add(ResultsRow);
                        }
                        else
                        {
                            ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        }

                        if (ECCCtoCalc)
                        {
                            ECCC = ECCC + (QuantityANC * ECCCSeconds * ECCCCost);
                        }

                        QuantityANC = 0;
                    }
                }

                if (Mass)
                {
                    if (Delta)
                    {
                        DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_DeltaSum", true).First()).Text);
                    }
                    else
                    {
                        DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_CalcSum", true).First()).Text);
                    }

                    foreach (DataRow Row in QuantityMassTable.Rows)
                    {
                        string Name = Row["PNC"].ToString();

                        if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Name, true).First()).Checked)
                        {

                            QuantityANC = decimal.Parse(Row[Revision + "/" + Month.ToString() + "/" + YearToCalc.ToString()].ToString()) * QuantityPercent;
                            QuantityANC = Math.Round(QuantityANC, 0, MidpointRounding.AwayFromZero);
                            Quantity += QuantityANC;
                            Savings += (QuantityANC * DeltaCost);
                            Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

                            if (Per != null)
                            {
                                if (Name != "")
                                    ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", Name)).FirstOrDefault();
                            }
                            if (ResultsRow == null)
                            {
                                ResultsRow = Per.NewRow();
                                if (Name != "")
                                    ResultsRow["Name"] = Name;

                                ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                                Per.Rows.Add(ResultsRow);
                            }
                            else
                            {
                                ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                            }

                            if (ECCCtoCalc)
                            {
                                ECCC += (QuantityANC * ECCCSeconds * ECCCCost);
                            }
                            QuantityANC = 0;
                        }
                    }
                }

                AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, Revision);
                Quantity = 0;
                QuantityANC = 0;
                Savings = 0;
                ECCC = 0;
            }

            if (Revision == "BU")
                BU = Per;
            else if (Revision == "EA1")
                EA1 = Per;
            else if (Revision == "EA2")
                EA2 = Per;
            else
                EA3 = Per;

            SumDataGridView();
        }

        //Kalkulacja po PNC 
        private void CalculationPNC(int MonthCalcStart, int MonthCalcFinish, string Revision, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityPNCTable = new DataTable();
            decimal QuantityPNC = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            decimal QuantityPercent;
            bool Delta;
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            DataRow ResultsRow = null;
            DataTable Per = new DataTable();
            int MonthAction;

            ComboBox MonthCombo = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First();
            MonthAction = Month[MonthCombo.SelectedItem.ToString()];

            if (Revision == "BU")
                Per = BU;
            else if (Revision == "EA1")
                Per = EA1;
            else if (Revision == "EA2")
                Per = EA2;
            else
                Per = EA3;

            int RevisionStart = RevisionStartMonth[Revision];

            QuantityPercent = decimal.Parse(((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text) / 100;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityPNCTable = LoadQuantityPNCTable(Revision, YearToCalc);

            //Sprawdzenie czy ma brać jeszcze po estymacji czy po finalnych wyliczeniach 
            Delta = DeltaIFcanCalculate(CarryOver, MonthCalcStart, RevisionStart, MonthAction);

            for (int Month = MonthCalcStart; Month <= MonthCalcFinish; Month++)
            {

                //Sprawdza jaki jest Saving odpowiednio czy akcja już weszła czy jeszcze nie
                if (Delta)
                {
                    DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_DeltaSum", true).First()).Text);
                }
                else
                {
                    DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_CalcSum", true).First()).Text);
                }

                //Sumuje ilości PNC dla danego miesiąca dla wszystkich PNC
                foreach (DataRow Row in QuantityPNCTable.Rows)
                {
                    QuantityPNC = QuantityPNC + decimal.Parse(Row[Month.ToString()].ToString());

                    if (Per != null)
                    {
                        if (Row[Month.ToString()].ToString() != "")
                            ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", Row[0].ToString())).FirstOrDefault();
                    }

                    decimal Quantity = Math.Round(decimal.Parse(Row[Month.ToString()].ToString()) * QuantityPercent, 0, MidpointRounding.AwayFromZero);
                    if (ResultsRow == null)
                    {
                        ResultsRow = Per.NewRow();
                        if (Row[0].ToString() != "")
                            ResultsRow["Name"] = Row[0].ToString();


                        ResultsRow[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Quantity * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        Per.Rows.Add(ResultsRow);
                    }
                    else
                    {
                        ResultsRow[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Quantity * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    }
                }

                //Przemnożenie ilości przez procentową ilość PNC
                QuantityPNC = QuantityPNC * QuantityPercent;

                //Wylicza saving
                Savings = QuantityPNC * DeltaCost;

                //Jak ECCC jest zaznaczone to przelicza
                if (ECCCtoCalc)
                {
                    ECCC = ECCC + (QuantityPNC * ECCCSeconds * ECCCCost);
                }

                AddValueToDataGrid(QuantityPNC, Savings, ECCC, Month, ECCCtoCalc, Revision);
                QuantityPNC = 0;
                Savings = 0;
                ECCC = 0;
            }

            if (Revision == "BU")
                BU = Per;
            else if (Revision == "EA1")
                EA1 = Per;
            else if (Revision == "EA2")
                EA2 = Per;
            else
                EA3 = Per;

            SumDataGridView();
        }

        //Kalkulacja po PNC Specjalnym
        private void CalculationPNCSpec(int MonthCalcStart, int MonthCalcFinish, string Revision, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityPNCTable = new DataTable();
            DataGridView PNCTable;
            decimal QuantityPNC = 0;
            decimal Quantity = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost = 0;
            decimal QuantityPercent;
            bool Delta;
            bool ECCCtoCalc = false;
            bool ECCCtoCalcSpec = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            string PNC;
            string ECCCHelp;
            DataRow ResultsRow = null;
            DataTable Per = new DataTable();
            int MonthAction;

            ComboBox MonthCombo = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First();
            MonthAction = Month[MonthCombo.SelectedItem.ToString()];

            if (Revision == "BU")
                Per = BU;
            else if (Revision == "EA1")
                Per = EA1;
            else if (Revision == "EA2")
                Per = EA2;
            else
                Per = EA3;

            int RevisionStart = RevisionStartMonth[Revision];

            QuantityPercent = decimal.Parse(((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text) / 100;

            PNCTable = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCtoCalcSpec = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked;
                if (!ECCCtoCalcSpec)
                {
                    ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
                }
            }

            //Załadowanie tablicy używanych ANC 
            QuantityPNCTable = LoadQuantityPNCTable(Revision, YearToCalc);

            //Sprawdzenie czy ma brać jeszcze po estymacji czy po finalnych wyliczeniach 
            Delta = DeltaIFcanCalculate(CarryOver, MonthCalcStart, RevisionStart, MonthAction);

            if (PNCTable.Columns.Count == 8)
            {
                Delta = true;
            }

            //Sprawdza Czy ma liczyć Saving po Estymacji czy finalny
            if (!Delta)
            {
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_EstymacjaPNC", true).First()).Text != "")
                    DeltaCost = decimal.Parse(((TextBox)mainProgram.TabControl.Controls.Find("TB_EstymacjaPNC", true).First()).Text);
            }

            for (int Month = MonthCalcStart; Month <= MonthCalcFinish; Month++)
            {
                //Liczenie Oszczędności korzystając z tabelki z PNC Quantity 
                foreach (DataGridViewRow PNCRow in PNCTable.Rows)
                {
                    if (PNCRow.Cells["PNC"].Value != null && !PNCRow.Cells["PNC"].Value.ToString().Equals(""))
                    {
                        PNC = PNCRow.Cells["PNC"].Value.ToString();

                        DataRow Row = QuantityPNCTable.Select(string.Format("PNC LIKE '%{0}%'", PNC)).First();

                        if (Row != null)
                        {
                            QuantityPNC = decimal.Parse(Row[Month.ToString()].ToString());
                            //Przemnożenie ilości przez procentową ilość PNC
                            QuantityPNC = QuantityPNC * QuantityPercent;
                            QuantityPNC = Math.Round(QuantityPNC, 0, MidpointRounding.AwayFromZero);
                            //Dodanie do puli danego PNC do łączej ilościw miesiącu
                            Quantity = Quantity + QuantityPNC;
                        }

                        if (!Delta)
                        {
                            Savings = Savings + (QuantityPNC * DeltaCost);
                        }
                        else
                        {
                            DeltaCost = decimal.Parse(PNCRow.Cells["Delta"].Value.ToString());
                            Savings = Savings + (QuantityPNC * DeltaCost);
                        }

                        if (Per.Rows.Count != 0)
                        {
                            if (Row[Month.ToString()].ToString() != "")
                                ResultsRow = Per.Select(string.Format("Name LIKE '%{0}%'", PNC)).FirstOrDefault();
                        }
                        else
                        {
                            ResultsRow = null;
                        }
                        if (ResultsRow == null)
                        {
                            ResultsRow = Per.NewRow();
                            if (Row[Month.ToString()].ToString() != "")
                                ResultsRow["Name"] = PNC;

                            ResultsRow[Month.ToString()] = QuantityPNC.ToString() + ":" + Math.Round(QuantityPNC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                            Per.Rows.Add(ResultsRow);
                        }
                        else
                        {
                            ResultsRow[Month.ToString()] = QuantityPNC.ToString() + ":" + Math.Round(QuantityPNC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        }

                        if (ECCCtoCalc)
                        {
                            if (ECCCtoCalcSpec)
                            {
                                ECCCHelp = PNCRow.Cells["OLD ANC"].Value.ToString();
                                if (ECCCHelp != "")
                                {
                                    ECCCHelp = ECCCHelp.Remove(0, 5);
                                    ECCCHelp = ECCCHelp.Remove(ECCCHelp.Length - 1, 1);
                                    ECCCSeconds = decimal.Parse(ECCCHelp);
                                }
                                else
                                {
                                    ECCCSeconds = 0;
                                }
                            }
                            ECCC = ECCC + (QuantityPNC * ECCCCost * ECCCSeconds);
                        }
                    }
                }

                AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, Revision);
                Quantity = 0;
                QuantityPNC = 0;
                Savings = 0;
                ECCC = 0;
                SumDataGridView();
            }
            if (Revision == "BU")
                BU = Per;
            else if (Revision == "EA1")
                EA1 = Per;
            else if (Revision == "EA2")
                EA2 = Per;
            else
                EA3 = Per;
        }

        //Kalkulacja dla akcji finalnego zużycia dla ANC - USE
        private void CalculationUSEANC(int Month, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityANCTable = new DataTable();
            DataRow QuantityRow;
            decimal Quantity = 0;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            string ANC = "";
            string ANCNext = "";
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            //string Results = "";
            DataRow ResultsRow = null;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityANCTable = LoadQuantityANCTableUSE(Month, YearToCalc);

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                //Wyciągnięcie ANC do liczenia
                ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First()).Text;
                ANCNext = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First()).Text;

                //Znalezienie ilości do odpowiednich ANC
                if (ANC != "")
                {
                    QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString());

                }
                if (ANCNext != "")
                {
                    QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                    QuantityANC = QuantityANC + decimal.Parse(QuantityRow[Month.ToString()].ToString());
                }
                //Dodanie Ilości nadego ANC dla Quantity wykorzystywanego w danym miesiącu 
                Quantity = Quantity + QuantityANC;

                //Sprawdza i wylicza Saving odpowiedni czy akcja już weszła czy jeszcze nie 
                DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_Delta" + counter.ToString(), true).First()).Text);
                Savings = Savings + (QuantityANC * DeltaCost);

                if (USE != null)
                {
                    if (ANC != "")
                        ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", ANC)).FirstOrDefault();
                    else if (ANCNext != "")
                        ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                }
                if (ResultsRow == null)
                {
                    ResultsRow = USE.NewRow();
                    if (ANC != "")
                        ResultsRow["Name"] = ANC;
                    else
                        ResultsRow["Name"] = ANCNext;

                    ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    USE.Rows.Add(ResultsRow);
                }
                else
                {
                    ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                }

                //Wylicza ECC jeśli wybrany
                if (ECCCtoCalc)
                {
                    ECCC = ECCC + (QuantityANC * ECCCSeconds * ECCCCost);
                }
                QuantityANC = 0;
            }

            AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, "USE");
            Quantity = 0;
            QuantityANC = 0;
            Savings = 0;
            ECCC = 0;

            SumDataGridView();
        }

        //Kalkulacja dla akcji Finalnego zużycia dla ANCSpec - USE
        private void CalculationUSEANCSpec(int Month, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityANCTable = new DataTable();
            DataTable QuantityMassTable = new DataTable();
            DataRow QuantityRow;
            decimal Quantity = 0;
            decimal QuantityANC = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            string ANC = "";
            string ANCNext = "";
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            bool ToCalc;
            bool Mass = true;
            //string Results = "";
            DataRow ResultsRow = null;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityANCTable = LoadQuantityANCTableUSE(Month, YearToCalc);
            QuantityMassTable = LoadQuantityACNSpecMass("USE", YearToCalc);

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                //Sprawdzenie dla którego ANC mają być brane ilości
                ToCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ANCby" + counter.ToString(), true).First()).Checked;
                if (ToCalc)
                {
                    Mass = false;
                    //Sprawdzenie które ANC mamy wziąśc do liczenie
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First()).Text;
                    ANCNext = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First()).Text;

                    //Znalezienie ilości do odpowiednich ANC
                    if (ANC != "")
                    {
                        QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                        QuantityANC = decimal.Parse(QuantityRow[Month.ToString()].ToString());
                        if (ANCNext != "")
                        {
                            QuantityRow = QuantityANCTable.Select(string.Format("ANC LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                            QuantityANC = QuantityANC + decimal.Parse(QuantityRow[Month.ToString()].ToString());
                        }
                    }

                    //Dodanie Ilości danego ANC dla Quantity wykorzystywanego w danym miesiącu 
                    Quantity = Quantity + QuantityANC;

                    //Wylicza finalny saving na akcji
                    DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First()).Text);
                    Savings = Savings + (QuantityANC * DeltaCost);

                    if (USE != null)
                    {
                        if (ANC != "")
                            ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", ANC)).FirstOrDefault();
                        else if (ANCNext != "")
                            ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", ANCNext)).FirstOrDefault();
                    }
                    if (ResultsRow == null)
                    {
                        ResultsRow = USE.NewRow();
                        if (ANC != "")
                            ResultsRow["Name"] = ANC;
                        else
                            ResultsRow["Name"] = ANCNext;

                        ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        USE.Rows.Add(ResultsRow);
                    }
                    else
                    {
                        ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    }

                    //Liczy ECCC jeśli wybrane
                    if (ECCCtoCalc)
                    {
                        ECCC = ECCC + (QuantityANC * ECCCSeconds * ECCCCost);
                    }
                    QuantityANC = 0;
                }
            }
            if(Mass)
            {
                DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First()).Text);

                foreach (DataRow Row in QuantityMassTable.Rows)
                {
                    string Name = Row["PNC"].ToString();

                    if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Name, true).First()).Checked)
                    {

                        QuantityANC = decimal.Parse(Row[Month.ToString() + "/" + YearToCalc.ToString()].ToString());
                        Quantity += QuantityANC;
                        Savings += (QuantityANC * DeltaCost);
                        Savings = Math.Round(Savings, 4, MidpointRounding.AwayFromZero);

                        if (USE != null)
                        {
                            if (Name != "")
                                ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", Name)).FirstOrDefault();
                        }
                        if (ResultsRow == null)
                        {
                            ResultsRow = USE.NewRow();
                            if (Name != "")
                                ResultsRow["Name"] = Name;

                            ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                            USE.Rows.Add(ResultsRow);
                        }
                        else
                        {
                            ResultsRow[Month.ToString()] = QuantityANC.ToString() + ":" + Math.Round(QuantityANC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        }

                        if (ECCCtoCalc)
                        {
                            ECCC += (QuantityANC * ECCCSeconds * ECCCCost);
                        }
                        QuantityANC = 0;
                    }
                }
            }

            AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, "USE");
            Quantity = 0;
            QuantityANC = 0;
            Savings = 0;
            ECCC = 0;

            SumDataGridView();
        }

        //Kallkulacja dla Finalnego zużycia dla PNC - USE
        private void CalculationUSEPNC(int Month, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityPNCTable = new DataTable();
            decimal QuantityPNC = 0;
            decimal Quantity = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost;
            bool ECCCtoCalc = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            //string Results = "";
            DataRow ResultsRow = null;

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
            }

            //Załadowanie tablicy używanych ANC 
            QuantityPNCTable = LoadQuantityPNCTableUSE(Month, YearToCalc);

            //Wyciąga Delta Cost 
            DeltaCost = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First()).Text);

            //Sumuje ilości PNC dla danego miesiąca dla wszystkich PNC
            foreach (DataRow Row in QuantityPNCTable.Rows)
            {
                ResultsRow = null;
                QuantityPNC = QuantityPNC + decimal.Parse(Row[Month.ToString()].ToString());
                Quantity = decimal.Parse(Row[Month.ToString()].ToString());

                if (USE != null)
                {
                    if (Row[Month.ToString()].ToString() != "")
                        ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", Row["PNC"].ToString())).FirstOrDefault();
                }
                if (ResultsRow == null)
                {
                    ResultsRow = USE.NewRow();
                    if (Row[Month.ToString()].ToString() != "")
                        ResultsRow["Name"] = Row["PNC"].ToString();

                    ResultsRow[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Quantity * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    USE.Rows.Add(ResultsRow);
                }
                else
                {
                    ResultsRow[Month.ToString()] = Quantity.ToString() + ":" + Math.Round(Quantity * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                }
            }

            //Wylicza saving
            Savings = QuantityPNC * DeltaCost;

            //Jak ECCC jest zaznaczone to przelicza
            if (ECCCtoCalc)
            {
                ECCC = ECCC + (QuantityPNC * ECCCSeconds * ECCCCost);
            }

            AddValueToDataGrid(QuantityPNC, Savings, ECCC, Month, ECCCtoCalc, "USE");
            QuantityPNC = 0;
            Savings = 0;
            ECCC = 0;

            SumDataGridView();
        }

        //Kalkulacja dla Dinalnego zużycia dla PNC - USE
        private void CalculationUSEPNCSpec(int Month, bool CarryOver, decimal YearToCalc)
        {
            DataTable QuantityPNCTable = new DataTable();
            DataGridView PNCTable;
            decimal QuantityPNC = 0;
            decimal Quantity = 0;
            decimal Savings = 0;
            decimal ECCC = 0;
            decimal DeltaCost = 0;
            bool ECCCtoCalc = false;
            bool ECCCtoCalcSpec = false;
            decimal ECCCCost = 0;
            decimal ECCCSeconds = 0;
            string PNC;
            string ECCCHelp;
            //string Results = "";
            DataRow ResultsRow = null;

            PNCTable = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

            //Sprawdzenie czy dana akcja ma być liczona z ECCC
            ECCCtoCalc = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            if (ECCCtoCalc)
            {
                ECCCCost = ECCCCostSecond(YearToCalc, CarryOver);
                ECCCtoCalcSpec = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked;
                if (!ECCCtoCalcSpec)
                {
                    ECCCSeconds = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value;
                }
            }

            //Załadowanie tablicy używanych ANC 
            QuantityPNCTable = LoadQuantityPNCTableUSE(Month, YearToCalc);

            //Liczenie Oszczędności korzystając z tabelki z PNC Quantity 
            foreach (DataGridViewRow PNCRow in PNCTable.Rows)
            {
                if (PNCRow.Cells["PNC"].Value != null && !PNCRow.Cells["PNC"].Value.ToString().Equals(""))
                {
                    PNC = PNCRow.Cells["PNC"].Value.ToString();

                    DataRow Row = QuantityPNCTable.Select(string.Format("PNC LIKE '%{0}%'", PNC)).First();

                    if (Row != null)
                    {
                        QuantityPNC = decimal.Parse(Row[Month.ToString()].ToString());
                        //Dodanie do puli danego PNC do łączej ilościw miesiącu
                        Quantity = Quantity + QuantityPNC;
                    }

                    DeltaCost = decimal.Parse(PNCRow.Cells["Delta"].Value.ToString());
                    Savings = Savings + (QuantityPNC * DeltaCost);

                    if (USE != null)
                    {
                        if (Row[Month.ToString()].ToString() != "")
                            ResultsRow = USE.Select(string.Format("Name LIKE '%{0}%'", Row["PNC"].ToString())).FirstOrDefault();
                    }
                    if (ResultsRow == null)
                    {
                        ResultsRow = USE.NewRow();
                        if (Row[Month.ToString()].ToString() != "")
                            ResultsRow["Name"] = PNC;

                        ResultsRow[Month.ToString()] = QuantityPNC.ToString() + ":" + Math.Round(QuantityPNC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                        USE.Rows.Add(ResultsRow);
                    }
                    else
                    {
                        ResultsRow[Month.ToString()] = QuantityPNC.ToString() + ":" + Math.Round(QuantityPNC * DeltaCost, 4, MidpointRounding.AwayFromZero).ToString();
                    }

                    if (ECCCtoCalc)
                    {
                        if (ECCCtoCalcSpec)
                        {
                            ECCCHelp = PNCRow.Cells["OLD ANC"].Value.ToString();
                            if (ECCCHelp != "")
                            {
                                ECCCHelp = ECCCHelp.Remove(0, 5);
                                ECCCHelp = ECCCHelp.Remove(ECCCHelp.Length - 1, 1);
                                ECCCSeconds = decimal.Parse(ECCCHelp);
                            }
                            else
                            {
                                ECCCSeconds = 0;
                            }
                        }
                        ECCC = ECCC + (QuantityPNC * ECCCCost * ECCCSeconds);
                    }
                }
            }

            AddValueToDataGrid(Quantity, Savings, ECCC, Month, ECCCtoCalc, "USE");
            Quantity = 0;
            QuantityPNC = 0;
            Savings = 0;
            ECCC = 0;

            SumDataGridView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Funkcje pomocnicze//

        //Czyszczensie kolumny dla danego miesiąca w USE
        private void ClearColumnInUSE(int MonthCalc)
        {
            foreach (DataRow Row in USE.Rows)
            {
                Row[MonthCalc] = "";
            }
        }

        //Sumowanie wierszy z Datagridów do sumy w poszczególnych Rewizjach:
        private void SumDataGridView()
        {
            DataGridView QuantityGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
            DataGridView SavingsGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
            DataGridView ECCCGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

            decimal QuantitySum = 0;
            decimal SavingsSum = 0;
            decimal ECCCSum = 0;
            int GridRow = 0;
            int GridColumn = 0;

            int BU = RevisionStartMonth["BU"];
            int EA1 = RevisionStartMonth["EA1"];
            int EA2 = RevisionStartMonth["EA2"];
            int EA3 = RevisionStartMonth["EA3"];

            int[] Rev = new int[5];
            Rev[0] = BU;        //1
            Rev[1] = EA1;       //3
            Rev[2] = EA2;       //6 
            Rev[3] = EA3;       //9
            Rev[4] = 13;        //13

            for (int RevRow = 0; RevRow < 5; RevRow++)
            {
                GridColumn = Rev[RevRow];
                for (int Column = 1; Column < GridColumn; Column++)
                {
                    if (QuantityGrid.Rows[0].Cells[Column.ToString()].Value != null && QuantityGrid.Rows[0].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        QuantitySum = QuantitySum + decimal.Parse(QuantityGrid.Rows[0].Cells[Column.ToString()].Value.ToString());
                    }
                    if (SavingsGrid.Rows[0].Cells[Column.ToString()].Value != null && SavingsGrid.Rows[0].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        SavingsSum = SavingsSum + decimal.Parse(SavingsGrid.Rows[0].Cells[Column.ToString()].Value.ToString());
                    }
                    if (ECCCGrid.Rows[0].Cells[Column.ToString()].Value != null && ECCCGrid.Rows[0].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        ECCCSum = ECCCSum + decimal.Parse(ECCCGrid.Rows[0].Cells[Column.ToString()].Value.ToString());
                    }
                }

                if (RevRow == 0)
                {
                    GridRow = 4;
                }
                else if (RevRow == 1)
                {
                    GridRow = 3;
                }
                else if (RevRow == 2)
                {
                    GridRow = 2;
                }
                else if (RevRow == 3)
                {
                    GridRow = 1;
                }
                else
                {
                    GridRow = 0;
                }

                for (int Column = GridColumn; Column <= 12; Column++)
                {
                    if (QuantityGrid.Rows[GridRow].Cells[Column.ToString()].Value != null && QuantityGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        QuantitySum = QuantitySum + decimal.Parse(QuantityGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString());
                    }
                    if (SavingsGrid.Rows[GridRow].Cells[Column.ToString()].Value != null && SavingsGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        SavingsSum = SavingsSum + decimal.Parse(SavingsGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString());
                    }
                    if (ECCCGrid.Rows[GridRow].Cells[Column.ToString()].Value != null && ECCCGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString() != "")
                    {
                        ECCCSum = ECCCSum + decimal.Parse(ECCCGrid.Rows[GridRow].Cells[Column.ToString()].Value.ToString());
                    }
                }

                if (QuantitySum != 0)
                {
                    QuantityGrid.Rows[GridRow].Cells["Sum:"].Value = QuantitySum;
                    SavingsGrid.Rows[GridRow].Cells["Sum:"].Value = SavingsSum;
                    if (ECCCSum != 0)
                    {
                        ECCCGrid.Rows[GridRow].Cells["Sum:"].Value = ECCCSum;
                    }
                    else
                    {
                        ECCCGrid.Rows[GridRow].Cells["Sum:"].Value = "";
                    }
                }
                else
                {
                    QuantityGrid.Rows[GridRow].Cells["Sum:"].Value = "";
                    SavingsGrid.Rows[GridRow].Cells["Sum:"].Value = "";
                    ECCCGrid.Rows[GridRow].Cells["Sum:"].Value = "";
                }

                QuantitySum = 0;
                SavingsSum = 0;
                ECCCSum = 0;
            }

        }

        //Dodanie wyliczonych wartości do DataGrid 
        private void AddValueToDataGrid(decimal Quantity, decimal Savings, decimal ECCC, int Month, bool ECCCCheck, string Revision)
        {
            DataGridView QuantityGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
            DataGridView SavingsGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
            DataGridView ECCCGrid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

            int Row = DataGridViewRowsNumber[Revision];

            QuantityGrid.Rows[Row].Cells[Month.ToString()].Value = Math.Round(Quantity, MidpointRounding.AwayFromZero);
            SavingsGrid.Rows[Row].Cells[Month.ToString()].Value = Math.Round(Savings, MidpointRounding.AwayFromZero);
            if (ECCCCheck)
            {
                ECCCGrid.Rows[Row].Cells[Month.ToString()].Value = Math.Round(ECCC, MidpointRounding.AwayFromZero);
            }
        }

        //Wyciągnięcie z Bazy ile kosztuje Sekunda do danej akcji
        private decimal ECCCCostSecond(decimal YearToCalc, bool CarryOver)
        {
            DataTable ECCC = new DataTable();
            DataRow ECCCYear;
            decimal Year;
            decimal SecondCost = 0;
            string LinkECCC;

            if (!CarryOver)
            {
                //Jak to nie jest akcja CarryOver to wyciągnij koszt sekundy dla danego roku 
                Year = YearToCalc;
            }
            else
            {
                // Dla akcji CarryOver bierzemy koszt Sekundy z roku wczesniej 
                Year = YearToCalc - 1;
            }

            LinkECCC = ImportData.Load_Link("Kurs");

            ImportData.Load_TxtToDataTable(ref ECCC, LinkECCC);

            ECCCYear = ECCC.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (ECCCYear != null)
            {
                SecondCost = decimal.Parse(ECCCYear["ECCC"].ToString());
            }


            return SecondCost;
        }

        //Wyciągnięcie z bazy danych ilości ANC używanych w akcji:
        private DataTable LoadQuantityANCTable(string Revision, decimal YearToCalc)
        {
            DataTable ANCQuantity = new DataTable();
            DataTable QuantityTable = new DataTable();
            DataRow FoundANCBase;
            string LinkANC;
            int RevisionStart;
            string BaseColumnName;
            string ANC;

            RevisionStart = RevisionStartMonth[Revision];

            //Tworzenie column
            ANCQuantity.Columns.Add("ANC", typeof(String));
            for (int counter = RevisionStart; counter <= 12; counter++)
            {
                ANCQuantity.Columns.Add(counter.ToString(), typeof(Decimal));
            }

            //Ładownaie linka do BU ANC 
            LinkANC = ImportData.Load_Link("ANC");
            //Ładowanie pliku z ilościami BUANC do DataTable
            ImportData.Load_TxtToDataTable(ref QuantityTable, LinkANC);

            for (int ANCRow = 1; ANCRow <= ANCChangeNumber; ANCRow++)
            {
                // Wyszukanie i dodanie do tabeli ANC Old 
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + ANCRow.ToString(), true).First()).Text != "")
                {
                    DataRow NewRow = ANCQuantity.NewRow();
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + ANCRow.ToString(), true).First()).Text;
                    NewRow["ANC"] = ANC;

                    FoundANCBase = QuantityTable.Select(string.Format("BUANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    if (FoundANCBase != null)
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            BaseColumnName = Revision + "/" + counter.ToString() + "/" + YearToCalc.ToString();
                            if (FoundANCBase[BaseColumnName].ToString() != "")
                            {
                                NewRow[counter.ToString()] = decimal.Parse(FoundANCBase[BaseColumnName].ToString());
                            }
                            else
                            {
                                NewRow[counter.ToString()] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            NewRow[counter.ToString()] = 0;
                        }
                    }
                    ANCQuantity.Rows.Add(NewRow);
                }
                // Wyszukanie i dodanie do tabeli ANC New
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + ANCRow.ToString(), true).First()).Text != "")
                {
                    DataRow NewRow = ANCQuantity.NewRow();
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + ANCRow.ToString(), true).First()).Text;
                    NewRow["ANC"] = ANC;

                    FoundANCBase = QuantityTable.Select(string.Format("BUANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    if (FoundANCBase != null)
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            BaseColumnName = Revision + "/" + counter.ToString() + "/" + YearToCalc.ToString();
                            if (FoundANCBase[BaseColumnName].ToString() != "")
                            {
                                NewRow[counter.ToString()] = decimal.Parse(FoundANCBase[BaseColumnName].ToString());
                            }
                            else
                            {
                                NewRow[counter.ToString()] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            NewRow[counter.ToString()] = 0;
                        }
                    }
                    ANCQuantity.Rows.Add(NewRow);
                }
                // Wyszukanie i dodanie do tabeli ANC Next 
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + ANCRow.ToString(), true).First()).Text != "")
                {
                    DataRow NewRow = ANCQuantity.NewRow();
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + ANCRow.ToString(), true).First()).Text;
                    NewRow["ANC"] = ANC;

                    FoundANCBase = QuantityTable.Select(string.Format("BUANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    if (FoundANCBase != null)
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            BaseColumnName = Revision + "/" + counter.ToString() + "/" + YearToCalc.ToString();
                            if (FoundANCBase[BaseColumnName].ToString() != "")
                            {
                                NewRow[counter.ToString()] = decimal.Parse(FoundANCBase[BaseColumnName].ToString());
                            }
                            else
                            {
                                NewRow[counter.ToString()] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            NewRow[counter.ToString()] = 0;
                        }
                    }
                    ANCQuantity.Rows.Add(NewRow);
                }

            }
            return ANCQuantity;
        }

        //Wyciągnienie z bazy danych ilości ANC użwanych w akcji dla USE
        private DataTable LoadQuantityANCTableUSE(int Month, decimal YearToCalc)
        {
            DataTable ANCQuantity = new DataTable();
            DataTable QuantityTable = new DataTable();
            DataRow FoundANCBase;
            string LinkANC;
            string BaseColumnName;
            string ANC;


            //Tworzenie column
            ANCQuantity.Columns.Add("ANC", typeof(String));
            ANCQuantity.Columns.Add(Month.ToString(), typeof(Decimal));


            //Ładownaie linka do BU ANC 
            LinkANC = ImportData.Load_Link("ANCMonth");
            //Ładowanie pliku z ilościami BUANC do DataTable
            ImportData.Load_TxtToDataTable(ref QuantityTable, LinkANC);

            for (int ANCRow = 1; ANCRow <= ANCChangeNumber; ANCRow++)
            {
                // Wyszukanie i dodanie do tabeli ANC New
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + ANCRow.ToString(), true).First()).Text != "")
                {
                    DataRow NewRow = ANCQuantity.NewRow();
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + ANCRow.ToString(), true).First()).Text;
                    NewRow["ANC"] = ANC;

                    FoundANCBase = QuantityTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    if (FoundANCBase != null)
                    {
                        BaseColumnName = Month.ToString() + "/" + YearToCalc.ToString();
                        if (FoundANCBase[BaseColumnName].ToString() != "")
                        {
                            NewRow[Month.ToString()] = decimal.Parse(FoundANCBase[BaseColumnName].ToString());
                        }
                        else
                        {
                            NewRow[Month.ToString()] = 0;
                        }
                    }
                    else
                    {
                        NewRow[Month.ToString()] = 0;
                    }
                    ANCQuantity.Rows.Add(NewRow);
                }
                // Wyszukanie i dodanie do tabeli ANC Next 
                if (((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + ANCRow.ToString(), true).First()).Text != "")
                {
                    DataRow NewRow = ANCQuantity.NewRow();
                    ANC = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + ANCRow.ToString(), true).First()).Text;
                    NewRow["ANC"] = ANC;

                    FoundANCBase = QuantityTable.Select(string.Format("ANC LIKE '%{0}%'", ANC)).FirstOrDefault();
                    if (FoundANCBase != null)
                    {
                        BaseColumnName = Month.ToString() + "/" + YearToCalc.ToString();
                        if (FoundANCBase[BaseColumnName].ToString() != "")
                        {
                            NewRow[Month.ToString()] = decimal.Parse(FoundANCBase[BaseColumnName].ToString());
                        }
                        else
                        {
                            NewRow[Month.ToString()] = 0;
                        }
                    }
                    else
                    {
                        NewRow[Month.ToString()] = 0;
                    }
                    ANCQuantity.Rows.Add(NewRow);
                }

            }
            return ANCQuantity;
        }

        //Wyciągnięcie z bazy danych ilości PNC używanych w akcji:
        private DataTable LoadQuantityPNCTable(string Revision, decimal YearToCalc)
        {
            DataTable PNCQuantity = new DataTable();
            DataTable QuantityTable = new DataTable();
            DataRow FoundPNCBase;
            DataGridView dg_PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
            string LinkPNC;
            int RevisionStart;
            string BaseColumnName;
            string PNC;

            RevisionStart = RevisionStartMonth[Revision];

            //Tworzenie column
            PNCQuantity.Columns.Add("PNC", typeof(String));
            for (int counter = RevisionStart; counter <= 12; counter++)
            {
                PNCQuantity.Columns.Add(counter.ToString(), typeof(Decimal));
            }

            //Ładownaie linka do BU ANC 
            LinkPNC = ImportData.Load_Link("PNC");
            //Ładowanie pliku z ilościami BUANC do DataTable
            ImportData.Load_TxtToDataTable(ref QuantityTable, LinkPNC);

            foreach (DataGridViewRow Row in dg_PNC.Rows)
            {
                if (Row.Cells[0].Value != null && Row.Cells[0].Value.ToString() != "")
                {
                    DataRow NewRow = PNCQuantity.NewRow();
                    PNC = Row.Cells[0].Value.ToString();

                    NewRow["PNC"] = PNC;
                    FoundPNCBase = QuantityTable.Select(string.Format("BUPNC LIKE '%{0}%'", PNC)).FirstOrDefault();
                    if (FoundPNCBase != null)
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            BaseColumnName = Revision + "/" + counter.ToString() + "/" + YearToCalc.ToString();

                            if (FoundPNCBase[BaseColumnName].ToString() != "")
                            {
                                NewRow[counter.ToString()] = decimal.Parse(FoundPNCBase[BaseColumnName].ToString());
                            }
                            else
                            {
                                NewRow[counter.ToString()] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int counter = RevisionStart; counter <= 12; counter++)
                        {
                            NewRow[counter.ToString()] = 0;
                        }
                    }
                    PNCQuantity.Rows.Add(NewRow);
                }
            }


            return PNCQuantity;
        }

        private DataTable LoadQuantityACNSpecMass(string Revision, decimal YearToCalc)
        {
            DataTable Quantity = new DataTable();
            DataTable QuantityFinal = new DataTable();
            string link;

            if (Revision == "USE")
            {
                link = ImportData.Load_Link("SumPNC");
            }
            else
            {
                link = ImportData.Load_Link("SumPNCBU");
            }

            ImportData.Load_TxtToDataTable(ref Quantity, link);

            QuantityFinal = Quantity.Clone();
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

        //Wyciągnięcie z bazy danych ilości PNC używanych w akcji dla USE
        private DataTable LoadQuantityPNCTableUSE(int Month, decimal YearToCalc)
        {
            DataTable PNCQuantity = new DataTable();
            DataTable QuantityTable = new DataTable();
            DataRow FoundPNCBase;
            DataGridView dg_PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
            string LinkPNC;
            string BaseColumnName;
            string PNC;

            //Tworzenie column
            PNCQuantity.Columns.Add("PNC", typeof(String));
            PNCQuantity.Columns.Add(Month.ToString(), typeof(Decimal));

            //Ładownaie linka do ANC 
            LinkPNC = ImportData.Load_Link("PNCMonth");
            //Ładowanie pliku z ilościami BUANC do DataTable
            ImportData.Load_TxtToDataTable(ref QuantityTable, LinkPNC);

            foreach (DataGridViewRow Row in dg_PNC.Rows)
            {
                if (Row.Cells[0].Value != null && Row.Cells[0].Value.ToString() != "")
                {
                    DataRow NewRow = PNCQuantity.NewRow();
                    PNC = Row.Cells[0].Value.ToString();

                    NewRow["PNC"] = PNC;
                    FoundPNCBase = QuantityTable.Select(string.Format("PNC LIKE '%{0}%'", PNC)).FirstOrDefault();
                    if (FoundPNCBase != null)
                    {
                        BaseColumnName = Month.ToString() + "/" + YearToCalc.ToString();

                        if (FoundPNCBase[BaseColumnName].ToString() != "")
                        {
                            NewRow[Month.ToString()] = decimal.Parse(FoundPNCBase[BaseColumnName].ToString());
                        }
                        else
                        {
                            NewRow[Month.ToString()] = 0;
                        }

                    }
                    else
                    {
                        NewRow[Month.ToString()] = 0;
                    }
                    PNCQuantity.Rows.Add(NewRow);
                }
            }
            return PNCQuantity;
        }

        //Czyszczenie DatagridView dla danej rewizji
        private void ClearDataGridViewForRevision(string Revision)
        {
            int RevisionRow;

            DataGridView Saving = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
            DataGridView Quantity = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
            DataGridView ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

            RevisionRow = DataGridViewRowsNumber[Revision];

            for (int counter = 0; counter < 12; counter++)
            {
                Saving.Rows[RevisionRow].Cells[counter].Value = "";
                Quantity.Rows[RevisionRow].Cells[counter].Value = "";
                ECCC.Rows[RevisionRow].Cells[counter].Value = "";
            }
        }

        //Do Jakiego Miesiąca ma liczyć
        private int CalcFinish_Revision(string Revision, bool CarryOver)
        {
            int MonthStartAction;
            int RevisionStart;


            RevisionStart = RevisionStartMonth[Revision];
            MonthStartAction = MonthActionStart();

            if (!CarryOver)
            {
                //Dla Akcji z danego roku
                return 12;
            }
            else
            {
                //Dla Akcji Carry Over
                return MonthStartAction - 1;
            }
        }

        //Od Jakiego Miesiąca ma zacząć liczyć 
        private int CalcStart_Revision(string Revision, bool CarryOver)
        {
            int MonthStartAction;
            int RevisionStart;


            RevisionStart = RevisionStartMonth[Revision];
            MonthStartAction = MonthActionStart();

            if (!CarryOver)
            {
                //Dla Akcji z danego roku
                if (MonthStartAction <= RevisionStart)
                {
                    return RevisionStart;
                }
                else
                {
                    return MonthStartAction;
                }
            }
            else
            {
                //Dla akcji Carry Over
                return RevisionStart;
            }
        }

        //Sprawdzenie miesiąca rozpoczęcia akcji 
        private int MonthActionStart()
        {
            int MonthStart = 0;
            ComboBox MonthAction = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First();

            MonthStart = Month[MonthAction.GetItemText(MonthAction.SelectedItem)];

            return MonthStart;
        }

        //Sprawdzenie czy rok przeliczenia zgadza się z Rokiem rozpoczęcia akcji 
        private bool CheckYearNewAction(decimal YearToCalc)
        {
            NumericUpDown YearAction = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First();

            if (YearToCalc == YearAction.Value)
            {
                return true;
            }

            return false;
        }

        //Sprawdzenie czy rok zgadza się z Rokiem -1 (Carry Over) rozpoczęcia akcji 
        private bool CheckYearCarryOver(decimal YearToCalc)
        {
            NumericUpDown YearAction = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First();

            if (YearToCalc - 1 == YearAction.Value)
            {
                return true;
            }
            return false;
        }

        //Sprawdzanie czy dana Devizja ma pozwolenie na przeliczanie akcji
        private bool DevisionPermision(DataRow YearRow)
        {
            //Zmienne
            bool Approve = false;
            //Uzywane z Formy
            ComboBox Devision = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Devision", true).First();

            if (Devision.GetItemText(Devision.SelectedItem) == "Electronic")
            {
                if (YearRow["EleApp"].ToString() == "Close")
                {
                    Approve = true;
                }
            }
            if (Devision.GetItemText(Devision.SelectedItem) == "Mechanic")
            {
                if (YearRow["MechApp"].ToString() == "Close")
                {
                    Approve = true;
                }
            }
            if (Devision.GetItemText(Devision.SelectedItem) == "NVR")
            {
                if (YearRow["NVRApp"].ToString() == "Close")
                {
                    Approve = true;
                }
            }

            return Approve;
        }

        //Sprawdzenie czy dana rewizja ma pozwolenie na przeliczenie akcji
        private bool RevisionPermission(DataRow YearRow, string Rewizja)
        {
            bool Revision = false;

            if (YearRow[Rewizja].ToString() == "Open")
            {
                Revision = true;
                return Revision;
            }
            return false;
        }

        //Sprawdzenie czy dany Miesiąc można przekalkulować
        private bool MonthPermission(DataRow YearRow, int Month)
        {
            bool MonthPermission = false;

            if (YearRow[Month.ToString()].ToString() == "Open")
            {
                MonthPermission = true;
                return MonthPermission;
            }

            return false;
        }

        //Sprawdzenie jakiego typu jest akcja
        private string CalculationTypeCheck()
        {
            CheckBox ANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANC", true).First();
            CheckBox ANCSpec = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANCby", true).First();
            CheckBox PNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNC", true).First();
            CheckBox PNCSpec = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First();

            if (ANC.Checked)
            {
                return "ANC";
            }
            else if (ANCSpec.Checked)
            {
                return "ANCSpec";
            }
            else if (PNC.Checked)
            {
                return "PNC";
            }
            else if (PNCSpec.Checked)
            {
                return "PNCSpec";
            }

            return "";
        }


        //Sprawdzenie Delty którą ma brać do kalkulacji
        private bool DeltaIFcanCalculate(bool CarryOver, int MonthToCalc, int RevisionStart, int MonthAction)
        {
            bool Delta;

            if (CarryOver)
            {
                if (MonthAction > DateTime.Now.Month)
                    Delta = false;
                else
                    Delta = true;
            }
            else if (MonthAction <= RevisionStart)
            {
                Delta = true;
            }
            else
            {
                Delta = false;
            }

            return Delta;
        }
    }
}
