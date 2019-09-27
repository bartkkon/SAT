using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    public class LoadAction
    {

        MainProgram mainProgram;
        Data_Import ImportData;
        Action action;

        DataTable USE = new DataTable();
        DataTable BU = new DataTable();
        DataTable EA1 = new DataTable();
        DataTable EA2 = new DataTable();
        DataTable EA3 = new DataTable();

        Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();

        public LoadAction(MainProgram mainProgram, Data_Import ImportData, Action action)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            this.action = action;
        }

        public void Load(string ActionToLoad)
        {
            //try
            //{
            DataRow Action;
            decimal Year;

            //Z jakiego roku ma być akcja
            Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;

            //Ładowanie Akcji 
            Action = ImportRowAction(ActionToLoad, Year);

            if (Action == null)
            {
                MessageBox.Show("Please select action again!", "Something go wrong!");
                return;
            }

            ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text = Action["Name"].ToString();
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Text = Action["Name"].ToString();
            ((TextBox)mainProgram.TabControl.Controls.Find("tb_Description", true).First()).Text = (Action["Description"].ToString()).Replace("/n", Environment.NewLine);
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value = decimal.Parse(Action["StartYear"].ToString());
            ((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text = Action["PNCANCPersent"].ToString();
            ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First()).Text = Action["StartMonth"].ToString();

            //Ustawienie Dewizji
            Devision(Action);

            //Jeśli akcja jest Carry Over ustawia odpowiednie przyciski
            CarryOverButton(decimal.Parse(Action["StartYear"].ToString()), Year);

            //Fabryka 
            Plant(Action["Factory"].ToString());

            //Platforny DMD czy D45
            Platform(Action["Platform"].ToString());

            //Sprawdzenie statusu akcji czy jest active czy idea
            Active_Idea_Action(Action["Status"].ToString());

            //Instalacje 
            Instalation(Action["Installation"].ToString());

            //Lider Akcji
            Leader(Action["Leader"].ToString());

            //Dodanie ANC
            ANCADD(Action);

            //Calcby plus dodanie ECCC i specyficznych rzeczy odnośnie danych akcji i ich sposobu kalkulacji
            CalcBy(Action);

            //Uzupełnianie Gridów odnośnie Quantity, Savings, ECCC
            GridLoad(Action, Year);

            //IDCO ładowanie 
            IDCO(Action);

            //Tworzenie kolumn W tabeli do zapisanych danych odnośnie liczenia
            CreateColumnPerANC("USE");
            CreateColumnPerANC("BU");
            CreateColumnPerANC("EA1");
            CreateColumnPerANC("EA2");
            CreateColumnPerANC("EA3");

            //Wypełnij tabele jeśli są dane
            PerANC_PNCToTable(Action, Year);
            //}
            //catch (Exception ex)
            //{
            //    LogSingleton.Instance.SaveLog(ex.Message);
            //}
        }

        public DataTable ReturnTable(string Rew)
        {
            if (Rew == "USE")
                return USE;
            else if (Rew == "BU")
                return BU;
            else if (Rew == "EA1")
                return EA1;
            else if (Rew == "EA2")
                return EA2;
            else if (Rew == "EA3")
                return EA3;
            else
                return null;
        }

        //Funkcje pomocnicze

        private void PerANC_PNCToTable(DataRow Action, decimal Year)
        {
            string Carry = "";

            if ((Year-1).ToString() == Action["StartYear"].ToString())
            {
                Carry = "Carry";
            }

            if (Action["PerUSE" + Carry].ToString() != "")
            {
                string[] Help = Action["PerUSE" + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = USE.NewRow();
                        string[] Help3 = Help2.Split('|');
                        for (int counter = 0; counter <= 12; counter++)
                        {
                            NewRow[counter] = Help3[counter];
                        }
                        USE.Rows.Add(NewRow);
                    }
                }
            }
            if (Action["PerBU" + Carry].ToString() != "")
            {
                string[] Help = Action["PerBU" + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = BU.NewRow();
                        string[] Help3 = Help2.Split('|');
                        for (int counter = 0; counter <= 12; counter++)
                        {
                            NewRow[counter] = Help3[counter];
                        }
                        BU.Rows.Add(NewRow);
                    }
                }
            }
            if (Action["PerEA1" + Carry].ToString() != "")
            {
                string[] Help = Action["PerEA1" + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = EA1.NewRow();
                        string[] Help3 = Help2.Split('|');
                        for (int counter = 0; counter <= 10; counter++)
                        {
                            NewRow[counter] = Help3[counter];
                        }
                        EA1.Rows.Add(NewRow);
                    }
                }
            }
            if (Action["PerEA2" + Carry].ToString() != "")
            {
                string[] Help = Action["PerEA2" + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = EA2.NewRow();
                        string[] Help3 = Help2.Split('|');
                        for (int counter = 0; counter <= 7; counter++)
                        {
                            NewRow[counter] = Help3[counter];
                        }
                        EA2.Rows.Add(NewRow);
                    }
                }
            }
            if (Action["PerEA3" + Carry].ToString() != "")
            {
                string[] Help = Action["PerEA3" + Carry].ToString().Split('/');
                foreach (string Help2 in Help)
                {
                    if (Help2 != "")
                    {
                        DataRow NewRow = EA3.NewRow();
                        string[] Help3 = Help2.Split('|');
                        for (int counter = 0; counter <= 4; counter++)
                        {
                            NewRow[counter] = Help3[counter];
                        }
                        EA3.Rows.Add(NewRow);
                    }
                }
            }
        }

        private void CreateColumnPerANC(string Rew)
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
                USE.Columns.Add(Name);
                USE.Columns.Add(M1);
                USE.Columns.Add(M2);
                USE.Columns.Add(M3);
                USE.Columns.Add(M4);
                USE.Columns.Add(M5);
                USE.Columns.Add(M6);
                USE.Columns.Add(M7);
                USE.Columns.Add(M8);
                USE.Columns.Add(M9);
                USE.Columns.Add(M10);
                USE.Columns.Add(M11);
                USE.Columns.Add(M12);
            }
            else if (Rew == "BU")
            {
                BU.Columns.Add(Name);
                BU.Columns.Add(M1);
                BU.Columns.Add(M2);
                BU.Columns.Add(M3);
                BU.Columns.Add(M4);
                BU.Columns.Add(M5);
                BU.Columns.Add(M6);
                BU.Columns.Add(M7);
                BU.Columns.Add(M8);
                BU.Columns.Add(M9);
                BU.Columns.Add(M10);
                BU.Columns.Add(M11);
                BU.Columns.Add(M12);
            }
            else if (Rew == "EA1")
            {
                EA1.Columns.Add(Name);
                EA1.Columns.Add(M3);
                EA1.Columns.Add(M4);
                EA1.Columns.Add(M5);
                EA1.Columns.Add(M6);
                EA1.Columns.Add(M7);
                EA1.Columns.Add(M8);
                EA1.Columns.Add(M9);
                EA1.Columns.Add(M10);
                EA1.Columns.Add(M11);
                EA1.Columns.Add(M12);
            }
            else if (Rew == "EA2")
            {
                EA2.Columns.Add(Name);
                EA2.Columns.Add(M6);
                EA2.Columns.Add(M7);
                EA2.Columns.Add(M8);
                EA2.Columns.Add(M9);
                EA2.Columns.Add(M10);
                EA2.Columns.Add(M11);
                EA2.Columns.Add(M12);
            }
            else if (Rew == "EA3")
            {
                EA3.Columns.Add(Name);
                EA3.Columns.Add(M9);
                EA3.Columns.Add(M10);
                EA3.Columns.Add(M11);
                EA3.Columns.Add(M12);
            }
        }

        //ładowanie tabeli z akcjami plus wyciągnięcie akcji która nas interesuje
        private DataRow ImportRowAction(string ActionName, decimal Year)
        {
            string Link;
            DataTable ActionList = new DataTable();
            DataRow[] FoundArry;

            Link = ImportData.Load_Link("Action");

            ImportData.Load_TxtToDataTable(ref ActionList, Link);

            FoundArry = ActionList.Select(string.Format("Name LIKE '%{0}%'", ActionName)).ToArray();

            foreach (DataRow Row in FoundArry.Take(FoundArry.Length))
            {
                if (Row["Name"].ToString() == ActionName && Row["StartYear"].ToString() == Year.ToString())
                {
                    return Row;
                }
                else if (Row["Name"].ToString() == ActionName && Row["StartYear"].ToString() == (Year - 1).ToString())
                {
                    return Row;
                }
            }

            return null;
        }

        //Ustawienie odpowiedniej Dewizji 
        private void Devision(DataRow Action)
        {
            ComboBox DevisionBox = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Devision", true).First();

            if (DevisionBox.Items.Contains(Action["Group"].ToString()))
            {
                int counter = DevisionBox.FindString(Action["Group"].ToString());
                DevisionBox.SelectedIndex = counter;
            }
        }

        //Jeśli akcja jest Carry Over to ustawia przyciski
        private void CarryOverButton(decimal ActionYear, decimal YearOption)
        {
            if (ActionYear == YearOption - 1)
            {
                Button pb_CarryOver = (Button)mainProgram.TabControl.Controls.Find("pb_CarryOver", true).First();
                Button pb_CurrentYear = (Button)mainProgram.TabControl.Controls.Find("pb_CurrentYear", true).First();
                pb_CarryOver.Enabled = true;
                pb_CarryOver.UseVisualStyleBackColor = false;
                pb_CarryOver.BackColor = Color.LightBlue;
                pb_CurrentYear.UseVisualStyleBackColor = true;
            }
        }

        //Ładowanie jakiej fabryki jest akcja
        private void Plant(string Factory)
        {
            ComboBox FactoryBox = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Factory", true).First();
            if (Factory != "")
            {
                if (Factory == "PLV")
                {
                    FactoryBox.SelectedIndex = 0;
                }
                else if (Factory == "ZM")
                {
                    FactoryBox.SelectedIndex = 1;
                }
            }
            else
            {
                FactoryBox.SelectedIndex = 0;
            }
        }

        //Łaowanie na jakich platformach jest akcja 
        private void Platform(string Plat)
        {
            string[] Platform1;
            if (Plat != "")
            {
                Platform1 = Plat.Split('/');
                if (Platform1[0] == "DMD")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_DMD", true).First()).Checked = true;
                }
                if (Platform1[1] == "D45")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_D45", true).First()).Checked = true;
                }
            }
        }

        //Ładowanie na jakie Instalacji DW jest dana akcja
        private void Instalation(string Instal)
        {
            string[] Installation;
            if (Instal != "")
            {
                Installation = Instal.Split('/');
                if (Installation[0] == "FS")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FS", true).First()).Checked = true;
                }
                if (Installation[1] == "FI")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FI", true).First()).Checked = true;
                }
                if (Installation[2] == "BI")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_BI", true).First()).Checked = true;
                }
                if (Installation[3] == "BU")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_BU", true).First()).Checked = true;
                }
                if (Installation[4] == "FSBU")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FSBU", true).First()).Checked = true;
                }
            }
        }

        //ładoawnie Lidera Akcji 
        private void Leader(string Who)
        {
            ComboBox LeaderBox = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_Leader", true).First();

            if (LeaderBox.Items.Contains(Who))
            {
                int counter = LeaderBox.FindString(Who);
                LeaderBox.SelectedIndex = counter;
            }
        }

        //Ładowanie w jaki sposób ma być kalkulowana akcja i wszystko co z tym związane
        private void CalcBy(DataRow Action)
        {
            string How = Action["Calculate"].ToString();

            if (How == "ANC")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANC", true).First()).Checked = true;
                ECCCSec(Action["ECCC"].ToString());
            }
            else if (How == "ANCSpec")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANCby", true).First()).Checked = true;
                ECCCSec(Action["ECCC"].ToString());
                CheckANCSPec(Action["Calc"].ToString());
            }
            else if (How == "PNC")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNC", true).First()).Checked = true;
                ECCCSec(Action["ECCC"].ToString());
                PNCLoad(Action);
            }
            else if (How == "PNCSpec")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked = true;
                PNCSpecLoad(Action);
            }
        }

        //Ładowanie sekund dla ECCC
        private void ECCCSec(string ECCC)
        {
            NumericUpDown ECCCSekundnik = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First();
            CheckBox ECCCCB = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First();

            string[] ECCCArry;

            if (ECCC != "")
            {
                ECCCArry = ECCC.Split('|');
                if (ECCCArry.Length == 1)
                {
                    ECCCCB.Enabled = true;
                    ECCCCB.Checked = true;
                    ECCCSekundnik.Value = decimal.Parse(ECCCArry[0].ToString());
                }
                else
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked = true;
                }
            }
        }

        //Ładowanie PNC dla kalkulacji pod PNC
        private void PNCLoad(DataRow Action)
        {
            DataGridView DG = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
            string[] PNC;

            CreateColumn(ref DG, "PNC", 80, Color.Black);
            PNC = Action["PNC"].ToString().Split('|');

            for (int counter = 0; counter < PNC.Length - 1; counter++)
            {
                DG.Rows.Add(PNC[counter]);
            }
        }

        //Ładowanie PNCSpec do Tabeli
        private void PNCSpecLoad(DataRow Action)
        {
            bool ECCCCheck = false;
            string[] PNC;
            string[] PNC_ANC;
            string[] PNC_ANC_Q;
            string[] PNCSTK;
            string[] PNCDelta;
            string[] PNCSumSTK;
            string[] PNCSumDelta;
            string[] ECCC;


            DataGridView DG = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

            ((TextBox)mainProgram.TabControl.Controls.Find("TB_EstymacjaPNC", true).First()).Text = Action["PNCEstyma"].ToString();

            //Dodawanie kolum 
            CreateColumn(ref DG, "PNC", 80, Color.Black);
            CreateColumn(ref DG, "OLD ANC", 65, Color.Red);
            CreateColumn(ref DG, "OLD Q", 35, Color.Red);
            CreateColumn(ref DG, "NEW ANC", 65, Color.Green);
            CreateColumn(ref DG, "NEW Q", 35, Color.Green);
            CreateColumn(ref DG, "OLD STK", 65, Color.Red);
            CreateColumn(ref DG, "NEW STK", 65, Color.Green);
            CreateColumn(ref DG, "Delta", 65, Color.Black);

            //Przypisanie danych z bazy do zmiennych
            PNC = Action["PNC"].ToString().Split('|');
            PNC_ANC = Action["PNC/ANC"].ToString().Split('|');
            PNC_ANC_Q = Action["PNC/ANC Q"].ToString().Split('|');
            PNCSTK = Action["PNCSTK"].ToString().Split('|');
            PNCDelta = Action["PNCDelta"].ToString().Split('|');
            PNCSumSTK = Action["PNCSumSTK"].ToString().Split('|');
            PNCSumDelta = Action["PNCSumDelta"].ToString().Split('|');
            ECCC = Action["ECCC"].ToString().Split('|');

            //Sprawdzenie czy ma liczyć ECCC
            if (ECCC.Length > 1)
            {
                ECCCCheck = true;
            }

            //Dodawanie wartości do Grida
            for (int counter = 0; counter < PNC.Length - 1; counter++)
            {
                int index = DG.Rows.Add();
                DataGridViewRow NewRow = DG.Rows[index];

                NewRow.Cells["PNC"].Value = PNC[counter];
                if (ECCCCheck)
                {
                    NewRow.Cells["OLD ANC"].Value = "ECCC(" + ECCC[counter] + ")";
                }

                string[] PNCSumSTKPNC = PNCSumSTK[counter].Split(':');
                NewRow.Cells["OLD STK"].Value = PNCSumSTKPNC[0];
                NewRow.Cells["NEW STK"].Value = PNCSumSTKPNC[1];
                NewRow.Cells["Delta"].Value = PNCSumDelta[counter];

                ColorPNC(ref NewRow, DG.Font);
                ColorDelta(ref NewRow);

                string[] PNC_ANCData = PNC_ANC[counter].Split('/');
                string[] PNC_ANC_QData = PNC_ANC_Q[counter].Split('/');
                string[] PNCSTKData = PNCSTK[counter].Split('/');
                string[] PNCDeltaData = PNCDelta[counter].Split('/');

                for (int counter2 = 0; counter2 < PNC_ANCData.Length - 1; counter2++)
                {
                    string[] PNC_ANCData2 = PNC_ANCData[counter2].Split(':');
                    string[] PNCSTKData2 = PNCSTKData[counter2].Split(':');
                    string[] PNC_ANC_QData2 = PNC_ANC_QData[counter2].Split(':');

                    index = DG.Rows.Add();
                    NewRow = DG.Rows[index];
                    NewRow.Cells["OLD ANC"].Value = PNC_ANCData2[0];
                    NewRow.Cells["OLD Q"].Value = PNC_ANC_QData2[0];
                    NewRow.Cells["NEW ANC"].Value = PNC_ANCData2[1];
                    NewRow.Cells["NEW Q"].Value = PNC_ANC_QData2[1];
                    NewRow.Cells["OLD STK"].Value = PNCSTKData2[0];
                    NewRow.Cells["NEW STK"].Value = PNCSTKData2[1];
                    NewRow.Cells["Delta"].Value = PNCDeltaData[counter2];

                    ColorDelta(ref NewRow);
                }

            }

        }

        //Tworzenie kolumny
        private void CreateColumn(ref DataGridView Table, string Name, int Width, Color color)
        {
            DataGridViewColumn NewColumn = new DataGridViewTextBoxColumn();
            NewColumn.Name = Name;
            NewColumn.HeaderText = Name;
            NewColumn.Width = Width;
            NewColumn.DefaultCellStyle.ForeColor = color;
            NewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            NewColumn.ValueType = typeof(String);
            Table.Columns.Add(NewColumn);
        }

        //Kolorowanie odpowiednie dla PNC 
        private void ColorPNC(ref DataGridViewRow NewRow, Font font)
        {
            NewRow.DefaultCellStyle.BackColor = Color.LightBlue;
            NewRow.DefaultCellStyle.Font = new Font(font, FontStyle.Bold); //MS UI Gothic, 9 punkt.
            NewRow.Cells["OLD ANC"].Style.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        //Kolorowanie Delty dla PNCSpec
        private void ColorDelta(ref DataGridViewRow NewRow)
        {
            decimal Delta = decimal.Parse(NewRow.Cells["Delta"].Value.ToString());

            if (Delta > 0)
            {
                NewRow.Cells["Delta"].Style.ForeColor = Color.Green;
            }
            else if (Delta < 0)
            {
                NewRow.Cells["Delta"].Style.ForeColor = Color.Red;
            }

        }

        //Dodanie odpowiedniej ilości ANC i wypełnienie ich
        private void ANCADD(DataRow ActionRow)
        {
            string[] ANCOld;
            string[] ANCNew;
            string[] STKOld;
            string[] STKNew;
            string[] Delta;
            string[] STKEst;
            string[] Percent;
            string[] STKCal;
            string[] OldQ;
            string[] NewQ;
            string[] Next;

            int ANCQuantity = int.Parse(ActionRow["IloscANC"].ToString());
            int ANCChangeNumber = action.Action_ANCChangeNumber();

            ANCOld = ActionRow["Old ANC"].ToString().Split('|');
            OldQ = ActionRow["Old ANCQ"].ToString().Split('|');
            ANCNew = ActionRow["New ANC"].ToString().Split('|');
            NewQ = ActionRow["New ANCQ"].ToString().Split('|');
            STKOld = ActionRow["Old STK"].ToString().Split('|');
            STKNew = ActionRow["New STK"].ToString().Split('|');
            Delta = ActionRow["Delta"].ToString().Split('|');
            STKEst = ActionRow["STKEst"].ToString().Split('|');
            Percent = ActionRow["Percent"].ToString().Split('|');
            STKCal = ActionRow["STKCal"].ToString().Split('|');
            Next = ActionRow["Next"].ToString().Split('|');

            action.AddValueANC(1, ANCOld[0], ANCNew[0], STKOld[0], STKNew[0], Delta[0], STKEst[0], Percent[0], STKCal[0], Next[0], OldQ[0], NewQ[0]);

            for (int counter = 2; ANCChangeNumber < ANCQuantity; counter++)
            {
                action.Action_AddANC();
                ANCChangeNumber = action.Action_ANCChangeNumber();
                action.AddValueANC(counter, ANCOld[counter - 1], ANCNew[counter - 1], STKOld[counter - 1], STKNew[counter - 1], Delta[counter - 1], STKEst[counter - 1], Percent[counter - 1], STKCal[counter - 1], Next[counter - 1], OldQ[counter - 1], NewQ[counter - 1]);
            }

            STK_Sum(ANCChangeNumber);
        }

        //Sumowanie STK w całości 
        private void STK_Sum(int ANCChangeNumber)
        {
            decimal OLDSTK = 0;
            decimal NEWSTK = 0;
            decimal DeltaSum = 0;
            decimal CalcSum = 0;

            Label OLD = (Label)mainProgram.TabControl.Controls.Find("lab_OldSum", true).First();
            Label NEW = (Label)mainProgram.TabControl.Controls.Find("lab_NewSum", true).First();
            Label Delta = (Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First();
            Label Calc = (Label)mainProgram.TabControl.Controls.Find("lab_CalcSum", true).First();

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                OLDSTK = OLDSTK + decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_OldSTK" + counter.ToString(), true).First()).Text);
                NEWSTK = NEWSTK + decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_NewSTK" + counter.ToString(), true).First()).Text);
                DeltaSum = DeltaSum + decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_Delta" + counter.ToString(), true).First()).Text);
                CalcSum = CalcSum + decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_Calc" + counter.ToString(), true).First()).Text);
            }

            OLD.Text = OLDSTK.ToString();
            NEW.Text = NEWSTK.ToString();
            Delta.Text = DeltaSum.ToString();
            Calc.Text = CalcSum.ToString();

            if (DeltaSum > 0)
            {
                Delta.ForeColor = Color.Green;
            }
            else if (DeltaSum < 0)
            {
                Delta.ForeColor = Color.Red;
            }
            else
            {
                Delta.ForeColor = Color.Black;
            }

            if (CalcSum > 0)
            {
                Calc.ForeColor = Color.Green;
            }
            else if (CalcSum < 0)
            {
                Calc.ForeColor = Color.Red;
            }
            else
            {
                Calc.ForeColor = Color.Black;
            }

        }

        //Zaznaczenie Check boxa po którym ma być liczone ANCSpec
        private void CheckANCSPec(string CalcSpec)
        {
            string[] Calc = CalcSpec.Split('|');
            for (int counter = 0; counter <= Calc.Length - 1; counter++)
            {
                if (Calc[counter] == "true")
                {
                    ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ANCby" + (counter + 1).ToString(), true).First()).Checked = true;
                }
            }
        }

        //Ładowanie Gridów z plików do tabel - Quantity, Savings, ECCC
        private void GridLoad(DataRow Action, decimal Year)
        {
            string Carry = "";
            string[] What = new string[3] { "Quantity", "Saving", "ECCC" };
            decimal YearStart = decimal.Parse(Action["StartYear"].ToString());

            if (YearStart == Year - 1)
            {
                Carry = "Carry";
            }

            for (int counter = 0; counter < 3; counter++)
            {
                SpecififcGridLoad(Action, What[counter], Carry);
            }
        }

        //Ładowanie danych bezpośrednio do gridów Quantity, savings, ECCC
        private void SpecififcGridLoad(DataRow Action, string TableName, string Carry)
        {
            DataGridView DG = (DataGridView)mainProgram.TabControl.Controls.Find("dg_" + TableName, true).First();

            string[] BU = Action["CalcBU" + TableName + Carry].ToString().Split('/');
            string[] EA1 = Action["CalcEA1" + TableName + Carry].ToString().Split('/');
            string[] EA2 = Action["CalcEA2" + TableName + Carry].ToString().Split('/');
            string[] EA3 = Action["CalcEA3" + TableName + Carry].ToString().Split('/');
            string[] USE = Action["CalcUSE" + TableName + Carry].ToString().Split('/');

            if (BU.Length != 1)
            {
                for (int counter = 0; counter < 13; counter++)
                {
                    if (BU[counter] != "")
                    {
                        DG.Rows[4].Cells[counter].Value = decimal.Parse(BU[counter]);
                    }
                    if (EA1[counter] != "")
                    {
                        DG.Rows[3].Cells[counter].Value = decimal.Parse(EA1[counter]);
                    }
                    if (EA2[counter] != "")
                    {
                        DG.Rows[2].Cells[counter].Value = decimal.Parse(EA2[counter]);
                    }
                    if (EA3[counter] != "")
                    {
                        DG.Rows[1].Cells[counter].Value = decimal.Parse(EA3[counter]);
                    }
                    if (USE[counter] != "")
                    {
                        DG.Rows[0].Cells[counter].Value = decimal.Parse(USE[counter]);
                    }
                }
            }
        }

        //IDCO ładowanie danych z bazy do Słownika
        private void IDCO(DataRow Action)
        {
            string[] IDCORow = Action["IDCO"].ToString().Split('/');
            string[] IDCOColumn;

            for (int counter = 0; counter < IDCORow.Length - 1; counter++)
            {
                IDCOColumn = IDCORow[counter].Split('|');
                IDCODictionary.Add(IDCOColumn[0], IDCOColumn[1]);
            }

            action.Action_IDCODictionary(IDCODictionary);
        }

        //Sprawdzenie i wybranie odpowiedniego statusu Akcji czy jest Active czy Idea
        private void Active_Idea_Action(string Status)
        {
            if (Status == "Active")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First()).Checked = true;
            }
            else if (Status == "Idea")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Idea", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First()).Checked = true;
            }
        }

    }

}