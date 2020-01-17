using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Framework
{
    public class LoadSpecificPNC
    {
        private readonly string _newPNC;
        private readonly string _oldPNC;
        private readonly string _project;
        public LoadSpecificPNC(string What)
        {

            _newPNC = What.Substring(0, 9);
            _oldPNC = What.Remove(0, 13).Replace(")", "");
            _project = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("combo_Project", true).First()).SelectedItem.ToString();

            LoadData();
        }

        private void LoadData()
        {
            DataTable AllData = new DataTable();
            DataRow[] ProjectRows;
            DataRow SpecyficPNC;

            Data_Import.Singleton().Load_TxtToDataTable2(ref AllData, "PlatformPNCList");

            ProjectRows = AllData.Select(string.Format("Project LIKE '%{0}%'", _project)).ToArray();
            SpecyficPNC = AllData.NewRow();

            foreach(DataRow Row in ProjectRows)
            {
                if(Row["NewPNC"].ToString() == _newPNC)
                {
                    if(Row["OldPNC"].ToString() == _oldPNC)
                    {
                        SpecyficPNC.ItemArray = (object[])Row.ItemArray.Clone();
                        break;
                    }
                }
            }

            if (SpecyficPNC == null)
                return;

            LoadSpecificationToLabel(SpecyficPNC);
        }

        private void LoadSpecificationToLabel(DataRow Data)
        {
            AddData("PNC", Data["OldPNC"].ToString(), Data["NewPNC"].ToString());
            AddData("Brand", Data["OldBrand"].ToString(), Data["NewBrand"].ToString());
            AddData("Master", Data["OldMaster"].ToString(), Data["NewMaster"].ToString());
            AddData("Denomination", Data["OldDenomination"].ToString(), Data["NewDenomination"].ToString());
            AddData("Platform", Data["OldPlatform"].ToString(), Data["NewPlatform"].ToString());
            AddData("Instalation", Data["OldInstallation"].ToString(), Data["NewInstallation"].ToString());
            AddData("FlowDevice", Data["OldFlowDevice"].ToString(), Data["NewFlowDevice"].ToString());
            AddData("Motor", Data["OldMotor"].ToString(), Data["NewMotor"].ToString());
            AddData("Class", Data["OldClass"].ToString(), Data["NewClass"].ToString());
            AddData("Noise", Data["OldNoise"].ToString(), Data["NewNoise"].ToString());
            AddData("EDW", Data["OldEDW"].ToString(), Data["NewEDW"].ToString()); 
            AddData("PB", Data["OldPB"].ToString(), Data["NewPB"].ToString());
            AddData("Color", Data["OldColor"].ToString(), Data["NewColor"].ToString());
            AddData("Voltage", Data["OldVoltage"].ToString(), Data["NewVoltage"].ToString());
            AddData("Frequency", Data["OldFrequency"].ToString(), Data["NewFrequency"].ToString());
            AddData("OffMode", Data["OldOffMode"].ToString(), Data["NewOffMode"].ToString());
        }

        private void AddData(string Where, string Old, string New)
        {
            Label LabNew = (Label)MainProgram.Self.TabControl.Controls.Find("lab_Platform_" + Where + "Actual", true).First();
            Label LabOld = (Label)MainProgram.Self.TabControl.Controls.Find("lab_Platform_" + Where + "Precedessor", true).First();

            LabNew.Text = New;
            LabOld.Text = Old;
        }
    }
}
