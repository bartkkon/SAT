using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    class SummaryDetails
    {
        Data_Import ImportData;
        MainProgram mainProgram;
        string LinkAction;
        string LinkFrozen;

        public SummaryDetails(MainProgram mainProgram, Data_Import ImportData)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            LinkAction = ImportData.Load_Link("Action");
            LinkFrozen = ImportData.Load_Link("Frozen");
        }

        public void SummaryDetails_ReportApprove(string Devision, string PC)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Devision == "Product Care Approve")
            {
                History history = new History(mainProgram, ImportData);
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

        public void SummaryDetails_Show(DataRow Person)
        {
            ShowCurrentAction(Person);
        }

        public void SummaryDetails_DataGridDifference()
        {
            DataGridDifference((DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First());
            DataGridDifference((DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First());
            DataGridDifference((DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First());
        }

        public void SummaryDetails_CheckifCanReporting(string Devision, string PC)
        {
            CheckifCanReporting(Devision, PC);
        }

        public void SummaryDetails_DataGridDifferenceClear()
        {
            DataGridDifferenceClear();
        }

        // Przeliczanie akcji dla raportu finalnego
        private void AddToFinalReport(string Devision)
        {
            string Link;

            DataTable Frozen = new DataTable();
            DataRow FrozenYear;
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            if (Devision != "Product Care Approve")
            {

                Link = ImportData.Load_Link("Frozen");
                ImportData.Load_TxtToDataTable(ref Frozen, Link);

                FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

                PCRaport_Approval PC_Approval = new PCRaport_Approval();

                if (FrozenYear["BU"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, "BU", Year, ImportData);
                }
                else if (FrozenYear["EA1"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, "EA1", Year, ImportData);
                }
                else if (FrozenYear["EA2"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, "EA2", Year, ImportData);
                }
                else if (FrozenYear["EA3"].ToString() == "Open")
                {
                    PC_Approval.Approve_Info(Devision, "EA3", Year, ImportData);
                }


            }
        }

        private void DataGridDifferenceClear()
        {
            DataGridView DG_ToClearCurrent = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();
            DataGridView DG_ToClearCarry = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            DataGridView DG_ToCearECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();
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
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;
            bool ToApprove = false;
            int ToApproveFull = 0;

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);
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
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_EleApprove", true).First()).Enabled = true;

                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["EleApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_EleApprove", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
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
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_MechApprove", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["MechApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_MechApprove", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
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
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_NVRApprove", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                else if (FrozenRow["NVRApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_NVRApprove", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                    App = null;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
            }
            if (PC == "true")
            {
                App = mainProgram.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
                for (int counter = 0; counter < App.Length; counter++)
                {
                    App[counter].Enabled = false;
                }
            }

            if (Devision == "PC" && ToApprove == true)
            {
                if (FrozenRow["EleApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_EleRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (FrozenRow["MechApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_MechRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (FrozenRow["NVRApp"].ToString() == "Approve")
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                    ToApproveFull += 1;
                }
                else
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_NVRRejected", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = false;
                    }
                }
                if (ToApproveFull == 3)
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_PCApprove", true).First()).Enabled = true;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
                    for (int counter = 0; counter < App.Length; counter++)
                    {
                        App[counter].Enabled = true;
                    }
                }
                else
                {
                    //((Button)mainProgram.TabControl.Controls.Find("pb_SummDet_PCApprove", true).First()).Enabled = false;
                    App = mainProgram.TabControl.Controls.Find("pb_SummDet_PCApprove", true);
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
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            if (FrozenRow != null)
            {
                if (Devision == "Electronic Rejected")
                {
                    FrozenRow["EleApp"] = "Close";
                }
                if (Devision == "Mechanic Rejected")
                {
                    FrozenRow["MechApp"] = "Close";
                }
                if (Devision == "NVR Rejected")
                {
                    FrozenRow["NVRApp"] = "Close";
                }
            }
            ImportData.Save_DataTableToTXT(ref Frozen, LinkFrozen);
        }

        private void ReportApprove(string Devision)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            if (FrozenRow != null)
            {
                if (Devision == "Electronic Approve")
                {
                    FrozenRow["EleApp"] = "Approve";
                }
                if (Devision == "Mechanic Approve")
                {
                    FrozenRow["MechApp"] = "Approve";
                }
                if (Devision == "NVR Approve")
                {
                    FrozenRow["NVRApp"] = "Approve";
                }
                if (Devision == "Product Care Approve")
                {
                    FrozenRow["EleApp"] = "Close";
                    FrozenRow["MechApp"] = "Close";
                    FrozenRow["NVRApp"] = "Close";
                    if (FrozenRow["BU"].ToString() == "Open")
                    {
                        FrozenRow["BU"] = "Approve";
                    }
                    if (FrozenRow["EA1"].ToString() == "Open")
                    {
                        FrozenRow["EA1"] = "Approve";
                    }
                    if (FrozenRow["EA2"].ToString() == "Open")
                    {
                        FrozenRow["EA2"] = "Approve";
                    }
                    if (FrozenRow["EA3"].ToString() == "Open")
                    {
                        FrozenRow["EA3"] = "Approve";
                    }
                    for (int counter = 1; counter <= 12; counter++)
                    {
                        if (FrozenRow[counter.ToString()].ToString() == "Open")
                        {
                            FrozenRow[counter.ToString()] = "Approve";
                        }
                    }
                }
            }
            ImportData.Save_DataTableToTXT(ref Frozen, LinkFrozen);
        }

        private void ShowCurrentAction(DataRow Person)
        {
            DataTable Action = new DataTable();
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            DataGridView dg_CurrentAction = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CurrentAction", true).First();
            DataGridView dg_CarryOver = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOver", true).First();
            ComboBox Leader = (ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetLeader", true).First();
            ComboBox Devision = (ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetDevision", true).First();
            CheckBox Active = (CheckBox)mainProgram.TabControl.Controls.Find("CB_Active1", true).First();
            CheckBox Idea = (CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea1", true).First();

            dg_CurrentAction.Rows.Clear();
            dg_CarryOver.Rows.Clear();

            ImportData.Load_TxtToDataTable(ref Action, LinkAction);

            AddZerotoDataGridView();

            foreach (DataRow ActionRow in Action.Rows)
            {
                if (ActionRow["StartYear"].ToString() == Year.ToString() || ActionRow["StartYear"].ToString() == "BU/" + Year.ToString())
                {
                    if (ActionRow["Status"].ToString() == "Active" && Active.Checked)
                    {
                        if (Devision.Text == "All")
                        {
                            if (Leader.Text == "All")
                            {
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "");
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
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                ShowLoadAction(ActionRow, "");
                                ShowLoadActionSum(ActionRow, "");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "");
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
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "Carry");
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
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                        }
                        else if (ActionRow["Group"].ToString() == Devision.Text)
                        {
                            if (Leader.Text == "All")
                            {
                                ShowLoadAction(ActionRow, "Carry");
                                ShowLoadActionSum(ActionRow, "Carry");
                            }
                            else if (ActionRow["Leader"].ToString() == Leader.Text)
                            {
                                ShowLoadAction(ActionRow, "Carry");
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
            DataGridView Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();

            for (int table = 0; table < 3; table++)
            {
                if (table == 1)
                {
                    Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
                }
                if (table == 2)
                {
                    Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();
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
            DataGridView Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();

            for (int table = 0; table < 3; table++)
            {
                if (table == 1)
                {
                    Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
                }
                if (table == 2)
                {
                    Tabela = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();
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

        private void ShowLoadAction(DataRow ActionRow, string CarryOver)
        {
            DataGridView Table;
            DataTable Frozen = new DataTable();
            DataRow FrozenYear;

            int rowIndex;
            string[] QuantityUse;
            string[] SavingUse;
            string[] ECCCUse;
            decimal Month = DateTime.Today.Month;
            string Rewizion = "BU";
            NumericUpDown Num_Year = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First();

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);
            FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Num_Year.Value.ToString())).FirstOrDefault();

            if (FrozenYear != null)
            {
                if (Month < 3)
                {
                    Rewizion = "BU";
                }
                if (Month >= 3 && Month < 6)
                {
                    if (FrozenYear["EA1"].ToString() == "Approve" || FrozenYear["EA1"].ToString() == "Open")
                    {
                        Rewizion = "EA1";
                    }
                    else
                    {
                        Rewizion = "BU";
                    }

                }
                if (Month >= 6 && Month < 9)
                {
                    if (FrozenYear["EA2"].ToString() == "Approve" || FrozenYear["EA2"].ToString() == "Open")
                    {
                        Rewizion = "EA2";
                    }
                    else
                    {
                        Rewizion = "EA1";
                    }

                }
                if (Month >= 9)
                {

                    if (FrozenYear["EA3"].ToString() == "Approve" || FrozenYear["EA3"].ToString() == "Open")
                    {
                        Rewizion = "EA3";
                    }
                    else
                    {
                        Rewizion = "EA2";
                    }
                }

                if (CarryOver == "")
                {
                    Table = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CurrentAction", true).First();
                }
                else
                {
                    Table = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOver", true).First();
                }


                rowIndex = Table.Rows.Add();
                Table.Rows[rowIndex].DefaultCellStyle.Format = "#,0.###";
                Table.Rows[rowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Table.Rows[rowIndex].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Table.Rows[rowIndex].Cells["Name"].Value = ActionRow["Name"].ToString();

                QuantityUse = (ActionRow["CalcUSEQuantity" + CarryOver].ToString()).Split('/');
                SavingUse = (ActionRow["CalcUSESaving" + CarryOver].ToString()).Split('/');
                ECCCUse = (ActionRow["CalcUSEECCC" + CarryOver].ToString()).Split('/');

                for (int counter = 1; counter < Month; counter++)
                {
                    if (QuantityUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["Q" + counter.ToString()].Value = decimal.Parse(QuantityUse[counter - 1]);
                        Table.Rows[rowIndex].Cells["Q" + counter.ToString()].Style.Font = new Font(Table.Font, FontStyle.Bold);
                    }
                    if (SavingUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["S" + counter.ToString()].Value = decimal.Parse(SavingUse[counter - 1]);
                        Table.Rows[rowIndex].Cells["S" + counter.ToString()].Style.Font = new Font(Table.Font, FontStyle.Bold);
                    }
                    if (ECCCUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["E" + counter.ToString()].Value = decimal.Parse(ECCCUse[counter - 1]);
                        Table.Rows[rowIndex].Cells["E" + counter.ToString()].Style.Font = new Font(Table.Font, FontStyle.Bold);
                    }
                }

                QuantityUse = (ActionRow["Calc" + Rewizion + "Quantity" + CarryOver].ToString()).Split('/');
                SavingUse = (ActionRow["Calc" + Rewizion + "Saving" + CarryOver].ToString()).Split('/');
                ECCCUse = (ActionRow["Calc" + Rewizion + "ECCC" + CarryOver].ToString()).Split('/');

                for (int counter = int.Parse(Month.ToString()); counter < 13; counter++)
                {
                    if (QuantityUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["Q" + counter.ToString()].Value = decimal.Parse(QuantityUse[counter - 1]);
                    }
                    if (SavingUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["S" + counter.ToString()].Value = decimal.Parse(SavingUse[counter - 1]);
                    }
                    if (ECCCUse[counter - 1] != "")
                    {
                        Table.Rows[rowIndex].Cells["E" + counter.ToString()].Value = decimal.Parse(ECCCUse[counter - 1]);
                    }
                }

                decimal Quantity = 0;
                decimal Saving = 0;
                decimal ECCC = 0;

                for (int counter = 1; counter < 13; counter++)
                {
                    if (Table.Rows[rowIndex].Cells["Q" + counter.ToString()].Value != null)
                    {
                        Quantity = Quantity + decimal.Parse(Table.Rows[rowIndex].Cells["Q" + counter].Value.ToString());
                        Saving = Saving + decimal.Parse(Table.Rows[rowIndex].Cells["S" + counter].Value.ToString());
                    }
                    if (Table.Rows[rowIndex].Cells["E" + counter.ToString()].Value != null)
                    {
                        ECCC = ECCC + decimal.Parse(Table.Rows[rowIndex].Cells["E" + counter].Value.ToString());
                    }
                }

                if (Quantity != 0)
                {
                    Table.Rows[rowIndex].Cells["QSum"].Value = Quantity;
                }
                if (Saving != 0)
                {
                    Table.Rows[rowIndex].Cells["SSum"].Value = Saving;
                }
                if (ECCC != 0)
                {
                    Table.Rows[rowIndex].Cells["ESum"].Value = ECCC;
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
                Action = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();
            }
            else
            {
                Action = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            }

            ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();

            ActionUse = (ActionRow["CalcUSESaving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcUSEECCC" + CarryOver].ToString()).Split('/');

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

            ActionUse = (ActionRow["CalcEA3Saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA3ECCC" + CarryOver].ToString()).Split('/');

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

            ActionUse = (ActionRow["CalcEA2saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA2ECCC" + CarryOver].ToString()).Split('/');

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

            ActionUse = (ActionRow["CalcEA1Saving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcEA1ECCC" + CarryOver].ToString()).Split('/');

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

            ActionUse = (ActionRow["CalcBUSaving" + CarryOver].ToString()).Split('/');
            ECCCSum = (ActionRow["CalcBUECCC" + CarryOver].ToString()).Split('/');

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

        private void ShowLoadActionSumSummary()
        {
            DataGridView Actual;
            DataGridView CarryOver;
            DataGridView ECCC;

            Actual = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();
            CarryOver = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();

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
            decimal Use = 0;
            decimal Rew = 0;
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
    }
}
