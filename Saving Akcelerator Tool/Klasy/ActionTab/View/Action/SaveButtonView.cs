using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class SaveButtonView : UserControl
    {
        public SaveButtonView()
        {
            InitializeComponent();
        }

        private void Pb_Save_Click(object sender, EventArgs e)
        {
            _ = new SaveActionFromForm();
        }

        private void Pb_SaveDraft_Click(object sender, EventArgs e)
        {

        }
    }
}
