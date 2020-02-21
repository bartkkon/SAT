using Saving_Accelerator_Tool.Klasy.ActionTab.View;
using Saving_Accelerator_Tool.Klasy.Acton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class SaveActionFromForm
    {
        private readonly CopyAction _action;
        private readonly ActionView _display;
        public SaveActionFromForm()
        {
            _action = CopyAction.Value;
            _display = MainProgram.Self.actionView;

            NameViewSave();
            StateViewSave();
            PlatformInstalationSave();
            ECCCSave();
            CalculatioBySave();
            PNCEstymationSave();
            ANCChangeSave();
            STKChangeSave();
            NextANCSave();
            CalculationGroupSave();

            if (new CheckIfEqual().Check())
            {
                
            }
        }

        private void CalculationGroupSave()
        {
            _action.Calc = _display.CalculationGroup.GetANCby();
            _action.CalcMass = _display.CalculationGroup.GetMass();
        }

        private void NextANCSave()
        {
            _action.Next = _display.NextANC.GetNext1(_action.IloscANC);
            _action.Next2 = _display.NextANC.GetNext2(_action.IloscANC);
        }

        private void STKChangeSave()
        {
            _action.OldSTK = _display.StkChange.GetOldSTK(_action.IloscANC);
            _action.NewSTK = _display.StkChange.GetNewSTK(_action.IloscANC);
            _action.Delta = _display.StkChange.GetDeltaSTK(_action.IloscANC);
            _action.STKEst = _display.StkChange.GetEstimationSTK(_action.IloscANC);
            _action.Percent = _display.StkChange.GetPercentSTK(_action.IloscANC);
            _action.STKCal = _display.StkChange.GetCalcSTK(_action.IloscANC);
        }

        private void ANCChangeSave()
        {
            _action.OldANC = _display.ANCChangeView.GetANC(_action.IloscANC, false);
            _action.OldANCQ = _display.ANCChangeView.GetQuantity(_action.IloscANC, false);
            _action.NewANC = _display.ANCChangeView.GetANC(_action.IloscANC, true);
            _action.NewANCQ = _display.ANCChangeView.GetQuantity(_action.IloscANC, true);
        }

        private void PNCEstymationSave()
        {
            _action.PNCEstyma = _display.PNCSpecialEstymationView.GetPNCEstymation();
        }

        private void CalculatioBySave()
        {
            _action.Calculate = _display.calculationByView.GetCalcMethod();
        }

        private void ECCCSave()
        {
            _action.ECCC = _display.ecccView.GetECCC();
        }

        private void PlatformInstalationSave()
        {
            _action.Platform = _display.platformView.GetPlatform();
            _action.Installation = _display.installationView.GetInstallation();
        }

        private void StateViewSave()
        {
            _action.Status = _display.stateView.GetActionIdea();
            _action.StartYear = _display.stateView.GetYear();
            _action.Factory = _display.stateView.GetFactory();
            _action.Group = _display.stateView.GetDevison();
            _action.Leader = _display.stateView.GetLeader();
            _action.StartMonth = _display.stateView.GetStartMonth();
        }

        private void NameViewSave()
        {
            _action.Name = _display.nameView.GetActionName();
            _action.Description = _display.nameView.GetDescription();
        }
    }
}
