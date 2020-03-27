using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    class ActionDB
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public int StartYear { get; set; }
        public string StatusYear { get; set; }
        public string MonthStart { get; set; }
        public string Factory { get; set; }
        public string Leader { get; set; }
        public string Devision { get; set; }
        public bool Platform_DMD { get; set; }
        public bool Platform_D45 { get; set; }
        public bool Installation_FI { get; set; }
        public bool Installation_FS { get; set; }
        public bool Installation_BI { get; set; }
        public bool Installation_FSBU { get; set; }
        public bool ANC { get; set; }
        public bool ANCSpec { get; set; }
        public bool PNC { get; set; }
        public bool PNCSpec { get; set; }
        public bool ECCC { get; set; }
        public double ECCC_Sec { get; set; }
        public bool ECCC_PNCSpec { get; set; }
        public double PercentQauntity { get; set; }
        public bool ANC_Calc { get; set; }
        public bool Group_Calc { get; set; }
        public double PNCSpec_Estimation { get; set; }
        public bool Active { get; set; }
        public int Rev { get; set; }
        public string ChangeBy { get; set; }    
        public DateTime ChangeTime { get; set; }
        public  int ActionIDOriginal { get; set; }
    }
}
