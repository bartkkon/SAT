using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.User;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    public partial class SDReporting : UserControl
    {
        private System.Threading.Timer _timer;
        SDReporting _sDReporting;
        public delegate void SetEnable(bool Visible, string What);
        public SetEnable myDeleate;

        public delegate void SetGroupEnable(bool Visible, string What);
        public SetGroupEnable myDeleate2;
        public SDReporting()
        {
            InitializeComponent();
            _sDReporting = this;
            myDeleate = new SetEnable(SetEnableMethod);
            myDeleate2 = new SetGroupEnable(SetGroupEnableMethod);
        }

        public void InitializeData()
        {

            if (!Users.Singleton.ElectronicApprove)
            {
                pb_Approval_Electronic.Enabled = false;
                pb_Approval_Electronic.Visible = false;
            }
            if (!Users.Singleton.MechanicApprove)
            {
                pb_Approval_Mechanic.Enabled = false;
                pb_Approval_Mechanic.Visible = false;
            }
            if (!Users.Singleton.NVRApprove)
            {
                pb_Approval_NVR.Enabled = false;
                pb_Approval_NVR.Visible = false;
            }
            if (!Users.Singleton.PCApprove)
            {
                pb_Approval_PC.Enabled = false;
                pb_Approval_PC.Visible = false;
            }
            if (Users.Singleton.ElectronicApprove || Users.Singleton.MechanicApprove || Users.Singleton.NVRApprove || Users.Singleton.PCApprove)
            {
                pb_GenerateRaport.Enabled = true;
                pb_GenerateRaport.Visible = true;
            }

            UpdateReporting(null);
            _timer = new System.Threading.Timer(UpdateReporting, null, 12000, 12000);
        }


        public void SetEnableMethod(bool Set, string What)
        {
            if (What == "Electronic")
                pb_Approval_Electronic.Enabled = Set;
            else if (What == "Mechanic")
                pb_Approval_Mechanic.Enabled = Set;
            else if (What == "NVR")
                pb_Approval_NVR.Enabled = Set;
            else if (What == "PC")
                pb_Approval_PC.Enabled = Set;
        }

        public void SetGroupEnableMethod(bool Set, string What)
        {
            if (What == "Electronic")
            {
                pb_Approval_Electronic.Text = "Electronic Reject";
                pb_Approval_Electronic.Enabled = Set;
                pb_Approval_Electronic.Visible = Set;
            }
            else if (What == "Mechanic")
            {
                pb_Approval_Mechanic.Text = "Mechanic Reject";
                pb_Approval_Mechanic.Enabled = Set;
                pb_Approval_Mechanic.Visible = Set;
            }
            else if (What == "NVR")
            {
                pb_Approval_NVR.Text = "NVR Reject";
                pb_Approval_NVR.Enabled = Set;
                pb_Approval_NVR.Visible = Set;
            }
        }
        public void Pb_SummDet_Approve_Click(object sender, EventArgs e)
        {
            Button Przycisk = sender as Button;

            if (Przycisk.Text.Remove(0, 7) == "Approve")
            {
                DialogResult result = MessageBox.Show("Do you want " + (sender as Button).Text.ToString() + "?", "Report Approve", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //summaryDetails.SummaryDetails_ReportApprove((sender as Button).Text, Users.Singleton.PCApprove.ToString());
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if(Przycisk.Text.Remove(0, 7) == "Rejected")
            {
                DialogResult Result = MessageBox.Show("Do you want " + (sender as Button).Text + "?", "Report Rejected", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    //summaryDetails.SummaryDetails_ReportRejected((sender as Button).Text, Users.Singleton.PCApprove.ToString());
                }
                else if (Result == DialogResult.No)
                {
                    return;
                }
            }
        }

        public void UpdateReporting(object state)
        {
            lock (this)
            {
                DataTable Frozen = new DataTable();
                DataRow FrozenYear;
                decimal Year;
                bool CanBeApprove = false;

                Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
                Year = MainProgram.Self.sdOptions1.GetYear();

                FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

                //MessageBox.Show("zrobił");

                foreach (DataColumn Column in Frozen.Columns)
                {
                    if (Column.ColumnName != "Year" && Column.ColumnName != "EleApp" && Column.ColumnName != "MechApp" && Column.ColumnName != "NVRApp")
                    {
                        if (FrozenYear[Column].ToString() == "Open")
                        {
                            CanBeApprove = true;
                            break;
                        }
                    }
                }

                if (CanBeApprove && Users.Singleton.ElectronicApprove && FrozenYear["EleApp"].ToString() != "Approve")
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { true, "Electronic" });
                }
                else
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { false, "Electronic" });
                }

                if (CanBeApprove && Users.Singleton.MechanicApprove && FrozenYear["MechApp"].ToString() != "Approve")
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { true, "Mechanic" });
                }
                else
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { false, "Mechanic" });
                }

                if (CanBeApprove && Users.Singleton.NVRApprove && FrozenYear["NVRApp"].ToString() != "Approve")
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { true, "NVR" });
                }
                else
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { false, "NVR" });
                }

                if (CanBeApprove && Users.Singleton.PCApprove && FrozenYear["EleApp"].ToString() == "Approve" && FrozenYear["MechApp"].ToString() != "Approve" && FrozenYear["NVRApp"].ToString() != "Approve")
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { true, "PC" });
                }
                else
                {
                    _sDReporting.Invoke(_sDReporting.myDeleate, new object[] { false, "PC" });
                }

                if (Users.Singleton.PCApprove)
                {
                    if (FrozenYear["EleApp"].ToString() == "Approve")
                    {
                        _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { true, "Electronic" });
                    }
                    else
                    {
                        if (Users.Singleton.Role != "Admin")
                        {
                            _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { false, "Electronic" });
                        }
                    }
                    if (FrozenYear["MechApp"].ToString() == "Approve")
                    {
                        _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { true, "Mechanic" });
                    }
                    else
                    {
                        if (Users.Singleton.Role != "Admin")
                        {
                            _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { false, "Mechanic" });
                        }
                    }
                    if (FrozenYear["MechApp"].ToString() == "Approve")
                    {
                        _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { true, "NVR" });
                    }
                    else
                    {
                        if (Users.Singleton.Role != "Admin")
                        {
                            _sDReporting.Invoke(_sDReporting.myDeleate2, new object[] { false, "PC" });
                        }
                    }
                }
            }
        }
    }
}
