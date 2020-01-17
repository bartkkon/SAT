using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework;

namespace Saving_Accelerator_Tool
{
    class SummaryDetailsFormHendler
    {
        private readonly MainProgram mainProgram;
        private readonly SummaryDetails summaryDetails;
        private readonly Data_Import data_Import;
        private readonly DataRow Person;
        private readonly Charts charts;

        public SummaryDetailsFormHendler(MainProgram mainProgram, SummaryDetails summaryDetails, DataRow Person, Data_Import data_Import)
        {
            this.mainProgram = mainProgram;
            this.summaryDetails = summaryDetails;
            this.Person = Person;
            this.data_Import = data_Import;
            charts = new Charts(mainProgram);
        }

        public void Pb_SummDet_Approve_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want " + (sender as Button).Text.ToString() + "?", "Report Approve", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                summaryDetails.SummaryDetails_ReportApprove((sender as Button).Text, Person["PCApprove"].ToString());
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        public void Pb_SummDet_Rejected_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want " + (sender as Button).Text + "?", "Report Rejected", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                summaryDetails.SummaryDetails_ReportRejected((sender as Button).Text, Person["PCApprove"].ToString());
            }
            else if (Result == DialogResult.No)
            {
                return;
            }
        }

        public void Pb_SummDet_Show_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            summaryDetails.SummaryDetails_Show(Person);
            _ = new SDTableLoad();
            charts.ChartSummary();
            summaryDetails.SummaryDetails_DataGridDifferenceClear();
            summaryDetails.SummaryDetails_DataGridDifference();
            summaryDetails.SummaryDetails_PlanCheck();
            summaryDetails.SummaryDetails_SumPlanCheck();
            Cursor.Current = Cursors.Default;
        }

        public void Cb_ChartFilter_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            charts.Charts_AddSeries();
            Cursor.Current = Cursors.Default;
        }

        public void Cb_LevelChange_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Level1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level1", true).First();
            CheckBox cb_Level2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level2", true).First();
            CheckBox cb_Level3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level3", true).First();
            CheckBox cb_Level1Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level1Sum", true).First();
            CheckBox cb_Level2Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level2Sum", true).First();
            CheckBox cb_Level3Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level3Sum", true).First();

            cb_Level1.CheckedChanged -= Cb_LevelChange_CheckedChanged;
            cb_Level2.CheckedChanged -= Cb_LevelChange_CheckedChanged;
            cb_Level3.CheckedChanged -= Cb_LevelChange_CheckedChanged;
            cb_Level1Sum.CheckedChanged -= Cb_LevelChange_CheckedChanged;
            cb_Level2Sum.CheckedChanged -= Cb_LevelChange_CheckedChanged;
            cb_Level3Sum.CheckedChanged -= Cb_LevelChange_CheckedChanged;

            if ((sender as CheckBox).Text == "Level 1")
            {
                cb_Level1.Checked = true;
                cb_Level2.Checked = false;
                cb_Level3.Checked = false;
                cb_Level1Sum.Checked = true;
                cb_Level2Sum.Checked = false;
                cb_Level3Sum.Checked = false;
            }
            if ((sender as CheckBox).Text == "Level 2")
            {
                cb_Level1.Checked = false;
                cb_Level2.Checked = true;
                cb_Level3.Checked = false;
                cb_Level1Sum.Checked = false;
                cb_Level2Sum.Checked = true;
                cb_Level3Sum.Checked = false;
            }
            if ((sender as CheckBox).Text == "Level 3")
            {
                cb_Level1.Checked = false;
                cb_Level2.Checked = false;
                cb_Level3.Checked = true;
                cb_Level1Sum.Checked = false;
                cb_Level2Sum.Checked = false;
                cb_Level3Sum.Checked = true;
            }

            cb_Level1.CheckedChanged += Cb_LevelChange_CheckedChanged;
            cb_Level2.CheckedChanged += Cb_LevelChange_CheckedChanged;
            cb_Level3.CheckedChanged += Cb_LevelChange_CheckedChanged;
            cb_Level1Sum.CheckedChanged += Cb_LevelChange_CheckedChanged;
            cb_Level2Sum.CheckedChanged += Cb_LevelChange_CheckedChanged;
            cb_Level3Sum.CheckedChanged += Cb_LevelChange_CheckedChanged;
        }

        public void Pb_SummDet_ReportingRefresh_Click(object sender, EventArgs e)
        {
            if (Person["EleApprove"].ToString() == "true")
            {
                summaryDetails.SummaryDetails_CheckifCanReporting("Electronic","false");
            }
            if (Person["MechApprove"].ToString() == "true")
            {
                summaryDetails.SummaryDetails_CheckifCanReporting("Mechanic", "false");
            }
            if (Person["NVRapprove"].ToString() == "true")
            {
                summaryDetails.SummaryDetails_CheckifCanReporting("NVR","false");
            }
            if (Person["PCApprove"].ToString() == "true")
            {
                summaryDetails.SummaryDetails_CheckifCanReporting("PC", "false");
            }
        }

        public void GeneretedSumCurrentAction_CarryOver_DataGridView()
        {
            GroupBox gb_ShowActionSum = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ShowActionSum", true).First();

            Label lab_CurrentActionSum = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(470, 15),
                Name = "lab_CurrentActionSum",
                Size = new System.Drawing.Size(20, 13),
                Text = "Actual:",
            };
            gb_ShowActionSum.Controls.Add(lab_CurrentActionSum);

            DataGridView dg_SavingSum = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 30),
                Name = "dg_SavingSum",
                Size = new System.Drawing.Size(1133, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreateTable(dg_SavingSum);
            gb_ShowActionSum.Controls.Add(dg_SavingSum);

            Label lab_CarryOverSum = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(470, 190),
                Name = "lab_CarryOverSum",
                Size = new System.Drawing.Size(20, 13),
                Text = "Carry Over:",
            };
            gb_ShowActionSum.Controls.Add(lab_CarryOverSum);

            DataGridView dg_CarryOverSum = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 205),
                Name = "dg_CarryOverSum",
                Size = new System.Drawing.Size(1133, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreateTable(dg_CarryOverSum);
            gb_ShowActionSum.Controls.Add(dg_CarryOverSum);

            Label lab_ECCCSum = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(470, 365),
                Name = "lab_ECCCSum",
                Size = new System.Drawing.Size(20, 13),
                Text = "ECCC:",
            };
            gb_ShowActionSum.Controls.Add(lab_ECCCSum);

            DataGridView dg_ECCCSum = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 380),
                Name = "dg_ECCCSum",
                Size = new System.Drawing.Size(1133, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreateTable(dg_ECCCSum);
            gb_ShowActionSum.Controls.Add(dg_ECCCSum);
        }

        public void ComboBox_Devision_ChangeIndex(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Name == "Comb_SummDevision")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetDevision", true).First()).SelectedIndex = (sender as ComboBox).SelectedIndex;
            }
            else if ((sender as ComboBox).Name == "Comb_SummDetDevision")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDevision", true).First()).SelectedIndex = (sender as ComboBox).SelectedIndex;
            }
        }

        public void ComboBox_Leader_ChangeIndex(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Name == "Comb_SummLeader")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetLeader", true).First()).SelectedIndex = (sender as ComboBox).SelectedIndex;
            }
            else if ((sender as ComboBox).Name == "Comb_SummDetLeader")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummLeader", true).First()).SelectedIndex = (sender as ComboBox).SelectedIndex;
            }
        }

        public void Num_Year_ValueChange(object sender, EventArgs e)
        {
            if((sender as NumericUpDown).Name == "num_SummaryDetailYear")
            {
                ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYearSum", true).First()).Value = (sender as NumericUpDown).Value;
            }
            else if((sender as NumericUpDown).Name == "num_SummaryDetailYearSum")
            {
                ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value = (sender as NumericUpDown).Value;
            }
        }

        public void Active_CheckedChange(object sender, EventArgs e)
        {
            CheckBox ToCheck = sender as CheckBox;

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active1", true).First()).CheckedChanged -= Active_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active2", true).First()).CheckedChanged -= Active_CheckedChange;

            if (ToCheck.Name == "CB_Active1")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active2", true).First()).Checked = ToCheck.Checked;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active1", true).First()).Checked = ToCheck.Checked;
            }

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active1", true).First()).CheckedChanged += Active_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Active2", true).First()).CheckedChanged += Active_CheckedChange;
        }

        public void Idea_CheckedChange(object sender, EventArgs e)
        {
            CheckBox ToCheck = sender as CheckBox;

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea1", true).First()).CheckedChanged -= Idea_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea2", true).First()).CheckedChanged -= Idea_CheckedChange;

            if (ToCheck.Name == "CB_Idea1")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea2", true).First()).Checked = ToCheck.Checked;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea1", true).First()).Checked = ToCheck.Checked;
            }

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea1", true).First()).CheckedChanged += Idea_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea2", true).First()).CheckedChanged += Idea_CheckedChange;
        }

        public void Positive_CheckedChange(object sender, EventArgs e)
        {
            CheckBox ToCheck = sender as CheckBox;

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive1", true).First()).CheckedChanged -= Positive_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive2", true).First()).CheckedChanged -= Positive_CheckedChange;

            if (ToCheck.Name == "CB_Positive1")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive2", true).First()).Checked = ToCheck.Checked;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive1", true).First()).Checked = ToCheck.Checked;
            }

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive1", true).First()).CheckedChanged += Positive_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Positive2", true).First()).CheckedChanged += Positive_CheckedChange;
        }

        public void Negative_CheckedChange(object sender, EventArgs e)
        {
            CheckBox ToCheck = sender as CheckBox;

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative1", true).First()).CheckedChanged -= Negative_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative2", true).First()).CheckedChanged -= Negative_CheckedChange;

            if (ToCheck.Name == "CB_Negative1")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative2", true).First()).Checked = ToCheck.Checked;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative1", true).First()).Checked = ToCheck.Checked;
            }

            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative1", true).First()).CheckedChanged += Negative_CheckedChange;
            ((CheckBox)mainProgram.TabControl.Controls.Find("CB_Negative2", true).First()).CheckedChanged += Negative_CheckedChange;
        }

        public void PCRaport_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //PCRaports_Genereted genereted = new PCRaports_Genereted(mainProgram, data_Import);
            //genereted.Genereted_PCRaport();
            //Cursor.Current = Cursors.Default;

            NumericUpDown YearToCalc = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_SummaryDetailYear", true).First();

            ReportingOption Report = new ReportingOption(mainProgram, data_Import, YearToCalc.Value);
            Report.ShowDialog();
        }

        private void CreateTable(DataGridView Table)
        {
            Table.Columns.Add("1", "I");
            Table.Columns.Add("2", "II");
            Table.Columns.Add("3", "III");
            Table.Columns.Add("4", "IV");
            Table.Columns.Add("5", "V");
            Table.Columns.Add("6", "VI");
            Table.Columns.Add("7", "VII");
            Table.Columns.Add("8", "VIII");
            Table.Columns.Add("9", "IX");
            Table.Columns.Add("10", "X");
            Table.Columns.Add("11", "XI");
            Table.Columns.Add("12", "XII");
            Table.Columns.Add("Sum", "Sum:");
            Table.Columns[0].Width = 80;
            Table.Columns[1].Width = 80;
            Table.Columns[2].Width = 80;
            Table.Columns[3].Width = 80;
            Table.Columns[4].Width = 80;
            Table.Columns[5].Width = 80;
            Table.Columns[6].Width = 80;
            Table.Columns[7].Width = 80;
            Table.Columns[8].Width = 80;
            Table.Columns[9].Width = 80;
            Table.Columns[10].Width = 80;
            Table.Columns[11].Width = 80;
            Table.Columns[12].Width = 103;
            Table.Rows.Add(6);
            Table.RowHeadersWidth = 68;
            Table.Rows[0].HeaderCell.Value = "Actual:";
            Table.Rows[1].HeaderCell.Value = "EA3:";
            Table.Rows[2].HeaderCell.Value = "EA2:";
            Table.Rows[3].HeaderCell.Value = "EA1:";
            Table.Rows[4].HeaderCell.Value = "BU:";
            Table.Rows[5].HeaderCell.Value = "Diff:";
            Table.CurrentCell = Table[0, 0];
            Table.ClearSelection();
            Table.Columns[0].Frozen = true;
            Table.Rows[0].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[1].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[2].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[3].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[4].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[5].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            Table.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            Table.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            Table.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
            Table.Columns["Sum"].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
            Table.Rows[0].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
        }
    }
}
