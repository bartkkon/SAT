using Saving_Accelerator_Tool.Klasy.ActionTab.View;
using Saving_Accelerator_Tool.Klasy.ActionTab.View.Action;
using Saving_Accelerator_Tool.Klasy.Acton;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class LoadActionToForm
    {
        private readonly CopyAction _action;
        public LoadActionToForm()
        {
            _action = CopyAction.Value;

            _ = new ClearForm();



            NameViewUpdate();
            StateViewUpdate();
            PlatformInstallation();
            ECCCUpdate();
            CalculationbyUpdate();
            PNCEstymUpdate();
            ANCChangeUpdate();
            STKChangeUpdate();
            NextChangeUpdate();
            QuantityPercentChangeUpdate();
            CalculationGroupUpdate();
            SavingsLoadUpdate();
            PNCListUpdate();
        }

        private void PNCListUpdate()
        {
            var PNC = MainProgram.Self.actionView.PNCListView;

            if(_action.Calculate == "PNC")
            {
                PNC.SetPNC(_action.PNC);
            }
            else if(_action.Calculate == "PNCSpec")
            {
                PNC.SetPNCSpec(_action.PNC, _action.PNCANC, _action.PNCANCQ, _action.PNCSTK, _action.PNCDelta, _action.PNCSumSTK, _action.PNCSumDelta, _action.ECCC);
            }
        }

        private void SavingsLoadUpdate()
        {
            var Savings = MainProgram.Self.actionView.SavingsTable;

            if (_action.StartYear == MainProgram.Self.treeActionView.GetYear())
            {
                Savings.SetData("Savings", _action.CalcUSESaving, _action.CalcBUSaving, _action.CalcEA1Saving, _action.CalcEA2Saving, _action.CalcEA3Saving);
                Savings.SetData("Quantity", _action.CalcUSEQuantity, _action.CalcBUQuantity, _action.CalcEA1Quantity, _action.CalcEA2Quantity, _action.CalcEA3Quantity);
                Savings.SetData("ECCC", _action.CalcUSEECCC, _action.CalcBUECCC, _action.CalcEA1ECCC, _action.CalcEA2ECCC, _action.CalcEA3ECCC);
                Savings.SetButton("CurrentYear");
            }
            else
            {
                Savings.SetData("Savings", _action.CalcUSESavingCarry, _action.CalcBUSavingCarry, _action.CalcEA1SavingCarry, _action.CalcEA2SavingCarry, _action.CalcEA3SavingCarry);
                Savings.SetData("Quantity", _action.CalcUSEQuantityCarry, _action.CalcBUQuantityCarry, _action.CalcEA1QuantityCarry, _action.CalcEA2QuantityCarry, _action.CalcEA3QuantityCarry);
                Savings.SetData("ECCC", _action.CalcUSEECCCCarry, _action.CalcBUECCCCarry, _action.CalcEA1ECCCCarry, _action.CalcEA2ECCCCarry, _action.CalcEA3ECCCCarry);
                Savings.SetButton("CarryOver");
            }
        }

        private void CalculationGroupUpdate()
        {
            MainProgram.Self.actionView.CalculationGroup.SetData(_action.Calc, _action.CalcMass);
        }

        private void QuantityPercentChangeUpdate()
        {
            MainProgram.Self.actionView.QunatityPercent.SetValue(_action.PNCANCPersent);
        }

        private void NextChangeUpdate()
        {
            var Next = MainProgram.Self.actionView.NextANC;

            Next.SetData(_action.Next, _action.Next2);
        }

        private void STKChangeUpdate()
        {
            var STK = MainProgram.Self.actionView.StkChange;

            STK.SetData(_action.IloscANC, _action.OldSTK, _action.NewSTK, _action.Delta, _action.STKEst, _action.Percent, _action.STKCal);
        }

        private void ANCChangeUpdate()
        {
            var ANCChange = MainProgram.Self.actionView.ANCChangeView;

            ANCChange.SetVisibleANC(_action.IloscANC);
            ANCChange.SetANC(_action.OldANC, _action.IloscANC, false);
            ANCChange.SetANCQ(_action.OldANCQ, _action.IloscANC, false);
            ANCChange.SetANC(_action.NewANC, _action.IloscANC, true);
            ANCChange.SetANCQ(_action.NewANCQ, _action.IloscANC, true);
        }

        private void PNCEstymUpdate()
        {
            var PNCEsty = MainProgram.Self.actionView.PNCSpecialEstymationView;

            PNCEsty.SetPNCEstymation(_action.PNCEstyma.ToString());
        }

        private void CalculationbyUpdate()
        {
            var CalcBy = MainProgram.Self.actionView.calculationByView;

            CalcBy.SetCalcMethod(_action.Calculate);
        }

        private void ECCCUpdate()
        {
            var ECCC = MainProgram.Self.actionView.ecccView;

            ECCC.SetECCC2(_action.ECCC);
        }

        private void PlatformInstallation()
        {
            var Platform = MainProgram.Self.actionView.platformView;
            var Installation = MainProgram.Self.actionView.installationView;

            Platform.SetPlatform(_action.Platform);
            Installation.SetInstallation(_action.Installation);
        }

        private void StateViewUpdate()
        {
            var StateView = MainProgram.Self.actionView.stateView;

            if (_action.Status == "Active")
                StateView.SetActive();
            else if (_action.Status == "Idea")
                StateView.SetIdea();
            StateView.SetYear(_action.StartYear);
            StateView.SetFactory(_action.Factory);
            StateView.SetDevision(_action.Group);
            StateView.SetLeader(_action.Leader);
            StateView.SetStartMonth(_action.StartMonth);
        }

        private void NameViewUpdate()
        {
            var NameView = MainProgram.Self.actionView.nameView;

            NameView.ActionNameChange(_action.Name);
            MainProgram.Self.actionView.SetActionName(_action.Name);
            NameView.Description(_action.Description);
        }
    }
}