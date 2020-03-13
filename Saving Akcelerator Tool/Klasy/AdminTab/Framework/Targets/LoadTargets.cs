using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Targets
{
    public class LoadTargets
    {
       
        public LoadTargets(int Year)
        {
            IEnumerable<Targets_CoinsDB> Lista = TargetsCoinsController.Load_Year(Year);

            MainProgram.Self.TargetView.Clear();

            if(Lista.Count() == 0)
            {
                return;
            }
            else
            {
                Load(Lista.First());
            }
        }

        public LoadTargets(int Year, string Revision)
        {
            IEnumerable<Targets_CoinsDB> Lista = TargetsCoinsController.Load_Year(Year);

            MainProgram.Self.TargetView.Clear();

            if (Lista.Count() == 0)
            {
                return;
            }
            else
            {
                LoadRevision(Lista.First(), Revision);
            }
        }

        private void LoadRevision(Targets_CoinsDB Data, string revision)
        {
            var Target = MainProgram.Self.TargetView;

            if (revision == "EA4")
            {
                Target.SetRevision("EA4");
                Target.SetDM(Data.DM_EA4);
                Target.SetPC(Data.PC_EA4);
                Target.SetElectronic(Data.Electronic_EA4);
                Target.SetMechanic(Data.Mechanic_EA4);
                Target.SetNVR(Data.NVR_EA4);
            }
            else if (revision == "EA3")
            {
                Target.SetRevision("EA3");
                Target.SetDM(Data.DM_EA3);
                Target.SetPC(Data.PC_EA3);
                Target.SetElectronic(Data.Electronic_EA3);
                Target.SetMechanic(Data.Mechanic_EA3);
                Target.SetNVR(Data.NVR_EA3);
            }
            else if (revision == "EA2")
            {
                Target.SetRevision("EA2");
                Target.SetDM(Data.DM_EA2);
                Target.SetPC(Data.PC_EA2);
                Target.SetElectronic(Data.Electronic_EA2);
                Target.SetMechanic(Data.Mechanic_EA2);
                Target.SetNVR(Data.NVR_EA2);
            }
            else if (revision == "EA1")
            {
                Target.SetRevision("EA1");
                Target.SetDM(Data.DM_EA1);
                Target.SetPC(Data.PC_EA1);
                Target.SetElectronic(Data.Electronic_EA1);
                Target.SetMechanic(Data.Mechanic_EA1);
                Target.SetNVR(Data.NVR_EA1);
            }
            else if (revision == "BU")
            {
                Target.SetRevision("BU");
                Target.SetDM(Data.DM_BU);
                Target.SetPC(Data.PC_BU);
                Target.SetElectronic(Data.Electronic_BU);
                Target.SetMechanic(Data.Mechanic_BU);
                Target.SetNVR(Data.NVR_BU);
            }
        }

        private void Load(Targets_CoinsDB Data)
        {
            var Target = MainProgram.Self.TargetView;
            
            if(Data.DM_EA4 != 0)
            {
                Target.SetRevision("EA4");
                Target.SetDM(Data.DM_EA4);
                Target.SetPC(Data.PC_EA4);
                Target.SetElectronic(Data.Electronic_EA4);
                Target.SetMechanic(Data.Mechanic_EA4);
                Target.SetNVR(Data.NVR_EA4);
            }
            else if (Data.DM_EA3 != 0)
            {
                Target.SetRevision("EA3");
                Target.SetDM(Data.DM_EA3);
                Target.SetPC(Data.PC_EA3);
                Target.SetElectronic(Data.Electronic_EA3);
                Target.SetMechanic(Data.Mechanic_EA3);
                Target.SetNVR(Data.NVR_EA3);
            }
            else if (Data.DM_EA2 != 0)
            {
                Target.SetRevision("EA2");
                Target.SetDM(Data.DM_EA2);
                Target.SetPC(Data.PC_EA2);
                Target.SetElectronic(Data.Electronic_EA2);
                Target.SetMechanic(Data.Mechanic_EA2);
                Target.SetNVR(Data.NVR_EA2);
            }
            else if (Data.DM_EA1 != 0)
            {
                Target.SetRevision("EA1");
                Target.SetDM(Data.DM_EA1);
                Target.SetPC(Data.PC_EA1);
                Target.SetElectronic(Data.Electronic_EA1);
                Target.SetMechanic(Data.Mechanic_EA1);
                Target.SetNVR(Data.NVR_EA1);
            }
            else 
            {
                Target.SetRevision("BU");
                Target.SetDM(Data.DM_BU);
                Target.SetPC(Data.PC_BU);
                Target.SetElectronic(Data.Electronic_BU);
                Target.SetMechanic(Data.Mechanic_BU);
                Target.SetNVR(Data.NVR_BU);
            }
        }
    }
}
