using Saving_Accelerator_Tool.Klasy.StatisticTab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.Handlers
{
    class StatisticQuantityMonthHandler
    {
        public void ComboBox_SelectedIndexChange(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticQuantityMonthLoad();
            Cursor.Current = Cursors.Default;
        }
    }
}
