using Saving_Accelerator_Tool.Klasy.Platform.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Handlers
{
    public class PNCTreeHandler
    {
        public void Tree_PNC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string Project = ((ComboBox)MainProgram.Self.Controls.Find("combo_Project", true).First()).SelectedIndex.ToString();

            if(e.Node.Text != Project)
            {
                _ = new LoadSpecificPNC(e.Node.Text);
            }
        }
    }
}
