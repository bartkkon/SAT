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
    class PNCListController
    {
        public static IEnumerable<PNCListDB> Load(int ActionID)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();

                    var List = context.PNCList.Where(u => u.ActionID == ActionID && u.Active == true).ToList();

                    return List;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void Remove(IEnumerable<PNCListDB> ListToRemove)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    foreach (var Row in ListToRemove)
                    {
                        context.PNCList.Remove(Row);
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

        public static void Add(IEnumerable<PNCListDB> ListToAdd)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    foreach (var Row in ListToAdd)
                    {
                        context.PNCList.Add(Row);
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

        public static void Update(IEnumerable<PNCListDB> ListToUpdate)
        {
            while (true)
            {
                try
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
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void UpdateID(int Previous, int Successor)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();

                    IEnumerable<PNCListDB> PNCTable = context.PNCList.Where(u => u.ActionID == Previous && u.Active == true).ToList();

                    foreach (PNCListDB PNC in PNCTable)
                    {
                        PNC.ActionID = Successor;
                        context.PNCList.Update(PNC);
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

        public static void UpatePNCList(int Previous, int Successor, IEnumerable<PNCListDB> NewPNCList)
        {
            while(true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();

                    IEnumerable<PNCListDB> CurrentPNCList = context.PNCList.Where(u => u.ActionID == Previous && u.Active == true).ToList();

                    foreach(PNCListDB CurrentPNC in CurrentPNCList)
                    {
                        CurrentPNC.ActionID = Successor;
                        if(!NewPNCList.Any(u => u.List == CurrentPNC.List))
                        {
                            CurrentPNC.Active = false;
                            CurrentPNC.ChangeTime = DateTime.UtcNow;
                            CurrentPNC.ChangeBy = Environment.UserName.ToLower();
                        }
                        context.PNCList.Update(CurrentPNC);
                    }

                    foreach(PNCListDB NewPNC in NewPNCList)
                    {
                        if(!CurrentPNCList.Any(u => u.List == NewPNC.List))
                        {
                            NewPNC.ActionID = Successor;
                            NewPNC.Active = true;
                            context.PNCList.Add(NewPNC);
                        }
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

        public static void Deactivation(int ID)
        {
            while(true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    IEnumerable<PNCListDB> PNCList = context.PNCList.Where(u => u.ActionID == ID && u.Active == true).ToList();

                    foreach(PNCListDB PNC in PNCList)
                    {
                        PNC.Active = false;
                        PNC.ChangeTime = DateTime.UtcNow;
                        PNC.ChangeBy = Environment.UserName.ToLower();
                        context.PNCList.Update(PNC);
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
