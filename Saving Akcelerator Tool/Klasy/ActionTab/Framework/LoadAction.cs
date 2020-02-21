using Saving_Accelerator_Tool.Klasy.Acton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class LoadAction
    {
        private readonly string _actionName;
        private readonly decimal _year;
        //private readonly bool _carryOver;
        private DataRow _Action;
        public LoadAction(string ActionName, decimal Year)
        {
            _actionName = ActionName;
            _year = Year;
            //_carryOver = CarryOver;

            FindAction();

            _ = new LoadActionToMemeory(_Action);
            _ = new LoadActionToForm();


        }

        private void FindAction()
        {
            DataTable ActionList = new DataTable();
            DataRow[] FoundArry;

            Data_Import.Singleton().Load_TxtToDataTable2(ref ActionList, "Action");

            FoundArry = ActionList.Select(string.Format("Name LIKE '%{0}%'", _actionName)).ToArray();

            foreach (DataRow Row in FoundArry.Take(FoundArry.Length))
            {
                if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == _year.ToString())
                {
                    _Action = Row;
                    return;
                }
                else if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == (_year - 1).ToString())
                {
                    _Action = Row;
                    return;
                }
                else if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == "SA/" + _year.ToString())
                {
                    _Action = Row;
                    return;
                }
            }
        }
    }
}
