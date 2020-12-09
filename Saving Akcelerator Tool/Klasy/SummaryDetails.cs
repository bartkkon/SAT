using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Saving_Accelerator_Tool.Klasy.Email;

namespace Saving_Accelerator_Tool
{
    public class SummaryDetails
    {

        public void SummaryDetails_ReportApprove(string Devision, string PC)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Devision == "Product Care Approve")
            {
                History history = new History();
                history.HistorySave();
            }
            ReportApprove(Devision);
            CheckifCanReporting(Devision, PC);
            AddToFinalReport(Devision);
            Cursor.Current = Cursors.Default;
        }

        public void SummaryDetails_ReportRejected(string Devision, string PC)
        {
            Cursor.Current = Cursors.WaitCursor;
            ReportRejected(Devision);
            CheckifCanReporting(Devision, PC);
            Cursor.Current = Cursors.Default;
        }

        public void SummaryDetails_Show()
        {
            ShowCurrentAction();
        }

        public void SummaryDetails_DataGridDifference()
        {
            DataGridDifference((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First());
            DataGridDifference((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First());
            DataGridDifference((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First());
        }

        public void SummaryDetails_CheckifCanReporting(string Devision, string PC)
        {
            CheckifCanReporting(Devision, PC);
        }

        public void SummaryDetails_DataGridDifferenceClear()
        {
            DataGridDifferenceClear();
        }

        public void SummaryDetails_PlanCheck()
        {
            PlanCheck();
        }

        public void SummaryDetails_SumPlanCheck()
        {
            SumPlanCheck();
        }

        // Przeliczanie akcji dla raportu finalnego
        private void AddToFinalReport(string Devision)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenYear;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            if (Devision != "Product Care Approve")
            {
                Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

                FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

                PCRaport_Approval PC_Approval = new PCRaport_Approval();

                if (FrozenYear["BU"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, Year, Data_Import.Singleton());
                }
                else if (FrozenYear["EA1"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, Year, Data_Import.Singleton());
                }
                else if (FrozenYear["EA2"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, Year, Data_Import.Singleton());
                }
                else if (FrozenYear["EA3"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, Year, Data_Import.Singleton());
                }
            }
        }

        private void DataGridDifferenceClear()
        {
            DataGridView DG_ToClearCurrent = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();
            DataGridView DG_ToClearCarry = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            DataGridView DG_ToCearECCC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();
            for (int counter = 0; counter < 12; counter++)
            {
                DG_ToClearCurrent.Rows[5].Cells[counter].Value = null;
                DG_ToClearCarry.Rows[5].Cells[counter].Value = null;
                DG_ToCearECCC.Rows[5].Cells[counter].Value = null;
                DG_ToClearCurrent.Rows[5].Cells[counter].Style.ForeColor = Color.Black;
                DG_ToClearCarry.Rows[5].Cells[counter].Style.ForeColor = Color.Black;
                DG_ToCearECCC.Rows[5].Cells[counter].Style.ForeColor = Color.Black;
            }
        }

        private void CheckifCanReporting(string Devision, string PC)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            Control[] App;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;
            bool ToApprove = false;
            int ToApproveFull = 0;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            if (Devision.Substring(0, 2) == "PC")
            {
                Devision = "PC";
            }
            else if (Devision.Substring(0, 3) == "NVR")
            {
                Devision = "NVR";
            }
            else if (Devision.Substring(0, 8) == "Mechanic")
            {
                Devision = "Mechanic";
            }
            else if (Devision.Substring(0, 10) == "Electronic")
            {
                Devision = "Electronic";
            }
            else if (Devision.Substring(0, 12) == "Product Care")
            {
                Devision = "PC";
            }

            if (FrozenRow["BU"].ToString() == "Open")
            {
                ToApprove = true;
            }
            if (FrozenRow["EA1"].ToString() == "Open")
            {
                ToApprove = true;

            }
            if (FrozenRow["EA2"].ToString() == "Open")
            {
                ToApprove = true;
            }
            if (FrozenRow["EA3"].ToString() == "Open")
            {
                ToApprove = true;
            }
            for (int counter = 1; counter <= 12; counter++)
            {
                if (FrozenRow[counter.ToString()].ToString() == "Open")
                {
                    ToApprove = true;
                }
            }

            if (Devision == "Electronic" && ToApprove == true)
            {
                if (FrozenRow["EleApp"].ToString() == "Close")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleApprove", true).First()).Enabled = true;

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["EleApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleApprove", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
            }
            if (Devision == "Mechanic" && ToApprove == true)
            {
                if (FrozenRow["MechApp"].ToString() == "Close")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechApprove", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["MechApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechApprove", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
            }
            if (Devision == "NVR" && ToApprove == true)
            {
                if (FrozenRow["NVRApp"].ToString() == "Close")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRApprove", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["NVRApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRApprove", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }

                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
            }
            if (PC == "true")
            {
                App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
                for (int counter = 0; counter < App.Length; counter++)
                {
                    App[counter].Enabled = false;
                }
            }

            if (Devision == "PC" && ToApprove == true)
            {
                if (FrozenRow["EleApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (FrozenRow["MechApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (FrozenRow["NVRApp"].ToString() == "Approve")
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (ToApproveFull == 3)
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_PCApprove", true).First()).Enabled = true;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
                else
                {
                    //((Button)MainProgram.Self.TabControl.Controls.Find("pb_SummDet_PCApprove", true).First()).Enabled = false;
                    App = MainProgram.Self.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
            }
        }

        private void ReportRejected(string Devision)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;
            string MailTo;
            string ToReject;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            ToReject = WhatIsToApprove(FrozenRow);

            if (FrozenRow != null)
            {
                if (Devision == "Electronic Rejected")
                {
                    FrozenRow["EleApp"] = "Close";

                    MailTo = new SentTo(true, false, false, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
                if (Devision == "Mechanic Rejected")
                {
                    FrozenRow["MechApp"] = "Close";

                    MailTo = new SentTo(false, true, false, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
                if (Devision == "NVR Rejected")
                {
                    FrozenRow["NVRApp"] = "Close";

                    MailTo = new SentTo(false, false, true, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");
        }

        private void ReportApprove(string Devision)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;
            string MailTo;
            string ToApprove;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            ToApprove = WhatIsToApprove(FrozenRow);

            if (FrozenRow != null && ToApprove != string.Empty)
            {
                if (Devision == "Electronic Approve")
                {
                    FrozenRow["EleApp"] = "Approve";

                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("Electronic"), new MailInfo().RaportApprove_Devision_Body("Electronic", ToApprove));
                    CheckIfAllDevisionApprove(FrozenRow, ToApprove);
                }
                if (Devision == "Mechanic Approve")
                {
                    FrozenRow["MechApp"] = "Approve";

                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("Mechanic"), new MailInfo().RaportApprove_Devision_Body("Mechanic", ToApprove));
                    CheckIfAllDevisionApprove(FrozenRow, ToApprove);
                }
                if (Devision == "NVR Approve")
                {
                    FrozenRow["NVRApp"] = "Approve";

                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("NVR"), new MailInfo().RaportApprove_Devision_Body("NVR", ToApprove));
                    CheckIfAllDevisionApprove(FrozenRow, ToApprove);
                }
                if (Devision == "Product Care Approve")
                {
                    FrozenRow["EleApp"] = "Close";
                    FrozenRow["MechApp"] = "Close";
                    FrozenRow["NVRApp"] = "Close";
                    FrozenRow[ToApprove] = "Approve";

                    MailTo = new SentTo(true, true, true, true).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_PC_Topic(ToApprove), new MailInfo().RaportApprove_PC_Body(ToApprove));
                }
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");
        }

        private string WhatIsToApprove(DataRow frozenRow)
        {

            if (frozenRow["BU"].ToString() == "Open")
            {
                return "BU";
            }
            if (frozenRow["EA1"].ToString() == "Open")
            {
                return "EA1";
            }
            if (frozenRow["EA2"].ToString() == "Open")
            {
                return "EA2";
            }
            if (frozenRow["EA3"].ToString() == "Open")
            {
                return "EA3";
            }
            for (int counter = 1; counter <= 12; counter++)
            {
                if (frozenRow[counter.ToString()].ToString() == "Open")
                {
                    return counter.ToString();
                }
            }

            return string.Empty;
        }

        private void CheckIfAllDevisionApprove(DataRow frozenRow, string ToApprove)
        {
            if (frozenRow["EleApp"].ToString() == "Approve" && frozenRow["MechApp"].ToString() == "Approve" && frozenRow["NVRApp"].ToString() == "Approve")
            {
                string MailTo = new SentTo(false, false, false, true).SentToList();
                SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_AllDevision_Topic(), new MailInfo().RaportApprove_AllDevison_Body(ToApprove));
            }
        }

        private void ShowCurrentAction()
        {
            DataTable Action = new DataTable();
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            ComboBox Leader = (ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_SummDetLeader", true).First();
            ComboBox Devision = (ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_SummDetDevision", true).First();
            CheckBox Active = (CheckBox)MainProgram.Self.TabControl.Controls.Find("CB_Active1", true).First();
            CheckBox Idea = (CheckBox)MainProgram.Self.TabControl.Controls.Find("CB_Idea1", true).First();
            CheckBox Positive = (CheckBox)MainProgram.Self.TabControl.Controls.Find("CB_Positive1", true).First();
            CheckBox Negative = (CheckBox)MainProgram.Self.TabControl.Controls.Find("CB_Negative1", true).First();


            Data_Import.Singleton().Load_TxtToDataTable2(ref Action, "Action");

            AddZerotoDataGridView();

            foreach (DataRow ActionRow in Action.Rows)
            {
                if (ActionRow["StartYear"].ToString() == Year.ToString() || ActionRow["StartYear"].ToString() == "BU/" + Year.ToString() || ActionRow["StartYear"].ToString() == "SA/" + Year.ToString())
                {
                    if (ActionRow["Status"].ToString() == "Active" && Active.Checked)
                    {
                        if (Devision.Text == "All")
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                        }
                    }
                    if (ActionRow["Status"].ToString() == "Idea" && Idea.Checked)
                    {
                        if (Devision.Text == "All")
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "");
                            }
                        }
                    }
                }

                if (ActionRow["StartYear"].ToString() == (Year - 1).ToString())
                {
                    if (ActionRow["Status"].ToString() == "Active" && ActionRow["StartMonth"].ToString() != "January" && Active.Checked)
                    {
                        if (Devision.Text == "All")
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                    }
                    if (ActionRow["Status"].ToString() == "Idea" && ActionRow["StartMonth"].ToString() != "January" && Idea.Checked)
                    {
                        if (Devision.Text == "All")
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                if (Positive.Checked && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                                else if (Negative.Checked && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                    }
                }
            }
            ShowLoadActionSumSummary();
            IfZerotoDataGridView();
        }

        private void AddZerotoDataGridView()
        {
            DataGridView Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();

            for (int table = 0; table < 3; table++)
            {
                if (table == 1)
                {
                    Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
                }
                if (table == 2)
                {
                    Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();
                }

                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 13; column++)
                    {
                        Tabela.Rows[row].Cells[column].Value = 0;
                    }
                }
            }
        }

        private void IfZerotoDataGridView()
        {
            DataGridView Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();

            for (int table = 0; table < 3; table++)
            {
                if (table == 1)
                {
                    Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
                }
                if (table == 2)
                {
                    Tabela = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();
                }

                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 13; column++)
                    {
                        if (int.Parse(Tabela.Rows[row].Cells[column].Value.ToString()) == 0)
                        {
                            Tabela.Rows[row].Cells[column].Value = "";
                        }
                    }
                }
            }
        }

        private void ShowLoadActionSum(DataRow ActionRow, string CarryOver)
        {
            DataGridView Action;
            DataGridView ECCC;
            string[] ActionUse;
            string[] ECCCSum;

            if (CarryOver == "")
            {
                Action = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();
            }
            else
            {
                Action = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            }

            ECCC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();

            ActionUse = (ActionRow["CalcUSESaving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcUSEECCC" + CarryOver].ToString()).Split('/');

            if (ActionUse.Length != 1)
            {
                for (int counter = 1; counter < 13; counter++)
                {
                    if (ActionUse[counter - 1].ToString() != "")
                    {
                        Action.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(Action.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ActionUse[counter - 1].ToString());
                    }
                    if (ECCCSum[counter - 1].ToString() != "")
                    {
                        ECCC.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(ECCC.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ECCCSum[counter - 1].ToString());
                    }
                }
            }

            ActionUse = (ActionRow["CalcEA3Saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA3ECCC" + CarryOver].ToString()).Split('/');

            if (ActionUse.Length != 1)
            {
                for (int counter = 1; counter < 13; counter++)
                {
                    if (ActionUse[counter - 1].ToString() != "")
                    {
                        Action.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(Action.Rows[1].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ActionUse[counter - 1].ToString());
                    }
                    if (ECCCSum[counter - 1].ToString() != "")
                    {
                        ECCC.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(ECCC.Rows[1].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ECCCSum[counter - 1].ToString());
                    }
                }
            }

            ActionUse = (ActionRow["CalcEA2saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA2ECCC" + CarryOver].ToString()).Split('/');

            if (ActionUse.Length != 1)
            {
                for (int counter = 1; counter < 13; counter++)
                {
                    if (ActionUse[counter - 1].ToString() != "")
                    {
                        Action.Rows[2].Cells[counter.ToString()].Value = decimal.Parse(Action.Rows[2].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ActionUse[counter - 1].ToString());
                    }
                    if (ECCCSum[counter - 1].ToString() != "")
                    {
                        ECCC.Rows[2].Cells[counter.ToString()].Value = decimal.Parse(ECCC.Rows[2].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ECCCSum[counter - 1].ToString());
                    }
                }
            }
            ActionUse = (ActionRow["CalcEA1Saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA1ECCC" + CarryOver].ToString()).Split('/');

            if (ActionUse.Length != 1)
            {
                for (int counter = 1; counter < 13; counter++)
                {
                    if (ActionUse[counter - 1].ToString() != "")
                    {
                        Action.Rows[3].Cells[counter.ToString()].Value = decimal.Parse(Action.Rows[3].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ActionUse[counter - 1].ToString());
                    }
                    if (ECCCSum[counter - 1].ToString() != "")
                    {
                        ECCC.Rows[3].Cells[counter.ToString()].Value = decimal.Parse(ECCC.Rows[3].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ECCCSum[counter - 1].ToString());
                    }
                }
            }
            ActionUse = (ActionRow["CalcBUSaving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcBUECCC" + CarryOver].ToString()).Split('/');

            if (ActionUse.Length != 1)
            {
                for (int counter = 1; counter < 13; counter++)
                {
                    if (ActionUse[counter - 1].ToString() != "")
                    {
                        Action.Rows[4].Cells[counter.ToString()].Value = decimal.Parse(Action.Rows[4].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ActionUse[counter - 1].ToString());

                    }
                    if (ECCCSum[counter - 1].ToString() != "")
                    {
                        ECCC.Rows[4].Cells[counter.ToString()].Value = decimal.Parse(ECCC.Rows[4].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(ECCCSum[counter - 1].ToString());
                    }
                }
            }
        }

        private void ShowLoadActionSumSummary()
        {
            DataGridView Actual;
            DataGridView CarryOver;
            DataGridView ECCC;

            Actual = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();
            CarryOver = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            ECCC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();

            for (int counter = 0; counter < 12; counter++)
            {
                Actual.Rows[0].Cells["Sum"].Value = decimal.Parse(Actual.Rows[0].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[0].Cells[counter].Value.ToString());
                Actual.Rows[4].Cells["Sum"].Value = decimal.Parse(Actual.Rows[4].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[4].Cells[counter].Value.ToString());
                CarryOver.Rows[0].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[0].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[0].Cells[counter].Value.ToString());
                CarryOver.Rows[4].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[4].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[4].Cells[counter].Value.ToString());
                ECCC.Rows[0].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[0].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[0].Cells[counter].Value.ToString());
                ECCC.Rows[4].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[4].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[4].Cells[counter].Value.ToString());
            }

            for (int counter = 0; counter < 2; counter++)
            {
                Actual.Rows[3].Cells["Sum"].Value = decimal.Parse(Actual.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[0].Cells[counter].Value.ToString());
                CarryOver.Rows[3].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[0].Cells[counter].Value.ToString());
                ECCC.Rows[3].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[0].Cells[counter].Value.ToString());
            }
            for (int counter = 2; counter < 12; counter++)
            {
                Actual.Rows[3].Cells["Sum"].Value = decimal.Parse(Actual.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[3].Cells[counter].Value.ToString());
                CarryOver.Rows[3].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[3].Cells[counter].Value.ToString());
                ECCC.Rows[3].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[3].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[3].Cells[counter].Value.ToString());
            }

            for (int counter = 0; counter < 5; counter++)
            {
                Actual.Rows[2].Cells["Sum"].Value = decimal.Parse(Actual.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[0].Cells[counter].Value.ToString());
                CarryOver.Rows[2].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[0].Cells[counter].Value.ToString());
                ECCC.Rows[2].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[0].Cells[counter].Value.ToString());
            }
            for (int counter = 5; counter < 12; counter++)
            {
                Actual.Rows[2].Cells["Sum"].Value = decimal.Parse(Actual.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[2].Cells[counter].Value.ToString());
                CarryOver.Rows[2].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[2].Cells[counter].Value.ToString());
                ECCC.Rows[2].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[2].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[2].Cells[counter].Value.ToString());
            }

            for (int counter = 0; counter < 8; counter++)
            {
                Actual.Rows[1].Cells["Sum"].Value = decimal.Parse(Actual.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[0].Cells[counter].Value.ToString());
                CarryOver.Rows[1].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[0].Cells[counter].Value.ToString());
                ECCC.Rows[1].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[0].Cells[counter].Value.ToString());
            }
            for (int counter = 8; counter < 12; counter++)
            {
                Actual.Rows[1].Cells["Sum"].Value = decimal.Parse(Actual.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(Actual.Rows[1].Cells[counter].Value.ToString());
                CarryOver.Rows[1].Cells["Sum"].Value = decimal.Parse(CarryOver.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(CarryOver.Rows[1].Cells[counter].Value.ToString());
                ECCC.Rows[1].Cells["Sum"].Value = decimal.Parse(ECCC.Rows[1].Cells["Sum"].Value.ToString()) + decimal.Parse(ECCC.Rows[1].Cells[counter].Value.ToString());
            }
        }

        private void DataGridDifference(DataGridView DataGridSum)
        {
            decimal Use;
            decimal Rew;
            int Rewizja = 4;

            for (int counter = 0; counter < 12; counter++)
            {
                if (counter == 2)
                {
                    Rewizja -= 1;
                }
                if (counter == 5)
                {
                    Rewizja -= 1;
                }
                if (counter == 8)
                {
                    Rewizja -= 1;
                }

                if (DataGridSum.Rows[0].Cells[counter].Value.ToString() != "")
                {
                    if (DataGridSum.Rows[0].Cells[counter].Value.ToString() != "")
                    {
                        Use = Convert.ToDecimal(DataGridSum.Rows[0].Cells[counter].Value);
                    }
                    else
                    {
                        Use = 0;
                    }

                    if (DataGridSum.Rows[Rewizja].Cells[counter].Value.ToString() != "")
                    {
                        Rew = Convert.ToDecimal(DataGridSum.Rows[Rewizja].Cells[counter].Value);
                    }
                    else
                    {
                        Rew = 0;
                    }

                    DataGridSum.Rows[5].Cells[counter].Value = Use - Rew;

                    if (Convert.ToDecimal(DataGridSum.Rows[5].Cells[counter].Value) > 0)
                    {
                        DataGridSum.Rows[5].Cells[counter].Style.ForeColor = Color.Green;
                    }
                    else if (Convert.ToDecimal(DataGridSum.Rows[5].Cells[counter].Value) < 0)
                    {
                        DataGridSum.Rows[5].Cells[counter].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void PlanCheck()
        {
            DataTable Kurs = new DataTable();
            DataRow KursRow;

            DataGridView Actual = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();
            DataGridView CarryOver = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            DataGridView ECCC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();
            DataGridView ActualPlan = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSumActual", true).First();
            DataGridView CarryOverPlan = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSumCarryOver", true).First();
            DataGridView ECCCPlan = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSumECCC", true).First();
            NumericUpDown Num_Year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYearSum", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            KursRow = Kurs.Select(string.Format("Year LIKE '%{0}%'", Num_Year.Value.ToString())).FirstOrDefault();

            PlanTableClear(ActualPlan);
            PlanTableClear(CarryOverPlan);
            PlanTableClear(ECCCPlan);

            PlanTableCheck(Actual, ActualPlan, KursRow);
            PlanTableCheck(CarryOver, CarryOverPlan, KursRow);
            PlanTableCheck(ECCC, ECCCPlan, KursRow);
        }

        private void SumPlanCheck()
        {
            DataTable Kurs = new DataTable();
            DataRow KursRow;


            DataGridView Summ = (DataGridView)MainProgram.Self.TabControl.Controls.Find("DVG_SumPlan", true).First();
            NumericUpDown Num_Year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYearSum", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            KursRow = Kurs.Select(string.Format("Year LIKE '%{0}%'", Num_Year.Value.ToString())).FirstOrDefault();

            //Czyszczenie tablicy
            CleanSummTabel(Summ);

            //Sumowanie wartości z Actuala, CarryOver i ECCC
            Summ.Rows[0].Cells[0].Value = SumPlanTable(0);
            Summ.Rows[1].Cells[0].Value = SumPlanTable(1);
            Summ.Rows[2].Cells[0].Value = SumPlanTable(2);
            Summ.Rows[3].Cells[0].Value = SumPlanTable(3);
            Summ.Rows[4].Cells[0].Value = SumPlanTable(4);

            //Wyliczenie Procentów dostarczonych 
            PercentWykonania(Summ);

            //Wyliczenie ile już dostarczyliśmy DM 
            DMForRewizion(Summ, KursRow);

            //Wpisanie targetów
            TargetsSum(Summ, KursRow);

            //Delta 
            DeltaSumm(Summ);

        }

        //Liczenie procentów i ile DM to jest
        private void PlanTableCheck(DataGridView Actions, DataGridView Percent, DataRow KursRow)
        {
            string[] DM = new string[3];
            bool DMexist = false;
            decimal ActualDec;
            decimal Rew;
            decimal DMRew;
            decimal PercentValue = 0;

            if (KursRow != null)
            {
                if (KursRow["DM"].ToString() != "////" || KursRow["DM"].ToString() != "")
                {
                    DM = KursRow["DM"].ToString().Split('/');
                    DMexist = true;
                }
            }

            if (Actions.Rows[0].Cells["Sum"].Value != null && Actions.Rows[0].Cells["Sum"].Value.ToString() != "")
            {
                ActualDec = decimal.Parse(Actions.Rows[0].Cells["Sum"].Value.ToString());

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (Actions.Rows[counter].Cells["Sum"].Value != null && Actions.Rows[counter].Cells["Sum"].Value.ToString() != "")
                    {
                        Rew = decimal.Parse(Actions.Rows[counter].Cells["Sum"].Value.ToString());
                        if (ActualDec > 0 && Rew > 0)
                        {
                            PercentValue = (ActualDec / Rew) * 100;
                        }
                        else if (ActualDec < 0 && Rew < 0)
                        {
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        else if (ActualDec > 0 && Rew < 0)
                        {
                            Rew = ActualDec - Rew;
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        else if (ActualDec < 0 && Rew > 0)
                        {
                            Rew -= ActualDec;
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        Percent.Rows[counter].Cells[0].Value = Math.Round(PercentValue, 2, MidpointRounding.AwayFromZero);
                        if (DMexist)
                        {
                            if (DM[4 - counter].ToString() != "")
                            {
                                DMRew = decimal.Parse(DM[4 - counter].ToString());
                                Percent.Rows[counter].Cells[1].Value = Math.Round((ActualDec / DMRew) * 100, 4, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                }

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (Percent.Rows[counter].Cells[0].Value != null)
                    {
                        decimal Tocheck = decimal.Parse(Percent.Rows[counter].Cells[0].Value.ToString());
                        if (Tocheck >= 100)
                        {
                            Percent.Rows[counter].Cells[0].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            Percent.Rows[counter].Cells[0].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        //Czyszczenie poszczególnych tabel Dla procentów i DM 
        private void PlanTableClear(DataGridView Percent)
        {
            for (int counter = 0; counter <= 4; counter++)
            {
                Percent.Rows[counter].Cells[0].Value = null;
                Percent.Rows[counter].Cells[1].Value = null;
            }
        }

        //Sumowanie Actual, CarryOver i ECCC
        private decimal SumPlanTable(int Row)
        {
            decimal Sum = 0;
            DataGridView Actual = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_SavingSum", true).First();
            DataGridView CarryOver = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            DataGridView ECCC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCCSum", true).First();

            if (Actual.Rows[Row].Cells["Sum"].Value != null && Actual.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(Actual.Rows[Row].Cells["Sum"].Value.ToString());
            }
            if (CarryOver.Rows[Row].Cells["Sum"].Value != null && CarryOver.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(CarryOver.Rows[Row].Cells["Sum"].Value.ToString());
            }
            if (ECCC.Rows[Row].Cells["Sum"].Value != null && ECCC.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(ECCC.Rows[Row].Cells["Sum"].Value.ToString());
            }

            return Sum;
        }

        //Liczenie procent wykonania planu dla SumWszystkich partów
        private void PercentWykonania(DataGridView Summ)
        {
            decimal Rew;
            decimal Actual;
            decimal Percent = 0;

            if (Summ.Rows[0].Cells[0].Value != null && Summ.Rows[0].Cells[0].Value.ToString() != "")
            {
                Actual = decimal.Parse(Summ.Rows[0].Cells[0].Value.ToString());

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (Summ.Rows[counter].Cells[0].Value != null && Summ.Rows[counter].Cells[0].Value.ToString() != "")
                    {
                        Rew = decimal.Parse(Summ.Rows[counter].Cells[0].Value.ToString());

                        if (Actual > 0 && Rew > 0)
                        {
                            Percent = (Actual / Rew) * 100;
                        }
                        else if (Actual < 0 && Rew < 0)
                        {
                            Percent = (Rew / Actual) * 100;
                        }
                        else if (Actual > 0 && Rew < 0)
                        {
                            Rew = Actual - Rew;
                            Percent = (Rew / Actual) * 100;
                        }
                        else if (Actual < 0 && Rew > 0)
                        {
                            Rew -= Actual;
                            Percent = (Rew / Actual) * 100;
                        }

                        Summ.Rows[counter].Cells[1].Value = Math.Round(Percent, 2, MidpointRounding.AwayFromZero);
                        if (Percent >= 100)
                            Summ.Rows[counter].Cells[1].Style.ForeColor = Color.Green;
                        else
                            Summ.Rows[counter].Cells[1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        //Liczenie dostarczonego DM dla Rewizji
        private void DMForRewizion(DataGridView Summ, DataRow KursRow)
        {
            string[] DM = new string[4];
            bool CanCalc = false;
            decimal Actual;
            decimal DMValue;
            decimal Percent;

            if (KursRow["DM"].ToString() != "")
            {
                DM = KursRow["DM"].ToString().Split('/');
                CanCalc = true;
            }

            if (CanCalc)
            {
                if (Summ.Rows[0].Cells[0].Value != null && Summ.Rows[0].Cells[0].Value.ToString() != "")
                {
                    Actual = decimal.Parse(Summ.Rows[0].Cells[0].Value.ToString());

                    if (DM[0].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[0].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        Summ.Rows[4].Cells[2].Value = Percent;
                    }
                    if (DM[1].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[1].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        Summ.Rows[3].Cells[2].Value = Percent;
                    }
                    if (DM[2].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[2].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        Summ.Rows[2].Cells[2].Value = Percent;
                    }
                    if (DM[3].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[3].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        Summ.Rows[1].Cells[2].Value = Percent;
                    }
                    if (DM[4].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[4].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        Summ.Rows[0].Cells[2].Value = Percent;
                    }
                }
            }
        }

        //Wpisywanie targetów
        private void TargetsSum(DataGridView Summ, DataRow KursRow)
        {
            string[] DMPercent = new string[4];
            string[] DMValue = new string[4];
            bool CanCalc = false;
            decimal Target;
            decimal Percent;
            decimal DMRew;

            ComboBox Devision = (ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_SummDevision", true).First();

            if (Devision.SelectedItem.ToString() == "All")
            {
                if (KursRow["PC"].ToString() != "")
                {
                    DMPercent = KursRow["PC"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision.SelectedItem.ToString() == "Electronic")
            {
                if (KursRow["Ele"].ToString() != "")
                {
                    DMPercent = KursRow["Ele"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision.SelectedItem.ToString() == "Mechanic")
            {
                if (KursRow["Mech"].ToString() != "")
                {
                    DMPercent = KursRow["Mech"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision.SelectedItem.ToString() == "NVR")
            {
                if (KursRow["NVR"].ToString() != "")
                {
                    DMPercent = KursRow["NVR"].ToString().Split('/');
                    CanCalc = true;
                }
            }

            if (KursRow["DM"].ToString() != "")
            {
                DMValue = KursRow["DM"].ToString().Split('/');
            }

            if (CanCalc)
            {
                if (DMPercent[0].ToString() != "" && DMValue[0].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[0].ToString());
                    DMRew = decimal.Parse(DMValue[0].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    Summ.Rows[4].Cells[3].Value = Target;
                    Summ.Rows[4].Cells[4].Value = Percent;
                }
                if (DMPercent[1].ToString() != "" && DMValue[1].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[1].ToString());
                    DMRew = decimal.Parse(DMValue[1].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    Summ.Rows[3].Cells[3].Value = Target;
                    Summ.Rows[3].Cells[4].Value = Percent;
                }
                if (DMPercent[2].ToString() != "" && DMValue[2].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[2].ToString());
                    DMRew = decimal.Parse(DMValue[2].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    Summ.Rows[2].Cells[3].Value = Target;
                    Summ.Rows[2].Cells[4].Value = Percent;
                }
                if (DMPercent[3].ToString() != "" && DMValue[3].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[3].ToString());
                    DMRew = decimal.Parse(DMValue[3].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    Summ.Rows[1].Cells[3].Value = Target;
                    Summ.Rows[1].Cells[4].Value = Percent;
                }
                if (DMPercent[4].ToString() != "" && DMValue[4].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[4].ToString());
                    DMRew = decimal.Parse(DMValue[4].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    Summ.Rows[0].Cells[3].Value = Target;
                    Summ.Rows[0].Cells[4].Value = Percent;
                }
            }
        }

        //Wyliczenie Delty 
        private void DeltaSumm(DataGridView Summ)
        {
            decimal Delivery;
            decimal Plan;
            for (int counter = 0; counter <= 4; counter++)
            {
                if (Summ.Rows[counter].Cells[3].Value != null && Summ.Rows[counter].Cells[3].Value.ToString() != "")
                {
                    if (Summ.Rows[0].Cells[0].Value != null && Summ.Rows[0].Cells[0].Value.ToString() != "")
                    {
                        Plan = decimal.Parse(Summ.Rows[counter].Cells[3].Value.ToString());
                        Delivery = decimal.Parse(Summ.Rows[0].Cells[0].Value.ToString());
                        Summ.Rows[counter].Cells[5].Value = Delivery - Plan;
                        if (Delivery - Plan < 0)
                        {
                            Summ.Rows[counter].Cells[5].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            Summ.Rows[counter].Cells[5].Style.ForeColor = Color.Green;
                        }
                    }
                }
                if (Summ.Rows[counter].Cells[4].Value != null && Summ.Rows[counter].Cells[4].Value.ToString() != "")
                {
                    if (Summ.Rows[counter].Cells[2].Value != null && Summ.Rows[counter].Cells[2].Value.ToString() != "")
                    {
                        Plan = decimal.Parse(Summ.Rows[counter].Cells[4].Value.ToString());
                        Delivery = decimal.Parse(Summ.Rows[counter].Cells[2].Value.ToString());
                        Summ.Rows[counter].Cells[6].Value = Delivery - Plan;
                        if (Delivery - Plan < 0)
                        {
                            Summ.Rows[counter].Cells[6].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            Summ.Rows[counter].Cells[6].Style.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        //Czyszenie tablei
        private void CleanSummTabel(DataGridView Summ)
        {
            for (int counter = 0; counter <= 4; counter++)
            {
                for (int counter2 = 0; counter2 <= 6; counter2++)
                {
                    Summ.Rows[counter].Cells[counter2].Value = null;
                }
            }
        }
    }
}
