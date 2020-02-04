using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Saving_Accelerator_Tool.Klasy.Action.Framework;

namespace Saving_Accelerator_Tool
{
    public class Admin
    {
        public Admin()
        {

        }

        public void Admin_FrozenSaveData()
        {
            Cursor.Current = Cursors.WaitCursor;
            FrozenSaveData();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_FrezenRefreshData()
        {
            Cursor.Current = Cursors.WaitCursor;
            FrozenRefreshData();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_ValueRefreshData()
        {
            Cursor.Current = Cursors.WaitCursor;
            ValueRefreshData();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_ValueSaveData()
        {
            Cursor.Current = Cursors.WaitCursor;
            ValueSaveData();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_Value_TextChange(TextBox TextBoxChange)
        {
            Value_TextChange(TextBoxChange);
        }

        public void Admin_ActivatorAction()
        {
            ActivatorAction();
        }

        public void Admin_DeactivatorAction()
        {
            DeactivatorAction();
        }

        public void Admin_CloneDataBase()
        {
            CloneDataBase();
        }

        private void CloneDataBase()
        {
            string LinkServer = @"\\PLWS4031\Project\CAD\Work\bartkkon\EC_Accelerator_Data\";
            string LinkDysk = @"C:\Moje\EC_Accelerator_Data\";
            string Access = @"Access\Access.txt";
            string BUANC = @"BUANC\BUANC.txt";
            string BUPNC = @"BUPNC\BUPNC.txt";
            string Frozen = @"Frozen\Frozen.txt";
            string Kurs = @"Kurs\Kurs.txt";
            string STK = @"STK\STK.txt";
            string ANC = @"ANC\ANC.txt";
            string PNC = @"PNC\PNC.txt";
            string Action = @"Action\Action.txt";
            string History = @"History\History.txt";
            string SumPNC = @"SumPNC\SumPNC.txt";
            string SUMPNCBU = @"SumPNCBU\SumPNCBU.txt";

            string date = "_" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".txt";

            ChangeNameForCopyBase(LinkDysk, Access, date);
            File.Copy(LinkServer + Access, LinkDysk + Access);

            ChangeNameForCopyBase(LinkDysk, BUANC, date);
            File.Copy(LinkServer + BUANC, LinkDysk + BUANC);

            ChangeNameForCopyBase(LinkDysk, BUPNC, date);
            File.Copy(LinkServer + BUPNC, LinkDysk + BUPNC);

            ChangeNameForCopyBase(LinkDysk, Frozen, date);
            File.Copy(LinkServer + Frozen, LinkDysk + Frozen);

            ChangeNameForCopyBase(LinkDysk, Kurs, date);
            File.Copy(LinkServer + Kurs, LinkDysk + Kurs);

            ChangeNameForCopyBase(LinkDysk, STK, date);
            File.Copy(LinkServer + STK, LinkDysk + STK);

            ChangeNameForCopyBase(LinkDysk, ANC, date);
            File.Copy(LinkServer + ANC, LinkDysk + ANC);

            ChangeNameForCopyBase(LinkDysk, PNC, date);
            File.Copy(LinkServer + PNC, LinkDysk + PNC);

            ChangeNameForCopyBase(LinkDysk, Action, date);
            File.Copy(LinkServer + Action, LinkDysk + Action);

            ChangeNameForCopyBase(LinkDysk, History, date);
            File.Copy(LinkServer + History, LinkDysk + History);

            ChangeNameForCopyBase(LinkDysk, SumPNC, date);
            File.Copy(LinkServer + SumPNC, LinkDysk + SumPNC);

            ChangeNameForCopyBase(LinkDysk, SUMPNCBU, date);
            File.Copy(LinkServer + SUMPNCBU, LinkDysk + SUMPNCBU);
        }

        private void ChangeNameForCopyBase(string LinkDysk, string Link, string Date)
        {
            string Temp1;
            string Temp2;

            Temp1 = LinkDysk + Link;
            Temp2 = LinkDysk + Link;
            Temp2 = Temp2.Remove(Temp2.Length - 4);
            Temp2 += Date;
            File.Move(Temp1, Temp2);
        }

        private void DeactivatorAction()
        {
            _ = new Deactivation_Action(-1);
        }

        private void ActivatorAction()
        {
            _ = new Activation_Action(-1);
        }

        private void Value_TextChange(TextBox TextBoxChange)
        {
            string[] Estyma;
            //Sprawdenie czy dana jest kropka czy przeciek. Jak kropka to ma zmienić na przecinek - dla wpisywania Estymacji
            Estyma = TextBoxChange.Text.Split('.');
            if (Estyma.Length == 2)
            {
                TextBoxChange.Text = TextBoxChange.Text.Replace('.', ',');
                TextBoxChange.Focus();
                TextBoxChange.SelectionStart = TextBoxChange.Text.Length;
            }
            //Sprawdza czy za dużo razy nie ma przecinka wstawionego w text. Jak tak to usuwa ostatni znak który jest przecinkiem - Dla Estymacji
            Estyma = TextBoxChange.Text.Split(',');
            if (Estyma.Length == 3)
            {
                TextBoxChange.Text = TextBoxChange.Text.Substring(0, TextBoxChange.Text.Length - 1);
                TextBoxChange.Focus();
                TextBoxChange.SelectionStart = TextBoxChange.Text.Length;
            }
        }

        private void ValueSaveData()
        {
            DataTable Value = new DataTable();
            DataRow NewRow;
            DataRow FoundRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_ValueYear", true).First()).Value;
            TextBox tb_AdminECCC = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminECCC", true).First();
            TextBox tb_AdminEuro = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminEuro", true).First();
            TextBox tb_AdminDolars = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminDolars", true).First();
            TextBox tb_AdminSEK = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminSEK", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Value, "Kurs");

            NewRow = Value.NewRow();

            NewRow["Year"] = Year.ToString();
            NewRow["ECCC"] = tb_AdminECCC.Text;
            NewRow["EURO"] = tb_AdminEuro.Text;
            NewRow["USD"] = tb_AdminDolars.Text;
            NewRow["SEK"] = tb_AdminSEK.Text;

            FoundRow = Value.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (FoundRow == null)
            {
                Value.Rows.Add(NewRow);
            }
            else
            {
                FoundRow.ItemArray = NewRow.ItemArray.Clone() as object[];
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref Value, "Kurs");
        }

        private void ValueRefreshData()
        {
            DataTable Value = new DataTable();
            DataRow FoundRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_ValueYear", true).First()).Value;
            TextBox tb_AdminECCC = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminECCC", true).First();
            TextBox tb_AdminEuro = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminEuro", true).First();
            TextBox tb_AdminDolars = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminDolars", true).First();
            TextBox tb_AdminSEK = (TextBox)MainProgram.Self.TabControl.Controls.Find("tb_AdminSEK", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Value, "Kurs");

            FoundRow = Value.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            if (FoundRow == null)
            {
                MessageBox.Show("Brak danych do wybranego roku, wprowadź je !");
                return;
            }
            else
            {
                tb_AdminECCC.Text = FoundRow["ECCC"].ToString();
                tb_AdminEuro.Text = FoundRow["EURO"].ToString();
                tb_AdminDolars.Text = FoundRow["USD"].ToString();
                tb_AdminSEK.Text = FoundRow["SEK"].ToString();
            }
        }

        private void FrozenSaveData()
        {
            DataTable Frozen = new DataTable();
            DataRow NewRow;
            DataRow FoundRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_FrozenYear", true).First()).Value;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            NewRow = Frozen.NewRow();

            foreach (DataColumn column in Frozen.Columns)
            {
                if (column.ColumnName == "Year")
                {

                    NewRow[column.ColumnName] = Year.ToString();
                }
                else
                {
                    ComboBox ComboBoxFrozen = (ComboBox)MainProgram.Self.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First();
                    NewRow[column.ColumnName] = ComboBoxFrozen.GetItemText(ComboBoxFrozen.SelectedItem);
                }
            }

            FoundRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (FoundRow == null)
            {
                Frozen.Rows.Add(NewRow);
            }
            else
            {
                FoundRow.ItemArray = NewRow.ItemArray.Clone() as object[];
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");
        }

        private void FrozenRefreshData()
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Admin_FrozenYear", true).First()).Value;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            if (FrozenRow == null)
            {
                MessageBox.Show("Brak Danego roku w Bazie - dodaj go !!");
                return;
            }
            else
            {
                foreach (DataColumn column in Frozen.Columns)
                {
                    if (column.ColumnName != "Year")
                    {
                        if (FrozenRow[column.ColumnName].ToString() == "Close")
                        {
                            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 0;
                        }
                        else if (FrozenRow[column.ColumnName].ToString() == "Open")
                        {
                            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 1;
                        }
                        else if (FrozenRow[column.ColumnName].ToString() == "Approve")
                        {
                            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 2;
                        }
                        else
                        {
                            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
