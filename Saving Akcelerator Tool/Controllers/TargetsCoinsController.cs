using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class TargetsCoinsController
    {
        public static IEnumerable<Targets_CoinsDB> Load_Year(int YearToLoad)
        {
            var context = new DataBaseConnectionContext();
            var List = context.Targets_Coins.Where(u => u.Year == YearToLoad).ToList();

            return List;
        }

        public static void UpdateValue(Targets_CoinsDB _UpdateValue)
        {
            var context = new DataBaseConnectionContext();

            context.Update(_UpdateValue);
            context.SaveChanges();
        }

        public static void AddValue(Targets_CoinsDB _AddValue)
        {
            var context = new DataBaseConnectionContext();

            context.Add(_AddValue);
            context.SaveChanges();
        }
    }
}
