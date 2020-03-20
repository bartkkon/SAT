using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class ActionController
    {
        public static ActionDB Load_ID(int ID)
        {
            var context = new DataBaseConnectionContext();

            ActionDB Action = context.Action.Where(u => u.ID == ID).FirstOrDefault();

            return Action;
        }

        public static void Save(ActionDB action)
        {
            var context = new DataBaseConnectionContext();

            context.Action.Update(action);
            context.SaveChanges();
        }

        public static void NewAction(ActionDB action)
        {
            var context = new DataBaseConnectionContext();

            context.Action.Add(action);
            context.SaveChanges();
        }
    }
}
