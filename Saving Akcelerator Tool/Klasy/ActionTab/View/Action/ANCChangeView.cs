using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Acton;
using System.Text.RegularExpressions;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class ANCChangeView : UserControl
    {
        private readonly List<TextBox> OldANCList;
        private readonly List<TextBox> OldANCQList;
        private readonly List<string> OldIDCO;
        private readonly List<TextBox> NewANCList;
        private readonly List<TextBox> NewANCQList;
        private readonly List<string> NewIDCO;
        private readonly List<Label> Arrows;
        private int VisibleRows;

        public bool Save;

        public ANCChangeView()
        {
            OldANCList = new List<TextBox>();
            OldANCQList = new List<TextBox>();
            OldIDCO = new List<string>();
            NewANCList = new List<TextBox>();
            NewANCQList = new List<TextBox>();
            NewIDCO = new List<string>();
            Arrows = new List<Label>();


            InitializeComponent();

            AddComponentToList();
            Save = true;
        }
        private void ChecIFIsPermisionToSave()
        {
            bool CanSave = true;
            foreach(TextBox OldANC in OldANCList)
            {
                if (OldANC.Text.Length != 9 && OldANC.Text.Length != 0)
                    CanSave = false;
            }
            foreach (TextBox NewANC in NewANCList)
            {
                if (NewANC.Text.Length != 9 && NewANC.Text.Length != 0)
                    CanSave = false;
            }

            Save = CanSave;
        }
        private void AddComponentToList()
        {
            OldANCList.Add(TB_OldANC1);
            OldANCList.Add(TB_OldANC2);
            OldANCList.Add(TB_OldANC3);
            OldANCList.Add(TB_OldANC4);
            OldANCList.Add(TB_OldANC5);
            OldANCList.Add(TB_OldANC6);
            OldANCList.Add(TB_OldANC7);
            OldANCList.Add(TB_OldANC8);
            OldANCList.Add(TB_OldANC9);
            OldANCList.Add(TB_OldANC10);
            OldANCQList.Add(TB_OldANCQ1);
            OldANCQList.Add(TB_OldANCQ2);
            OldANCQList.Add(TB_OldANCQ3);
            OldANCQList.Add(TB_OldANCQ4);
            OldANCQList.Add(TB_OldANCQ5);
            OldANCQList.Add(TB_OldANCQ6);
            OldANCQList.Add(TB_OldANCQ7);
            OldANCQList.Add(TB_OldANCQ8);
            OldANCQList.Add(TB_OldANCQ9);
            OldANCQList.Add(TB_OldANCQ10);
            NewANCList.Add(TB_NewANC1);
            NewANCList.Add(TB_NewANC2);
            NewANCList.Add(TB_NewANC3);
            NewANCList.Add(TB_NewANC4);
            NewANCList.Add(TB_NewANC5);
            NewANCList.Add(TB_NewANC6);
            NewANCList.Add(TB_NewANC7);
            NewANCList.Add(TB_NewANC8);
            NewANCList.Add(TB_NewANC9);
            NewANCList.Add(TB_NewANC10);
            NewANCQList.Add(TB_NewANCQ1);
            NewANCQList.Add(TB_NewANCQ2);
            NewANCQList.Add(TB_NewANCQ3);
            NewANCQList.Add(TB_NewANCQ4);
            NewANCQList.Add(TB_NewANCQ5);
            NewANCQList.Add(TB_NewANCQ6);
            NewANCQList.Add(TB_NewANCQ7);
            NewANCQList.Add(TB_NewANCQ8);
            NewANCQList.Add(TB_NewANCQ9);
            NewANCQList.Add(TB_NewANCQ10);
            Arrows.Add(Arrow1);
            Arrows.Add(Arrow2);
            Arrows.Add(Arrow3);
            Arrows.Add(Arrow4);
            Arrows.Add(Arrow5);
            Arrows.Add(Arrow6);
            Arrows.Add(Arrow7);
            Arrows.Add(Arrow8);
            Arrows.Add(Arrow9);
            Arrows.Add(Arrow10);

            for (int counter = 0; counter < 10; counter++)
            {
                OldIDCO.Add("");
                NewIDCO.Add("");
            }
        }
        public void SetVisibleANC(int VisibleRows)
        {
            this.VisibleRows = VisibleRows;
            for (int counter = 0; counter < VisibleRows; counter++)
            {
                OldANCList[counter].Visible = true;
                OldANCQList[counter].Visible = true;
                OldANCQList[counter].Text = "0";
                NewANCList[counter].Visible = true;
                NewANCQList[counter].Visible = true;
                NewANCQList[counter].Text = "0";
                Arrows[counter].Visible = true;
                MainProgram.Self.actionView.StkChange.SetVisibleANC(counter, true);
                MainProgram.Self.actionView.NextANC.SetVisisble(counter, true);
                MainProgram.Self.actionView.CalculationGroup.SetVisible(counter, true);
            }
        }
        public int GetVisibleNumber()
        {
            int visible = 0;
            foreach (var List in OldANCList)
            {
                if (List.Visible)
                    visible++;
            }
            return visible;
        }
        public void SetOldIDCO(int Count, string Value)
        {
            OldIDCO[Count] = Value;
        }
        public void SetNewIDCO(int Count, string Value)
        {
            NewIDCO[Count] = Value;
        }
        public void SetANC(string[] ANCList, int Rows, bool TrueifNew)
        {
            for (int counter = 0; counter < Rows; counter++)
            {
                if (TrueifNew)
                    NewANCList[counter].Text = ANCList[counter];
                else
                    OldANCList[counter].Text = ANCList[counter];
            }
        }
        public void SetANCQ(decimal[] QuantityList, int Rows, bool TrueIfNew)
        {
            for (int counter = 0; counter < Rows; counter++)
            {
                if (TrueIfNew)
                    NewANCQList[counter].Text = QuantityList[counter].ToString();
                else
                    OldANCQList[counter].Text = QuantityList[counter].ToString();
            }
        }
        public string[] GetANC(int Rows, bool New)
        {
            string[] ANCList = new string[Rows];

            for (int counter = 0; counter < Rows; counter++)
            {
                if (New)
                    ANCList[counter] = NewANCList[counter].Text;
                else
                    ANCList[counter] = OldANCList[counter].Text;
            }

            return ANCList;
        }
        public decimal[] GetQuantity(int Rows, bool New)
        {
            decimal[] QuantityList = new decimal[Rows];

            for (int counter = 0; counter < Rows; counter++)
            {
                if (New)
                    QuantityList[counter] = decimal.Parse(NewANCQList[counter].Text);
                else
                    QuantityList[counter] = decimal.Parse(OldANCQList[counter].Text);
            }

            return QuantityList;
        }
        public string GetOldANC(int Count)
        {
            return OldANCList[Count-1].Text;
        }
        public int GetOldANCQ (int Count)
        {
            return Convert.ToInt32(OldANCQList[Count-1].Text);
        }
        public string GetNewANC(int Count)
        {
            return NewANCList[Count-1].Text;
        }
        public int GetNewANCQ(int Count)
        {
            return Convert.ToInt32(NewANCQList[Count-1].Text);
        }
        public string GetOldIDCO(int Count)
        {
            return OldIDCO[Count - 1];
        }
        public string GetNewIDCO(int Count)
        {
            return NewIDCO[Count - 1];
        }
        public void SetOldANC(int Count, string Value)
        {
            OldANCList[Count].TextChanged -= ANC_TextChange;
            OldANCList[Count].Text = Value;
            OldANCList[Count].ForeColor = Color.Black;
            OldANCList[Count].TextChanged += ANC_TextChange;
        }
        public void SetOldANCQ(int Count, double Value)
        {
            OldANCQList[Count].TextChanged -= Quantity_TextChange;
            OldANCQList[Count].Leave -= Quantity_Leave;
            OldANCQList[Count].Text = Value.ToString();
            OldANCQList[Count].ForeColor = Color.Black;
            OldANCQList[Count].Leave += Quantity_Leave;
            OldANCQList[Count].TextChanged += Quantity_TextChange;
        }
        public void SetNewANC(int Count, string Value)
        {
            NewANCList[Count].TextChanged -= ANC_TextChange;
            NewANCList[Count].Text = Value;
            NewANCList[Count].ForeColor = Color.Black;
            NewANCList[Count].TextChanged += ANC_TextChange;
        }
        public void SetNewANCQ(int Count, double Value)
        {
            NewANCQList[Count].TextChanged -= Quantity_TextChange;
            NewANCQList[Count].Leave -= Quantity_Leave;
            NewANCQList[Count].Text = Value.ToString();
            NewANCQList[Count].ForeColor = Color.Black;
            NewANCQList[Count].Leave += Quantity_Leave;
            NewANCQList[Count].TextChanged += Quantity_TextChange;
        }
        public void SetOldANC_IDCO(int Count, string Value)
        {
            OldIDCO[Count] = Value;
        }
        public void SetNewANC_IDCO(int Count, string Value)
        {
            NewIDCO[Count] = Value;
        }
        public void Clear()
        {
            foreach (TextBox Box in OldANCList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in OldANCQList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in NewANCList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in NewANCQList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (Label lab in Arrows)
            {
                lab.Visible = false;
            }
            MainProgram.Self.actionView.StkChange.Clear();
            MainProgram.Self.actionView.NextANC.Clear();
            MainProgram.Self.actionView.CalculationGroup.Clear();
        }
        private void Pb_Plus_Click(object sender, EventArgs e)
        {
            if(VisibleRows <10)
            {
                VisibleRows++;
                AddRow(VisibleRows);
            }
        }
        private void Pb_Minus_Click(object sender, EventArgs e)
        {
            if (VisibleRows >1)
            {
                RemoveRow(VisibleRows);
                VisibleRows--;
            }
            else
            {
                RemoveRow(1);
                AddRow(1);
            }
        }
        private void AddRow(int iloscANC)
        {
            OldANCList[iloscANC - 1].Visible = true;
            OldANCQList[iloscANC - 1].Visible = true;
            OldANCQList[iloscANC - 1].Text = "0";
            NewANCList[iloscANC - 1].Visible = true;
            NewANCQList[iloscANC - 1].Visible = true;
            NewANCQList[iloscANC - 1].Text = "0";
            Arrows[iloscANC - 1].Visible = true;
            MainProgram.Self.actionView.StkChange.SetVisibleANC(iloscANC - 1, true);
            MainProgram.Self.actionView.NextANC.SetVisisble(iloscANC - 1, true);
            MainProgram.Self.actionView.CalculationGroup.SetVisible(iloscANC - 1, true);
            ActionID.Singleton.ANCModification = true;
        }
        private void RemoveRow(int iloscANC)
        {
            OldANCList[iloscANC - 1].Visible = false;
            OldANCList[iloscANC - 1].Text = "";
            OldANCQList[iloscANC - 1].Visible = false;
            OldANCQList[iloscANC - 1].Text = "";
            NewANCList[iloscANC - 1].Visible = false;
            NewANCList[iloscANC - 1].Text = "";
            NewANCQList[iloscANC - 1].Visible = false;
            NewANCQList[iloscANC - 1].Text = "";
            Arrows[iloscANC - 1].Visible = false;
            MainProgram.Self.actionView.StkChange.SetVisibleANC(iloscANC - 1, false);
            MainProgram.Self.actionView.NextANC.SetVisisble(iloscANC - 1, false);
            MainProgram.Self.actionView.CalculationGroup.SetVisible(iloscANC - 1, false);
            ActionID.Singleton.ANCModification = true;
        }
        private void ANC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 'A') && (e.KeyChar != 'a'))
                e.Handled = true;

            if ((e.KeyChar == 'A') && ((sender as TextBox).Text.IndexOf('A') > -1))
                e.Handled = true;

            if ((e.KeyChar == 'a') && ((sender as TextBox).Text.IndexOf('a') > -1))
                e.Handled = true;

            if ((e.KeyChar == 'A') && ((sender as TextBox).Text.IndexOf('A') == -1) && ((sender as TextBox).SelectionStart != 0))
                e.Handled = true;

            if ((e.KeyChar == 'a') && ((sender as TextBox).Text.IndexOf('a') == -1) && ((sender as TextBox).SelectionStart != 0))
                e.Handled = true;
        }
        private void ANC_TextChange(object sender, EventArgs e)
        {
            (sender as TextBox).Text.Replace('a', 'A');

            if ((sender as TextBox).Text.Length < 9)
            {
                (sender as TextBox).ForeColor = Color.Red;
                if (OldANCList.Contains(sender as TextBox))
                {
                    _ = new FindSTK(OldANCList.IndexOf(sender as TextBox), "Old", string.Empty, 0);
                }
                else if (NewANCList.Contains(sender as TextBox))
                {
                    _ = new FindSTK(NewANCList.IndexOf(sender as TextBox), "New", string.Empty, 0);
                }
            }
            else if ((sender as TextBox).Text.Length == 9)
            {
                (sender as TextBox).ForeColor = Color.Black;
                if (OldANCList.Contains(sender as TextBox))
                {
                    if (OldANCQList[OldANCList.IndexOf(sender as TextBox)].Text == "0")
                        OldANCQList[OldANCList.IndexOf(sender as TextBox)].Text = "1";

                    _ = new FindSTK(OldANCList.IndexOf(sender as TextBox), "Old", (sender as TextBox).Text, Convert.ToDouble(OldANCQList[OldANCList.IndexOf(sender as TextBox)].Text));
                }
                else if (NewANCList.Contains(sender as TextBox))
                {
                    if (NewANCQList[NewANCList.IndexOf(sender as TextBox)].Text == "0")
                        NewANCQList[NewANCList.IndexOf(sender as TextBox)].Text = "1";

                    _ = new FindSTK(NewANCList.IndexOf(sender as TextBox), "New", (sender as TextBox).Text, Convert.ToDouble(NewANCQList[NewANCList.IndexOf(sender as TextBox)].Text));
                }
            }
            ChecIFIsPermisionToSave();
            ActionID.Singleton.ANCModification = true;
        }
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                e.Handled = true;

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') == -1) && ((sender as TextBox).SelectionStart == 0))
                e.Handled = true;
        }
        private void Quantity_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                if ((sender as TextBox).Name[3] == 'O')
                {
                    int Number = OldANCQList.IndexOf(sender as TextBox);
                    if (OldANCList[Number].Text != string.Empty)
                        (sender as TextBox).Text = "1";
                    else
                        (sender as TextBox).Text = "0";
                    _ = new FindSTK(Number, "Old", OldANCList[Number].Text, Convert.ToDouble((sender as TextBox).Text));
                }
                else if ((sender as TextBox).Name[3] == 'N')
                {
                    int Number = NewANCQList.IndexOf(sender as TextBox);
                    if (NewANCList[Number].Text != string.Empty)
                        (sender as TextBox).Text = "1";
                    else
                        (sender as TextBox).Text = "0";
                    _ = new FindSTK(Number, "New", NewANCList[Number].Text, Convert.ToDouble((sender as TextBox).Text));
                }
            }
            else
            {
                if ((sender as TextBox).Text[0] == ',')
                {
                    (sender as TextBox).Text = "0" + (sender as TextBox).Text;
                }

                int Number;
                if ((sender as TextBox).Name[3] == 'O')
                {
                    Number = OldANCQList.IndexOf(sender as TextBox);

                    if ((sender as TextBox).Text == "0" && OldANCList[Number].Text.Length == 9)
                        (sender as TextBox).Text = "1";
                    else if ((sender as TextBox).Text != "0" && OldANCList[Number].Text.Length == 0)
                        (sender as TextBox).Text = "0";
                }
                else
                {
                    Number = NewANCQList.IndexOf(sender as TextBox);

                    if ((sender as TextBox).Text == "0" && NewANCList[Number].Text.Length == 9)
                        (sender as TextBox).Text = "1";
                    else if((sender as TextBox).Text != "0" && NewANCList[Number].Text.Length == 0)
                        (sender as TextBox).Text = "0";
                }

                double Value = Convert.ToDouble((sender as TextBox).Text);
                if (Value > 100)
                    Value = 100;
                (sender as TextBox).Text = Math.Round(Value, 3, MidpointRounding.AwayFromZero).ToString();

                if ((sender as TextBox).Name[3] == 'O')
                {
                    _ = new FindSTK(Number, "Old", OldANCList[Number].Text, Convert.ToDouble((sender as TextBox).Text));
                }
                else if((sender as TextBox).Name[3] == 'N')
                {
                    _ = new FindSTK(Number, "New", NewANCList[Number].Text, Convert.ToDouble((sender as TextBox).Text));
                }
            }
        }
        private void Quantity_TextChange(object sender, EventArgs e)
        {
            ActionID.Singleton.ANCModification = true;
        }
    }
}
