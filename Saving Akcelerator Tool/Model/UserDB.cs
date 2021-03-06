﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Model
{
    public class UserDB
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public bool ActionTab { get; set; }
        public string Action { get; set; }
        public bool ActionEle { get; set; }
        public bool ActionMech { get; set; }
        public bool ActionNVR { get; set; }
        public bool SummaryTab { get; set; }
        public bool STKTab { get; set; }
        public bool QuantityTab { get; set; }
        public bool AdminTab { get; set; }
        public bool ElectronicApprove { get; set; }
        public bool MechanicApprove { get; set; }
        public bool NVRApprove { get; set; }
        public bool PCApprove { get; set; }
        public bool StatisticTab { get; set; }
        public bool PlatformTab { get; set; }
    }
}
