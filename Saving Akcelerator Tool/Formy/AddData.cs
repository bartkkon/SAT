﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool
{
    public partial class AddData : Form
    {
        MainProgram mainProgram;
        Data_Import data_Import;
        string Jak;
        string LinkANC;
        string LinkPNC;
        string LinkANCMonth;
        string LinkPNCMonth;

        public AddData(string text, string What, MainProgram mainProgram, Data_Import dataImport)
        {
            InitializeComponent();
            lab_AddData_Text.Text = text;
            this.mainProgram = mainProgram;
            data_Import = dataImport;
            LinkANC = data_Import.Load_Link("ANC");
            LinkPNC = data_Import.Load_Link("PNC");
            LinkANCMonth = data_Import.Load_Link("ANCMonth");
            LinkPNCMonth = data_Import.Load_Link("PNCMonth");
            Jak = What;
        }

        private void pb_AddData_Close_Click(object sender, EventArgs e)
        {
            //Action action = new Action();
            Cursor.Current = Cursors.WaitCursor;
            string[] row = tb_AddData_Data.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (row[0] != "")
            {
                if (Jak == "PNC")
                {

                    DataGridView dg_PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
                    dg_PNC.Rows.Clear();
                    dg_PNC.Columns.Clear();
                    dg_PNC.Columns.Add("PNC", "PNC");
                    dg_PNC.Columns["PNC"].Width = 63;
                    dg_PNC.Columns["PNC"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    for (int counter = 0; counter < row.Length - 1; counter++)
                    {
                        if (row[counter] != "")
                        {
                            dg_PNC.Rows.Add(row[counter]);
                        }
                    }
                    this.Close();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                if (Jak == "PNCSpec")
                {
                    DataGridView dg_PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
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

                    for (int counter = 0; counter < row.Length - 1; counter++)
                    {
                        string[] row2 = row[counter].Split('\t');
                        string PNC = row2[0];
                        string ECCC = "";
                        int Limit = ((row2.Length - 3) / 2);
                        if(row2[1].ToString() != "")
                        {
                            ECCC = "ECCC(" + row2[1] + ")";
                        }
                        dg_PNC.Rows.Add(PNC, ECCC, "");
                        dg_PNC.Rows[dg_PNC.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightBlue;
                        dg_PNC.Rows[dg_PNC.Rows.Count - 2].DefaultCellStyle.Font = new Font(dg_PNC.Font, FontStyle.Bold);
                        dg_PNC.Rows[dg_PNC.Rows.Count - 2].Cells[1].Style.Font = new Font(dg_PNC.Font, FontStyle.Regular);
                        dg_PNC.Rows[dg_PNC.Rows.Count - 2].Cells[1].Style.Font = new Font("Tahoma", 10F, GraphicsUnit.Pixel);

                        for (int counter2 = 2; counter2 < Limit + 2; counter2++)
                        {
                            if (row2[counter2] != "" || row2[counter2 + Limit + 1] != "")
                            {
                                dg_PNC.Rows.Add("", row2[counter2], row2[counter2 + 1], row2[counter2 + Limit + 1], row2[counter2 + Limit + 2]);
                            }
                            counter2++;
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
                NumericUpDown Admin_Year = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_YearQuantity", true).First();
                CheckBox cb_AdminPNC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminPNC", true).First();
                CheckBox cb_AdminANC = (CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminANC", true).First();
                DataTable Baza = new DataTable();
                DataRow FoundRow;

                int ile;

                if (cb_AdminANC.Checked)
                {
                    data_Import.Load_TxtToDataTable(ref Baza, LinkANC);
                }
                if (cb_AdminPNC.Checked)
                {
                    data_Import.Load_TxtToDataTable(ref Baza, LinkPNC);
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
                        ile = 0;
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
                    data_Import.Save_DataTableToTXT(ref Baza, LinkANC);
                }
                if (cb_AdminPNC.Checked)
                {
                    data_Import.Save_DataTableToTXT(ref Baza, LinkPNC);
                }
                this.Close();
                Cursor.Current = Cursors.Default;
                return;
            }
            if (Jak == "AddMonthANC" || Jak == "AddMonthPNC")
            {
                NumericUpDown Admin_Year = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_YearMonth", true).First();
                NumericUpDown Admin_Month = (NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_QuantityMonth", true).First();
                DataTable Quantity = new DataTable();
                DataRow FoundRow;
                string Miesiac = Admin_Month.Value.ToString() + "/" + Admin_Year.Value.ToString();


                if (Jak == "AddMonthANC")
                {
                    data_Import.Load_TxtToDataTable(ref Quantity, LinkANCMonth);
                }
                if(Jak == "AddMonthPNC")
                {
                    data_Import.Load_TxtToDataTable(ref Quantity, LinkPNCMonth);
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
                    data_Import.Save_DataTableToTXT(ref Quantity, LinkANCMonth);
                }
                if (Jak == "AddMonthPNC")
                {
                    data_Import.Save_DataTableToTXT(ref Quantity, LinkPNCMonth);
                }
                this.Close();
                Cursor.Current = Cursors.Default;
                return;
            }
        }
    }
}
