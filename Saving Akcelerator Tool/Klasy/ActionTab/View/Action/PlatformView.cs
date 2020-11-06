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

        public bool GetDMD()
        {
            return Cb_DMD.Checked;
        }

        public bool GetD45()
        {
            return Cb_D45.Checked;
        }

        public void SetDMD(bool DMD)
        {
            Cb_DMD.Checked = DMD;
        }

        public void SetD45(bool D45)
        {
            Cb_D45.Checked = D45;
        }

        public void Clear()
        {
            Cb_D45.Checked = false;
            Cb_DMD.Checked = false;
        }
    }
}
