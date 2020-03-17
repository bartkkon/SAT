using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class FrozenController
    {
        public static IEnumerable<FrozenDB> Load_year(int YearToLoad)
        {
            var context = new DataBaseConnectionContext();

            var Lista = context.Frozen.Where(u => u.Year == YearToLoad).ToList();

            return Lista;
        }

        public static IEnumerable<FrozenDB> Load()
        {
            var context = new DataBaseConnectionContext();
            var List = context.Frozen.ToList();

            return List;
        }

        public static void AddValue(FrozenDB _AddValue)
        {
            var context = new DataBaseConnectionContext();

            context.Add(_AddValue);
            context.SaveChanges();
        }

        public static void UpdateValue(FrozenDB _UpdateValue)
        {
            var context = new DataBaseConnectionContext();

            context.Update(_UpdateValue);
            context.SaveChanges();
        }
    }
}
