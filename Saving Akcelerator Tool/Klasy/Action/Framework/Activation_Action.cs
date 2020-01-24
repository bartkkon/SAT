using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Action.Framework
{
    public class Activation_Action
    {
        public Activation_Action(int ANCChangeNumber)
        {
            ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Month", true).First()).Enabled = true;
            ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearAction", true).First()).Enabled = true;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ECCC", true).First()).Enabled = true;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_PNCEsty", true).First()).Enabled = true;
            if (ANCChangeNumber == -1)
            {
                for (int counter = 1; counter <= 10; counter++)
                {
                    try
                    {
                        ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Estymacja" + counter.ToString(), true).First()).Enabled = true;
                        ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Percent" + counter.ToString(), true).First()).Enabled = true;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Estymacja" + counter.ToString(), true).First()).Enabled = true;
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Percent" + counter.ToString(), true).First()).Enabled = true;
            }
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ANC", true).First()).Enabled = true;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ANCby", true).First()).Enabled = true;
            ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_MassCalc", true).First()).Enabled = true;
        }
    }
}
