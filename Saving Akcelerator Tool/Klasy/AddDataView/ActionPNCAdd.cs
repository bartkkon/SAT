using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AddDataView
{
    class ActionPNCAdd
    {
        public static bool Load(string[] NewValue)
        {
            var PNCList = MainProgram.Self.actionView.PNCListView;
            DataTable PNCTable = PNCList.GetDataTable();

            if (PNCTable.Columns.Count == 0)
            {
                PNCTable.Columns.Add("PNC");
            }

            if (PNCTable.Rows.Count > 0)
            {
                DialogResult Result = MessageBox.Show("Do you want replease exist PNC List?", "Warning!", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    PNCTable.Rows.Clear();
                }
                else
                {
                    DialogResult Result2 = MessageBox.Show("Do you want Add to exist PNC List?", "Warning!", MessageBoxButtons.YesNo);
                    if (Result2 == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            foreach (string PNC in NewValue)
            {
                if (PNC != string.Empty && PNC.Length == 9)
                {
                    DataRow NewRow = PNCTable.NewRow();
                    NewRow["PNC"] = PNC;
                    PNCTable.Rows.Add(NewRow);
                }
            }
            DataTable PNCListDup = PNCTable.Clone();

            int DuplicatCount = 0;
            foreach (DataRow Row in PNCTable.Rows)
            {
                if(PNCListDup.AsEnumerable().Where(u => u.Field<string>("PNC").Equals(Row["PNC"].ToString())).Count() == 0)
                {
                    PNCListDup.Rows.Add(Row.ItemArray);
                }
                else
                {
                    DuplicatCount++;
                }
            }

            if(DuplicatCount !=0)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Duplicates have beed removed, in numbers: " + DuplicatCount.ToString() + ".", "Information");
                Cursor.Current = Cursors.WaitCursor;
            }

            PNCList.SetPNC(PNCListDup);
            return true;
        }
    }
}
