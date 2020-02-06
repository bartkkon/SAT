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

        private void Pb_Admin_UpdateSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            STK UpdateSTK = new STK();
            UpdateSTK.STK_LoadNewSTK();
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_YearClear_Click(object sender, EventArgs e)
        {
            DialogResult Results = MessageBox.Show("Zostanie Usunięty Rok: " + num_Admin_AutoUpdateSTK_Year.Value.ToString() + "  Jesteś tego pewny?", "Uwaga!!", MessageBoxButtons.YesNo);
            if (Results == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                STK _STK = new STK();
                _STK.STK_ClearYear(num_Admin_AutoUpdateSTK_Year.Value);
                Cursor.Current = Cursors.Default;
            }
        }

        private void Pb_Admin_ManualUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Results = MessageBox.Show("Czy chcesz dodać STK manualnie na rok: " + num_Admin_AutoUpdateSTK_Year.Value.ToString() + "  Jesteś tego pewny?", "Uwaga!!", MessageBoxButtons.YesNo);
            if (Results == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                STK _STK = new STK();
                _STK.STK_ManualUpdateFromFile(num_Admin_AutoUpdateSTK_Year.Value);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
