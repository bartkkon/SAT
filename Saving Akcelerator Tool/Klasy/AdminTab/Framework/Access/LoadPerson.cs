using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class LoadPerson
    {
        public LoadPerson(UserDB User)
        {
            var AddPerson = MainProgram.Self.addPersonView;

            AddPerson.SetFullName(User.Name);
            AddPerson.SetMail(User.Mail);
            AddPerson.SetRole(User.Role);
            AddPerson.SetViwer(User.Action);
            AddPerson.SetActionTab(User.ActionTab);
            AddPerson.SetActionEle(User.ActionEle);
            AddPerson.SetActionMech(User.ActionMech);
            AddPerson.SetActionNVR(User.ActionNVR);
            AddPerson.SetSummaryTab(User.SummaryTab);
            AddPerson.SetSTKTab(User.STKTab);
            AddPerson.SetQuantityTab(User.QuantityTab);
            AddPerson.SetAdminTab(User.AdminTab);
            AddPerson.SetStatisticTab(User.StatisticTab);
            AddPerson.SetPlatformTab(User.PlatformTab);
            AddPerson.SetReportElectroic(User.ElectronicApprove);
            AddPerson.SetReportMechanic(User.MechanicApprove);
            AddPerson.SetReportNVR(User.NVRApprove);
            AddPerson.SetReportPC(User.PCApprove);
        }

    }
}
