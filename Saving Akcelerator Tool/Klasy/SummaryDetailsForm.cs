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

            //
            GroupBox gb_ShowAction = new GroupBox
            {
                Location = new Point(310, 5),
                Name = "gb_ShowAction",
                Size = new Size(1510, 970),
                TabStop = false,
                Text = "",
            };
            tab_Summary.Controls.Add(gb_ShowAction);

            Label lab_SummNewAction = new Label
            {
                AutoSize = true,
                Location = new Point(10, 20),
                Font = new Font("Microsoft Sans Serif", 15.75F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_SummNewAction",
                Size = new Size(71, 13),
                Text = "Current Acton:",
            };
            gb_ShowAction.Controls.Add(lab_SummNewAction);

            Label lab_SummCarryover = new Label
            {
                AutoSize = true,
                Location = new Point(10, 480),
                Font = new Font("Microsoft Sans Serif", 15.75F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_SummCarryover",
                Size = new Size(71, 13),
                Text = "CarryOver:",
            };
            gb_ShowAction.Controls.Add(lab_SummCarryover);

            //Dodanie Idea lub active Action
            Active_Idea_CheckBox(gb_Show, "1");

            //Generowanie DataGridView dla danych Current year action and Carry over 
            GeneretedCurrentAction_CarryOver_DataGridView();

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
                Size = new Size(1510, 970),
                TabStop = false,
                Text = "",
            };
            tab_Summary.Controls.Add(gb_ShowActionSum);

            //Dodanie Idea lub active Action
            Active_Idea_CheckBox(gb_Show, "2");

            //Generowanie 3 tablic na new action, Carry over i ECCC
            GeneretedSumCurrentAction_CarryOver_DataGridView();

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
                Location = new Point(50, 220),
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

        private void ChartFilters(GroupBox gb_ShowActionSum)
        {
            GroupBox Gb_ChartFilters = new GroupBox
            {
                Location = new Point(5, 860),
                Name = "Gb_ChartFilters",
                Size = new Size(300, 70),
                TabStop = false,
                Text = "Chart Filters:"
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
            if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "PCMenager")
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
    }
}
