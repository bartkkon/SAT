using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.AdminTableTab
{
    class AdminTableController
    {
        public static void LoadAccess()
        {
            var context = new DataBaseConnectionContext();
            List<UserDB> users = new List<UserDB>();
            foreach(UserDB user in context.Users)
            {
                users.Add(user);
            }
            MainProgram.Self.adminTableView.ReturnDataGridView().DataSource = users;
        }
    }
}
