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
    public partial class QunatityPercentView : UserControl
    {
        public QunatityPercentView()
        {
            InitializeComponent();
        }

        public void SetValue(decimal Percent)
        {
            num_QuantityPercent.Value = Percent;
        }

        public decimal GetValue()
        {
            return num_QuantityPercent.Value;
        }

        public void Clear()
        {
            num_QuantityPercent.Value = 100;
        }
    }
}
