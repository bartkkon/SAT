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
        public PNCListView()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            dg_PNC.Rows.Clear();
            dg_PNC.Columns.Clear();
        }

        public void SetPNC(DataTable PNCList)
        {
            NewColumn(dg_PNC, "PNC", 80, Color.Black);

            foreach (DataRow Row in PNCList.Rows)
            {
                dg_PNC.Rows.Add(Row[0]);
            }
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
