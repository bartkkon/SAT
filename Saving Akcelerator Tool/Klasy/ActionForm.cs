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
    class ActionForm : ActionFormHendler
    {
        MainProgram mainProgram;
        Action action;
        Admin admin;
        DataRow Person;
        SummaryDetails summaryDetails;
        Data_Import ImportData;

        public ActionForm(MainProgram mainProgram, Action action, SummaryDetails summaryDetails, Admin admin, Data_Import ImportData, DataRow Person) : base(mainProgram, action, summaryDetails, admin, ImportData, Person)
        {
            this.mainProgram = mainProgram;
            this.action = action;
            this.summaryDetails = summaryDetails;
            this.admin = admin;
            this.ImportData = ImportData;
            this.Person = Person;

            Tab_Action_Comp();
        }

        private void Tab_Action_Comp()
        {
            TabPage ntab_Action = (TabPage)mainProgram.TabControl.Controls.Find("tab_Action", false).First();

            //Panels 
            //Panel Left na drzewo akcji i opcje akcji
            Panel panelLeftAll = new Panel
            {
                Dock = DockStyle.Left,
                Location = new Point(0, 0),
                Name = "panelLeftAll",
                Size = new Size(307, 877),
                TabIndex = 0
            };
            ntab_Action.Controls.Add(panelLeftAll);

            //Panel Left opcje na górze
            Panel panelLeftOption = new Panel
            {
                Dock = DockStyle.Top,
                Location = new Point(0, 0),
                Name = "panellLeftOption",
                Size = new Size(307, 172),
                TabIndex = 0
            };
            panelLeftAll.Controls.Add(panelLeftOption);

            //Panel Left Tree
            Panel panelLeftTree = new Panel
            {
                //panelLeftTree.Dock = DockStyle.Fill;
                Location = new Point(0, 180),
                Name = "panelLeftTree",
                Size = new Size(307, 785),
                TabIndex = 1
            };
            panelLeftAll.Controls.Add(panelLeftTree);

            Panel panelAction = new Panel
            {
                //panelAction.Dock = DockStyle.Fill;
                Location = new Point(315, 0),
                Name = "panelAction",
                Size = new Size(1593, 970),
                TabIndex = 1
            };
            ntab_Action.Controls.Add(panelAction);

            //Opcje do wyboru ackcji - komponenty do tego
            Action_Group_MainFilter(panelLeftOption);

            if (Person["Action"].ToString() == "Developer")
            {
                Button Action_NewAction = new Button
                {
                    Location = new Point(193, 10),
                    Name = "but_Action_NewAction",
                    Size = new Size(103, 28),
                    TabIndex = 4,
                    Text = "New Action",
                    UseVisualStyleBackColor = true
                };
                Action_NewAction.Click += new EventHandler(but_Action_NewAction_Click);
                panelLeftOption.Controls.Add(Action_NewAction);
            }

            Action_Group_Tree(panelLeftTree);

            GroupBox Action_groupBox = new GroupBox
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "gb_ActiveAction",
                Size = new Size(1511, 970),
                TabIndex = 0,
                TabStop = false,
                Text = "",
                Enabled = false,
            };
            panelAction.Controls.Add(Action_groupBox);

            action.Action_AddList(Person);

            //ładowanie form na akcje 
            Load_ActionForm(Action_groupBox, mainProgram, Person);


        }

        private void Action_Group_MainFilter(Panel panelLeftOption)
        {
            CheckBox Action_Active = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(11, 13),
                Name = "cb_ActionActive",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Active Action",
                UseVisualStyleBackColor = true
            };
            Action_Active.CheckedChanged += new EventHandler(Active_Idea_CheckedChange);
            panelLeftOption.Controls.Add(Action_Active);

            CheckBox Action_Completed = new CheckBox
            {
                AutoSize = true,
                Location = new Point(11, 36),
                Name = "cb_ActionCompleted",
                Size = new Size(80, 17),
                TabIndex = 1,
                Text = "Completed Action",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            panelLeftOption.Controls.Add(Action_Completed);

            CheckBox Action_Draft = new CheckBox
            {
                AutoSize = true,
                Location = new Point(11, 59),
                Name = "cb_ActionDraft",
                Size = new Size(80, 17),
                TabIndex = 2,
                Text = "Draft Action",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            panelLeftOption.Controls.Add(Action_Draft);

            CheckBox Action_Idea = new CheckBox
            {
                AutoSize = true,
                Location = new Point(11, 82),
                Name = "cb_ActionIdea",
                Size = new Size(80, 17),
                TabIndex = 2,
                Text = "Idea Action",
                UseVisualStyleBackColor = true,
                Enabled = true,
            };
            Action_Idea.CheckedChanged += new EventHandler(Active_Idea_CheckedChange);
            panelLeftOption.Controls.Add(Action_Idea);

            NumericUpDown Action_YearOption = new NumericUpDown
            {
                Location = new Point(35, 150),
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
                Name = "num_Action_YearOption",
                Size = new Size(55, 20),
                TabIndex = 3,
                Value = DateTime.Today.Year
            };
            panelLeftOption.Controls.Add(Action_YearOption);

            Label Action_Label1 = new Label
            {
                AutoSize = true,
                Location = new Point(0, 153),
                Name = "lab_YearOption",
                Size = new Size(35, 13),
                TabIndex = 5,
                Text = "Year:"
            };
            panelLeftOption.Controls.Add(Action_Label1);

            Label Action_Label_FilterBy = new Label
            {
                AutoSize = true,
                Location = new Point(115, 153),
                Name = "Action_Label_FilterBy",
                Size = new Size(35, 13),
                TabIndex = 5,
                Text = "Leader:"
            };
            panelLeftOption.Controls.Add(Action_Label_FilterBy);

            ComboBox combox_FilterBy = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(165, 150),
                Name = "comBox_FilterBy",
                Size = new Size(140, 21),
            };
            panelLeftOption.Controls.Add(combox_FilterBy);
            Add_People_To_Combobox(combox_FilterBy, true);

        }

        private void Action_Group_Tree(Panel panelLeftTree)
        {
            // Odświerzanie Drzewa akcji
            Button button_Refresh = new Button
            {
                Location = new Point(250, 5),
                Name = "but_TreeRefresh",
                Size = new Size(52, 22),
                TabIndex = 1,
                Text = "Refresh",
                UseVisualStyleBackColor = true
            };
            button_Refresh.Click += new EventHandler(but_TreeRefresh_Click);
            panelLeftTree.Controls.Add(button_Refresh);

            //Drzewo Akcji 
            TreeView treeView_Action = new TreeView
            {
                //treeView_Action.Dock = DockStyle.Fill;
                Location = new Point(0, 0),
                Name = "tree_Action",
                Size = new Size(307, 785),
                TabIndex = 0,
                HideSelection = false,
            };
            treeView_Action.AfterSelect += new TreeViewEventHandler(tree_Action_AfterSelect);
            panelLeftTree.Controls.Add(treeView_Action);
        }

        private void Load_ActionForm(GroupBox Action_GroupBox, MainProgram mainProgram, DataRow Person)
        {
            //Nazwa akcji / Description / Przyciski Zapisywania akcji plus Draft 
            Action_Group_Name_Change(Action_GroupBox);

            //Group Box dla zmiany ANC plus wszystko co jest z tym związane
            Action_Group_ANCChange_Change(Action_GroupBox);

            //Group Box dla zmiany STK plus wszystko co jest z tym związane
            Action_Group_STK_Change(Action_GroupBox);

            //GrupBox dla Calc
            Action_Group_Calculation_Change(Action_GroupBox);

            //Group Box dla pokazania PNC do użytku w wyliczeniach 
            Action_Group_PNC_PNCSpec_Change(Action_GroupBox);

            //GroupBox dla mozlwiości zaznaczenia czy liczyć Mass czy nie 
            Action_Mass_Calculation(Action_GroupBox);

            //Group Box dla Calculation by: - ACN/PNC/PNCSpec
            Action_Group_CalcBy_Change(Action_GroupBox);

            //GroupBox dla informacji kiedy ma byc akcja zwolniona, plus jaki jest status akcji - Active czy Draft
            Action_Group_State_Change(Action_GroupBox);

            //GroupBox dla liczenia oszczędności na danej akcji 
            Action_Group_CalcFinal_Change(Action_GroupBox);

            //GroupBox dla ECCC
            Action_Group_ECCC_Change(Action_GroupBox);

            //GrupBox dla Estymacji dla PNC Spec - Dla ANC i PNC jest ukryte
            Action_Group_PNCEstyma_Change(Action_GroupBox);

            //Dodanie obiektów dla ANC calc by -  liczenie go grupie ANC z ilościamy z wybranego
            Action_Group_ANCBy_change(Action_GroupBox);

            //Dodanie obiektór dla wybrania platformy na jakich jest używana akcja 
            Action_Group_Platform_Change(Action_GroupBox);

            //Dodanie obiektów dla wybrania Instalacji w jakich jest wykonywana akcja
            Action_Group_Installation_Change(Action_GroupBox);

            //Dodawanie obiektów do obliczania ANC change
            action.Action_AddANC();

            //ładowanie specjalnych przycisków
            Load_SpecialButton(Action_GroupBox);


        }

        private void Action_Group_Installation_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_Installation = new GroupBox
            {
                Location = new Point(790, 65),
                Name = "gb_Instalation",
                Size = new Size(175, 60),
                TabStop = false,
                Text = "Installation:",
            };
            Action_GroupBox.Controls.Add(gb_Installation);

            CheckBox cb_InstallAll = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 15),
                Name = "cb_InstallAll",
                Size = new Size(80, 17),
                Text = "All",
                UseVisualStyleBackColor = true
            };
            cb_InstallAll.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_InstallAll);

            CheckBox cb_FI = new CheckBox
            {
                AutoSize = true,
                Location = new Point(70, 15),
                Name = "cb_FI",
                Size = new Size(80, 17),
                Text = "FI",
                UseVisualStyleBackColor = true
            };
            cb_FI.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_FI);

            CheckBox cb_FS = new CheckBox
            {
                AutoSize = true,
                Location = new Point(120, 15),
                Name = "cb_FS",
                Size = new Size(80, 17),
                Text = "FS",
                UseVisualStyleBackColor = true
            };
            cb_FS.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_FS);

            CheckBox cb_BI = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 35),
                Name = "cb_BI",
                Size = new Size(80, 17),
                Text = "BI",
                UseVisualStyleBackColor = true
            };
            cb_BI.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_BI);

            CheckBox cb_BU = new CheckBox
            {
                AutoSize = true,
                Location = new Point(70, 35),
                Name = "cb_BU",
                Size = new Size(80, 17),
                Text = "BU",
                UseVisualStyleBackColor = true
            };
            cb_BU.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_BU);

            CheckBox cb_FSBU = new CheckBox
            {
                AutoSize = true,
                Location = new Point(120, 35),
                Name = "cb_FSBU",
                Size = new Size(80, 17),
                Text = "FSBU",
                UseVisualStyleBackColor = true
            };
            cb_FSBU.CheckedChanged += cb_Installation_CheckedChanged;
            gb_Installation.Controls.Add(cb_FSBU);
        }

        private void Action_Group_Platform_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_Platform = new GroupBox
            {
                Location = new Point(790, 10),
                Name = "gb_Platform",
                Size = new Size(175, 55),
                TabStop = false,
                Text = "Platform:",
            };
            Action_GroupBox.Controls.Add(gb_Platform);

            CheckBox cb_DMD = new CheckBox
            {
                AutoSize = true,
                Location = new Point(35, 25),
                Name = "cb_DMD",
                Size = new Size(80, 17),
                Text = "DMD",
                UseVisualStyleBackColor = true
            };
            cb_DMD.CheckedChanged += new EventHandler(cb_Platform_CheckedChanged);
            gb_Platform.Controls.Add(cb_DMD);

            CheckBox cb_D45 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(100, 25),
                Name = "cb_D45",
                Size = new Size(80, 17),
                Text = "D45",
                UseVisualStyleBackColor = true
            };
            gb_Platform.Controls.Add(cb_D45);
        }

        private void Action_Group_ANCBy_change(GroupBox Action_GroupBox)
        {
            GroupBox gb_ANCby = new GroupBox
            {
                Location = new Point(970, 130),
                Name = "gb_ANCby",
                Size = new Size(80, 350),
                TabStop = false,
                Text = "ANC by:",
                Visible = false,
            };
            Action_GroupBox.Controls.Add(gb_ANCby);

        }

        private void Action_Group_Name_Change(GroupBox Action_GroupBox)
        {
            Label lab_NameAction = new Label
            {
                AutoSize = true,
                Location = new Point(10, 20),
                Name = "lab_Name",
                Size = new Size(71, 13),
                Text = "Action Name:"
            };
            Action_GroupBox.Controls.Add(lab_NameAction);

            Label lab_Description = new Label
            {
                AutoSize = true,
                Location = new Point(10, 45),
                Name = "lab_Description",
                Size = new Size(71, 13),
                Text = "Description:"
            };
            Action_GroupBox.Controls.Add(lab_Description);

            TextBox tb_Name = new TextBox
            {
                Location = new Point(90, 20),
                Name = "tb_Name",
                Size = new Size(310, 20),
                TabIndex = 1,
            };
            tb_Name.TextChanged += new EventHandler(Name_TextChange);
            tb_Name.Leave += new EventHandler(Name_Leave);
            Action_GroupBox.Controls.Add(tb_Name);

            TextBox tb_Description = new TextBox
            {
                Location = new Point(90, 45),
                Name = "tb_Description",
                Multiline = true,
                Size = new Size(310, 60),
                TabIndex = 2,
                MaxLength = 1000,
            };
            tb_Description.TextChanged += new EventHandler(Description_TextChange);
            Action_GroupBox.Controls.Add(tb_Description);

            Label Lab_MaxLength = new Label
            {
                Location = new Point(343, 105),
                Name = "Lab_MaxLength",
                Size = new Size(10, 10),
                AutoSize = true,
                Text = "0/1000",
            };
            Action_GroupBox.Controls.Add(Lab_MaxLength);

            Button pb_Save = new Button
            {
                Location = new Point(1480, 20),
                Name = "pb_Save",
                Size = new Size(100, 40),
                Text = "Save",
                UseVisualStyleBackColor = true,
            };
            pb_Save.Click += new System.EventHandler(pb_Save_Click);
            Action_GroupBox.Controls.Add(pb_Save);

            Button pb_SaveDraft = new Button
            {
                Location = new Point(1480, 70),
                Name = "pb_SaveDraft",
                Size = new Size(100, 40),
                Text = "Save as Draft",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            pb_SaveDraft.Click += new System.EventHandler(pb_SaveDraft_Click);
            Action_GroupBox.Controls.Add(pb_SaveDraft);
        }

        private void Action_Group_ANCChange_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_ANC = new GroupBox
            {
                Location = new Point(15, 130),
                Name = "gb_ANC",
                Size = new Size(270, 350),
                TabStop = false,
                Text = "ANC change:",
            };
            Action_GroupBox.Controls.Add(gb_ANC);

            Button pb_Plus = new Button
            {
                Location = new Point(200, 10),
                Name = "pb_Plus",
                Size = new Size(30, 30),
                Text = "+",
                UseVisualStyleBackColor = true,
            };
            pb_Plus.Click += new System.EventHandler(pb_Plus_Click);
            gb_ANC.Controls.Add(pb_Plus);

            Button pb_Minus = new Button
            {
                Location = new Point(235, 10),
                Name = "pb_Minus",
                Size = new Size(30, 30),
                Text = "-",
                UseVisualStyleBackColor = true,
            };
            pb_Minus.Click += new System.EventHandler(pb_Minus_Click);
            gb_ANC.Controls.Add(pb_Minus);

            Label lab_OLDANC = new Label
            {
                AutoSize = true,
                Location = new Point(5, 60),
                Name = "lab_OldANC",
                Size = new Size(20, 13),
                Text = "Old ANC",
            };
            gb_ANC.Controls.Add(lab_OLDANC);

            Label lab_NewANC = new Label
            {
                AutoSize = true,
                Location = new Point(150, 60),
                Name = "lab_NewANC",
                Size = new Size(20, 13),
                Text = "New ANC",
            };
            gb_ANC.Controls.Add(lab_NewANC);
        }

        private void Action_Group_STK_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_STK = new GroupBox
            {
                Location = new Point(290, 130),
                Name = "gb_STK",
                Size = new Size(500, 350),
                TabStop = false,
                Text = "STK:",
            };
            Action_GroupBox.Controls.Add(gb_STK);

            Label lab_OLDSTK = new Label
            {
                AutoSize = true,
                Location = new Point(25, 60),
                Name = "lab_OldSTK",
                Size = new Size(20, 13),
                Text = "Old STK",
            };
            gb_STK.Controls.Add(lab_OLDSTK);

            Label lab_OldSum = new Label
            {
                AutoSize = true,
                Location = new Point(25, 40),
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_OldSum",
                Size = new Size(20, 13),
                Text = "",
                ForeColor = Color.Red,
            };
            gb_STK.Controls.Add(lab_OldSum);

            Label lab_NewSTK = new Label
            {
                AutoSize = true,
                Location = new Point(110, 60),
                Name = "lab_NewSTK",
                Size = new Size(20, 13),
                Text = "New STK",
            };
            gb_STK.Controls.Add(lab_NewSTK);

            Label lab_NewSum = new Label
            {
                AutoSize = true,
                Location = new Point(110, 40),
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_NewSum",
                Size = new Size(20, 13),
                Text = "",
                ForeColor = Color.Green,
            };
            gb_STK.Controls.Add(lab_NewSum);

            Label lab_Delta = new Label
            {
                AutoSize = true,
                Location = new Point(220, 60),
                Name = "lab_Delta",
                Size = new Size(20, 13),
                Text = "Delta",
            };
            gb_STK.Controls.Add(lab_Delta);

            Label lab_DeltaSum = new Label
            {
                AutoSize = true,
                Location = new Point(220, 40),
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_DeltaSum",
                Size = new Size(20, 13),
                Text = "",
            };
            gb_STK.Controls.Add(lab_DeltaSum);

            Label lab_Esty = new Label
            {
                AutoSize = true,
                Location = new Point(288, 60),
                Name = "lab_Estymacja",
                Size = new Size(20, 13),
                Text = "Estymacja",
            };
            gb_STK.Controls.Add(lab_Esty);

            Label lab_Percent = new Label
            {
                AutoSize = true,
                Location = new Point(365, 60),
                Name = "lab_Percent",
                Size = new Size(20, 13),
                Text = "Percent[%]",
            };
            gb_STK.Controls.Add(lab_Percent);

            Label lab_Calc = new Label
            {
                AutoSize = true,
                Location = new Point(435, 60),
                Name = "lab_Calc",
                Size = new Size(20, 13),
                Text = "To Calc",
            };
            gb_STK.Controls.Add(lab_Calc);

            Label lab_CalcSum = new Label
            {
                AutoSize = true,
                Location = new Point(435, 40),
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
                Name = "lab_CalcSum",
                Size = new Size(20, 13),
                Text = "0",
            };
            gb_STK.Controls.Add(lab_CalcSum);

            Button pb_RefreshSTK = new Button
            {
                Location = new Point(440, 10),
                Name = "pb_RefreshSTK",
                Size = new Size(55, 25),
                Text = "Refresh",
                UseVisualStyleBackColor = true,
            };
            pb_RefreshSTK.Click += new EventHandler(pb_RefreshSTK_Click);
            gb_STK.Controls.Add(pb_RefreshSTK);
        }

        private void Action_Group_Calculation_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_Calc = new GroupBox
            {
                Location = new Point(795, 130),
                Name = "gb_Calc",
                Size = new Size(170, 350),
                TabStop = false,
                Text = "Calculation:",
            };
            Action_GroupBox.Controls.Add(gb_Calc);

            Label lab_ANC_PNC_Precent = new Label
            {
                AutoSize = true,
                Location = new Point(20, 20),
                Name = "lab_ANC_PNC_Percent",
                Size = new Size(20, 13),
                Text = "Quantity Percent:",
            };
            gb_Calc.Controls.Add(lab_ANC_PNC_Precent);

            TextBox nTB_PercentANCPNC = new TextBox
            {
                Location = new Point(110, 15),
                MaxLength = 3,
                Text = "100",
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(238))),
                Name = "TB_PercentANCPNC",
                Size = new Size(32, 20),
            };
            nTB_PercentANCPNC.Leave += new EventHandler(Tb_PercentQuantity_Leave);
            nTB_PercentANCPNC.TextChanged += new EventHandler(Tb_PercentQuantity_TextChange);
            gb_Calc.Controls.Add(nTB_PercentANCPNC);

            Label lab_Znaczek = new Label
            {
                AutoSize = true,
                Location = new Point(145, 20),
                Name = "lab_Znaczek",
                Size = new Size(20, 13),
                Text = "%",
            };
            gb_Calc.Controls.Add(lab_Znaczek);

            GroupBox gb_NextANC = new GroupBox
            {
                Location = new Point(5, 60),
                Name = "gb_NextANC",
                Size = new Size(155, 285),
                TabStop = false,
                Text = "Next ANC:",
            };
            gb_Calc.Controls.Add(gb_NextANC);
        }

        private void Action_Group_PNC_PNCSpec_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_PNC = new GroupBox
            {
                Location = new Point(1055, 130),
                Name = "gb_PNC",
                Size = new Size(525, 830),
                TabStop = false,
                Text = "PNC:",
                Enabled = false,
            };
            Action_GroupBox.Controls.Add(gb_PNC);

            DataGridView dg_PNC = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(10, 30),
                Name = "dg_PNC",
                Size = new Size(505, 790),
                ReadOnly = true,
                AllowUserToAddRows = false,
            };
            dg_PNC.RowHeadersWidth = 4;
            gb_PNC.Controls.Add(dg_PNC);
        }

        private void Action_Mass_Calculation(GroupBox Action_GroupBox)
        {
            GroupBox gb_MassCalc = new GroupBox
            {
                Location = new Point(1055, 130),
                Name = "gb_MassCalc",
                Size = new Size(525, 300),
                TabStop = false,
                Text = "Calculation Group",
                Enabled = true,
                Visible = false,
            };
            Action_GroupBox.Controls.Add(gb_MassCalc);

            CheckBox cb_Mass_All = new CheckBox
            {
                Location = new Point(25, 25),
                Name = "cb_Mass_All",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "All",
            };
            cb_Mass_All.CheckedChanged += new EventHandler(cb_Mass_All_CheckedChange);
            gb_MassCalc.Controls.Add(cb_Mass_All);

            CheckBox cb_Mass_DMD = new CheckBox
            {
                Location = new Point(25, 55),
                Name = "cb_Mass_DMD",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "DMD",
            };
            cb_Mass_DMD.CheckedChanged += new EventHandler(cb_Mass_DMD_CheckedChange);
            gb_MassCalc.Controls.Add(cb_Mass_DMD);

            CheckBox cb_Mass_D45 = new CheckBox
            {
                Location = new Point(90, 55),
                Name = "cb_Mass_D45",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "D45",
            };
            cb_Mass_D45.CheckedChanged += new EventHandler(cb_Mass_D45_CheckedChange);
            gb_MassCalc.Controls.Add(cb_Mass_D45);

            Label lab_DMD = new Label
            {
                Location = new Point(15, 95),
                Name = "Lab_DMD",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "DMD:",
            };
            gb_MassCalc.Controls.Add(lab_DMD);

            CheckBox cb_Mass_DMD_FS = new CheckBox
            {
                Location = new Point(25, 125),
                Name = "cb_Mass_DMD_FS",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FS",
            };
            gb_MassCalc.Controls.Add(cb_Mass_DMD_FS);

            CheckBox cb_Mass_DMD_FI = new CheckBox
            {
                Location = new Point(70, 125),
                Name = "cb_Mass_DMD_FI",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FI",
            };
            gb_MassCalc.Controls.Add(cb_Mass_DMD_FI);

            CheckBox cb_Mass_DMD_BI = new CheckBox
            {
                Location = new Point(115, 125),
                Name = "cb_Mass_DMD_BI",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "BI/BU",
            };
            gb_MassCalc.Controls.Add(cb_Mass_DMD_BI);

            CheckBox cb_Mass_DMD_FSBU = new CheckBox
            {
                Location = new Point(180, 125),
                Name = "cb_Mass_DMD_FSBU",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FSBU",
            };
            gb_MassCalc.Controls.Add(cb_Mass_DMD_FSBU);

            Label lab_D45 = new Label
            {
                Location = new Point(15, 165),
                Name = "Lab_D45",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "D45:",
            };
            gb_MassCalc.Controls.Add(lab_D45);

            CheckBox cb_Mass_D45_FS = new CheckBox
            {
                Location = new Point(25, 195),
                Name = "cb_Mass_D45_FS",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FS",
            };
            gb_MassCalc.Controls.Add(cb_Mass_D45_FS);

            CheckBox cb_Mass_D45_FI = new CheckBox
            {
                Location = new Point(70, 195),
                Name = "cb_Mass_D45_FI",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FI",
            };
            gb_MassCalc.Controls.Add(cb_Mass_D45_FI);

            CheckBox cb_Mass_D45_BI = new CheckBox
            {
                Location = new Point(115, 195),
                Name = "cb_Mass_D45_BI",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "BI/BU",
            };
            gb_MassCalc.Controls.Add(cb_Mass_D45_BI);

            CheckBox cb_Mass_D45_FSBU = new CheckBox
            {
                Location = new Point(180, 195),
                Name = "cb_Mass_D45_FSBU",
                AutoSize = true,
                Size = new Size(20, 20),
                Text = "FSBU",
            };
            gb_MassCalc.Controls.Add(cb_Mass_D45_FSBU);
        }

        private void Action_Group_CalcBy_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_CalcBy = new GroupBox
            {
                Location = new Point(1095, 10),
                Name = "gb_CalcBy",
                Size = new Size(220, 115),
                TabStop = false,
                Text = "Calculation by:",
            };
            Action_GroupBox.Controls.Add(gb_CalcBy);

            CheckBox cb_CalcANC = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(15, 25),
                Name = "cb_CalcANC",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "ANC",
                UseVisualStyleBackColor = true
            };
            cb_CalcANC.CheckedChanged += cb_Calc_CheckedChanged;
            gb_CalcBy.Controls.Add(cb_CalcANC);

            CheckBox cb_CalcANCby = new CheckBox
            {
                AutoSize = true,
                Checked = false,
                Location = new Point(130, 25),
                Name = "cb_CalcANCby",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "ANC Special",
                UseVisualStyleBackColor = true
            };
            cb_CalcANCby.CheckedChanged += cb_Calc_CheckedChanged;
            gb_CalcBy.Controls.Add(cb_CalcANCby);

            CheckBox cb_CalcPNC = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 55),
                Name = "cb_CalcPNC",
                Size = new Size(80, 17),
                Text = "PNC",
                UseVisualStyleBackColor = true
            };
            cb_CalcPNC.CheckedChanged += cb_Calc_CheckedChanged;
            gb_CalcBy.Controls.Add(cb_CalcPNC);

            CheckBox cb_CalcPNCSpec = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 85),
                Name = "cb_CalcPNCSpec",
                Size = new Size(80, 17),
                Text = "PNC Special",
                UseVisualStyleBackColor = true
            };
            cb_CalcPNCSpec.CheckedChanged += cb_Calc_CheckedChanged;
            gb_CalcBy.Controls.Add(cb_CalcPNCSpec);

            Button pb_PNC = new Button
            {
                Location = new Point(130, 50),
                Name = "pb_PNC",
                Size = new Size(75, 25),
                Text = "Add PNC",
                Enabled = false,
                UseVisualStyleBackColor = true,
            };
            pb_PNC.Click += new System.EventHandler(pb_PNC_Click);
            gb_CalcBy.Controls.Add(pb_PNC);

            Button pb_PNCSpec = new Button
            {
                Location = new Point(130, 80),
                Font = new Font("Microsoft Sans Serif", 6.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238))),
                Name = "pb_PNCSpec",
                Size = new Size(75, 25),
                Text = "Add PNCSpec",
                Enabled = false,
                UseVisualStyleBackColor = true,
            };
            pb_PNCSpec.Click += new System.EventHandler(pb_PNCSpec_Click);
            gb_CalcBy.Controls.Add(pb_PNCSpec);
        }

        private void Action_Group_State_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_State = new GroupBox
            {
                Location = new Point(410, 10),
                Name = "gb_State",
                Size = new Size(375, 115),
                TabStop = false,
                Text = "",
            };
            Action_GroupBox.Controls.Add(gb_State);

            CheckBox cb_Active = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(15, 25),
                Name = "cb_Active",
                Size = new Size(80, 17),
                Text = "Active",
                UseVisualStyleBackColor = true
            };
            cb_Active.CheckedChanged += cb_Active_CheckedChanged;
            gb_State.Controls.Add(cb_Active);

            CheckBox cb_Idea = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 45),
                Name = "cb_Idea",
                Size = new Size(80, 17),
                Text = "Idea",
                UseVisualStyleBackColor = true
            };
            cb_Idea.CheckedChanged += cb_Idea_CheckedChanged;
            gb_State.Controls.Add(cb_Idea);

            Label lab_opis = new Label
            {
                AutoSize = true,
                Location = new Point(10, 70),
                Name = "lab_opis",
                Size = new Size(20, 13),
                Text = "Devision:",
            };
            gb_State.Controls.Add(lab_opis);

            ComboBox combox_Devision = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(15, 85),
                Name = "comBox_Devision",
                Size = new Size(90, 21),
            };

            if (Person["ActionEle"].ToString() == "true")
            {
                combox_Devision.Items.Add("Electronic");
            }
            if (Person["ActionMech"].ToString() == "true")
            {
                combox_Devision.Items.Add("Mechanic");
            }
            if (Person["ActionNVR"].ToString() == "true")
            {
                combox_Devision.Items.Add("NVR");
            }
            combox_Devision.SelectedIndex = 0;
            combox_Devision.SelectedIndexChanged += new EventHandler(combo_Devision_SelectedIndexChange);
            gb_State.Controls.Add(combox_Devision);

            Label leb_YearAction = new Label
            {
                AutoSize = true,
                Location = new Point(120, 20),
                Name = "leb_YearAction",
                Size = new Size(20, 13),
                Text = "Start Year:",
            };
            gb_State.Controls.Add(leb_YearAction);

            NumericUpDown num_YearAction = new NumericUpDown
            {
                Location = new Point(125, 35),
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
                Name = "num_Action_YearAction",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            num_YearAction.ValueChanged += new EventHandler(num_YearAction_ValueChanged);
            gb_State.Controls.Add(num_YearAction);

            Label leb_MonthAction = new Label
            {
                AutoSize = true,
                Location = new Point(120, 70),
                Name = "leb_MonthAction",
                Size = new Size(20, 13),
                Text = "Start Month:",
            };
            gb_State.Controls.Add(leb_MonthAction);

            ComboBox combox_Month = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(125, 85),
                Name = "comBox_Month",
                Size = new Size(100, 21),
                Text = "Wybierz Miesiąc",
            };
            combox_Month.Items.AddRange(new object[] { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            combox_Month.SelectedIndexChanged += new EventHandler(combox_Month_SelectedIndexChange);
            gb_State.Controls.Add(combox_Month);

            Label lab_Leader = new Label
            {
                AutoSize = true,
                Location = new Point(230, 20),
                Name = "lab_Leader",
                Size = new Size(20, 13),
                Text = "Action Leader:",
            };
            gb_State.Controls.Add(lab_Leader);

            ComboBox combox_Leader = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(230, 35),
                Name = "comBox_Leader",
                Size = new Size(140, 21),
            };
            combox_Leader.SelectedIndexChanged += new EventHandler(combox_Leader_SelectedIndexChanged);
            gb_State.Controls.Add(combox_Leader);

            Label lab_Factory = new Label
            {
                AutoSize = true,
                Location = new Point(230, 70),
                Name = "lab_Factory",
                Size = new Size(20, 13),
                Text = "Factory",
            };
            gb_State.Controls.Add(lab_Factory);

            ComboBox combox_Factory = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(230, 85),
                Name = "comBox_Factory",
                Size = new Size(60, 21),
            };
            combox_Factory.Items.AddRange(new object[] { "PLV", "ZM" });
            combox_Factory.SelectedIndex = 0;
            combox_Factory.SelectedIndexChanged += new EventHandler(combox_Factory_SelectedIndexChanged);
            gb_State.Controls.Add(combox_Factory);

            //Dodanie osób z których można wybierać jako liderów akcji
            Add_People_To_Combobox(combox_Leader, false);

        }

        private void Action_Group_CalcFinal_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_CalcFinal = new GroupBox
            {
                Location = new Point(15, 480),
                Name = "gb_CalcFinal",
                Size = new Size(955, 480),
                TabStop = false,
                Text = "Saving:",
            };
            Action_GroupBox.Controls.Add(gb_CalcFinal);

            Label lab_Saving = new Label
            {
                AutoSize = true,
                Location = new Point(470, 15),
                Name = "lab_Saving",
                Size = new Size(20, 13),
                Text = "Saving:",
            };
            gb_CalcFinal.Controls.Add(lab_Saving);

            Button pb_SavingCalc = new Button
            {
                Location = new Point(890, 9),
                Name = "pb_SavingCalc",
                Size = new Size(60, 20),
                Text = "Calc",
                UseVisualStyleBackColor = true,
            };
            pb_SavingCalc.Click += new System.EventHandler(pb_SavingCalc_Click);
            gb_CalcFinal.Controls.Add(pb_SavingCalc);

            Button pb_CurrentYear = new Button
            {
                Location = new Point(80, 9),
                Name = "pb_CurrentYear",
                Size = new Size(80, 20),
                Text = "Start Year",
                BackColor = Color.LightBlue,
            };
            pb_CurrentYear.Click += new System.EventHandler(pb_Curren_Carry_Click);
            gb_CalcFinal.Controls.Add(pb_CurrentYear);

            Button pb_CarryOver = new Button
            {
                Location = new Point(170, 9),
                Name = "pb_CarryOver",
                Size = new Size(80, 20),
                Text = "Carry Over",
                UseVisualStyleBackColor = true,
            };
            pb_CarryOver.Click += new System.EventHandler(pb_Curren_Carry_Click);
            gb_CalcFinal.Controls.Add(pb_CarryOver);

            DataGridView dg_Saving = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(5, 30),
                Name = "dg_Saving",
                Size = new Size(945, 133),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreaterDataGridView(dg_Saving);

            gb_CalcFinal.Controls.Add(dg_Saving);

            Label lab_Quantity = new Label
            {
                AutoSize = true,
                Location = new Point(470, 170),
                Name = "lab_Quantity",
                Size = new Size(20, 13),
                Text = "Quantity:",
            };
            gb_CalcFinal.Controls.Add(lab_Quantity);

            DataGridView dg_Quantity = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(5, 185),
                Name = "dg_Quantity",
                Size = new Size(945, 133),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreaterDataGridView(dg_Quantity);
            gb_CalcFinal.Controls.Add(dg_Quantity);

            Label lab_ECCC2 = new Label
            {
                AutoSize = true,
                Location = new Point(470, 325),
                Name = "lab_ECCC2",
                Size = new Size(20, 13),
                Text = "ECCC:",
            };
            gb_CalcFinal.Controls.Add(lab_ECCC2);

            DataGridView dg_ECCC = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(5, 340),
                Name = "dg_ECCC",
                Size = new Size(945, 133),
                AllowUserToAddRows = false,
                ReadOnly = true,
                Enabled = false,
            };

            CreaterDataGridView(dg_ECCC);

            gb_CalcFinal.Controls.Add(dg_ECCC);
        }

        private void Action_Group_ECCC_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_ECCC = new GroupBox
            {
                Location = new Point(970, 10),
                Name = "gb_ECCC",
                Size = new Size(120, 115),
                TabStop = false,
                Text = "ECCC",
            };
            Action_GroupBox.Controls.Add(gb_ECCC);

            CheckBox cb_ECCC = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 25),
                Name = "cb_ECCC",
                Size = new Size(80, 17),
                Text = "ECCC",
                UseVisualStyleBackColor = true
            };
            cb_ECCC.CheckedChanged += cb_ECCC_CheckedChanged;
            gb_ECCC.Controls.Add(cb_ECCC);

            CheckBox cb_ECCSpec = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 50),
                Name = "cb_ECCCSpec",
                Size = new Size(80, 17),
                Text = "From PNC Spec",
                UseVisualStyleBackColor = true,
                Visible = false,
                Enabled = false,
            };
            cb_ECCSpec.CheckedChanged += cb_Calc_CheckedChanged;
            gb_ECCC.Controls.Add(cb_ECCSpec);

            NumericUpDown num_ECCC = new NumericUpDown
            {
                Location = new Point(15, 70),
                Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648}),
                Name = "num_ECCC",
                Size = new Size(50, 20),
                Value = 0,
                Enabled = false,
                DecimalPlaces = 1,
                Increment = .5m,
            };
            gb_ECCC.Controls.Add(num_ECCC);

            Label lab_ECCC = new Label
            {
                AutoSize = true,
                Location = new Point(65, 75),
                Name = "lab_ECCC",
                Size = new Size(20, 13),
                Text = "sec.",
            };
            gb_ECCC.Controls.Add(lab_ECCC);
        }

        private void Action_Group_PNCEstyma_Change(GroupBox Action_GroupBox)
        {
            GroupBox gb_PNCEsty = new GroupBox
            {
                Location = new Point(1320, 10),
                Name = "gb_PNCEsty",
                Size = new Size(150, 115),
                TabStop = false,
                Text = "PNC Estymacja",
                Visible = false,
            };
            Action_GroupBox.Controls.Add(gb_PNCEsty);

            Label lab_PNCestyma_Esty = new Label
            {
                AutoSize = true,
                Location = new Point(15, 30),
                Name = "lab_PNCEstyma_Esty",
                Size = new Size(20, 13),
                Text = "Estymacja:",
            };
            gb_PNCEsty.Controls.Add(lab_PNCestyma_Esty);

            TextBox nTB_EstymacjaPNC = new TextBox
            {
                Location = new Point(15, 55),
                Name = "TB_EstymacjaPNC",
                Size = new Size(60, 20),
                MaxLength = 10,
            };
            nTB_EstymacjaPNC.TextChanged += new EventHandler(tb_PNCEStymation_TextChanged);
            nTB_EstymacjaPNC.Leave += new EventHandler(tb_PNCEstimation_Leave);
            gb_PNCEsty.Controls.Add(nTB_EstymacjaPNC);
        }

        private void Add_People_To_Combobox(ComboBox combox_Leader, bool All)
        {
            if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "MechMenager" || Person["Role"].ToString() == "EleMenager" || Person["Role"].ToString() == "NVRMenager" || Person["Role"].ToString() == "PCMenager")
            {
                DataTable Access = new DataTable();
                string LinkAccess = ImportData.Load_Link("Access");
                ImportData.Load_TxtToDataTable(ref Access, LinkAccess);

                if (All)
                {
                    combox_Leader.Items.Add("All");
                }

                combox_Leader.Items.Add(Person["FullName"].ToString());
                combox_Leader.SelectedIndex = 0;

                foreach (DataRow AccessRow in Access.Rows)
                {
                    if (AccessRow["Name"].ToString() != Person["Name"].ToString())
                    {
                        if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "PCMenager")
                        {
                            combox_Leader.Items.Add(AccessRow["FullName"].ToString());
                        }
                        else if (Person["Role"].ToString() == "EleMenager")
                        {
                            if (AccessRow["ActionEle"].ToString() == "true")
                            {
                                if (AccessRow["Role"].ToString() != "PCMenager")
                                    combox_Leader.Items.Add(AccessRow["FullName"].ToString());
                            }
                        }
                        else if (Person["Role"].ToString() == "MechMenager")
                        {
                            if (AccessRow["ActionMech"].ToString() == "true")
                            {
                                if (AccessRow["Role"].ToString() != "PCMenager" )
                                    if (AccessRow["Role"].ToString() != "Admin")
                                        combox_Leader.Items.Add(AccessRow["FullName"].ToString());
                               
                            }
                        }
                        else if (Person["Role"].ToString() == "NVRMenager")
                        {
                            if (AccessRow["ActionNVR"].ToString() == "true")
                            {
                                if (AccessRow["Role"].ToString() != "PCMenager")
                                    if (AccessRow["Role"].ToString() != "Admin")
                                        combox_Leader.Items.Add(AccessRow["FullName"].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                combox_Leader.Items.Add(Person["FullName"].ToString());
                combox_Leader.SelectedIndex = 0;
            }
        }

        private void Load_SpecialButton(GroupBox Action_GroupBox)
        {
            //PRzycisk do pokazywania IDCO jakie jest w akcji
            Button IDCO = new Button
            {
                Location = new Point(975, 490),
                Name = "PB_Idco",
                Size = new Size(75, 30),
                Text = "IDCO",
            };
            IDCO.Click += new EventHandler(IDCO_Click);
            Action_GroupBox.Controls.Add(IDCO);

            //Przycisk do zapisywania do Excela danych z Akcji PNC i PNC Spec
            Button SavePNC = new Button
            {
                Location = new Point(975, 930),
                Name = "PB_SavePNC",
                Size = new Size(75, 30),
                Text = "Save Data",
                Visible = false,
            };
            SavePNC.Click += new EventHandler(SavePNC_Click);
            Action_GroupBox.Controls.Add(SavePNC);

        }

        private void CreaterDataGridView(DataGridView DG)
        {
            DG.Columns.Add("1", "I");
            DG.Columns.Add("2", "II");
            DG.Columns.Add("3", "III");
            DG.Columns.Add("4", "IV");
            DG.Columns.Add("5", "V");
            DG.Columns.Add("6", "VI");
            DG.Columns.Add("7", "VII");
            DG.Columns.Add("8", "VIII");
            DG.Columns.Add("9", "IX");
            DG.Columns.Add("10", "X");
            DG.Columns.Add("11", "XI");
            DG.Columns.Add("12", "XII");
            DG.Columns.Add("Sum:", "Sum:");
            DG.Columns[0].Width = 67;
            DG.Columns[1].Width = 67;
            DG.Columns[2].Width = 67;
            DG.Columns[3].Width = 67;
            DG.Columns[4].Width = 67;
            DG.Columns[5].Width = 67;
            DG.Columns[6].Width = 67;
            DG.Columns[7].Width = 67;
            DG.Columns[8].Width = 67;
            DG.Columns[9].Width = 67;
            DG.Columns[10].Width = 67;
            DG.Columns[11].Width = 67;
            DG.Columns[12].Width = 84;
            DG.Rows.Add(5);
            DG.RowHeadersWidth = 55;
            DG.Rows[0].HeaderCell.Value = "Use:";
            DG.Rows[1].HeaderCell.Value = "EA3:";
            DG.Rows[2].HeaderCell.Value = "EA2:";
            DG.Rows[3].HeaderCell.Value = "EA1:";
            DG.Rows[4].HeaderCell.Value = "BU:";
            DG.CurrentCell = DG[0, 0];
            DG.ClearSelection();
            DG.Columns["Sum:"].DefaultCellStyle.Font = new Font(DG.Font, FontStyle.Bold);
            DG.Rows[0].DefaultCellStyle.Font = new Font(DG.Font, FontStyle.Bold);
            //DG.Rows[0].DefaultCellStyle.BackColor = Color.Lime;
            DG.Rows[1].DefaultCellStyle.BackColor = Color.LightBlue;
            DG.Rows[2].DefaultCellStyle.BackColor = Color.MediumTurquoise;
            DG.Rows[3].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
            DG.Rows[4].DefaultCellStyle.BackColor = Color.DodgerBlue;
            DG.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            DG.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            DG.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            DG.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
            DG.Rows[0].DefaultCellStyle.Format = "#,0.###";
            DG.Rows[1].DefaultCellStyle.Format = "#,0.###";
            DG.Rows[2].DefaultCellStyle.Format = "#,0.###";
            DG.Rows[3].DefaultCellStyle.Format = "#,0.###";
            DG.Rows[4].DefaultCellStyle.Format = "#,0.###";
            DG.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
