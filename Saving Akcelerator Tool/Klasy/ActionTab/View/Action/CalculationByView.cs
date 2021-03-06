﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Acton;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class CalculationByView : UserControl
    {
        private bool Calculation;
        public CalculationByView()
        {
            InitializeComponent();
            Calculation = true;
        }

        public void SetCalcMethod(string Method)
        {
            if (Method == "ANC")
                Cb_CalcANC.Checked = true;
            else if (Method == "ANCSpec")
                Cb_CalcANCby.Checked = true;
            else if (Method == "PNC")
                Cb_CalcPNC.Checked = true;
            else if (Method == "PNCSpec")
                Cb_CalcPNCSpec.Checked = true;
        }

        public string GetCalcMethod()
        {
            if (Cb_CalcANC.Checked)
                return "ANC";
            else if (Cb_CalcANCby.Checked)
                return "ANCSpec";
            else if (Cb_CalcPNC.Checked)
                return "PNC";
            else
                return "PNCSpec";
        }

        public bool GetANC()
        {
            return Cb_CalcANC.Checked;
        }

        public bool GetANCSpec()
        {
            return Cb_CalcANCby.Checked;
        }

        public bool GetPNC()
        {
            return Cb_CalcPNC.Checked;
        }

        public bool GetPNCSpec()
        {
            return Cb_CalcPNCSpec.Checked;
        }

        public void SetANC(bool ANC)
        {
            Calculation = false;
            Cb_CalcANC.Checked = ANC;
            Calculation = true;
        }

        public void SetANCSpec(bool ANCSpec)
        {
            Calculation = false;
            Cb_CalcANCby.Checked = ANCSpec;
            Calculation = true;
        }

        public void SetPNC(bool PNC)
        {
            Calculation = false;
            Cb_CalcPNC.Checked = PNC;
            Calculation = true;
        }

        public void SetPNCSpec(bool PNCSpec)
        {
            Calculation = false;
            Cb_CalcPNCSpec.Checked = PNCSpec;
            Calculation = true;
        }

        public void Clear()
        {
            Calculation = false;
            Cb_CalcANC.Checked = true;
            Calculation = true;
        }

        private void Cb_Calc_CheckedChanged(object sender, EventArgs e)
        {
            Cb_CalcANC.CheckedChanged -= Cb_Calc_CheckedChanged;
            Cb_CalcANCby.CheckedChanged -= Cb_Calc_CheckedChanged;
            Cb_CalcPNC.CheckedChanged -= Cb_Calc_CheckedChanged;
            Cb_CalcPNCSpec.CheckedChanged -= Cb_Calc_CheckedChanged;

            if ((sender as CheckBox).Text == "ANC")
            {
                Cb_CalcANCby.Checked = false;
                Cb_CalcPNC.Checked = false;
                Cb_CalcPNCSpec.Checked = false;
                Pb_PNC.Visible = false;
                MainProgram.Self.actionView.ecccView.VisibleECCCSpec(false);
                MainProgram.Self.actionView.PNCSpecialEstymationView.Clear();
                MainProgram.Self.actionView.PNCSpecialEstymationView.Visible = false;
                MainProgram.Self.actionView.CalculationGroup.Clear();
                MainProgram.Self.actionView.CalculationGroup.Visible = false;
                MainProgram.Self.actionView.PNCListView.Visible = false;
                MainProgram.Self.actionView.ButtonsView.SetSaveButtonVisible(false);
                MainProgram.Self.actionView.ButtonsView.SetSpecialButtonEnable(false);
                if (Calculation)
                    ActionID.Singleton.CalcModification = true;
            }
            else if ((sender as CheckBox).Text == "ANC Special")
            {
                Cb_CalcANC.Checked = false;
                Cb_CalcPNC.Checked = false;
                Cb_CalcPNCSpec.Checked = false;
                Pb_PNC.Visible = false;
                MainProgram.Self.actionView.ecccView.VisibleECCCSpec(false);
                MainProgram.Self.actionView.PNCSpecialEstymationView.Clear();
                MainProgram.Self.actionView.PNCSpecialEstymationView.Visible = false;
                MainProgram.Self.actionView.CalculationGroup.Clear();
                MainProgram.Self.actionView.CalculationGroup.SetVisibleCount(MainProgram.Self.actionView.ANCChangeView.GetVisibleNumber());
                MainProgram.Self.actionView.CalculationGroup.Visible = true;
                MainProgram.Self.actionView.PNCListView.Visible = false;
                MainProgram.Self.actionView.ButtonsView.SetSaveButtonVisible(false);
                MainProgram.Self.actionView.ButtonsView.SetSpecialButtonEnable(false);
                if (Calculation)
                {
                    ActionID.Singleton.CalcModification = true;
                    ActionID.Singleton.MassModification = true;
                }
            }
            else if ((sender as CheckBox).Text == "PNC")
            {
                Cb_CalcANC.Checked = false;
                Cb_CalcANCby.Checked = false;
                Cb_CalcPNCSpec.Checked = false;
                Pb_PNC.Visible = true;
                Pb_PNC.Text = "Add PNC";
                MainProgram.Self.actionView.ecccView.VisibleECCCSpec(false);
                MainProgram.Self.actionView.PNCSpecialEstymationView.Clear();
                MainProgram.Self.actionView.PNCSpecialEstymationView.Visible = false;
                MainProgram.Self.actionView.CalculationGroup.Clear();
                MainProgram.Self.actionView.CalculationGroup.Visible = false;
                MainProgram.Self.actionView.PNCListView.Visible = true;
                MainProgram.Self.actionView.ButtonsView.SetSaveButtonVisible(true);
                MainProgram.Self.actionView.ButtonsView.SetSpecialButtonEnable(false);
                if (Calculation)
                {
                    ActionID.Singleton.PNCModification = true;
                    ActionID.Singleton.CalcModification = true;
                }
            }
            else if((sender as CheckBox).Text == "PNC Special")
            {
                Cb_CalcANC.Checked = false;
                Cb_CalcANCby.Checked = false;
                Cb_CalcPNC.Checked = false;
                Pb_PNC.Visible = true;
                Pb_PNC.Text = "Add PNC Spec";
                MainProgram.Self.actionView.ecccView.VisibleECCCSpec(true);
                MainProgram.Self.actionView.PNCSpecialEstymationView.Clear();
                MainProgram.Self.actionView.PNCSpecialEstymationView.Visible = true;
                MainProgram.Self.actionView.CalculationGroup.Clear();
                MainProgram.Self.actionView.CalculationGroup.Visible = false;
                MainProgram.Self.actionView.PNCListView.Visible = true;
                MainProgram.Self.actionView.ButtonsView.SetSaveButtonVisible(true);
                MainProgram.Self.actionView.ButtonsView.SetSpecialButtonEnable(true);
                if (Calculation)
                {
                    ActionID.Singleton.PNCSpecModification = true;
                    ActionID.Singleton.CalcModification = true;
                }
            }

            Cb_CalcANC.CheckedChanged += Cb_Calc_CheckedChanged;
            Cb_CalcANCby.CheckedChanged += Cb_Calc_CheckedChanged;
            Cb_CalcPNC.CheckedChanged += Cb_Calc_CheckedChanged;
            Cb_CalcPNCSpec.CheckedChanged += Cb_Calc_CheckedChanged;

            if(Calculation)
            {
                ActionID.Singleton.ActionModification = true;
            }
        }

        private void Pb_PNC_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Add PNC")
            {
                Form AddData = new AddData("Proszę podać listę PNC", "PNC");
                AddData.ShowDialog();
            }
            else if ((sender as Button).Text == "Add PNC Spec")
            {
                Form AddData = new AddData("Proszę podać liste PNC", "PNCSpec");
                AddData.ShowDialog();
            }
        }
    }
}
