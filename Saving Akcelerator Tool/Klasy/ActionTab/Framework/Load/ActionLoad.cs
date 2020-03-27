using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load
{
    class ActionLoad
    {
        public ActionLoad(ActionDB Action)
        {
            var ActionView = MainProgram.Self.actionView;

            ActionView.nameView.ActionNameChange(Action.Name);
            ActionView.nameView.Description(Action.Description);

            // StateView
            ActionView.stateView.SetActionIdea(Action.Status);
            ActionView.stateView.SetYear(Convert.ToDecimal(Action.StartYear));
            ActionView.stateView.SetStartMonth(Action.MonthStart);
            ActionView.stateView.SetFactory(Action.Factory);
            ActionView.stateView.SetLeader(Action.Leader);
            ActionView.stateView.SetDevision(Action.Devision);

            //Platform
            ActionView.platformView.SetDMD(Action.Platform_DMD);
            ActionView.platformView.SetD45(Action.Platform_D45);

            //Installation
            ActionView.installationView.SetBI(Action.Installation_BI);
            ActionView.installationView.SetFI(Action.Installation_FI);
            ActionView.installationView.SetFS(Action.Installation_FS);
            ActionView.installationView.SetFSBU(Action.Installation_FSBU);

            //ECCC
            ActionView.ecccView.SetECCC(Action.ECCC);
            ActionView.ecccView.SetECCCSpec(Action.ECCC_PNCSpec);
            ActionView.ecccView.SetECCCSec(Action.ECCC_Sec);

            //Action Calculation by Method
            ActionView.calculationByView.SetANC(Action.ANC);
            ActionView.calculationByView.SetANCSpec(Action.ANCSpec);
            ActionView.calculationByView.SetPNC(Action.PNC);
            ActionView.calculationByView.SetPNCSpec(Action.PNCSpec);

            //Set PNC Estimation 
            ActionView.PNCSpecialEstymationView.SetPNCEstimationValue(Action.PNCSpec_Estimation);
        }
    }
}
