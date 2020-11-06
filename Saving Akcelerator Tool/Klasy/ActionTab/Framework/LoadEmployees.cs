using Saving_Accelerator_Tool.Klasy.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class LoadEmployees
    {
        private readonly ComboBox _ActionLeader;
        private readonly bool _AddAll;
        public  LoadEmployees(ComboBox ActionLeader, bool AddAll)
        {
            _ActionLeader = ActionLeader;
            _AddAll = AddAll;
            Load();
        }

        private void Load()
        {
            DataTable Access = new DataTable();
            Data_Import.Singleton().Load_TxtToDataTable2(ref Access, "Access");

            if (_AddAll)
            {
                _ActionLeader.Items.Add("All");
            }

            if (Users.Singleton.Role != "PCMenager")
            {
                _ActionLeader.Items.Add(Users.Singleton.Name);
            }

            foreach (DataRow AccessRow in Access.Rows)
            {
                if (AccessRow["Name"].ToString() != Users.Singleton.Name)
                {
                    if (Users.Singleton.Role == "Admin" || Users.Singleton.Role == "PCMenager")
                        if(Users.Singleton.Name != AccessRow["FullName"].ToString())
                            _ActionLeader.Items.Add(AccessRow["FullName"].ToString());
                    else if (Users.Singleton.Role == "EleMenager" && AccessRow["ActionEle"].ToString() == "true" && AccessRow["Role"].ToString() != "PCMenager")
                        _ActionLeader.Items.Add(AccessRow["FullName"].ToString());
                    else if (Users.Singleton.Role == "MechMenager" && AccessRow["ActionMech"].ToString() == "true" && AccessRow["Role"].ToString() != "PCMenager")
                        _ActionLeader.Items.Add(AccessRow["FullName"].ToString());
                    else if (Users.Singleton.Role == "NVRMenager" && AccessRow["ActionNVR"].ToString() == "true" && AccessRow["Role"].ToString() != "PCMenager")
                        _ActionLeader.Items.Add(AccessRow["FullName"].ToString());
                }
            }
            _ActionLeader.SelectedIndex = 0;
        }
    }
}
