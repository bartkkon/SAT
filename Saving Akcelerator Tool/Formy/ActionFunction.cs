using Saving_Accelerator_Tool.Klasy.Acton;
using System;
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
        private DataGridView DG_IDCO;
        private readonly DataTable IDCO;
        private readonly int ANCChangeNumber;
        public ActionFunction()
        {
            InitializeComponent();

            IDCO = OriginalAction.Value.IDCO;
            ANCChangeNumber = OriginalAction.Value.IloscANC;

            ShowIDCO();
        }


        private void ShowIDCO()
        {
            ADDGrid();
            DG_IDCO = (DataGridView)this.Controls.Find("DG_IDCO", true).First();
            ADD_Column("OLD ANC", 80, Color.Red);
            ADD_Column("OLD IDCO", 80, Color.Red);
            ADD_Column("NEW ANC", 80, Color.Green);
            ADD_Column("NEW IDCO", 80, Color.Green);

            this.Size = new Size(397, 550);

            LoadIDCO();

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

        private void ADD_Column(string Name, int Width, Color color)
        {
            DataGridViewColumn NewColumn = new DataGridViewTextBoxColumn();
            NewColumn.Name = Name;
            NewColumn.HeaderText = Name;
            NewColumn.Width = Width;
            NewColumn.DefaultCellStyle.ForeColor = color;
            NewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            NewColumn.ValueType = typeof(String);
            DG_IDCO.Columns.Add(NewColumn);
        }

        private void LoadIDCO()
        {
            CheckBox PNCSpec = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNCSpec", true).First();
            if (IDCO.Rows.Count != 0)
            {
                if (!PNCSpec.Checked)
                {
                    for (int counter = 1; counter <= ANCChangeNumber; counter++)
                    {
                        TextBox OLDANC = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_OldANC" + counter.ToString(), true).First();
                        TextBox NEWANC = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_NewANC" + counter.ToString(), true).First();

                        int index = DG_IDCO.Rows.Add();
                        DataGridViewRow Row = DG_IDCO.Rows[index];

                        Row.Cells["OLD ANC"].Value = OLDANC.Text;
                        Row.Cells["NEW ANC"].Value = NEWANC.Text;

                        if (OLDANC.Text != "")
                        {
                            DataRow[] OLD = IDCO.Select("ANC = '" + OLDANC.Text + "'");
                            if (OLD != null)
                            {
                                Row.Cells["OLD IDCO"].Value = OLD[0][1];
                            }
                        }
                        if (NEWANC.Text != "")
                        {
                            DataRow[] NEW = IDCO.Select("ANC = '" + NEWANC.Text + "'");
                            if (NEW != null)
                            {
                                Row.Cells["NEW IDCO"].Value = NEW[0][1];
                            }
                        }
                    }
                }
                else
                {
                    DataGridView PNC = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();

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
                                    DataRow[] OLD = IDCO.Select("ANC = '" + Old + "'");
                                    if (OLD != null)
                                    {
                                        Row.Cells["OLD IDCO"].Value = OLD[0][1];
                                    }

                                }
                                else
                                {
                                    Row.Cells["OLD ANC"].Value = "";
                                    Row.Cells["OLD IDCO"].Value = "";
                                }
                                if (New != "")
                                {
                                    Row.Cells["NEW ANC"].Value = New;
                                    DataRow[] NEW = IDCO.Select("ANC = '" + New + "'");
                                    if (NEW != null)
                                    {
                                        Row.Cells["NEW IDCO"].Value = NEW[0][1];
                                    }
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
