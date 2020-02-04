using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Targets;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class TargetView : UserControl
    {
        public TargetView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            Num_AdminTargetsYear.Value = DateTime.UtcNow.Year;
            Comb_AdminTargetsRewizja.SelectedIndex = 1;
        }

        private void Pb_AdminTargets_Open_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadTargets(Num_AdminTargetsYear.Value);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_AdminTargets_Save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SaveTargets(Num_AdminTargetsYear.Value);
            Cursor.Current = Cursors.Default;
        }

        private void Comb_AdminTargetsComboBoxChange_SelectedItemChange(object sender, EventArgs e)
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;
            decimal Year = Num_AdminTargetsYear.Value;
            int SelectedIndex = Comb_AdminTargetsRewizja.SelectedIndex;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Targets, "Kurs");
            Tb_AdminTargetsDM.Text = "";
            Tb_AdminTargetsPercent.Text = "";
            Tb_AdminTargetsElePercent.Text = "";
            Tb_AdminTargetsMechPercent.Text = "";
            Tb_AdminTargetsNVRPercent.Text = "";

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();
            if (TargetsRow != null)
            {
                string[] DM = (TargetsRow["DM"].ToString()).Split('/');
                string[] PC = (TargetsRow["PC"].ToString()).Split('/');
                string[] Ele = (TargetsRow["Ele"].ToString()).Split('/');
                string[] Mech = (TargetsRow["Mech"].ToString()).Split('/');
                string[] NVR = (TargetsRow["NVR"].ToString()).Split('/');

                Tb_AdminTargetsDM.Text = DM[SelectedIndex];
                Tb_AdminTargetsPercent.Text = PC[SelectedIndex];
                Tb_AdminTargetsElePercent.Text = Ele[SelectedIndex];
                Tb_AdminTargetsMechPercent.Text = Mech[SelectedIndex];
                Tb_AdminTargetsNVRPercent.Text = NVR[SelectedIndex];
            }
        }

        private void Tb_AdminTargets_TextChange(object sender, EventArgs e)
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
                //TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                //Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsPC", true).First();

                if (ChangeText.Text != "")
                {
                    if (Tb_AdminTargetsDM.Text != "")
                    {
                        delta = decimal.Parse(Tb_AdminTargetsDM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Lab_AdminTargetsPC.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Lab_AdminTargetsPC.Text = "";
                }
            }
            else if (ChangeText.Name == "Tb_AdminTargetsElePercent")
            {
                //TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                //Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsEle", true).First();
                if (ChangeText.Text != "")
                {
                    if (Tb_AdminTargetsDM.Text != "")
                    {
                        delta = decimal.Parse(Tb_AdminTargetsDM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Lab_AdminTargetsEle.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Lab_AdminTargetsEle.Text = "";
                }
            }
            else if (ChangeText.Name == "Tb_AdminTargetsMechPercent")
            {
                //TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                //Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsMech", true).First();
                if (ChangeText.Text != "")
                {
                    if (Tb_AdminTargetsDM.Text != "")
                    {
                        delta = decimal.Parse(Tb_AdminTargetsDM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Lab_AdminTargetsMech.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Lab_AdminTargetsMech.Text = "";
                }
            }
            else if (ChangeText.Name == "Tb_AdminTargetsNVRPercent")
            {
                //TextBox DM = (TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First();
                //Label Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_AdminTargetsNVR", true).First();
                if (ChangeText.Text != "")
                {
                    if (Tb_AdminTargetsDM.Text != "")
                    {
                        delta = decimal.Parse(Tb_AdminTargetsDM.Text) * (decimal.Parse(ChangeText.Text) / 100);
                        Lab_AdminTargetsNVR.Text = (Math.Round(delta, 0, MidpointRounding.AwayFromZero)).ToString("# ### ##0") + " zł";
                    }
                }
                else
                {
                    Lab_AdminTargetsNVR.Text = "";
                }
            }
            ChangeText.TextChanged += Tb_AdminTargets_TextChange;
        }

    }
}
