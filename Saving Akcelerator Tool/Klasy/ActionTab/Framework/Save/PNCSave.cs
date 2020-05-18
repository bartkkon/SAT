using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Data;
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

            DataTable PNC= MainProgram.Self.actionView.PNCListView.GetDataTable();

            foreach(DataRow PNCRow in PNC.Rows)
            {
                PNCListDB NewRow = new PNCListDB
                {
                    List = PNCRow["PNC"].ToString(),
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
