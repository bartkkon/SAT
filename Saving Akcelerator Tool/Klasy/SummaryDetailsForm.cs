using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Saving_Accelerator_Tool.Klasy.SummaryDetails.View;

namespace Saving_Accelerator_Tool
{
    class SummaryDetailsForm : SummaryDetailsFormHendler
    {
        MainProgram mainProgram;
        SummaryDetails summaryDetails;
        DataRow Person;

        public SummaryDetailsForm(MainProgram mainProgram, DataRow Person, SummaryDetails summaryDetails, Data_Import data_Import) : base(mainProgram, summaryDetails, Person, data_Import)
        {
            this.mainProgram = mainProgram;
            this.summaryDetails = summaryDetails;
            this.Person = Person;
            Tab_SummaryDetail_Comp();
            Tab_Summary_Comp();
        }

        private void Tab_SummaryDetail_Comp()
        {
            TabPage tab_Summary = (TabPage)mainProgram.TabControl.Controls.Find("tab_Summary", false).First();

            GroupBox gb_Controls = new GroupBox
            {
                Location = new Point(5, 5),
                Name = "gb_Controls",
                Size = new Size(300, 970),
                TabStop = false,
                Text = "",
            };
            tab_Summary.Controls.Add(gb_Controls);

            GroupBox gb_Show = new GroupBox
            {
                Location = new Point(0, 0),
                Name = "gb_Show",
                Size = new Size(300, 790),
                TabStop = false,
                Text = "",
            };
            gb_Controls.Controls.Add(gb_Show);

            CheckBox cb_Level1 = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(40, 40),
                Name = "cb_Level1",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 1",
                UseVisualStyleBackColor = true
            };
            cb_Level1.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level1);

            CheckBox cb_Level2 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(40, 65),
                Name = "cb_Level2",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 2",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            cb_Level2.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level2);

            CheckBox cb_Level3 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(40, 90),
                Name = "cb_Level3",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 3",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            cb_Level3.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level3);

            Label lab_SummDetYear = new Label
            {
                AutoSize = true,
                Location = new Point(140, 20),
                Name = "lab_SummDetYear",
                Size = new Size(71, 13),
                Text = "Year:",
            };
            gb_Show.Controls.Add(lab_SummDetYear);

            NumericUpDown num_SummaryDetailYear = new NumericUpDown
            {
                Location = new Point(140, 40),
                Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0}),
                Name = "num_SummaryDetailYear",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            num_SummaryDetailYear.ValueChanged += new EventHandler(Num_Year_ValueChange);
            gb_Show.Controls.Add(num_SummaryDetailYear);

            Label lab_SummDetLeader = new Label
            {
                AutoSize = true,
                Location = new Point(140, 70),
                Name = "lab_SummDetLeader",
                Size = new Size(71, 13),
                Text = "Leader:",
            };
            gb_Show.Controls.Add(lab_SummDetLeader);

            ComboBox Comb_SummDetLeader = new ComboBox
            {
                Location = new Point(140, 90),
                Name = "Comb_SummDetLeader",
                Size = new Size(140, 20),
            };
            //Hendler dla tego Comboboxa inicjalizowamy w Tab_Summary_comp - w związki z niestworzonym jeszcze elementem z Tab_Summary_Comp
            gb_Show.Controls.Add(Comb_SummDetLeader);
            AddLeadertoComboBox(Comb_SummDetLeader);

            Label lab_SummDetDevision = new Label
            {
                AutoSize = true,
                Location = new Point(140, 120),
                Name = "lab_SummDetDevision",
                Size = new Size(71, 13),
                Text = "Devision:",
            };
            gb_Show.Controls.Add(lab_SummDetDevision);

            ComboBox Comb_SummDetDevision = new ComboBox
            {
                Location = new Point(140, 140),
                Name = "Comb_SummDetDevision",
                Size = new Size(140, 20),
            };
            //Hendler dla tego Comboboxa inicjalizowamy w Tab_Summary_comp - w związki z niestworzonym jeszcze elementem z Tab_Summary_Comp
            //Comb_SummDetDevision.SelectedIndexChanged += new EventHandler(ComboBox_Devision_ChangeIndex);
            gb_Show.Controls.Add(Comb_SummDetDevision);
            AddDevisionToComboBox(Comb_SummDetDevision);

            Button pb_SummDet_Show = new Button
            {
                Location = new Point(110, 180),
                Name = "pb_SummDet_Show",
                Size = new Size(80, 25),
                Text = "Show",
                UseVisualStyleBackColor = true,
            };
            pb_SummDet_Show.Click += new EventHandler(pb_SummDet_Show_Click);
            gb_Show.Controls.Add(pb_SummDet_Show);

            //Dodanie Idea lub active Action
            Active_Idea_CheckBox(gb_Show, "1");

            //Dodanie Pozytywne i Negatywne 
            Positive_Negative_ChecBox(gb_Show, "1");

            //Generowanie nowych SummaryDetails
            _ = new SDTableView(tab_Summary);

            //Generowanie GrupBoxa dla zatwierdzania akcji Dla menagerów.
            ReportingForm(gb_Controls);

            //Przycisk do generowania raportu PC
            PC_Raport(gb_Show);

        }

        

        private void Tab_Summary_Comp()
        {
            TabPage tab_Summary = (TabPage)mainProgram.TabControl.Controls.Find("tab_SummaryS", true).First();

            GroupBox gb_Controls = new GroupBox
            {
                Location = new Point(5, 5),
                Name = "gb_ControlsSum",
                Size = new Size(300, 970),
                TabStop = false,
                Text = "",
            };
            tab_Summary.Controls.Add(gb_Controls);

            GroupBox gb_Show = new GroupBox
            {
                Location = new Point(0, 0),
                Name = "gb_ShowSum",
                Size = new Size(300, 790),
                TabStop = false,
                Text = "",
            };
            gb_Controls.Controls.Add(gb_Show);

            CheckBox cb_Level1 = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(40, 40),
                Name = "cb_Level1Sum",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 1",
                UseVisualStyleBackColor = true
            };
            cb_Level1.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level1);

            CheckBox cb_Level2 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(40, 65),
                Name = "cb_Level2Sum",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 2",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            cb_Level2.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level2);

            CheckBox cb_Level3 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(40, 90),
                Name = "cb_Level3Sum",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Level 3",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            cb_Level3.CheckedChanged += cb_LevelChange_CheckedChanged;
            gb_Show.Controls.Add(cb_Level3);

            Label lab_SummDetYear = new Label
            {
                AutoSize = true,
                Location = new Point(140, 20),
                Name = "lab_SummDetYearSum",
                Size = new Size(71, 13),
                Text = "Year:",
            };
            gb_Show.Controls.Add(lab_SummDetYear);

            NumericUpDown num_SummaryDetailYear = new NumericUpDown
            {
                Location = new Point(140, 40),
                Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0}),
                Name = "num_SummaryDetailYearSum",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            num_SummaryDetailYear.ValueChanged += new EventHandler(Num_Year_ValueChange);
            gb_Show.Controls.Add(num_SummaryDetailYear);

            Label lab_SummDetLeader = new Label
            {
                AutoSize = true,
                Location = new Point(140, 70),
                Name = "lab_SummDetLeader",
                Size = new Size(71, 13),
                Text = "Leader:",
            };
            gb_Show.Controls.Add(lab_SummDetLeader);

            ComboBox Comb_SummLeader = new ComboBox
            {
                Location = new Point(140, 90),
                Name = "Comb_SummLeader",
                Size = new Size(140, 20),
            };
            Comb_SummLeader.SelectedIndexChanged += new EventHandler(ComboBox_Leader_ChangeIndex);
            gb_Show.Controls.Add(Comb_SummLeader);
            AddLeadertoComboBox(Comb_SummLeader);
            ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetLeader", true).First()).SelectedIndexChanged += new EventHandler(ComboBox_Leader_ChangeIndex);


            Label lab_SummDetDevision = new Label
            {
                AutoSize = true,
                Location = new Point(140, 120),
                Name = "lab_SummDetDevision",
                Size = new Size(71, 13),
                Text = "Devision:",
            };
            gb_Show.Controls.Add(lab_SummDetDevision);

            ComboBox Comb_SummDevision = new ComboBox
            {
                Location = new Point(140, 140),
                Name = "Comb_SummDevision",
                Size = new Size(140, 20),
            };
            Comb_SummDevision.SelectedIndexChanged += new EventHandler(ComboBox_Devision_ChangeIndex);
            gb_Show.Controls.Add(Comb_SummDevision);
            AddDevisionToComboBox(Comb_SummDevision);
            //Dodanie Hendlera do opodobnego Elementy z Tab_SummaryDet_Comp
            ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_SummDetDevision", true).First()).SelectedIndexChanged += new EventHandler(ComboBox_Devision_ChangeIndex);

            Button pb_SummDet_Show = new Button
            {
                Location = new Point(110, 180),
                Name = "pb_SummDet_ShowSum",
                Size = new Size(80, 25),
                Text = "Show",
                UseVisualStyleBackColor = true,
            };
            pb_SummDet_Show.Click += new System.EventHandler(pb_SummDet_Show_Click);
            gb_Show.Controls.Add(pb_SummDet_Show);

            GroupBox gb_ShowActionSum = new GroupBox
            {
                Location = new Point(310, 5),
                Name = "gb_ShowActionSum",
                Size = new Size(1600, 970),
                TabStop = false,
                Text = "",
            };
            tab_Summary.Controls.Add(gb_ShowActionSum);

            //Dodanie Idea lub active Action
            Active_Idea_CheckBox(gb_Show, "2");

            //Dodanie Pozytywne i Negatywne 
            Positive_Negative_ChecBox(gb_Show, "2");

            //Generowanie 3 tablic na new action, Carry over i ECCC
            GeneretedSumCurrentAction_CarryOver_DataGridView();

            //Generowanie tablic dla podsumowania poszczególnych grup
            Plan_Grid(gb_ShowActionSum, 30, "Actual");
            Plan_Grid(gb_ShowActionSum, 205, "CarryOver");
            Plan_Grid(gb_ShowActionSum, 380, "ECCC");

            //Generowanie Tablicy dla podsumowania całości
            SumPlanGrid(gb_ShowActionSum);

            //Generowanie GrupBoxa dla zatwierdzania akcji Dla menagerów.
            ReportingForm(gb_Controls);

            //Dodanie elementów filtra dla Wykresów
            ChartFilters(gb_ShowActionSum);

            //Przycisk do generowania raportu PC
            PC_Raport(gb_Show);
        }

        private void ReportingForm(GroupBox gb_Controls)
        {
            if (Person["EleApprove"].ToString() == "true" || Person["MechApprove"].ToString() == "true" || Person["NVRApprove"].ToString() == "true" || Person["PCApprove"].ToString() == "true")
            {
                GroupBox gb_Approve = new GroupBox
                {
                    Location = new Point(0, 790),
                    Name = "gb_Approve",
                    Size = new Size(300, 180),
                    TabStop = false,
                    Text = "Reporting:",
                };
                gb_Controls.Controls.Add(gb_Approve);

                Button Pb_SummDet_ReportingRefresh = new Button
                {
                    Location = new Point(280, 5),
                    Name = "Pb_SummDep_ReportingRefresh",
                    Size = new Size(20, 20),
                    Text = "R",
                };
                Pb_SummDet_ReportingRefresh.Click += new EventHandler(Pb_SummDet_ReportingRefresh_Click);
                gb_Approve.Controls.Add(Pb_SummDet_ReportingRefresh);

                if (Person["EleApprove"].ToString() == "true")
                {
                    Button pb_SummDet_EleApp = new Button
                    {
                        Location = new Point(20, 15),
                        Name = "pb_SummDet_EleApprove",
                        Size = new Size(120, 40),
                        Text = "Electronic Approve",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_EleApp.Click += new System.EventHandler(pb_SummDet_Approve_Click);
                    gb_Approve.Controls.Add(pb_SummDet_EleApp);
                    summaryDetails.SummaryDetails_CheckifCanReporting("Electronic", "false");
                }

                if (Person["MechApprove"].ToString() == "true")
                {
                    Button pb_SummDet_MechApp = new Button
                    {
                        Location = new Point(20, 55),
                        Name = "pb_SummDet_MechApprove",
                        Size = new Size(120, 40),
                        Text = "Mechanic Approve",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_MechApp.Click += new System.EventHandler(pb_SummDet_Approve_Click);
                    gb_Approve.Controls.Add(pb_SummDet_MechApp);
                    summaryDetails.SummaryDetails_CheckifCanReporting("Mechanic", "false");
                }

                if (Person["NVRApprove"].ToString() == "true")
                {
                    Button pb_SummDet_NVRApp = new Button
                    {
                        Location = new Point(20, 95),
                        Name = "pb_SummDet_NVRApprove",
                        Size = new Size(120, 40),
                        Text = "NVR Approve",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_NVRApp.Click += new System.EventHandler(pb_SummDet_Approve_Click);
                    gb_Approve.Controls.Add(pb_SummDet_NVRApp);
                    summaryDetails.SummaryDetails_CheckifCanReporting("NVR", "false");
                }

                if (Person["PCApprove"].ToString() == "true")
                {
                    Button pb_SummDet_PCApp = new Button
                    {
                        Location = new Point(20, 135),
                        Name = "pb_SummDet_PCApprove",
                        Size = new Size(250, 40),
                        Text = "Product Care Approve",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_PCApp.Click += new System.EventHandler(pb_SummDet_Approve_Click);
                    gb_Approve.Controls.Add(pb_SummDet_PCApp);

                    Button pb_SummDet_EleRej = new Button
                    {
                        Location = new Point(150, 15),
                        Name = "pb_SummDet_EleRejected",
                        Size = new Size(120, 40),
                        Text = "Electronic Rejected",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_EleRej.Click += new System.EventHandler(pb_SummDet_Rejected_Click);
                    gb_Approve.Controls.Add(pb_SummDet_EleRej);

                    Button pb_SummDet_MechRej = new Button
                    {
                        Location = new Point(150, 55),
                        Name = "pb_SummDet_MechRejected",
                        Size = new Size(120, 40),
                        Text = "Mechanic Rejected",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_MechRej.Click += new System.EventHandler(pb_SummDet_Rejected_Click);
                    gb_Approve.Controls.Add(pb_SummDet_MechRej);

                    Button pb_SummDet_NVRRej = new Button
                    {
                        Location = new Point(150, 95),
                        Name = "pb_SummDet_NVRRejected",
                        Size = new Size(120, 40),
                        Text = "NVR Rejected",
                        UseVisualStyleBackColor = true,
                        Enabled = false,
                    };
                    pb_SummDet_NVRRej.Click += new System.EventHandler(pb_SummDet_Rejected_Click);
                    gb_Approve.Controls.Add(pb_SummDet_NVRRej);
                    summaryDetails.SummaryDetails_CheckifCanReporting("PC", "false");
                }
            }
        }

        private void Active_Idea_CheckBox(GroupBox gb_Show, string counter)
        {
            CheckBox Active = new CheckBox
            {
                Location = new Point(30, 220),
                Size = new Size(100, 20),
                AutoSize = true,
                Name = "CB_Active" + counter,
                Text = "Active Action",
                Checked = true,
            };
            Active.CheckedChanged += new EventHandler(Active_CheckedChange);
            gb_Show.Controls.Add(Active);

            CheckBox Idea = new CheckBox
            {
                Location = new Point(140, 220),
                Size = new Size(100, 20),
                AutoSize = true,
                Name = "CB_Idea" + counter,
                Text = "Idea Action",
                Checked = false,
            };
            Idea.CheckedChanged += new EventHandler(Idea_CheckedChange);
            gb_Show.Controls.Add(Idea);
        }

        private void Positive_Negative_ChecBox(GroupBox gb_Show, string counter)
        {
            CheckBox Positive = new CheckBox
            {
                Location = new Point(30, 250),
                Size = new Size(100, 20),
                AutoSize = true,
                Name = "CB_Positive" + counter,
                Text = "Positive Action",
                Checked = true,
            };
            Positive.CheckedChanged += new EventHandler(Positive_CheckedChange);
            gb_Show.Controls.Add(Positive);

            CheckBox Negative = new CheckBox
            {
                Location = new Point(140, 250),
                Size = new Size(100, 20),
                AutoSize = true,
                Name = "CB_Negative" + counter,
                Text = "Negative Action",
                Checked = true,
            };
            Negative.CheckedChanged += new EventHandler(Negative_CheckedChange);
            gb_Show.Controls.Add(Negative);
        }

        private void ChartFilters(GroupBox gb_ShowActionSum)
        {
            GroupBox Gb_ChartFilters = new GroupBox
            {
                Location = new Point(5, 860),
                Name = "Gb_ChartFilters",
                Size = new Size(300, 70),
                TabStop = false,
                Text = "Chart Filters:",
                Enabled = false,
            };
            gb_ShowActionSum.Controls.Add(Gb_ChartFilters);

            CheckBox Cb_ChartFilters_USE = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_USE",
                Text = "USE",
            };
            Cb_ChartFilters_USE.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_USE);

            CheckBox Cb_ChartFilters_EA3 = new CheckBox
            {
                Location = new Point(60, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_EA3",
                Text = "EA3",
            };
            Cb_ChartFilters_EA3.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_EA3);

            CheckBox Cb_ChartFilters_EA2 = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_EA2",
                Text = "EA2",
            };
            Cb_ChartFilters_EA2.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_EA2);

            CheckBox Cb_ChartFilters_EA1 = new CheckBox
            {
                Location = new Point(160, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_EA1",
                Text = "EA1",
            };
            Cb_ChartFilters_EA1.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_EA1);

            CheckBox Cb_ChartFilters_BU = new CheckBox
            {
                Location = new Point(210, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_BU",
                Text = "BU",
            };
            Cb_ChartFilters_BU.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_BU);

            CheckBox Cb_ChartFilters_CurrentAction = new CheckBox
            {
                Location = new Point(10, 50),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_CurrentAction",
                Text = "Current Action",
            };
            Cb_ChartFilters_CurrentAction.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_CurrentAction);

            CheckBox Cb_ChartFilters_CarryOver = new CheckBox
            {
                Location = new Point(110, 50),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_CarryOver",
                Text = "Carry Over",
            };
            Cb_ChartFilters_CarryOver.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_CarryOver);

            CheckBox Cb_ChartFilters_ECCC = new CheckBox
            {
                Location = new Point(210, 50),
                Size = new Size(10, 10),
                AutoSize = true,
                Checked = true,
                Name = "Cb_ChartFilters_ECCC",
                Text = "ECCC",
            };
            Cb_ChartFilters_ECCC.CheckedChanged += Cb_ChartFilter_CheckedChanged;
            Gb_ChartFilters.Controls.Add(Cb_ChartFilters_ECCC);
        }

        private void AddLeadertoComboBox(ComboBox Comb_SummDetLeader)
        {
            ComboBox ActionLeader = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_FilterBy", true).First();

            Comb_SummDetLeader.Items.AddRange(ActionLeader.Items.Cast<Object>().ToArray());
            Comb_SummDetLeader.SelectedIndex = 0;
        }

        private void AddDevisionToComboBox(ComboBox Comb_SummDetDevision)
        {
            if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "PCMenager")
            {
                Comb_SummDetDevision.Items.Add("All");
                Comb_SummDetDevision.Items.Add("Electronic");
                Comb_SummDetDevision.Items.Add("Mechanic");
                Comb_SummDetDevision.Items.Add("NVR");
                Comb_SummDetDevision.SelectedIndex = 0;
            }
            else if (Person["Role"].ToString() == "EleMenager")
            {
                Comb_SummDetDevision.Items.Add("Electronic");
                Comb_SummDetDevision.SelectedIndex = 0;
            }
            else if (Person["Role"].ToString() == "MechMenager")
            {
                Comb_SummDetDevision.Items.Add("Mechanic");
                Comb_SummDetDevision.SelectedIndex = 0;
            }
            else if (Person["Role"].ToString() == "NVRMenager")
            {
                Comb_SummDetDevision.Items.Add("NVR");
                Comb_SummDetDevision.SelectedIndex = 0;
            }
        }

        private void PC_Raport(GroupBox gb_Show)
        {
            if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "PCMenager" || Person["Role"].ToString() == "EleMenager" || Person["Role"].ToString() == "MechMenager" || Person["Role"].ToString() == "NVRMenager")
            {
                Button PCRaport = new Button
                {
                    Location = new Point(130, 750),
                    Name = "pb_PCRaport",
                    Size = new Size(160, 30),
                    Text = "Genereted PC Raport",
                    UseVisualStyleBackColor = true,
                };
                PCRaport.Click += new EventHandler(PCRaport_Click);
                gb_Show.Controls.Add(PCRaport);
            }
        }

        private void Plan_Grid(GroupBox gb_ShowActionSum, int Start_position, string Group)
        {
            DataGridView dg_SavingSum = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(1200, Start_position),
                Name = "dg_SavingSum" + Group,
                Size = new Size(330, 133),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };
            gb_ShowActionSum.Controls.Add(dg_SavingSum);

            dg_SavingSum.Columns.Add("Percent", "Execution of plan [%]");
            dg_SavingSum.Columns.Add("PercentDM", "Delivery DM [%]");
            dg_SavingSum.Columns[0].Width = 140;
            dg_SavingSum.Columns[1].Width = 120;
            dg_SavingSum.Rows.Add(5);
            dg_SavingSum.RowHeadersWidth = 68;
            dg_SavingSum.Rows[0].HeaderCell.Value = "Actual:";
            dg_SavingSum.Rows[1].HeaderCell.Value = "EA3:";
            dg_SavingSum.Rows[2].HeaderCell.Value = "EA2:";
            dg_SavingSum.Rows[3].HeaderCell.Value = "EA1:";
            dg_SavingSum.Rows[4].HeaderCell.Value = "BU:";
            dg_SavingSum.CurrentCell = dg_SavingSum[0, 0];
            dg_SavingSum.ClearSelection();
            dg_SavingSum.Rows[0].DefaultCellStyle.Format = "#,0.####";
            dg_SavingSum.Rows[1].DefaultCellStyle.Format = "#,0.####";
            dg_SavingSum.Rows[2].DefaultCellStyle.Format = "#,0.####";
            dg_SavingSum.Rows[3].DefaultCellStyle.Format = "#,0.####";
            dg_SavingSum.Rows[4].DefaultCellStyle.Format = "#,0.####";
            dg_SavingSum.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_SavingSum.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_SavingSum.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_SavingSum.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_SavingSum.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_SavingSum.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            dg_SavingSum.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            dg_SavingSum.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            dg_SavingSum.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
        }

        private void SumPlanGrid(GroupBox gb_ShowActionSum)
        {
            DataGridView DGV_SumPlan = new DataGridView()
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(700, 550),
                Name = "DVG_SumPlan",
                Size = new Size(771, 146),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };
            gb_ShowActionSum.Controls.Add(DGV_SumPlan);

            DGV_SumPlan.Columns.Add("Sum", "Sum [PLN]");
            DGV_SumPlan.Columns.Add("Plan", "Execution of plan [%]");
            DGV_SumPlan.Columns.Add("DM", "DM [%]");
            DGV_SumPlan.Columns.Add("Target DM", "Target DM [PLN]");
            DGV_SumPlan.Columns.Add("Target DMP", "Target DM [%]");
            DGV_SumPlan.Columns.Add("Delta", "Delta [PLN]");
            DGV_SumPlan.Columns.Add("DeltaP", "Delta [%]");
            DGV_SumPlan.Columns[0].Width = 100;
            DGV_SumPlan.Columns[1].Width = 100;
            DGV_SumPlan.Columns[2].Width = 100;
            DGV_SumPlan.Columns[3].Width = 100;
            DGV_SumPlan.Columns[4].Width = 100;
            DGV_SumPlan.Columns[5].Width = 100;
            DGV_SumPlan.Columns[6].Width = 100;
            DGV_SumPlan.Rows.Add(5);
            DGV_SumPlan.RowHeadersWidth = 68;
            DGV_SumPlan.Rows[0].HeaderCell.Value = "Actual:";
            DGV_SumPlan.Rows[1].HeaderCell.Value = "EA3:";
            DGV_SumPlan.Rows[2].HeaderCell.Value = "EA2:";
            DGV_SumPlan.Rows[3].HeaderCell.Value = "EA1:";
            DGV_SumPlan.Rows[4].HeaderCell.Value = "BU:";
            DGV_SumPlan.CurrentCell = DGV_SumPlan[0, 0];
            DGV_SumPlan.ClearSelection();
            DGV_SumPlan.Rows[0].DefaultCellStyle.Format = "#,0.####";
            DGV_SumPlan.Rows[1].DefaultCellStyle.Format = "#,0.####";
            DGV_SumPlan.Rows[2].DefaultCellStyle.Format = "#,0.####";
            DGV_SumPlan.Rows[3].DefaultCellStyle.Format = "#,0.####";
            DGV_SumPlan.Rows[4].DefaultCellStyle.Format = "#,0.####";
            DGV_SumPlan.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_SumPlan.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_SumPlan.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_SumPlan.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_SumPlan.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_SumPlan.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            DGV_SumPlan.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            DGV_SumPlan.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            DGV_SumPlan.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
        }
    }
}
