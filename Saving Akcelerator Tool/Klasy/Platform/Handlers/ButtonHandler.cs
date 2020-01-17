using Saving_Accelerator_Tool.Klasy.Platform.AddPNC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Handlers
{
    public class ButtonHandler
    {
        public void Pb_NewPNC_Click(object sender, EventArgs e)
        {
            Form AddPNC = new Platform_AddPNC("projekcik");
            AddPNC.ShowDialog();
        }

        public void Pb_DeletePNC_Click(object sender, EventArgs e)
        {

        }

        public void Pb_ChangePNC_Click(object sender, EventArgs e)
        {

        }
    }
}
