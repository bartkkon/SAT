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
        public CreateUsers(DataTable UserDataFromBase)
        {
            DataRow Person = UserDataFromBase.Rows[0];
            
            Users NewUser = Users.Singleton();

            NewUser.Login = Person["Name"].ToString();
            NewUser.Name = Person["FullName"].ToString();
            NewUser.Role = Person["Role"].ToString();

            //Taby
            NewUser.ActionTab = bool.Parse(Person["tab_Action"].ToString());
            NewUser.SummaryTab = bool.Parse(Person["tab_Summary"].ToString());
            NewUser.STKTab = bool.Parse(Person["tab_STK"].ToString());
            NewUser.QuantityTab = bool.Parse(Person["tab_Quantity"].ToString());
            NewUser.AdminTab = bool.Parse(Person["tab_Admin"].ToString());
            NewUser.StatisticTab = bool.Parse(Person["tab_Statistic"].ToString());

            //Ustawienia dla Action
            NewUser.Action = Person["Action"].ToString();
            NewUser.ActionEle = bool.Parse(Person["ActionEle"].ToString());
            NewUser.ActionMech = bool.Parse(Person["ActionMech"].ToString());
            NewUser.ActionNVR = bool.Parse(Person["ActionNVR"].ToString());
            
            //Ustawienia dla Approvali
            NewUser.ElectronicApprove = bool.Parse(Person["EleApprove"].ToString());
            NewUser.MechanicApprove = bool.Parse(Person["MechApprove"].ToString());
            NewUser.NVRApprove = bool.Parse(Person["NVRApprove"].ToString());
            NewUser.PCApprove = bool.Parse(Person["PCApprove"].ToString());
            
        }
    }
}
