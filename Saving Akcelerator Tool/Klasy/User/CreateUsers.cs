using Saving_Accelerator_Tool.Controllers.AdminTab;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.User
{
    class CreateUsers
    {
        public CreateUsers(Users users, string UserLogin)
        {
            UserDB BaseUser = AddPersonController.ReturnUser(UserLogin);

            users.Login = BaseUser.Login;
            users.Name = BaseUser.Name;
            users.Role = BaseUser.Role;
            users.Mail = BaseUser.Mail;

            //Taby
            users.ActionTab = BaseUser.ActionTab;
            users.SummaryTab = BaseUser.SummaryTab;
            users.STKTab = BaseUser.STKTab;
            users.QuantityTab = BaseUser.QuantityTab;
            users.AdminTab = BaseUser.AdminTab;
            users.StatisticTab = BaseUser.StatisticTab;
            users.PlatformTab = BaseUser.PlatformTab;

            //Ustawienia dla Action
            users.Action = BaseUser.Action;
            users.ActionEle = BaseUser.ActionEle;
            users.ActionMech = BaseUser.ActionMech;
            users.ActionNVR = BaseUser.ActionNVR;

            //Ustawienia dla Approvali
            users.ElectronicApprove = BaseUser.ElectronicApprove;
            users.MechanicApprove = BaseUser.MechanicApprove;
            users.NVRApprove = BaseUser.NVRApprove;
            users.PCApprove = BaseUser.PCApprove;
        }
    }
}
