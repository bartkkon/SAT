using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Email
{
    public class SentTo
    {
        private readonly Data_Import _Import;
        private readonly bool _Electronic;
        private readonly bool _Mechanic;
        private readonly bool _NVR;
        private readonly bool _PC;

        public SentTo(bool ElectronicMenager, bool MechanicMenager, bool NVRMenager, bool PCMenager)
        {
            _Import = Data_Import.Singleton();
            _Electronic = ElectronicMenager;
            _Mechanic = MechanicMenager;
            _NVR = NVRMenager;
            _PC = PCMenager;
        }

        public SentTo()
        {
            _Import = Data_Import.Singleton();
        }

        public string SentToList()
        {
            string PersonList = "";
            DataTable Access = new DataTable();

            _Import.Load_TxtToDataTable2(ref Access, "Access");

            foreach (DataRow Person in Access.Rows)
            {
                if (_Electronic && Person["Role"].ToString() == "EleMenager")
                {
                    PersonList += Person["Mail"].ToString() + ",";
                }
                if (_Mechanic && Person["Role"].ToString() == "MechMenager")
                {
                    PersonList += Person["Mail"].ToString() + ",";
                }
                if (_NVR && Person["Role"].ToString() == "NVRMenager")
                {
                    PersonList += Person["Mail"].ToString() + ",";
                }
                if (_PC && Person["Role"].ToString() == "PCMenager")
                {
                    PersonList += Person["Mail"].ToString() + ",";
                }
            }
            if (PersonList.Length > 0)
                PersonList = PersonList.Substring(0, PersonList.Length - 1);

            return PersonList;
        }

        public string SentToAdmin()
        {
            string PersonList = "";
            DataTable Access = new DataTable();

            _Import.Load_TxtToDataTable2(ref Access, "Access");

            foreach (DataRow Person in Access.Rows)
            {
                if (Person["Role"].ToString() == "Admin")
                {
                    PersonList += Person["Mail"].ToString() + ",";
                }
            }

            if (PersonList.Length > 0)
                PersonList = PersonList.Substring(0, PersonList.Length - 1);

            return PersonList;
        }
    }
}
