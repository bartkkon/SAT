using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class History
    {
        private readonly Data_Import data_Import;

        public History()
        {

            data_Import = Data_Import.Singleton();
        }

        public void HistorySave()
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            string Link;

            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_SummaryDetailYear", true).First()).Value;

            Link = data_Import.Load_Link("Frozen");
            data_Import.Load_TxtToDataTable(ref Frozen, Link);

            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            if (FrozenRow != null)
            {
                if (FrozenRow["BU"].ToString() == "Open")
                {
                    DeleteRowFromHistory("BU", Year);
                    AddRowForHistory("BU", Year);
                }
                if (FrozenRow["EA1"].ToString() == "Open")
                {
                    DeleteRowFromHistory("EA1", Year);
                    AddRowForHistory("EA1", Year);
                }
                if (FrozenRow["EA2"].ToString() == "Open")
                {
                    DeleteRowFromHistory("EA2", Year);
                    AddRowForHistory("RA2", Year);
                }
                if (FrozenRow["EA3"].ToString() == "Open")
                {
                    DeleteRowFromHistory("EA3", Year);
                    AddRowForHistory("EA3", Year);
                }
                for (int counter = 1; counter < 13; counter++)
                {
                    if (FrozenRow[counter.ToString()].ToString() == "Open")
                    {
                        DeleteRowFromHistory(counter.ToString(), Year);
                        AddRowForHistory(counter.ToString(), Year);
                    }
                }
            }

        }

        private void DeleteRowFromHistory(string what, decimal Year)
        {
            DataTable Historia = new DataTable();
            DataRow[] ForDelete;
            string Link;

            Link = data_Import.Load_Link("History");
            data_Import.Load_TxtToDataTable(ref Historia, Link);

            ForDelete = Historia.Select(string.Format("History LIKE '%{0}%'", what + "/" + Year.ToString())).ToArray();

            if (ForDelete != null)
            {
                foreach (DataRow Delete in ForDelete)
                {
                    Historia.Rows.Remove(Delete);
                }
            }

            data_Import.Save_DataTableToTXT(ref Historia, Link);
        }

        private void AddRowForHistory(string What,decimal  Year)
        {
            DataTable Action = new DataTable();
            DataTable Historia = new DataTable();
            string LinkHistory;
            string LinkAction;

            LinkHistory = data_Import.Load_Link("History");
            LinkAction = data_Import.Load_Link("Action");
            data_Import.Load_TxtToDataTable(ref Historia, LinkHistory);
            data_Import.Load_TxtToDataTable(ref Action, LinkAction);

            DataColumn Col = Action.Columns.Add("History");
            Col.SetOrdinal(0);

            foreach(DataRow ActionRow in Action.Rows)
            {
                if(ActionRow["StartYear"].ToString() == Year.ToString() || ActionRow["StartYear"].ToString() == (Year-1).ToString() || ActionRow["StartYear"].ToString() == ("BU/"+Year).ToString())
                {
                    ActionRow["History"] = What + "/" + Year.ToString();
                    DataRow HistoriaNewRow = Historia.NewRow();
                    HistoriaNewRow.ItemArray = ActionRow.ItemArray;
                    Historia.Rows.Add(HistoriaNewRow);
                }
            }

            data_Import.Save_DataTableToTXT(ref Historia, LinkHistory);
        }
    }
}
