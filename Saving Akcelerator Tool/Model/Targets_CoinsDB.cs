using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    class Targets_CoinsDB
    {
        [Key]
        public int ID { get; set; }
        public int Year { get; set; }
        public double ECCC { get; set; }
        public double Euro { get; set; }
        public double USD { get; set; }
        public double SEK { get; set; }
        public double DM_BU { get; set; }
        public double DM_EA1 { get; set; }
        public double DM_EA2 { get; set; }
        public double DM_EA3 { get; set; }
        public double DM_EA4 { get; set; }
        public double PC_BU { get; set; }
        public double PC_EA1 { get; set; }
        public double PC_EA2 { get; set; }
        public double PC_EA3 { get; set; }
        public double PC_EA4 { get; set; }
        public double Electronic_BU { get; set; }
        public double Electronic_EA1 { get; set; }
        public double Electronic_EA2 { get; set; }
        public double Electronic_EA3 { get; set; }
        public double Electronic_EA4 { get; set; }
        public double Mechanic_BU { get; set; }
        public double Mechanic_EA1 { get; set; }
        public double Mechanic_EA2 { get; set; }
        public double Mechanic_EA3 { get; set; }
        public double Mechanic_EA4 { get; set; }
        public double NVR_BU { get; set; }
        public double NVR_EA1 { get; set; }
        public double NVR_EA2 { get; set; }
        public double NVR_EA3 { get; set; }
        public double NVR_EA4 { get; set; }

    }
}
