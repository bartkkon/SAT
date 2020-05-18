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
using Saving_Accelerator_Tool.Klasy.Acton;

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

            if (row[0] == string.Empty)
            {
                Cursor.Current = Cursors.Default;
                DialogResult Result = MessageBox.Show("No Data to add. Do you want close this windows?", "Warning!", MessageBoxButtons.YesNo);

                if (Result == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
                else if (Result == DialogResult.No)
                {
                    return;
                }

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
            else if (Jak == "PNC")
            {
                if (!ActionPNCAdd.Load(row))
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    ActionID.Singleton.PNCModification = true;
                }
            }
            else if (Jak == "PNCSpec")
            {

                if (!ActionPNCSpecAdd.Load(row))
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    ActionID.Singleton.PNCSpecModification = true;
                }
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
