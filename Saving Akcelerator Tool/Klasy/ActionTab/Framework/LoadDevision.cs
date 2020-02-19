using Saving_Accelerator_Tool.Klasy.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class LoadDevision
    {
        public LoadDevision(ComboBox Devision, bool AddAll)
        {
            if (Users.Singleton.Role == "Admin" || Users.Singleton.Role == "PCMenager" || AddAll)
            {
                Devision.Items.Add("Electronic");
                Devision.Items.Add("Mechanic");
                Devision.Items.Add("NVR");

            }
            else if (Users.Singleton.Role == "EleMenager")
            {
                Devision.Items.Add("Electronic");
            }
            else if (Users.Singleton.Role == "MechMenager")
            {
                Devision.Items.Add("Mechanic");
            }
            else if (Users.Singleton.Role == "NVRMenager")
            {
                Devision.Items.Add("NVR");
            }

            Devision.SelectedIndex = 0;
        }
    }
}
