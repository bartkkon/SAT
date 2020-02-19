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
    public partial class InstallationView : UserControl
    {
        public InstallationView()
        {
            InitializeComponent();
        }

        public void SetInstallation(string[] Installation)
        {
            if (Installation[0] == "FS")                
                Cb_FS.Checked = true;
            if (Installation[1] == "FI")
                Cb_FI.Checked = true;
            if (Installation[2] == "BI")
                Cb_BI.Checked = true;
            if (Installation[3] == "BU")
                Cb_BU.Checked = true;
            if (Installation[4] == "FSBU")
                Cb_FSBU.Checked = true;
        }

        public string[] GetInstallation()
        {
            string[] Installation = new string[5];

            if (Cb_FS.Checked)
                Installation[0] = "FS";
            if (Cb_FI.Checked)
                Installation[1] = "FI";
            if (Cb_BI.Checked)
                Installation[2] = "BI";
            if (Cb_BU.Checked)
                Installation[3] = "BU";
            if (Cb_FSBU.Checked)
                Installation[4] = "FSBU";

            return Installation;
        }

        public void Clear()
        {
            Cb_FS.Checked = false;
            Cb_FI.Checked = false;
            Cb_BI.Checked = false;
            Cb_BU.Checked = false;
            Cb_FSBU.Checked = false;
        }

        private void Cb_Installation_CheckedChanged(object sender, EventArgs e)
        {
            Cb_InstallAll.CheckedChanged -= Cb_Installation_CheckedChanged;
            Cb_FI.CheckedChanged -= Cb_Installation_CheckedChanged;
            Cb_FS.CheckedChanged -= Cb_Installation_CheckedChanged;
            Cb_BI.CheckedChanged -= Cb_Installation_CheckedChanged;
            Cb_BU.CheckedChanged -= Cb_Installation_CheckedChanged;
            Cb_FSBU.CheckedChanged -= Cb_Installation_CheckedChanged;

            if ((sender as CheckBox).Text == "All")
            {
                Cb_FI.Checked = Cb_InstallAll.Checked;
                Cb_FS.Checked = Cb_InstallAll.Checked;
                Cb_BI.Checked = Cb_InstallAll.Checked;
                Cb_BU.Checked = Cb_InstallAll.Checked;
                Cb_FSBU.Checked = Cb_InstallAll.Checked;
            }
            else
            {
                if (!(sender as CheckBox).Checked)
                {
                    Cb_InstallAll.Checked = false;
                }
                if (Cb_FI.Checked && Cb_FS.Checked && Cb_BI.Checked && Cb_BU.Checked && Cb_FSBU.Checked)
                {
                    Cb_InstallAll.Checked = true;
                }
            }

            Cb_InstallAll.CheckedChanged += Cb_Installation_CheckedChanged;
            Cb_FI.CheckedChanged += Cb_Installation_CheckedChanged;
            Cb_FS.CheckedChanged += Cb_Installation_CheckedChanged;
            Cb_BI.CheckedChanged += Cb_Installation_CheckedChanged;
            Cb_BU.CheckedChanged += Cb_Installation_CheckedChanged;
            Cb_FSBU.CheckedChanged += Cb_Installation_CheckedChanged;
        }
    }
}
