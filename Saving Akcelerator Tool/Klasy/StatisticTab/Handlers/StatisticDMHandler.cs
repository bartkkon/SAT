using Saving_Accelerator_Tool.Klasy.StatisticTab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.Handlers
{
    public class StatisticDMHandler
    {
        public void Exchange_SelectedItemChange (object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticDMLoad();
            Cursor.Current = Cursors.Default;
        }
    }
}
