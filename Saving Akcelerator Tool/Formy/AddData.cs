using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Saving_Accelerator_Tool.Klasy.AddDataView;
using Saving_Accelerator_Tool.Model;
using Saving_Accelerator_Tool.Controllers;

namespace Saving_Accelerator_Tool
{
    public partial class AddData : Form
    {
        private readonly string Jak;
        private readonly decimal Year;
        private readonly decimal _Month;
        private readonly bool _ANC;

        public AddData(string text, string What)
        {
            InitializeComponent();
            lab_AddData_Text.Text = text;

            Jak = What;

            if (Jak == "PNCSpec")
            {
                PB_CopyTemplate.Visible = true;
            }
        }

        public AddData(string text, decimal Year)
        {
            InitializeComponent();
            lab_AddData_Text.Text = text;
            this.Year = Year;

            this.Show();

            Button Close = (Button)this.Controls.Find("pb_AddData_Close", true).First();
            Close.Click -= Pb_AddData_Close_Click;
            Close.Click += Pb_AddData_STK_Close_Click;

            MessageBox.Show("Information:" + Environment.NewLine + "4 Excelowe kolumny!" + Environment.NewLine + "ANC | Description | IDCO | Value");
        }

        public AddData(string text, decimal Year, decimal Month, string What)
        {
            InitializeComponent();
            lab_AddData_Text.Text = text;

            Jak = What;
            this.Year = Year;
            _Month = Month;
        }

        public AddData(string text, decimal Year, string What, bool ANC)
        {
            InitializeComponent();
            lab_AddData_Text.Text = text;

            Jak = What;
            this.Year = Year;
            _ANC = ANC;
        }


        private void Pb_AddData_STK_Close_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string[] Data = tb_AddData_Data.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (Data.Length == 1 && Data[0] == "")
            {
                return;
            }

            _ = new ManualUpdateSTK(Data, Convert.ToInt32(Year));

            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void Pb_AddData_Close_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] row = tb_AddData_Data.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            bool IFCalc = false;

            if (row[0] != "")
            {
                if (Jak == "PNC")
                {

                    DataGridView dg_PNC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();

                    if (dg_PNC.Rows.Count > 1)
                    {
                        DialogResult result = MessageBox.Show("Do you want replace all PNC in this Action ?", "Warning!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            dg_PNC.Rows.Clear();
                            dg_PNC.Columns.Clear();
                            dg_PNC.Columns.Add("PNC", "PNC");
                            dg_PNC.Columns["PNC"].Width = 63;
                            dg_PNC.Columns["PNC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            IFCalc = true;
                        }
                        else if (result == DialogResult.No)
                        {
                            DialogResult result2 = MessageBox.Show("Do you want add this PNC to exisitng PNC for this Action ?", "Warning!", MessageBoxButtons.YesNo);
                            if (result2 == DialogResult.Yes)
                            {
                                IFCalc = true;
                            }
                            else if (result2 == DialogResult.No)
                            {
                                IFCalc = false;
                            }
                        }
                    }
                    else
                    {
                        dg_PNC.Rows.Clear();
                        dg_PNC.Columns.Clear();
                        dg_PNC.Columns.Add("PNC", "PNC");
                        dg_PNC.Columns["PNC"].Width = 63;
                        dg_PNC.Columns["PNC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        IFCalc = true;
                    }


                    if (IFCalc)
                    {
                        for (int counter = 0; counter < row.Length - 1; counter++)
                        {
                            if (row[counter] != "")
                            {
                                dg_PNC.Rows.Add(row[counter]);
                            }
                        }
                    }
                    this.Close();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                if (Jak == "PNCSpec")
                {
                    DataGridView dg_PNC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();

                    if (dg_PNC.Rows.Count > 1)
                    {
                        DialogResult result = MessageBox.Show("Do you want replace all PNC in this Action ?", "Warning!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            dg_PNC.Rows.Clear();
                            dg_PNC.Columns.Clear();
                            dg_PNC.Columns.Add("PNC", "PNC");
                            dg_PNC.Columns.Add("OLD ANC", "OLD ANC");
                            dg_PNC.Columns.Add("OLD Q", "Q");
                            dg_PNC.Columns.Add("NEW ANC", "NEW ANC");
                            dg_PNC.Columns.Add("NEW Q", "Q");
                            dg_PNC.Columns["PNC"].Width = 80;
                            dg_PNC.Columns["OLD ANC"].Width = 65;
                            dg_PNC.Columns["OLD ANC"].DefaultCellStyle.ForeColor = Color.Red;
                            dg_PNC.Columns["OLD Q"].Width = 35;
                            dg_PNC.Columns["OLD Q"].DefaultCellStyle.ForeColor = Color.Red;
                            dg_PNC.Columns["NEW ANC"].Width = 65;
                            dg_PNC.Columns["NEW ANC"].DefaultCellStyle.ForeColor = Color.Green;
                            dg_PNC.Columns["NEW Q"].Width = 35;
                            dg_PNC.Columns["NEW Q"].DefaultCellStyle.ForeColor = Color.Green;
                            dg_PNC.Columns["PNC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dg_PNC.Columns["OLD ANC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dg_PNC.Columns["OLD Q"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dg_PNC.Columns["NEW ANC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dg_PNC.Columns["NEW Q"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            IFCalc = true;
                        }
                        else if (result == DialogResult.No)
                        {
                            DialogResult result2 = MessageBox.Show("Do you want add this PNC to exisitng PNC for this Action ?", "Warning!", MessageBoxButtons.YesNo);
                            if (result2 == DialogResult.Yes)
                            {
                                IFCalc = true;
                            }
                            else if (result2 == DialogResult.No)
                            {
                                IFCalc = false;
                            }
                        }
                    }
                    else
                    {
                        dg_PNC.Rows.Clear();
                        dg_PNC.Columns.Clear();
                        dg_PNC.Columns.Add("PNC", "PNC");
                        dg_PNC.Columns.Add("OLD ANC", "OLD ANC");
                        dg_PNC.Columns.Add("OLD Q", "Q");
                        dg_PNC.Columns.Add("NEW ANC", "NEW ANC");
                        dg_PNC.Columns.Add("NEW Q", "Q");
                        dg_PNC.Columns["PNC"].Width = 80;
                        dg_PNC.Columns["OLD ANC"].Width = 65;
                        dg_PNC.Columns["OLD ANC"].DefaultCellStyle.ForeColor = Color.Red;
                        dg_PNC.Columns["OLD Q"].Width = 35;
                        dg_PNC.Columns["OLD Q"].DefaultCellStyle.ForeColor = Color.Red;
                        dg_PNC.Columns["NEW ANC"].Width = 65;
                        dg_PNC.Columns["NEW ANC"].DefaultCellStyle.ForeColor = Color.Green;
                        dg_PNC.Columns["NEW Q"].Width = 35;
                        dg_PNC.Columns["NEW Q"].DefaultCellStyle.ForeColor = Color.Green;
                        dg_PNC.Columns["PNC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dg_PNC.Columns["OLD ANC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dg_PNC.Columns["OLD Q"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dg_PNC.Columns["NEW ANC"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dg_PNC.Columns["NEW Q"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        IFCalc = true;
                    }


                    if (IFCalc)
                    {
                        for (int counter = 0; counter < row.Length - 1; counter++)
                        {
                            string[] row2 = row[counter].Split(';');
                            string PNC = row2[0];
                            string ECCC = "";
                            int Limit = ((row2.Length - 3) / 2);
                            if (row2[1].ToString() != "")
                            {
                                ECCC = "ECCC(" + row2[1] + ")";
                            }
                            dg_PNC.Rows.Add(PNC, ECCC, "");

                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].DefaultCellStyle.Font = new Font(dg_PNC.Font, FontStyle.Bold);
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].Cells[1].Style.Font = new Font(dg_PNC.Font, FontStyle.Regular);
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].Cells[1].Style.Font = new Font("Tahoma", 10F, GraphicsUnit.Pixel);

                            for (int counter2 = 2; counter2 < Limit + 2; counter2++)
                            {
                                if (row2[counter2] != "" || row2[counter2 + Limit + 1] != "")
                                {
                                    dg_PNC.Rows.Add("", row2[counter2], row2[counter2 + 1], row2[counter2 + Limit + 1], row2[counter2 + Limit + 2]);
                                }
                                counter2++;
                            }

                        }

                    }
                    this.Close();
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            else
            {
                this.Close();
                Cursor.Current = Cursors.Default;
                return;
            }

            if (Jak == "BU")
            {
                if (_ANC)
                    _ = new ANCRevisionQuantityAdd("BU", Convert.ToInt32(Year), row);
                else
                    _ = new PNCRevisionQuantityAdd("BU", Convert.ToInt32(Year), row);
            }
            else if (Jak == "EA1")
            {
                if (_ANC)
                    _ = new ANCRevisionQuantityAdd("EA1", Convert.ToInt32(Year), row);
                else
                    _ = new PNCRevisionQuantityAdd("EA1", Convert.ToInt32(Year), row);
            }
            else if (Jak == "EA2")
            {
                if (_ANC)
                    _ = new ANCRevisionQuantityAdd("EA2", Convert.ToInt32(Year), row);
                else
                    _ = new PNCRevisionQuantityAdd("EA2", Convert.ToInt32(Year), row);
            }
            else if (Jak == "EA3")
            {
                if (_ANC)
                    _ = new ANCRevisionQuantityAdd("EA3", Convert.ToInt32(Year), row);
                else
                    _ = new PNCRevisionQuantityAdd("EA3", Convert.ToInt32(Year), row);
            }
            else if (Jak == "AddMonthANC")
            {
                _ = new ANCQuantityAdd(Convert.ToInt32(_Month), Convert.ToInt32(Year), row);
            }
            else if (Jak == "AddMonthPNC")
            {
                _ = new PNCQuantityAdd(Convert.ToInt32(_Month), Convert.ToInt32(Year), row);
            }

            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void PB_CopyTemplate_Click(object sender, EventArgs e)
        {
            string Template = @"\\PLWS4031\Project\CAD\Work\bartkkon\EC_Accelerator_Data\PNCSpec_Template.xlsm";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = "PNCSpec_Template",
                DefaultExt = "Xlsm",
                Filter = "Excel Files (*.xlsm)|*xlsm",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                File.Copy(Template, saveFileDialog.FileName);
            }
        }
    }
}
