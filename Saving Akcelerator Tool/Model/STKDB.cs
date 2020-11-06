using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    class STKDB
    {
        [Key]
        public int ID { get; set; }
        public string ANC { get; set; }
        public string Description { get; set; }
        public string IDCO { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double Value { get; set; }

    }
}
