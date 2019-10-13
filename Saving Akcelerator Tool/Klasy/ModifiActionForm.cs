using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool
{
    class ModifiActionForm : ModifiActionFormHendler
    {
        Data_Import ImportData;
        TabPage AdminAction;
        MainProgram mainProgram;

        public ModifiActionForm(MainProgram mainProgram, TabPage AdminAction, Data_Import data_Import) : base(mainProgram ,data_Import, AdminAction)
        {
            ImportData = data_Import;
            this.AdminAction = AdminAction;
            this.mainProgram = mainProgram;

            ModifiActionFormBuild();
        }

        private void ModifiActionFormBuild()
        {
            ModifiActionTopPanel();
            ModifiActionGridPanel();
        }

        private void ModifiActionTopPanel()
        {
            Panel PanelTop = new Panel
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Location = new System.Drawing.Point(0, 0),
                Name = "AdminAction_PanelTop",
                Size = new System.Drawing.Size(307, 150),
                TabIndex = 0
            };
            AdminAction.Controls.Add(PanelTop);

            GroupBox Gb_AdminAction_Top = new GroupBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "Gb_AdminAction_Top",
                Text = "",
                Size = new System.Drawing.Size(307, 150),
            };
            PanelTop.Controls.Add(Gb_AdminAction_Top);

            // Przyciski do ładowania i zapisu dla Bazy danych z Akcjami
            ModifiAction_Action(Gb_AdminAction_Top);

            //Przycisk do ładowania i zapisu dla Bazy Frozzen
            ModifiAction_Frozzen(Gb_AdminAction_Top);

            //Przycisk do ładowania i zapisu dla Bazy Access
            ModifiAction_Access(Gb_AdminAction_Top);

            //Przyciski do ładowania i zapisu dla Bazy STK
            ModifiAction_STK(Gb_AdminAction_Top);

            //Przyciski do ładowania i zapisu dla Bazy Kursy
            ModifiAction_Kursy(Gb_AdminAction_Top);

            //Przyciski do ładowania i zapisu dla Bazy History
            ModifAction_History(Gb_AdminAction_Top);

            //Export to XML
            SaveToXML(Gb_AdminAction_Top);

            //Przycisk czyszczenia DataGridView

            Button Pb_AdminAction_ClearGrid = new Button
            {
                Location = new System.Drawing.Point(10, 90),
                Name = "Pb_AdminAction_ClearGrid",
                Text = "Clear Grid",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_ClearGrid.Click += new EventHandler(Pb_AdminAction_ClearGrid_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_ClearGrid);

            ModifiActionAddColumn(Gb_AdminAction_Top);
        }

        private void ModifAction_History(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadHistory = new Button
            {
                Location = new System.Drawing.Point(460, 10),
                Name = "Pb_AdminAction_LoadHistory",
                Text = "Load History",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadHistory.Click += new EventHandler(Pb_AdminAction_LoadHistory_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadHistory);

            Button Pb_AdminAction_SaveHistory = new Button
            {
                Location = new System.Drawing.Point(460, 50),
                Name = "Pb_AdminAction_SaveHistory",
                Text = "Save Hisotry",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveHistory.Click += new EventHandler(Pb_AdminAction_SaveHistory_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveHistory);
        }

        private void ModifiAction_STK(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadSTK = new Button
            {
                Location = new System.Drawing.Point(370, 10),
                Name = "Pb_AdminAction_LoadKursy",
                Text = "Load STK",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadSTK.Click += new EventHandler(Pb_AdminAction_LoadSTK_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadSTK);

            Button Pb_AdminAction_SaveSTK = new Button
            {
                Location = new System.Drawing.Point(370, 50),
                Name = "Pb_AdminAction_SaveSTK",
                Text = "Save STK",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveSTK.Click += new EventHandler(Pb_AdminAction_SaveSTK_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveSTK);
        }

        private void ModifiAction_Kursy(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadKursy = new Button
            {
                Location = new System.Drawing.Point(280, 10),
                Name = "Pb_AdminAction_LoadSTK",
                Text = "Load Kursy",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadKursy.Click += new EventHandler(Pb_AdminAction_LoadKursy_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadKursy);

            Button Pb_AdminAction_SaveKursy = new Button
            {
                Location = new System.Drawing.Point(280, 50),
                Name = "Pb_AdminAction_SaveKursy",
                Text = "Save Kursy",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveKursy.Click += new EventHandler(Pb_AdminAction_SaveKursy_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveKursy);
        }

        private void ModifiAction_Access(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadAccess = new Button
            {
                Location = new System.Drawing.Point(190, 10),
                Name = "Pb_AdminAction_LoadAccess",
                Text = "Load Access",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadAccess.Click += new EventHandler(Pb_AdminAction_LoadAccess_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadAccess);

            Button Pb_AdminAction_SaveAccess = new Button
            {
                Location = new System.Drawing.Point(190, 50),
                Name = "Pb_AdminAction_SaveAccess",
                Text = "Save Access",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveAccess.Click += new EventHandler(Pb_AdminAction_SaveAccess_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveAccess);
        }

        private void ModifiAction_Frozzen(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadFrozen = new Button
            {
                Location = new System.Drawing.Point(100, 10),
                Name = "Pb_AdminAction_LoadFrozen",
                Text = "Load Frozen",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadFrozen.Click += new EventHandler(Pb_AdminAction_LoadFrozen_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadFrozen);

            Button Pb_AdminAction_SaveFrozen = new Button
            {
                Location = new System.Drawing.Point(100, 50),
                Name = "Pb_AdminAction_SaveFrozen",
                Text = "Save Frozen",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveFrozen.Click += new EventHandler(Pb_AdminAction_SaveFrozen_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveFrozen);
        }

        private void ModifiAction_Action(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_LoadAction = new Button
            {
                Location = new System.Drawing.Point(10, 10),
                Name = "Pb_AdminAction_LoadAction",
                Text = "Load Action",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_LoadAction.Click += new EventHandler(Pb_AdminAction_LoadAction_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_LoadAction);

            Button Pb_AdminAction_SaveAction = new Button
            {
                Location = new System.Drawing.Point(10, 50),
                Name = "Pb_AdminAction_SaveAction",
                Text = "Save Action",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_SaveAction.Click += new EventHandler(Pb_AdminAction_SaveAction_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveAction);
        }

        private void SaveToXML(GroupBox Gb_AdminAction_Top)
        {
            Button Pb_AdminAction_SaveToXML = new Button
            {
                Location = new System.Drawing.Point(1600, 10),
                Name = "Pb_AdminAction_SaveToXML",
                Text = "Save To XML",
                Size = new System.Drawing.Size(120, 30),
            };
            Pb_AdminAction_SaveToXML.Click += new EventHandler(Pb_AdminAction_SaveToXML_Click);
            Gb_AdminAction_Top.Controls.Add(Pb_AdminAction_SaveToXML);
        }

        private void ModifiActionGridPanel()
        {
            Panel PanelGrid = new Panel
            {
                //Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 150),
                Name = "AdminAction_PanelGrid",
                Size = new System.Drawing.Size(1910, 820),
                TabIndex = 0
            };
            AdminAction.Controls.Add(PanelGrid);

            DataGridView Dg_AdminAction = new DataGridView
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "Dg_AdminActionGrid",
                Size = new System.Drawing.Size(10, 10),
            };
            PanelGrid.Controls.Add(Dg_AdminAction);
        }

        private void ModifiActionAddColumn(GroupBox Gb_AdminAction_Top)
        {
            GroupBox Gb_AdminAction_NewColumn = new GroupBox
            {
                Location = new System.Drawing.Point(1750, 0),
                Name = "Gb_AdminAction_NewColumn",
                Text = "",
                Size = new System.Drawing.Size(160, 150),
                Enabled = false,
            };
            Gb_AdminAction_Top.Controls.Add(Gb_AdminAction_NewColumn);

            Label Lab_AdminAction_NewColumn = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Name = "Lab_AdminAction_NewColumn",
                Text = "Add kolumn:",
                Size = new System.Drawing.Size(50, 20),
                AutoSize = true,
            };
            Gb_AdminAction_NewColumn.Controls.Add(Lab_AdminAction_NewColumn);

            TextBox Tb_AdminAction_NewColumn = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Name = "Tb_AdminAction_newColumn",
                Text = "",
                Size = new System.Drawing.Size(100, 20),
            };
            Gb_AdminAction_NewColumn.Controls.Add(Tb_AdminAction_NewColumn);

            NumericUpDown Num_AdminAction_NewColumn = new NumericUpDown
            {
                Location = new System.Drawing.Point(10, 70),
                Name = "Num_AdminAction_NewColumn",
                Size = new System.Drawing.Size(40, 20),
                Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0}),
                Value = 1,
               
            };
            Gb_AdminAction_NewColumn.Controls.Add(Num_AdminAction_NewColumn);

            Label Lab_ColumnQuantity = new Label
            {
                Name = "Lab_ColumnQuantity",
                Text = "",
                Location = new System.Drawing.Point(60, 70),
                Size = new System.Drawing.Size(40, 20),
            };
            Gb_AdminAction_NewColumn.Controls.Add(Lab_ColumnQuantity);

            Button Pb_AdminAction_NewColumn = new Button
            {
                Location = new System.Drawing.Point(10, 100),
                Name = "Pb_AdminAction_NewColumn",
                Text = "Add Column",
                Size = new System.Drawing.Size(80, 30),
            };
            Pb_AdminAction_NewColumn.Click += new EventHandler(Pb_AdminAction_NewColumn_Click);
            Gb_AdminAction_NewColumn.Controls.Add(Pb_AdminAction_NewColumn);
        }
    }
}
