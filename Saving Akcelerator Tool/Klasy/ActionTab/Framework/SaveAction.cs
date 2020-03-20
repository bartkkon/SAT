using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class SaveAction
    {
        private readonly ActionDB _OriginalAction;
        private readonly ActionDB _CurrentAction;
        public SaveAction()
        {
            if (ActionID.Singleton.ID != 0)
            {
                _OriginalAction = ActionController.Load_ID(ActionID.Singleton.ID);
                _CurrentAction.ID = ActionID.Singleton.ID;
            }
            else
            {
                //NewAction
            }

            CurrentActionGenereted();
        }

        private void CurrentActionGenereted()
        {
            var Action = MainProgram.Self.actionView;

            _CurrentAction.Name = Action.nameView.GetActionName();
            _CurrentAction.Description = Action.nameView.GetDescription();
            _CurrentAction.Group = Action.stateView.GetDevison();

            if (Action.stateView.GetActive())
                _CurrentAction.Status = "Active";
            if (Action.stateView.GetIdea())
                _CurrentAction.Status = "Idea";

            _CurrentAction.Factory = Action.stateView.GetFactory();
            _CurrentAction.MonthStart = Action.stateView.GetStartMonth();
            _CurrentAction.Leader = Action.stateView.GetLeader();
            _CurrentAction.StartYear = Convert.ToInt32(Action.stateView.GetYear());

            //StatusYear do zrobienia

            _CurrentAction.Platform_DMD = Action.platformView.GetDMD();
            _CurrentAction.Platform_D45 = Action.platformView.GetD45();

            _CurrentAction.Installation_FS = Action.installationView.GetFS();
            _CurrentAction.Installation_FI = Action.installationView.GetFI();
            _CurrentAction.Installation_BI = Action.installationView.GetBI();
            _CurrentAction.Installation_FSBU = Action.installationView.GetFSBU();

            _CurrentAction.ANC = Action.calculationByView.GetANC();
            _CurrentAction.ANCSpec = Action.calculationByView.GetANCSpec();
            _CurrentAction.PNC = Action.calculationByView.GetPNC();
            _CurrentAction.PNCSpec = Action.calculationByView.GetPNCSpec();

            _CurrentAction.ECCC = Action.ecccView.GetECCC();
            _CurrentAction.ECCC_PNCSpec = Action.ecccView.GetECCCSpec();
            _CurrentAction.ECCC_Sec = Convert.ToDouble(Action.ecccView.GetECCCSec());

            _CurrentAction.PNCSpec_Estimation = Convert.ToDouble(Action.PNCSpecialEstymationView.GetPNCEstymation());

        }
    }
}
