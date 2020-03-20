using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class PNCSpecialController
    {
        public static IEnumerable<PNCSpecialDB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.PNCSpecial.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<PNCSpecialDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToRemove)
            {
                context.PNCSpecial.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(IEnumerable<PNCSpecialDB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToAdd)
            {
                context.PNCSpecial.Add(Row);
            }

            context.SaveChanges();
        }

        public static void Update(IEnumerable<PNCSpecialDB> ListToUpdate)
        {
            var context = new DataBaseConnectionContext();

            foreach (var Row in ListToUpdate)
            {
                if (Row.ID != 0)
                {
                    context.PNCSpecial.Update(Row);
                }
                else
                {
                    context.PNCSpecial.Add(Row);
                }
            }

            context.SaveChanges();
        }
    }
}
