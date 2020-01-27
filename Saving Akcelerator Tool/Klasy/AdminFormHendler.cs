using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Saving_Accelerator_Tool.SumPNC;
using Saving_Accelerator_Tool.Klasy.Email;

namespace Saving_Accelerator_Tool
{
    class AdminFormHendler
    {
        private readonly MainProgram mainProgram;
        private readonly Action action;
        private readonly Admin admin;
        private readonly Data_Import ImportData;


        public AdminFormHendler(MainProgram mainProgram, Action action, Admin admin, Data_Import ImportData)
        {
            this.mainProgram = mainProgram;
            this.action = action;
            this.admin = admin;
            this.ImportData = ImportData;
        }

        public void Pb_Admin_AddColumn_Click(object sender, EventArgs e)
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

        public void SentEmailTest_Clikc(object sender, EventArgs e)
        {
            SentEmail.Instance.Sent_Email("konrad.bartkowiak@electrolux.com", "Test", "Testujemy!!!!!!!!!!!!!!!!!");
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
            ChangeText.TextChanged -= Tb_AdminTargets_TextChange;

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

            if (ChangeText.Name == "Tb_AdminTargetsDM")
            {
                if (ChangeText.Text != "")
                {
                    ChangeText.Text = string.Format("{0:# ### ##0}", double.Parse(ChangeText.Text));
                    ChangeText.Focus();
                    ChangeText.SelectionStart = ChangeText.Text.Length;
                }
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
            ChangeText.TextChanged += Tb_AdminTargets_TextChange;
        }

        public void Pb_AdminSaveCalcRev_Click(object sender, EventArgs e)
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

        public void Pb_Admin_ValueSave_Click(object sender, EventArgs e)
        {
            admin.Admin_ValueSaveData();
        }

        public void Pb_Admin_ValueRefresh_Click(object sender, EventArgs e)
        {
            admin.Admin_ValueRefreshData();
        }

        public void Pb_Admin_FrozenRefresh_Click(object sender, EventArgs e)
        {
            admin.Admin_FrezenRefreshData();
        }

        public void Pb_Admin_FrozenSave_Click(object sender, EventArgs e)
        {
            admin.Admin_FrozenSaveData();
        }

        public void Cb_DataGridEnable_CheckedChanged(object sender, EventArgs e)
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
        
        public void Pb_AdminSaveQuantityMonth_Click(object sender, EventArgs e)
        {
            NumericUpDown num_Year = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_YearMonth", true).First();
            NumericUpDown num_Month = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_QuantityMonth", true).First();
            CheckBox cb_ANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANCMonth", true).First();
            CheckBox cb_PNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNCMonth", true).First();

            if (cb_ANC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_ANC.Text + " dla " + num_Month.Value.ToString() + "/" + num_Year.Value.ToString(), "AddMonthANC");
                AddData.Show();
            }
            if (cb_PNC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_PNC.Text + " dla " + num_Month.Value.ToString() + "/" + num_Year.Value.ToString(), "AddMonthPNC");
                AddData.Show();
            }
        }

        public void Cb_ChangeANC_PNCMonth_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNCMonth", true).First();
            CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANCMonth", true).First();

            cb_AdminANC.CheckedChanged -= Cb_ChangeANC_PNCMonth_CheckedChanged;
            cb_AdminPNC.CheckedChanged -= Cb_ChangeANC_PNCMonth_CheckedChanged;

            if ((sender as CheckBox).Text == "PNC")
            {
                cb_AdminANC.Checked = false;
            }
            if ((sender as CheckBox).Text == "ANC")
            {
                cb_AdminPNC.Checked = false;
            }

            cb_AdminANC.CheckedChanged += Cb_ChangeANC_PNCMonth_CheckedChanged;
            cb_AdminPNC.CheckedChanged += Cb_ChangeANC_PNCMonth_CheckedChanged;
        }

        public void Cb_ChangeRewision_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminBU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminBU", true).First();
            CheckBox cb_AdminEA1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA1", true).First();
            CheckBox cb_AdminEA2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA2", true).First();
            CheckBox cb_AdminEA3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminEA3", true).First();
            CheckBox cb_AdminBU2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcBU", true).First();
            CheckBox cb_AdminEA12 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA1", true).First();
            CheckBox cb_AdminEA22 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA2", true).First();
            CheckBox cb_AdminEA32 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA3", true).First();

            cb_AdminBU.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminBU2.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA12.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA22.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA32.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;

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
            cb_AdminBU.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminBU2.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA12.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA22.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA32.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
        }

        public void Cb_ChangeANC_PNC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNC", true).First();
            CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANC", true).First();

            cb_AdminPNC.CheckedChanged -= Cb_ChangeANC_PNC_CheckedChanged;
            cb_AdminANC.CheckedChanged -= Cb_ChangeANC_PNC_CheckedChanged;

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
            cb_AdminPNC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
            cb_AdminANC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
        }

        public void RadBut_AdminDev_Vie_CheckCange(object sender, EventArgs e)
        {
            RadioButton radbut_AdminDevelop = (RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminDevelop", true).First();
            RadioButton radbut_AdminViewer = (RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminViwer", true).First();

            radbut_AdminDevelop.CheckedChanged -= RadBut_AdminDev_Vie_CheckCange;
            radbut_AdminViewer.CheckedChanged -= RadBut_AdminDev_Vie_CheckCange;

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

            radbut_AdminDevelop.CheckedChanged += RadBut_AdminDev_Vie_CheckCange;
            radbut_AdminViewer.CheckedChanged += RadBut_AdminDev_Vie_CheckCange;
        }

        public void Tb_Value_TextChange(object sender, EventArgs e)
        {
            admin.Admin_Value_TextChange(sender as TextBox);
        }

        public void RadBut_AdminFrozen_EnableDisable_CheckCange(object sender, EventArgs e)
        {

        }

        public void Pb_AdminCalcMonth_Click(object sender, EventArgs e)
        {
            action.Action_CalcMonth();
        }

        public void Pb_AdminSaveQuantity_Click(object sender, EventArgs e)
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
                Form AddData = new AddData("Proszę podać liste " + cb_AdminPNC.Text, What);
                AddData.Show();
            }
            if (cb_AdminANC.Checked)
            {
                Form AddData = new AddData("Proszę podać liste " + cb_AdminANC.Text, What);
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

        public void Pb_AdminSaveCalcRevNew_Click(object sender, EventArgs e)
        {
            string Rewizion = "";
            Cursor.Current = Cursors.WaitCursor;
            CheckBox BU = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcBU", true).First();
            CheckBox EA1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA1", true).First();
            CheckBox EA2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA2", true).First();
            CheckBox EA3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminCalcEA3", true).First();

            if (BU.Checked)
                Rewizion = "BU";
            else if (EA1.Checked)
                Rewizion = "EA1";
            else if (EA2.Checked)
                Rewizion = "EA2";
            else if (EA3.Checked)
                Rewizion = "EA3";

            if (Rewizion != "")
            {
                _ = new CalculationMass(mainProgram, ImportData, Rewizion);
            }

            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminSaveCalcMonthNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            NumericUpDown Month = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_MonthCalc", true).First();

            _ = new CalculationMass(mainProgram, ImportData, int.Parse(Month.Value.ToString()));
            Cursor.Current = Cursors.Default;
        }

        public void Comb_AdminTargetsComboBoxChange_SelectedItemChange(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            admin.Admin_TargetChangeRewizion();
            Cursor.Current = Cursors.Default;
        }

        public void Pb_Admin_SumPNC_Month_Click(object sender, EventArgs e)
        {
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_SumPNC_Year", true).First()).Value;
            decimal Month = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_SumPNC_Month", true).First()).Value;

            Cursor.Current = Cursors.WaitCursor;
            GroupingPNC PNC = new GroupingPNC(ImportData, Year, Month);
            PNC.GrupingPNC_Month();
            Cursor.Current = Cursors.Default;
        }

        public void Pb_Admin_SumPNC_Revision_Click(object sender, EventArgs e)
        {
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_SumPNC_Year", true).First()).Value;
            string Rev = ((ComboBox)mainProgram.TabControl.Controls.Find("comb_Admin_SumPNC_Rev", true).First()).SelectedItem.ToString();

            Cursor.Current = Cursors.WaitCursor;
            GroupingPNC PNC = new GroupingPNC(ImportData, Year, Rev);
            PNC.GrupingPNC_Revision();
            Cursor.Current = Cursors.Default;
        }

        public void Pb_CloneBase_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            admin.Admin_CloneDataBase();
            Cursor.Current = Cursors.Default;
        }
    }
}
