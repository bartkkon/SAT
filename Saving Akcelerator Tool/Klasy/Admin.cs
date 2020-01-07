using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Saving_Accelerator_Tool
{
    public class Admin
    {
        MainProgram mainProgram;
        Data_Import ImportData;

        string LinkFrozen;
        string LinkKurs;
        string LinkAccess;

        public Admin(MainProgram mainProgram, Data_Import ImportData)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            LinkFrozen = ImportData.Load_Link("Frozen");
            LinkKurs = ImportData.Load_Link("Kurs");
            LinkAccess = ImportData.Load_Link("Access");
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

        public void Admin_AccessRefresh()
        {
            Cursor.Current = Cursors.WaitCursor;
            AccessRefresh();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_AccessSave()
        {
            Cursor.Current = Cursors.WaitCursor;
            AccessSave();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_AddNewAccount()
        {
            Cursor.Current = Cursors.WaitCursor;
            AddNewAccount();
            AccessRefresh();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_DeleteAccount()
        {
            Cursor.Current = Cursors.WaitCursor;
            DeleteAccount();
            AccessRefresh();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_LoadAccess()
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadAccess();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_TargetsOpen()
        {
            Cursor.Current = Cursors.WaitCursor;
            TargetOpen();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_TargetsSave()
        {
            Cursor.Current = Cursors.WaitCursor;
            TargetsSave();
            Cursor.Current = Cursors.Default;
        }

        public void Admin_ActivatorAction()
        {
            ActivatorAction();
        }

        public void Admin_DeactivatorAction()
        {
            DeactivatorAction();
        }

        public void Admin_TargetChangeRewizion()
        {
            TargetChangeRewizion();
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
            Temp2 = Temp2 + Date;
            File.Move(Temp1, Temp2);
        }

        private void DeactivatorAction()
        {
            ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First()).Enabled = false;
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Enabled = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ECCC", true).First()).Enabled = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_PNCEsty", true).First()).Enabled = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_STK", true).First()).Enabled = false;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ANC", true).First()).Enabled = false;
        }

        private void ActivatorAction()
        {
            ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First()).Enabled = true;
            ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Enabled = true;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ECCC", true).First()).Enabled = true;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_PNCEsty", true).First()).Enabled = true;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_STK", true).First()).Enabled = true;
            ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ANC", true).First()).Enabled = true;
        }

        private void TargetsSave()
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;

            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("Num_AdminTargetsYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Targets, LinkKurs);

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();
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

                if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 0)
                {
                    DM[0] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                    PC[0] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                    Ele[0] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                    Mech[0] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                    NVR[0] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 1)
                {
                    DM[1] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                    PC[1] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                    Ele[1] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                    Mech[1] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                    NVR[1] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 2)
                {
                    DM[2] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                    PC[2] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                    Ele[2] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                    Mech[2] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                    NVR[2] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 3)
                {
                    DM[3] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                    PC[3] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                    Ele[3] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                    Mech[3] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                    NVR[3] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 4)
                {
                    DM[4] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "");
                    PC[4] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                    Ele[4] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                    Mech[4] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                    NVR[4] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                }

                for (int counter= 0; counter<=4; counter++)
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
                TargetsRow = Targets.NewRow();
                TargetsRow["PC"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "");
                TargetsRow["Ele"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "");
                TargetsRow["Mech"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "");
                TargetsRow["NVR"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "");
                if(((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 0)
                {
                    TargetsRow["DM"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + "/////";
                    TargetsRow["PC"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + "/////";
                    TargetsRow["Ele"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + "/////";
                    TargetsRow["Mech"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + "/////";
                    TargetsRow["NVR"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + "/////";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 1)
                {
                    TargetsRow["DM"] = "/" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + "////";
                    TargetsRow["PC"] = "/" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + "////";
                    TargetsRow["Ele"] = "/" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + "////";
                    TargetsRow["Mech"] = "/" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + "////";
                    TargetsRow["NVR"] = "/" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + "////";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 2)
                {
                    TargetsRow["DM"] = "//" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + "///";
                    TargetsRow["PC"] = "//" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + "///";
                    TargetsRow["Ele"] = "//" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + "///";
                    TargetsRow["Mech"] = "//" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + "///";
                    TargetsRow["NVR"] = "//" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + "///";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 3)
                {
                    TargetsRow["DM"] = "///" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + "//";
                    TargetsRow["PC"] = "///" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + "//";
                    TargetsRow["Ele"] = "///" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + "//";
                    TargetsRow["Mech"] = "///" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + "//";
                    TargetsRow["NVR"] = "///" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + "//";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex == 4)
                {
                    TargetsRow["DM"] = "////" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text.Replace(" ", "") + "/";
                    TargetsRow["PC"] = "////" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text.Replace(" ", "") + "/";
                    TargetsRow["Ele"] = "////" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text.Replace(" ", "") + "/";
                    TargetsRow["Mech"] = "////" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text.Replace(" ", "") + "/";
                    TargetsRow["NVR"] = "////" + ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text.Replace(" ", "") + "/";
                }
                else
                {
                    TargetsRow["DM"] = "/////";
                    TargetsRow["PC"] = "/////";
                    TargetsRow["Ele"] = "/////";
                    TargetsRow["Mech"] = "/////";
                    TargetsRow["NVR"] = "/////";
                }
                Targets.Rows.Add(TargetsRow);
            }
            ImportData.Save_DataTableToTXT(ref Targets, LinkKurs);
        }

        private void TargetOpen()
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;

            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("Num_AdminTargetsYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Targets, LinkKurs);

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();
            if(TargetsRow != null)
            {
                string[] DM = (TargetsRow["DM"].ToString()).Split('/');
                string[] PC = (TargetsRow["PC"].ToString()).Split('/');
                string[] Ele = (TargetsRow["Ele"].ToString()).Split('/');
                string[] Mech = (TargetsRow["Mech"].ToString()).Split('/');
                string[] NVR = (TargetsRow["NVR"].ToString()).Split('/');

                if (DM[4] != "")
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 4;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[4];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[4];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[4];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[4];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[4];
                }
                if (DM[3] != "")
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 3;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[3];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[3];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[3];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[3];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[3];
                }
                else if (DM[2] != "")
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 2;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[2];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[2];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[2];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[2];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[2];
                }
                else if (DM[1] != "")
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 1;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[1];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[1];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[1];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[1];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[1];
                }
                else if (DM[0] != "")
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 0;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[0];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[0];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[0];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[0];
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[0];
                }
                else
                {
                    ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 0;
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = "";
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = "";
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = "";
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = "";
                    ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = "";
                }

            }
            else
            {
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = "";
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = "";
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = "";
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = "";
                ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex = 0;
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = "";
                TargetsSave();
            }
        }

        private void TargetChangeRewizion()
        {
            DataTable Targets = new DataTable();
            DataRow TargetsRow;
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("Num_AdminTargetsYear", true).First()).Value;
            int SelectedIndex = ((ComboBox)mainProgram.TabControl.Controls.Find("Comb_AdminTargetsRewizja", true).First()).SelectedIndex;

            ImportData.Load_TxtToDataTable(ref Targets, LinkKurs);
            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = "";
            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = "";
            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = "";
            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = "";
            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = "";

            TargetsRow = Targets.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();
            if (TargetsRow != null)
            {
                string[] DM = (TargetsRow["DM"].ToString()).Split('/');
                string[] PC = (TargetsRow["PC"].ToString()).Split('/');
                string[] Ele = (TargetsRow["Ele"].ToString()).Split('/');
                string[] Mech = (TargetsRow["Mech"].ToString()).Split('/');
                string[] NVR = (TargetsRow["NVR"].ToString()).Split('/');

                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsDM", true).First()).Text = DM[SelectedIndex];
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsPercent", true).First()).Text = PC[SelectedIndex];
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsElePercent", true).First()).Text = Ele[SelectedIndex];
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsMechPercent", true).First()).Text = Mech[SelectedIndex];
                ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminTargetsNVRPercent", true).First()).Text = NVR[SelectedIndex];
            }
        }

        private void DeleteAccount()
        {
            DataTable Account = new DataTable();
            DataRow FoundRow;
            ComboBox cb_comBox_AdminAccess = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_AdminAccess", true).First();

            ImportData.Load_TxtToDataTable(ref Account, LinkAccess);

            FoundRow = Account.Select(string.Format("Name LIKE '%{0}%'", cb_comBox_AdminAccess.Text)).FirstOrDefault();
            if (FoundRow != null)
            {
                Account.Rows.Remove(FoundRow);
            }

            ImportData.Save_DataTableToTXT(ref Account, LinkAccess);
        }

        private void LoadAccess()
        {
            DataTable Access = new DataTable();
            DataRow FoundAccess;
            ComboBox cb_comBox_AdminAccess = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_AdminAccess", true).First();

            ImportData.Load_TxtToDataTable(ref Access, LinkAccess);

            FoundAccess = Access.Select(string.Format("Name LIKE '%{0}%'", cb_comBox_AdminAccess.Text)).FirstOrDefault();

            ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminAccessFullName", true).First()).Text = FoundAccess["FullName"].ToString();

            if (FoundAccess["Role"].ToString() == "Employee")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 0;
            }
            else if (FoundAccess["Role"].ToString() == "EleMenager")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 1;
            }
            else if (FoundAccess["Role"].ToString() == "MechMenager")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 2;
            }
            else if (FoundAccess["Role"].ToString() == "NVRMenager")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 3;
            }
            else if (FoundAccess["Role"].ToString() == "PCMenager")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 4;
            }
            else if (FoundAccess["Role"].ToString() == "Admin")
            {
                ((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 5;
            }

            if (FoundAccess["tab_Action"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAction", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAction", true).First()).Checked = false;
            }

            if (FoundAccess["Action"].ToString() == "Developer")
            {
                ((RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked = false;
                ((RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminDevelop", true).First()).Checked = true;
            }
            else
            {
                ((RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked = true;
                ((RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminDevelop", true).First()).Checked = false;
            }

            if (FoundAccess["ActionEle"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminElectronic", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminElectronic", true).First()).Checked = false;
            }

            if (FoundAccess["ActionMech"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminMechanic", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminMechanic", true).First()).Checked = false;
            }

            if (FoundAccess["ActionNVR"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminNVR", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminNVR", true).First()).Checked = false;
            }

            if (FoundAccess["tab_Summary"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSummary", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSummary", true).First()).Checked = false;
            }

            if (FoundAccess["tab_Statistic"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabStatistic", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabStatistic", true).First()).Checked = false;
            }

            if (FoundAccess["tab_STK"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSTK", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSTK", true).First()).Checked = false;
            }

            if (FoundAccess["tab_Quantity"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabQuantity", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabQuantity", true).First()).Checked = false;
            }

            if (FoundAccess["tab_Admin"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAdmin", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAdmin", true).First()).Checked = false;
            }

            if (FoundAccess["EleApprove"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapEle", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapEle", true).First()).Checked = false;
            }

            if (FoundAccess["MechApprove"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapMech", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapMech", true).First()).Checked = false;
            }

            if (FoundAccess["NVRApprove"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapNVR", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapNVR", true).First()).Checked = false;
            }

            if (FoundAccess["PCApprove"].ToString() == "true")
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapPC", true).First()).Checked = true;
            }
            else
            {
                ((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapPC", true).First()).Checked = false;
            }

        }

        private void AddNewAccount()
        {
            DataTable Access = new DataTable();
            DataRow NewAccount;

            ImportData.Load_TxtToDataTable(ref Access, LinkAccess);

            NewAccount = Access.NewRow();

            NewAccount["Name"] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_Admin_NewAccount", true).First()).Text;
            NewAccount["FullName"] = "";
            NewAccount["Role"] = "Employee";
            NewAccount["tab_Action"] = "flase";
            NewAccount["Action"] = "flase";
            NewAccount["ActionEle"] = "flase";
            NewAccount["ActionMech"] = "flase";
            NewAccount["tab_Summary"] = "flase";
            NewAccount["tab_STK"] = "flase";
            NewAccount["tab_Quantity"] = "flase";
            NewAccount["tab_Admin"] = "flase";
            NewAccount["EleApprove"] = "false";
            NewAccount["MechApprove"] = "false";
            NewAccount["NVRApprove"] = "false";
            NewAccount["PCApprove"] = "false";

            Access.Rows.Add(NewAccount);

            ImportData.Save_DataTableToTXT(ref Access, LinkAccess);
        }

        private void AccessSave()
        {
            DataTable Access = new DataTable();
            DataRow FoundRow;
            ComboBox cb_comBox_AdminAccess = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_AdminAccess", true).First();

            ImportData.Load_TxtToDataTable(ref Access, LinkAccess);

            if (cb_comBox_AdminAccess.Text != "")
            {
                FoundRow = Access.Select(string.Format("Name LIKE '%{0}%'", cb_comBox_AdminAccess.Text)).FirstOrDefault();

                FoundRow["FullName"] = ((TextBox)mainProgram.TabControl.Controls.Find("Tb_AdminAccessFullName", true).First()).Text;

                if(((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Employee")
                {
                    FoundRow["Role"] = "Employee";
                }
                else if(((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Electronic")
                {
                    FoundRow["Role"] = "EleMenager";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Mechanic")
                {
                    FoundRow["Role"] = "MechMenager";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "NVR")
                {
                    FoundRow["Role"] = "NVRMenager";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "PC")
                {
                    FoundRow["Role"] = "PCMenager";
                }
                else if (((ComboBox)mainProgram.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Admin")
                {
                    FoundRow["Role"] = "Admin";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAction", true).First()).Checked)
                {
                    FoundRow["tab_Action"] = "true";
                }
                else
                {
                    FoundRow["tab_Action"] = "false";
                }

                if (((RadioButton)mainProgram.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked)
                {
                    FoundRow["Action"] = "Viwer";
                }
                else
                {
                    FoundRow["Action"] = "Developer";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminElectronic", true).First()).Checked)
                {
                    FoundRow["ActionEle"] = "true";
                }
                else
                {
                    FoundRow["ActionEle"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminMechanic", true).First()).Checked)
                {
                    FoundRow["ActionMech"] = "true";
                }
                else
                {
                    FoundRow["ActionMech"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminNVR", true).First()).Checked)
                {
                    FoundRow["ActionNVR"] = "true";
                }
                else
                {
                    FoundRow["ActionNVR"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSummary", true).First()).Checked)
                {
                    FoundRow["tab_Summary"] = "true";
                }
                else
                {
                    FoundRow["tab_Summary"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabStatistic", true).First()).Checked)
                {
                    FoundRow["tab_Statistic"] = "true";
                }
                else
                {
                    FoundRow["tab_Statistic"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabSTK", true).First()).Checked)
                {
                    FoundRow["tab_STK"] = "true";
                }
                else
                {
                    FoundRow["tab_STK"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabQuantity", true).First()).Checked)
                {
                    FoundRow["tab_Quantity"] = "true";
                }
                else
                {
                    FoundRow["tab_Quantity"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_AdminTabAdmin", true).First()).Checked)
                {
                    FoundRow["tab_Admin"] = "true";
                }
                else
                {
                    FoundRow["tab_Admin"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapEle", true).First()).Checked)
                {
                    FoundRow["EleApprove"] = "true";
                }
                else
                {
                    FoundRow["EleApprove"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapMech", true).First()).Checked)
                {
                    FoundRow["MechApprove"] = "true";
                }
                else
                {
                    FoundRow["MechApprove"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapNVR", true).First()).Checked)
                {
                    FoundRow["NVRApprove"] = "true";
                }
                else
                {
                    FoundRow["NVRApprove"] = "false";
                }

                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Admin_RapPC", true).First()).Checked)
                {
                    FoundRow["PCApprove"] = "true";
                }
                else
                {
                    FoundRow["PCApprove"] = "false";
                }
            }
            else
            {
                return;
            }

            ImportData.Save_DataTableToTXT(ref Access, LinkAccess);

        }

        private void AccessRefresh()
        {
            DataTable Access = new DataTable();

            ComboBox cb_comBox_AdminAccess = (ComboBox)mainProgram.TabControl.Controls.Find("comBox_AdminAccess", true).First();

            ImportData.Load_TxtToDataTable(ref Access, LinkAccess);

            cb_comBox_AdminAccess.Items.Clear();
            cb_comBox_AdminAccess.Text = "";

            foreach (DataRow Row in Access.Rows)
            {
                cb_comBox_AdminAccess.Items.Add(Row["Name"]);
            }

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
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_ValueYear", true).First()).Value;
            TextBox tb_AdminECCC = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminECCC", true).First();
            TextBox tb_AdminEuro = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminEuro", true).First();
            TextBox tb_AdminDolars = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminDolars", true).First();
            TextBox tb_AdminSEK = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminSEK", true).First();

            ImportData.Load_TxtToDataTable(ref Value, LinkKurs);

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

            ImportData.Save_DataTableToTXT(ref Value, LinkKurs);
        }

        private void ValueRefreshData()
        {
            DataTable Value = new DataTable();
            DataRow FoundRow;
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_ValueYear", true).First()).Value;
            TextBox tb_AdminECCC = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminECCC", true).First();
            TextBox tb_AdminEuro = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminEuro", true).First();
            TextBox tb_AdminDolars = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminDolars", true).First();
            TextBox tb_AdminSEK = (TextBox)mainProgram.TabControl.Controls.Find("tb_AdminSEK", true).First();

            ImportData.Load_TxtToDataTable(ref Value, LinkKurs);

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
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_FrozenYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);

            NewRow = Frozen.NewRow();

            foreach (DataColumn column in Frozen.Columns)
            {
                if (column.ColumnName == "Year")
                {

                    NewRow[column.ColumnName] = Year.ToString();
                }
                else
                {
                    ComboBox ComboBoxFrozen = (ComboBox)mainProgram.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First();
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

            ImportData.Save_DataTableToTXT(ref Frozen, LinkFrozen);
        }

        private void FrozenRefreshData()
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Admin_FrozenYear", true).First()).Value;

            ImportData.Load_TxtToDataTable(ref Frozen, LinkFrozen);

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
                            ((ComboBox)mainProgram.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 0;
                        }
                        else if (FrozenRow[column.ColumnName].ToString() == "Open")
                        {
                            ((ComboBox)mainProgram.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 1;
                        }
                        else if (FrozenRow[column.ColumnName].ToString() == "Approve")
                        {
                            ((ComboBox)mainProgram.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 2;
                        }
                        else
                        {
                            ((ComboBox)mainProgram.TabControl.Controls.Find("Combo_Admin" + column.ColumnName, true).First()).SelectedIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
