using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class EA4_CarryController
    {
        public static IEnumerable<EA4_Carry_DB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.EA4_Carry.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<EA4_Carry_DB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToRemove)
            {
                context.EA4_Carry.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(IEnumerable<EA4_Carry_DB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToAdd)
            {
                context.EA4_Carry.Add(Row);
            }

            context.SaveChanges();
        }

        public static void Update(IEnumerable<EA4_Carry_DB> ListToUpdate)
        {
            var context = new DataBaseConnectionContext();

            foreach (var Row in ListToUpdate)
            {
                if (Row.ID != 0)
                {
                    context.EA4_Carry.Update(Row);
                }
                else
                {
                    context.EA4_Carry.Add(Row);
                }
            }

            context.SaveChanges();
        }
    }
}
