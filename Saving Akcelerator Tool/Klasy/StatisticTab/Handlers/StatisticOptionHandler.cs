using Saving_Accelerator_Tool.Klasy.StatisticTab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.Handlers
{
     public class StatisticOptionHandler
    {

       public void LoadButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            StatisticLoadData LoadData = new StatisticLoadData();
            LoadData.LoadData();

            Cursor.Current = Cursors.Default;
        }
    }
}
