using Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc
{
    public partial class SpecialCalcAction : Form
    {
        private readonly string _ActionName;
        private readonly decimal _Year;
        private DataRow _ActionRow;
        private readonly DataTable _Quantity;
        private readonly DataTable _Savings;
        private readonly DataTable _ECCC;

        public SpecialCalcAction()
        {
            InitializeComponent();
            InitializeData();
            _ActionName = ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text;
            _Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value;
            _Quantity = new DataTable();
            _Savings = new DataTable();
            _ECCC = new DataTable();

            Load_Action();
        }

        private void Load_Action()
        {
            _ActionRow = new Load_Action_SM(_ActionName, _Year).Load();
            CreateTable(_Quantity);
            CreateTable(_Savings);
            CreateTableECCC(_ECCC);
            Load_Inside();
            Load_InsideECCC();
            Load_Table();
            Load_SumTable();

            Load_DataToForm();
        }

        private void Load_InsideECCC()
        {
            string[] PNC;
            string[] ECCC;

            PNC = _ActionRow["PNC"].ToString().Split('|');
            ECCC = _ActionRow["ECCC"].ToString().Split('|');

            for (int counter = 0; counter < PNC.Length - 1; counter++)
            {
                DataRow NewRow = _ECCC.NewRow();

                NewRow["PNC"] = PNC[counter];
                if (ECCC.Length ==1)
                {
                    if(ECCC[0] != "")
                    {
                        NewRow["Value"] = ECCC[0];
                    }
                }
                else if(ECCC.Length >1)
                {
                    NewRow["Value"] = ECCC[counter];
                }
                _ECCC.Rows.Add(NewRow);
            }
        }

        private void Load_DataToForm()
        {
            tb_Comments.Text = _ActionRow["Comment"].ToString();
            if (_ActionRow["StartYear"].ToString() == "SA/" + _Year.ToString())
            {
                cb_SingleAction.Checked = true;
            }
        }

        private void Load_SumTable()
        {
            decimal[] Quantity = new decimal[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal[] Savings = new decimal[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal[] ECCC = new decimal[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal Kurs;

            Kurs = Load_ECCCKurs(_ActionRow["StartYear"].ToString());


            foreach (DataRow Row in _Quantity.Rows)
            {
                for (int counter = 1; counter <= 12; counter++)
                {
                    if (Row[counter.ToString()] != null && Row[counter.ToString()].ToString() != "")
                    {
                        Quantity[counter - 1] += decimal.Parse(Row[counter.ToString()].ToString());
                        DataRow ECCCPNC = _ECCC.Select(string.Format("PNC LIKE '%{0}%'", Row["PNC"].ToString())).FirstOrDefault();
                        if(ECCCPNC != null)
                        {
                            if(ECCCPNC["Value"] != null && ECCCPNC["Value"].ToString() != "")
                            {
                                ECCC[counter - 1] += (decimal.Parse(Row[counter.ToString()].ToString()) * Kurs * decimal.Parse(ECCCPNC["Value"].ToString()));
                            }
                        }
                    }
                }
            }

            foreach (DataRow Row in _Savings.Rows)
            {
                for (int counter = 1; counter <= 12; counter++)
                {
                    if (Row[counter.ToString()] != null && Row[counter.ToString()].ToString() != "")
                        Savings[counter - 1] += decimal.Parse(Row[counter.ToString()].ToString());
                }
            }

            int QuantityCount = DGV_Suma.Rows.Add();
            int SavingsCount = DGV_Suma.Rows.Add();
            int ECCCCount = DGV_Suma.Rows.Add();
            DGV_Suma.Rows[QuantityCount].DefaultCellStyle.Format = "#,#0.####";
            DGV_Suma.Rows[SavingsCount].DefaultCellStyle.Format = "#,#0.";
            DGV_Suma.Rows[ECCCCount].DefaultCellStyle.Format = "#,#0.";
            for (int counter = 1; counter <= 12; counter++)
            {
                DGV_Suma[counter.ToString(), QuantityCount].Value = Quantity[counter - 1];
                DGV_Suma[counter.ToString(), SavingsCount].Value = Savings[counter - 1];
                DGV_Suma[counter.ToString(), ECCCCount].Value = ECCC[counter - 1];
            }
        }

        private decimal Load_ECCCKurs(string StartYear)
        {
            decimal Kurs = 0;
            DataTable AllKursy = new DataTable();
            DataRow KursyYear;

            if (StartYear.Length != 4)
            {
                StartYear = StartYear.Remove(0, 3);
            }

            Data_Import.Singleton().Load_TxtToDataTable2(ref AllKursy, "Kurs");
            KursyYear = AllKursy.Select(string.Format("Year LIKE '%{0}%'", StartYear)).FirstOrDefault();
            if (KursyYear != null)
            {
                if (KursyYear["ECCC"] != null && KursyYear["ECCC"].ToString() != "")
                    Kurs = decimal.Parse(KursyYear["ECCC"].ToString());
            }

            return Kurs;
        }

        private void CreateTable(DataTable Table)
        {
            Table.Columns.Add("PNC");
            Table.Columns.Add("1");
            Table.Columns.Add("2");
            Table.Columns.Add("3");
            Table.Columns.Add("4");
            Table.Columns.Add("5");
            Table.Columns.Add("6");
            Table.Columns.Add("7");
            Table.Columns.Add("8");
            Table.Columns.Add("9");
            Table.Columns.Add("10");
            Table.Columns.Add("11");
            Table.Columns.Add("12");
        }

        private void CreateTableECCC(DataTable TableECCC)
        {
            TableECCC.Columns.Add("PNC");
            TableECCC.Columns.Add("Value");
        }

        private void Load_Inside()
        {
            string[] PNC;

            PNC = _ActionRow["PerUSE"].ToString().Split('/');

            for (int counter = 0; counter < PNC.Length - 1; counter++)
            {
                string[] Specific = PNC[counter].Split('|');
                if (Specific[0] != "")
                {
                    DataRow QuantityRow = _Quantity.NewRow();
                    DataRow SavingsRow = _Savings.NewRow();
                    QuantityRow["PNC"] = Specific[0];
                    SavingsRow["PNC"] = Specific[0];

                    for (int counter2 = 1; counter2 <= 12; counter2++)
                    {
                        if (Specific[counter2] != "")
                        {
                            string[] Final = Specific[counter2].Split(':');
                            QuantityRow[counter2.ToString()] = Final[0];
                            SavingsRow[counter2.ToString()] = Final[1];
                        }
                    }
                    _Quantity.Rows.Add(QuantityRow);
                    _Savings.Rows.Add(SavingsRow);
                }
            }
        }

        private void Load_Table()
        {
            Dgv_Action.CellValueChanged -= Dgv_Action_CellValueChanged;
            string[] PNC = _ActionRow["PNC"].ToString().Split('|');
            string[] Delta = _ActionRow["PNCSumDelta"].ToString().Split('|');
            string[] ECCC = _ActionRow["ECCC"].ToString().Split('|');
            DataRow Quantity;
            DataRow Savings;
            int RowCount;
            int SavingCount;

            for (int counter = 0; counter < PNC.Length - 1; counter++)
            {
                if (Cb_Quantity.Checked)
                {
                    RowCount = Dgv_Action.Rows.Add();


                    Dgv_Action["PNC", RowCount].Value = PNC[counter];
                    Dgv_Action["Saving", RowCount].Value = Delta[counter];

                    DataRow ECCCRow = _ECCC.Select(string.Format("PNC LIKE '%{0}%'", PNC[counter])).FirstOrDefault();

                    if(ECCCRow != null)
                    {
                        if(ECCCRow["Value"] != null && ECCCRow["Value"].ToString() != "")
                        {
                            Dgv_Action["ECCC", RowCount].Value = ECCCRow["Value"];
                        }
                    }

                    Quantity = _Quantity.Select(string.Format("PNC LIKE '%{0}%'", PNC[counter])).FirstOrDefault();
                    if (Quantity != null)
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (Quantity[counter2.ToString()] != null && Quantity[counter2.ToString()].ToString() != "")
                            {
                                Dgv_Action[counter2.ToString(), RowCount].Value = double.Parse(Quantity[counter2.ToString()].ToString());
                            }
                        }
                    }
                    FormattingRow(Dgv_Action.Rows[RowCount], "Quantity");
                }
                if (Cb_Savings.Checked)
                {
                    SavingCount = Dgv_Action.Rows.Add();

                    if (!Cb_Quantity.Checked)
                    {
                        Dgv_Action["PNC", SavingCount].Value = PNC[counter];
                        Dgv_Action["Saving", SavingCount].Value = Delta[counter];

                        DataRow ECCCRow = _ECCC.Select(string.Format("PNC LIKE '%{0}%'", PNC[counter])).FirstOrDefault();

                        if (ECCCRow != null)
                        {
                            if (ECCCRow["Value"] != null && ECCCRow["Value"].ToString() != "")
                            {
                                Dgv_Action["ECCC", SavingCount].Value = ECCCRow["Value"];
                            }
                        }
                    }
                    Savings = _Savings.Select(string.Format("PNC LIKE '%{0}%'", PNC[counter])).FirstOrDefault();

                    if (Savings != null)
                    {
                        for (int counter2 = 1; counter2 <= 12; counter2++)
                        {
                            if (Savings[counter2.ToString()] != null && Savings[counter2.ToString()].ToString() != "")
                            {
                                Dgv_Action[counter2.ToString(), SavingCount].Value = double.Parse(Savings[counter2.ToString()].ToString());
                            }
                        }
                    }
                    FormattingRow(Dgv_Action.Rows[SavingCount], "Saving");
                }
            }
            Dgv_Action.CellValueChanged += Dgv_Action_CellValueChanged;
        }

        private void FormattingRow(DataGridViewRow FormattingRow, string What)
        {
            FormattingRow.DefaultCellStyle.Format = "#,0.####";

            if (What == "Saving")
            {
                FormattingRow.DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            }
            else if (What == "Quantity")
            {

            }
        }

        private void InitializeData()
        {
            _ = new InitializeData_DataGrid(Dgv_Action, DGV_Suma);
        }

        private void Cb_Savings_CheckedChanged(object sender, EventArgs e)
        {
            Dgv_Action.Rows.Clear();
            Load_Table();
        }

        private void Dgv_Action_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int Row = e.RowIndex;
            int Column = e.ColumnIndex;
            decimal Savings;
            string PNC;

            if (Dgv_Action["PNC", Row].Value == null || Dgv_Action["PNC", Row].Value.ToString() == "")
            {
                Load_Table();
            }
            else
            {
                if (Column <= 1)
                {
                    Load_Table();
                }
                else
                {
                    PNC = Dgv_Action["PNC", Row].Value.ToString();
                    Savings = decimal.Parse(Dgv_Action["Saving", Row].Value.ToString());
                    DataRow FoundRow = _Quantity.Select(string.Format("PNC LIKE '%{0}%'", PNC)).FirstOrDefault();
                    if(FoundRow == null)
                    {
                        DataRow NewRow = _Quantity.NewRow();
                        NewRow["PNC"] = PNC;
                        _Quantity.Rows.Add(NewRow);
                        NewRow = _Savings.NewRow();
                        NewRow["PNC"] = PNC;
                        _Savings.Rows.Add(NewRow);
                        FoundRow = _Quantity.Select(string.Format("PNC LIKE '%{0}%'", PNC)).FirstOrDefault();
                    }
                    FoundRow[(Column - 2).ToString()] = Dgv_Action[Column, Row].Value;
                    FoundRow = _Savings.Select(string.Format("PNC LIKE '%{0}%'", PNC)).First();
                    FoundRow[(Column - 2).ToString()] = (decimal.Parse(Dgv_Action[Column, Row].Value.ToString()) * Savings);

                    Dgv_Action.Rows.Clear();
                    Load_Table();
                    DGV_Suma.Rows.Clear();
                    Load_SumTable();
                }
            }
        }

        private void Pb_SaveChange_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new Save_Action_SM(_Quantity, _Savings, DGV_Suma, cb_SingleAction.Checked, tb_Comments.Text, _ActionName, _Year);
            Cursor.Current = Cursors.Default;
            this.Close();
        }
    }
}
