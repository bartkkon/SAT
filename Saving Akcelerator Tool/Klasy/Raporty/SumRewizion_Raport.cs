using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Saving_Accelerator_Tool.Klasy.Raporty
{
    public class SumRewizion_Raport
    {
        private readonly DataTable _History;
        private readonly decimal _Year;
        private readonly string _Revision;
        private readonly string _Devision;

        public SumRewizion_Raport(DataTable Hisotry, decimal Year, string Rev, ref double[] Actual, ref double[] Carry, string Devision)
        {
            _History = Hisotry;
            _Year = Year;
            _Revision = Rev;
            _Devision = Devision;

            SumRewizion(ref Actual, ref Carry);

        }

        private void SumRewizion(ref double[] actual, ref double[] carry)
        {
            DataRow[] FindAction;


            FindAction = _History.Select(string.Format("History LIKE '%{0}%'", _Revision + "/" + _Year.ToString())).ToArray();

            foreach (DataRow Row in FindAction)
            {
                if (Row["Group"].ToString() == _Devision)
                {
                    if (Row["StartYear"].ToString() == _Year.ToString() || Row["StartYear"].ToString() == "BU" + _Year.ToString())
                    {
                        string[] Per = Row["Per" + _Revision].ToString().Split('/');

                        foreach(string OneANC in Per)
                        {
                            if (OneANC != "")
                            {
                                string[] One = OneANC.Split('|');
                                for (int counter = 1; counter <= 12; counter++)
                                {
                                    if (One[counter] != "")
                                    {
                                        string[] Oszczednosc = One[counter].Split(':');
                                        actual[counter - 1] += double.Parse(Oszczednosc[1]);
                                    }
                                }
                            }
                        }
                    }
                    else if (Row["StartYear"].ToString() == (_Year - 1).ToString())
                    {
                        string[] Per = Row["Per" + _Revision +"Carry"].ToString().Split('/');

                        foreach (string OneANC in Per)
                        {
                            if (OneANC != "")
                            {
                                string[] One = OneANC.Split('|');
                                for (int counter = 1; counter <= 12; counter++)
                                {
                                    if (One[counter] != "")
                                    {
                                        string[] Oszczednosc = One[counter].Split(':');
                                        carry[counter - 1] += double.Parse(Oszczednosc[1]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int counter = 0; counter <12; counter++)
            {
                actual[12] += actual[counter];
                carry[12] += carry[counter];
            }
        }
    }
}
