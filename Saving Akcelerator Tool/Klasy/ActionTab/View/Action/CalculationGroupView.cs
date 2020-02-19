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
    public partial class CalculationGroupView : UserControl
    {
        private readonly List<CheckBox> ANCby;

        public CalculationGroupView()
        {
            ANCby = new List<CheckBox>();

            InitializeComponent();

            AddComponentsToList();
        }

        public void SetVisible(int Row, bool ifVisibel)
        {
            ANCby[Row].Checked = false;
            ANCby[Row].Visible = ifVisibel;
        }

        public void SetVisibleCount(int Row)
        {
            for (int counter = 0; counter < Row; counter++)
            {
                ANCby[counter].Checked = false;
                ANCby[counter].Visible = true;
            }
        }

        public void SetData(bool[] Calc, string[] Mass)
        {
            bool GroupCalc = true;
            if (Calc != null)
            {
                for (int counter = 0; counter < Calc.Length; counter++)
                {
                    if (Calc[counter])
                    {
                        GroupCalc = false;
                        if (!cb_Mass_ANCUse.Checked)
                            cb_Mass_ANCUse.Checked = true;
                        ANCby[counter].Checked = true;
                    }
                }
            }
            if (GroupCalc)
            {
                if (!cb_Mass_GroupUse.Checked)
                    cb_Mass_GroupUse.Checked = true;

                if (Mass[0] == "All")
                    cb_Mass_All.Checked = true;
                else
                {
                    if (Mass[1] == "DMD")
                        cb_Mass_DMD.Checked = true;
                    if (Mass[2] == "D45")
                        cb_Mass_D45.Checked = true;
                    if (Mass[3] == "DMD_FS")
                        cb_Mass_DMD_FS.Checked = true;
                    if (Mass[4] == "DMD_FI")
                        cb_Mass_DMD_FI.Checked = true;
                    if (Mass[5] == "DMD_BI")
                        cb_Mass_DMD_BI.Checked = true;
                    if (Mass[6] == "DMD_FSBU")
                        cb_Mass_DMD_FSBU.Checked = true;
                    if (Mass[7] == "D45_FS")
                        cb_Mass_D45_FS.Checked = true;
                    if (Mass[8] == "D45_FI")
                        cb_Mass_D45_FI.Checked = true;
                    if (Mass[9] == "D45_BI")
                        cb_Mass_D45_BI.Checked = true;
                    if (Mass[10] == "D45_FSBU")
                        cb_Mass_D45_FSBU.Checked = true;
                }
            }
        }

        public bool[] GetANCby()
        {
            bool[] Status = new bool[10];

            for (int counter = 0; counter < 10; counter++)
            {
                if(ANCby[counter].Checked)
                {
                    Status[counter] = true;
                }
            }

            return Status;
        }

        public string[] GetMass()
        {
            string[] MassStatus = new string[11];

            if (cb_Mass_All.Checked)
                MassStatus[0] = "All";
            if (cb_Mass_DMD.Checked)
                MassStatus[1] = "DMD";
            if (cb_Mass_D45.Checked)
                MassStatus[2] = "D45";
            if (cb_Mass_DMD_FS.Checked)
                MassStatus[3] = "DMD_FS";
            if (cb_Mass_DMD_FI.Checked)
                MassStatus[4] = "DMD_FI";
            if (cb_Mass_DMD_BI.Checked)
                MassStatus[5] = "DMD_BI";
            if (cb_Mass_DMD_FSBU.Checked)
                MassStatus[6] = "DMD_FSBU";
            if (cb_Mass_D45_FS.Checked)
                MassStatus[7] = "D45_FS";
            if (cb_Mass_D45_FI.Checked)
                MassStatus[8] = "D45_FI";
            if (cb_Mass_D45_BI.Checked)
                MassStatus[9] = "D45_BI";
            if (cb_Mass_D45_FSBU.Checked)
                MassStatus[10] = "D45_FSBU";

            return MassStatus;
        }

        public void Clear()
        {
            foreach (CheckBox checkBox in ANCby)
            {
                checkBox.Checked = false;
                checkBox.Visible = false;
            }
            cb_Mass_ANCUse.Checked = true;
        }

        private void AddComponentsToList()
        {
            ANCby.Add(cb_ANCby1);
            ANCby.Add(cb_ANCby2);
            ANCby.Add(cb_ANCby3);
            ANCby.Add(cb_ANCby4);
            ANCby.Add(cb_ANCby5);
            ANCby.Add(cb_ANCby6);
            ANCby.Add(cb_ANCby7);
            ANCby.Add(cb_ANCby8);
            ANCby.Add(cb_ANCby9);
            ANCby.Add(cb_ANCby10);
        }

        private void ClearChecked()
        {
            foreach (CheckBox checkBox in ANCby)
            {
                checkBox.Checked = false;
            }
        }

        private void ClearMass()
        {
            cb_Mass_All.Checked = false;
            cb_Mass_DMD.Checked = false;
            cb_Mass_DMD_FS.Checked = false;
            cb_Mass_DMD_FI.Checked = false;
            cb_Mass_DMD_BI.Checked = false;
            cb_Mass_DMD_FSBU.Checked = false;
            cb_Mass_D45.Checked = false;
            cb_Mass_D45_FS.Checked = false;
            cb_Mass_D45_FI.Checked = false;
            cb_Mass_D45_BI.Checked = false;
            cb_Mass_D45_FSBU.Checked = false;
        }

        private void SetMass(bool Set)
        {
            cb_Mass_DMD.Checked = Set;
            cb_Mass_DMD_FS.Checked = Set;
            cb_Mass_DMD_FI.Checked = Set;
            cb_Mass_DMD_BI.Checked = Set;
            cb_Mass_DMD_FSBU.Checked = Set;
            cb_Mass_D45.Checked = Set;
            cb_Mass_D45_FS.Checked = Set;
            cb_Mass_D45_FI.Checked = Set;
            cb_Mass_D45_BI.Checked = Set;
            cb_Mass_D45_FSBU.Checked = Set;
        }

        private void Cb_Mass_ANCUse_CheckedChanged(object sender, EventArgs e)
        {
            cb_Mass_GroupUse.CheckedChanged -= Cb_Mass_GroupUse_CheckedChanged;
            cb_Mass_GroupUse.Checked = !(sender as CheckBox).Checked;
            gb_ANCby.Enabled = (sender as CheckBox).Checked;
            gb_ByGroup.Enabled = !(sender as CheckBox).Checked;
            ClearChecked();
            ClearMass();
            cb_Mass_GroupUse.CheckedChanged += Cb_Mass_GroupUse_CheckedChanged;
        }

        private void Cb_Mass_GroupUse_CheckedChanged(object sender, EventArgs e)
        {
            cb_Mass_ANCUse.CheckedChanged -= Cb_Mass_ANCUse_CheckedChanged;
            cb_Mass_ANCUse.Checked = !(sender as CheckBox).Checked;
            gb_ANCby.Enabled = !(sender as CheckBox).Checked;
            gb_ByGroup.Enabled = (sender as CheckBox).Checked;
            ClearChecked();
            ClearMass();
            cb_Mass_ANCUse.CheckedChanged += Cb_Mass_ANCUse_CheckedChanged;
        }

        private void Cb_Mass_All_CheckedChanged(object sender, EventArgs e)
        {
            SetMass((sender as CheckBox).Checked);
        }

        private void Cb_Mass_Group_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Mass_DMD.Checked &&
                cb_Mass_D45.Checked &&
                cb_Mass_DMD_FS.Checked &&
                cb_Mass_DMD_FI.Checked &&
                cb_Mass_DMD_BI.Checked &&
                cb_Mass_DMD_FSBU.Checked &&
                cb_Mass_D45_FS.Checked &&
                cb_Mass_D45_FI.Checked &&
                cb_Mass_D45_BI.Checked &&
                cb_Mass_D45_FSBU.Checked)
            {
                cb_Mass_All.CheckedChanged -= Cb_Mass_All_CheckedChanged;
                cb_Mass_All.Checked = true;
                cb_Mass_All.CheckedChanged += Cb_Mass_All_CheckedChanged;
            }
            else
            {
                cb_Mass_All.CheckedChanged -= Cb_Mass_All_CheckedChanged;
                cb_Mass_All.Checked = false; ;
                cb_Mass_All.CheckedChanged += Cb_Mass_All_CheckedChanged;
            }
        }
    }
}
