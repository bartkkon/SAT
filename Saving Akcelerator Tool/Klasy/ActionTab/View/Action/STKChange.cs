using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Saving_Accelerator_Tool.Klasy.Acton;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class STKChange : UserControl
    {
        private readonly List<Label> OldSTK;
        private readonly List<Label> NewSTK;
        private readonly List<Label> Delta;
        private readonly List<TextBox> Estimation;
        private readonly List<TextBox> Percent;
        private readonly List<Label> ToCalc;

        private readonly List<Label> Arrow;
        private readonly List<Label> Equal;
        private readonly List<Label> PercentLab;

        public STKChange()
        {
            OldSTK = new List<Label>();
            NewSTK = new List<Label>();
            Delta = new List<Label>();
            Estimation = new List<TextBox>();
            Percent = new List<TextBox>();
            ToCalc = new List<Label>();
            Arrow = new List<Label>();
            Equal = new List<Label>();
            PercentLab = new List<Label>();


            InitializeComponent();

            AddComponentToList();
        }

        public void SetVisibleANC(int Row, bool VisibleBool)
        {
            OldSTK[Row].Visible = VisibleBool;
            OldSTK[Row].Text = "";
            NewSTK[Row].Visible = VisibleBool;
            NewSTK[Row].Text = "";
            Delta[Row].Visible = VisibleBool;
            Estimation[Row].Text = "";
            Estimation[Row].Visible = VisibleBool;
            Percent[Row].Visible = VisibleBool;
            Percent[Row].Text = "100";
            ToCalc[Row].Visible = VisibleBool;
            Arrow[Row].Visible = VisibleBool;
            Equal[Row].Visible = VisibleBool;
            PercentLab[Row].Visible = VisibleBool;
        }

        public void SetData(int Ilosc, decimal[] Old, decimal[] New, decimal[] DeltaBase, decimal[] STKEst, decimal[] PercentBase, decimal[] STKCalc)
        {
            for (int counter = 0; counter < Ilosc; counter++)
            {
                OldSTK[counter].Text = Old[counter].ToString();
                NewSTK[counter].Text = New[counter].ToString();
                Delta[counter].Text = DeltaBase[counter].ToString();
                if (STKEst[counter].ToString() != "0")
                    Estimation[counter].Text = STKEst[counter].ToString();
                Percent[counter].Text = PercentBase[counter].ToString();
                ToCalc[counter].Text = STKCalc[counter].ToString();
            }

            CalcSum();
        }

        public decimal[] GetOldSTK(int Ilosc)
        {
            decimal[] OldStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (OldSTK[counter].ToString() != "")
                    OldStkTable[counter] = decimal.Parse(OldSTK[counter].ToString());
            }

            return OldStkTable;
        }

        public decimal[] GetNewSTK(int Ilosc)
        {
            decimal[] NewStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (NewSTK[counter].ToString() != "")
                    NewStkTable[counter] = decimal.Parse(NewSTK[counter].ToString());
            }

            return NewStkTable;
        }

        public decimal[] GetDeltaSTK(int Ilosc)
        {
            decimal[] DeltaStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (Delta[counter].ToString() != "")
                    DeltaStkTable[counter] = decimal.Parse(Delta[counter].ToString());
            }

            return DeltaStkTable;
        }

        public decimal[] GetEstimationSTK(int Ilosc)
        {
            decimal[] EstimationStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (Estimation[counter].ToString() != "")
                    EstimationStkTable[counter] = decimal.Parse(Estimation[counter].ToString());
            }

            return EstimationStkTable;
        }

        public decimal[] GetPercentSTK(int Ilosc)
        {
            decimal[] PercentStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (Percent[counter].ToString() != "")
                    PercentStkTable[counter] = decimal.Parse(Percent[counter].ToString());
            }

            return PercentStkTable;
        }

        public decimal[] GetCalcSTK(int Ilosc)
        {
            decimal[] CalcStkTable = new decimal[Ilosc];
            for (int counter = 0; counter < Ilosc; counter++)
            {
                if (ToCalc[counter].ToString() != "")
                    CalcStkTable[counter] = decimal.Parse(ToCalc[counter].ToString());
            }

            return CalcStkTable;
        }

        public double GetSTKNew(int Count)
        {
            if (NewSTK[Count - 1].Text != "n/a")
                return Convert.ToDouble(NewSTK[Count - 1].Text);
            else
                return -999999;
        }

        public double GetSTKOld(int Count)
        {
            if (OldSTK[Count - 1].Text != "n/a")
                return Convert.ToDouble(OldSTK[Count - 1].Text);
            else
                return -999999;
        }

        public double GetDelta(int Count)
        {
            return Convert.ToDouble(Delta[Count - 1].Text);
        }

        public double GetEstimation(int Count)
        {
            if (Estimation[Count - 1].Text != "")
                return Convert.ToDouble(Estimation[Count - 1].Text);
            else
                return 0;
        }

        public double GetPercent(int Count)
        {
            return Convert.ToDouble(Percent[Count - 1].Text);
        }

        public double GetCalculation(int Count)
        {
            return Convert.ToDouble(ToCalc[Count - 1].Text);
        }

        public void SetOldSTK(int Count, string Value)
        {
            if (Value != "-999999")
                OldSTK[Count].Text = Value;
            else
                OldSTK[Count].Text = "n/a";
        }

        public void SetNewSTK(int Count, string Value)
        {
            if (Value != "-999999")
                NewSTK[Count].Text = Value;
            else
                NewSTK[Count].Text = "n/a";
        }

        public void SetDelta(int Count, string Value)
        {
            Delta[Count].Text = Value;
        }

        public void SetEstimation (int Count, string Value)
        {
            if (Value != "0")
                Estimation[Count].Text = Value;
            else
                Estimation[Count].Text = string.Empty;
        }

        public void SetPercent(int Count, string Value)
        {
            Percent[Count].Text = Value;
        }

        public void SetToCalc(int Count, string Value)
        {
            ToCalc[Count].Text = Value;
        }

        public void Clear()
        {
            for (int counter = 0; counter < 10; counter++)
            {
                OldSTK[counter].Text = "";
                OldSTK[counter].Visible = false;
                NewSTK[counter].Text = "";
                NewSTK[counter].Visible = false;
                Delta[counter].Visible = false;
                Estimation[counter].Text = "";
                Estimation[counter].Visible = false;
                Percent[counter].Text = "100";
                Percent[counter].Visible = false;
                ToCalc[counter].Text = "";
                ToCalc[counter].Visible = false;
                Arrow[counter].Visible = false;
                Equal[counter].Visible = false;
                PercentLab[counter].Visible = false;
                CalcSum();
            }
        }

        public void SumVisible(bool IfVisible)
        {
            lab_OldSum.Visible = IfVisible;
            lab_NewSum.Visible = IfVisible;
            lab_DeltaSum.Visible = IfVisible;
            lab_CalcSum.Visible = IfVisible;
        }

        private void CalcSum()
        {
            decimal SumDelta = 0;
            decimal SumCalc = 0;
            decimal SumOld = 0;
            decimal SumNew = 0;

            foreach (Label OldRow in OldSTK)
            {
                if (OldRow.Text != "")
                    SumOld += decimal.Parse(OldRow.Text);
            }
            foreach (Label NewRow in NewSTK)
            {
                if (NewRow.Text != "")
                    SumOld += decimal.Parse(NewRow.Text);
            }
            foreach (Label DeltaRow in Delta)
            {
                if (DeltaRow.Text != "")
                    SumDelta += decimal.Parse(DeltaRow.Text);
            }
            foreach (Label CalcRow in ToCalc)
            {
                if (CalcRow.Text != "")
                    SumCalc += decimal.Parse(CalcRow.Text);
            }
            lab_OldSum.Text = SumOld.ToString();
            lab_NewSum.Text = SumNew.ToString();
            lab_DeltaSum.Text = SumDelta.ToString();
            lab_CalcSum.Text = SumCalc.ToString();
        }

        private void AddComponentToList()
        {
            OldSTK.Add(lab_OldSTK1);
            OldSTK.Add(lab_OldSTK2);
            OldSTK.Add(lab_OldSTK3);
            OldSTK.Add(lab_OldSTK4);
            OldSTK.Add(lab_OldSTK5);
            OldSTK.Add(lab_OldSTK6);
            OldSTK.Add(lab_OldSTK7);
            OldSTK.Add(lab_OldSTK8);
            OldSTK.Add(lab_OldSTK9);
            OldSTK.Add(lab_OldSTK10);
            NewSTK.Add(lab_NewSTK1);
            NewSTK.Add(lab_NewSTK2);
            NewSTK.Add(lab_NewSTK3);
            NewSTK.Add(lab_NewSTK4);
            NewSTK.Add(lab_NewSTK5);
            NewSTK.Add(lab_NewSTK6);
            NewSTK.Add(lab_NewSTK7);
            NewSTK.Add(lab_NewSTK8);
            NewSTK.Add(lab_NewSTK9);
            NewSTK.Add(lab_NewSTK10);
            Delta.Add(lab_Delta1);
            Delta.Add(lab_Delta2);
            Delta.Add(lab_Delta3);
            Delta.Add(lab_Delta4);
            Delta.Add(lab_Delta5);
            Delta.Add(lab_Delta6);
            Delta.Add(lab_Delta7);
            Delta.Add(lab_Delta8);
            Delta.Add(lab_Delta9);
            Delta.Add(lab_Delta10);
            Estimation.Add(tb_Estymacja1);
            Estimation.Add(tb_Estymacja2);
            Estimation.Add(tb_Estymacja3);
            Estimation.Add(tb_Estymacja4);
            Estimation.Add(tb_Estymacja5);
            Estimation.Add(tb_Estymacja6);
            Estimation.Add(tb_Estymacja7);
            Estimation.Add(tb_Estymacja8);
            Estimation.Add(tb_Estymacja9);
            Estimation.Add(tb_Estymacja10);
            Percent.Add(tb_Percent1);
            Percent.Add(tb_Percent2);
            Percent.Add(tb_Percent3);
            Percent.Add(tb_Percent4);
            Percent.Add(tb_Percent5);
            Percent.Add(tb_Percent6);
            Percent.Add(tb_Percent7);
            Percent.Add(tb_Percent8);
            Percent.Add(tb_Percent9);
            Percent.Add(tb_Percent10);
            ToCalc.Add(lab_Calc1);
            ToCalc.Add(lab_Calc2);
            ToCalc.Add(lab_Calc3);
            ToCalc.Add(lab_Calc4);
            ToCalc.Add(lab_Calc5);
            ToCalc.Add(lab_Calc6);
            ToCalc.Add(lab_Calc7);
            ToCalc.Add(lab_Calc8);
            ToCalc.Add(lab_Calc9);
            ToCalc.Add(lab_Calc10);
            Arrow.Add(lab_Arrow1);
            Arrow.Add(lab_Arrow2);
            Arrow.Add(lab_Arrow3);
            Arrow.Add(lab_Arrow4);
            Arrow.Add(lab_Arrow5);
            Arrow.Add(lab_Arrow6);
            Arrow.Add(lab_Arrow7);
            Arrow.Add(lab_Arrow8);
            Arrow.Add(lab_Arrow9);
            Arrow.Add(lab_Arrow10);
            Equal.Add(lab_Equal1);
            Equal.Add(lab_Equal2);
            Equal.Add(lab_Equal3);
            Equal.Add(lab_Equal4);
            Equal.Add(lab_Equal5);
            Equal.Add(lab_Equal6);
            Equal.Add(lab_Equal7);
            Equal.Add(lab_Equal8);
            Equal.Add(lab_Equal9);
            Equal.Add(lab_Equal10);
            PercentLab.Add(lab_Percent1);
            PercentLab.Add(lab_Percent2);
            PercentLab.Add(lab_Percent3);
            PercentLab.Add(lab_Percent4);
            PercentLab.Add(lab_Percent5);
            PercentLab.Add(lab_Percent6);
            PercentLab.Add(lab_Percent7);
            PercentLab.Add(lab_Percent8);
            PercentLab.Add(lab_Percent9);
            PercentLab.Add(lab_Percent10);
        }

        private void CalcEstimation(int number)
        {
            double Calculate = 0;
            if (Estimation[number].Text != "")
            {
                Calculate = Convert.ToDouble(Estimation[number].Text) * (Convert.ToDouble(Percent[number].Text) / 100);
                ToCalc[number].Text = Math.Round(Calculate, 4, MidpointRounding.AwayFromZero).ToString();
            }
            else if (Delta[number].Text != "")
            {
                Calculate = Convert.ToDouble(Delta[number].Text) * (Convert.ToDouble(Percent[number].Text) / 100);
                ToCalc[number].Text = Math.Round(Calculate, 4, MidpointRounding.AwayFromZero).ToString();
            }
            else
                ToCalc[number].Text = "";

            if (Calculate > 0)
                ToCalc[number].ForeColor = Color.Green;
            else if (Calculate < 0)
                ToCalc[number].ForeColor = Color.Red;
            else
                ToCalc[number].ForeColor = Color.Black;
        }

        private void CalcDelta(int number)
        {
            double Old = 0;
            double New = 0;

            if (OldSTK[number].Text != "" && OldSTK[number].Text != "n/a")
            {
                Old = Convert.ToDouble(OldSTK[number].Text);
            }
            if (NewSTK[number].Text != "" && NewSTK[number].Text != "n/a")
            {
                New = Convert.ToDouble(NewSTK[number].Text);
            }

            double DeltaSum = Old - New;
            Delta[number].Text = (Math.Round(DeltaSum, 4, MidpointRounding.AwayFromZero)).ToString();

            if (DeltaSum > 0)
                Delta[number].ForeColor = Color.Green;
            else if (DeltaSum < 0)
                Delta[number].ForeColor = Color.Red;
            else
                Delta[number].ForeColor = Color.Black;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                if ((sender as TextBox).Text[0] == ',')
                    (sender as TextBox).Text = "0" + (sender as TextBox).Text;
                if ((sender as TextBox).Text[0] == '-' && (sender as TextBox).Text[1] == ',')
                    (sender as TextBox).Text = "-0" + (sender as TextBox).Text.Remove(0, 1);

                if ((sender as TextBox).Name[3] == 'P')
                    (sender as TextBox).Text = Math.Round(Convert.ToDouble((sender as TextBox).Text), 1, MidpointRounding.AwayFromZero).ToString();
                else
                    (sender as TextBox).Text = Math.Round(Convert.ToDouble((sender as TextBox).Text), 4, MidpointRounding.AwayFromZero).ToString();
            }

            if ((sender as TextBox).Name[3] == 'E' && (sender as TextBox).Text == "0")
                (sender as TextBox).Text = string.Empty;

            if ((sender as TextBox).Name[3] == 'P' && (sender as TextBox).Text == "0")
                (sender as TextBox).Text = "100";

            if ((sender as TextBox).Text.Length == 0 && (sender as TextBox).Name[3] == 'P')
                (sender as TextBox).Text = "100";

            if ((sender as TextBox).Name[3] == 'P')
                CalcEstimation(Percent.IndexOf((sender as TextBox)));
            else if ((sender as TextBox).Name[3] == 'E')
                CalcEstimation(Estimation.IndexOf((sender as TextBox)));

            ActionID.Singleton.ANCModification = true;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') == -1) && ((sender as TextBox).SelectionStart == 0))
                e.Handled = true;

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
                e.Handled = true;

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == -1) && ((sender as TextBox).SelectionStart != 0))
                e.Handled = true;
        }

        private void Lab_Delta_TextChanged(object sender, EventArgs e)
        {
            CalcEstimation(Delta.IndexOf(sender as Label));
        }

        private void Lab_STK_TextChanged(object sender, EventArgs e)
        {
            if ((sender as Label).Name[4] == 'O')
                CalcDelta(OldSTK.IndexOf(sender as Label));
            if ((sender as Label).Name[4] == 'N')
                CalcDelta(NewSTK.IndexOf(sender as Label));
        }
    }
}
