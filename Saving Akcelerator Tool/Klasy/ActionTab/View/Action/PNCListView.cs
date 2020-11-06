using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class PNCListView : UserControl
    {
        private Dictionary<string, string> IDCO = new Dictionary<string, string>();

        public PNCListView()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            dg_PNC.Rows.Clear();
            dg_PNC.Columns.Clear();
            IDCO.Clear();
        }

        public void SetPNC(DataTable PNCList)
        {
            Clear();
            NewColumn(dg_PNC, "PNC", 80, Color.Black);

            foreach (DataRow Row in PNCList.Rows)
            {
                dg_PNC.Rows.Add(Row[0]);
            }
        }

        public void SetPNCSpecial(DataTable TableToAdd)
        {
            Clear();
            NewColumn(dg_PNC, "PNC", 80, Color.Black);
            NewColumn(dg_PNC, "OLD ANC", 75, Color.Red);
            NewColumn(dg_PNC, "OLD Q", 35, Color.Red);
            NewColumn(dg_PNC, "NEW ANC", 75, Color.Green);
            NewColumn(dg_PNC, "NEW Q", 35, Color.Green);
            NewColumn(dg_PNC, "OLD STK", 70, Color.Red);
            NewColumn(dg_PNC, "NEW STK", 70, Color.Green);
            NewColumn(dg_PNC, "Delta", 70, Color.Black);

            foreach (DataRow Row in TableToAdd.Rows)
            {
                dg_PNC.Rows.Add(Row.ItemArray);
            }

            ColorTable();
        }
        public void AddIDCOValue(string ANC, string ANC_IDCO)
        {
            IDCO.Add(ANC, ANC_IDCO);
        }

        public void SetIDCoLoad(Dictionary<string, string> LoadIDCO)
        {
            IDCO.Clear();
            IDCO = LoadIDCO;
        }

        public string GetIDCO(string ANC)
        {
            if (ANC != string.Empty)
            {
                if (IDCO.ContainsKey(ANC))
                    return IDCO[ANC];
            }
            return string.Empty;
        }

        private void ColorTable()
        {
            foreach(DataGridViewRow Row in dg_PNC.Rows)
            {
                if(Row.Cells["PNC"].Value.ToString() != string.Empty)
                {
                    Row.DefaultCellStyle.BackColor = Color.LightBlue;
                    Row.DefaultCellStyle.Font = new Font(dg_PNC.Font, FontStyle.Bold);
                    Row.Cells[1].Style.Font = new Font(dg_PNC.Font, FontStyle.Regular);
                }
                if (Row.Cells["Delta"].Value.ToString() != string.Empty)
                {
                    double Delta = Convert.ToDouble(Row.Cells["Delta"].Value.ToString());
                    if (Delta > 0)
                    {
                        Row.Cells["Delta"].Style.ForeColor = Color.Green;
                    }
                    else if (Delta < 0)
                    {
                        Row.Cells["Delta"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.Cells["Delta"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        public DataTable GetDataTable()
        {
            DataTable ExistTable = new DataTable();

            foreach (DataGridViewColumn Column in dg_PNC.Columns)
            {
                ExistTable.Columns.Add(Column.Name);
            }

            foreach(DataGridViewRow Row in dg_PNC.Rows)
            {
                DataRow NewRow = ExistTable.NewRow();

                foreach(DataGridViewColumn Column in dg_PNC.Columns)
                {
                    NewRow[Column.Name] = Row.Cells[Column.Name].Value; 
                }

                ExistTable.Rows.Add(NewRow);
            }

            return ExistTable;
        }


        public DataGridView GetTable()
        {
            return dg_PNC;
        }

        public void SetPNCSpec(DataTable PNCList, DataTable ANCList, DataTable QuantitlyList, DataTable STKList, DataTable Deltalist, DataTable PNCSumSTKList, DataTable SumDeltaList, decimal[] ECCC)
        {
            bool ECCCCalc = false;

            NewColumn(dg_PNC, "PNC", 80, Color.Black);
            NewColumn(dg_PNC, "OLD ANC", 70, Color.Red);
            NewColumn(dg_PNC, "OLD Q", 35, Color.Red);
            NewColumn(dg_PNC, "NEW ANC", 70, Color.Green);
            NewColumn(dg_PNC, "NEW Q", 35, Color.Green);
            NewColumn(dg_PNC, "OLD STK", 70, Color.Red);
            NewColumn(dg_PNC, "NEW STK", 70, Color.Green);
            NewColumn(dg_PNC, "Delta", 70, Color.Black);

            if (ECCC.Length > 1)
                ECCCCalc = true;

            for (int counter = 0; counter < PNCList.Rows.Count; counter++)
            {
                int index = dg_PNC.Rows.Add();
                DataGridViewRow NewRow = dg_PNC.Rows[index];

                NewRow.Cells["PNC"].Value = PNCList.Rows[counter][0];

                if (ECCCCalc)
                    NewRow.Cells["OLD ANC"].Value = "ECCC(" + ECCC[counter].ToString() + ")";

                NewRow.Cells["OLD STK"].Value = PNCSumSTKList.Rows[counter][1];
                NewRow.Cells["NEW STK"].Value = PNCSumSTKList.Rows[counter][2];
                NewRow.Cells["Delta"].Value = SumDeltaList.Rows[counter][1];

                ColorPNC(ref NewRow, dg_PNC.Font);
                ColorDelta(ref NewRow);

                DataRow[] ANCData = ANCList.Select("PNC = '" + Convert.ToInt64(counter) +"'");
                DataRow[] QuantityData = QuantitlyList.Select("PNC = '" + Convert.ToInt64(counter) + "'");
                DataRow[] STKData = STKList.Select("PNC = '" + Convert.ToInt64(counter) + "'");
                DataRow[] DeltaData = Deltalist.Select("PNC = '" + Convert.ToInt64(counter) + "'");

                for (int counter2 =0; counter2<ANCData.Length; counter2++)
                {
                    index = dg_PNC.Rows.Add();
                    NewRow = dg_PNC.Rows[index];
                    NewRow.Cells["OLD ANC"].Value = ANCData[counter2][1];
                    NewRow.Cells["OLD Q"].Value = QuantityData[counter2][1];
                    NewRow.Cells["NEW ANC"].Value = ANCData[counter2][2];
                    NewRow.Cells["NEW Q"].Value = QuantityData[counter2][2];
                    NewRow.Cells["OLD STK"].Value = STKData[counter2][1];
                    NewRow.Cells["NEW STK"].Value = STKData[counter2][2];
                    NewRow.Cells["Delta"].Value = DeltaData[counter2][1];

                    ColorDelta(ref NewRow);
                }
            }
        }

        private void NewColumn(DataGridView Table, string Name, int Width, Color color)
        {
            DataGridViewColumn NewColumn = new DataGridViewTextBoxColumn
            {
                Name = Name,
                HeaderText = Name,
                Width = Width,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ValueType = typeof(String),
            };
            NewColumn.DefaultCellStyle.ForeColor = color;
            Table.Columns.Add(NewColumn);
        }

        //Kolorowanie odpowiednie dla PNC 
        private void ColorPNC(ref DataGridViewRow NewRow, Font font)
        {
            NewRow.DefaultCellStyle.BackColor = Color.LightBlue;
            NewRow.DefaultCellStyle.Font = new Font(font, FontStyle.Bold); //MS UI Gothic, 9 punkt.
            NewRow.Cells["OLD ANC"].Style.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        //Kolorowanie Delty dla PNCSpec
        private void ColorDelta(ref DataGridViewRow NewRow)
        {
            decimal Delta = decimal.Parse(NewRow.Cells["Delta"].Value.ToString());

            if (Delta > 0)
            {
                NewRow.Cells["Delta"].Style.ForeColor = Color.Green;
            }
            else if (Delta < 0)
            {
                NewRow.Cells["Delta"].Style.ForeColor = Color.Red;
            }

        }
    }
}
