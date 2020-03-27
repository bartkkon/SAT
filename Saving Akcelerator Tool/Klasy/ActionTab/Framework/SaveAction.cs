using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Model;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class SaveAction
    {
        private readonly ActionDB OriginalAction;
        public SaveAction()
        {
            if (ActionID.Singleton.ID != 0)
            {
                ActionDB NewAction;
                OriginalAction = ActionController.Load_ID(ActionID.Singleton.ID);
                NewAction = ActionSave.Save();

                if (ActionID.Singleton.ActionModification)
                {
                    ActionController.ModificationAction(OriginalAction, NewAction);
                    ActionID.Delete();
                    ActionID.Singleton.ID = NewAction.ID;
                }
                if(ActionID.Singleton.ANCModification)
                {

                }

                
                //OriginalAction = ActionController.
            }

            else
            {
                ActionDB ActionToSave = ActionSave.Save();
                ActionToSave.Rev = 1;
                ActionToSave.ActionIDOriginal = 0;
                ActionController.NewAction(ActionToSave);
                OriginalAction = ActionController.FindAction(ActionToSave.Name, ActionToSave.StartYear);

                //IEnumerable<ANCChangeDB> ListANC = ANCChangeSave.ANCSave();
                //foreach(var ANC in ListANC)
                //{
                //    ANC.ActionID = OriginalAction.ID;
                //    ANC.Rev = 1;
                //}
                //ANCChangeController.Add(ListANC);

                //if (OriginalAction.ANCSpec)
                //{
                //    CalculationMassDB MassList = CalculationMassSave.Mass();
                //    MassList.ActionID = OriginalAction.ID;
                //    MassList.Rev = 1;
                //    CalculationMassController.Add(MassList);
                //}
                //else if(OriginalAction.PNC)
                //{
                //    IEnumerable<PNCListDB> PNCList = PNCSave.Save();
                //    foreach(var Row in PNCList)
                //    {
                //        Row.ActionID = OriginalAction.ID;
                //        Row.Rev = 1;
                //    }
                //}
                //else if(OriginalAction.PNCSpec)
                //{
                //    IEnumerable<PNCSpecialDB> PNCSpecialList = PNCSpecialSave.Save();
                //    foreach(var Row in PNCSpecialList)
                //    {
                //        Row.ActionID = OriginalAction.ID;
                //        Row.Rev = 1;
                //    }
                //}
            }
        }
    }
}
