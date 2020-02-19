using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class Deactivation_Action
    {
        public Deactivation_Action(int ANCChangeNumber)
        {
            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Month", true).First()).Enabled = false;
            ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearAction", true).First()).Enabled = false;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ECCC", true).First()).Enabled = false;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_PNCEsty", true).First()).Enabled = false;
            if (ANCChangeNumber == -1)
            {
                for (int counter = 1; counter <= 10; counter++)
                {
                    try
                    {
                        ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Estymacja" + counter.ToString(), true).First()).Enabled = false;
                        ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Percent" + counter.ToString(), true).First()).Enabled = false;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Estymacja" + counter.ToString(), true).First()).Enabled = false;
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Percent" + counter.ToString(), true).First()).Enabled = false;
            }
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ANC", true).First()).Enabled = false;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ANCby", true).First()).Enabled = false;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_MassCalc", true).First()).Enabled = false;
        }
    }
}
