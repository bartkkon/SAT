using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Targets
{
    public class LoadTargets
    {
        private readonly decimal _Year;
        public LoadTargets(decimal Year)
        {
            _Year = Year;

            TargetsLoad();
        }

        private void TargetsLoad()
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;
            int Revision = 5;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Targets, "Kurs");

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).FirstOrDefault();
            if (TargetsRow != null)
            {
                string[] DM = (TargetsRow["DM"].ToString()).Split('/');
                string[] PC = (TargetsRow["PC"].ToString()).Split('/');
                string[] Ele = (TargetsRow["Ele"].ToString()).Split('/');
                string[] Mech = (TargetsRow["Mech"].ToString()).Split('/');
                string[] NVR = (TargetsRow["NVR"].ToString()).Split('/');
                
                for(int counter = 4; counter>=0; counter--)
                {
                    if(DM[counter]!= "")
                    {
                        Revision = counter;
                        break;
                    }
                }

                if(Revision != 5)
                {
                    ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = Revision;
                    ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[Revision];
                    ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[Revision];
                    ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[Revision];
                    ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[Revision];
                    ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[Revision];
                }
            }
            if(Revision == 5)
            {
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = "";
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = "";
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = "";
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = "";
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 0;
                ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = "";
            }
        }
    }
}
