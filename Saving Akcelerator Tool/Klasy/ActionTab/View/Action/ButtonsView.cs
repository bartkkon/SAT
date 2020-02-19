using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class ButtonsView : UserControl
    {
        public ButtonsView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            if (Users.Singleton.Role == "Admin")
                pb_SpecialCalc.Visible = true;
        }

        public void SetSaveButtonVisible(bool ifVisible)
        {
            pb_SavePNC.Visible = ifVisible;
        }

        public void SetSpecialButtonEnable(bool ifEnabled)
        {
            pb_SpecialCalc.Enabled = ifEnabled;
        }

        private void pb_IDCO_Click(object sender, EventArgs e)
        {

            Form ActionFunction = new ActionFunction();
            ActionFunction.ShowDialog();
        }

        private void pb_SpecialCalc_Click(object sender, EventArgs e)
        {
            SpecialCalcAction SpecialCalc = new SpecialCalcAction();
            SpecialCalc.ShowDialog();
        }

        private void pb_SavePNC_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SavePNC();
            Cursor.Current = Cursors.Default;
        }
    }
}
