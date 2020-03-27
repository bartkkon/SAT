
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model.Action
{
    class PNCListDB
    {
        [Key]
        public int ID { get; set; }
        public int ActionID { get; set; }
        public string List { get; set; }
        public bool Active { get; set; }
        public int Rev { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeTime { get; set; }
        public int ActionIDOriginal { get; set; }
    }
}
