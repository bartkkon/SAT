using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.StatisticTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    public partial class OptionView : UserControl
    {
        public OptionView()
        {
            InitializeComponent();
        }

        public void SetYear(decimal Year)
        {
            num_OptionYear.ValueChanged -= Num_OptionYear_ValueChanged;
            num_OptionYear.Value = Year;
            num_OptionYear.ValueChanged += Num_OptionYear_ValueChanged;
        }

        public decimal GetYear()
        {
            return num_OptionYear.Value;
        }
    
        private void Pb_LoadStatistic_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticLoadData();
            Cursor.Current = Cursors.Default;
        }

        private void Num_OptionYear_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticLoadData();
            Cursor.Current = Cursors.Default;
        }
    }
}
