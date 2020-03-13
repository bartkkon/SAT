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
        }

        public string GetRevision()
        {
            return Comb_AdminTargetsRewizja.SelectedItem.ToString();
        }

        public void Clear()
        {
            Comb_AdminTargetsRewizja.SelectedIndex = -1;
            Tb_AdminTargetsDM.Text = string.Empty;
            Tb_AdminTargetsElePercent.Text = string.Empty;
            Tb_AdminTargetsMechPercent.Text = string.Empty;
            Tb_AdminTargetsNVRPercent.Text = string.Empty;
            Tb_AdminTargetsPercent.Text = string.Empty;
        }

        public void SetRevision(string Revision)
        {
            if (Comb_AdminTargetsRewizja.Items.Contains(Revision))
            {
                int index = Comb_AdminTargetsRewizja.Items.IndexOf(Revision);
                Comb_AdminTargetsRewizja.SelectedIndexChanged -= Comb_AdminTargetsComboBoxChange_SelectedItemChange;
                Comb_AdminTargetsRewizja.SelectedIndex = index;
                Comb_AdminTargetsRewizja.SelectedIndexChanged += Comb_AdminTargetsComboBoxChange_SelectedItemChange;
            }
            else
            {
                Comb_AdminTargetsRewizja.SelectedIndex = -1;
            }
        }

        public void SetDM(double DMValue)
        {
            Tb_AdminTargetsDM.Text = DMValue.ToString();
        }

        public void SetPC(double PCValue)
        {
            Tb_AdminTargetsPercent.Text = PCValue.ToString();
        }

        public void SetElectronic(double EleValue)
        {
            Tb_AdminTargetsElePercent.Text = EleValue.ToString();
        }

        public void SetMechanic(double MechValue)
        {
            Tb_AdminTargetsMechPercent.Text = MechValue.ToString();
        }

        public void SetNVR(double NVRValue)
        {
            Tb_AdminTargetsNVRPercent.Text = NVRValue.ToString();
        }

        public void InitializeData()
        {
            Num_AdminTargetsYear.Value = DateTime.UtcNow.Year;
            Comb_AdminTargetsRewizja.SelectedIndex = -1;
        }

        private void Pb_AdminTargets_Open_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadTargets(Convert.ToInt32(Num_AdminTargetsYear.Value));
            Cursor.Current = Cursors.Default;
        }

        private void Pb_AdminTargets_Save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int Year = Convert.ToInt32(Num_AdminTargetsYear.Value);
            string Revision = Comb_AdminTargetsRewizja.SelectedItem.ToString();
            double DM = 0;
            double PC = 0;
            double Ele = 0;
            double Mech = 0;
            double NVR = 0;

            if (Tb_AdminTargetsDM.Text != string.Empty)
                DM = Convert.ToDouble(Tb_AdminTargetsDM.Text);
            if (Tb_AdminTargetsPercent.Text != string.Empty)
                PC = Convert.ToDouble(Tb_AdminTargetsPercent.Text);
            if (Tb_AdminTargetsElePercent.Text != string.Empty)
                Ele = Convert.ToDouble(Tb_AdminTargetsElePercent.Text);
            if (Tb_AdminTargetsMechPercent.Text != string.Empty)
                Mech = Convert.ToDouble(Tb_AdminTargetsMechPercent.Text);
            if (Tb_AdminTargetsNVRPercent.Text != string.Empty)
                NVR = Convert.ToDouble(Tb_AdminTargetsNVRPercent.Text);

            _ = new SaveTargets(Year, Revision, DM, PC, Ele, Mech, NVR);

            Cursor.Current = Cursors.Default;
        }

        private void Comb_AdminTargetsComboBoxChange_SelectedItemChange(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                _ = new LoadTargets(Convert.ToInt32(Num_AdminTargetsYear.Value), (sender as ComboBox).SelectedItem.ToString());
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
