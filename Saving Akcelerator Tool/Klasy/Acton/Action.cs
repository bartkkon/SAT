using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    public class Action
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public string StatusYear{get; set;}
        public decimal StartYear { get; set; }
        public string StartMonth { get; set; }
        public string Factory { get; set; }
        public string Calculate { get; set; }
        public int IloscANC { get; set; }
        public string[] OldANC { get; set; }
        public int[] OldANCQ { get; set; }
        public string[] NewANC { get; set; }
        public int[] NewANCQ { get; set; }
        public DataTable IDCO { get; set; }
        public decimal[] OldSTK { get; set; }
        public decimal[] NewSTK { get; set; }
        public string Poz_Neg { get; set; }
        public decimal[] Delta { get; set; }
        public decimal[] STKEst { get; set; }
        public decimal[] Percent { get; set; }
        public decimal[] STKCal { get; set; }
        public decimal[] ECCC { get; set; }
        public string[] CalcMass { get; set; }
        public bool[] Calc { get; set; }
        public string[] Next { get; set; }
        public string[] Next2 { get; set; }
        public DataTable PNC { get; set; }
        public DataTable PNCANC { get; set; }
        public DataTable PNCANCQ { get; set; }
        public DataTable PNCSTK { get; set; }
        public DataTable PNCDelta { get; set; }
        public DataTable PNCSumSTK { get; set; }
        public DataTable PNCSumDelta { get; set; }
        public decimal PNCANCPersent { get; set; }
        public decimal[] CalcBUQuantity { get; set; }
        public decimal[] CalcEA1Quantity { get; set; }
        public decimal[] CalcEA2Quantity { get; set; }
        public decimal[] CalcEA3Quantity { get; set; }
        public decimal[] CalcUSEQuantity { get; set; }
        public decimal[] CalcBUSaving { get; set; }
        public decimal[] CalcEA1Saving { get; set; }
        public decimal[] CalcEA2Saving { get; set; }
        public decimal[] CalcEA3Saving { get; set; }
        public decimal[] CalcEA4Saving { get; set; }
        public decimal[] CalcUSESaving { get; set; }
        public decimal[] CalcBUECCC { get; set; }
        public decimal[] CalcEA1ECCC { get; set; }
        public decimal[] CalcEA2ECCC { get; set; }
        public decimal[] CalcEA3ECCC { get; set; }
        public decimal[] CalcUSEECCC { get; set; }
        public decimal[] CalcBUQuantityCarry { get; set; }
        public decimal[] CalcEA1QuantityCarry { get; set; }
        public decimal[] CalcEA2QuantityCarry { get; set; }
        public decimal[] CalcEA3QuantityCarry { get; set; }
        public decimal[] CalcUSEQuantityCarry { get; set; }
        public decimal[] CalcBUSavingCarry { get; set; }
        public decimal[] CalcEA1SavingCarry { get; set; }
        public decimal[] CalcEA2SavingCarry { get; set; }
        public decimal[] CalcEA3SavingCarry { get; set; }
        public decimal[] CalcUSESavingCarry { get; set; }
        public decimal[] CalcBUECCCCarry { get; set; }
        public decimal[] CalcEA1ECCCCarry { get; set; }
        public decimal[] CalcEA2ECCCCarry { get; set; }
        public decimal[] CalcEA3ECCCCarry { get; set; }
        public decimal[] CalcUSEECCCCarry { get; set; }
        public decimal PNCEstyma { get; set; }
        public string Leader { get; set; }
        public string[] Platform { get; set; }
        public string[] Installation { get; set; }
        public DataTable PerUSE { get; set; }
        public DataTable PerUSECarry { get; set; }
        public DataTable PerBU { get; set; }
        public DataTable PerBUCarry { get; set; }
        public DataTable PerEA1 { get; set; }
        public DataTable PerEA1Carry { get; set; }
        public DataTable PerEA2 { get; set; }
        public DataTable PerEA2Carry { get; set; }
        public DataTable PerEA3 { get; set; }
        public DataTable PerEA3Carry { get; set; }
        public string Comment { get; set; }
    }
}
