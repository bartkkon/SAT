﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Saving_Accelerator_Tool.Klasy.AdmnTab;
using Saving_Accelerator_Tool.Klasy.AdmnTab.View;

namespace Saving_Accelerator_Tool
{
    class AdminForm : AdminFormHendler
    {
        private readonly TabPage tab_Admin;

        public AdminForm(MainProgram mainProgram, Action action, Admin admin, Data_Import ImportData) : base(mainProgram, action, admin, ImportData)
        {
            tab_Admin = (TabPage)mainProgram.TabControl.Controls.Find("tab_Admin", false).First();

            Tab_Admin_Comp();
        }

        private void Tab_Admin_Comp()
        {
            //Dodaw2anie Ilości na każdą rewizje budżetu
            Admin_Group_AddQperRev_Change();

            //Kalkulowanie akcji po dodaniu ilości Rewizyjnych 
            Admin_Group_CalcRev_Change();

            //Dodawanie ilosci miesięcznie 
            Admin_Group_AddQperMonth_Change();

            //Miesięczne przeliczanie akcji 
            Admin_Group_CalcEveryMonth_Change();

            //Update STK
            //Admin_Group_STK_Change();
            _ = new STKUpdate(tab_Admin);

            //Odblokowanie DatagridView dla qunatity/Savings/ECCC
            Admin_Group_EnableDGV_Change();

            // frozen Grupbox do aktualizacji czy dany jest frozen 
            Admin_Group_Frozen_Change();

            //Dane dla Kursów - ECCC, Euro, Dolary, Seki
            Admin_Group_Coins_Change();

            //Dodawanie kolumny do każdej z bazy danych, plus można wypełnić czymś standardowym (wszystko w jednym)
            Admin_AddColumnToDataBase();

            //Aktywowanie zablokowanych akcji
            Admin_Activator_Action();

            //Klonowanie Bazy danych na dysk - działa tylko dla Bartkkon
            Admin_CloneDataBase();

            //Wszystkie nowe rzeczy dodawana w nowy sposób
            _ = new AdminTabGenerator(tab_Admin);

        }

        private void Admin_AddColumnToDataBase()
        {
            GroupBox gb_AdminAddColumn = new GroupBox
            {
                Location = new Point(830, 15),
                Name = "gb_AdminAddColumn",
                Size = new Size(300, 160),
                TabStop = false,
                Text = "Add Column:",
            };
            tab_Admin.Controls.Add(gb_AdminAddColumn);

            ComboBox combox_AdminAddColumn_Where = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(15, 30),
                Name = "comBox_AdminAddColumn_Where",
                Size = new Size(100, 21),
            };
            //combox_AdminAddColumn_Where.SelectedIndexChanged += new EventHandler(combox_AdminAccess_SelectedIndexChanged);
            combox_AdminAddColumn_Where.Items.AddRange(new object[] { "Action", "STK", "Frozen", "ANC", "PNC", "ANCMonth", "PNCMonth", "Kurs" });
            combox_AdminAddColumn_Where.SelectedIndex = 0;
            gb_AdminAddColumn.Controls.Add(combox_AdminAddColumn_Where);

            Label lab_AdminAddColumn = new Label
            {
                Location = new Point(15, 63),
                Size = new Size(15, 20),
                AutoSize = true,
                Name = "lab_AdminAddColumn",
                Text = "Column Name:"
            };
            gb_AdminAddColumn.Controls.Add(lab_AdminAddColumn);

            TextBox tb_AdminAddColumn = new TextBox
            {
                Location = new Point(100, 60),
                Name = "tb_AdminAddColumn",
                Size = new Size(160, 21)
            };
            gb_AdminAddColumn.Controls.Add(tb_AdminAddColumn);

            Label Lab_AdminAddValue = new Label
            {
                Location = new Point(15, 93),
                Size = new Size(10, 10),
                AutoSize = true,
                Text = "Values inside:"
            };
            gb_AdminAddColumn.Controls.Add(Lab_AdminAddValue);

            TextBox Tb_AdminAddValue = new TextBox
            {
                Location = new Point(100, 90),
                Name = "tb_AdminAddValue",
                Size = new Size(160, 21)
            };
            gb_AdminAddColumn.Controls.Add(Tb_AdminAddValue);

            Button pb_AdminAddColum = new Button
            {
                Location = new Point(15, 120),
                Name = "pb_adminAddColumn",
                Size = new Size(90, 25),
                Text = "Add Column",
            };
            pb_AdminAddColum.Click += new System.EventHandler(Pb_Admin_AddColumn_Click);
            gb_AdminAddColumn.Controls.Add(pb_AdminAddColum);
        }

        private void Admin_Group_AddQperRev_Change()
        {
            GroupBox gb_AdminNewQuantity = new GroupBox
            {
                Location = new Point(15, 15),
                Name = "gb_NewQuantity",
                Size = new Size(200, 160),
                TabStop = false,
                Text = "Add Quantity for Revision",
            };
            tab_Admin.Controls.Add(gb_AdminNewQuantity);

            CheckBox cb_AdminBU = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(15, 70),
                Name = "cb_AdminBU",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "BU",
                UseVisualStyleBackColor = true
            };
            cb_AdminBU.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminBU);

            CheckBox cb_AdminEA1 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 90),
                Name = "cb_AdminEA1",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA1",
                UseVisualStyleBackColor = true
            };
            cb_AdminEA1.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminEA1);

            CheckBox cb_AdminEA2 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 110),
                Name = "cb_AdminEA2",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA2",
                UseVisualStyleBackColor = true
            };
            cb_AdminEA2.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminEA2);

            CheckBox cb_AdminEA3 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 130),
                Name = "cb_AdminEA3",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA3",
                UseVisualStyleBackColor = true
            };
            cb_AdminEA3.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminEA3);

            CheckBox cb_AdminPNC = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(15, 25),
                Name = "cb_AdminPNC",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "PNC",
                UseVisualStyleBackColor = true
            };
            cb_AdminPNC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminPNC);

            CheckBox cb_AdminANC = new CheckBox
            {
                AutoSize = true,
                Location = new Point(100, 25),
                Name = "cb_AdminANC",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "ANC",
                UseVisualStyleBackColor = true
            };
            cb_AdminANC.CheckedChanged += Cb_ChangeANC_PNC_CheckedChanged;
            gb_AdminNewQuantity.Controls.Add(cb_AdminANC);

            NumericUpDown num_YearQuantity = new NumericUpDown
            {
                Location = new Point(100, 70),
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
                Name = "num_Admin_YearQuantity",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            gb_AdminNewQuantity.Controls.Add(num_YearQuantity);

            Button pb_Admin_SaveQuantity = new Button
            {
                Location = new Point(100, 130),
                Name = "pb_Admin_SaveQuantity",
                Size = new Size(60, 20),
                Text = "Add",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_SaveQuantity.Click += new System.EventHandler(Pb_AdminSaveQuantity_Click);
            gb_AdminNewQuantity.Controls.Add(pb_Admin_SaveQuantity);
        }

        private void Admin_Group_CalcRev_Change()
        {
            GroupBox gb_AdminCalcBU = new GroupBox
            {
                Location = new Point(15, 175),
                Name = "gb_NewQuantityBU",
                Size = new Size(200, 110),
                TabStop = false,
                Text = "Calc Revision:",
            };
            tab_Admin.Controls.Add(gb_AdminCalcBU);

            CheckBox cb_AdminCalcBU = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(15, 20),
                Name = "cb_AdminCalcBU",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "BU",
                UseVisualStyleBackColor = true
            };
            cb_AdminCalcBU.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminCalcBU.Controls.Add(cb_AdminCalcBU);

            CheckBox cb_AdminCalcEA1 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 40),
                Name = "cb_AdminCalcEA1",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA1",
                UseVisualStyleBackColor = true
            };
            cb_AdminCalcEA1.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminCalcBU.Controls.Add(cb_AdminCalcEA1);

            CheckBox cb_AdminCalcEA2 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 60),
                Name = "cb_AdminCalcEA2",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA2",
                UseVisualStyleBackColor = true
            };
            cb_AdminCalcEA2.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminCalcBU.Controls.Add(cb_AdminCalcEA2);

            CheckBox cb_AdminCalcEA3 = new CheckBox
            {
                AutoSize = true,
                Location = new Point(15, 80),
                Name = "cb_AdminCalcEA3",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "EA3",
                UseVisualStyleBackColor = true
            };
            cb_AdminCalcEA3.CheckedChanged += Cb_ChangeRewision_CheckedChanged;
            gb_AdminCalcBU.Controls.Add(cb_AdminCalcEA3);

            NumericUpDown num_QuantityCalcRev = new NumericUpDown
            {
                Location = new Point(100, 30),
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
                Name = "num_Admin_QuantityCalcRev",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year,
            };
            gb_AdminCalcBU.Controls.Add(num_QuantityCalcRev);

            Button pb_Admin_SaveCalcRevNew = new Button
            {
                Location = new Point(100, 80),
                Name = "pb_Admin_SaveCalcRevNew",
                Size = new Size(80, 20),
                Text = "Calc Rev",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_SaveCalcRevNew.Click += new EventHandler(Pb_AdminSaveCalcRevNew_Click);
            gb_AdminCalcBU.Controls.Add(pb_Admin_SaveCalcRevNew);
        }

        private void Admin_Group_AddQperMonth_Change()
        {
            GroupBox gb_AdminNewQuantityMonth = new GroupBox
            {
                Location = new Point(15, 285),
                Name = "gb_NewQuantityMonth",
                Size = new Size(200, 130),
                TabStop = false,
                Text = "Add Quantity per Month",
            };
            tab_Admin.Controls.Add(gb_AdminNewQuantityMonth);

            Label lab_AdminYearMonth = new Label
            {
                AutoSize = true,
                Location = new Point(15, 25),
                Name = "lab_AdminYearMonth",
                Size = new Size(71, 13),
                Text = "Year:",
            };
            gb_AdminNewQuantityMonth.Controls.Add(lab_AdminYearMonth);

            NumericUpDown num_YearQuantityMonth = new NumericUpDown
            {
                Location = new Point(100, 20),
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
                Name = "num_Admin_YearMonth",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            gb_AdminNewQuantityMonth.Controls.Add(num_YearQuantityMonth);

            Label lab_AdminMonth = new Label
            {
                AutoSize = true,
                Location = new Point(15, 50),
                Name = "lab_AdminMonth",
                Size = new Size(71, 13),
                Text = "Month:",
            };
            gb_AdminNewQuantityMonth.Controls.Add(lab_AdminMonth);

            NumericUpDown num_QuantityMonth = new NumericUpDown
            {
                Location = new Point(100, 45),
                Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0}),
                Name = "num_Admin_QuantityMonth",
                Size = new Size(78, 20),
            };
            if (DateTime.Today.Month == 1)
            {
                num_QuantityMonth.Value = 12;
                num_YearQuantityMonth.Value -= 1;
            }
            else
            {
                num_QuantityMonth.Value = DateTime.Today.Month - 1;
            }
            gb_AdminNewQuantityMonth.Controls.Add(num_QuantityMonth);

            CheckBox cb_AdminPNCMonth = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(50, 75),
                Name = "cb_AdminPNCMonth",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "PNC",
                UseVisualStyleBackColor = true
            };
            cb_AdminPNCMonth.CheckedChanged += Cb_ChangeANC_PNCMonth_CheckedChanged;
            gb_AdminNewQuantityMonth.Controls.Add(cb_AdminPNCMonth);

            CheckBox cb_AdminANCMonth = new CheckBox
            {
                AutoSize = true,
                Location = new Point(100, 75),
                Name = "cb_AdminANCMonth",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "ANC",
                UseVisualStyleBackColor = true
            };
            cb_AdminANCMonth.CheckedChanged += Cb_ChangeANC_PNCMonth_CheckedChanged;
            gb_AdminNewQuantityMonth.Controls.Add(cb_AdminANCMonth);

            Button pb_Admin_SaveQuantityMonth = new Button
            {
                Location = new Point(70, 100),
                Name = "pb_Admin_SaveQuantityMonth",
                Size = new Size(60, 20),
                Text = "Add",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_SaveQuantityMonth.Click += new System.EventHandler(Pb_AdminSaveQuantityMonth_Click);
            gb_AdminNewQuantityMonth.Controls.Add(pb_Admin_SaveQuantityMonth);
        }

        private void Admin_Group_CalcEveryMonth_Change()
        {
            GroupBox gb_AdminCalcMonth = new GroupBox
            {
                Location = new Point(15, 415),
                Name = "gb_NewQuantityMonth",
                Size = new Size(200, 110),
                TabStop = false,
                Text = "Calc EvryMonth:",
            };
            tab_Admin.Controls.Add(gb_AdminCalcMonth);

            Label lab_AdminYearCalc = new Label
            {
                AutoSize = true,
                Location = new Point(15, 25),
                Name = "lab_AdminYearCalc",
                Size = new Size(71, 13),
                Text = "Year:",
            };
            gb_AdminCalcMonth.Controls.Add(lab_AdminYearCalc);

            NumericUpDown num_YearCalc = new NumericUpDown
            {
                Location = new Point(100, 20),
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
                Name = "num_Admin_YearCalc",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            gb_AdminCalcMonth.Controls.Add(num_YearCalc);

            Label lab_AdminMonthCalc = new Label
            {
                AutoSize = true,
                Location = new Point(15, 50),
                Name = "lab_AdminMonthCalc",
                Size = new Size(71, 13),
                Text = "Month:",
            };
            gb_AdminCalcMonth.Controls.Add(lab_AdminMonthCalc);

            NumericUpDown num_MonthCalc = new NumericUpDown
            {
                Location = new Point(100, 45),
                Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0}),
                Name = "num_Admin_MonthCalc",
                Size = new Size(78, 20),
            };
            if (DateTime.Today.Month == 1)
            {
                num_MonthCalc.Value = 12;
                num_YearCalc.Value -= 1;
            }
            else
            {
                num_MonthCalc.Value = DateTime.Today.Month - 1;
            }
            gb_AdminCalcMonth.Controls.Add(num_MonthCalc);

            Button pb_Admin_SaveCalcMonthNew = new Button
            {
                Location = new Point(100, 80),
                Name = "pb_Admin_SaveCalcMonthNew",
                Size = new Size(80, 20),
                Text = "Calc Month",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_SaveCalcMonthNew.Click += new EventHandler(Pb_AdminSaveCalcMonthNew_Click);
            gb_AdminCalcMonth.Controls.Add(pb_Admin_SaveCalcMonthNew);
        }

        private void Admin_Group_EnableDGV_Change()
        {
            GroupBox gb_EnableDataGrid = new GroupBox
            {
                Location = new Point(220, 755),
                Name = "gb_AdminEnableDataGrid",
                Size = new Size(200, 90),
                TabStop = false,
                Text = "Enable DataGridView",
            };
            tab_Admin.Controls.Add(gb_EnableDataGrid);

            CheckBox cb_quantity = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(20, 20),
                Name = "cb_Quantity",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Qunatity",
                UseVisualStyleBackColor = true,
            };
            cb_quantity.CheckedChanged += Cb_DataGridEnable_CheckedChanged;
            gb_EnableDataGrid.Controls.Add(cb_quantity);

            CheckBox cb_Saving = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(20, 40),
                Name = "cb_Saving",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "Saving",
                UseVisualStyleBackColor = true,
            };
            cb_Saving.CheckedChanged += Cb_DataGridEnable_CheckedChanged;
            gb_EnableDataGrid.Controls.Add(cb_Saving);

            CheckBox cb_ECCCtab = new CheckBox
            {
                AutoSize = true,
                Checked = true,
                Location = new Point(20, 60),
                Name = "cb_ECCCtab",
                Size = new Size(80, 17),
                TabIndex = 0,
                Text = "ECCC",
                UseVisualStyleBackColor = true,
            };
            cb_ECCCtab.CheckedChanged += Cb_DataGridEnable_CheckedChanged;
            gb_EnableDataGrid.Controls.Add(cb_ECCCtab);
        }

        private void Admin_Group_Frozen_Change()
        {
            GroupBox gb_AdminFrozen = new GroupBox
            {
                Location = new Point(220, 15),
                Name = "gb_AdminFrozen",
                Size = new Size(200, 630),
                TabStop = false,
                Text = "Frozen",
            };
            tab_Admin.Controls.Add(gb_AdminFrozen);

            NumericUpDown num_AdminFrozenYear = new NumericUpDown
            {
                Location = new Point(10, 20),
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
                Name = "num_Admin_FrozenYear",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            gb_AdminFrozen.Controls.Add(num_AdminFrozenYear);

            //Dodanie Elementów Do sprawdzenia czy jest frozzen czy nie 
            Admin_Frozen_AddFrozzen(gb_AdminFrozen);

            Button pb_Admin_FrozenRefresh = new Button
            {
                Location = new Point(130, 15),
                Name = "pb_Admin_FrozenRefresh",
                Size = new Size(60, 20),
                Text = "Refresh",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_FrozenRefresh.Click += new System.EventHandler(Pb_Admin_FrozenRefresh_Click);
            gb_AdminFrozen.Controls.Add(pb_Admin_FrozenRefresh);

            Button pb_Admin_FrozenSave = new Button
            {
                Location = new Point(70, 600),
                Name = "pb_Admin_FrozenSave",
                Size = new Size(60, 20),
                Text = "Save",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_FrozenSave.Click += new System.EventHandler(Pb_Admin_FrozenSave_Click);
            gb_AdminFrozen.Controls.Add(pb_Admin_FrozenSave);
        }

        private void Admin_Group_Coins_Change()
        {
            GroupBox gb_AdminValue = new GroupBox
            {
                Location = new Point(15, 685),
                Name = "gb_AdminValue",
                Size = new Size(200, 200),
                TabStop = false,
                Text = "Coins",
            };
            tab_Admin.Controls.Add(gb_AdminValue);

            Label lab_AdminYear = new Label
            {
                AutoSize = true,
                Location = new Point(10, 20),
                Name = "lab_AdminYear",
                Size = new Size(71, 13),
                Text = "Year:",
            };
            gb_AdminValue.Controls.Add(lab_AdminYear);

            NumericUpDown num_AdminValueYear = new NumericUpDown
            {
                Location = new Point(50, 20),
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
                Name = "num_Admin_ValueYear",
                Size = new Size(78, 20),
                Value = DateTime.Today.Year
            };
            num_AdminValueYear.ValueChanged += Pb_Admin_ValueRefresh_Click;
            gb_AdminValue.Controls.Add(num_AdminValueYear);

            Label lab_AdminECCC = new Label
            {
                AutoSize = true,
                Location = new Point(10, 53),
                Name = "lab_AdminECCC",
                Size = new Size(71, 13),
                Text = "ECCC:",
            };
            gb_AdminValue.Controls.Add(lab_AdminECCC);

            TextBox TB_AdminECCC = new TextBox
            {
                Location = new Point(50, 50),
                Name = "tb_AdminECCC",
                Size = new Size(70, 20),
            };
            TB_AdminECCC.TextChanged += new EventHandler(Tb_Value_TextChange);
            gb_AdminValue.Controls.Add(TB_AdminECCC);

            Label lab_AdminEuro = new Label
            {
                AutoSize = true,
                Location = new Point(25, 83),
                Name = "lab_AdminEuro",
                Size = new Size(71, 13),
                Text = "€:",
            };
            gb_AdminValue.Controls.Add(lab_AdminEuro);

            TextBox TB_AdminEuro = new TextBox
            {
                Location = new Point(50, 80),
                Name = "tb_AdminEuro",
                Size = new Size(70, 20),

            };
            TB_AdminEuro.TextChanged += new EventHandler(Tb_Value_TextChange);
            gb_AdminValue.Controls.Add(TB_AdminEuro);

            Label lab_AdminDolars = new Label
            {
                AutoSize = true,
                Location = new Point(25, 113),
                Name = "lab_AdminDolars",
                Size = new Size(71, 13),
                Text = "$:",
            };
            gb_AdminValue.Controls.Add(lab_AdminDolars);

            TextBox TB_AdminDolars = new TextBox
            {
                Location = new Point(50, 110),
                Name = "tb_AdminDolars",
                Size = new Size(70, 20),

            };
            TB_AdminDolars.TextChanged += new EventHandler(Tb_Value_TextChange);
            gb_AdminValue.Controls.Add(TB_AdminDolars);

            Label lab_AdminSEK = new Label
            {
                AutoSize = true,
                Location = new Point(10, 143),
                Name = "lab_AdminSEK",
                Size = new Size(71, 13),
                Text = "SEK:",
            };
            gb_AdminValue.Controls.Add(lab_AdminSEK);

            TextBox TB_AdminSek = new TextBox
            {
                Location = new Point(50, 140),
                Name = "tb_AdminSek",
                Size = new Size(70, 20),

            };
            TB_AdminSek.TextChanged += new EventHandler(Tb_Value_TextChange);
            gb_AdminValue.Controls.Add(TB_AdminSek);

            Button pb_Admin_ValueRefresh = new Button
            {
                Location = new Point(30, 170),
                Name = "pb_Admin_ValueRefresh",
                Size = new Size(60, 20),
                Text = "Refresh",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_ValueRefresh.Click += new System.EventHandler(Pb_Admin_ValueRefresh_Click);
            gb_AdminValue.Controls.Add(pb_Admin_ValueRefresh);

            Button pb_Admin_ValueSave = new Button
            {
                Location = new Point(110, 170),
                Name = "pb_Admin_ValueSave",
                Size = new Size(60, 20),
                Text = "Save",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_ValueSave.Click += new System.EventHandler(Pb_Admin_ValueSave_Click);
            gb_AdminValue.Controls.Add(pb_Admin_ValueSave);
        }

        private void Admin_Frozen_AddFrozzen(GroupBox gb_AdminFrozen)
        {
            string[] ComboBoxItems = new string[] { "Close", "Open", "Approve" };
            string[] ComboBoxItems2 = new string[] { "Close", "", "Approve" };

            Label Lab_AdminBU = new Label
            {
                AutoSize = true,
                Location = new Point(10, 60),
                Name = "Lab_AdminBU",
                Size = new Size(71, 13),
                Text = "BU:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminBU);

            ComboBox Combo_AdminBU = new ComboBox
            {
                Location = new Point(50, 60),
                Name = "Combo_AdminBU",
                Size = new Size(80, 20),
            };
            Combo_AdminBU.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_AdminBU);

            Label Lab_AdminEA1 = new Label
            {
                AutoSize = true,
                Location = new Point(10, 85),
                Name = "Lab_AdminEA1",
                Size = new Size(71, 13),
                Text = "EA1:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminEA1);

            ComboBox Combo_AdminEA1 = new ComboBox
            {
                Location = new Point(50, 85),
                Name = "Combo_AdminEA1",
                Size = new Size(80, 20),
            };
            Combo_AdminEA1.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_AdminEA1);

            Label Lab_AdminEA2 = new Label
            {
                AutoSize = true,
                Location = new Point(10, 110),
                Name = "Lab_AdminEA2",
                Size = new Size(71, 13),
                Text = "EA2:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminEA2);

            ComboBox Combo_AdminEA2 = new ComboBox
            {
                Location = new Point(50, 110),
                Name = "Combo_AdminEA2",
                Size = new Size(80, 20),
            };
            Combo_AdminEA2.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_AdminEA2);

            Label Lab_AdminEA3 = new Label
            {
                AutoSize = true,
                Location = new Point(10, 135),
                Name = "Lab_AdminEA3",
                Size = new Size(71, 13),
                Text = "EA3:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminEA3);

            ComboBox Combo_AdminEA3 = new ComboBox
            {
                Location = new Point(50, 135),
                Name = "Combo_AdminEA3",
                Size = new Size(80, 20),
            };
            Combo_AdminEA3.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_AdminEA3);

            Label Lab_Admin1 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 160),
                Name = "Lab_Admin1",
                Size = new Size(71, 13),
                Text = "1:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin1);

            ComboBox Combo_Admin1 = new ComboBox
            {
                Location = new Point(50, 160),
                Name = "Combo_Admin1",
                Size = new Size(80, 20),
            };
            Combo_Admin1.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin1);

            Label Lab_Admin2 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 185),
                Name = "Lab_Admin2",
                Size = new Size(71, 13),
                Text = "2:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin2);

            ComboBox Combo_Admin2 = new ComboBox
            {
                Location = new Point(50, 185),
                Name = "Combo_Admin2",
                Size = new Size(80, 20),
            };
            Combo_Admin2.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin2);

            Label Lab_Admin3 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 210),
                Name = "Lab_Admin3",
                Size = new Size(71, 13),
                Text = "3:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin3);

            ComboBox Combo_Admin3 = new ComboBox
            {
                Location = new Point(50, 210),
                Name = "Combo_Admin3",
                Size = new Size(80, 20),
            };
            Combo_Admin3.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin3);

            Label Lab_Admin4 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 235),
                Name = "Lab_Admin4",
                Size = new Size(71, 13),
                Text = "4:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin4);

            ComboBox Combo_Admin4 = new ComboBox
            {
                Location = new Point(50, 235),
                Name = "Combo_Admin4",
                Size = new Size(80, 20),
            };
            Combo_Admin4.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin4);

            Label Lab_Admin5 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 260),
                Name = "Lab_Admin5",
                Size = new Size(71, 13),
                Text = "5:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin5);

            ComboBox Combo_Admin5 = new ComboBox
            {
                Location = new Point(50, 260),
                Name = "Combo_Admin5",
                Size = new Size(80, 20),
            };
            Combo_Admin5.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin5);

            Label Lab_Admin6 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 285),
                Name = "Lab_Admin6",
                Size = new Size(71, 13),
                Text = "6:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin6);

            ComboBox Combo_Admin6 = new ComboBox
            {
                Location = new Point(50, 285),
                Name = "Combo_Admin6",
                Size = new Size(80, 20),
            };
            Combo_Admin6.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin6);

            Label Lab_Admin7 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 310),
                Name = "Lab_Admin7",
                Size = new Size(71, 13),
                Text = "7:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin7);

            ComboBox Combo_Admin7 = new ComboBox
            {
                Location = new Point(50, 310),
                Name = "Combo_Admin7",
                Size = new Size(80, 20),
            };
            Combo_Admin7.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin7);

            Label Lab_Admin8 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 335),
                Name = "Lab_Admin8",
                Size = new Size(71, 13),
                Text = "8:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin8);

            ComboBox Combo_Admin8 = new ComboBox
            {
                Location = new Point(50, 335),
                Name = "Combo_Admin8",
                Size = new Size(80, 20),
            };
            Combo_Admin8.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin8);

            Label Lab_Admin9 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 360),
                Name = "Lab_Admin9",
                Size = new Size(71, 13),
                Text = "9:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin9);

            ComboBox Combo_Admin9 = new ComboBox
            {
                Location = new Point(50, 360),
                Name = "Combo_Admin9",
                Size = new Size(80, 20),
            };
            Combo_Admin9.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin9);

            Label Lab_Admin10 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 385),
                Name = "Lab_Admin10",
                Size = new Size(71, 13),
                Text = "10:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin10);

            ComboBox Combo_Admin10 = new ComboBox
            {
                Location = new Point(50, 385),
                Name = "Combo_Admin10",
                Size = new Size(80, 20),
            };
            Combo_Admin10.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin10);

            Label Lab_Admin11 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 410),
                Name = "Lab_Admin11",
                Size = new Size(71, 13),
                Text = "11:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin11);

            ComboBox Combo_Admin11 = new ComboBox
            {
                Location = new Point(50, 410),
                Name = "Combo_Admin11",
                Size = new Size(80, 20),
            };
            Combo_Admin11.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin11);

            Label Lab_Admin12 = new Label
            {
                AutoSize = true,
                Location = new Point(20, 435),
                Name = "Lab_Admin12",
                Size = new Size(71, 13),
                Text = "12:",
            };
            gb_AdminFrozen.Controls.Add(Lab_Admin12);

            ComboBox Combo_Admin12 = new ComboBox
            {
                Location = new Point(50, 435),
                Name = "Combo_Admin12",
                Size = new Size(80, 20),
            };
            Combo_Admin12.Items.AddRange(ComboBoxItems);
            gb_AdminFrozen.Controls.Add(Combo_Admin12);

            Label Lab_AdminEleApp = new Label
            {
                AutoSize = true,
                Location = new Point(10, 460),
                Name = "Lab_AdminEleApp",
                Size = new Size(71, 13),
                Text = "Ele:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminEleApp);

            ComboBox Combo_AdminEleApp = new ComboBox
            {
                Location = new Point(50, 460),
                Name = "Combo_AdminEleApp",
                Size = new Size(80, 20),
            };
            Combo_AdminEleApp.Items.AddRange(ComboBoxItems2);
            gb_AdminFrozen.Controls.Add(Combo_AdminEleApp);

            Label Lab_AdminMechApp = new Label
            {
                AutoSize = true,
                Location = new Point(10, 485),
                Name = "Lab_AdminMechApp",
                Size = new Size(71, 13),
                Text = "Mech:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminMechApp);

            ComboBox Combo_AdminMechApp = new ComboBox
            {
                Location = new Point(50, 485),
                Name = "Combo_AdminMechApp",
                Size = new Size(80, 20),
            };
            Combo_AdminMechApp.Items.AddRange(ComboBoxItems2);
            gb_AdminFrozen.Controls.Add(Combo_AdminMechApp);

            Label Lab_AdminNVRApp = new Label
            {
                AutoSize = true,
                Location = new Point(10, 510),
                Name = "Lab_AdminMNVRApp",
                Size = new Size(71, 13),
                Text = "NVR:",
            };
            gb_AdminFrozen.Controls.Add(Lab_AdminNVRApp);

            ComboBox Combo_AdminNVRApp = new ComboBox
            {
                Location = new Point(50, 510),
                Name = "Combo_AdminNVRApp",
                Size = new Size(80, 20),
            };
            Combo_AdminNVRApp.Items.AddRange(ComboBoxItems2);
            gb_AdminFrozen.Controls.Add(Combo_AdminNVRApp);
        }

        private void Admin_Activator_Action()
        {
            GroupBox Gb_Activater_Action = new GroupBox
            {
                Location = new Point(220, 650),
                Size = new Size(200, 100),
                Name = "Gb_Activator_Action",
                TabStop = false,
                Text = "Action Activator",
            };
            tab_Admin.Controls.Add(Gb_Activater_Action);

            Button Pb_Activator_Action = new Button
            {
                Location = new Point(40, 20),
                Size = new Size(120, 30),
                Name = "Pb_Activator_Action",
                Text = "ActivatorAction",
            };
            Pb_Activator_Action.Click += new EventHandler(Pb_ActivatorAction_Click);
            Gb_Activater_Action.Controls.Add(Pb_Activator_Action);

            Button Pb_Deactivator_Action = new Button
            {
                Location = new Point(40, 60),
                Size = new Size(120, 30),
                Name = "Pb_Deactivator_Action",
                Text = "DeactivatorAction",
            };
            Pb_Deactivator_Action.Click += new EventHandler(Pb_DeactivatorAction_Click);
            Gb_Activater_Action.Controls.Add(Pb_Deactivator_Action);
        }

        private void Admin_CloneDataBase()
        {
            GroupBox gb_ColneDataBase = new GroupBox
            {
                Location = new Point(630, 515),
                Size = new Size(200, 60),
                Text = "Clone Data Base",
                Name = "gb_CloneDataBase",
            };
            tab_Admin.Controls.Add(gb_ColneDataBase);

            Button pb_CloneBase = new Button
            {
                Location = new Point(40, 20),
                Size = new Size(120, 20),
                Text = "Clone Data Base",
                Name = "pb_CloneBase",
            };
            pb_CloneBase.Click += new EventHandler(Pb_CloneBase_Click);
            gb_ColneDataBase.Controls.Add(pb_CloneBase);
        }
    }
}
