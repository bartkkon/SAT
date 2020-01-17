using Saving_Accelerator_Tool.Klasy.Platform.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Handlers
{
    public class OptionHandler
    {
        public void comb_Project_SelectedIndexChange(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadPNC();
            Cursor.Current = Cursors.Default;
        }

        public void num_Year_ValueChange (object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadProjects();
            Cursor.Current = Cursors.Default;
        }
    }
}
