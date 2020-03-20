using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    class IDAction
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public bool ActionModification { get; set; }
        public bool ANCModification { get; set; }
        public bool CalcModification { get; set; }
        public bool MassModification { get; set; }
        public bool PNCModification { get; set; }
    }
}
