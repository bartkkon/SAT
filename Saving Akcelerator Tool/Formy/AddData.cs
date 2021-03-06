﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Saving_Accelerator_Tool
{
    public partial class AddData : Form
    {
        private readonly string Jak;
        private readonly decimal Year;

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
        }


        private void Pb_AddData_STK_Close_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] Row = tb_AddData_Data.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            DataTable STK = new DataTable();
            DataRow STKRow;

            Data_Import.Singleton().Load_TxtToDataTable2(ref STK, "STK");

            foreach(string SingleRow in Row)
            {
                string[] Part = SingleRow.Split('\t');
                if(Part.Length >1)
                {
                    Part[0] = Part[0].Replace(" ", "");
                    STKRow = STK.Select(string.Format("ANC LIKE '%{0}%'", Part[0])).FirstOrDefault();
                    if(STKRow != null)
                    {
                        STKRow[Year.ToString()] = "01/00/" + Year.ToString();
                        STKRow["STK/" + Year.ToString()] = Part[1];
                    }
                    else
                    {
                        STKRow = STK.NewRow();
                        STKRow["ANC"] = Part[0].ToString();
                        STKRow[Year.ToString()] = "01/00/" + Year.ToString();
                        STKRow["STK/" + Year.ToString()] = Part[1];
                        STK.Rows.Add(STKRow);
                    }
                }
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref STK, "STK");
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void Pb_AddData_Close_Click(object sender, EventArgs e)
        {
            //Action action = new Action();
            Cursor.Current = Cursors.WaitCursor;
            string[] row = tb_AddData_Data.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int DuplicateCount = 0;
            bool IFCalc = false;

            if (row[0] != "")
            {
                if (Jak == "PNC")
                {

                    DataGridView dg_PNC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();

                    if(dg_PNC.Rows.Count>1)
                    {
                        DialogResult result = MessageBox.Show("Do you want replace all PNC in this Action ?", "Warning!", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
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
                            if(result2 == DialogResult.Yes)
                            {
                                IFCalc = true;
                            }
                            else if(result2 == DialogResult.No)
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
                        foreach(string OneRow in row)
                        {
                            if (OneRow != "")
                            {
                                var Row = dg_PNC.Rows.Cast<DataGridViewRow>().Where(u => u.Cells["PNC"].Value.ToString().Equals(OneRow)).FirstOrDefault();
                                if (Row == null)
                                    dg_PNC.Rows.Add(OneRow);
                                else
                                    DuplicateCount++;
                            }
                        }
                    }
                    this.Close();
                    Cursor.Current = Cursors.Default;
                    if (DuplicateCount > 0)
                        MessageBox.Show($"Was remove {DuplicateCount} Duplicate Value", "Duplicate counter");
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
                        foreach(string SingleRow in row)
                        {
                            if(SingleRow == string.Empty)
                            {
                                continue;
                            }

                            string[] SelectedRow = SingleRow.Split(';');
                            string PNC = SelectedRow[0];
                            string ECCC = string.Empty;

                            int Limit = ((SelectedRow.Length - 3) / 2);
                            if (SelectedRow[1].ToString() != string.Empty)
                            {
                                ECCC = "ECCC(" + SelectedRow[1] + ")";
                            }
                            dg_PNC.Rows.Add(PNC, ECCC, string.Empty);

                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].DefaultCellStyle.Font = new Font(dg_PNC.Font, FontStyle.Bold);
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].Cells[1].Style.Font = new Font(dg_PNC.Font, FontStyle.Regular);
                            dg_PNC.Rows[dg_PNC.Rows.Count - 1].Cells[1].Style.Font = new Font("Tahoma", 10F, GraphicsUnit.Pixel);

                            for (int counter2 = 2; counter2 < Limit + 2; counter2++)
                            {
                                if (SelectedRow[counter2] != string.Empty || SelectedRow[counter2 + Limit + 1] != string.Empty)
                                {
                                    dg_PNC.Rows.Add(string.Empty, SelectedRow[counter2], SelectedRow[counter2 + 1], SelectedRow[counter2 + Limit + 1], SelectedRow[counter2 + Limit + 2]);
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
            if (Jak == "BU" || Jak == "EA1" || Jak == "EA2" || Jak == "EA3")
            {
                NumericUpDown Admin_Year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_YearQuantity", true).First();
                CheckBox cb_AdminPNC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminPNC", true).First();
                CheckBox cb_AdminANC = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminANC", true).First();
                DataTable Baza = new DataTable();
                DataRow FoundRow;

                int ile;

                if (cb_AdminANC.Checked)
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Baza, "ANC");
                }
                if (cb_AdminPNC.Checked)
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Baza, "PNC");
                }
                switch (Jak)
                {
                    case "BU":
                        ile = 1;
                        break;
                    case "EA1":
                        ile = 3;
                        break;
                    case "EA2":
                        ile = 6;
                        break;
                    case "EA3":
                        ile = 9;
                        break;
                    default:
                        return;
                }

                if (Baza.Columns.Contains(Jak + "/12/" + Admin_Year.Text))
                {
                    for (int counter = ile; counter <= 12; counter++)
                    {
                        Baza.Columns.Remove(Jak + "/" + counter + "/" + Admin_Year.Text);
                    }
                }
                for (int counter = ile; counter <= 12; counter++)
                {
                    Baza.Columns.Add(new DataColumn(Jak + "/" + counter + "/" + Admin_Year.Text));
                }

                foreach (string OneRow in row)
                {
                    string[] row2 = OneRow.Split('\t');
                    if (row2[0] != "")
                    {
                        if (cb_AdminANC.Checked)
                        {
                            FoundRow = Baza.Select(string.Format("BUANC LIKE '%{0}%'", row2[0])).FirstOrDefault();
                        }
                        else
                        {
                            FoundRow = Baza.Select(string.Format("BUPNC LIKE '%{0}%'", row2[0])).FirstOrDefault();
                        }
                        int zmienna;
                        if (FoundRow != null)
                        {
                            zmienna = ile;
                            for (int counter = 1; counter <= (13 - ile); counter++)
                            {
                                FoundRow[Jak + "/" + zmienna + "/" + Admin_Year.Text] = row2[counter];
                                zmienna++;
                            }

                        }
                        else
                        {
                            DataRow NewRow = Baza.NewRow();
                            NewRow[0] = row2[0];
                            zmienna = ile;
                            for (int counter = 1; counter <= (13 - ile); counter++)
                            {
                                NewRow[Jak + "/" + zmienna + "/" + Admin_Year.Text] = row2[counter];
                                zmienna++;
                            }
                            Baza.Rows.Add(NewRow);
                        }
                    }
                }
                if (cb_AdminANC.Checked)
                {
                    Data_Import.Singleton().Save_DataTableToTXT2(ref Baza, "ANC");
                }
                if (cb_AdminPNC.Checked)
                {
                    Data_Import.Singleton().Save_DataTableToTXT2(ref Baza, "PNC");
                }
                this.Close();
                Cursor.Current = Cursors.Default;
                return;
            }
            if (Jak == "AddMonthANC" || Jak == "AddMonthPNC")
            {
                NumericUpDown Admin_Year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_YearMonth", true).First();
                NumericUpDown Admin_Month = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_QuantityMonth", true).First();
                DataTable Quantity = new DataTable();
                DataRow FoundRow;
                string Miesiac = Admin_Month.Value.ToString() + "/" + Admin_Year.Value.ToString();


                if (Jak == "AddMonthANC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Quantity, "ANCMonth");
                }
                if(Jak == "AddMonthPNC")
                {
                    Data_Import.Singleton().Load_TxtToDataTable2(ref Quantity, "PNCMonth");
                }

                if (Quantity.Columns.Contains(Miesiac))
                {
                    Quantity.Columns.Remove(Miesiac);
                }
                Quantity.Columns.Add(new DataColumn(Miesiac));

                foreach (string OneRow in row)
                {
                    string[] NewValue = OneRow.Split('\t');

                    if (NewValue[0] != "")
                    {
                        if(Jak == "AddMonthANC")
                        {
                            FoundRow = Quantity.Select(string.Format("ANC LIKE '%{0}%'", NewValue[0])).FirstOrDefault();
                        }
                        else
                        {
                            FoundRow = Quantity.Select(string.Format("PNC LIKE '%{0}%'", NewValue[0])).FirstOrDefault();
                        }
                        if(FoundRow != null)
                        {
                            FoundRow[Miesiac] = NewValue[1];
                        }
                        else
                        {
                            DataRow NewRow = Quantity.NewRow();
                            NewRow[0] = NewValue[0];
                            NewRow[Miesiac] = NewValue[1];
                            Quantity.Rows.Add(NewRow);
                        }
                    }
                }
                if (Jak == "AddMonthANC")
                {
                    Data_Import.Singleton().Save_DataTableToTXT2(ref Quantity, "ANCMonth");
                }
                if (Jak == "AddMonthPNC")
                {
                    Data_Import.Singleton().Save_DataTableToTXT2(ref Quantity, "PNCMonth");
                }
                this.Close();
                Cursor.Current = Cursors.Default;
                return;
            }
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
                if(File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                File.Copy(Template, saveFileDialog.FileName);
            }
        }
    }
}
