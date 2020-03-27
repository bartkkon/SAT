using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Model;
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
        public LoadAction(string ActionName, decimal Year)
        {
            _ = new ClearForm();
            _ = new ActionVerificationEnabled();

            ActionDB Action = ActionController.FindAction(ActionName, Convert.ToInt32(Year));

            _ = new ActionLoad(Action);

            ActionID.Delete();
            ActionID.Singleton.ID = Action.ID;
        }
        //private readonly string _actionName;
        //private readonly decimal _year;
        ////private readonly bool _carryOver;
        //private DataRow _Action;
        //public LoadAction(string ActionName, decimal Year)
        //{
        //    _actionName = ActionName;
        //    _year = Year;
        //    //_carryOver = CarryOver;

        //    FindAction();

        //    _ = new LoadActionToMemeory(_Action);
        //    _ = new LoadActionToForm();
        //    _ = new ActionVerificationEnabled();

        //}

        //private void FindAction()
        //{
        //    DataTable ActionList = new DataTable();
        //    DataRow[] FoundArry;

        //    Data_Import.Singleton().Load_TxtToDataTable2(ref ActionList, "Action");

        //    FoundArry = ActionList.Select(string.Format("Name LIKE '%{0}%'", _actionName)).ToArray();

        //    foreach (DataRow Row in FoundArry.Take(FoundArry.Length))
        //    {
        //        if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == _year.ToString())
        //        {
        //            _Action = Row;
        //            return;
        //        }
        //        else if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == (_year - 1).ToString())
        //        {
        //            _Action = Row;
        //            return;
        //        }
        //        else if (Row["Name"].ToString() == _actionName && Row["StartYear"].ToString() == "SA/" + _year.ToString())
        //        {
        //            _Action = Row;
        //            return;
        //        }
        //    }
        //}
    }
}
