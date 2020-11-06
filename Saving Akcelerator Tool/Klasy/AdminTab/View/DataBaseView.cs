using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Framework;
using Saving_Accelerator_Tool.Controllers.AdminTab;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class DataBaseView : UserControl
    {
        public DataBaseView()
        {
            InitializeComponent();
        }

        private void Pb_CloneBase_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new CloneDataBase();
            Cursor.Current = Cursors.Default;
        }

        private void PB_IDB_Update_DataBase_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new IDBLoadDataBase();
            Cursor.Current = Cursors.Default;
        }

        private void But_Upload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //MessageBox.Show("Noting to do!");
            ConvertTXTtoDB.Upload();
            Cursor.Current = Cursors.Default;
        }
    }
}
