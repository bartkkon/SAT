﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Saving_Accelerator_Tool
{
    class ModifiActionFormHendler
    {
        MainProgram mainProgram;
        Data_Import ImportData;
        TabPage Tab_AdminAction;
        string LinkAction;
        string LinkHistory;
        string LinkFrozen;
        string LinkAccess;
        string LinkKurs;
        string LinkSTK;

        public ModifiActionFormHendler(MainProgram mainProgram, Data_Import ImportData, TabPage Tab_AdminAction)
        {
            this.ImportData = ImportData;
            this.Tab_AdminAction = Tab_AdminAction;
            this.mainProgram = mainProgram;
            LinkHistory = ImportData.Load_Link("History");
            LinkAction = ImportData.Load_Link("Action");
            LinkFrozen = ImportData.Load_Link("Frozen");
            LinkAccess = ImportData.Load_Link("Access");
            LinkKurs = ImportData.Load_Link("Kurs");
            LinkSTK = ImportData.Load_Link("STK");
        }

        public void Pb_AdminAction_LoadSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkSTK);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkSTK);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadHistory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkHistory);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveHistory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkHistory);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadKursy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkKurs);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveKursy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkKurs);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkAction);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkAction);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadFrozen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkFrozen);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveFrozen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkFrozen);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadAccess_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(LinkAccess);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveAccess_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(LinkAccess);
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_ClearGrid_Click(object sender, EventArgs e)
        {
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();
            GroupBox Gb_AdminAction_NewColumn = (GroupBox)Tab_AdminAction.Controls.Find("Gb_AdminAction_NewColumn", true).First();

            Cursor.Current = Cursors.WaitCursor;

            //Dg_AdminActionGrid.Rows.Clear();
            //Dg_AdminActionGrid.Columns.Clear();
            Dg_AdminActionGrid.DataSource = null;
            Dg_AdminActionGrid.Refresh();
            Gb_AdminAction_NewColumn.Enabled = false;

            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_NewColumn_Click(object sender, EventArgs e)
        {
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();
            TextBox Tb_AdminAction_NewColumn = (TextBox)Tab_AdminAction.Controls.Find("Tb_AdminAction_NewColumn", true).First();
            NumericUpDown Num_AdminAction_NewColumn = (NumericUpDown)Tab_AdminAction.Controls.Find("Num_AdminAction_NewColumn", true).First();

            Cursor.Current = Cursors.WaitCursor;

            if (Tb_AdminAction_NewColumn.Text != "")
            {

                DataTable TableSource = (DataTable)Dg_AdminActionGrid.DataSource;
                DataColumn NewColumn = new DataColumn();
                NewColumn.ColumnName = Tb_AdminAction_NewColumn.Text;
                TableSource.Columns.Add(NewColumn);
                TableSource.Columns[Tb_AdminAction_NewColumn.Text].SetOrdinal(Decimal.ToInt32(Num_AdminAction_NewColumn.Value));

                Dg_AdminActionGrid.DataSource = TableSource;
            }

            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveToXML_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveToXML();
            Cursor.Current = Cursors.Default;
        }

        private void SaveToXML()
        {
            //Level1 level1 = new Level1(mainProgram, ImportData);
            //level1.Genereted_Level1();

            ReportingOption Report = new ReportingOption(mainProgram, ImportData, 2020);
            Report.ShowDialog();
        }

        private void LoadToDataGridView(string Link)
        {
            DataTable ActionTable = new DataTable();
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();
            GroupBox Gb_AdminAction_NewColumn = (GroupBox)Tab_AdminAction.Controls.Find("Gb_AdminAction_NewColumn", true).First();
            Label QuantityColumns = (Label)mainProgram.TabControl.Controls.Find("Lab_ColumnQuantity", true).First();

            ImportData.Load_TxtToDataTable(ref ActionTable, Link);
            Dg_AdminActionGrid.DataSource = ActionTable;
            foreach (DataGridViewColumn Column in Dg_AdminActionGrid.Columns)
            {
                Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Dg_AdminActionGrid.Columns[0].Frozen = true;
            Gb_AdminAction_NewColumn.Enabled = true;
            Dg_AdminActionGrid.AutoSize = true;
            QuantityColumns.Text = (Dg_AdminActionGrid.Columns.Count -1).ToString();
        }

        private void SaveFromDataGridView(string Link)
        {
            DataTable Actiontable = new DataTable();
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();

            Actiontable = (DataTable)(Dg_AdminActionGrid.DataSource);
            ImportData.Save_DataTableToTXT(ref Actiontable, Link);
        }
    }
}
