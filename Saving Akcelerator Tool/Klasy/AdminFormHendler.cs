using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class AdminFormHendler
    {
        MainProgram mainProgram;
        Action action;
        Admin admin;
        DataRow Person;
        SummaryDetails summaryDetails;
        Data_Import ImportData;
        //TabPage tab_Admin;

        public AdminFormHendler(MainProgram mainProgram, Action action, SummaryDetails summaryDetails, Admin admin, Data_Import ImportData, DataRow Person)
        {
            this.mainProgram = mainProgram;
            this.action = action;
            this.summaryDetails = summaryDetails;
            this.admin = admin;
            this.ImportData = ImportData;
            this.Person = Person;

        }

        public void pb_Admin_AddColumn_Click(object sender, EventArgs e)
        {
            TextBox tb_AdminAddColumn = (TextBox)mainProgram.Controls.Find("tb_AdminAddColumn", true).First();

            if (tb_AdminAddColumn.Text == "")
            {
                MessageBox.Show("Brak nazwy nowej kolumny", "Uwaga !!!!");
            }
            {
                Cursor.Current = Cursors.WaitCursor;
                action.Action_AddColumn();
                Cursor.Current = Cursors.Default;
            }
        }

        public void Pb_AdminTargets_Save_Click(object sender, EventArgs e)
        {
            admin.Admin_TargetsSave();
        }

        public void Pb_AdminTargets_Open_Click(object sender, EventArgs e)
        {
            admin.Admin_TargetsOpen();
        }

        public void Tb_AdminTargets_TextChange(object sender, EventArgs e)
        {
            TextBox ChangeText = (sender as TextBox);

            decimal delta = 0;

            if (!string.IsNullOrWhiteSpace(ChangeText.Text))
            {
                if (ChangeText.Text.Substring(ChangeText.Text.Length - 1, 1) != "-")
                {
                    if (ChangeText.Text.Substring(ChangeText.Text.Length - 1, 1) != ".")
                    {
                        ChangeText.Text = ChangeText.Text.Replace('.', ',');
                        ChangeText.Focus();
                        ChangeText.SelectionStart = ChangeText.Text.Length;
                    }
                    if (ChangeText.Text.Substring(ChangeText.Text.Length - 1, 1) != ",")
                    {
                        if (!Char.IsNumber(char.Parse(ChangeText.Text.Substring(ChangeText.Text.Length - 1, 1))))
                        {
                            ChangeText.Text = ChangeText.Text.Substring(0, ChangeText.Text.Length - 1);
                            ChangeText.Focus();
                            ChangeText.SelectionStart = ChangeText.Text.Length;
                        }
                    }
                }
            }

            if(ChangeText.Name == "Tb_AdminTargetsDM")
            {
                ChangeText.Text = string.Format("{0:# ### ##0}", double.Parse(ChangeText.Text));
            }

            if (ChangeText.Name == "Tb_AdminTargetsPercent")
            {
                TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsPC", true).First();
                if (ChangeText.Text != "")
                {
                    if (DM.Text != "")
                    {
                        delta = decimal.Parse(DM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Calc.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Calc.Text = "";
                }
            }
            if (ChangeText.Name == "Tb_AdminTargetsElePercent")
            {
                TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsEle", true).First();
                if (ChangeText.Text != "")
                {
                    if (DM.Text != "")
                    {
                        delta = decimal.Parse(DM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Calc.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Calc.Text = "";
                }
            }
            if (ChangeText.Name == "Tb_AdminTargetsMechPercent")
            {
                TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsMech", true).First();
                if (ChangeText.Text != "")
                {
                    if (DM.Text != "")
                    {
                        delta = decimal.Parse(DM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Calc.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Calc.Text = "";
                }
            }
            if (ChangeText.Name == "Tb_AdminTargetsNVRPercent")
            {
                TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsNVR", true).First();
                if (ChangeText.Text != "")
                {
                    if (DM.Text != "")
                    {
                        delta = decimal.Parse(DM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Calc.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Calc.Text = "";
                }
            }
        }

        public void pb_AdminSaveCalcRev_Click(object sender, EventArgs e)
        {
            CheckBox cb_AdminBU2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcBU", true).First();
            CheckBox cb_AdminEA12 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA1", true).First();
            CheckBox cb_AdminEA22 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA2", true).First();
            CheckBox cb_AdminEA32 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA3", true).First();
            if (cb_AdminBU2.Checked)
            {
                action.Action_CalcRev("BU");
            }
            if (cb_AdminEA12.Checked)
            {
                action.Action_CalcRev("EA1");
            }
            if (cb_AdminEA22.Checked)
            {
                action.Action_CalcRev("EA2");
            }
            if (cb_AdminEA32.Checked)
            {
                action.Action_CalcRev("EA3");
            }
        }

        public void pb_Admin_DeleteAccount_Click(object sender, EventArgs e)
        {
            admin.Admin_DeleteAccount();
        }

        public void combox_AdminAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            admin.Admin_LoadAccess();
        }

        public void pb_Admin_AddNewAccount_Click(object sender, EventArgs e)
        {
            admin.Admin_AddNewAccount();
        }

        public void pb_Admin_AccessSave_Click(object sender, EventArgs e)
        {
            admin.Admin_AccessSave();
        }

        public void pb_Admin_AccessRefresh_Click(object sender, EventArgs e)
        {
            admin.Admin_AccessRefresh();
        }

        public void pb_Admin_ValueSave_Click(object sender, EventArgs e)
        {
            admin.Admin_ValueSaveData();
        }

        public void pb_Admin_ValueRefresh_Click(object sender, EventArgs e)
        {
            admin.Admin_ValueRefreshData();
        }

        public void pb_Admin_FrozenRefresh_Click(object sender, EventArgs e)
        {
            admin.Admin_FrezenRefreshData();
        }

        public void pb_Admin_FrozenSave_Click(object sender, EventArgs e)
        {
            admin.Admin_FrozenSaveData();
        }

        public void cb_DataGridEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Text == "Qunatity")
            {
                DataGridView dg_Quantity = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();

                if (((CheckBox)sender).Checked)
                {
                    dg_Quantity.Enabled = false;
                    dg_Quantity.ReadOnly = true;
                }
                else
                {
                    dg_Quantity.Enabled = true;
                    dg_Quantity.ReadOnly = false;
                }
            }
            if (((CheckBox)sender).Text == "Saving")
            {
                DataGridView dg_Saving = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();

                if (((CheckBox)sender).Checked)
                {
                    dg_Saving.Enabled = false;
                    dg_Saving.ReadOnly = true;
                }
                else
                {
                    dg_Saving.Enabled = true;
                    dg_Saving.ReadOnly = false;
                }
            }
            if (((CheckBox)sender).Text == "ECCC")
            {
                DataGridView dg_ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();

                if (((CheckBox)sender).Checked)
                {
                    dg_ECCC.Enabled = false;
                    dg_ECCC.ReadOnly = true;
                }
                else
                {
                    dg_ECCC.Enabled = true;
                    dg_ECCC.ReadOnly = false;
                }
            }
        }

        public void pb_Admin_UpdateSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            STK UpdateSTK = new STK(mainProgram, ImportData);
            UpdateSTK.STK_LoadNewSTK();
            Cursor.Current = Cursors.Default;
        }

        public void pb_AdminSaveQuantityMonth_Click(object sender, EventArgs e)
        {
            NumericUpDown num_Year = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_YearMonth", true).First();
            NumericUpDown num_Month = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_QuantityMonth", true).First();
            CheckBox cb_ANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANCMonth", true).First();
            CheckBox cb_PNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNCMonth", true).First();

            if (cb_ANC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_ANC.Text + " dla " + num_Month.Value.ToString() + "/" + num_Year.Value.ToString(), "AddMonthANC", mainProgram, ImportData);
                AddData.Show();
            }
            if (cb_PNC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_PNC.Text + " dla " + num_Month.Value.ToString() + "/" + num_Year.Value.ToString(), "AddMonthPNC", mainProgram, ImportData);
                AddData.Show();
            }
        }

        public void cb_ChangeANC_PNCMonth_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNCMonth", true).First();
            CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANCMonth", true).First();

            cb_AdminANC.CheckedChanged -= cb_ChangeANC_PNCMonth_CheckedChanged;
            cb_AdminPNC.CheckedChanged -= cb_ChangeANC_PNCMonth_CheckedChanged;

            if ((sender as CheckBox).Text == "PNC")
            {
                cb_AdminANC.Checked = false;
            }
            if ((sender as CheckBox).Text == "ANC")
            {
                cb_AdminPNC.Checked = false;
            }

            cb_AdminANC.CheckedChanged += cb_ChangeANC_PNCMonth_CheckedChanged;
            cb_AdminPNC.CheckedChanged += cb_ChangeANC_PNCMonth_CheckedChanged;
        }

        public void cb_ChangeRewision_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminBU", true).First();
            CheckBox cb_AdminEA1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA1", true).First();
            CheckBox cb_AdminEA2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA2", true).First();
            CheckBox cb_AdminEA3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA3", true).First();
            CheckBox cb_AdminBU2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcBU", true).First();
            CheckBox cb_AdminEA12 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA1", true).First();
            CheckBox cb_AdminEA22 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA2", true).First();
            CheckBox cb_AdminEA32 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA3", true).First();

            cb_AdminBU.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminBU2.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA12.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA22.CheckedChanged -= cb_ChangeRewision_CheckedChanged;
            cb_AdminEA32.CheckedChanged -= cb_ChangeRewision_CheckedChanged;

            if ((sender as CheckBox).Text == "BU")
            {
                cb_AdminBU.Checked = true;
                cb_AdminEA1.Checked = false;
                cb_AdminEA2.Checked = false;
                cb_AdminEA3.Checked = false;
                cb_AdminBU2.Checked = true;
                cb_AdminEA12.Checked = false;
                cb_AdminEA22.Checked = false;
                cb_AdminEA32.Checked = false;
            }
            if ((sender as CheckBox).Text == "EA1")
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA1.Checked = true;
                cb_AdminEA2.Checked = false;
                cb_AdminEA3.Checked = false;
                cb_AdminBU2.Checked = false;
                cb_AdminEA12.Checked = true;
                cb_AdminEA22.Checked = false;
                cb_AdminEA32.Checked = false;
            }
            if ((sender as CheckBox).Text == "EA2")
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA1.Checked = false;
                cb_AdminEA2.Checked = true;
                cb_AdminEA3.Checked = false;
                cb_AdminBU2.Checked = false;
                cb_AdminEA12.Checked = false;
                cb_AdminEA22.Checked = true;
                cb_AdminEA32.Checked = false;
            }
            if ((sender as CheckBox).Text == "EA3")
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA1.Checked = false;
                cb_AdminEA2.Checked = false;
                cb_AdminEA3.Checked = true;
                cb_AdminBU2.Checked = false;
                cb_AdminEA12.Checked = false;
                cb_AdminEA22.Checked = false;
                cb_AdminEA32.Checked = true;
            }
            cb_AdminBU.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminBU2.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA12.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA22.CheckedChanged += cb_ChangeRewision_CheckedChanged;
            cb_AdminEA32.CheckedChanged += cb_ChangeRewision_CheckedChanged;
        }

        public void cb_ChangeANC_PNC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNC", true).First();
            CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANC", true).First();

            cb_AdminPNC.CheckedChanged -= cb_ChangeANC_PNC_CheckedChanged;
            cb_AdminANC.CheckedChanged -= cb_ChangeANC_PNC_CheckedChanged;

            if ((sender as CheckBox).Text == "PNC")
            {
                cb_AdminPNC.Checked = true;
                cb_AdminANC.Checked = false;
            }
            if ((sender as CheckBox).Text == "ANC")
            {
                cb_AdminPNC.Checked = false;
                cb_AdminANC.Checked = true;
            }
            cb_AdminPNC.CheckedChanged += cb_ChangeANC_PNC_CheckedChanged;
            cb_AdminANC.CheckedChanged += cb_ChangeANC_PNC_CheckedChanged;
        }

        public void radBut_AdminDev_Vie_CheckCange(object sender, EventArgs e)
        {
            RadioButton radbut_AdminDevelop = (RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminDevelop", true).First();
            RadioButton radbut_AdminViewer = (RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminViwer", true).First();

            radbut_AdminDevelop.CheckedChanged -= radBut_AdminDev_Vie_CheckCange;
            radbut_AdminViewer.CheckedChanged -= radBut_AdminDev_Vie_CheckCange;

            if ((sender as RadioButton).Text == "Developer")
            {
                radbut_AdminDevelop.Checked = true;
                radbut_AdminViewer.Checked = false;
            }
            if ((sender as RadioButton).Text == "Viwer")
            {
                radbut_AdminDevelop.Checked = false;
                radbut_AdminViewer.Checked = true;
            }

            radbut_AdminDevelop.CheckedChanged += radBut_AdminDev_Vie_CheckCange;
            radbut_AdminViewer.CheckedChanged += radBut_AdminDev_Vie_CheckCange;
        }

        public void tb_Value_TextChange(object sender, EventArgs e)
        {
            admin.Admin_Value_TextChange(sender as TextBox);
        }

        public void radBut_AdminFrozen_EnableDisable_CheckCange(object sender, EventArgs e)
        {

        }

        public void pb_AdminCalcMonth_Click(object sender, EventArgs e)
        {
            action.Action_CalcMonth();
        }

        public void pb_AdminSaveQuantity_Click(object sender, EventArgs e)
        {
            CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNC", true).First();
            CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANC", true).First();
            CheckBox cb_AdminBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminBU", true).First();
            CheckBox cb_AdminEA1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA1", true).First();
            CheckBox cb_AdminEA2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA2", true).First();
            CheckBox cb_AdminEA3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA3", true).First();
            string What = "";

            if (cb_AdminBU.Checked)
            {
                What = cb_AdminBU.Text;
            }
            if (cb_AdminEA1.Checked)
            {
                What = cb_AdminEA1.Text;
            }
            if (cb_AdminEA2.Checked)
            {
                What = cb_AdminEA2.Text;
            }
            if (cb_AdminEA3.Checked)
            {
                What = cb_AdminEA3.Text;
            }

            //admin.Admin_QuantityAddBudget((sender as CheckBox).Text);
            if (cb_AdminPNC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_AdminPNC.Text, What, mainProgram, ImportData);
                AddData.Show();
            }
            if (cb_AdminANC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_AdminANC.Text, What, mainProgram, ImportData);
                AddData.Show();
            }
        }

        public void Pb_ActivatorAction_Click(object sender, EventArgs e)
        {
            admin.Admin_ActivatorAction();
        }

        public void Pb_DeactivatorAction_Click(object sender, EventArgs e)
        {
            admin.Admin_DeactivatorAction();
        }

        public void pb_AdminSaveCalcRevNew_Click(object sender, EventArgs e)
        {
            CalculationMass Mass = new CalculationMass(mainProgram, ImportData, "BU");
        }

        public void pb_AdminSaveCalcMonthNew_Click(object sender, EventArgs e)
        {
            CalculationMass Mass = new CalculationMass(mainProgram, ImportData, 8);
        }
    }
}
