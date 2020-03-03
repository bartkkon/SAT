using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework
{
    class SumAllAction
    {
        private readonly List<AllAction> _Actual;
        private readonly List<AllAction> _CarryOver;
        private readonly DataGridView _ActualTable;
        private readonly DataGridView _CarryOverTable;
        private readonly DataGridView _ECCCTable;

        public SumAllAction(List<AllAction> Actual, List<AllAction> CarryOver)
        {
            _Actual = Actual;
            _CarryOver = CarryOver;
            _ActualTable = MainProgram.Self.SDSumAllAction.GetActual();
            _CarryOverTable = MainProgram.Self.SDSumAllAction.GetCarryOver();
            _ECCCTable = MainProgram.Self.SDSumAllAction.GetECCC();

            LoadActual();
        }

        private void LoadActual()
        {
            foreach (AllAction oneAction in _Actual)
            {
                for (int counter = 0; counter < 12; counter++)
                {
                    _ActualTable.Rows[0].Cells[counter].Value = decimal.Parse(_ActualTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSESaving[counter];
                    _ActualTable.Rows[1].Cells[counter].Value = decimal.Parse(_ActualTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3Saving[counter];
                    _ActualTable.Rows[2].Cells[counter].Value = decimal.Parse(_ActualTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2Saving[counter];
                    _ActualTable.Rows[3].Cells[counter].Value = decimal.Parse(_ActualTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1Saving[counter];
                    _ActualTable.Rows[4].Cells[counter].Value = decimal.Parse(_ActualTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUSaving[counter];
                    _ECCCTable.Rows[0].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSEECCC[counter];
                    _ECCCTable.Rows[1].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3ECCC[counter];
                    _ECCCTable.Rows[2].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2ECCC[counter];
                    _ECCCTable.Rows[3].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1ECCC[counter];
                    _ECCCTable.Rows[4].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUECCC[counter];
                }
            }

            foreach (AllAction oneAction in _CarryOver)
            {
                for (int counter = 0; counter < 12; counter++)
                {
                    _CarryOverTable.Rows[0].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSESaving[counter];
                    _CarryOverTable.Rows[1].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3Saving[counter];
                    _CarryOverTable.Rows[2].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2Saving[counter];
                    _CarryOverTable.Rows[3].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1Saving[counter];
                    _CarryOverTable.Rows[4].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUSaving[counter];
                    _ECCCTable.Rows[0].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSEECCC[counter];
                    _ECCCTable.Rows[1].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3ECCC[counter];
                    _ECCCTable.Rows[2].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2ECCC[counter];
                    _ECCCTable.Rows[3].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1ECCC[counter];
                    _ECCCTable.Rows[4].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUECCC[counter];
                }
            }
        }
    }
}
