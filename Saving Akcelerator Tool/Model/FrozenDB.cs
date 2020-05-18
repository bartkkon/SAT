using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    class FrozenDB
    {
        [Key]

        /*
        Logic:
        0 - Close - Month/Revision not calculated,
        1 - Open - Month/Revision can be calculated,
        2 - Approve - Month/Revision is approved.
        */

        public int ID { get; set; }
        public int Year { get; set; }
        public int BU { get; set; }
        public int EA1 { get; set; }
        public int EA2 { get; set; }
        public int EA3 { get; set; }
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
        public int ElectronicApprove { get; set; }
        public int MechanicApprove { get; set; }
        public int NVRApprove { get; set; }
    }
}
