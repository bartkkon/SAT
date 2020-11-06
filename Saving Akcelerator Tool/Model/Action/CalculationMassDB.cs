using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model.Action
{
    class CalculationMassDB
    {
        [Key]
        public int ID { get; set; }
        public int ActionID { get; set; }
        public bool DMD_FI { get; set; }
        public bool DMD_FS { get; set; }
        public bool DMD_BI { get; set; }
        public bool DMD_FSBU { get; set; }
        public bool D45_FI { get; set; }
        public bool D45_FS { get; set; }
        public bool D45_BI { get; set; }
        public bool D45_FSBU { get; set; }
        public bool Active { get; set; }
        public int Rev { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeTime { get; set; }
        public int ActionIDOriginal { get; set; }

    }
}
