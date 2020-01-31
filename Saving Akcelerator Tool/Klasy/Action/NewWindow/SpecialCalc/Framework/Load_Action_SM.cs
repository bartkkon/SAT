using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Action.NewWindow.SpecialCalc.Framework
{
    public class Load_Action_SM
    {
        private readonly string _ActionName;
        private readonly decimal _Year;
        public Load_Action_SM(string ActionName, decimal Year)
        {
            _ActionName = ActionName;
            _Year = Year;

        }

        public DataRow Load()
        {
            DataTable AllAction = new DataTable();
            DataRow[] FoundRows;
            DataRow FoundRow;

            Data_Import.Singleton().Load_TxtToDataTable2(ref AllAction, "Action");

            FoundRow = AllAction.NewRow();

            FoundRows = AllAction.Select(string.Format("Name LIKE '%{0}%'", _ActionName)).ToArray();

            foreach (DataRow Row in FoundRows)
            {
                if (Row["StartYear"].ToString() == _Year.ToString() || Row["StartYear"].ToString() == "SA/" + _Year.ToString())
                {
                    FoundRow.ItemArray = Row.ItemArray.Clone() as object[];
                    return FoundRow;
                }
            }

            return FoundRow;
        }
    }
}
