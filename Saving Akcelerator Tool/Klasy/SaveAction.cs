using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Saving_Accelerator_Tool
{
    public class SaveAction
    {
        private Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();
        private readonly int ANCChangeNumber;

        private readonly DataTable USE = new DataTable();
        private readonly DataTable BU = new DataTable();
        private readonly DataTable EA1 = new DataTable();
        private readonly DataTable EA2 = new DataTable();
        private readonly DataTable EA3 = new DataTable();

        private readonly Dictionary<string, int> Month = new Dictionary<string, int>()
        {
            {"January", 1},
            {"February", 2},
            {"March", 3},
            {"April", 4},
            {"May", 5},
            {"June",6},
            {"July", 7},
            {"August",8},
            {"September",9},
            {"October",10},
            {"November",11},
            {"December",12},
        };

        public SaveAction(int ANCChangeNumber, Dictionary<string, string> IDCODictionary, DataTable USE, DataTable BU, DataTable EA1, DataTable EA2, DataTable EA3)
        {
            this.ANCChangeNumber = ANCChangeNumber;
            this.IDCODictionary = IDCODictionary;
            this.USE = USE;
            this.EA1 = EA1;
            this.EA2 = EA2;
            this.EA3 = EA3;
            this.BU = BU;
        }

        public bool Save(bool NewAction, Dictionary<string, string> IDCO)
        {
            bool IfSave;

            IfSave = ActionSave(NewAction);
            IDCODictionary = IDCO;

            return IfSave;
        }

        private bool ActionSave(bool NewAction)
        {
            DataTable ActionList;
            DataRow[] TableRow;
            DataRow NewRow = null;
            string NameAction;
            string NameAction2;
            decimal Year;
            bool New_Year = false;


            ActionList = LoadActionTable();

            Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value;

            if (NewAction)
            {

                NameAction = ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text;
                NameAction = NameAction.Replace(";", ",");
                bool NameExist = CheckIfActionNameExist(NameAction, ref ActionList);
                if (NameExist)
                {
                    MessageBox.Show("Please change Action Name, current Name Exist in DataBase");
                    return false;
                }
                else
                {
                    NewRow = ActionList.NewRow();
                }
            }
            else
            {
                NameAction = ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ActiveAction", true).First()).Text;
                NameAction = NameAction.Replace(";", ",");

                NameAction2 = ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Name", true).First()).Text;
                NameAction2 = NameAction2.Replace(";", ",");

                TableRow = ActionList.Select(string.Format("Name LIKE '%{0}%'", NameAction)).ToArray();
                foreach (DataRow Row in TableRow.Take(TableRow.Length))
                {
                    if (Row["StartYear"].ToString() == Year.ToString() && Row["Name"].ToString() == NameAction2)
                    {
                        NewRow = Row;
                    }
                    else if (Row["StartYear"].ToString() == (Year - 1).ToString() && Row["Name"].ToString() == NameAction2)
                    {
                        //NewRow = Row;
                        if (Year.ToString() != Row["StartYear"].ToString())
                        {
                            if (GridCheck(decimal.Parse(Row["StartYear"].ToString())))
                            {
                                //TableRow = ActionList.Select(string.Format("Name LIKE '%{0}%'", NameAction)).ToArray();
                                //foreach (DataRow Row2 in TableRow.Take(TableRow.Length))
                                //{
                                //if (Row["Name"].ToString() == NameAction)
                                //{
                                Row["StartYear"] = "BU/" + Row["StartYear"].ToString();
                                //}
                                //}

                                NewRow = ActionList.NewRow();
                                New_Year = true;
                            }
                            else
                            {
                                NewRow = Row;
                            }
                        }
                        else
                        {
                            NewRow = Row;
                        }
                    }
                }

                if (NewRow == null)
                {
                    if (NameAction != NameAction2)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want change Action Name for this Action?", "Change Action Name", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Action will be save with Old Name");
                        }
                        else if (dialogResult == DialogResult.Yes)
                        {
                            bool NameExist = CheckIfActionNameExist(NameAction2, ref ActionList);

                            if (NameExist)
                            {
                                MessageBox.Show("Name Exist in Data Base, please change Action Name");
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("Action will be Save with New Name");
                                TableRow = ActionList.Select(string.Format("Name LIKE '%{0}%'", NameAction)).ToArray();


                                foreach (DataRow Row in TableRow.Take(TableRow.Length))
                                {
                                    if (Row["StartYear"].ToString() == Year.ToString() && Row["Name"].ToString() == NameAction)
                                    {
                                        NewRow = Row;
                                    }
                                    else if (Row["StartYear"].ToString() == (Year - 1).ToString() && Row["Name"].ToString() == NameAction)
                                    {
                                        NewRow = Row;
                                    }
                                }
                                NameAction = NameAction2;
                                ((GroupBox)MainProgram.Self.TabControl.Controls.Find("gb_ActiveAction", true).First()).Text = NameAction2;
                            }
                        }
                    }
                    //else
                    //{
                    //    if (Year.ToString() != NewRow["StartYear"].ToString())
                    //    {
                    //        if (GridCheck(decimal.Parse(NewRow["StartYear"].ToString())))
                    //        {
                    //            TableRow = ActionList.Select(string.Format("Name LIKE '%{0}%'", NameAction)).ToArray();
                    //            foreach (DataRow Row in TableRow.Take(TableRow.Length))
                    //            {
                    //                if(Row["Name"].ToString() == NameAction)
                    //                {
                    //                    Row["StartYear"] = "BU/" + NewRow["StartYear"].ToString();
                    //                }
                    //            }

                    //            NewRow = ActionList.NewRow();
                    //            New_Year = true;
                    //        }
                    //    }
                    //}
                }
            }


            NewRow["Name"] = NameAction;

            NewRow["Description"] = ActionDescription();

            NewRow["Group"] = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Devision", true).First()).Text;
            NewRow["Leader"] = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Leader", true).First()).Text;

            NewRow["Status"] = Active_Idea_Action();

            NewRow["Factory"] = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Factory", true).First()).Text;


            NewRow["StartYear"] = Year.ToString();
            NewRow["StartMonth"] = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Month", true).First()).Text;

            ClearDataforUse(((ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_Month", true).First()).Text);

            NewRow["Platform"] = Platform();

            NewRow["Installation"] = Installation();

            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcANC", true).First()).Checked)
            {
                NewRow["Calculate"] = "ANC";
                ANCSave(ref NewRow);
            }
            else if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcANCby", true).First()).Checked)
            {
                NewRow["Calculate"] = "ANCSpec";
                ANCSave(ref NewRow);
                NewRow["Calc"] = ANCCalcby();
                NewRow["CalcMass"] = ANCCalcbyMass();
            }
            else if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNC", true).First()).Checked)
            {
                NewRow["Calculate"] = "PNC";
                ANCSave(ref NewRow);
                NewRow["PNC"] = PNCReader();
            }
            else if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked)
            {
                NewRow["Calculate"] = "PNCSpec";
                ANCSave(ref NewRow);
                PNCSpecReader(ref NewRow);
                NewRow["PNCEstyma"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_EstymacjaPNC", true).First()).Text;
            }

            NewRow["PNCANCPersent"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text;

            NewRow["ECCC"] = ECCCReader(NewRow["ECCC"].ToString());

            string[] GridValue;

            //Quantity
            DataGridView Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_Quantity", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "Quantity", Year);

            //Saving
            Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_Saving", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "Saving", Year);

            //ECCC
            Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCC", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "ECCC", Year);

            //Sprawdzenie czy to jest Akcja dodatnia czy ujemna
            PozitiveOrNegative(ref NewRow);

            //Sprawdzenie czy jakiś Calc jest nie wpisany - jak nie jest to ma zamienić na same "//////////////"
            IfEmptyCalc(ref NewRow);

            //Dodanie IDCO do pliku
            IDCOAdd(ref NewRow);

            //Zapis kalkulacji poszczególych ANC?PNC
            PerANC_PNC(ref NewRow, Year);

            //Jesli zmienił się rok to ma do gridów wpisać puste warości
            if (New_Year)
            {
                Calc_Clear(ref NewRow, "Quantity");
                Calc_Clear(ref NewRow, "Saving");
                Calc_Clear(ref NewRow, "ECCC");
                Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_Quantity", true).First();
                Grid_Clear(Grid);
                Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_Saving", true).First();
                Grid_Clear(Grid);
                Grid = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_ECCC", true).First();
                Grid_Clear(Grid);
                //NewRow["IDCO"] = "";
            }


            //Jeśli to była nowa akcja to dodaje wiersz
            if (NewAction || New_Year)
            {
                ActionList.Rows.Add(NewRow);
            }


            //Zapis do pliku
            Data_Import.Singleton().Save_DataTableToTXT2(ref ActionList, "Action");

            return true;
        }

        private void ClearDataforUse(string MonthStart)
        {
            int StartCalc = Month[MonthStart];
            for (int counter = 1; counter < StartCalc; counter++)
            {
                foreach (DataRow Row in USE.Rows)
                {
                    Row[counter.ToString()] = "";    
                }
            }
        }

        //Sprawdzenie czy akcja jest dodatnia czy ujemna
        private void PozitiveOrNegative(ref DataRow NewRow)
        {
            decimal Delta = decimal.Parse(((Label)MainProgram.Self.TabControl.Controls.Find("lab_CalcSum", true).First()).Text);
            if (Delta >= 0)
            {
                NewRow["+ czy -"] = "Pozytywna";
            }
            else
            {
                NewRow["+ czy -"] = "Negatywna";
            }
        }

        private void PerANC_PNC(ref DataRow NewRow, decimal Year)
        {
            string Carry = "";
            string Save = "";
            decimal YearCalc = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;

            if (Year == YearCalc - 1)
                Carry = "Carry";

            if (USE != null)
            {
                foreach (DataRow Row in USE.Rows)
                {
                    for (int counter = 0; counter < USE.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save += "/";
                }
                NewRow["PerUSE" + Carry] = Save;
                Save = "";
            }

            if (BU != null)
            {
                foreach (DataRow Row in BU.Rows)
                {
                    for (int counter = 0; counter < BU.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save += "/";
                }
                NewRow["PerBU" + Carry] = Save;
                Save = "";
            }

            if (EA1 != null)
            {
                foreach (DataRow Row in EA1.Rows)
                {
                    for (int counter = 0; counter < EA1.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save += "/";
                }
                NewRow["PerEA1" + Carry] = Save;
                Save = "";
            }

            if (EA2 != null)
            {
                foreach (DataRow Row in EA2.Rows)
                {
                    for (int counter = 0; counter < EA2.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save += "/";
                }
                NewRow["PerEA2" + Carry] = Save;
                Save = "";
            }

            if (EA3 != null)
            {
                foreach (DataRow Row in EA3.Rows)
                {
                    for (int counter = 0; counter < EA3.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save += "/";
                }
                NewRow["PerEA3" + Carry] = Save;
            }
        }

        //LoadAction Table
        private DataTable LoadActionTable()
        {
            DataTable ActionList = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref ActionList, "Action");

            return ActionList;
        }

        //Sprawdzenie czy dana nazwa akcji istnieje w tabeli
        private bool CheckIfActionNameExist(string Name, ref DataTable ActionList)
        {
            bool NameExist = false;
            DataRow[] CheckName = ActionList.Select(string.Format("Name LIKE '%{0}%'", Name)).ToArray();

            foreach (DataRow Row in CheckName.Take(CheckName.Length))
            {
                if (Name == Row["Name"].ToString())
                {
                    NameExist = true;
                }
            }

            return NameExist;
        }

        //Wyciąga i przetwarza Description do wyświetlanej akcji
        private string ActionDescription()
        {
            string Description;

            Description = ((TextBox)MainProgram.Self.TabControl.Controls.Find("tb_Description", true).First()).Text;
            Description = Description.Replace(Environment.NewLine, "/n");
            Description = Description.Replace(";", ",");

            return Description;
        }

        //Sprawdzenie czy Akcja jest w statusie Active czy Idea
        private string Active_Idea_Action()
        {
            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Active", true).First()).Checked)
            {
                return "Active";
            }
            else if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Idea", true).First()).Checked)
            {
                return "Idea";
            }
            return "";
        }

        //Na jakie platformy jest akcja
        private string Platform()
        {
            string What = "";

            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_DMD", true).First()).Checked)
            {
                What += "DMD";
            }
            What += "/";
            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_D45", true).First()).Checked)
            {
                What += "D45";
            }
            What += "/";

            return What;
        }

        //Jakie Instalacje są uwzględnione w akcji
        private string Installation()
        {
            string What = "";

            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_InstallAll", true).First()).Checked)
            {
                What = "FS/FI/BI/BU/FSBU/";
            }
            else
            {
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FS", true).First()).Checked)
                {
                    What += "FS";
                }
                What += "/";
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FI", true).First()).Checked)
                {
                    What += "FI";
                }
                What += "/";
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_BI", true).First()).Checked)
                {
                    What += "BI";
                }
                What += "/";
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_BU", true).First()).Checked)
                {
                    What += "BU";
                }
                What += "/";
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_FSBU", true).First()).Checked)
                {
                    What += "FSBU";
                }
                What += "/";
            }

            return What;
        }

        //Zapis ANC które są wpisane w akcji
        private void ANCSave(ref DataRow ActionRow)
        {
            string OldANC = "";
            string OldANCQ = "";
            string NewANC = "";
            string NewANCQ = "";
            string OldSTK = "";
            string NewSTK = "";
            string Delta = "";
            string STKEstym = "";
            string Percent = "";
            string STKCalc = "";
            string NextANC = "";

            ActionRow["IloscANC"] = ANCChangeNumber;

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                TextBox nTB_OLDANC = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_OldANC" + (counter).ToString(), true).First();
                OldANC = OldANC + nTB_OLDANC.Text + "|";

                TextBox nTB_OLDANCQ = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_OldANCQ" + (counter).ToString(), true).First();
                OldANCQ = OldANCQ + nTB_OLDANCQ.Text + "|";

                TextBox nTB_NEWANC = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_NewANC" + (counter).ToString(), true).First();
                NewANC = NewANC + nTB_NEWANC.Text + "|";

                TextBox nTB_NEWANCQ = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_NewANCQ" + (counter).ToString(), true).First();
                NewANCQ = NewANCQ + nTB_NEWANCQ.Text + "|";

                Label nLab_OldStk = (Label)MainProgram.Self.TabControl.Controls.Find("lab_OldSTK" + (counter).ToString(), true).First();
                OldSTK = OldSTK + nLab_OldStk.Text + "|";

                Label nLab_NewSTK = (Label)MainProgram.Self.TabControl.Controls.Find("lab_NewSTK" + (counter).ToString(), true).First();
                NewSTK = NewSTK + nLab_NewSTK.Text + "|";

                Label nLab_Delta = (Label)MainProgram.Self.TabControl.Controls.Find("lab_Delta" + (counter).ToString(), true).First();
                Delta = Delta + nLab_Delta.Text + "|";

                TextBox nTB_Estymacja = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Estymacja" + (counter).ToString(), true).First();
                STKEstym = STKEstym + nTB_Estymacja.Text + "|";

                TextBox nTB_Percent = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_Percent" + (counter).ToString(), true).First();
                Percent = Percent + nTB_Percent.Text + "|";

                Label nTB_Calc = (Label)MainProgram.Self.TabControl.Controls.Find("Lab_Calc" + (counter).ToString(), true).First();
                STKCalc = STKCalc + nTB_Calc.Text + "|";

                TextBox nTB_NextANC = (TextBox)MainProgram.Self.TabControl.Controls.Find("TB_NextANC" + (counter).ToString(), true).First();
                NextANC = NextANC + nTB_NextANC.Text + "|";
            }

            ActionRow["Old ANC"] = OldANC;
            ActionRow["Old ANCQ"] = OldANCQ;
            ActionRow["New ANC"] = NewANC;
            ActionRow["New ANCQ"] = NewANCQ;
            ActionRow["Old STK"] = OldSTK;
            ActionRow["New STK"] = NewSTK;
            ActionRow["Delta"] = Delta;
            ActionRow["STKEst"] = STKEstym;
            ActionRow["Percent"] = Percent;
            ActionRow["STKCal"] = STKCalc;
            ActionRow["Next"] = NextANC;
        }

        //Odczyt które ANC jest brane pod uwagę przy ANC Spec
        private string ANCCalcby()
        {
            string Calcby = "";

            for (int counter = 1; counter <= ANCChangeNumber; counter++)
            {
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ANCby" + counter.ToString(), true).First()).Checked)
                {
                    Calcby += "true";
                }
                Calcby += "|";
            }
            return Calcby;
        }

        //Odczyt jak jest masowe liczenie 
        private string ANCCalcbyMass()
        {
            string Results = "";
            CheckBox DMD_FS = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD_FS", true).First();
            CheckBox DMD_FI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD_FI", true).First();
            CheckBox DMD_BI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD_BI", true).First();
            CheckBox DMD_FSBU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD_FSBU", true).First();
            CheckBox D45_FS = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45_FS", true).First();
            CheckBox D45_FI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45_FI", true).First();
            CheckBox D45_BI = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45_BI", true).First();
            CheckBox D45_FSBU = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45_FSBU", true).First();
            CheckBox DMD = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_DMD", true).First();
            CheckBox D45 = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_D45", true).First();
            CheckBox All = (CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Mass_All", true).First();

            if (All.Checked)
                Results += "All";
            Results += "/";
            if (DMD.Checked)
                Results += "DMD";
            Results += "/";
            if (D45.Checked)
                Results += "D45";
            Results += "/";
            if (DMD_FS.Checked)
                Results += "DMD_FS";
            Results += "/";
            if (DMD_FI.Checked)
                Results += "DMD_FI";
            Results += "/";
            if (DMD_BI.Checked)
                Results += "DMD_BI";
            Results += "/";
            if (DMD_FSBU.Checked)
                Results += "DMD_FSBU";
            Results += "/";
            if (D45_FS.Checked)
                Results += "D45_FS";
            Results += "/";
            if (D45_FI.Checked)
                Results += "D45_FI";
            Results += "/";
            if (D45_BI.Checked)
                Results += "D45_BI";
            Results += "/";
            if (D45_FSBU.Checked)
                Results += "D45_FSBU";
            Results += "/";


            return Results;
        }


        //Odczytaj PNc które były użyte w akcji
        private string PNCReader()
        {
            string PNC = "";
            DataGridView DG = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();

            for (int counter = 0; counter < DG.Rows.Count; counter++)
            {
                PNC = PNC + DG.Rows[counter].Cells[0].Value.ToString() + "|";
            }

            return PNC;
        }

        //Odczyt PNCSpec dla wszystkich PNC które biorą udziała w Akcji
        private void PNCSpecReader(ref DataRow ActionRow)
        {
            DataGridView DG = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First();
            string PNC = "";
            string PNCSumSTK = "";
            string PNCSumDelta = "";
            string ECCC = "";
            string PNCANC = "";
            string PNCSTK = "";
            string PNCDelta = "";
            string PNCANCQ = "";


            foreach (DataGridViewRow PNCRow in DG.Rows)
            {
                if (PNCRow.Index < (((DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count))
                {
                    if (PNCRow.Cells["PNC"].Value != null && PNCRow.Cells["PNC"].Value.ToString() != "")
                    {
                        PNC = PNC + PNCRow.Cells[0].Value.ToString() + "|";
                        PNCSumSTK = PNCSumSTK + PNCRow.Cells[5].Value.ToString() + ":" + PNCRow.Cells[6].Value.ToString() + "|";
                        PNCSumDelta = PNCSumDelta + PNCRow.Cells[7].Value.ToString() + "|";
                        if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked)
                        {
                            string ECCCtemp = (PNCRow.Cells[1].Value.ToString()).Remove(0, 5);
                            ECCC = ECCC + ECCCtemp.Remove(ECCCtemp.Length - 1, 1) + "|";
                        }

                        if (PNCANC != "")
                        {
                            PNCANC += "|";
                            PNCSTK += "|";
                            PNCDelta += "|";
                            PNCANCQ += "|";
                        }
                    }
                    else
                    {
                        PNCANC = PNCANC + PNCRow.Cells[1].Value.ToString() + ":" + PNCRow.Cells[3].Value.ToString() + "/";
                        PNCANCQ = PNCANCQ + PNCRow.Cells[2].Value.ToString() + ":" + PNCRow.Cells[4].Value.ToString() + "/";
                        PNCSTK = PNCSTK + PNCRow.Cells[5].Value.ToString() + ":" + PNCRow.Cells[6].Value.ToString() + "/";
                        PNCDelta = PNCDelta + PNCRow.Cells[7].Value.ToString() + "/";
                    }
                }
            }
            ActionRow["PNC"] = PNC;
            ActionRow["PNC/ANC"] = PNCANC + "|";
            ActionRow["PNC/ANC Q"] = PNCANCQ + "|";
            ActionRow["PNCSTK"] = PNCSTK + "|";
            ActionRow["PNCDelta"] = PNCDelta + "|";
            ActionRow["PNCSumSTK"] = PNCSumSTK;
            ActionRow["PNCSumDelta"] = PNCSumDelta;
            ActionRow["ECCC"] = ECCC;
        }

        //Odczyt ECCC jeśli w PNCSpecReader jest PNC 
        private string ECCCReader(string ECCCell)
        {
            string ECCC;

            if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCC", true).First()).Checked)
            {
                if (((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked)
                {
                    ECCC = ECCCell;
                }
                else
                {
                    ECCC = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_ECCC", true).First()).Value.ToString();
                }
            }
            else
            {
                ECCC = "";
            }
            return ECCC;
        }

        //Odzczyt Gridów z Quantity, Saving, ECCC
        private string[] GridReader(DataGridView DG)
        {
            string[] Grid = new string[5] { "", "", "", "", "" };

            for (int Row = 0; Row < 5; Row++)
            {
                for (int Column = 0; Column < 13; Column++)
                {
                    if (DG.Rows[Row].Cells[Column].Value != null && DG.Rows[Row].Cells[Column].Value.ToString() != "")
                    {
                        Grid[Row] = Grid[Row] + DG.Rows[Row].Cells[Column].Value.ToString() + "/";
                    }
                    else
                    {
                        Grid[Row] = Grid[Row] + "/";
                    }
                }
            }

            return Grid;
        }

        //Zapis Gridów do tabeli
        private void GridSave(ref DataRow ActionRow, string[] GridValue, string Column, decimal Year)
        {
            decimal YearSave = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;
            if (Year == YearSave)
            {
                ActionRow["CalcBU" + Column] = GridValue[4];
                ActionRow["CalcEA1" + Column] = GridValue[3];
                ActionRow["CalcEA2" + Column] = GridValue[2];
                ActionRow["CalcEA3" + Column] = GridValue[1];
                ActionRow["CalcUSE" + Column] = GridValue[0];
                //ActionRow["CalcBU" + Column + "Carry"] = "/////////////";
                //ActionRow["CalcEA1" + Column + "Carry"] = "/////////////";
                //ActionRow["CalcEA2" + Column + "Carry"] = "/////////////";
                //ActionRow["CalcEA3" + Column + "Carry"] = "/////////////";
                //ActionRow["CalcUSE" + Column + "Carry"] = "/////////////";
            }
            else if (Year == YearSave - 1)
            {
                ActionRow["CalcBU" + Column + "Carry"] = GridValue[4];
                ActionRow["CalcEA1" + Column + "Carry"] = GridValue[3];
                ActionRow["CalcEA2" + Column + "Carry"] = GridValue[2];
                ActionRow["CalcEA3" + Column + "Carry"] = GridValue[1];
                ActionRow["CalcUSE" + Column + "Carry"] = GridValue[0];
            }
        }

        //Sprawdzenie czy dla gridów nie ma pustego pola jak jest to ma wypełnić "////////////"
        private void IfEmptyCalc(ref DataRow ActionRow)
        {
            string Carry = "";
            for (int counter = 0; counter <= 1; counter++)
            {
                if (ActionRow["CalcBUSaving" + Carry].ToString() == "")
                    ActionRow["CalcBUSaving" + Carry] = "/////////////";
                if (ActionRow["CalcEA1Saving" + Carry].ToString() == "")
                    ActionRow["CalcEA1Saving" + Carry] = "/////////////";
                if (ActionRow["CalcEA2Saving" + Carry].ToString() == "")
                    ActionRow["CalcEA2Saving" + Carry] = "/////////////";
                if (ActionRow["CalcEA3Saving" + Carry].ToString() == "")
                    ActionRow["CalcEA3Saving" + Carry] = "/////////////";
                if (ActionRow["CalcUSESaving" + Carry].ToString() == "")
                    ActionRow["CalcUSESaving" + Carry] = "/////////////";
                if (ActionRow["CalcBUQuantity" + Carry].ToString() == "")
                    ActionRow["CalcBUQuantity" + Carry] = "/////////////";
                if (ActionRow["CalcEA1Quantity" + Carry].ToString() == "")
                    ActionRow["CalcEA1Quantity" + Carry] = "/////////////";
                if (ActionRow["CalcEA2Quantity" + Carry].ToString() == "")
                    ActionRow["CalcEA2Quantity" + Carry] = "/////////////";
                if (ActionRow["CalcEA3Quantity" + Carry].ToString() == "")
                    ActionRow["CalcEA3Quantity" + Carry] = "/////////////";
                if (ActionRow["CalcUSEQuantity" + Carry].ToString() == "")
                    ActionRow["CalcUSEQuantity" + Carry] = "/////////////";
                if (ActionRow["CalcBUECCC" + Carry].ToString() == "")
                    ActionRow["CalcBUECCC" + Carry] = "/////////////";
                if (ActionRow["CalcEA1ECCC" + Carry].ToString() == "")
                    ActionRow["CalcEA1ECCC" + Carry] = "/////////////";
                if (ActionRow["CalcEA2ECCC" + Carry].ToString() == "")
                    ActionRow["CalcEA2ECCC" + Carry] = "/////////////";
                if (ActionRow["CalcEA3ECCC" + Carry].ToString() == "")
                    ActionRow["CalcEA3ECCC" + Carry] = "/////////////";
                if (ActionRow["CalcUSEECCC" + Carry].ToString() == "")
                    ActionRow["CalcUSEECCC" + Carry] = "/////////////";
                Carry = "Carry";
            }
        }

        //Sprawdzenie czy w Gridach jest coś zapisane już 
        private bool GridCheck(decimal Year)
        {
            bool Grid = false;
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            DataGridView Table_Check = (DataGridView)MainProgram.Self.TabControl.Controls.Find("dg_Saving", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (FrozenRow == null)
            {
                return Grid;
            }


            for (int Row = 0; Row < 5; Row++)
            {
                for (int Column = 0; Column < 13; Column++)
                {
                    if (Table_Check.Rows[Row].Cells[Column] != null && Table_Check.Rows[Row].Cells[Column].ToString() != "")
                    {
                        if (Row == 1)
                        {
                            if (FrozenRow["EA3"].ToString() == "Approve")
                            {
                                Grid = true;
                                return Grid;
                            }
                        }
                        else if (Row == 2)
                        {
                            if (FrozenRow["EA2"].ToString() == "Approve")
                            {
                                Grid = true;
                                return Grid;
                            }
                        }
                        else if (Row == 3)
                        {
                            if (FrozenRow["EA1"].ToString() == "Approve")
                            {
                                Grid = true;
                                return Grid;
                            }
                        }
                        else if (Row == 4)
                        {
                            if (FrozenRow["BU"].ToString() == "Approve")
                            {
                                Grid = true;
                                return Grid;
                            }
                        }
                        else
                        {
                            if (FrozenRow[(Column + 1).ToString()].ToString() == "Approve")
                            {
                                Grid = true;
                                return Grid;
                            }
                        }
                    }
                }
            }

            return Grid;
        }

        //Zapis IDCO do Akcji 
        private void IDCOAdd(ref DataRow ActionRow)
        {
            string IDCO = "";

            foreach (KeyValuePair<string, string> DictionaryValue in IDCODictionary)
            {
                IDCO = IDCO + DictionaryValue.Key + "|" + DictionaryValue.Value + "/";
            }

            ActionRow["IDCO"] = IDCO;
        }

        //Czyszczenie Komórek w tablicy do Gridów jeśli jest nowy rok dla akcji 
        private void Calc_Clear(ref DataRow ActionRow, string Column)
        {
            ActionRow["CalcBU" + Column] = "/////////////";
            ActionRow["CalcEA1" + Column] = "/////////////";
            ActionRow["CalcEA2" + Column] = "/////////////";
            ActionRow["CalcEA3" + Column] = "/////////////";
            ActionRow["CalcUSE" + Column] = "/////////////";
            ActionRow["CalcBU" + Column + "Carry"] = "/////////////";
            ActionRow["CalcEA1" + Column + "Carry"] = "/////////////";
            ActionRow["CalcEA2" + Column + "Carry"] = "/////////////";
            ActionRow["CalcEA3" + Column + "Carry"] = "/////////////";
            ActionRow["CalcUSE" + Column + "Carry"] = "/////////////";
        }

        //Czyszczenie Gridów wyświetlanych, bo jest to nowa akcja
        private void Grid_Clear(DataGridView DG)
        {
            for (int Row = 0; Row < 5; Row++)
            {
                for (int Column = 0; Column < 13; Column++)
                {
                    DG.Rows[Row].Cells[Column].Value = null;
                }
            }
        }
    }
}
