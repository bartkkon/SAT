using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Handlers
{
    public class STKUpdateHandlers
    {

        public void Pb_Admin_UpdateSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            STK UpdateSTK = new STK(MainProgram.Self, Data_Import.Singleton());
            UpdateSTK.STK_LoadNewSTK();
            Cursor.Current = Cursors.Default;
        }

        public void Pb_Admin_YearClear_Click(object sender, EventArgs e)
        {
            decimal Year;

            Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("pb_Admin_STKYearToClear", true).First()).Value;

            DialogResult Results = MessageBox.Show("Zostanie Usunięty Rok: " + Year.ToString() + "  Jesteś tego pewny?", "Uwaga!!", MessageBoxButtons.OKCancel);
            if (Results == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                STK _STK = new STK(MainProgram.Self, Data_Import.Singleton());
                _STK.STK_ClearYear(Year);
                Cursor.Current = Cursors.Default;
            }
        }

        public void Pb_Admin_ManualUpdate_Click(object sender, EventArgs e)
        {
            decimal Year;

            Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("pb_Admin_STKYearToClear", true).First()).Value;

            DialogResult Results = MessageBox.Show("Czy chcesz dodać STK amnualnie na rok: " + Year.ToString() + "  Jesteś tego pewny?", "Uwaga!!", MessageBoxButtons.OKCancel);
            if (Results == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                STK _STK = new STK(MainProgram.Self, Data_Import.Singleton());
                _STK.STK_ManualUpdateFromFile(Year);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
