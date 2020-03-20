using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class PNCListController
    {
        public static IEnumerable<PNCListDB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.PNCList.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<PNCListDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToRemove)
            {
                context.PNCList.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(IEnumerable<PNCListDB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToAdd)
            {
                context.PNCList.Add(Row);
            }

            context.SaveChanges();
        }

        public static void Update(IEnumerable<PNCListDB> ListToUpdate)
        {
            var context = new DataBaseConnectionContext();

            foreach (var Row in ListToUpdate)
            {
                if (Row.ID != 0)
                {
                    context.PNCList.Update(Row);
                }
                else
                {
                    context.PNCList.Add(Row);
                }
            }

            context.SaveChanges();
        }
    }
}
