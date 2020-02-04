using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Framework;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Handlers;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.View
{
    public partial class AutoUpdateSTKView : UserControl
    {
        public AutoUpdateSTKView() 
        {
            InitializeComponent();
            InitialuzeData();
        }

        private void InitialuzeData()
        {
            num_Admin_AutoUpdateSTK_Year.Value = DateTime.UtcNow.Year;
        }

        private void Pb_Admin_AutoUpdateSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new AutoUpdateSTK();
            Cursor.Current = Cursors.Default;
        }
    }
}
