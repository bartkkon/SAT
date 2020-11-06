using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    public class CheckIfEqual
    {
        public bool Check()
        {
            if (OriginalAction.Value.Name != CopyAction.Value.Name)
                return false;
            if (OriginalAction.Value.Description != CopyAction.Value.Description)
                return false;
            if (OriginalAction.Value.Group != CopyAction.Value.Group)
                return false;
            if (OriginalAction.Value.Status != CopyAction.Value.Status)
                return false;
            if (OriginalAction.Value.StartYear != CopyAction.Value.StartYear)
                return false;
            if (OriginalAction.Value.StartMonth != CopyAction.Value.StartMonth)
                return false;
            if (OriginalAction.Value.Factory != CopyAction.Value.Factory)
                return false;
            if (OriginalAction.Value.Calculate != CopyAction.Value.Calculate)
                return false;
            if (OriginalAction.Value.IloscANC != CopyAction.Value.IloscANC)
                return false;
            if (OriginalAction.Value.OldANC != CopyAction.Value.OldANC)
                return false;
            if (OriginalAction.Value.OldANCQ != CopyAction.Value.OldANCQ)
                return false;
            if (OriginalAction.Value.NewANC != CopyAction.Value.NewANC)
                return false;
            if (OriginalAction.Value.NewANCQ != CopyAction.Value.NewANCQ)
                return false;
            if (OriginalAction.Value.IDCO != CopyAction.Value.IDCO)
                return false;
            if (OriginalAction.Value.OldSTK != CopyAction.Value.OldSTK)
                return false;
            if (OriginalAction.Value.NewSTK != CopyAction.Value.NewSTK)
                return false;
            if (OriginalAction.Value.Poz_Neg != CopyAction.Value.Poz_Neg)
                return false;
            if (OriginalAction.Value.Delta != CopyAction.Value.Delta)
                return false;
            if (OriginalAction.Value.STKEst != CopyAction.Value.STKEst)
                return false;
            if (OriginalAction.Value.Percent != CopyAction.Value.Percent)
                return false;
            if (OriginalAction.Value.STKCal != CopyAction.Value.STKCal)
                return false;
            if (OriginalAction.Value.ECCC != CopyAction.Value.ECCC)
                return false;
            if (OriginalAction.Value.CalcMass != CopyAction.Value.CalcMass)
                return false;
            if (OriginalAction.Value.Calc != CopyAction.Value.Calc)
                return false;
            if (OriginalAction.Value.Next != CopyAction.Value.Next)
                return false;
            if (OriginalAction.Value.PNC != CopyAction.Value.PNC)
                return false;
            if (OriginalAction.Value.PNCANC != CopyAction.Value.PNCANC)
                return false;
            if (OriginalAction.Value.PNCANCQ != CopyAction.Value.PNCANCQ)
                return false;
            if (OriginalAction.Value.PNCSTK != CopyAction.Value.PNCSTK)
                return false;
            if (OriginalAction.Value.PNCDelta != CopyAction.Value.PNCDelta)
                return false;
            if (OriginalAction.Value.PNCSumSTK != CopyAction.Value.PNCSumSTK)
                return false;
            if (OriginalAction.Value.PNCSumDelta != CopyAction.Value.PNCSumDelta)
                return false;
            if (OriginalAction.Value.PNCANCPersent != CopyAction.Value.PNCANCPersent)
                return false;
            if (OriginalAction.Value.CalcBUQuantity != CopyAction.Value.CalcBUQuantity)
                return false;
            if (OriginalAction.Value.CalcEA1Quantity != CopyAction.Value.CalcEA1Quantity)
                return false;
            if (OriginalAction.Value.CalcEA2Quantity != CopyAction.Value.CalcEA2Quantity)
                return false;
            if (OriginalAction.Value.CalcEA3Quantity != CopyAction.Value.CalcEA3Quantity)
                return false;
            if (OriginalAction.Value.CalcUSEQuantity != CopyAction.Value.CalcUSEQuantity)
                return false;
            if (OriginalAction.Value.CalcBUSaving != CopyAction.Value.CalcBUSaving)
                return false;
            if (OriginalAction.Value.CalcEA1Saving != CopyAction.Value.CalcEA1Saving)
                return false;
            if (OriginalAction.Value.CalcEA2Saving != CopyAction.Value.CalcEA2Saving)
                return false;
            if (OriginalAction.Value.CalcEA3Saving != CopyAction.Value.CalcEA3Saving)
                return false;
            if (OriginalAction.Value.CalcEA4Saving != CopyAction.Value.CalcEA4Saving)
                return false;
            if (OriginalAction.Value.CalcUSESaving != CopyAction.Value.CalcUSESaving)
                return false;
            if (OriginalAction.Value.CalcBUECCC != CopyAction.Value.CalcBUECCC)
                return false;
            if (OriginalAction.Value.CalcEA1ECCC != CopyAction.Value.CalcEA1ECCC)
                return false;
            if (OriginalAction.Value.CalcEA2ECCC != CopyAction.Value.CalcEA2ECCC)
                return false;
            if (OriginalAction.Value.CalcEA3ECCC != CopyAction.Value.CalcEA3ECCC)
                return false;
            if (OriginalAction.Value.CalcUSEECCC != CopyAction.Value.CalcUSEECCC)
                return false;
            if (OriginalAction.Value.CalcBUQuantityCarry != CopyAction.Value.CalcBUQuantityCarry)
                return false;
            if (OriginalAction.Value.CalcEA1QuantityCarry != CopyAction.Value.CalcEA1QuantityCarry)
                return false;
            if (OriginalAction.Value.CalcEA2QuantityCarry != CopyAction.Value.CalcEA2QuantityCarry)
                return false;
            if (OriginalAction.Value.CalcEA3QuantityCarry != CopyAction.Value.CalcEA3QuantityCarry)
                return false;
            if (OriginalAction.Value.CalcUSEQuantityCarry != CopyAction.Value.CalcUSEQuantityCarry)
                return false;
            if (OriginalAction.Value.CalcBUSavingCarry != CopyAction.Value.CalcBUSavingCarry)
                return false;
            if (OriginalAction.Value.CalcEA1SavingCarry != CopyAction.Value.CalcEA1SavingCarry)
                return false;
            if (OriginalAction.Value.CalcEA2SavingCarry != CopyAction.Value.CalcEA2SavingCarry)
                return false;
            if (OriginalAction.Value.CalcEA3SavingCarry != CopyAction.Value.CalcEA3SavingCarry)
                return false;
            if (OriginalAction.Value.CalcUSESavingCarry != CopyAction.Value.CalcUSESavingCarry)
                return false;
            if (OriginalAction.Value.CalcBUECCCCarry != CopyAction.Value.CalcBUECCCCarry)
                return false;
            if (OriginalAction.Value.CalcEA1ECCCCarry != CopyAction.Value.CalcEA1ECCCCarry)
                return false;
            if (OriginalAction.Value.CalcEA2ECCCCarry != CopyAction.Value.CalcEA2ECCCCarry)
                return false;
            if (OriginalAction.Value.CalcEA3ECCCCarry != CopyAction.Value.CalcEA3ECCCCarry)
                return false;
            if (OriginalAction.Value.CalcUSEECCCCarry != CopyAction.Value.CalcUSEECCCCarry)
                return false;
            if (OriginalAction.Value.PNCEstyma != CopyAction.Value.PNCEstyma)
                return false;
            if (OriginalAction.Value.Leader != CopyAction.Value.Leader)
                return false;
            if (OriginalAction.Value.Platform != CopyAction.Value.Platform)
                return false;
            if (OriginalAction.Value.Installation != CopyAction.Value.Installation)
                return false;
            if (OriginalAction.Value.PerUSE != CopyAction.Value.PerUSE)
                return false;
            if (OriginalAction.Value.PerUSECarry != CopyAction.Value.PerUSECarry)
                return false;
            if (OriginalAction.Value.PerBU != CopyAction.Value.PerBU)
                return false;
            if (OriginalAction.Value.PerBUCarry != CopyAction.Value.PerBUCarry)
                return false;
            if (OriginalAction.Value.PerEA1 != CopyAction.Value.PerEA1)
                return false;
            if (OriginalAction.Value.PerEA1Carry != CopyAction.Value.PerEA1Carry)
                return false;
            if (OriginalAction.Value.PerEA2 != CopyAction.Value.PerEA2)
                return false;
            if (OriginalAction.Value.PerEA2Carry != CopyAction.Value.PerEA2Carry)
                return false;
            if (OriginalAction.Value.PerEA3 != CopyAction.Value.PerEA3)
                return false;
            if (OriginalAction.Value.PerEA3Carry != CopyAction.Value.PerEA3Carry)
                return false;
            if (OriginalAction.Value.Comment != CopyAction.Value.Comment)
                return false;

            return true;
        }
    }
}
