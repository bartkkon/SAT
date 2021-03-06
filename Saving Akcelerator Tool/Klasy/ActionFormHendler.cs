﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.Action.NewWindow.SpecialCalc;

namespace Saving_Accelerator_Tool
{
     public class ActionFormHendler
    {
        private readonly Action action;

        public ActionFormHendler(Action action)
        {
            this.action = action;
        }

        public void Cb_ECCCSpec_CheckedChanged(object sender, EventArgs e)
        {
            //((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First()).Enabled = !((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            //((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First()).Value = 0;
        }

        public void Cb_Installation_CheckedChanged(object sender, EventArgs e)
        {
            //Sprawdza jakie są wciśnięte ComboBoxy dla wybranych Instalacji + logika ich klikania i odklikiwania

            CheckBox cb_InstallAll = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_InstallAll", true).First();
            CheckBox cb_FS = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FS", true).First();
            CheckBox cb_FI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FI", true).First();
            CheckBox cb_BI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_BI", true).First();
            CheckBox cb_BU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_BU", true).First();
            CheckBox cb_FSBU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FSBU", true).First();

            cb_InstallAll.CheckedChanged -= Cb_Installation_CheckedChanged;
            cb_FS.CheckedChanged -= Cb_Installation_CheckedChanged;
            cb_FI.CheckedChanged -= Cb_Installation_CheckedChanged;
            cb_BI.CheckedChanged -= Cb_Installation_CheckedChanged;
            cb_BU.CheckedChanged -= Cb_Installation_CheckedChanged;
            cb_FSBU.CheckedChanged -= Cb_Installation_CheckedChanged;

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

            cb_InstallAll.CheckedChanged += Cb_Installation_CheckedChanged;
            cb_FS.CheckedChanged += Cb_Installation_CheckedChanged;
            cb_FI.CheckedChanged += Cb_Installation_CheckedChanged;
            cb_BI.CheckedChanged += Cb_Installation_CheckedChanged;
            cb_BU.CheckedChanged += Cb_Installation_CheckedChanged;
            cb_FSBU.CheckedChanged += Cb_Installation_CheckedChanged;

        }

        public void Pb_Curren_Carry_Click(object sender, EventArgs e)
        {
            Button pb_CurrentYear = (Button)MainProgram.Self.TabControl.Controls.Find("pb_CurrentYear", true).First();
            Button pb_CarryOver = (Button)MainProgram.Self.TabControl.Controls.Find("pb_CarryOver", true).First();

            if ((sender as Button).Text == "Start Year")
            {
                pb_CurrentYear.UseVisualStyleBackColor = false;
                pb_CurrentYear.BackColor = System.Drawing.Color.LightBlue;
                pb_CarryOver.UseVisualStyleBackColor = true;
                action.Action_CurrentCarry_Change("", ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text);

            }
            if ((sender as Button).Text == "Carry Over")
            {
                pb_CarryOver.UseVisualStyleBackColor = false;
                pb_CarryOver.BackColor = System.Drawing.Color.LightBlue;
                pb_CurrentYear.UseVisualStyleBackColor = true;
                action.Action_CurrentCarry_Change("Carry", ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text);
            }
        }

        public void Tb_PNCEStymation_TextChanged(object sender, EventArgs e)
        {
            string[] Estyma;
            TextBox tb_Estymacja = sender as TextBox;
            int CursorPosition = tb_Estymacja.SelectionStart - 1;
            int LenghtText = tb_Estymacja.Text.Length;
            Regex GoodChar = new Regex("^[0-9,-]*$");
            Regex GoodChar2 = new Regex("^[0-9,]*$");
            string CharToCheck;

            tb_Estymacja.TextChanged -= Tb_PNCEStymation_TextChanged;

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
            tb_Estymacja.TextChanged += Tb_PNCEStymation_TextChanged;
        }

        public void Tb_PNCEstimation_Leave(object sender, EventArgs e)
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

        public void Tree_Action_AfterSelect(object sender, TreeViewEventArgs e)
        {


            if (e.Node.Text == "Electronic" || e.Node.Text == "Mechanic" || e.Node.Text == "NVR" || e.Node.Text == "Electronic Carry Over" || e.Node.Text == "Mechanic Carry Over" || e.Node.Text == "NVR Carry Over")
            {
                //Przy wybranym tytule akcji nie dziej się nie 
            }
            else
            {
                if (Users.Singleton().Action == "Developer")
                {
                    ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ActiveAction", true).First()).Enabled = true;
                }

                if (action.Action_IfcanChange())
                {
                    DialogResult Results = MessageBox.Show("Do you want save change ?", "Save?", MessageBoxButtons.YesNo);

                    if (Results == DialogResult.Yes)
                    {
                        action.Action_Save();
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

        public void Pb_SavingCalc_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            action.Action_SavingCalculation();
            Cursor.Current = Cursors.Default;
        }

        public void Pb_PNC_Click(object sender, EventArgs e)
        {
            Form AddData = new AddData("Proszę podać liste PNC", "PNC");
            int DG_RowsCountStart = ((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;

            AddData.ShowDialog();
            int DG_RowsCountFinish = ((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;
            if (DG_RowsCountStart != DG_RowsCountFinish)
            {
                action.Action_CalcNeed();
                action.Action_ChangeInAction();
            }
        }

        public void Pb_PNCSpec_Click(object sender, EventArgs e)
        {
            Form AddData = new AddData("Proszę podać liste PNC", "PNCSpec");
            int DG_RowsCountStart = ((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;

            AddData.ShowDialog();
            int DG_RowsCountFinish = ((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count;
            if (DG_RowsCountStart != DG_RowsCountFinish)
            {
                action.Action_STKCalcNeed();
                action.Action_ChangeInAction();
            }
        }

        public void Pb_Save_Click(object sender, EventArgs e)
        {
            action.Action_Save();
        }

        public void Pb_RefreshSTK_Click(object sender, EventArgs e)
        {
            if (action.Action_CheckANCLenght())
            {
                return;
            }
            action.Action_RefreshSTK();
        }

        public void But_TreeRefresh_Click(object sender, EventArgs e)
        {
            action.Action_TreeRefresh();
        }

        public void Cb_ECCC_CheckedChanged(object sender, EventArgs e)
        {
            ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First()).Enabled = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Enabled = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCC", true).First()).Checked;
            ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First()).Value = 0;
            action.Action_ChangeInAction();
        }

        public void Pb_SaveDraft_Click(object sender, EventArgs e)
        {

        }

        public void Cb_Active_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Idea = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Idea", true).First();

            cb_Idea.CheckedChanged -= Cb_Idea_CheckedChanged;
            cb_Idea.Checked = false;
            action.Action_ChangeInAction();
            cb_Idea.CheckedChanged += Cb_Idea_CheckedChanged;
        }

        public void Cb_Idea_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Active = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Active", true).First();

            cb_Active.CheckedChanged -= Cb_Active_CheckedChanged;
            cb_Active.Checked = false;
            action.Action_ChangeInAction();
            cb_Active.CheckedChanged += Cb_Active_CheckedChanged;
        }

        public void Cb_Calc_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_CalcANC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcANC", true).First();
            CheckBox cb_CalcANCby = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcANCby", true).First();
            CheckBox cb_CalcPNC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNC", true).First();
            CheckBox cb_CalcPNCSpec = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNCSpec", true).First();
            Button pb_PNC = (Button)MainProgram.Self.TabControl.Controls.Find("pb_PNC", true).First();
            Button pb_PNCSpec = (Button)MainProgram.Self.TabControl.Controls.Find("pb_PNCSPec", true).First();
            Button PB_SavePNC = (Button)MainProgram.Self.TabControl.Controls.Find("PB_SavePNC", true).First();
            GroupBox gb_PNC = (GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_PNC", true).First();
            DataGridView dg_PNC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();
            GroupBox gb_Estyma = (GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_PNCEsty", true).First();
            GroupBox gb_ANCby = (GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ANCby", true).First();
            CheckBox cb_ECCCSpec = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCCSpec", true).First();
            CheckBox cb_ECCC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCC", true).First();
            NumericUpDown num_ECCC = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First();
            GroupBox Mass = (GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_MassCalc", true).First();

            cb_CalcANC.CheckedChanged -= Cb_Calc_CheckedChanged;
            cb_CalcANCby.CheckedChanged -= Cb_Calc_CheckedChanged;
            cb_CalcPNC.CheckedChanged -= Cb_Calc_CheckedChanged;
            cb_CalcPNCSpec.CheckedChanged -= Cb_Calc_CheckedChanged;
            cb_ECCCSpec.CheckedChanged -= Cb_Calc_CheckedChanged;

            if ((sender as CheckBox).Text == "ANC")
            {
                cb_CalcANC.Checked = true;
                cb_CalcANCby.Checked = false;
                cb_CalcPNC.Checked = false;
                cb_CalcPNCSpec.Checked = false;
                pb_PNC.Enabled = false;
                pb_PNCSpec.Enabled = false;
                gb_PNC.Enabled = false;
                gb_PNC.Visible = false;
                Mass.Visible = false;
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
                if (Users.Singleton().Role == "Admin")
                {
                    ((Button)MainProgram.Self.TabControl.Controls.Find("PB_SpecialCalc", true).First()).Visible = false;
                }

            }
            if ((sender as CheckBox).Text == "ANC Special")
            {
                cb_CalcANC.Checked = false;
                cb_CalcANCby.Checked = true;
                cb_CalcPNC.Checked = false;
                cb_CalcPNCSpec.Checked = false;
                pb_PNC.Enabled = false;
                pb_PNCSpec.Enabled = false;
                gb_PNC.Visible = false;
                gb_PNC.Enabled = false;
                Mass.Visible = true;
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
                if (Users.Singleton().Role == "Admin")
                {
                    ((Button)MainProgram.Self.TabControl.Controls.Find("PB_SpecialCalc", true).First()).Visible = false;
                }

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
                gb_PNC.Visible = true;
                Mass.Visible = false;
                gb_Estyma.Visible = false;
                gb_ANCby.Visible = false;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = false;
                PB_SavePNC.Visible = true;
                if (cb_ECCC.Checked)
                    num_ECCC.Enabled = true;
                else
                    num_ECCC.Enabled = false;
                if (Users.Singleton().Role == "Admin")
                {
                    ((Button)MainProgram.Self.TabControl.Controls.Find("PB_SpecialCalc", true).First()).Visible =false;
                }

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
                gb_PNC.Visible = true;
                Mass.Visible = false;
                gb_Estyma.Visible = true;
                gb_ANCby.Visible = false;
                cb_ECCCSpec.Checked = false;
                cb_ECCCSpec.Visible = true;
                PB_SavePNC.Visible = true;
                if (cb_ECCC.Checked && !cb_ECCCSpec.Checked)
                {
                    num_ECCC.Enabled = true;
                }
                if(Users.Singleton().Role == "Admin")
                {
                    ((Button)MainProgram.Self.TabControl.Controls.Find("PB_SpecialCalc", true).First()).Visible = true;
                }
            }

            if ((sender as CheckBox).Text == "From PNC Spec")
            {
                num_ECCC.Enabled = !cb_ECCCSpec.Checked;
            }

            action.Action_ChangeInAction();

            cb_CalcANC.CheckedChanged += Cb_Calc_CheckedChanged;
            cb_CalcANCby.CheckedChanged += Cb_Calc_CheckedChanged;
            cb_CalcPNC.CheckedChanged += Cb_Calc_CheckedChanged;
            cb_CalcPNCSpec.CheckedChanged += Cb_Calc_CheckedChanged;
            cb_ECCCSpec.CheckedChanged += Cb_Calc_CheckedChanged;
        }

        public void But_Action_NewAction_Click(object sender, EventArgs e)
        {
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ActiveAction", true).First()).Enabled = true;
            action.Action_NewAction();
        }

        public void Pb_Plus_Click(object sender, EventArgs e)
        {
            action.Action_AddANC();
            action.Action_ChangeInAction();
        }

        public void Pb_Minus_Click(object sender, EventArgs e)
        {
            action.Action_RemoveANC();
            action.Action_ChangeInAction();
        }

        public void Description_TextChange(object sender, EventArgs e)
        {
            Label MaxLength = (Label)MainProgram.Self.TabControl.Controls.Find("Lab_MaxLength", true).First();
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
            action.Action_CalcNeed();
            action.Action_ChangeInAction();
        }

        public void IDCO_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> IDCODictionaty;
            int ANCChangeNumber;

            IDCODictionaty = action.Action_IDCODictionary();
            ANCChangeNumber = action.Action_ANCChangeNumber();
            Form ActionFunction = new ActionFunction(IDCODictionaty, ANCChangeNumber, MainProgram.Self);
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
            CheckBox Active = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ActionActive", true).First();
            CheckBox Idea = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ActionIdea", true).First();

            Active.CheckedChanged -= Active_Idea_CheckedChange;
            Idea.CheckedChanged -= Active_Idea_CheckedChange;

            if (Check.Text == "Active Action")
            {
                Active.Checked = true;
                Idea.Checked = false;
            }
            else if (Check.Text == "Idea Action")
            {
                Active.Checked = false;
                Idea.Checked = true;
            }
            action.Action_ChangeInAction();

            Active.CheckedChanged += Active_Idea_CheckedChange;
            Idea.CheckedChanged += Active_Idea_CheckedChange;
        }

        public void Combo_Devision_SelectedIndexChange(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void Num_YearAction_ValueChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void Combox_Month_SelectedIndexChange(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void Combox_Leader_SelectedIndexChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void Combox_Factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void Cb_Platform_CheckedChanged(object sender, EventArgs e)
        {
            action.Action_ChangeInAction();
        }

        public void SavePNC_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SavePNC();
            Cursor.Current = Cursors.Default;
        }

        public void Cb_Mass_DMD_CheckedChange(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                Mass_DMD_D45_Enabled(false, "DMD");
                Mass_DMD_D45_Checked(false, "DMD");
            }
            else
            {
                Mass_DMD_D45_Enabled(true, "DMD");
                Mass_DMD_D45_Checked(false, "DMD");
            }
        }

        public void Cb_Mass_D45_CheckedChange(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                Mass_DMD_D45_Enabled(false, "D45");
                Mass_DMD_D45_Checked(false, "D45");
            }
            else
            {
                Mass_DMD_D45_Enabled(true, "D45");
                Mass_DMD_D45_Checked(false, "D45");
            }
        }

        public void Cb_Mass_All_CheckedChange(object sender, EventArgs e)
        {
            CheckBox DMD = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD", true).First();
            CheckBox D45 = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45", true).First();

            if((sender as CheckBox).Checked)
            {
                DMD.Checked = false;
                DMD.Enabled = false;
                D45.Checked = false;
                D45.Enabled = false;
                Mass_DMD_D45_Enabled(false, "DMD");
                Mass_DMD_D45_Checked(false, "DMD");
                Mass_DMD_D45_Enabled(false, "D45");
                Mass_DMD_D45_Checked(false, "D45");
            }
            else
            {
                DMD.Enabled = true;
                D45.Enabled = true;
                Mass_DMD_D45_Enabled(true, "DMD");
                Mass_DMD_D45_Checked(false, "DMD");
                Mass_DMD_D45_Enabled(true, "D45");
                Mass_DMD_D45_Checked(false, "D45");
            }
        }

        public void Mass_DMD_D45_Enabled (bool Status, string Instalation)
        {
            CheckBox FS = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_"+Instalation+"_FS", true).First();
            CheckBox FI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FI", true).First();
            CheckBox BI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_BI", true).First();
            CheckBox FSBU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FSBU", true).First();

            FS.Enabled = Status;
            FI.Enabled = Status;
            BI.Enabled = Status;
            FSBU.Enabled = Status;
        }

        public void Mass_DMD_D45_Checked(bool Status, string Instalation)
        {
            CheckBox FS = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FS", true).First();
            CheckBox FI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FI", true).First();
            CheckBox BI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_BI", true).First();
            CheckBox FSBU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_" + Instalation + "_FSBU", true).First();

            FS.Checked = Status;
            FI.Checked = Status;
            BI.Checked = Status;
            FSBU.Checked = Status;
        }

        public void Pb_SpecialCalc_Click(object sender, EventArgs e)
        {
            SpecialCalcAction SpecialCalc = new SpecialCalcAction();
            SpecialCalc.ShowDialog();
        }
    }
}
