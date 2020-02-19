using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.ActionTab.View.Action;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View
{
    public partial class ActionView : UserControl
    {
        public ActionView()
        {
            InitializeComponent();
        }

        public void SetActionName(string LoadName)
        {
            gb_ActiveAction.Text = LoadName;
        }
    }
}
