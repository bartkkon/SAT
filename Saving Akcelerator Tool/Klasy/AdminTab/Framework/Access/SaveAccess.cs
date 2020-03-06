using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Controllers.AdminTab;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class SaveAccess
    {
        public SaveAccess(string UserLogin)
        {
            var AddPerson = MainProgram.Self.addPersonView;

            UserDB user = AddPersonController.ReturnUser(UserLogin);

            if(user != null)
            {
                user.Name = AddPerson.GetFullName();
                user.Mail = AddPerson.GetMail();
                user.Role = AddPerson.GetRole();
                user.Action = AddPerson.GetViewer();
                user.ActionTab = AddPerson.GetActionTab();
                user.ActionEle = AddPerson.GetActionEle();
                user.ActionMech = AddPerson.GetActionMech();
                user.ActionNVR = AddPerson.GetActionNVR();
                user.SummaryTab = AddPerson.GetSummaryTab();
                user.STKTab = AddPerson.GetSTKTab();
                user.QuantityTab = AddPerson.GetQuantityTab();
                user.AdminTab = AddPerson.GetAdminTab();
                user.StatisticTab = AddPerson.GetStatisticTab();
                user.PlatformTab = AddPerson.GetPlatformTab();
                user.ElectronicApprove = AddPerson.GetReportElectronic();
                user.MechanicApprove = AddPerson.GetReportMechanic();
                user.NVRApprove = AddPerson.GetReportNVR();
                user.PCApprove = AddPerson.GetReportPC();


                AddPersonController.UpdatePerson(user);
            }

        }
    }
}
