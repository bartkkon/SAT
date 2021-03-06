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
    public partial class ActionFunction : Form
    {
        MainProgram mainProgram;

        Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();

        public ActionFunction(Dictionary<string, string> IDCO, int ANCChangeNumber, MainProgram mainProgram)
        {
            InitializeComponent();
            IDCODictionary = IDCO;
            this.mainProgram = mainProgram;
            ShowIDCO(ANCChangeNumber);
        }


        private void ShowIDCO(int ANCChangeNumber)
        {
            ADDGrid();
            DataGridView DG_IDCO = (DataGridView)this.Controls.Find("DG_IDCO", true).First();
            ADD_Column(ref DG_IDCO, "OLD ANC", 80, Color.Red);
            ADD_Column(ref DG_IDCO, "OLD IDCO", 80, Color.Red);
            ADD_Column(ref DG_IDCO, "NEW ANC", 80, Color.Green);
            ADD_Column(ref DG_IDCO, "NEW IDCO", 80, Color.Green);

            this.Size = new Size(397, 550);

            LoadIDCO(ref DG_IDCO, ANCChangeNumber);

        }

        private void ADDGrid()
        {
            DataGridView DG_IDCO = new DataGridView()
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Name = "DG_IDCO",
                ReadOnly = true,
                AllowUserToAddRows = false,
            };
            this.Controls.Add(DG_IDCO);
        }

        private void ADD_Column(ref DataGridView Table, string Name, int Width, Color color)
        {
            DataGridViewColumn NewColumn = new DataGridViewTextBoxColumn();
            NewColumn.Name = Name;
            NewColumn.HeaderText = Name;
            NewColumn.Width = Width;
            NewColumn.DefaultCellStyle.ForeColor = color;
            NewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            NewColumn.ValueType = typeof(String);
            Table.Columns.Add(NewColumn);
        }

        private void LoadIDCO(ref DataGridView DG_IDCO, int ANCChangeNumber)
        {
            CheckBox PNCSpec = (CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First();
            if (IDCODictionary.Count != 0)
            {
                if (!PNCSpec.Checked)
                {
                    for (int counter = 1; counter <= ANCChangeNumber; counter++)
                    {
                        TextBox OLDANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First();
                        TextBox NEWANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First();

                        int index = DG_IDCO.Rows.Add();
                        DataGridViewRow Row = DG_IDCO.Rows[index];

                        Row.Cells["OLD ANC"].Value = OLDANC.Text;
                        Row.Cells["NEW ANC"].Value = NEWANC.Text;

                        if (IDCODictionary.ContainsKey(OLDANC.Text))
                        {
                            Row.Cells["OLD IDCO"].Value = IDCODictionary[OLDANC.Text];
                        }
                        if (IDCODictionary.ContainsKey(NEWANC.Text))
                        {
                            Row.Cells["NEW IDCO"].Value = IDCODictionary[NEWANC.Text];
                        }
                    }
                }
                else
                {
                    DataGridView PNC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

                    foreach (DataGridViewRow IDCO_Row in PNC.Rows)
                    {
                        if (IDCO_Row.Cells["PNC"].Value == null || IDCO_Row.Cells["PNC"].Value.ToString() == "")
                        {
                            string Old = IDCO_Row.Cells["OLD ANC"].Value.ToString();
                            string New = IDCO_Row.Cells["NEW ANC"].Value.ToString();

                            bool Check = true;

                            foreach (DataGridViewRow DG in DG_IDCO.Rows)
                            {
                                if (DG.Cells["OLD ANC"].Value != null && DG.Cells["OLD ANC"].Value.ToString() == Old)
                                {
                                    if (DG.Cells["NEW ANC"].Value != null && DG.Cells["NEW ANC"].Value.ToString() == New)
                                    {
                                        Check = false;
                                        break;
                                    }
                                }
                            }

                            if (Check)
                            {
                                int index = DG_IDCO.Rows.Add();
                                DataGridViewRow Row = DG_IDCO.Rows[index];

                                if (Old != "")
                                {
                                    Row.Cells["OLD ANC"].Value = Old;
                                    Row.Cells["OLD IDCO"].Value = IDCODictionary[Old];
                                }
                                else
                                {
                                    Row.Cells["OLD ANC"].Value = "";
                                    Row.Cells["OLD IDCO"].Value = "";
                                }
                                if (New != "")
                                {
                                    Row.Cells["NEW ANC"].Value = New;
                                    Row.Cells["NEW IDCO"].Value = IDCODictionary[New];
                                }
                                else
                                {
                                    Row.Cells["NEW ANC"].Value = "";
                                    Row.Cells["NEW IDCO"].Value = "";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing IDCO in this action, Please Refresh STK!");
            }
        }
    }
}
