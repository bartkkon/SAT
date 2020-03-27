using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model.Action
{
    class PNCSpecialDB
    {
        [Key]
        public int ID { get; set; }
        public int ActionID { get; set; }
        public string PNC { get; set; }
        public double ECCC { get; set; }
        public string Old_ANC { get; set; }
        public double Old_Quant_ANC { get; set; }
        public string Old_IDCO { get; set; }
        public string New_ANC { get; set; }
        public double New_Quant_ANC { get; set; }
        public string New_IDCO { get; set; }
        public double Old_STK { get; set; }
        public double New_STK { get; set; }
        public double Delta { get; set; }
        public bool Active { get; set; }
        public int Rev { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeTime { get; set; }
        public int ActionIDOriginal { get; set; }
    }
}
