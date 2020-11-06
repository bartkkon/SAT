using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc.Framework
{
    class InitializeData_DataGrid
    {
        private readonly DataGridView _DGV;
        private readonly DataGridView _Summ;
        public InitializeData_DataGrid(DataGridView DGV, DataGridView Summ)
        {
            _DGV = DGV;
            _Summ = Summ;

            CreateTable();
            CreateTableSum();
        }

        private void CreateTableSum()
        {
            _Summ.Columns.Add("1", "I");
            _Summ.Columns.Add("2", "II");
            _Summ.Columns.Add("3", "III");
            _Summ.Columns.Add("4", "IV");
            _Summ.Columns.Add("5", "V");
            _Summ.Columns.Add("6", "VI");
            _Summ.Columns.Add("7", "VII");
            _Summ.Columns.Add("8", "VIII");
            _Summ.Columns.Add("9", "IX");
            _Summ.Columns.Add("10", "X");
            _Summ.Columns.Add("11", "XI");
            _Summ.Columns.Add("12", "XII");
            _Summ.Columns["1"].Width = 90;
            _Summ.Columns["2"].Width = 90;
            _Summ.Columns["3"].Width = 90;
            _Summ.Columns["4"].Width = 90;
            _Summ.Columns["5"].Width = 90;
            _Summ.Columns["6"].Width = 90;
            _Summ.Columns["7"].Width = 90;
            _Summ.Columns["8"].Width = 90;
            _Summ.Columns["9"].Width = 90;
            _Summ.Columns["10"].Width = 90;
            _Summ.Columns["11"].Width = 90;
            _Summ.Columns["12"].Width = 90;

        }

        private void CreateTable()
        {
            _DGV.Columns.Add("PNC", "PNC");
            _DGV.Columns.Add("Saving", "Savings");
            _DGV.Columns.Add("ECCC", "ECCC");
            _DGV.Columns.Add("1", "I");
            _DGV.Columns.Add("2", "II");
            _DGV.Columns.Add("3", "III");
            _DGV.Columns.Add("4", "IV");
            _DGV.Columns.Add("5", "V");
            _DGV.Columns.Add("6", "VI");
            _DGV.Columns.Add("7", "VII");
            _DGV.Columns.Add("8", "VIII");
            _DGV.Columns.Add("9", "IX");
            _DGV.Columns.Add("10", "X");
            _DGV.Columns.Add("11", "XI");
            _DGV.Columns.Add("12", "XII");

            _DGV.Columns["PNC"].Width = 70;
            _DGV.Columns["Saving"].Width = 70;
            _DGV.Columns["ECCC"].Width = 70;
            _DGV.Columns["1"].Width = 70;
            _DGV.Columns["2"].Width = 70;
            _DGV.Columns["3"].Width = 70;
            _DGV.Columns["4"].Width = 70;
            _DGV.Columns["5"].Width = 70;
            _DGV.Columns["6"].Width = 70;
            _DGV.Columns["7"].Width = 70;
            _DGV.Columns["8"].Width = 70;
            _DGV.Columns["9"].Width = 70;
            _DGV.Columns["10"].Width = 70;
            _DGV.Columns["11"].Width = 70;
            _DGV.Columns["12"].Width = 70;

        }
    }
}
