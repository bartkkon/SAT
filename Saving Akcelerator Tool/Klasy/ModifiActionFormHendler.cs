using System;
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
        private readonly TabPage Tab_AdminAction;

        public ModifiActionFormHendler(TabPage Tab_AdminAction)
        {
            this.Tab_AdminAction = Tab_AdminAction;
        }

        public void Pb_AdminAction_LoadSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("STK"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveSTK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("STK"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadHistory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("History"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveHistory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("History"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadKursy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("Kurs"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveKursy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("Kurs"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("Action"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveAction_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("Action"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadFrozen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("Frozen"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveFrozen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("Frozen"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_LoadAccess_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadToDataGridView(Data_Import.Singleton().Load_Link("Access"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_SaveAccess_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFromDataGridView(Data_Import.Singleton().Load_Link("Access"));
            Cursor.Current = Cursors.Default;
        }

        public void Pb_AdminAction_ClearGrid_Click(object sender, EventArgs e)
        {
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();
            GroupBox Gb_AdminAction_NewColumn = (GroupBox)Tab_AdminAction.Controls.Find("Gb_AdminAction_NewColumn", true).First();

            Cursor.Current = Cursors.WaitCursor;

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
                DataColumn NewColumn = new DataColumn
                {
                    ColumnName = Tb_AdminAction_NewColumn.Text
                };
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
            ReportingOption Report = new ReportingOption();
            Report.ShowDialog();
        }

        private void LoadToDataGridView(string Link)
        {
            DataTable ActionTable = new DataTable();
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();
            GroupBox Gb_AdminAction_NewColumn = (GroupBox)Tab_AdminAction.Controls.Find("Gb_AdminAction_NewColumn", true).First();
            Label QuantityColumns = (Label)MainProgram.Self.TabControl.Controls.Find("Lab_ColumnQuantity", true).First();

            Data_Import.Singleton().Load_TxtToDataTable(ref ActionTable, Link);
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
            DataTable Actiontable;
            DataGridView Dg_AdminActionGrid = (DataGridView)Tab_AdminAction.Controls.Find("Dg_AdminActionGrid", true).First();

            Actiontable = (DataTable)(Dg_AdminActionGrid.DataSource);
            Data_Import.Singleton().Save_DataTableToTXT(ref Actiontable, Link);
        }
    }
}
