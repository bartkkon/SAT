using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Acton;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class QunatityPercentView : UserControl
    {
        public QunatityPercentView()
        {
            InitializeComponent();
        }

        public void SetValue(decimal Percent)
        {
            num_QuantityPercent.ValueChanged -= Num_QuantityPercent_ValueChanged;
            num_QuantityPercent.Value = Percent;
            num_QuantityPercent.ValueChanged += Num_QuantityPercent_ValueChanged;
        }

        public decimal GetValue()
        {
            return num_QuantityPercent.Value;
        }

        public void Clear()
        {
            num_QuantityPercent.ValueChanged -= Num_QuantityPercent_ValueChanged;
            num_QuantityPercent.Value = 100;
            num_QuantityPercent.ValueChanged += Num_QuantityPercent_ValueChanged;
        }

        private void Num_QuantityPercent_ValueChanged(object sender, EventArgs e)
        {
            ActionID.Singleton.ActionModification = true;
        }
    }
}
