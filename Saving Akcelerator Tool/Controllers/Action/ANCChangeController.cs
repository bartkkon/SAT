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
            var List = context.ANCChange.Where(u => u.ActionID == ActionID && u.Active == true).ToList();

            return List;
        }

        public static void UpdateActionID(int OldID, int NewID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.ANCChange.Where(u => u.ActionID == OldID && u.Active == true).ToList();

            foreach(var One in List)
            {
                One.ActionID = NewID;
                context.ANCChange.Update(One);
            }
            context.SaveChanges();
        }

        public static void UpdateANC(int OldID, int NewID, IEnumerable<ANCChangeDB> NewList)
        {
            var context = new DataBaseConnectionContext();
            var OldList = context.ANCChange.Where(u => u.ActionID == OldID && u.Active == true).ToList();
            int Revision = 0;

            foreach(var Old in OldList)
            {
                Old.Active = false;
                Revision = Old.Rev;
                context.ANCChange.Update(Old);
            }

            foreach(var New in NewList)
            {
                New.ActionID = NewID;
                New.Rev = Revision + 1;
                New.ChangeBy = Environment.UserName.ToLower();
                New.ChangeTime = DateTime.UtcNow;
                context.ANCChange.Add(New);
            }

            context.SaveChanges();

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
