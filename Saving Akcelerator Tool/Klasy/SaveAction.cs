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
        MainProgram mainProgram;
        Data_Import ImportData;
        Dictionary<string, string> IDCODictionary = new Dictionary<string, string>();
        readonly int ANCChangeNumber;

        DataTable USE = new DataTable();
        DataTable BU = new DataTable();
        DataTable EA1 = new DataTable();
        DataTable EA2 = new DataTable();
        DataTable EA3 = new DataTable();

        public SaveAction(MainProgram mainProgram, Data_Import ImportData, int ANCChangeNumber, Dictionary<string, string> IDCODictionary, DataTable USE, DataTable BU, DataTable EA1, DataTable EA2, DataTable EA3)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
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
            bool IfSave = false;

            IfSave = ActionSave(NewAction);
            IDCODictionary = IDCO;

            return IfSave;
        }

        private bool ActionSave(bool NewAction)
        {
            DataTable ActionList = new DataTable();
            DataRow[] TableRow;
            DataRow NewRow = null;
            string NameAction;
            string NameAction2;
            decimal Year;
            bool New_Year = false;



            ActionList = LoadActionTable();

            Year = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearAction", true).First()).Value;

            if (NewAction)
            {

                NameAction = ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text;
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
                NameAction = ((GroupBox)mainProgram.TabControl.Controls.Find("gb_ActiveAction", true).First()).Text;
                NameAction = NameAction.Replace(";", ",");

                NameAction2 = ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text;
                NameAction2 = NameAction.Replace(";", ",");

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

                if (NewRow != null)
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
                            bool NameExist = CheckIfActionNameExist(NameAction, ref ActionList);

                            if (NameExist)
                            {
                                MessageBox.Show("Name Exist in Data Base, please change Action Name");
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("Action will be Save with New Name");
                                NameAction = ((TextBox)mainProgram.TabControl.Controls.Find("tb_Name", true).First()).Text;
                            }
                        }
                    }
                    else
                    {
                        if (Year.ToString() != NewRow["StartYear"].ToString())
                        {
                            if (GridCheck())
                            {
                                NewRow["StartYear"] = "BU/" + NewRow["StartYear"].ToString();
                                NewRow = ActionList.NewRow();
                                New_Year = true;
                            }
                        }
                    }
                }
            }


            NewRow["Name"] = NameAction;

            NewRow["Description"] = ActionDescription();

            NewRow["Group"] = ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Devision", true).First()).Text;
            NewRow["Leader"] = ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Leader", true).First()).Text;

            NewRow["Status"] = Active_Idea_Action();

            NewRow["Factory"] = ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Factory", true).First()).Text;


            NewRow["StartYear"] = Year.ToString();
            NewRow["StartMonth"] = ((ComboBox)mainProgram.TabControl.Controls.Find("comBox_Month", true).First()).Text;

            NewRow["Platform"] = Platform();

            NewRow["Installation"] = Installation();

            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANC", true).First()).Checked)
            {
                NewRow["Calculate"] = "ANC";
                ANCSave(ref NewRow);
            }
            else if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcANCby", true).First()).Checked)
            {
                NewRow["Calculate"] = "ANCSpec";
                ANCSave(ref NewRow);
                NewRow["Calc"] = ANCCalcby();
            }
            else if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNC", true).First()).Checked)
            {
                NewRow["Calculate"] = "PNC";
                ANCSave(ref NewRow);
                NewRow["PNC"] = PNCReader();
            }
            else if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_CalcPNCSpec", true).First()).Checked)
            {
                NewRow["Calculate"] = "PNCSpec";
                ANCSave(ref NewRow);
                PNCSpecReader(ref NewRow);
                NewRow["PNCEstyma"] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_EstymacjaPNC", true).First()).Text;
            }

            NewRow["PNCANCPersent"] = ((TextBox)mainProgram.TabControl.Controls.Find("TB_PercentANCPNC", true).First()).Text;

            NewRow["ECCC"] = ECCCReader(NewRow["ECCC"].ToString());

            string[] GridValue = new string[5];

            //Quantity
            DataGridView Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "Quantity", Year);

            //Saving
            Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "Saving", Year);

            //ECCC
            Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();
            GridValue = GridReader(Grid);
            GridSave(ref NewRow, GridValue, "ECCC", Year);

            //Sprawdzenie czy to jest Akcja dodatnia czy ujemna
            PozitiveOrNegative(ref NewRow);

            //Dodanie IDCO do pliku
            IDCOAdd(ref NewRow);

            //Zapis kalkulacji poszczególych ANC?PNC
            PerANC_PNC(ref NewRow,Year);

            //Jesli zmienił się rok to ma do gridów wpisać puste warości
            if (New_Year)
            {
                Calc_Clear(ref NewRow, "Quantity");
                Calc_Clear(ref NewRow, "Saving");
                Calc_Clear(ref NewRow, "ECCC");
                Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Quantity", true).First();
                Grid_Clear(Grid);
                Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();
                Grid_Clear(Grid);
                Grid = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCC", true).First();
                Grid_Clear(Grid);
                NewRow["IDCO"] = "";
            }


            //Jeśli to była nowa akcja to dodaje wiersz
            if (NewAction)
            {
                ActionList.Rows.Add(NewRow);
            }

            //Zapis do pliku
            string LinkAction = ImportData.Load_Link("Action");
            ImportData.Save_DataTableToTXT(ref ActionList, LinkAction);

            return true;
        }

        //Sprawdzenie czy akcja jest dodatnia czy ujemna
        private void PozitiveOrNegative( ref DataRow NewRow)
        {
            decimal Delta = decimal.Parse(((Label)mainProgram.TabControl.Controls.Find("lab_CalcSum", true).First()).Text); 
            if(Delta >=0)
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
            decimal YearCalc = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;

            if (Year == YearCalc -1)
                Carry = "Carry";

            if (USE!= null)
            {
                foreach (DataRow Row in USE.Rows)
                {
                    for (int counter = 0; counter < USE.Columns.Count; counter++)
                    {
                        Save = Save + Row[counter].ToString() + "|";
                    }
                    Save = Save + "/";
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
                    Save = Save + "/";
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
                    Save = Save + "/";
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
                    Save = Save + "/";
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
                    Save = Save + "/";
                }
                NewRow["PerEA3" + Carry] = Save;
            }
        }

        //LoadAction Table
        private DataTable LoadActionTable()
        {
            DataTable ActionList = new DataTable();
            string LinkAction;

            LinkAction = ImportData.Load_Link("Action");
            ImportData.Load_TxtToDataTable(ref ActionList, LinkAction);

            return ActionList;
        }

        //Sprawdzenie czy dana nazwa akcji istnieje w tabeli
        private bool CheckIfActionNameExist(string Name, ref DataTable ActionList)
        {
            DataRow CheckName = ActionList.Select(string.Format("Name LIKE '%{0}%'", Name)).FirstOrDefault();

            if (CheckName == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Wyciąga i przetwarza Description do wyświetlanej akcji
        private string ActionDescription()
        {
            string Description;

            Description = ((TextBox)mainProgram.TabControl.Controls.Find("tb_Description", true).First()).Text;
            Description = Description.Replace(Environment.NewLine, "/n");
            Description = Description.Replace(";", ",");

            return Description;
        }

        //Sprawdzenie czy Akcja jest w statusie Active czy Idea
        private string Active_Idea_Action()
        {
            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Active", true).First()).Checked)
            {
                return "Active";
            }
            else if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_Idea", true).First()).Checked)
            {
                return "Idea";
            }
            return "";
        }

        //Na jakie platformy jest akcja
        private string Platform()
        {
            string What = "";

            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_DMD", true).First()).Checked)
            {
                What = What + "DMD";
            }
            What = What + "/";
            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_D45", true).First()).Checked)
            {
                What = What + "D45";
            }
            What = What + "/";

            return What;
        }

        //Jakie Instalacje są uwzględnione w akcji
        private string Installation()
        {
            string What = "";

            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_InstallAll", true).First()).Checked)
            {
                What = "FS/FI/BI/BU/FSBU/";
            }
            else
            {
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_FS", true).First()).Checked)
                {
                    What = What + "FS";
                }
                What = What + "/";
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_FI", true).First()).Checked)
                {
                    What = What + "FI";
                }
                What = What + "/";
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_BI", true).First()).Checked)
                {
                    What = What + "BI";
                }
                What = What + "/";
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_BU", true).First()).Checked)
                {
                    What = What + "BU";
                }
                What = What + "/";
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_FSBU", true).First()).Checked)
                {
                    What = What + "FSBU";
                }
                What = What + "/";
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
                TextBox nTB_OLDANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANC" + (counter).ToString(), true).First();
                OldANC = OldANC + nTB_OLDANC.Text + "|";

                TextBox nTB_OLDANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_OldANCQ" + (counter).ToString(), true).First();
                OldANCQ = OldANCQ + nTB_OLDANCQ.Text + "|";

                TextBox nTB_NEWANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANC" + (counter).ToString(), true).First();
                NewANC = NewANC + nTB_NEWANC.Text + "|";

                TextBox nTB_NEWANCQ = (TextBox)mainProgram.TabControl.Controls.Find("TB_NewANCQ" + (counter).ToString(), true).First();
                NewANCQ = NewANCQ + nTB_NEWANCQ.Text + "|";

                Label nLab_OldStk = (Label)mainProgram.TabControl.Controls.Find("lab_OldSTK" + (counter).ToString(), true).First();
                OldSTK = OldSTK + nLab_OldStk.Text + "|";

                Label nLab_NewSTK = (Label)mainProgram.TabControl.Controls.Find("lab_NewSTK" + (counter).ToString(), true).First();
                NewSTK = NewSTK + nLab_NewSTK.Text + "|";

                Label nLab_Delta = (Label)mainProgram.TabControl.Controls.Find("lab_Delta" + (counter).ToString(), true).First();
                Delta = Delta + nLab_Delta.Text + "|";

                TextBox nTB_Estymacja = (TextBox)mainProgram.TabControl.Controls.Find("TB_Estymacja" + (counter).ToString(), true).First();
                STKEstym = STKEstym + nTB_Estymacja.Text + "|";

                TextBox nTB_Percent = (TextBox)mainProgram.TabControl.Controls.Find("TB_Percent" + (counter).ToString(), true).First();
                Percent = Percent + nTB_Percent.Text + "|";

                Label nTB_Calc = (Label)mainProgram.TabControl.Controls.Find("Lab_Calc" + (counter).ToString(), true).First();
                STKCalc = STKCalc + nTB_Calc.Text + "|";

                TextBox nTB_NextANC = (TextBox)mainProgram.TabControl.Controls.Find("TB_NextANC" + (counter).ToString(), true).First();
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
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_ANCby" + counter.ToString(), true).First()).Checked)
                {
                    Calcby = Calcby + "true";
                }
                Calcby = Calcby + "|";
            }
            return Calcby;
        }

        //Odczytaj PNc które były użyte w akcji
        private string PNCReader()
        {
            string PNC = "";
            DataGridView DG = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();

            for (int counter = 0; counter < DG.Rows.Count; counter++)
            {
                PNC = PNC + DG.Rows[counter].Cells[0].Value.ToString() + "|";
            }

            return PNC;
        }

        //Odczyt PNCSpec dla wszystkich PNC które biorą udziała w Akcji
        private void PNCSpecReader(ref DataRow ActionRow)
        {
            DataGridView DG = (DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First();
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
                if (PNCRow.Index < (((DataGridView)mainProgram.TabControl.Controls.Find("dg_PNC", true).First()).Rows.Count))
                {
                    if (PNCRow.Cells["PNC"].Value != null && PNCRow.Cells["PNC"].Value.ToString() != "")
                    {
                        PNC = PNC + PNCRow.Cells[0].Value.ToString() + "|";
                        PNCSumSTK = PNCSumSTK + PNCRow.Cells[5].Value.ToString() + ":" + PNCRow.Cells[6].Value.ToString() + "|";
                        PNCSumDelta = PNCSumDelta + PNCRow.Cells[7].Value.ToString() + "|";
                        if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked)
                        {
                            string ECCCtemp = (PNCRow.Cells[1].Value.ToString()).Remove(0, 5);
                            ECCC = ECCC + ECCCtemp.Remove(ECCCtemp.Length - 1, 1) + "|";
                        }

                        if (PNCANC != "")
                        {
                            PNCANC = PNCANC + "|";
                            PNCSTK = PNCSTK + "|";
                            PNCDelta = PNCDelta + "|";
                            PNCANCQ = PNCANCQ + "|";
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

            if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCC", true).First()).Checked)
            {
                if (((CheckBox)mainProgram.TabControl.Controls.Find("cb_ECCCSpec", true).First()).Checked)
                {
                    ECCC = ECCCell;
                }
                else
                {
                    ECCC = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_ECCC", true).First()).Value.ToString();
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
            decimal YearSave = ((NumericUpDown)mainProgram.TabControl.Controls.Find("num_Action_YearOption", true).First()).Value;
            if (Year >= YearSave)
            {
                ActionRow["CalcBU" + Column] = GridValue[4];
                ActionRow["CalcEA1" + Column] = GridValue[3];
                ActionRow["CalcEA2" + Column] = GridValue[2];
                ActionRow["CalcEA3" + Column] = GridValue[1];
                ActionRow["CalcUSE" + Column] = GridValue[0];
                ActionRow["CalcBU" + Column + "Carry"] = "/////////////";
                ActionRow["CalcEA1" + Column + "Carry"] = "/////////////";
                ActionRow["CalcEA2" + Column + "Carry"] = "/////////////";
                ActionRow["CalcEA3" + Column + "Carry"] = "/////////////";
                ActionRow["CalcUSE" + Column + "Carry"] = "/////////////";
            }
            else if (Year == YearSave -1)
            {
                ActionRow["CalcBU" + Column + "Carry"] = GridValue[4];
                ActionRow["CalcEA1" + Column + "Carry"] = GridValue[3];
                ActionRow["CalcEA2" + Column + "Carry"] = GridValue[2];
                ActionRow["CalcEA3" + Column + "Carry"] = GridValue[1];
                ActionRow["CalcUSE" + Column + "Carry"] = GridValue[0];
            }
        }

        //Sprawdzenie czy w Gridach jest coś zapisane już 
        private bool GridCheck()
        {
            bool Grid = false;

            DataGridView Table_Check = (DataGridView)mainProgram.TabControl.Controls.Find("dg_Saving", true).First();

            for (int Row = 0; Row < 5; Row++)
            {
                for (int Column = 0; Column < 13; Column++)
                {
                    if (Table_Check.Rows[Row].Cells[Column] != null && Table_Check.Rows[Row].Cells[Column].ToString() != "")
                    {
                        Grid = true;
                        return Grid;
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
