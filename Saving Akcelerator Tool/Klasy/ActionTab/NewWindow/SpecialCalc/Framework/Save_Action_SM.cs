using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc.Framework
{
    class Save_Action_SM
    {
        private readonly DataTable _Quantity;
        private readonly DataTable _Savings;
        private readonly DataGridView _SumTable;
        private readonly bool _SingleAction;
        private readonly string _Comment;
        private readonly string _ActionName;
        private readonly decimal _Year;
        public Save_Action_SM(DataTable Quantity, DataTable Savings, DataGridView SumTable, bool SingleAction, string Comments, string ActionName, decimal Year)
        {
            _Quantity = Quantity;
            _Savings = Savings;
            _SumTable = SumTable;
            _SingleAction = SingleAction;
            _Comment = Comments;
            _ActionName = ActionName;
            _Year = Year;

            Save();
        }

        private void Save()
        {
            DataTable AllAction = new DataTable();
            DataRow[] FoundRows;
            string[] AllString;
            string[] OnePNC;
            string[] SumQuantity;
            string[] SumSavings;
            decimal AllQuantity = 0;
            decimal AllSavings = 0;
            decimal AllECCC = 0;

            Data_Import.Singleton().Load_TxtToDataTable2(ref AllAction, "Action");

            FoundRows = AllAction.Select(string.Format("Name LIKE '%{0}%'", _ActionName)).ToArray();

            foreach (DataRow Row in FoundRows)
            {
                if (Row["StartYear"].ToString() == _Year.ToString() || Row["StartYear"].ToString() == "SA/" + _Year.ToString())
                {
                    if (_SingleAction)
                    {
                        Row["StartYear"] = "SA/" + _Year;
                    }
                    Row["Comment"] = _Comment;

                    AllString = Row["PerUSE"].ToString().Split('/');
                    Row["PerUSE"] = "";


                    for (int counter = 0; counter < AllString.Length - 1; counter++)
                    {
                        OnePNC = AllString[counter].Split('|');
                        AllString[counter] = UpdateDataForTable(OnePNC);
                        Row["PerUse"] += AllString[counter] + "/";
                    }



                    SumQuantity = Row["CalcUseQuantity"].ToString().Split('/');
                    SumSavings = Row["CalcUSESaving"].ToString().Split('/');
                    Row["CalcUseQuantity"] = "";
                    Row["CalcUSESaving"] = "";
                    Row["CalcUSEECCC"] = "";


                    //Sumowanie wszystkiego do wyświetlania w akcji
                    for (int counter = 1; counter <= 12; counter++)
                    {
                        if (_SumTable[counter.ToString(), 0].Value.ToString() != "" && _SumTable[counter.ToString(), 0].Value.ToString() != "0")
                        {
                            AllQuantity += decimal.Parse(_SumTable[counter.ToString(), 0].Value.ToString());
                            Row["CalcUseQuantity"] += _SumTable[counter.ToString(), 0].Value.ToString();

                            AllSavings += decimal.Parse(_SumTable[counter.ToString(), 1].Value.ToString());
                            Row["CalcUSESaving"] += Math.Round(decimal.Parse(_SumTable[counter.ToString(), 1].Value.ToString()), 0, MidpointRounding.AwayFromZero).ToString();

                            if (_SumTable[counter.ToString(), 1].Value.ToString() != "" && _SumTable[counter.ToString(), 1].Value.ToString() != "0")
                            {
                                AllECCC += decimal.Parse(_SumTable[counter.ToString(), 1].Value.ToString());
                                Row["CalcUSEECCC"] += Math.Round(decimal.Parse(_SumTable[counter.ToString(), 2].Value.ToString()), 0, MidpointRounding.AwayFromZero).ToString();
                            }
                        }
                        Row["CalcUseQuantity"] += "/";
                        Row["CalcUSESaving"] += "/";
                        Row["CalcUSEECCC"] += "/";
                    }
                    Row["CalcUseQuantity"] += AllQuantity.ToString() + "/";
                    Row["CalcUSESaving"] += Math.Round(AllSavings, 0, MidpointRounding.AwayFromZero).ToString() + "/";
                    Row["CalcUSEECCC"] += Math.Round(AllECCC, 0, MidpointRounding.AwayFromZero).ToString() + "/";
                }
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref AllAction, "Action");
        }

        private string UpdateDataForTable(string[] onePNC)
        {
            DataRow QuantityRow;
            DataRow SavingsRow;
            string Final = "";

            QuantityRow = _Quantity.Select(string.Format("PNC LIKE '%{0}%'", onePNC[0])).FirstOrDefault();
            if (QuantityRow != null)
            {
                SavingsRow = _Savings.Select(string.Format("PNC LIKE '%{0}%'", onePNC[0])).FirstOrDefault();

                if (SavingsRow != null)
                {
                    for (int counter = 1; counter <= 12; counter++)
                    {
                        onePNC[counter] = QuantityRow[counter.ToString()].ToString() + ":" + SavingsRow[counter.ToString()].ToString();
                    }
                }
            }

            for (int counter = 0; counter < 13; counter++)
            {
                Final += onePNC[counter] + "|";
            }

            return Final;
        }
    }
}
