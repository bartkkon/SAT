using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.Text.RegularExpressions;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;

namespace Saving_Accelerator_Tool
{
    public class Action
    {
        private int ANCChangeNumber = 0;
        private readonly string link;
        private readonly string linkSTK;
        private readonly string LinkFrozen;
        private readonly string LinkANC;
        private readonly string LinkPNC;
        private readonly string LinkANCMonth;
        private readonly string LinkPNCMonth;
        private readonly string LinkECCC;
        private bool ChangeANC = true; //Ustawia się gdy Zostało zmienione ANC (old new), Resetuje się gdy jest przeliczone STK
        private bool SavingCalc = false; // Ustawia się gdy zostało przeliczone STK, Resetuje się gdy zrobiony jest calc dla akcji
        private bool IfanyChange = false; //Jeśli jakaś akcja była zrobiona w wyświetlanej akcji, zmienia się na true. Jeśli będziesz próbował przejść do innej akcji zapyta czy chesz zapisać zmiany
        private bool NewActionCreate = false;

        private DataTable USE = new DataTable();
        private DataTable BU = new DataTable();
        private DataTable EA1 = new DataTable();
        private DataTable EA2 = new DataTable();
        private DataTable EA3 = new DataTable();

        //Słownik z IDCO
        private Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();

        private readonly Data_Import ImportData;
        private readonly MainProgram mainProgram;

        public Action(MainProgram mainProgram, Data_Import ImportData)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            link = ImportData.Load_Link("Action");
            linkSTK = ImportData.Load_Link("STK");
            LinkFrozen = ImportData.Load_Link("Frozen");
            LinkANC = ImportData.Load_Link("ANC");
            LinkPNC = ImportData.Load_Link("PNC");
            LinkANCMonth = ImportData.Load_Link("ANCMonth");
            LinkPNCMonth = ImportData.Load_Link("PNCMonth");
            LinkECCC = ImportData.Load_Link("Kurs");
        }

        public void Action_AddColumn()
        {
            AddColumn();
        }

        //public void Action_AddANC()
        //{
        //    if (ANCChangeNumber < 10)
        //    {
        //        ANCChangeNumber++;
        //        ButtonAddANC();
        //    }
        //}

        //public void Action_RemoveANC()
        //{
        //    if (ANCChangeNumber == 1)
        //    {
        //        ButtonRemoveANC();
        //        ButtonAddANC();
        //    }
        //    if (ANCChangeNumber > 1)
        //    {
        //        ButtonRemoveANC();
        //        ANCChangeNumber--;
        //    }

        //}

        public void Action_IDCODictionary(Dictionary<string, string> IDCOLoad)
        {
            IDCODictionary = IDCOLoad;
        }

        public Dictionary<string, string> Action_IDCODictionary()
        {
            return IDCODictionary;
        }

        public int Action_ANCChangeNumber()
        {
            return ANCChangeNumber;
        }

        public void Action_SavingCalculation()
        {
            //SavingCalculation();
            if (NewActionCreate)
            {
                if (USE.Columns.Count != 13)
                    CreateColumnPerANC("USE");
                if (BU.Columns.Count != 13)
                    CreateColumnPerANC("BU");
                if (EA1.Columns.Count != 11)
                    CreateColumnPerANC("EA1");
                if (EA2.Columns.Count != 8)
                    CreateColumnPerANC("EA2");
                if (EA3.Columns.Count != 5)
                    CreateColumnPerANC("EA3");
            }
            Calculation Calc = new Calculation(ANCChangeNumber, USE, BU, EA1, EA2, EA3);
            Calc.SavingCalculation();
            Action_ChangeInAction();
            ChangeCalcProtector(false);
        }

        //public void Action_AddList()
        //{
        //    TreeView tree_Action = (TreeView)mainProgram.TabControl.Controls.Find("tree_Action", true).First();

        //    AddList();
        //    tree_Action.ExpandAll();
        //}

        public void Action_Load(string Action)
        {

            Cursor.Current = Cursors.WaitCursor;
            NewAction(mainProgram);
            LoadAction loadAction = new LoadAction(this);
            loadAction.Load(Action);
            USE = loadAction.ReturnTable("USE");
            BU = loadAction.ReturnTable("BU");
            EA1 = loadAction.ReturnTable("EA1");
            EA2 = loadAction.ReturnTable("EA2");
            EA3 = loadAction.ReturnTable("EA3");

            ChangeActionBlocker();
            ChangeANCProtector(false);
            ChangeCalcProtector(false);
            NewActionCreate = false;
            Action_NoChangeInAction();

            Cursor.Current = Cursors.Default;
        }

        public void Action_NewAction()
        {
            if (IfanyChange)
            {
                DialogResult Results = MessageBox.Show("Do you want save change ? ", "Save ? ", MessageBoxButtons.YesNo);
                if (Results == DialogResult.Yes)
                {
                    Action_Save();
                    NewAction(MainProgram.Self);
                    ChangeActionBlocker();
                    NewActionCreate = true;
                }
                else if (Results == DialogResult.No)
                {
                    NewAction(MainProgram.Self);
                    ChangeActionBlocker();
                    NewActionCreate = true;
                }
            }
            else
            {
                NewAction(MainProgram.Self);
                ChangeActionBlocker();
                NewActionCreate = true;
            }
        }

        public void Action_Save()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (CheckBeforeSave())
            {
                Cursor.Current = Cursors.Default;
                return;
            }
            else
            {
                SaveAction Save = new SaveAction(ANCChangeNumber, IDCODictionary, USE, BU, EA1, EA2, EA3);
                Save.Save(NewActionCreate, IDCODictionary);
                TreeRefresh();
                Action_NoChangeInAction();
                Cursor.Current = Cursors.Default;
            }
        }

        public void Action_RefreshSTK()
        {
            Cursor.Current = Cursors.WaitCursor;
            STKCalculation STK = new STKCalculation(mainProgram, ImportData, ANCChangeNumber);
            STK.STKRefresh();
            IDCODictionary = STK.GetIDCO();
            mainProgram.Refresh();
            RefreshEstimationAll();
            ChangeANCProtector(false);
            ChangeCalcProtector(true);
            Action_ChangeInAction();
            Cursor.Current = Cursors.Default;
        }

        //public void Action_TreeRefresh()
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    TreeRefresh();
        //    Cursor.Current = Cursors.Default;
        //}

        public void Action_CurrentCarry_Change(string what, string Action)
        {
            Cursor.Current = Cursors.WaitCursor;
            Current_CarryOver_Change(what, Action);
            Cursor.Current = Cursors.Default;
        }

        public bool Action_CheckANCLenght()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool IfError = CheckANCLength();
            Cursor.Current = Cursors.Default;
            return IfError;
        }

        public void Action_STKCalcNeed()
        {
            ChangeANCProtector(true);
        }

        public void Action_CalcNeed()
        {
            ChangeCalcProtector(true);
        }

        public void Action_ChangeInAction()
        {
            IfanyChange = true;
            ((Button)mainProgram.TabControl.Controls.Find("pb_Save", true).First()).ForeColor = Color.Red;
        }

        public void Action_NoChangeInAction()
        {
            IfanyChange = false;
            //((Button)mainProgram.TabControl.Controls.Find("pb_Save", true).First()).ForeColor = Color.Black;
        }

        public bool Action_IfcanChange()
        {
            return IfanyChange;
        }

        private void AddColumn()
        {
            ComboBox combox_AdminAddColumn = (ComboBox)mainProgram.Controls.Find("comBox_AdminAddColumn_Where", true).First();
            TextBox tb_AdminAddColumn = (TextBox)mainProgram.Controls.Find("tb_AdminAddColumn", true).First();
            TextBox Tb_AdminValue = (TextBox)mainProgram.Controls.Find("tb_AdminAddValue", true).First();
            DataTable dataTable = new DataTable();
            string LinkToSave = "";


            switch (combox_AdminAddColumn.Text)
            {
                case "Action":
                    ImportData.Load_TxtToDataTable(ref dataTable, link);
                    LinkToSave = link;
                    break;
                case "STK":
                    ImportData.Load_TxtToDataTable(ref dataTable, linkSTK);
                    LinkToSave = linkSTK;
                    break;
                case "Frozen":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkFrozen);
                    LinkToSave = LinkFrozen;
                    break;
                case "ANC":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkANC);
                    LinkToSave = LinkANC;
                    break;
                case "PNC":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkPNC);
                    LinkToSave = LinkPNC;
                    break;
                case "ANCMonth":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkANCMonth);
                    LinkToSave = LinkANCMonth;
                    break;
                case "PNCMonth":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkPNCMonth);
                    LinkToSave = LinkPNCMonth;
                    break;
                case "Kurs":
                    ImportData.Load_TxtToDataTable(ref dataTable, LinkECCC);
                    LinkToSave = LinkECCC;
                    break;
                default:
                    break;
            }

            if (LinkToSave != "")
            {
                dataTable.Columns.Add(tb_AdminAddColumn.Text);
                if (Tb_AdminValue.Text != "")
                {
                    foreach (DataRow Row in dataTable.Rows)
                    {
                        Row[tb_AdminAddColumn.Text] = Tb_AdminValue.Text;
                    }
                }
                ImportData.Save_DataTableToTXT(ref dataTable, LinkToSave);
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

        private void Current_CarryOver_Change(string what, string Action)
        {
            DataTable ActionList = new DataTable();
            DataRow FoundRow = null;
            DataRow[] FoundArry;
            NumericUpDown Num_YearAction = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First();

            string[] Next;
            string[] Next1;
            string[] Next2;
            string[] Next3;
            string[] Next4;
            string help;
            string help1;
            string help2;
            string help3;
            string help4;

            ImportData.Load_TxtToDataTable(ref ActionList, link);

            //FoundRow = ActionList.Select(string.Format("Name LIKE '%{0}%'", Action)).FirstOrDefault();

            FoundArry = ActionList.Select(string.Format("Name LIKE '%{0}%'", Action)).ToArray();
            foreach (DataRow Row in FoundArry.Take(FoundArry.Length))
            {
                if (Row["Name"].ToString() == Action.ToString() && Row["StartYear"].ToString() == (Num_YearAction.Value).ToString())
                {
                    FoundRow = Row;
                }
            }
            if (FoundRow != null)
            {
                help = FoundRow["CalcBUQuantity" + what].ToString();
                Next = help.Split('/');
                help1 = FoundRow["CalcEA1Quantity" + what].ToString();
                Next1 = help1.Split('/');
                help2 = FoundRow["CalcEA2Quantity" + what].ToString();
                Next2 = help2.Split('/');
                help3 = FoundRow["CalcEA3Quantity" + what].ToString();
                Next3 = help3.Split('/');
                help4 = FoundRow["CalcUSEQuantity" + what].ToString();
                Next4 = help4.Split('/');

                DataGridView dg_Quantity = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();

                for (int counter = 0; counter < 13; counter++)
                {
                    dg_Quantity.Rows[4].Cells[counter].Value = Next[counter];
                    dg_Quantity.Rows[3].Cells[counter].Value = Next1[counter];
                    dg_Quantity.Rows[2].Cells[counter].Value = Next2[counter];
                    dg_Quantity.Rows[1].Cells[counter].Value = Next3[counter];
                    dg_Quantity.Rows[0].Cells[counter].Value = Next4[counter];
                }

                help = FoundRow["CalcBUSaving" + what].ToString();
                Next = help.Split('/');
                help1 = FoundRow["CalcEA1Saving" + what].ToString();
                Next1 = help1.Split('/');
                help2 = FoundRow["CalcEA2Saving" + what].ToString();
                Next2 = help2.Split('/');
                help3 = FoundRow["CalcEA3Saving" + what].ToString();
                Next3 = help3.Split('/');
                help4 = FoundRow["CalcUSESaving" + what].ToString();
                Next4 = help4.Split('/');

                DataGridView dg_Saving = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();

                for (int counter = 0; counter < 13; counter++)
                {
                    dg_Saving.Rows[4].Cells[counter].Value = Next[counter];
                    dg_Saving.Rows[3].Cells[counter].Value = Next1[counter];
                    dg_Saving.Rows[2].Cells[counter].Value = Next2[counter];
                    dg_Saving.Rows[1].Cells[counter].Value = Next3[counter];
                    dg_Saving.Rows[0].Cells[counter].Value = Next4[counter];
                }


                help = FoundRow["CalcBUECCC" + what].ToString();
                Next = help.Split('/');
                help1 = FoundRow["CalcEA1ECCC" + what].ToString();
                Next1 = help1.Split('/');
                help2 = FoundRow["CalcEA2ECCC" + what].ToString();
                Next2 = help2.Split('/');
                help3 = FoundRow["CalcEA3ECCC" + what].ToString();
                Next3 = help3.Split('/');
                help4 = FoundRow["CalcUSEECCC" + what].ToString();
                Next4 = help4.Split('/');

                DataGridView dg_ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

                for (int counter = 0; counter < 13; counter++)
                {
                    dg_ECCC.Rows[4].Cells[counter].Value = Next[counter];
                    dg_ECCC.Rows[3].Cells[counter].Value = Next1[counter];
                    dg_ECCC.Rows[2].Cells[counter].Value = Next2[counter];
                    dg_ECCC.Rows[1].Cells[counter].Value = Next3[counter];
                    dg_ECCC.Rows[0].Cells[counter].Value = Next4[counter];
                }
            }
        }

        private int WhatMonth(string Month)
        {
            int MonthCount;
            switch (Month)
            {
                case "January":
                    MonthCount = 1;
                    break;
                case "February":
                    MonthCount = 2;
                    break;
                case "March":
                    MonthCount = 3;
                    break;
                case "April":
                    MonthCount = 4;
                    break;
                case "May":
                    MonthCount = 5;
                    break;
                case "June":
                    MonthCount = 6;
                    break;
                case "July":
                    MonthCount = 7;
                    break;
                case "August":
                    MonthCount = 8;
                    break;
                case "September":
                    MonthCount = 9;
                    break;
                case "October":
                    MonthCount = 10;
                    break;
                case "November":
                    MonthCount = 11;
                    break;
                case "December":
                    MonthCount = 12;
                    break;
                default:
                    MonthCount = 0;
                    break;
            }

            return MonthCount;
        }

        public void RefreshEstymation2(TextBox ToCheck)
        {
            string Name;
            int Number;
            string[] TextToCheck;
            int PositionCurrsor;

            ToCheck.TextChanged -= CalcAfterChange_TextChanged;

            if (ToCheck.Name.Length > 12)
            {
                Name = ToCheck.Name.Substring(0, 12);
                Number = int.Parse(ToCheck.Name.Remove(0, 12));
            }
            else
            {
                Name = ToCheck.Name.Substring(0, 10);
                Number = int.Parse(ToCheck.Name.Remove(0, 10));
            }

            PositionCurrsor = ToCheck.SelectionStart;

            ToCheck.Text = ToCheck.Text.Replace(".", ",");
            if (Name == "TB_Estymacja")
            {
                ToCheck.Text = Regex.Replace(ToCheck.Text, @"[^0-9,-]+", "");
                TextToCheck = ToCheck.Text.Split(',');
                if (TextToCheck.Length > 2)
                {
                    PositionCurrsor -= 1;
                    ToCheck.Text = ToCheck.Text.Remove(PositionCurrsor, 1);
                }
                TextToCheck = ToCheck.Text.Split('-');
                if (TextToCheck.Length > 2)
                {
                    PositionCurrsor -= 1;
                    ToCheck.Text = ToCheck.Text.Remove(PositionCurrsor, 1);
                }
                TextToCheck = ToCheck.Text.Split('-');
                if (TextToCheck.Length >= 2 && TextToCheck[0] != "")
                {
                    PositionCurrsor -= 1;
                    ToCheck.Text = ToCheck.Text.Remove(PositionCurrsor, 1);
                }

                ToCheck.Focus();
                ToCheck.SelectionStart = PositionCurrsor;
            }
            else if (Name == "TB_Percent")
            {
                ToCheck.Text = Regex.Replace(ToCheck.Text, @"[^0-9,]+", "");
                TextToCheck = ToCheck.Text.Split(',');
                if (TextToCheck.Length > 2)
                {
                    ToCheck.Text = ToCheck.Text.Remove(PositionCurrsor, 1);
                }
                ToCheck.Focus();
                ToCheck.SelectionStart = PositionCurrsor;
            }

            ToCheck.TextChanged += CalcAfterChange_TextChanged;
            ChangeANCProtector(true);
        }

        private void RefreshEstimation_Calc(int Number)
        {
            decimal Estimation;
            decimal Percent;
            decimal Calc;
            decimal Sum = 0;

            TextBox TB_Estimation = (TextBox)mainProgram.TabControl.Controls.Find("TB_Estymacja" + Number.ToString(), true).First();
            TextBox TB_Percent = (TextBox)mainProgram.TabControl.Controls.Find("TB_Percent" + Number.ToString(), true).First();
            Label Lab_Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_Calc" + Number.ToString(), true).First();
            Label Lab_CalcSum = ((Label)mainProgram.TabControl.Controls.Find("Lab_CalcSum", true).First());

            if (TB_Estimation.Text == "")
            {
                if (((Label)mainProgram.TabControl.Controls.Find("Lab_Delta" + Number.ToString(), true).First()).Text != "")
                {
                    Estimation = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_Delta" + Number.ToString(), true).First()).Text);
                }
                else
                {
                    Estimation = 0;
                }
            }
            else
            {
                Estimation = decimal.Parse(TB_Estimation.Text);
            }

            Percent = decimal.Parse(TB_Percent.Text) / 100;

            Calc = Math.Round(Estimation * Percent, 4, MidpointRounding.AwayFromZero);

            Lab_Calc.Text = Calc.ToString();

            if (Calc > 0)
            {
                Lab_Calc.ForeColor = Color.Green;
            }
            else if (Calc < 0)
            {
                Lab_Calc.ForeColor = Color.Red;
            }
            else
            {
                Lab_Calc.ForeColor = Color.Black;
            }

            for (int counter = 1; counter <= Number; counter++)
            {
                Sum += decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("Lab_Calc" + counter.ToString(), true).First()).Text);
            }
            Lab_CalcSum.Text = (Math.Round(Sum, 4, MidpointRounding.AwayFromZero)).ToString();

            if (Sum > 0)
            {
                Lab_CalcSum.ForeColor = Color.Green;
            }
            else if (Sum < 0)
            {
                Lab_CalcSum.ForeColor = Color.Red;
            }
            else
            {
                Lab_CalcSum.ForeColor = Color.Black;
            }
        }

        private void RefreshEstimationAll()
        {
            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                RefreshEstimation_Calc(counter);
            }
        }

        private void TreeRefresh()
        {
            TreeView tree_Action = (TreeView)mainProgram.TabControl.Controls.Find("tree_Action", true).First();

            tree_Action.Nodes.Clear();
            //AddList();
            tree_Action.ExpandAll();
        }

        private void NewAction(MainProgram mainProgram)
        {
            ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text = "";
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Text = "New Action";
            //((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Enabled = true;
            ((TextBox)mainProgram.TabControl.Controls.Find("tb_Description", true).First()).Text = "";
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANC", true).First()).Checked = true;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First()).Checked = true;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Enabled = false;
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Enabled = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_DMD", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_D45", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FS", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FI", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_BU", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_BI", true).First()).Checked = false;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_FSBU", true).First()).Checked = false;
            ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Leader", true).First()).SelectedIndex = 0;
            ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Clear();
            ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Columns.Clear();
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_PNC", true).First()).Enabled = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_PNC", true).First()).Visible = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_MassCalc", true).First()).Visible = false;
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value = DateTime.Today.Year;
            ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First()).Text = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            ((Button)mainProgram.TabControl.Controls.Find("pb_SaveDraft", true).First()).Visible = true;
            ((Label)mainProgram.TabControl.Controls.Find("lab_OldSum", true).First()).Text = "0";
            ((Label)mainProgram.TabControl.Controls.Find("lab_NewSum", true).First()).Text = "0";
            ((Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First()).Text = "0";
            ((Label)mainProgram.TabControl.Controls.Find("lab_DeltaSum", true).First()).ForeColor = Color.Black;
            ((Label)mainProgram.TabControl.Controls.Find("lab_CalcSum", true).First()).Text = "0";
            ((Button)mainProgram.TabControl.Controls.Find("pb_CarryOver", true).First()).Enabled = false;
            Button pb_CarryOver = (Button)mainProgram.TabControl.Controls.Find("pb_CarryOver", true).First();
            Button pb_CurrentYear = (Button)mainProgram.TabControl.Controls.Find("pb_CurrentYear", true).First();
            ((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text = "100";
            pb_CurrentYear.UseVisualStyleBackColor = false;
            pb_CurrentYear.BackColor = Color.LightBlue;
            pb_CarryOver.UseVisualStyleBackColor = true;

            IDCODictionary.Clear();

            DataGridView dg_Saving = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
            DataGridView dg_Quantity = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
            DataGridView dg_ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

            for (int counter = 0; counter < 5; counter++)
            {
                for (int counter2 = 0; counter2 < 13; counter2++)
                {
                    dg_Saving.Rows[counter].Cells[counter2].Value = "";
                    dg_Quantity.Rows[counter].Cells[counter2].Value = "";
                    dg_ECCC.Rows[counter].Cells[counter2].Value = "";
                }
            }

            for (; ANCChangeNumber > 1;)
            {
                //Action_RemoveANC();
            }
            //Action_RemoveANC();
        }

        public void AddValueANC(int counter, string ANCOld, string ANCNew, string STKold, string STKNew, string Delta, string STKEst, string Percent, string STKCal, string Next, string OldQ, string NewQ)
        {

            TextBox nTB_OLDANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First();
            nTB_OLDANC.Text = ANCOld;

            TextBox nTB_OLDANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANCQ" + counter.ToString(), true).First();
            nTB_OLDANCQ.Text = OldQ;

            TextBox nTB_NEWANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First();
            nTB_NEWANC.Text = ANCNew;

            TextBox nTB_NEWANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANCQ" + counter.ToString(), true).First();
            nTB_NEWANCQ.Text = NewQ;

            Label nLab_OldStk = (Label)mainProgram.TabControl.Controls.Find("lab_OldSTK" + counter.ToString(), true).First();
            nLab_OldStk.Text = STKold;

            Label nLab_NewSTK = (Label)mainProgram.TabControl.Controls.Find("lab_NewSTK" + counter.ToString(), true).First();
            nLab_NewSTK.Text = STKNew;

            Label nLab_Delta = (Label)mainProgram.TabControl.Controls.Find("lab_Delta" + counter.ToString(), true).First();
            nLab_Delta.Text = Delta;
            if (Delta == "")
                Delta = "0"
                    ;
            decimal DeltaDecimal = decimal.Parse(Delta);
            if (DeltaDecimal > 0)
            {
                nLab_Delta.ForeColor = Color.Green;
            }
            else if (DeltaDecimal < 0)
            {
                nLab_Delta.ForeColor = Color.Red;
            }
            else
            {
                nLab_Delta.ForeColor = Color.Black;
            }


            TextBox nTB_Estymacja = (TextBox)mainProgram.TabControl.Controls.Find("TB_Estymacja" + counter.ToString(), true).First();
            nTB_Estymacja.TextChanged -= CalcAfterChange_TextChanged;
            nTB_Estymacja.Text = STKEst;
            nTB_Estymacja.TextChanged += CalcAfterChange_TextChanged;

            TextBox nTB_Percent = (TextBox)mainProgram.TabControl.Controls.Find("TB_Percent" + counter.ToString(), true).First();
            nTB_Percent.TextChanged -= CalcAfterChange_TextChanged;
            nTB_Percent.Text = Percent;
            nTB_Percent.TextChanged += CalcAfterChange_TextChanged;

            Label nTB_Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_Calc" + counter.ToString(), true).First();
            if (STKCal == "")
                STKCal = "0";

            nTB_Calc.Text = STKCal;
            if (decimal.Parse(nTB_Calc.Text) > 0)
            {
                nTB_Calc.ForeColor = Color.Green;
            }
            if (decimal.Parse(nTB_Calc.Text) < 0)
            {
                nTB_Calc.ForeColor = Color.Red;
            }
            if (decimal.Parse(nTB_Calc.Text) == 0)
            {
                nTB_Calc.ForeColor = Color.Black;
            }

            TextBox nTB_NextANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First();
            nTB_NextANC.Text = Next;


            //STK_Sum(mainProgram, counter);
        }

        //private void AddList()
        //{
        //    DataTable ActionList = new DataTable();
        //    string Leader;
        //    string Status;

        //    NumericUpDown nNum_ActionYear = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearOption", true).First();
        //    TreeView ntree_Action = (TreeView)mainProgram.TabControl.Controls.Find("tree_Action", true).First();
        //    ComboBox ComBox_Leader = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_FilterBy", true).First();

        //    Leader = ComBox_Leader.GetItemText(ComBox_Leader.SelectedItem);
        //    ntree_Action.Nodes.Clear();

        //    decimal Year = nNum_ActionYear.Value;

        //    ImportData.Load_TxtToDataTable(ref ActionList, link);

        //    if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_ActionActive", true).First()).Checked)
        //    {
        //        Status = "Active";
        //    }
        //    else
        //    {
        //        Status = "Idea";
        //    }


        //    if (Users.Singleton().ActionEle)
        //    {
        //        TreeNode Electronic = new TreeNode("Electronic")
        //        {
        //            Name = "Electronic"
        //        };
        //        ntree_Action.Nodes.Add(Electronic);
        //        TreeNode ElectronicCarry = new TreeNode("Electronic Carry Over")
        //        {
        //            Name = "Electronic Carry Over"
        //        };
        //        ntree_Action.Nodes.Add(ElectronicCarry);
        //    }
        //    if (Users.Singleton().ActionMech)
        //    {
        //        TreeNode Mechanic = new TreeNode("Mechanic")
        //        {
        //            Name = "Mechanic"
        //        };
        //        ntree_Action.Nodes.Add(Mechanic);
        //        TreeNode MechanicCarry = new TreeNode("Mechanic Carry Over")
        //        {
        //            Name = "Mechanic Carry Over"
        //        };
        //        ntree_Action.Nodes.Add(MechanicCarry);
        //    }
        //    if (Users.Singleton().ActionNVR)
        //    {
        //        TreeNode NVR = new TreeNode("NVR")
        //        {
        //            Name = "NVR"
        //        };
        //        ntree_Action.Nodes.Add(NVR);
        //        TreeNode NVRCarry = new TreeNode("NVR Carry Over")
        //        {
        //            Name = "NVR Carry Over"
        //        };
        //        ntree_Action.Nodes.Add(NVRCarry);
        //    }

        //    foreach (DataRow Row in ActionList.Rows)
        //    {
        //        if (Users.Singleton().ActionEle)
        //        {
        //            if (Row["Group"].ToString() == "Electronic" && Row["StartYear"].ToString() == Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["Electronic"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["Electronic"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }
        //            if (Row["Group"].ToString() == "Electronic" && Row["StartYear"].ToString() == "SA/" + Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["Electronic"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["Electronic"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }

        //            if (Row["Group"].ToString() == "Electronic" && Row["StartYear"].ToString() == (Year - 1).ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Row["StartMonth"].ToString() != "January")
        //                {
        //                    if (Leader == "All")
        //                    {
        //                        ntree_Action.Nodes["Electronic Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                    else
        //                    {
        //                        if (Row["Leader"].ToString() == Leader)
        //                        {
        //                            ntree_Action.Nodes["Electronic Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (Users.Singleton().ActionMech)
        //        {
        //            if (Row["Group"].ToString() == "Mechanic" && Row["StartYear"].ToString() == Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["Mechanic"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["Mechanic"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }

        //            if (Row["Group"].ToString() == "Mechanic" && Row["StartYear"].ToString() == "SA/" + Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["Mechanic"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["Mechanic"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }

        //            if (Row["Group"].ToString() == "Mechanic" && Row["StartYear"].ToString() == (Year - 1).ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Row["StartMonth"].ToString() != "January")
        //                {
        //                    if (Leader == "All")
        //                    {
        //                        ntree_Action.Nodes["Mechanic Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                    else
        //                    {
        //                        if (Row["Leader"].ToString() == Leader)
        //                        {
        //                            ntree_Action.Nodes["Mechanic Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (Users.Singleton().ActionNVR)
        //        {
        //            if (Row["Group"].ToString() == "NVR" && Row["StartYear"].ToString() == Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["NVR"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["NVR"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }
        //            if (Row["Group"].ToString() == "NVR" && Row["StartYear"].ToString() == "SA/" + Year.ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Leader == "All")
        //                {
        //                    ntree_Action.Nodes["NVR"].Nodes.Add(Row["Name"].ToString());
        //                }
        //                else
        //                {
        //                    if (Row["Leader"].ToString() == Leader)
        //                    {
        //                        ntree_Action.Nodes["NVR"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                }
        //            }

        //            if (Row["Group"].ToString() == "NVR" && Row["StartYear"].ToString() == (Year - 1).ToString() && Row["Status"].ToString() == Status)
        //            {
        //                if (Row["StartMonth"].ToString() != "January")
        //                {
        //                    if (Leader == "All")
        //                    {
        //                        ntree_Action.Nodes["NVR Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                    }
        //                    else
        //                    {
        //                        if (Row["Leader"].ToString() == Leader)
        //                        {
        //                            ntree_Action.Nodes["NVR Carry Over"].Nodes.Add(Row["Name"].ToString());
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //}

        //private void ButtonAddANC()
        //{
        //    GroupBox gb_ANC = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ANC", true).First();
        //    GroupBox gb_STK = (GroupBox)mainProgram.TabControl.Controls.Find("gb_STK", true).First();
        //    GroupBox gb_Calc = (GroupBox)mainProgram.TabControl.Controls.Find("gb_Calc", true).First();
        //    GroupBox gb_NextANC = (GroupBox)mainProgram.TabControl.Controls.Find("gb_NextANC", true).First();
        //    GroupBox gb_ANCby = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ANCby", true).First();

        //    //TextBox for Old ANC
        //    TextBox nTB_OldANC = new TextBox
        //    {
        //        Location = new Point(5, ((ANCChangeNumber - 1) * 26 + 80)),
        //        MaxLength = 9,
        //        Name = "TB_OldANC" + ANCChangeNumber.ToString(),
        //        Size = new Size(70, 20)
        //    };
        //    nTB_OldANC.TextChanged += new EventHandler(Tb_CheckifOK_TextChange);
        //    nTB_OldANC.Leave += new EventHandler(Tb_Quantity_Leave);
        //    gb_ANC.Controls.Add(nTB_OldANC);

        //    //TextBox for qunatity Old ANC
        //    TextBox nTB_OldANCQ = new TextBox
        //    {
        //        Location = new Point(80, ((ANCChangeNumber - 1) * 26 + 80)),
        //        MaxLength = 5,
        //        Name = "TB_OldANCQ" + ANCChangeNumber.ToString(),
        //        Size = new Size(40, 20),
        //        Text = "0",
        //    };
        //    nTB_OldANCQ.TextChanged += new EventHandler(Tb_CheckIfQuantity_TextChange);
        //    nTB_OldANCQ.Leave += new EventHandler(Tb_Quantity_Leave);
        //    gb_ANC.Controls.Add(nTB_OldANCQ);

        //    //Label between Old ANC And New ANC
        //    Label nLab_ANC = new Label
        //    {
        //        AutoSize = true,
        //        Location = new Point(130, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "leb_ANC" + ANCChangeNumber.ToString(),
        //        Size = new Size(16, 13),
        //        Text = "->"
        //    };
        //    gb_ANC.Controls.Add(nLab_ANC);

        //    //TextBox for New ANC
        //    TextBox nTB_NewANC = new TextBox
        //    {
        //        Location = new Point(150, ((ANCChangeNumber - 1) * 26 + 80)),
        //        MaxLength = 9,
        //        Name = "TB_NewANC" + ANCChangeNumber.ToString(),
        //        Size = new Size(70, 20)
        //    };
        //    nTB_NewANC.TextChanged += new EventHandler(Tb_CheckifOK_TextChange);
        //    nTB_NewANC.Leave += new EventHandler(Tb_Quantity_Leave);
        //    gb_ANC.Controls.Add(nTB_NewANC);

        //    //TextBox for quantity to new ANC 
        //    TextBox nTB_NewANCQ = new TextBox
        //    {
        //        Location = new Point(225, ((ANCChangeNumber - 1) * 26 + 80)),
        //        MaxLength = 5,
        //        Name = "TB_NewANCQ" + ANCChangeNumber.ToString(),
        //        Size = new Size(40, 20),
        //        Text = "0",
        //    };
        //    nTB_NewANCQ.TextChanged += new EventHandler(Tb_CheckIfQuantity_TextChange);
        //    nTB_NewANCQ.Leave += new EventHandler(Tb_Quantity_Leave);
        //    gb_ANC.Controls.Add(nTB_NewANCQ);

        //    //Label for OLD STK 
        //    Label nLab_OldSTK = new Label
        //    {
        //        AutoSize = true,
        //        Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
        //        ForeColor = Color.Red,
        //        Location = new Point(24, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "lab_OldSTK" + ANCChangeNumber.ToString(),
        //        Size = new Size(48, 13),
        //        Text = ""
        //    };
        //    gb_STK.Controls.Add(nLab_OldSTK);

        //    //Label between OLD STK and New STK
        //    Label nLab_Strz = new Label
        //    {
        //        AutoSize = true,
        //        Location = new Point(82, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "lab_Strz" + ANCChangeNumber.ToString(),
        //        Size = new Size(16, 13),
        //        Text = "->"
        //    };
        //    gb_STK.Controls.Add(nLab_Strz);

        //    //Label for New STK 
        //    Label nLab_NewSTK = new Label
        //    {
        //        AutoSize = true,
        //        Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
        //        ForeColor = Color.Green,
        //        Location = new Point(114, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "lab_NewSTK" + ANCChangeNumber.ToString(),
        //        Size = new Size(48, 13),
        //        Text = ""
        //    };
        //    gb_STK.Controls.Add(nLab_NewSTK);

        //    //Label Equal
        //    Label nLab_Rowna = new Label
        //    {
        //        AutoSize = true,
        //        Location = new Point(182, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "lab_Rowna" + ANCChangeNumber.ToString(),
        //        Size = new Size(13, 13),
        //        Text = "="
        //    };
        //    gb_STK.Controls.Add(nLab_Rowna);

        //    //Label Delta
        //    Label nLab_Delta = new Label
        //    {
        //        AutoSize = true,
        //        Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
        //        Location = new Point(215, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "lab_Delta" + ANCChangeNumber.ToString(),
        //        Size = new Size(48, 13),
        //        Text = ""
        //    };
        //    gb_STK.Controls.Add(nLab_Delta);

        //    //Estimation 
        //    TextBox nTB_Estymacja = new TextBox
        //    {
        //        Location = new Point(285, ((ANCChangeNumber - 1) * 26 + 80)),
        //        Name = "TB_Estymacja" + ANCChangeNumber.ToString(),
        //        Size = new Size(60, 20)
        //    };
        //    nTB_Estymacja.TextChanged += new EventHandler(CalcAfterChange_TextChanged);
        //    nTB_Estymacja.Leave += new EventHandler(RefreshEstimation_Leave);
        //    gb_STK.Controls.Add(nTB_Estymacja);

        //    //Percent
        //    TextBox nTB_Percent = new TextBox
        //    {
        //        Location = new Point(373, ((ANCChangeNumber - 1) * 26 + 80)),
        //        MaxLength = 3,
        //        Text = "100",
        //        Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
        //        Name = "TB_Percent" + ANCChangeNumber.ToString(),
        //        Size = new Size(32, 20)
        //    };
        //    nTB_Percent.TextChanged += new EventHandler(CalcAfterChange_TextChanged);
        //    nTB_Percent.Leave += new EventHandler(RefreshEstimation_Leave);
        //    gb_STK.Controls.Add(nTB_Percent);

        //    //Calculation
        //    Label nLab_Calc = new Label
        //    {
        //        AutoSize = true,
        //        Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
        //        Location = new Point(435, ((ANCChangeNumber - 1) * 26 + 83)),
        //        Name = "Lab_Calc" + ANCChangeNumber.ToString(),
        //        Size = new Size(48, 13),
        //        Text = ""
        //    };
        //    gb_STK.Controls.Add(nLab_Calc);

        //    //Next ANC 
        //    TextBox nTB_NextANC = new TextBox
        //    {
        //        Location = new Point(5, ((ANCChangeNumber - 1) * 26 + 20)),
        //        Name = "TB_NextANC" + ANCChangeNumber.ToString(),
        //        MaxLength = 9,
        //        Size = new Size(70, 20),

        //    };
        //    nTB_NextANC.TextChanged += new EventHandler(Tb_CheckifOK_TextChange);
        //    gb_NextANC.Controls.Add(nTB_NextANC);

        //    //Next ANC 2
        //    TextBox nTB_NextANC2 = new TextBox
        //    {
        //        Location = new Point(80, ((ANCChangeNumber - 1) * 26 + 20)),
        //        Name = "TB_NextANC2" + ANCChangeNumber.ToString(),
        //        MaxLength = 9,
        //        Size = new Size(70, 20),
        //        Enabled = false,
        //    };
        //    nTB_NextANC2.TextChanged += new EventHandler(Tb_CheckifOK_TextChange);
        //    gb_NextANC.Controls.Add(nTB_NextANC2);

        //    //Calc ANCBy - licz po tym ANC 
        //    CheckBox cb_ANCby = new CheckBox
        //    {
        //        AutoSize = true,
        //        Checked = false,
        //        Location = new Point(10, (ANCChangeNumber - 1) * 26 + 83),
        //        Name = "cb_ANCby" + ANCChangeNumber.ToString(),
        //        Size = new Size(80, 17),
        //        Text = "",
        //        UseVisualStyleBackColor = true
        //    };
        //    cb_ANCby.CheckedChanged += Cb_ANCby_CheckedChanged;
        //    gb_ANCby.Controls.Add(cb_ANCby);
        //}

        //private void ButtonRemoveANC()
        //{
        //    GroupBox gb_ANC = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ANC", true).First();
        //    GroupBox gb_STK = (GroupBox)mainProgram.TabControl.Controls.Find("gb_STK", true).First();
        //    GroupBox gb_NextANC = (GroupBox)mainProgram.TabControl.Controls.Find("gb_NextANC", true).First();
        //    GroupBox gb_ANCby = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ANCby", true).First();

        //    TextBox nTB_OLDANC = (TextBox)gb_ANC.Controls.Find("TB_OldANC" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANC.Controls.Remove(nTB_OLDANC);

        //    TextBox nTB_OLDANCQ = (TextBox)gb_ANC.Controls.Find("TB_OldANCQ" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANC.Controls.Remove(nTB_OLDANCQ);

        //    Label nLab_ANC = (Label)gb_ANC.Controls.Find("leb_ANC" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANC.Controls.Remove(nLab_ANC);

        //    TextBox nTB_NEWANC = (TextBox)gb_ANC.Controls.Find("TB_NewANC" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANC.Controls.Remove(nTB_NEWANC);

        //    TextBox nTB_NEWANCQ = (TextBox)gb_ANC.Controls.Find("TB_NewANCQ" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANC.Controls.Remove(nTB_NEWANCQ);

        //    Label nLab_OldStk = (Label)gb_STK.Controls.Find("lab_OldSTK" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_OldStk);

        //    Label nLab_Strz = (Label)gb_STK.Controls.Find("lab_Strz" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_Strz);

        //    Label nLab_NewSTK = (Label)gb_STK.Controls.Find("lab_NewSTK" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_NewSTK);

        //    Label nLab_Rowna = (Label)gb_STK.Controls.Find("lab_Rowna" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_Rowna);

        //    Label nLab_Delta = (Label)gb_STK.Controls.Find("lab_Delta" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_Delta);

        //    TextBox nTB_Estymacja = (TextBox)gb_STK.Controls.Find("TB_Estymacja" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nTB_Estymacja);

        //    TextBox nTB_Percent = (TextBox)gb_STK.Controls.Find("TB_Percent" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nTB_Percent);

        //    Label nLab_Calc = (Label)gb_STK.Controls.Find("Lab_Calc" + ANCChangeNumber.ToString(), false).First();
        //    gb_STK.Controls.Remove(nLab_Calc);

        //    TextBox nTB_NextANC = (TextBox)gb_NextANC.Controls.Find("TB_NextANC" + ANCChangeNumber.ToString(), false).First();
        //    gb_NextANC.Controls.Remove(nTB_NextANC);

        //    TextBox nTB_NextANC2 = (TextBox)gb_NextANC.Controls.Find("TB_NextANC2" + ANCChangeNumber.ToString(), false).First();
        //    gb_NextANC.Controls.Remove(nTB_NextANC2);

        //    CheckBox nCB_ANCby = (CheckBox)gb_ANCby.Controls.Find("cb_ANCby" + ANCChangeNumber.ToString(), false).First();
        //    gb_ANCby.Controls.Remove(nCB_ANCby);
        //}

        private bool CheckANCLength()
        {
            bool IfError = false;

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                TextBox NewANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First();
                TextBox OldANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First();
                TextBox NextANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + counter.ToString(), true).First();

                if (NewANC.Text.Length == 9) { }
                else if (NewANC.Text.Length == 0) { }
                else { IfError = true; }

                if (OldANC.Text.Length == 9) { }
                else if (OldANC.Text.Length == 0) { }
                else { IfError = true; }

                if (NextANC.Text.Length == 9) { }
                else if (NextANC.Text.Length == 0) { }
                else { IfError = true; }

            }
            if (IfError)
            {
                MessageBox.Show("Błędne ANC! Popraw ANC na czerwono!", "Popraw");
            }
            return IfError;
        }

        private void ChangeANCProtector(bool What)
        {
            if (What)
            {
                ChangeANC = true;
                ((Button)mainProgram.TabControl.Controls.Find("pb_RefreshSTK", true).First()).ForeColor = Color.Red;
            }
            else
            {
                ChangeANC = false;
                ((Button)mainProgram.TabControl.Controls.Find("pb_RefreshSTK", true).First()).ForeColor = Color.Black;
            }
        }

        private void ChangeCalcProtector(bool What)
        {
            if (What)
            {
                SavingCalc = true;
                ((Button)mainProgram.TabControl.Controls.Find("pb_SavingCalc", true).First()).ForeColor = Color.Red;
            }
            else
            {
                SavingCalc = false;
                ((Button)mainProgram.TabControl.Controls.Find("pb_SavingCalc", true).First()).ForeColor = Color.Black;
            }
        }

        private bool CheckBeforeSave()
        {
            bool Check = false;

            if (ChangeANC)
            {
                MessageBox.Show("ANC was Change, Please recalculate STK!", "Attention!!");
                Check = true;
            }
            else if (SavingCalc)
            {
                MessageBox.Show("STK was Recalculated, Please recalculate Action!", "Attention!!");
                Check = true;
            }

            return Check;
        }

        private void ChangeActionBlocker()
        {
            NumericUpDown ActionYear = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First();
            CheckBox ActiveActionCB = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First();
            ComboBox ActionMonth = ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First());

            if (ActiveActionCB.Checked)
            {
                if (ActionYear.Value == DateTime.Today.Year)
                {
                    if (WhatMonth(ActionMonth.Text) < DateTime.Today.Month - 1)
                    {
                        BlockAction();
                    }
                    else if (WhatMonth(ActionMonth.Text) >= DateTime.Today.Month - 1)
                    {
                        ActiveAction();
                    }
                }
                else if (ActionYear.Value > DateTime.Today.Year)
                {
                    ActiveAction();
                }
                else if (ActionYear.Value < DateTime.Today.Year)
                {
                    BlockAction();
                }
            }
            else
            {
                ActiveAction();
            }
        }

        private void ActiveAction()
        {
            _ = new Activation_Action(ANCChangeNumber);
        }

        private void BlockAction()
        {
            _ = new Deactivation_Action(ANCChangeNumber);
        }



        //Przerwania

        //Handler dla wpisywanych wartości Estymacji i Procentów przez użytkownika
        private void CalcAfterChange_TextChanged(object sender, EventArgs e)
        {
            RefreshEstymation2(sender as TextBox);
        }

        //Przerwanie przy wyjściu z Estimation i Percent STK
        private void RefreshEstimation_Leave(object sender, EventArgs e)
        {
            int Number;
            decimal Convert;
            string Percent;

            if ((sender as TextBox).Text != "")
            {
                if ((sender as TextBox).Text == "-")
                {
                    (sender as TextBox).Text = "";
                }
                Percent = (sender as TextBox).Name.Substring(0, 10);
                if (Percent == "TB_Percent")
                {
                    if ((sender as TextBox).Text == "")
                    {
                        (sender as TextBox).Text = "100";
                    }
                }

                //Sprawdzenie czy na pierwszej pozycji jest , - jak tak to dodać zero na początku
                Percent = (sender as TextBox).Text.Substring(0, 1);
                if (Percent == ",")
                {
                    (sender as TextBox).Text = "0" + (sender as TextBox).Text;
                }

                if ((sender as TextBox).Name.Length > 12)
                {
                    Number = int.Parse((sender as TextBox).Name.Remove(0, 12));
                }
                else
                {
                    Number = int.Parse((sender as TextBox).Name.Remove(0, 10));
                }

                if ((sender as TextBox).Text != "")
                {
                    Convert = decimal.Parse((sender as TextBox).Text);
                    Convert = Math.Round(Convert, 4, MidpointRounding.AwayFromZero);
                    (sender as TextBox).Text = Convert.ToString();
                }

                RefreshEstimation_Calc(Number);
            }
            Action_ChangeInAction();
        }

        //Przerwanie od sprawdzenia czy został wybrany tylko jeden checkbox dla ANCby
        private void Cb_ANCby_CheckedChanged(object sender, EventArgs e)
        {
            bool Status = false;
            CheckBox All = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_All", true).First();

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                CheckBox ANCby = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ANCby" + counter.ToString(), true).First();

                if (ANCby.Checked)
                {
                    Status = true;
                    All.Checked = false;
                    All.Enabled = false;
                    Mass_DMD_D45_Checked(false, "DMD");
                    Mass_DMD_D45_Checked(false, "D45");
                    Mass_DMD_D45_Enabled(false, "DMD");
                    Mass_DMD_D45_Enabled(false, "D45");
                }
            }

            if (!Status)
            {
                All.Enabled = true;
                Mass_DMD_D45_Enabled(true, "DMD");
                Mass_DMD_D45_Enabled(true, "D45");
            }
        }

        ////Przerwanie do wpisywania ANC New, Old, Next czy poza pierwszym znakiem jest char 
        //private void Tb_CheckifOK_TextChange(object sender, EventArgs e)
        //{
        //    TextBox TextToCheck = sender as TextBox;
        //    Regex GoodChar = new Regex("^[aA0-9]*$");
        //    Regex OnlyNumber = new Regex("^[0-9]*$");
        //    Regex SmallChar = new Regex("^[a]");
        //    int CursorPosition = TextToCheck.SelectionStart - 1;
        //    if (CursorPosition < 0)
        //    {
        //        CursorPosition = 0;
        //    }

        //    if (TextToCheck.Text.Length > 1)
        //    {
        //        string Check = TextToCheck.Text.Remove(0, 1);
        //        if (!OnlyNumber.IsMatch(Check))
        //        {
        //            Check = Regex.Replace(Check, @"[^0-9]+", "");

        //            TextToCheck.Text = TextToCheck.Text.Remove(1, TextToCheck.Text.Length - 1) + Check;
        //            TextToCheck.Focus();
        //            TextToCheck.SelectionStart = CursorPosition;
        //        }

        //        Check = TextToCheck.Text.Remove(1, TextToCheck.Text.Length - 1);
        //        if (!GoodChar.IsMatch(Check))
        //        {
        //            TextToCheck.Text = TextToCheck.Text.Remove(0, 1);
        //            TextToCheck.Focus();
        //            TextToCheck.SelectionStart = 0;
        //        }
        //        else if (Check == "a")
        //        {
        //            TextToCheck.Text = "A" + TextToCheck.Text.Remove(0, 1);
        //            TextToCheck.Focus();
        //            TextToCheck.SelectionStart = CursorPosition + 1;
        //        }

        //    }
        //    else if (TextToCheck.Text.Length == 1)
        //    {
        //        if (!GoodChar.IsMatch(TextToCheck.Text))
        //        {
        //            TextToCheck.Text = TextToCheck.Text.Substring(0, TextToCheck.Text.Length - 1);
        //            TextToCheck.Focus();
        //            TextToCheck.SelectionStart = TextToCheck.Text.Length;
        //        }
        //        if (SmallChar.IsMatch(TextToCheck.Text))
        //        {
        //            TextToCheck.Text = "A";
        //            TextToCheck.Focus();
        //            TextToCheck.SelectionStart = TextToCheck.Text.Length;
        //        }
        //    }
        //    if (TextToCheck.Text.Length < 9)
        //    {
        //        TextToCheck.ForeColor = Color.Red;
        //    }
        //    else if (TextToCheck.Text.Length == 9)
        //    {
        //        TextToCheck.ForeColor = Color.Black;
        //    }

        //    if (TextToCheck.Name.Substring(0, 10) != "TB_NextANC")
        //    {
        //        ChangeANCProtector(true);
        //        Tb_Quantity_Leave(sender, e);
        //    }
        //    Action_ChangeInAction();
        //}

        //Przerwanie dla Quantity czy jest prawidłowy
        //private void Tb_CheckIfQuantity_TextChange(object sender, EventArgs e)
        //{
        //    TextBox Quantity = sender as TextBox;
        //    Regex Good = new Regex("^[0-9,]*$");
        //    string[] Check;
        //    int CursorPosition = Quantity.SelectionStart - 1;

        //    if (!Good.IsMatch(Quantity.Text))
        //    {
        //        Quantity.Text = Quantity.Text.Substring(0, Quantity.Text.Length - 1);
        //        Quantity.Focus();
        //        Quantity.SelectionStart = Quantity.Text.Length;
        //    }

        //    Check = Quantity.Text.Split(',');
        //    if (Check.Length == 3)
        //    {
        //        Quantity.Text = Quantity.Text.Remove(Quantity.SelectionStart - 1, 1);
        //        Quantity.Focus();
        //        Quantity.SelectionStart = CursorPosition;
        //    }
        //    ChangeANCProtector(true);
        //    Action_ChangeInAction();

        //}

        //Przerwanie które sprawdza czy po wyjściu z Quantity nie ma pustego pola
        //private void Tb_Quantity_Leave(object sender, EventArgs e)
        //{
        //    TextBox Quantity;

        //    if ((sender as TextBox).Name.Substring(0, 10) == "TB_OldANCQ" || (sender as TextBox).Name.Substring(0, 10) == "TB_NewANCQ")
        //    {
        //        Quantity = sender as TextBox;
        //    }
        //    else
        //    {
        //        Quantity = (TextBox)mainProgram.TabControl.Controls.Find((sender as TextBox).Name.Insert(9, "Q"), true).First();
        //    }

        //    if (Quantity.Text.Length == 0)
        //    {
        //        string ANC = Quantity.Name.Remove(9, 1);
        //        TextBox Old_New = (TextBox)mainProgram.TabControl.Controls.Find(ANC, true).First();
        //        if (Old_New.Text == "")
        //        {
        //            Quantity.Text = "0";
        //        }
        //        else
        //        {
        //            Quantity.Text = "1";
        //        }
        //    }
        //    else
        //    {
        //        string ANC = Quantity.Name.Remove(9, 1);
        //        TextBox Old_New = (TextBox)mainProgram.TabControl.Controls.Find(ANC, true).First();
        //        if (Old_New.Text == "")
        //        {
        //            Quantity.Text = "0";
        //        }
        //        else if (Quantity.Text == "0")
        //        {
        //            Quantity.Text = "1";
        //        }
        //    }
        //}

        public void Mass_DMD_D45_Enabled(bool Status, string Instalation)
        {
            CheckBox FS = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FS", true).First();
            CheckBox FI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FI", true).First();
            CheckBox BI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_BI", true).First();
            CheckBox FSBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FSBU", true).First();
            CheckBox All = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation, true).First();

            All.Enabled = Status;
            FS.Enabled = Status;
            FI.Enabled = Status;
            BI.Enabled = Status;
            FSBU.Enabled = Status;
        }

        public void Mass_DMD_D45_Checked(bool Status, string Instalation)
        {
            CheckBox FS = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FS", true).First();
            CheckBox FI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FI", true).First();
            CheckBox BI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_BI", true).First();
            CheckBox FSBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FSBU", true).First();
            CheckBox All = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Mass_" + Instalation, true).First();

            All.Checked = Status;
            FS.Checked = Status;
            FI.Checked = Status;
            BI.Checked = Status;
            FSBU.Checked = Status;
        }
    }
}
