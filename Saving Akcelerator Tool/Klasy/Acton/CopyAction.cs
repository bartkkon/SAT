using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    class CopyAction : Action
    {
        private static CopyAction _instance;
        private static readonly object syncRoot = new object();

        private CopyAction()
        {
            Copy();
        }

        public static CopyAction Value
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                        if (_instance == null)
                        {
                            _instance = new CopyAction();
                        }
                }
                return _instance;
            }
        }

        public static CopyAction Delete
        {
            get
            {
                if (_instance != null)
                {
                    lock (syncRoot)
                        if (_instance != null)
                        {
                            _instance = null;
                        }
                }
                return _instance;
            }
        }

        private void Copy()
        {
            Name = OriginalAction.Value.Name;
            Description = OriginalAction.Value.Description;
            Group = OriginalAction.Value.Group;
            Status = OriginalAction.Value.Status;
            StartYear = OriginalAction.Value.StartYear;
            StartMonth = OriginalAction.Value.StartMonth;
            Factory = OriginalAction.Value.Factory;
            Calculate = OriginalAction.Value.Calculate;
            IloscANC = OriginalAction.Value.IloscANC;
            OldANC = OriginalAction.Value.OldANC;
            OldANCQ = OriginalAction.Value.OldANCQ;
            NewANC = OriginalAction.Value.NewANC;
            NewANCQ = OriginalAction.Value.NewANCQ;
            IDCO = OriginalAction.Value.IDCO;
            OldSTK = OriginalAction.Value.OldSTK;
            NewSTK = OriginalAction.Value.NewSTK;
            Poz_Neg = OriginalAction.Value.Poz_Neg;
            Delta = OriginalAction.Value.Delta;
            STKEst = OriginalAction.Value.STKEst;
            Percent = OriginalAction.Value.Percent;
            STKCal = OriginalAction.Value.STKCal;
            ECCC = OriginalAction.Value.ECCC;
            CalcMass = OriginalAction.Value.CalcMass;
            Calc = OriginalAction.Value.Calc;
            Next = OriginalAction.Value.Next;
            PNC = OriginalAction.Value.PNC;
            PNCANC = OriginalAction.Value.PNCANC;
            PNCANCQ = OriginalAction.Value.PNCANCQ;
            PNCSTK = OriginalAction.Value.PNCSTK;
            PNCDelta = OriginalAction.Value.PNCDelta;
            PNCSumSTK = OriginalAction.Value.PNCSumSTK;
            PNCSumDelta = OriginalAction.Value.PNCSumDelta;
            PNCANCPersent = OriginalAction.Value.PNCANCPersent;
            CalcBUQuantity = OriginalAction.Value.CalcBUQuantity;
            CalcEA1Quantity = OriginalAction.Value.CalcEA1Quantity;
            CalcEA2Quantity = OriginalAction.Value.CalcEA2Quantity;
            CalcEA3Quantity = OriginalAction.Value.CalcEA3Quantity;
            CalcUSEQuantity = OriginalAction.Value.CalcUSEQuantity;
            CalcBUSaving = OriginalAction.Value.CalcBUSaving;
            CalcEA1Saving = OriginalAction.Value.CalcEA1Saving;
            CalcEA2Saving = OriginalAction.Value.CalcEA2Saving;
            CalcEA3Saving = OriginalAction.Value.CalcEA3Saving;
            CalcEA4Saving = OriginalAction.Value.CalcEA4Saving;
            CalcUSESaving = OriginalAction.Value.CalcUSESaving;
            CalcBUECCC = OriginalAction.Value.CalcBUECCC;
            CalcEA1ECCC = OriginalAction.Value.CalcEA1ECCC;
            CalcEA2ECCC = OriginalAction.Value.CalcEA2ECCC;
            CalcEA3ECCC = OriginalAction.Value.CalcEA3ECCC;
            CalcUSEECCC = OriginalAction.Value.CalcUSEECCC;
            CalcBUQuantityCarry = OriginalAction.Value.CalcBUQuantityCarry;
            CalcEA1QuantityCarry = OriginalAction.Value.CalcEA1QuantityCarry;
            CalcEA2QuantityCarry = OriginalAction.Value.CalcEA2QuantityCarry;
            CalcEA3QuantityCarry = OriginalAction.Value.CalcEA3QuantityCarry;
            CalcUSEQuantityCarry = OriginalAction.Value.CalcUSEQuantityCarry;
            CalcBUSavingCarry = OriginalAction.Value.CalcBUSavingCarry;
            CalcEA1SavingCarry = OriginalAction.Value.CalcEA1SavingCarry;
            CalcEA2SavingCarry = OriginalAction.Value.CalcEA2SavingCarry;
            CalcEA3SavingCarry = OriginalAction.Value.CalcEA3SavingCarry;
            CalcUSESavingCarry = OriginalAction.Value.CalcUSESavingCarry;
            CalcBUECCCCarry = OriginalAction.Value.CalcBUECCCCarry;
            CalcEA1ECCCCarry = OriginalAction.Value.CalcEA1ECCCCarry;
            CalcEA2ECCCCarry = OriginalAction.Value.CalcEA2ECCCCarry;
            CalcEA3ECCCCarry = OriginalAction.Value.CalcEA3ECCCCarry;
            CalcUSEECCCCarry = OriginalAction.Value.CalcUSEECCCCarry;
            PNCEstyma = OriginalAction.Value.PNCEstyma;
            Leader = OriginalAction.Value.Leader;
            Platform = OriginalAction.Value.Platform;
            Installation = OriginalAction.Value.Installation;
            PerUSE = OriginalAction.Value.PerUSE;
            PerUSECarry = OriginalAction.Value.PerUSECarry;
            PerBU = OriginalAction.Value.PerBU;
            PerBUCarry = OriginalAction.Value.PerBUCarry;
            PerEA1 = OriginalAction.Value.PerEA1;
            PerEA1Carry = OriginalAction.Value.PerEA1Carry;
            PerEA2 = OriginalAction.Value.PerEA2;
            PerEA2Carry = OriginalAction.Value.PerEA2Carry;
            PerEA3 = OriginalAction.Value.PerEA3;
            PerEA3Carry = OriginalAction.Value.PerEA3Carry;
            Comment = OriginalAction.Value.Comment;
        }
    }
}
