using Saving_Accelerator_Tool.Klasy.AdmnTab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Handlers
{
    class IDBHandler
    {
        public void PB_IDB_Update_DataBase_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new IDBLoadDataBase();
            Cursor.Current = Cursors.Default;
        }
    }
}
