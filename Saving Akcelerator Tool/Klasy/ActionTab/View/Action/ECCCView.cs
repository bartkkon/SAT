using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class ECCCView : UserControl
    {
        public ECCCView()
        {
            InitializeComponent();
        }

        public void VisibleECCCSpec(bool Visible)
        {
            Cb_ECCCSpec.Checked = false;
            Cb_ECCCSpec.Visible = Visible;
        }

        public void SetECCC(decimal[] ECCCValue)
        {
            if (ECCCValue != null)
            {
                if (ECCCValue.Length == 1)
                {
                    Cb_ECCC.Checked = true;
                    Num_ECCC.Value = ECCCValue[0];
                }
                else
                {
                    Cb_ECCC.Checked = true;
                    Cb_ECCCSpec.Visible = true;
                    Cb_ECCCSpec.Checked = true;
                }
            }
        }

        public decimal[] GetECCC()
        {
            decimal[] ECCC = new decimal[1];
            if (Cb_ECCC.Checked)
            {
                if (!Cb_ECCCSpec.Checked)
                {
                    ECCC[0] = Num_ECCC.Value;
                    return ECCC;
                }
            }
            return ECCC;
        }

        public void Clear()
        {
            Cb_ECCCSpec.Checked = false;
            Cb_ECCC.Checked = false;
            Cb_ECCCSpec.Visible = false;
            Num_ECCC.Value = 0;
        }

        private void Cb_ECCC_CheckedChanged(object sender, EventArgs e)
        {
            Num_ECCC.Enabled = Cb_ECCC.Checked;
            Cb_ECCCSpec.Enabled = Cb_ECCC.Checked;
            Num_ECCC.Value = 0;
        }

        private void Cb_ECCCSpec_CheckedChanged(object sender, EventArgs e)
        {
            Num_ECCC.Enabled = !Cb_ECCCSpec.Checked;
        }
    }
}
