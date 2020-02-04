using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Targets
{
    public class SaveTargets
    {
        private readonly decimal _Year;
        public SaveTargets(decimal Year)
        {
            _Year = Year;

            TargetSave();
        }

        private void TargetSave()
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;
            int Revision;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Targets, "Kurs");

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", _Year.ToString())).First();
            if (TargetsRow != null)
            {
                string[] DM = (TargetsRow["DM"].ToString()).Split('/');
                string[] PC = (TargetsRow["PC"].ToString()).Split('/');
                string[] Ele = (TargetsRow["Ele"].ToString()).Split('/');
                string[] Mech = (TargetsRow["Mech"].ToString()).Split('/');
                string[] NVR = (TargetsRow["NVR"].ToString()).Split('/');
                string DMSum = "";
                string PCSum = "";
                string EleSum = "";
                string MechSum = "";
                string NVRSum = "";

                Revision = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex;

                DM[Revision] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                PC[Revision] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                Ele[Revision] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                Mech[Revision] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                NVR[Revision] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");

                for (int counter = 0; counter <= 4; counter++)
                {
                    DMSum = DMSum + DM[counter] + "/";
                    PCSum = PCSum + PC[counter] + "/";
                    EleSum = EleSum + Ele[counter] + "/";
                    MechSum = MechSum + Mech[counter] + "/";
                    NVRSum = NVRSum + NVR[counter] + "/";
                }
                TargetsRow["DM"] = DMSum;
                TargetsRow["PC"] = PCSum;
                TargetsRow["Ele"] = EleSum;
                TargetsRow["Mech"] = MechSum;
                TargetsRow["NVR"] = NVRSum;
            }
            else
            {
                string Begining;
                string End;

                TargetsRow = Targets.NewRow();

                TargetsRow["PC"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                TargetsRow["Ele"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                TargetsRow["Mech"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                TargetsRow["NVR"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");

                Revision = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex;

                switch(Revision)
                {
                    case 0:
                        Begining = "";
                        End = "/////";
                        break;
                    case 1:
                        Begining = "/";
                        End = "////";
                        break;
                    case 2:
                        Begining = "//";
                        End = "///";
                        break;
                    case 3:
                        Begining = "///";
                        End = "//";
                        break;
                    case 4:
                        Begining = "////";
                        End = "/";
                        break;
                    default:
                        Begining = "";
                        End = "";
                        break;
                }
                TargetsRow["DM"] = Begining + ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + End;
                TargetsRow["PC"] = Begining + ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + End;
                TargetsRow["Ele"] = Begining + ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + End;
                TargetsRow["Mech"] = Begining + ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + End;
                TargetsRow["NVR"] = Begining + ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + End;

                Targets.Rows.Add(TargetsRow);
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref Targets, "Kurs");
        }
    }
}
