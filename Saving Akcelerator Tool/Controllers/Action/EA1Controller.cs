﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class EA1Controller
    {
        public static IEnumerable<EA1_DB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.EA1.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<EA1_DB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToRemove)
            {
                context.EA1.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(IEnumerable<EA1_DB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToAdd)
            {
                context.EA1.Add(Row);
            }

            context.SaveChanges();
        }

        public static void Update(IEnumerable<EA1_DB> ListToUpdate)
        {
            var context = new DataBaseConnectionContext();

            foreach (var Row in ListToUpdate)
            {
                if (Row.ID != 0)
                {
                    context.EA1.Update(Row);
                }
                else
                {
                    context.EA1.Add(Row);
                }
            }

            context.SaveChanges();
        }
    }
}
