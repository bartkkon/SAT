using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Action.Framework;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class ActionActivatorView : UserControl
    {
        public ActionActivatorView()
        {
            InitializeComponent();
        }

        private void Pb_DeactivatorAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new Deactivation_Action(-1);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_ActivatorAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new Activation_Action(-1);
            Cursor.Current = Cursors.Default;
        }
    }
}
