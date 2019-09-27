using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;



namespace Saving_Accelerator_Tool
{
    class SummaryDetailsFormHendler
    {
        MainProgram mainProgram;
        SummaryDetails summaryDetails;
        Data_Import data_Import;
        DataRow Person;
        Charts charts;

        public SummaryDetailsFormHendler(MainProgram mainProgram, SummaryDetails summaryDetails, DataRow Person, Data_Import data_Import)
        {
            this.mainProgram = mainProgram;
            this.summaryDetails = summaryDetails;
            this.Person = Person;
            this.data_Import = data_Import;
            charts = new Charts(mainProgram);
        }

        public void pb_SummDet_Approve_Click(object sender, EventArgs e)
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

        public void pb_SummDet_Rejected_Click(object sender, EventArgs e)
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

        public void pb_SummDet_Show_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            summaryDetails.SummaryDetails_Show(Person);
            charts.ChartSummary();
            summaryDetails.SummaryDetails_DataGridDifferenceClear();
            summaryDetails.SummaryDetails_DataGridDifference();
            Cursor.Current = Cursors.Default;
        }

        public void Cb_ChartFilter_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            charts.Charts_AddSeries();
            Cursor.Current = Cursors.Default;
        }

        public void cb_LevelChange_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb_Level1 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level1", true).First();
            CheckBox cb_Level2 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level2", true).First();
            CheckBox cb_Level3 = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level3", true).First();
            CheckBox cb_Level1Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level1Sum", true).First();
            CheckBox cb_Level2Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level2Sum", true).First();
            CheckBox cb_Level3Sum = (CheckBox)mainProgram.TabControl.Controls.Find("cb_Level3Sum", true).First();

            cb_Level1.CheckedChanged -= cb_LevelChange_CheckedChanged;
            cb_Level2.CheckedChanged -= cb_LevelChange_CheckedChanged;
            cb_Level3.CheckedChanged -= cb_LevelChange_CheckedChanged;
            cb_Level1Sum.CheckedChanged -= cb_LevelChange_CheckedChanged;
            cb_Level2Sum.CheckedChanged -= cb_LevelChange_CheckedChanged;
            cb_Level3Sum.CheckedChanged -= cb_LevelChange_CheckedChanged;

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

            cb_Level1.CheckedChanged += cb_LevelChange_CheckedChanged;
            cb_Level2.CheckedChanged += cb_LevelChange_CheckedChanged;
            cb_Level3.CheckedChanged += cb_LevelChange_CheckedChanged;
            cb_Level1Sum.CheckedChanged += cb_LevelChange_CheckedChanged;
            cb_Level2Sum.CheckedChanged += cb_LevelChange_CheckedChanged;
            cb_Level3Sum.CheckedChanged += cb_LevelChange_CheckedChanged;
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

        public void GeneretedCurrentAction_CarryOver_DataGridView()
        {
            GroupBox gb_ShowAction = (GroupBox)mainProgram.TabControl.Controls.Find("gb_ShowAction", true).First();

            DataGridView dg_CurrentAction = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 60),
                Name = "dg_CurrentAction",
                Size = new System.Drawing.Size(1500, 400),
                AllowUserToAddRows = false,
                ReadOnly = true,
                //Enabled = false,

            };
            dg_CurrentAction.Columns.Add("Name", "Name Action");
            dg_CurrentAction.Columns[0].Width = 200;
            dg_CurrentAction.Columns.Add("Q1", "I");
            dg_CurrentAction.Columns.Add("Q2", "II");
            dg_CurrentAction.Columns.Add("Q3", "III");
            dg_CurrentAction.Columns.Add("Q4", "IV");
            dg_CurrentAction.Columns.Add("Q5", "V");
            dg_CurrentAction.Columns.Add("Q6", "VI");
            dg_CurrentAction.Columns.Add("Q7", "VII");
            dg_CurrentAction.Columns.Add("Q8", "VIII");
            dg_CurrentAction.Columns.Add("Q9", "IX");
            dg_CurrentAction.Columns.Add("Q10", "X");
            dg_CurrentAction.Columns.Add("Q11", "XI");
            dg_CurrentAction.Columns.Add("Q12", "XII");
            dg_CurrentAction.Columns.Add("QSum", "Sum:");

            dg_CurrentAction.Columns[1].Width = 67;
            dg_CurrentAction.Columns[2].Width = 67;
            dg_CurrentAction.Columns[3].Width = 67;
            dg_CurrentAction.Columns[4].Width = 67;
            dg_CurrentAction.Columns[5].Width = 67;
            dg_CurrentAction.Columns[6].Width = 67;
            dg_CurrentAction.Columns[7].Width = 67;
            dg_CurrentAction.Columns[8].Width = 67;
            dg_CurrentAction.Columns[9].Width = 67;
            dg_CurrentAction.Columns[10].Width = 67;
            dg_CurrentAction.Columns[11].Width = 67;
            dg_CurrentAction.Columns[12].Width = 67;
            dg_CurrentAction.Columns[13].Width = 84;

            dg_CurrentAction.Columns.Add("Break1", "");
            dg_CurrentAction.Columns[14].Width = 50;

            dg_CurrentAction.Columns.Add("S1", "I");
            dg_CurrentAction.Columns.Add("S2", "II");
            dg_CurrentAction.Columns.Add("S3", "III");
            dg_CurrentAction.Columns.Add("S4", "IV");
            dg_CurrentAction.Columns.Add("S5", "V");
            dg_CurrentAction.Columns.Add("S6", "VI");
            dg_CurrentAction.Columns.Add("S7", "VII");
            dg_CurrentAction.Columns.Add("S8", "VIII");
            dg_CurrentAction.Columns.Add("S9", "IX");
            dg_CurrentAction.Columns.Add("S10", "X");
            dg_CurrentAction.Columns.Add("S11", "XI");
            dg_CurrentAction.Columns.Add("S12", "XII");
            dg_CurrentAction.Columns.Add("SSum", "Sum:");

            dg_CurrentAction.Columns[15].Width = 67;
            dg_CurrentAction.Columns[16].Width = 67;
            dg_CurrentAction.Columns[17].Width = 67;
            dg_CurrentAction.Columns[18].Width = 67;
            dg_CurrentAction.Columns[19].Width = 67;
            dg_CurrentAction.Columns[20].Width = 67;
            dg_CurrentAction.Columns[21].Width = 67;
            dg_CurrentAction.Columns[22].Width = 67;
            dg_CurrentAction.Columns[23].Width = 67;
            dg_CurrentAction.Columns[24].Width = 67;
            dg_CurrentAction.Columns[25].Width = 67;
            dg_CurrentAction.Columns[26].Width = 67;
            dg_CurrentAction.Columns[27].Width = 84;

            dg_CurrentAction.Columns.Add("Break2", "");
            dg_CurrentAction.Columns[28].Width = 50;

            dg_CurrentAction.Columns.Add("E1", "I");
            dg_CurrentAction.Columns.Add("E2", "II");
            dg_CurrentAction.Columns.Add("E3", "III");
            dg_CurrentAction.Columns.Add("E4", "IV");
            dg_CurrentAction.Columns.Add("E5", "V");
            dg_CurrentAction.Columns.Add("E6", "VI");
            dg_CurrentAction.Columns.Add("E7", "VII");
            dg_CurrentAction.Columns.Add("E8", "VIII");
            dg_CurrentAction.Columns.Add("E9", "IX");
            dg_CurrentAction.Columns.Add("E10", "X");
            dg_CurrentAction.Columns.Add("E11", "XI");
            dg_CurrentAction.Columns.Add("E12", "XII");
            dg_CurrentAction.Columns.Add("ESum", "Sum:");

            dg_CurrentAction.Columns[28].Width = 67;
            dg_CurrentAction.Columns[29].Width = 67;
            dg_CurrentAction.Columns[30].Width = 67;
            dg_CurrentAction.Columns[31].Width = 67;
            dg_CurrentAction.Columns[32].Width = 67;
            dg_CurrentAction.Columns[33].Width = 67;
            dg_CurrentAction.Columns[34].Width = 67;
            dg_CurrentAction.Columns[35].Width = 67;
            dg_CurrentAction.Columns[36].Width = 67;
            dg_CurrentAction.Columns[37].Width = 67;
            dg_CurrentAction.Columns[38].Width = 67;
            dg_CurrentAction.Columns[39].Width = 67;
            dg_CurrentAction.Columns[40].Width = 84;

            dg_CurrentAction.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dg_CurrentAction.ClearSelection();
            dg_CurrentAction.Columns[0].Frozen = true;
            gb_ShowAction.Controls.Add(dg_CurrentAction);


            DataGridView dg_CarryOver = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 520),
                Name = "dg_CarryOver",
                Size = new System.Drawing.Size(1500, 400),
                AllowUserToAddRows = false,
                ReadOnly = true,
                //Enabled = false,

            };
            dg_CarryOver.Columns.Add("Name", "Name Action");
            dg_CarryOver.Columns[0].Width = 200;
            dg_CarryOver.Columns.Add("Q1", "I");
            dg_CarryOver.Columns.Add("Q2", "II");
            dg_CarryOver.Columns.Add("Q3", "III");
            dg_CarryOver.Columns.Add("Q4", "IV");
            dg_CarryOver.Columns.Add("Q5", "V");
            dg_CarryOver.Columns.Add("Q6", "VI");
            dg_CarryOver.Columns.Add("Q7", "VII");
            dg_CarryOver.Columns.Add("Q8", "VIII");
            dg_CarryOver.Columns.Add("Q9", "IX");
            dg_CarryOver.Columns.Add("Q10", "X");
            dg_CarryOver.Columns.Add("Q11", "XI");
            dg_CarryOver.Columns.Add("Q12", "XII");
            dg_CarryOver.Columns.Add("QSum", "Sum:");

            dg_CarryOver.Columns[1].Width = 67;
            dg_CarryOver.Columns[2].Width = 67;
            dg_CarryOver.Columns[3].Width = 67;
            dg_CarryOver.Columns[4].Width = 67;
            dg_CarryOver.Columns[5].Width = 67;
            dg_CarryOver.Columns[6].Width = 67;
            dg_CarryOver.Columns[7].Width = 67;
            dg_CarryOver.Columns[8].Width = 67;
            dg_CarryOver.Columns[9].Width = 67;
            dg_CarryOver.Columns[10].Width = 67;
            dg_CarryOver.Columns[11].Width = 67;
            dg_CarryOver.Columns[12].Width = 67;
            dg_CarryOver.Columns[13].Width = 84;

            dg_CarryOver.Columns.Add("Break1", "");
            dg_CarryOver.Columns[14].Width = 50;

            dg_CarryOver.Columns.Add("S1", "I");
            dg_CarryOver.Columns.Add("S2", "II");
            dg_CarryOver.Columns.Add("S3", "III");
            dg_CarryOver.Columns.Add("S4", "IV");
            dg_CarryOver.Columns.Add("S5", "V");
            dg_CarryOver.Columns.Add("S6", "VI");
            dg_CarryOver.Columns.Add("S7", "VII");
            dg_CarryOver.Columns.Add("S8", "VIII");
            dg_CarryOver.Columns.Add("S9", "IX");
            dg_CarryOver.Columns.Add("S10", "X");
            dg_CarryOver.Columns.Add("S11", "XI");
            dg_CarryOver.Columns.Add("S12", "XII");
            dg_CarryOver.Columns.Add("SSum", "Sum:");

            dg_CarryOver.Columns[15].Width = 67;
            dg_CarryOver.Columns[16].Width = 67;
            dg_CarryOver.Columns[17].Width = 67;
            dg_CarryOver.Columns[18].Width = 67;
            dg_CarryOver.Columns[19].Width = 67;
            dg_CarryOver.Columns[20].Width = 67;
            dg_CarryOver.Columns[21].Width = 67;
            dg_CarryOver.Columns[22].Width = 67;
            dg_CarryOver.Columns[23].Width = 67;
            dg_CarryOver.Columns[24].Width = 67;
            dg_CarryOver.Columns[25].Width = 67;
            dg_CarryOver.Columns[26].Width = 67;
            dg_CarryOver.Columns[27].Width = 84;

            dg_CarryOver.Columns.Add("Break2", "");
            dg_CarryOver.Columns[28].Width = 50;

            dg_CarryOver.Columns.Add("E1", "I");
            dg_CarryOver.Columns.Add("E2", "II");
            dg_CarryOver.Columns.Add("E3", "III");
            dg_CarryOver.Columns.Add("E4", "IV");
            dg_CarryOver.Columns.Add("E5", "V");
            dg_CarryOver.Columns.Add("E6", "VI");
            dg_CarryOver.Columns.Add("E7", "VII");
            dg_CarryOver.Columns.Add("E8", "VIII");
            dg_CarryOver.Columns.Add("E9", "IX");
            dg_CarryOver.Columns.Add("E10", "X");
            dg_CarryOver.Columns.Add("E11", "XI");
            dg_CarryOver.Columns.Add("E12", "XII");
            dg_CarryOver.Columns.Add("ESum", "Sum:");

            dg_CarryOver.Columns[28].Width = 67;
            dg_CarryOver.Columns[29].Width = 67;
            dg_CarryOver.Columns[30].Width = 67;
            dg_CarryOver.Columns[31].Width = 67;
            dg_CarryOver.Columns[32].Width = 67;
            dg_CarryOver.Columns[33].Width = 67;
            dg_CarryOver.Columns[34].Width = 67;
            dg_CarryOver.Columns[35].Width = 67;
            dg_CarryOver.Columns[36].Width = 67;
            dg_CarryOver.Columns[37].Width = 67;
            dg_CarryOver.Columns[38].Width = 67;
            dg_CarryOver.Columns[39].Width = 67;
            dg_CarryOver.Columns[40].Width = 84;

            dg_CarryOver.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dg_CarryOver.ClearSelection();
            dg_CarryOver.Columns[0].Frozen = true;
            gb_ShowAction.Controls.Add(dg_CarryOver);
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
                Text = "Current Year:",
            };
            gb_ShowActionSum.Controls.Add(lab_CurrentActionSum);

            DataGridView dg_SavingSum = new DataGridView
            {
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(5, 30),
                Name = "dg_SavingSum",
                Size = new System.Drawing.Size(1120, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };
            dg_SavingSum.Columns.Add("1", "I");
            dg_SavingSum.Columns.Add("2", "II");
            dg_SavingSum.Columns.Add("3", "III");
            dg_SavingSum.Columns.Add("4", "IV");
            dg_SavingSum.Columns.Add("5", "V");
            dg_SavingSum.Columns.Add("6", "VI");
            dg_SavingSum.Columns.Add("7", "VII");
            dg_SavingSum.Columns.Add("8", "VIII");
            dg_SavingSum.Columns.Add("9", "IX");
            dg_SavingSum.Columns.Add("10", "X");
            dg_SavingSum.Columns.Add("11", "XI");
            dg_SavingSum.Columns.Add("12", "XII");
            dg_SavingSum.Columns.Add("Sum", "Sum:");
            dg_SavingSum.Columns[0].Width = 80;
            dg_SavingSum.Columns[1].Width = 80;
            dg_SavingSum.Columns[2].Width = 80;
            dg_SavingSum.Columns[3].Width = 80;
            dg_SavingSum.Columns[4].Width = 80;
            dg_SavingSum.Columns[5].Width = 80;
            dg_SavingSum.Columns[6].Width = 80;
            dg_SavingSum.Columns[7].Width = 80;
            dg_SavingSum.Columns[8].Width = 80;
            dg_SavingSum.Columns[9].Width = 80;
            dg_SavingSum.Columns[10].Width = 80;
            dg_SavingSum.Columns[11].Width = 80;
            dg_SavingSum.Columns[12].Width = 103;
            dg_SavingSum.Rows.Add(6);
            dg_SavingSum.RowHeadersWidth = 55;
            dg_SavingSum.Rows[0].HeaderCell.Value = "Use:";
            dg_SavingSum.Rows[1].HeaderCell.Value = "EA3:";
            dg_SavingSum.Rows[2].HeaderCell.Value = "EA2:";
            dg_SavingSum.Rows[3].HeaderCell.Value = "EA1:";
            dg_SavingSum.Rows[4].HeaderCell.Value = "BU:";
            dg_SavingSum.Rows[5].HeaderCell.Value = "Diff";
            dg_SavingSum.CurrentCell = dg_SavingSum[0, 0];
            dg_SavingSum.ClearSelection();
            dg_SavingSum.Columns[0].Frozen = true;
            dg_SavingSum.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[5].DefaultCellStyle.Format = "#,0.###";
            dg_SavingSum.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Rows[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_SavingSum.Columns["Sum"].DefaultCellStyle.Font = new Font(dg_SavingSum.Font, FontStyle.Bold);
            dg_SavingSum.Rows[0].DefaultCellStyle.Font = new Font(dg_SavingSum.Font, FontStyle.Bold);
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
                Size = new System.Drawing.Size(1120, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };
            dg_CarryOverSum.Columns.Add("1", "I");
            dg_CarryOverSum.Columns.Add("2", "II");
            dg_CarryOverSum.Columns.Add("3", "III");
            dg_CarryOverSum.Columns.Add("4", "IV");
            dg_CarryOverSum.Columns.Add("5", "V");
            dg_CarryOverSum.Columns.Add("6", "VI");
            dg_CarryOverSum.Columns.Add("7", "VII");
            dg_CarryOverSum.Columns.Add("8", "VIII");
            dg_CarryOverSum.Columns.Add("9", "IX");
            dg_CarryOverSum.Columns.Add("10", "X");
            dg_CarryOverSum.Columns.Add("11", "XI");
            dg_CarryOverSum.Columns.Add("12", "XII");
            dg_CarryOverSum.Columns.Add("Sum", "Sum:");
            dg_CarryOverSum.Columns[0].Width = 80;
            dg_CarryOverSum.Columns[1].Width = 80;
            dg_CarryOverSum.Columns[2].Width = 80;
            dg_CarryOverSum.Columns[3].Width = 80;
            dg_CarryOverSum.Columns[4].Width = 80;
            dg_CarryOverSum.Columns[5].Width = 80;
            dg_CarryOverSum.Columns[6].Width = 80;
            dg_CarryOverSum.Columns[7].Width = 80;
            dg_CarryOverSum.Columns[8].Width = 80;
            dg_CarryOverSum.Columns[9].Width = 80;
            dg_CarryOverSum.Columns[10].Width = 80;
            dg_CarryOverSum.Columns[11].Width = 80;
            dg_CarryOverSum.Columns[12].Width = 103;
            dg_CarryOverSum.Rows.Add(6);
            dg_CarryOverSum.RowHeadersWidth = 55;
            dg_CarryOverSum.Rows[0].HeaderCell.Value = "Use:";
            dg_CarryOverSum.Rows[1].HeaderCell.Value = "EA3:";
            dg_CarryOverSum.Rows[2].HeaderCell.Value = "EA2:";
            dg_CarryOverSum.Rows[3].HeaderCell.Value = "EA1:";
            dg_CarryOverSum.Rows[4].HeaderCell.Value = "BU:";
            dg_CarryOverSum.Rows[5].HeaderCell.Value = "Diff:";
            dg_CarryOverSum.CurrentCell = dg_CarryOverSum[0, 0];
            dg_CarryOverSum.ClearSelection();
            dg_CarryOverSum.Columns[0].Frozen = true;
            dg_CarryOverSum.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[5].DefaultCellStyle.Format = "#,0.###";
            dg_CarryOverSum.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Rows[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_CarryOverSum.Columns["Sum"].DefaultCellStyle.Font = new Font(dg_CarryOverSum.Font, FontStyle.Bold);
            dg_CarryOverSum.Rows[0].DefaultCellStyle.Font = new Font(dg_CarryOverSum.Font, FontStyle.Bold);
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
                Size = new System.Drawing.Size(1120, 155),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            dg_ECCCSum.Columns.Add("1", "I");
            dg_ECCCSum.Columns.Add("2", "II");
            dg_ECCCSum.Columns.Add("3", "III");
            dg_ECCCSum.Columns.Add("4", "IV");
            dg_ECCCSum.Columns.Add("5", "V");
            dg_ECCCSum.Columns.Add("6", "VI");
            dg_ECCCSum.Columns.Add("7", "VII");
            dg_ECCCSum.Columns.Add("8", "VIII");
            dg_ECCCSum.Columns.Add("9", "IX");
            dg_ECCCSum.Columns.Add("10", "X");
            dg_ECCCSum.Columns.Add("11", "XI");
            dg_ECCCSum.Columns.Add("12", "XII");
            dg_ECCCSum.Columns.Add("Sum", "Sum:");
            dg_ECCCSum.Columns[0].Width = 80;
            dg_ECCCSum.Columns[1].Width = 80;
            dg_ECCCSum.Columns[2].Width = 80;
            dg_ECCCSum.Columns[3].Width = 80;
            dg_ECCCSum.Columns[4].Width = 80;
            dg_ECCCSum.Columns[5].Width = 80;
            dg_ECCCSum.Columns[6].Width = 80;
            dg_ECCCSum.Columns[7].Width = 80;
            dg_ECCCSum.Columns[8].Width = 80;
            dg_ECCCSum.Columns[9].Width = 80;
            dg_ECCCSum.Columns[10].Width = 80;
            dg_ECCCSum.Columns[11].Width = 80;
            dg_ECCCSum.Columns[12].Width = 103;
            dg_ECCCSum.Rows.Add(6);
            dg_ECCCSum.RowHeadersWidth = 55;
            dg_ECCCSum.Rows[0].HeaderCell.Value = "Use:";
            dg_ECCCSum.Rows[1].HeaderCell.Value = "EA3:";
            dg_ECCCSum.Rows[2].HeaderCell.Value = "EA2:";
            dg_ECCCSum.Rows[3].HeaderCell.Value = "EA1:";
            dg_ECCCSum.Rows[4].HeaderCell.Value = "BU:";
            dg_ECCCSum.Rows[5].HeaderCell.Value = "Diff:";
            dg_ECCCSum.CurrentCell = dg_ECCCSum[0, 0];
            dg_ECCCSum.ClearSelection();
            dg_ECCCSum.Columns[0].Frozen = true;
            dg_ECCCSum.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[5].DefaultCellStyle.Format = "#,0.###";
            dg_ECCCSum.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Rows[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_ECCCSum.Columns["Sum"].DefaultCellStyle.Font = new Font(dg_ECCCSum.Font, FontStyle.Bold);
            dg_ECCCSum.Rows[0].DefaultCellStyle.Font = new Font(dg_ECCCSum.Font, FontStyle.Bold);
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

        public void PCRaport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PCRaports_Genereted genereted = new PCRaports_Genereted(mainProgram, data_Import);
            genereted.Genereted_PCRaport();
            Cursor.Current = Cursors.Default;
        }
    }
}
