using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    public class ANCMonthlyDB
    {
        [Key]
        public int ID{get; set;}
        public string ANC { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }
    }
}
