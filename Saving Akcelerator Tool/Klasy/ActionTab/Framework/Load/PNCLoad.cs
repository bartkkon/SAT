using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load
{
    class PNCLoad
    {
        public static void Load(int ID)
        {
            IEnumerable<PNCListDB> PNCBase = PNCListController.Load(ID);
            DataTable PNCList = new DataTable();

            PNCList.Columns.Add("PNC");

            foreach(PNCListDB PNC in PNCBase)
            {
                DataRow NewRow = PNCList.NewRow();
                NewRow["PNC"] = PNC.List;
                PNCList.Rows.Add(NewRow);
            }

            MainProgram.Self.actionView.PNCListView.SetPNC(PNCList);
        }
    }
}
