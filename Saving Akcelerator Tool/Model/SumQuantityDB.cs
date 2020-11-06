using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    class SumQuantityDB
    {
        [Key]
        public int ID { get; set; }
        public string Platform { get; set; }
        public string Installation { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }
    }
}
