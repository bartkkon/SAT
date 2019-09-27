using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    public class STKCalculation
    {
        Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();
        Dictionary<string, decimal> STKDictionary = new Dictionary<string, decimal>();

        readonly MainProgram mainProgram;
        readonly Data_Import ImportData;
        private readonly int ANCChangeNumber;

        public STKCalculation(MainProgram mainProgram, Data_Import ImportData, int ANCChangeNumber)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            this.ANCChangeNumber = ANCChangeNumber;
        }

        public void STKRefresh()
        {
            STKCalc();
        }

        public Dictionary<string, string> GetIDCO()
        {
            return IDCODictionary;
        }

        private void STKCalc()
        {
            //Deklaracja zmiennych
            DataTable STK = new DataTable();
            decimal ActionYear;

            //
            ActionYear = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value;

            //Ładowanie Dazy danych z STK do tabeli
            LoadSTK(ActionYear);

            //Wpisanie STK dla ANC
            LoadSTKtoAction();

            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked)
            {
                //Wpisywanie STK dla ANC w Tabeli z PNC - PNCSpec
                LoadSTKtoPNCSpec();
            }
        }


        //Funkcje pomocnicze

        //Ładowanie używanych STK do Słownika plus Ładowanie IDCO do słownika 
        private void LoadSTK(decimal Year)
        {
            //Deklaracja zmiennych
            DataTable STK = new DataTable();
            DataRow FoundRow;
            string LinkSTK;
            string[] ANC = new string[3];
            string[] ANCSpec = new string[2];
            string STKYear;
            decimal STKValue;
            bool STKCheck;
            bool Zero = false;

            //
            LinkSTK = ImportData.Load_Link("STK");
            ImportData.Load_TxtToDataTable(ref STK, LinkSTK);

            //Sprawdzenie czy STK na dany rok jest już w bazie czy nie ma - jak nie ma daje wybrór użytkowanikowi aby użył z poprzedniego roku
            do
            {
                DataColumnCollection Columns = STK.Columns;
                if (!Columns.Contains(Year.ToString()))
                {
                    STKCheck = true;
                    DialogResult dialogResult = MessageBox.Show("STK for this Year not exist, Do you want to take for calculation STK from Year Before?", "STK Issue", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Zero = false;
                        Year = Year - 1;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Zero = true;
                        STKCheck = false;
                    }
                }
                else
                {
                    STKCheck = false;
                }
            } while (STKCheck);

            STKYear = "STK/" + Year.ToString();

            //Dodanie do słownika ANC z Old/New 
            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                ANC[0] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First()).Text;
                ANC[1] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First()).Text;
                ANC[2] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First()).Text;

                for (int counter2 = 0; counter2 < 3; counter2++)
                {
                    if (ANC[counter2].ToString() != "")
                    {
                        if (!STKDictionary.ContainsKey(ANC[counter2]))
                        {
                            if (!Zero)
                            {
                                FoundRow = STK.Select(string.Format("ANC LIKE '%{0}%'", ANC[counter2])).FirstOrDefault();
                                if (FoundRow != null)
                                {
                                    if (FoundRow[STKYear].ToString() != "")
                                    {
                                        STKValue = decimal.Parse(FoundRow[STKYear].ToString());
                                        STKDictionary.Add(ANC[counter2], STKValue);
                                        IDCODictionary.Add(ANC[counter2], FoundRow["IDCO"].ToString());
                                    }
                                    else
                                    {
                                        STKDictionary.Add(ANC[counter2], 0);
                                        IDCODictionary.Add(ANC[counter2], "");
                                    }
                                }
                                else
                                {
                                    STKDictionary.Add(ANC[counter2], 0);
                                    IDCODictionary.Add(ANC[counter2], "");
                                }
                            }
                            else
                            {
                                STKDictionary.Add(ANC[counter2], 0);
                                IDCODictionary.Add(ANC[counter2], "");
                            }
                        }
                    }
                }
            }

            //Jeśli jest PNCSpec to musi przelecieć kolejną tabele aby dodać brakujące ANC
            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked)
            {
                DataGridView PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

                DataGridViewColumnCollection Columns = PNC.Columns;
                if (Columns.Contains("OLD ANC"))
                {

                    foreach (DataGridViewRow Row in PNC.Rows)
                    {
                        if (Row.Cells["PNC"].Value == null || Row.Cells["PNC"].Value.ToString() == "")
                        {
                            ANCSpec[0] = Row.Cells["OLD ANC"].Value.ToString();
                            ANCSpec[1] = Row.Cells["NEW ANC"].Value.ToString();

                            for (int counter = 0; counter < 2; counter++)
                            {
                                if (ANCSpec[counter] != "")
                                {
                                    if (!STKDictionary.ContainsKey(ANCSpec[counter]))
                                    {
                                        if (!Zero)
                                        {
                                            FoundRow = STK.Select(string.Format("ANC LIKE '%{0}%'", ANCSpec[counter])).First();
                                            if (FoundRow != null || FoundRow[STKYear].ToString() != "")
                                            {
                                                STKValue = decimal.Parse(FoundRow[STKYear].ToString());
                                                STKDictionary.Add(ANCSpec[counter], STKValue);
                                                IDCODictionary.Add(ANCSpec[counter], FoundRow["IDCO"].ToString());

                                            }
                                            else
                                            {
                                                STKDictionary.Add(ANCSpec[counter], 0);
                                                IDCODictionary.Add(ANCSpec[counter], "");
                                            }
                                        }
                                        else
                                        {
                                            STKDictionary.Add(ANCSpec[counter], 0);
                                            IDCODictionary.Add(ANCSpec[counter], "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Ładowanie STK dla ANC 
        private void LoadSTKtoAction()
        {
            TextBox OldANC;
            TextBox OldANCQ;
            TextBox NewANC;
            TextBox NewANCQ;
            Label OldSTK;
            Label NewSTK;
            Label Delta;

            string ANCOLD;
            string ANCNEW;
            decimal ANCOLDQ;
            decimal ANCNEWQ;
            decimal Old;
            decimal New;

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                OldANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First();
                OldANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANCQ" + counter.ToString(), true).First();
                NewANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First();
                NewANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANCQ" + counter.ToString(), true).First();
                OldSTK = (Label)mainProgram.TabControl.Controls.Find("lab_OldSTK" + counter.ToString(), true).First();
                NewSTK = (Label)mainProgram.TabControl.Controls.Find("lab_NewSTK" + counter.ToString(), true).First();
                Delta = (Label)mainProgram.TabControl.Controls.Find("lab_Delta" + counter.ToString(), true).First();

                ANCOLD = OldANC.Text;
                ANCNEW = NewANC.Text;
                ANCOLDQ = decimal.Parse(OldANCQ.Text);
                ANCNEWQ = decimal.Parse(NewANCQ.Text);

                if (ANCOLD != "")
                {
                    Old = STKDictionary[ANCOLD] * ANCOLDQ;
                }
                else
                {
                    Old = 0;
                }
                if (ANCNEW != "")
                {
                    New = STKDictionary[ANCNEW] * ANCNEWQ;
                }
                else
                {
                    New = 0;
                }

                OldSTK.Text = Old.ToString();
                NewSTK.Text = New.ToString();
                Delta.Text = (Old - New).ToString();

                DeltaColor(Delta);
            }

            DeltaSum();
        }

        //Ładowanie STK do PNCSpec tabeli
        private void LoadSTKtoPNCSpec()
        {
            DataGridView PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
            DataGridViewRow PNCSelect;
            decimal[] STKSum = new decimal[] { 0, 0 };
            decimal[] STK = new decimal[] { 0, 0 };
            decimal[] Q = new decimal[] { 0, 0 };
            decimal DeltaSum = 0;
            decimal Delta = 0;
            string[] ANC = new string[2];
            //DataGridViewRow ANCSelect;

            if (PNC.Columns.Contains("OLD ANC") == true)
            {
                if (PNC.Columns.Contains("OLD STK") == true)
                {
                    PNC.Columns.Remove("OLD STK");
                    PNC.Columns.Remove("NEW STK");
                    PNC.Columns.Remove("Delta");
                }

                PNC.Columns.Add("OLD STK", "OLD STK");
                PNC.Columns.Add("NEW STK", "NEW STK");
                PNC.Columns.Add("Delta", "Delta");
                PNC.Columns["OLD STK"].Width = 65;
                PNC.Columns["OLD STK"].DefaultCellStyle.ForeColor = Color.Red;
                PNC.Columns["NEW STK"].Width = 65;
                PNC.Columns["NEW STK"].DefaultCellStyle.ForeColor = Color.Green;
                PNC.Columns["Delta"].Width = 65;
                PNC.Columns["OLD STK"].SortMode = DataGridViewColumnSortMode.NotSortable;
                PNC.Columns["NEW STK"].SortMode = DataGridViewColumnSortMode.NotSortable;
                PNC.Columns["Delta"].SortMode = DataGridViewColumnSortMode.NotSortable;

                PNCSelect = PNC.Rows[0];

                foreach (DataGridViewRow ANCSelected in PNC.Rows)
                {
                    if (ANCSelected.Cells["PNC"].Value != null && ANCSelected.Cells["PNC"].Value.ToString() != "")
                    {
                        if (ANCSelected.Index != 1)
                        {
                            PNCSelect.Cells["OLD STK"].Value = STKSum[0];
                            PNCSelect.Cells["NEW STK"].Value = STKSum[1];
                            PNCSelect.Cells["Delta"].Value = DeltaSum;
                            STKSum[0] = 0;
                            STKSum[1] = 0;
                            DeltaSum = 0;
                            DeltaColorGrid(PNCSelect.Cells["Delta"]);
                        }
                        PNCSelect = ANCSelected;
                    }
                    else
                    {
                        ANC[0] = ANCSelected.Cells["OLD ANC"].Value.ToString();
                        ANC[1] = ANCSelected.Cells["NEW ANC"].Value.ToString();
                        if (ANCSelected.Cells["OLD Q"].Value.ToString() != "")
                        {
                            Q[0] = decimal.Parse(ANCSelected.Cells["OLD Q"].Value.ToString());
                        }
                        else
                        {
                            Q[0] = 0;
                        }
                        if (ANCSelected.Cells["NEW Q"].Value.ToString() != "")
                        {
                            Q[1] = decimal.Parse(ANCSelected.Cells["NEW Q"].Value.ToString());
                        }
                        else
                        {
                            Q[1] = 0;
                        }


                        for (int counter = 0; counter < 2; counter++)
                        {
                            if (ANC[counter] != "")
                            {
                                STK[counter] = Math.Round(STKDictionary[ANC[counter]] * Q[counter], 4, MidpointRounding.AwayFromZero);
                                STKSum[counter] = STKSum[counter] + STK[counter];
                            }
                            else
                            {
                                STK[counter] = 0;
                            }
                        }

                        Delta = STK[0] - STK[1];
                        DeltaSum = DeltaSum + Delta;

                        ANCSelected.Cells["OLD STK"].Value = STK[0];
                        ANCSelected.Cells["NEW STK"].Value = STK[1];
                        ANCSelected.Cells["Delta"].Value = Delta;
                        DeltaColorGrid(ANCSelected.Cells["Delta"]);

                        if (ANCSelected.Index == PNC.Rows.Count - 1)
                        {
                            PNCSelect.Cells["OLD STK"].Value = STKSum[0];
                            PNCSelect.Cells["NEW STK"].Value = STKSum[1];
                            PNCSelect.Cells["Delta"].Value = DeltaSum;
                            DeltaColorGrid(PNCSelect.Cells["Delta"]);
                        }
                    }
                }
            }
        }

        //Sprawdzenie czy delta jest dodatnia czy ujemna i dobranie koloru
        private void DeltaColor(Label Delta)
        {
            decimal DeltaCost;

            DeltaCost = decimal.Parse(Delta.Text);

            if (DeltaCost > 0)
            {
                Delta.ForeColor = Color.Green;
            }
            else if (DeltaCost < 0)
            {
                Delta.ForeColor = Color.Red;
            }
            else if (DeltaCost == 0)
            {
                Delta.ForeColor = Color.Black;
            }
        }

        private void DeltaColorGrid(DataGridViewCell Delta)
        {
            decimal DeltaCost;

            DeltaCost = decimal.Parse(Delta.Value.ToString());

            if (DeltaCost > 0)
            {
                Delta.Style.ForeColor = Color.Green;
            }
            else if (DeltaCost < 0)
            {
                Delta.Style.ForeColor = Color.Red;
            }
            else if (DeltaCost == 0)
            {
                Delta.Style.ForeColor = Color.Black;
            }
        }

        private void DeltaSum()
        {
            Label DeltaSum = (Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First();
            Label OLDSum = (Label)mainProgram.TabControl.Controls.Find("lab_OldSum", true).First();
            Label NewSum = (Label)mainProgram.TabControl.Controls.Find("lab_NewSum", true).First();

            decimal Delta = 0;
            decimal Old = 0;
            decimal New = 0;

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                Label DeltaANC = (Label)mainProgram.TabControl.Controls.Find("lab_Delta" + counter.ToString(), true).First();
                Label OLDANC = (Label)mainProgram.TabControl.Controls.Find("lab_OldSTK" + counter.ToString(), true).First();
                Label NewANC = (Label)mainProgram.TabControl.Controls.Find("lab_NewSTK" + counter.ToString(), true).First();

                Delta = Delta + decimal.Parse(DeltaANC.Text);
                Old = Old + decimal.Parse(OLDANC.Text);
                New = New + decimal.Parse(NewANC.Text);
            }

            DeltaSum.Text = Delta.ToString();
            OLDSum.Text = Old.ToString();
            NewSum.Text = New.ToString();

            DeltaColor(DeltaSum);
        }
    }
}
