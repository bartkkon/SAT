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

        public static IEnumerable<ActionDB> Load(int Year)
        {
            var context = new DataBaseConnectionContext();
            List<ActionDB> List = context.Action.Where(u => u.StartYear == Year && u.Active == true).ToList();

            return List;
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

        public static void ModificationAction(ActionDB Original, ActionDB Updaeted)
        {
            var context = new DataBaseConnectionContext();

            Original.Active = false;
            Updaeted.Rev = Original.Rev + 1;
            Updaeted.ActionIDOriginal = Original.ID;

            context.Action.Update(Original);
            context.Action.Add(Updaeted);

            context.SaveChanges();
        }

        public static ActionDB FindAction(string ActionName, int Year)
        {
            var context = new DataBaseConnectionContext();
            ActionDB FindAction = context.Action.Where(u => u.Name == ActionName && u.StartYear == Year && u.Active == true).FirstOrDefault();
            return FindAction;
        }

        public static bool CheckIfNameExist(string ActionName)
        {
            var context = new DataBaseConnectionContext();
            IEnumerable<ActionDB> List = context.Action.Where(u => u.Name == ActionName).ToList();

            if (List.Count() != 0)
                return false;

            return true;
        }
    }
}
