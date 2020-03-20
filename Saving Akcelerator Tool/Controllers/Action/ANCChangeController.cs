using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class ANCChangeController
    {
        public static IEnumerable<ANCChangeDB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.ANCChange.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<ANCChangeDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach(var Row in ListToRemove)
            {
                context.ANCChange.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(IEnumerable<ANCChangeDB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach(var Row in ListToAdd)
            {
                context.ANCChange.Add(Row);
            }

            context.SaveChanges();
        }

        public static void Update(IEnumerable<ANCChangeDB> ListToUpdate)
        {
            var context = new DataBaseConnectionContext();

            foreach(var Row in ListToUpdate)
            {
                if(Row.ID != 0)
                {
                    context.ANCChange.Update(Row);
                }
                else
                {
                    context.ANCChange.Add(Row);
                }
            }

            context.SaveChanges();
        }
    }
}
