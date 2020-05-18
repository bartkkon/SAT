using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Controllers.Excptions;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class PNCSpecialController
    {
        public static IEnumerable<PNCSpecialDB> Load(int ActionID)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    var List = context.PNCSpecial.Where(u => u.ActionID == ActionID && u.Active == true).ToList();

                    return List;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void Remove(IEnumerable<PNCSpecialDB> ListToRemove)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    foreach (var Row in ListToRemove)
                    {
                        context.PNCSpecial.Remove(Row);
                    }

                    context.SaveChanges();
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void Deactivation(int ActionID)
        {
            while(true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    var List = context.PNCSpecial.Where(u => u.ActionID == ActionID).ToList();

                    foreach(PNCSpecialDB PNC in List)
                    {
                        PNC.Active = false;
                        context.PNCSpecial.Update(PNC);
                    }

                    context.SaveChanges();
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void Add(IEnumerable<PNCSpecialDB> ListToAdd)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    foreach (var Row in ListToAdd)
                    {
                        Row.Rev = 1;
                        context.PNCSpecial.Add(Row);
                    }

                    context.SaveChanges();
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void UpdateList(IEnumerable<PNCSpecialDB> ListToUpdate, int OriginalID, int NewID)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    IEnumerable<PNCSpecialDB> CurrentList = context.PNCSpecial.Where(u => u.ActionID == OriginalID && u.Active == true).ToList();
                    int Revision = 0;

                    foreach(PNCSpecialDB PNC in CurrentList)
                    {
                        PNC.Active = false;
                        Revision = PNC.Rev;
                        context.PNCSpecial.Update(PNC);
                    }

                    foreach(PNCSpecialDB PNC in ListToUpdate)
                    {
                        PNC.ActionID = NewID;
                        PNC.Rev = Revision + 1;
                        PNC.ActionIDOriginal = OriginalID;
                        context.PNCSpecial.Add(PNC);
                    }

                    context.SaveChanges();
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }
    }
}
