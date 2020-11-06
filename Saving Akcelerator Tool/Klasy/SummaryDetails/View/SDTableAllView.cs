using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    public partial class SDTableAllView : UserControl
    {
        public SDTableAllView()
        {
            InitializeComponent();
        }

        public void  InitializeData()
        {
            PrepateTable(dgv_ActualAction);
            PrepateTable(dgv_CarryOverAction);
        }

        public DataGridView ObjectTableActual()
        {
            return dgv_ActualAction;
        }

        public DataGridView ObjectTableCarryOver()
        {
            return dgv_CarryOverAction;
        }

        public bool GetSavings()
        {
            return cb_SDOptionSavings.Checked;
        }

        public bool GetQauntity()
        {
            return cb_SDOptionQuantity.Checked;
        }

        public bool GetECCC()
        {
            return cb_SDOptionECCC.Checked;
        }

        private void PrepateTable(DataGridView DGV)
        {
            DGV.Columns.Add("Name", "NameAction");
            DGV.Columns.Add("Option", "");
            DGV.Columns.Add("1", "I");
            DGV.Columns.Add("2", "II");
            DGV.Columns.Add("3", "III");
            DGV.Columns.Add("4", "IV");
            DGV.Columns.Add("5", "V");
            DGV.Columns.Add("6", "VI");
            DGV.Columns.Add("7", "VII");
            DGV.Columns.Add("8", "VIII");
            DGV.Columns.Add("9", "IX");
            DGV.Columns.Add("10", "X");
            DGV.Columns.Add("11", "XI");
            DGV.Columns.Add("12", "XII");
            DGV.Columns.Add("Sum", "Sum");

            for (int counter = 1; counter <= 12; counter++)
            {
                DGV.Columns[counter.ToString()].Width = 85;
            }
            DGV.Columns["Name"].Width = 300;
            DGV.Columns["Option"].Width = 50;
            DGV.Columns["Sum"].Width = 90;  //W zapasie 2 piksele które możana wykorzystać jeśli będzie miejsce

            DGV.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            DGV.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.DefaultCellStyle.Format = "#,0.###");
            DGV.ClearSelection();
        }

        private void SDOptionForTable_CheckChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SDTableLoad();
            Cursor.Current = Cursors.Default;
        }
    }
}
