using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class PlatformView : UserControl
    {
        public PlatformView()
        {
            InitializeComponent();
        }

        public void SetPlatform(string[] Platform)
        {
            if(Platform[0] == "DMD")
            {
                Cb_DMD.Checked = true;
            }
            else
            {
                Cb_DMD.Checked = false;
            }
            if(Platform[1] == "D45")
            {
                Cb_D45.Checked = true;
            }
            else
            {
                Cb_D45.Checked = false;
            }
        }

        public string[] GetPlatform()
        {
            string[] platform = new string[2];

            if(Cb_DMD.Checked)
            {
                platform[0] = "DMD";
            }
            if(Cb_D45.Checked)
            {
                platform[1] = "D45";
            }
            return platform;
        }

        public void Clear()
        {
            Cb_D45.Checked = false;
            Cb_DMD.Checked = false;
        }
    }
}
