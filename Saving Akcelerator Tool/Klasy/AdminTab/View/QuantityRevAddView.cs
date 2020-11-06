using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class QuantityRevAddView : UserControl
    {
        public QuantityRevAddView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            num_Admin_YearQuantity.Value = DateTime.UtcNow.Year;
        }

        private void Pb_AdminSaveQuantity_Click(object sender, EventArgs e)
        {
            string What;
            if (cb_AdminANC.Checked || cb_AdminPNC.Checked)
            {
                if (cb_AdminBU.Checked || cb_AdminEA1.Checked || cb_AdminEA2.Checked || cb_AdminEA3.Checked)
                {
                    if(cb_AdminBU.Checked)
                    {
                        What = "BU";
                    }
                    else if(cb_AdminEA1.Checked)
                    {
                        What = "EA1";
                    }
                    else if(cb_AdminEA2.Checked)
                    {
                        What = "EA2";
                    }
                    else
                    {
                        What = "EA3";
                    }

                    if(cb_AdminPNC.Checked)
                    {
                        Form AddData = new AddData("Proszę podać liste PNC", num_Admin_YearQuantity.Value, What, false);
                        AddData.Show();
                    }
                    else
                    {
                        Form AddData = new AddData("Proszę podać liste ANC", num_Admin_YearQuantity.Value, What, true);
                        AddData.Show();
                    }      
                }
                else
                {
                    MessageBox.Show("Wybierz rewizje dla której chcesz dodać ilości");
                }
            }
            else
            {
                MessageBox.Show("Co za ilości chcesz dodać?");
            }
        }

        private void Cb_ChangeANC_PNC_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Text == "PNC")
            {
                cb_AdminANC.CheckedChanged -= Cb_ChangeANC_PNC_CheckedChanged;
                cb_AdminANC.Checked = false;
                cb_AdminANC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
            }
            else
            {
                cb_AdminPNC.CheckedChanged -= Cb_ChangeANC_PNC_CheckedChanged;
                cb_AdminPNC.Checked = false;
                cb_AdminPNC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
            }
        }

        private void Cb_ChangeRewision_CheckedChanged(object sender, EventArgs e)
        {
            cb_AdminBU.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged -= Cb_ChangeRewision_CheckedChanged;

            if((sender as CheckBox).Text == "BU")
            {
                cb_AdminEA1.Checked = false;
                cb_AdminEA2.Checked = false;
                cb_AdminEA3.Checked = false;
            }
            else if ((sender as CheckBox).Text == "EA1")
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA2.Checked = false;
                cb_AdminEA3.Checked = false; 
            }
            else if ((sender as CheckBox).Text == "EA2")
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA1.Checked = false;
                cb_AdminEA3.Checked = false;    
            }
            else
            {
                cb_AdminBU.Checked = false;
                cb_AdminEA1.Checked = false;
                cb_AdminEA2.Checked = false;
            }

            cb_AdminBU.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA1.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA2.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            cb_AdminEA3.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
        }

        private void Pb_AdminSaveCalcRevNew_Click(object sender, EventArgs e)
        {
            DialogResult Results = MessageBox.Show("Do you want Calculate All Action for Revision", "ATTENTION!", MessageBoxButtons.YesNo);
            if(Results == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;

                if(cb_AdminBU.Checked)
                {
                    _ = new CalculationMass("BU", num_Admin_YearQuantity.Value);
                }
                if (cb_AdminEA1.Checked)
                {
                    _ = new CalculationMass("EA1", num_Admin_YearQuantity.Value);
                }
                if (cb_AdminEA2.Checked)
                {
                    _ = new CalculationMass("EA2", num_Admin_YearQuantity.Value);
                }
                if (cb_AdminEA3.Checked)
                {
                    _ = new CalculationMass("EA3", num_Admin_YearQuantity.Value);
                }

                Cursor.Current = Cursors.Default;
            }
        }
    }
}
