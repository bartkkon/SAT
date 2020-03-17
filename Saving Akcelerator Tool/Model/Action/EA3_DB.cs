using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model.Action
{
    class EA3_DB
    {
        [Key]
        public int ID { get; set; }
        public int ActionID { get; set; }
        public string Component { get; set; }
        public int Month { get; set; }
        public double Quantity { get; set; }
        public double Saving { get; set; }
        public double ECCC { get; set; }

    }
}
