using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model.Action
{
    class ANCChangeDB
    {
        [Key]
        public int ID { get; set; }
        public int ActionID { get; set; }
        public string Old_ANC { get; set; }
        public int Old_Quant_ANC { get; set; }
        public string OLD_IDCO { get; set; }
        public string New_ANC { get; set; }
        public int New_Quant_ANC { get; set; }
        public string New_IDCO { get; set; }
        public double Old_STK { get; set; }
        public double New_STK { get; set; }
        public double Delta { get; set; }
        public double Estimation { get; set; }
        public double Percent { get; set; }
        public double Calculation { get; set; }
        public string Next_ANC_1 { get; set; }
        public string Next_ANC_2 { get; set; }
        public bool ANC_Calculation { get; set; }

    }
}
