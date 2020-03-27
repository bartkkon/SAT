using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save
{
    class PNCSave
    {
        public static IEnumerable<PNCListDB> Save()
        {
            List<PNCListDB> PNCList = new List<PNCListDB>();

            DataGridView PNCTable = MainProgram.Self.actionView.PNCListView.GetTable();

            foreach(DataGridViewRow PNCRow in PNCTable.Rows)
            {
                PNCListDB NewRow = new PNCListDB
                {
                    List = PNCRow.Cells["PNC"].Value.ToString(),
                    Active = true,
                    ChangeBy = Environment.UserName.ToLower(),
                    ChangeTime = DateTime.UtcNow,
                };
                PNCList.Add(NewRow);
            }


            return PNCList;
        }
    }
}
