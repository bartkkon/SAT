using Saving_Accelerator_Tool.Klasy.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class ActionVerificationEnabled
    {
        public ActionVerificationEnabled()
        {
            decimal ActionYear = MainProgram.Self.actionView.stateView.GetYear();
            int Month = MainProgram.Self.actionView.stateView.GetStartMonthInt();


            if (Users.Singleton.Role == "Admin")
            {
                UserContorlEnable(true);
                return;
            }

            if (ActionYear < DateTime.UtcNow.Year)
            {
                UserContorlEnable(false);
                return;
            }
            else if( ActionYear > DateTime.UtcNow.Year)
            {
                UserContorlEnable(true);
                return;
            }
            else
            {
                if(Month < DateTime.UtcNow.Month)
                {
                    UserContorlEnable(false);
                    return;
                }
                else
                {
                    UserContorlEnable(true);
                    return;
                }
            }
        }

        public ActionVerificationEnabled(bool vision)
        {
            UserContorlEnable(vision);
        }

        private void UserContorlEnable(bool Vision)
        {
            var Action = MainProgram.Self.actionView;

            Action.nameView.Enabled = Vision;
            Action.stateView.Enabled = Vision;
            Action.platformView.Enabled = Vision;
            Action.installationView.Enabled = Vision;
            Action.ecccView.Enabled = Vision;
            Action.calculationByView.Enabled = Vision;
            Action.PNCSpecialEstymationView.Enabled = Vision;
            Action.saveButtonView1.Enabled = Vision;
            Action.ANCChangeView.Enabled = Vision;
            Action.StkChange.Enabled = Vision;
            Action.NextANC.Enabled = Vision;
            Action.QunatityPercent.Enabled = Vision;
            Action.CalculationGroup.Enabled = Vision;
            Action.SavingsTable.Enabled = Vision;
            Action.ButtonsView.Enabled = Vision;
            Action.PNCListView.Enabled = Vision;
        }

    }
}
