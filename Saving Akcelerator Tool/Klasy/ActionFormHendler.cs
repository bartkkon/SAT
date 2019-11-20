using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    class ActionFormHendler
    {
        MainProgram mainProgram;
        Action action;
        Admin admin;
        DataRow Person;
        SummaryDetails summaryDetails;
        Data_Import ImportData;

        public ActionFormHendler(MainProgram mainProgram, Action action, SummaryDetails summaryDetails, Admin admin, Data_Import ImportData, DataRow Person)
        {
            this.mainProgram = mainProgram;
            this.mainProgram = mainProgram;
            this.action = action;
            this.summaryDetails = summaryDetails;
            this.admin = admin;
            this.ImportData = ImportData;
            this.Person = Person;
        }

        public void cb_ECCCSpec_CheckedChanged(object sender, EventArgs e)
        {
            //((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Enabled = !((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            //((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value = 0;
        }

        public void cb_Installation_CheckedChanged(object sender, EventArgs e)
        {
            //Sprawdza jakie są wciśnięte ComboBoxy dla wybranych Instalacji + logika ich klikania i odklikiwania

            CheckBox cb_InstallAll = (CheckBox)mainProgram.TabControl.Controls.Find("cb_InstallAll", true).First();
            CheckBox cb_FS = (CheckBox)mainProgram.TabControl.Controls.Find("cb_FS", true).First();
            CheckBox cb_FI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_FI", true).First();
            CheckBox cb_BI = (CheckBox)mainProgram.TabControl.Controls.Find("cb_BI", true).First();
            CheckBox cb_BU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_BU", true).First();
            CheckBox cb_FSBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_FSBU", true).First();

            cb_InstallAll.CheckedChanged -= cb_Installation_CheckedChanged;
            cb_FS.CheckedChanged -= cb_Installation_CheckedChanged;
            cb_FI.CheckedChanged -= cb_Installation_CheckedChanged;
            cb_BI.CheckedChanged -= cb_Installation_CheckedChanged;
            cb_BU.CheckedChanged -= cb_Installation_CheckedChanged;
            cb_FSBU.CheckedChanged -= cb_Installation_CheckedChanged;

            if ((sender as CheckBox).Name == "cb_InstallAll")
            {
                if ((sender as CheckBox).Checked)
                {
                    cb_FS.Checked = true;
                    cb_FI.Checked = true;
                    cb_BI.Checked = true;
                    cb_BU.Checked = true;
                    cb_FSBU.Checked = true;
                }
                else
                {
                    cb_FS.Checked = false;
                    cb_FI.Checked = false;
                    cb_BI.Checked = false;
                    cb_BU.Checked = false;
                    cb_FSBU.Checked = false;
                }
            }
            else
            {
                if (!(sender as CheckBox).Checked)
                {
                    cb_InstallAll.Checked = false;
                }
                if (cb_FS.Checked && cb_FI.Checked && cb_BI.Checked && cb_BU.Checked && cb_FSBU.Checked)
                {
                    cb_InstallAll.Checked = true;
                }
            }

            action.Action_ChangeInAction();

            cb_InstallAll.CheckedChanged += cb_Installation_CheckedChanged;
            cb_FS.CheckedChanged += cb_Installation_CheckedChanged;
            cb_FI.CheckedChanged += cb_Installation_CheckedChanged;
            cb_BI.CheckedChanged += cb_Installation_CheckedChanged;
            cb_BU.CheckedChanged += cb_Installation_CheckedChanged;
            cb_FSBU.CheckedChanged += cb_Installation_CheckedChanged;

        }

        public void pb_Curren_Carry_Click(object sender, EventArgs e)
        {
            Button pb_CurrentYear = (Button)mainProgram.TabControl.Controls.Find("pb_CurrentYear", true).First();
            Button pb_CarryOver = (Button)mainProgram.TabControl.Controls.Find("pb_CarryOver", true).First();

            if ((sender as Button).Text == "Start Year")
            {
                pb_CurrentYear.UseVisualStyleBackColor = false;
                pb_CurrentYear.BackColor = System.Drawing.Color.LightBlue;
                pb_CarryOver.UseVisualStyleBackColor = true;
                action.Action_CurrentCarry_Change("", ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text);

            }
            if ((sender as Button).Text == "Carry Over")
            {
                pb_CarryOver.UseVisualStyleBackColor = false;
                pb_CarryOver.BackColor = System.Drawing.Color.LightBlue;
                pb_CurrentYear.UseVisualStyleBackColor = true;
                action.Action_CurrentCarry_Change("Carry", ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text);
            }
        }

        public void tb_PNCEStymation_TextChanged(object sender, EventArgs e)
        {
            string[] Estyma;
            TextBox tb_Estymacja = sender as TextBox;
            int CursorPosition = tb_Estymacja.SelectionStart - 1;
            int LenghtText = tb_Estymacja.Text.Length;
            Regex GoodChar = new Regex("^[0-9,-]*$");
            Regex GoodChar2 = new Regex("^[0-9,]*$");
            string CharToCheck;

            tb_Estymacja.TextChanged -= tb_PNCEStymation_TextChanged;

            if (CursorPosition < 0)
            {
                CursorPosition = 0;
            }

            if (tb_Estymacja.Text.Length != 0)
            {
                Estyma = tb_Estymacja.Text.Split('.');
                if (Estyma.Length == 2)
                {
                    tb_Estymacja.Text = tb_Estymacja.Text.Replace('.', ',');
                    tb_Estymacja.Focus();
                    tb_Estymacja.SelectionStart = CursorPosition + 1;
                }

                Estyma = tb_Estymacja.Text.Split(',');
                if (Estyma.Length > 2)
                {
                    if (tb_Estymacja.SelectionStart == tb_Estymacja.Text.Length)
                    {
                        tb_Estymacja.Text = tb_Estymacja.Text.Substring(0, CursorPosition);
                    }
                    else
                    {
                        tb_Estymacja.Text = tb_Estymacja.Text.Substring(0, CursorPosition) + tb_Estymacja.Text.Substring(tb_Estymacja.SelectionStart, tb_Estymacja.Text.Length - tb_Estymacja.SelectionStart);
                    }

                    tb_Estymacja.Focus();
                    tb_Estymacja.SelectionStart = CursorPosition;
                }

                if (!GoodChar.IsMatch(tb_Estymacja.Text))
                {
                    tb_Estymacja.Text = Regex.Replace(tb_Estymacja.Text, @"[^0-9,-]+", "");
                    tb_Estymacja.Focus();
                    tb_Estymacja.SelectionStart = CursorPosition;
                }

                CharToCheck = tb_Estymacja.Text.Substring(1, tb_Estymacja.Text.Length - 1);
                if (!GoodChar2.IsMatch(CharToCheck))
                {
                    CharToCheck = Regex.Replace(CharToCheck, @"[^0-9,]+", "");
                    tb_Estymacja.Text = tb_Estymacja.Text.Substring(0, 1) + CharToCheck;
                    tb_Estymacja.Focus();
                    tb_Estymacja.SelectionStart = CursorPosition;
                }
            }

            action.Action_ChangeInAction();
            action.Action_CalcNeed();
            tb_Estymacja.TextChanged += tb_PNCEStymation_TextChanged;
        }

        public void tb_PNCEstimation_Leave(object sender, EventArgs e)
        {
            TextBox PNCEstimation = sender as TextBox;
            decimal Convert = 0;

            if (PNCEstimation.Text.Length != 0)
            {
                Convert = decimal.Parse(PNCEstimation.Text);
                Convert = Math.Round(Convert, 4, MidpointRounding.AwayFromZero);
                PNCEstimation.Text = Convert.ToString();
            }
            else
            {
                PNCEstimation.Text = Convert.ToString();
            }

            if (Convert > 0)
            {
                PNCEstimation.ForeColor = Color.Green;
            }
            else if (Convert < 0)
            {
                PNCEstimation.ForeColor = Color.Red;
            }
            else
            {
                PNCEstimation.ForeColor = Color.Black;
            }
        }

        public void tree_Action_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

            if (e.Node.Text == "Electronic" || e.Node.Text == "Mechanic" || e.Node.Text == "NVR" || e.Node.Text == "Electronic Carry Over" || e.Node.Text == "Mechanic Carry Over" || e.Node.Text == "NVR Carry Over")
            {
                //Przy wybranym tytule akcji nie dziej się nie 
            }
            else
            {
                if (Person["Action"].ToString() == "Developer")
                {
                    ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Enabled = true;
                }

                if(action.Action_IfcanChange())
                {
                    DialogResult Results = MessageBox.Show("Do you want save change ?", "Save?", MessageBoxButtons.YesNo);

                    if(Results == DialogResult.Yes)
                    {
                        action.Action_Save(mainProgram, Person);
                        action.Action_Load(e.Node.Text);
                    }
                    else
                    {
                        action.Action_Load(e.Node.Text);
                    }
                }
                else
                {
                    action.Action_Load(e.Node.Text);
                }
            }
        }

        public void pb_SavingCalc_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            action.Action_SavingCalculation();
            Cursor.Current = Cursors.Default;
        }

        public void pb_PNC_Click(object sender, EventArgs e)
        {
            Form AddData = new AddData("Proszę podać liste PNC", "PNC", mainProgram, ImportData);
            int DG_RowsCountStart = ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;

            AddData.ShowDialog();
            int DG_RowsCountFinish = ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;
            if (DG_RowsCountStart != DG_RowsCountFinish)
            {
                action.Action_CalcNeed();
                action.Action_ChangeInAction();
            }
        }

        public void pb_PNCSpec_Click(object sender, EventArgs e)
        {
            Form AddData = new AddData("Proszę podać liste PNC", "PNCSpec", mainProgram, ImportData);
            int DG_RowsCountStart = ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;

            AddData.ShowDialog();
            int DG_RowsCountFinish = ((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;
            if(DG_RowsCountStart != DG_RowsCountFinish)
            {
                action.Action_STKCalcNeed();
                action.Action_ChangeInAction();
            }
        }

        public void pb_Save_Click(object sender, EventArgs e)
        {
            action.Action_Save(mainProgram, Person);
        }

        public void pb_RefreshSTK_Click(object sender, EventArgs e)
        {
            if (action.Action_CheckANCLenght())
            {
                return;
            }
            action.Action_RefreshSTK();
        }

        public void but_TreeRefresh_Click(object sender, EventArgs e)
        {
            action.Action_TreeRefresh(Person);
        }

        public void cb_ECCC_CheckedChanged(object sender, EventArgs e)
        {
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Enabled = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Enabled = ((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value = 0;
            action.Action_ChangeInAction();
        }

        public void pb_SaveDraft_Click(object sender, EventArgs e)
        {

        }

        public void cb_Active_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Idea = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Idea", true).First();

            cb_Idea.CheckedChanged -= cb_Idea_CheckedChanged;
            cb_Idea.Checked = false;
            action.Action_ChangeInAction();
            cb_Idea.CheckedChanged += cb_Idea_CheckedChanged;
        }

        public void cb_Idea_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Active = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First();

            cb_Active.CheckedChanged -= cb_Active_CheckedChanged;
            cb_Active.Checked = false;
            action.Action_ChangeInAction();
            cb_Active.CheckedChanged += cb_Active_CheckedChanged;
        }

        public void cb_Calc_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_CalcANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANC", true).First();
            CheckBox cb_CalcANCby = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANCby", true).First();
            CheckBox cb_CalcPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNC", true).First();
            CheckBox cb_CalcPNCSpec = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First();
            Button pb_PNC = (Button)mainProgram.TabControl.Controls.Find("pb_PNC", true).First();
            Button pb_PNCSpec = (Button)mainProgram.TabControl.Controls.Find("pb_PNCSPec", true).First();
            Button PB_SavePNC = (Button)MainProgram.Self.TabControl.Controls.Find("PB_SavePNC", true).First();
            GroupBox gb_PNC = (GroupBox)mainProgram.TabControl.Controls.Find("gb_PNC", true).First();
            DataGridView dg_PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
            GroupBox gb_Estyma = (GroupBox)mainProgram.TabControl.Controls.Find("gb_PNCEsty", true).First();
            GroupBox gb_ANCby = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ANCby", true).First();
            CheckBox cb_ECCCSpec = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First();
            CheckBox cb_ECCC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First();
            NumericUpDown num_ECCC = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First();

            cb_CalcANC.CheckedChanged -= cb_Calc_CheckedChanged;
            cb_CalcANCby.CheckedChanged -= cb_Calc_CheckedChanged;
            cb_CalcPNC.CheckedChanged -= cb_Calc_CheckedChanged;
            cb_CalcPNCSpec.CheckedChanged -= cb_Calc_CheckedChanged;
            cb_ECCCSpec.CheckedChanged -= cb_Calc_CheckedChanged;

            if ((sender as CheckBox).Text == "ANC")
            {
                cb_CalcANC.Checked = true;
                cb_CalcANCby.Checked = false;
                cb_CalcPNC.Checked = false;
                cb_CalcPNCSpec.Checked = false;
                pb_PNC.Enabled = false;
                pb_PNCSpec.Enabled = false;
                gb_PNC.Enabled = false;
                dg_PNC.Rows.Clear();
                dg_PNC.Columns.Clear();
                gb_Estyma.Visible = false;
                gb_ANCby.Visible = false;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = false;
                PB_SavePNC.Visible = false;
                if (cb_ECCC.Checked)
                    num_ECCC.Enabled = true;
                else
                    num_ECCC.Enabled = false;

            }
            if ((sender as CheckBox).Text == "ANC Special")
            {
                cb_CalcANC.Checked = false;
                cb_CalcANCby.Checked = true;
                cb_CalcPNC.Checked = false;
                cb_CalcPNCSpec.Checked = false;
                pb_PNC.Enabled = false;
                pb_PNCSpec.Enabled = false;
                gb_PNC.Enabled = false;
                dg_PNC.Rows.Clear();
                dg_PNC.Columns.Clear();
                gb_Estyma.Visible = false;
                gb_ANCby.Visible = true;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = false;
                PB_SavePNC.Visible = false;
                if (cb_ECCC.Checked)
                    num_ECCC.Enabled = true;
                else
                    num_ECCC.Enabled = false;

            }
            if ((sender as CheckBox).Text == "PNC")
            {
                cb_CalcANC.Checked = false;
                cb_CalcANCby.Checked = false;
                cb_CalcPNC.Checked = true;
                cb_CalcPNCSpec.Checked = false;
                pb_PNC.Enabled = true;
                pb_PNCSpec.Enabled = false;
                gb_PNC.Enabled = true;
                gb_Estyma.Visible = false;
                gb_ANCby.Visible = false;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = false;
                PB_SavePNC.Visible = true;
                if (cb_ECCC.Checked)
                    num_ECCC.Enabled = true;
                else
                    num_ECCC.Enabled = false;

            }
            if ((sender as CheckBox).Text == "PNC Special")
            {
                cb_CalcANC.Checked = false;
                cb_CalcANCby.Checked = false;
                cb_CalcPNC.Checked = false;
                cb_CalcPNCSpec.Checked = true;
                pb_PNC.Enabled = false;
                pb_PNCSpec.Enabled = true;
                gb_PNC.Enabled = true;
                gb_Estyma.Visible = true;
                gb_ANCby.Visible = false;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = true;
                PB_SavePNC.Visible = true;
                if (cb_ECCC.Checked && !cb_ECCCSpec.Checked)
                {
                    num_ECCC.Enabled = true;
                }
            }

            if ((sender as CheckBox).Text == "From PNC Spec")
            {
                num_ECCC.Enabled = !cb_ECCCSpec.Checked;
            }

            action.Action_ChangeInAction();

            cb_CalcANC.CheckedChanged += cb_Calc_CheckedChanged;
            cb_CalcANCby.CheckedChanged += cb_Calc_CheckedChanged;
            cb_CalcPNC.CheckedChanged += cb_Calc_CheckedChanged;
            cb_CalcPNCSpec.CheckedChanged += cb_Calc_CheckedChanged;
            cb_ECCCSpec.CheckedChanged += cb_Calc_CheckedChanged;
        }

        public void but_Action_NewAction_Click(object sender, EventArgs e)
        {
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Enabled = true;
            action.Action_NewAction(mainProgram, Person);
        }

        public void pb_Plus_Click(object sender, EventArgs e)
        {
            action.Action_AddANC();
            action.Action_ChangeInAction();
        }

        public void pb_Minus_Click(object sender, EventArgs e)
        {
            action.Action_RemoveANC();
            action.Action_ChangeInAction();
        }

        public void Description_TextChange(object sender, EventArgs e)
        {
            Label MaxLength = (Label)mainProgram.TabControl.Controls.Find("Lab_MaxLength", true).First();
            TextBox Description = sender as TextBox;

            MaxLength.Text = Description.Text.Length.ToString() + "/1000";
            action.Action_ChangeInAction();
        }

        public void Tb_PercentQuantity_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "100";
            }
        }

        public void Tb_PercentQuantity_TextChange(object sender, EventArgs e)
        {
            TextBox PercentQuantity = sender as TextBox;

            PercentQuantity.Text = Regex.Replace(PercentQuantity.Text, @"[^0-9,]+", "");
            action.Action_ChangeInAction();
        }

        public void IDCO_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> IDCODictionaty = new Dictionary<string, string>();
            int ANCChangeNumber;

            IDCODictionaty = action.Action_IDCODictionary();
            ANCChangeNumber = action.Action_ANCChangeNumber();
            Form ActionFunction = new ActionFunction(IDCODictionaty, ANCChangeNumber, mainProgram);
            ActionFunction.ShowDialog();
        }

        public void Name_TextChange(object sender, EventArgs e)
        {
            TextBox Name = sender as TextBox;
            int Index = Name.SelectionStart;
            int Start;
            int End;
            if (Name.Text != "")
            {
                Start = Name.Text.Length;

                Name.Text = Name.Text.Replace(";", "");
                Name.Text = Name.Text.Replace("|", "");
                Name.Text = Name.Text.Replace("@", "");
                Name.Text = Name.Text.Replace(":", "");

                End = Name.Text.Length;
                if (Index != 0)
                {
                    if (Start == End)
                    {
                        return;
                    }
                    if (Start > End)
                    {
                        Name.SelectionStart = Index - 1;
                    }
                }
            }
            action.Action_ChangeInAction();
        }

        public void Name_Leave(object sender, EventArgs e)
        {
            TextBox Name = sender as TextBox;

            Name.Text = Name.Text.Trim();
        }

        public void Active_Idea_CheckedChange(object sender, EventArgs e)
        {
            CheckBox Check = sender as CheckBox;
            CheckBox Active = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ActionActive", true).First();
            CheckBox Idea = (CheckBox)mainProgram.TabControl.Controls.Find("cb_ActionIdea", true).First();

            Active.CheckedChanged -= Active_Idea_CheckedChange;
            Idea.CheckedChanged -= Active_Idea_CheckedChange;

            if (Check.Text == "Active Action")
            {
                Active.Checked = true;
                Idea.Checked = false;
            }
            else if(Check.Text == "Idea Action")
            {
                Active.Checked = false;
                Idea.Checked = true;
            }
            action.Action_ChangeInAction();

            Active.CheckedChanged += Active_Idea_CheckedChange;
            Idea.CheckedChanged += Active_Idea_CheckedChange;
        }

        public void combo_Devision_SelectedIndexChange (object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void num_YearAction_ValueChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void combox_Month_SelectedIndexChange(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void combox_Leader_SelectedIndexChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void combox_Factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void cb_Platform_CheckedChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void SavePNC_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SavePNC Save = new SavePNC();
            Cursor.Current = Cursors.Default;
        }
    }
}
