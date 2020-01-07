using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Handlers
{
    public class SDTableHandler
    {
        public void SDOptionForTable_CheckChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SDTableLoad();
            Cursor.Current = Cursors.Default;
        }
    }
}
