using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save
{
    class ActionSave
    {
        public static ActionDB Save()
        {
            ActionDB ActionToSave = new ActionDB();
            var ActionForm = MainProgram.Self.actionView;

            ActionToSave.Name = ActionForm.nameView.GetActionName();
            ActionToSave.Description = ActionForm.nameView.GetDescription();

            if (ActionForm.stateView.GetActive())
                ActionToSave.Status = "Active";
            if (ActionForm.stateView.GetIdea())
                ActionToSave.Status = "Idea";

            ActionToSave.Group = ActionForm.stateView.GetDevison();
            ActionToSave.Devision = ActionForm.stateView.GetDevison();
            ActionToSave.Factory = ActionForm.stateView.GetFactory();
            ActionToSave.Leader = ActionForm.stateView.GetLeader();

            ActionToSave.StartYear = Convert.ToInt32(ActionForm.stateView.GetYear());
            ActionToSave.MonthStart = ActionForm.stateView.GetStartMonth();

            //Platform and Instalation

            ActionToSave.Platform_DMD = ActionForm.platformView.GetDMD();
            ActionToSave.Platform_D45 = ActionForm.platformView.GetD45();

            ActionToSave.Installation_FS = ActionForm.installationView.GetFS();
            ActionToSave.Installation_FI = ActionForm.installationView.GetFI();
            ActionToSave.Installation_BI = ActionForm.installationView.GetBI();
            ActionToSave.Installation_FSBU = ActionForm.installationView.GetFSBU();

            //Sposób kalkulacji
            ActionToSave.ANC = ActionForm.calculationByView.GetANC();
            ActionToSave.ANCSpec = ActionForm.calculationByView.GetANCSpec();
            ActionToSave.PNC = ActionForm.calculationByView.GetPNC();
            ActionToSave.PNCSpec = ActionForm.calculationByView.GetPNCSpec();

            //ECCC
            ActionToSave.ECCC = ActionForm.ecccView.GetECCC();
            ActionToSave.ECCC_Sec = Convert.ToDouble(ActionForm.ecccView.GetECCCSec());
            ActionToSave.ECCC_PNCSpec = ActionForm.ecccView.GetECCCSpec();

            //Calcby ANC or MAss
            ActionToSave.ANC_Calc = ActionForm.CalculationGroup.GetANCbyGroup();
            ActionToSave.Group_Calc = ActionForm.CalculationGroup.GetMassGroup();

            //PNC Special Estymation
            ActionToSave.PNCSpec_Estimation = Convert.ToDouble(ActionForm.PNCSpecialEstymationView.GetPNCEstymation());


            //Revision info
            ActionToSave.Active = true;
            ActionToSave.ChangeBy = Environment.UserName.ToLower();
            ActionToSave.ChangeTime = DateTime.UtcNow;

            return ActionToSave;
        }
    }
}
