using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework.Actions;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            ClearTable();
            LoadActual();
            SumAndDiff();
            RemoveZero();
        }

        private void SumAndDiff()
        {
            for (int Rows = 0; Rows < 5; Rows++)
            {
                for (int Columns = 0; Columns < 12; Columns++)
                {
                    _ActualTable.Rows[Rows].Cells[12].Value = decimal.Parse(_ActualTable.Rows[Rows].Cells[12].Value.ToString()) + decimal.Parse(_ActualTable.Rows[Rows].Cells[Columns].Value.ToString());
                    _CarryOverTable.Rows[Rows].Cells[12].Value = decimal.Parse(_CarryOverTable.Rows[Rows].Cells[12].Value.ToString()) + decimal.Parse(_CarryOverTable.Rows[Rows].Cells[Columns].Value.ToString());
                    _ECCCTable.Rows[Rows].Cells[12].Value = decimal.Parse(_ECCCTable.Rows[Rows].Cells[12].Value.ToString()) + decimal.Parse(_ECCCTable.Rows[Rows].Cells[Columns].Value.ToString());
                }
            }
            for (int column = 0; column < 2; column++)
            {
                if(decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) !=0)
                {
                    _ActualTable.Rows[5].Cells[column].Value = decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ActualTable.Rows[4].Cells[column].Value.ToString());
                    _CarryOverTable.Rows[5].Cells[column].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_CarryOverTable.Rows[4].Cells[column].Value.ToString());
                    _ECCCTable.Rows[5].Cells[column].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ECCCTable.Rows[4].Cells[column].Value.ToString());
                }
            }

            for (int column = 2; column < 5; column++)
            {
                if (decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) != 0)
                {
                    _ActualTable.Rows[5].Cells[column].Value = decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ActualTable.Rows[3].Cells[column].Value.ToString());
                    _CarryOverTable.Rows[5].Cells[column].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_CarryOverTable.Rows[3].Cells[column].Value.ToString());
                    _ECCCTable.Rows[5].Cells[column].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ECCCTable.Rows[3].Cells[column].Value.ToString());

                }
            }
            for (int column = 5; column < 8; column++)
            {
                if (decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) != 0)
                {
                    _ActualTable.Rows[5].Cells[column].Value = decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ActualTable.Rows[2].Cells[column].Value.ToString());
                    _CarryOverTable.Rows[5].Cells[column].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_CarryOverTable.Rows[2].Cells[column].Value.ToString());
                    _ECCCTable.Rows[5].Cells[column].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ECCCTable.Rows[2].Cells[column].Value.ToString());
                }
            }

            for (int column = 8; column < 12; column++)
            {
                if (decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) != 0)
                {
                    _ActualTable.Rows[5].Cells[column].Value = decimal.Parse(_ActualTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ActualTable.Rows[1].Cells[column].Value.ToString());
                    _CarryOverTable.Rows[5].Cells[column].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_CarryOverTable.Rows[1].Cells[column].Value.ToString());
                    _ECCCTable.Rows[5].Cells[column].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[column].Value.ToString()) - decimal.Parse(_ECCCTable.Rows[1].Cells[column].Value.ToString());
                }
            }

            ColorDiff(_ActualTable);
            ColorDiff(_CarryOverTable);
            ColorDiff(_ECCCTable);
        }

        private void ColorDiff(DataGridView Table)
        {
            for (int counter = 0; counter < 12; counter++)
            {
                if (decimal.Parse(Table.Rows[5].Cells[counter].Value.ToString()) > 0)
                {
                    Table.Rows[5].Cells[counter].Style.ForeColor = Color.Green;
                }
                else if(decimal.Parse(Table.Rows[5].Cells[counter].Value.ToString()) < 0)
                {
                    Table.Rows[5].Cells[counter].Style.ForeColor = Color.Red;
                }
                else
                {
                    Table.Rows[5].Cells[counter].Style.ForeColor = Color.Black;
                }
            }
        }

        private void RemoveZero()
        {
            for (int Rows = 0; Rows < 6; Rows++)
            {
                for (int Columns = 0; Columns < 13; Columns++)
                {
                    if (_ActualTable.Rows[Rows].Cells[Columns].Value.ToString() == "0")
                        _ActualTable.Rows[Rows].Cells[Columns].Value = null;

                    if (_CarryOverTable.Rows[Rows].Cells[Columns].Value.ToString() == "0")
                        _CarryOverTable.Rows[Rows].Cells[Columns].Value = null;

                    if (_ECCCTable.Rows[Rows].Cells[Columns].Value.ToString() == "0")
                        _ECCCTable.Rows[Rows].Cells[Columns].Value = null;
                }
            }
        }

        private void ClearTable()
        {
            for (int Rows = 0; Rows < 6; Rows++)
            {
                for (int Columns = 0; Columns < 13; Columns++)
                {
                    _ActualTable.Rows[Rows].Cells[Columns].Value = 0;
                    _CarryOverTable.Rows[Rows].Cells[Columns].Value = 0;
                    _ECCCTable.Rows[Rows].Cells[Columns].Value = 0;
                }
            }
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
                    _CarryOverTable.Rows[0].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSESavingCarry[counter];
                    _CarryOverTable.Rows[1].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3SavingCarry[counter];
                    _CarryOverTable.Rows[2].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2SavingCarry[counter];
                    _CarryOverTable.Rows[3].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1SavingCarry[counter];
                    _CarryOverTable.Rows[4].Cells[counter].Value = decimal.Parse(_CarryOverTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUSavingCarry[counter];
                    _ECCCTable.Rows[0].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[0].Cells[counter].Value.ToString()) + oneAction.CalcUSEECCCCarry[counter];
                    _ECCCTable.Rows[1].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[1].Cells[counter].Value.ToString()) + oneAction.CalcEA3ECCCCarry[counter];
                    _ECCCTable.Rows[2].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[2].Cells[counter].Value.ToString()) + oneAction.CalcEA2ECCCCarry[counter];
                    _ECCCTable.Rows[3].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[3].Cells[counter].Value.ToString()) + oneAction.CalcEA1ECCCCarry[counter];
                    _ECCCTable.Rows[4].Cells[counter].Value = decimal.Parse(_ECCCTable.Rows[4].Cells[counter].Value.ToString()) + oneAction.CalcBUECCCCarry[counter];
                }
            }
        }
    }
}
