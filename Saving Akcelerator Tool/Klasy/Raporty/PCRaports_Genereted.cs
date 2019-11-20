using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    class PCRaports_Genereted
    {
        MainProgram mainProgram;
        Data_Import data_Import;

        private readonly Dictionary<string, int> MonthStart = new Dictionary<string, int>()
        {
            {"January", 1},
            {"Febuary", 2},
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

        private readonly Dictionary<string, int> RevisionStartMonth = new Dictionary<string, int>()
        {
            {"BU", 1},
            {"EA1", 3},
            {"EA2", 6},
            {"EA3", 9},
        };

        public PCRaports_Genereted(MainProgram mainProgram, Data_Import data_Import)
        {
            this.mainProgram = mainProgram;
            this.data_Import = data_Import;
        }

        public void Genereted_PCRaport()
        {
            System.Data.DataTable ActionList = new System.Data.DataTable();
            System.Data.DataTable NewActionPozitive = new System.Data.DataTable();
            System.Data.DataTable NewActionNegative = new System.Data.DataTable();
            System.Data.DataTable NewActionPozitiveFinish = new System.Data.DataTable();
            System.Data.DataTable NewActionNegativeFinish = new System.Data.DataTable();
            string Link;
            Worksheet worksheet;


            Link = data_Import.Load_Link("Action");
            data_Import.Load_TxtToDataTable(ref ActionList, Link);

            NewActionPozitive = Load_Table(ActionList, "2019", "Pozytywna");
            NewActionNegative = Load_Table(ActionList, "2019", "Negatywna");

            NewActionPozitiveFinish = Prepare_Table(NewActionPozitive);
            NewActionNegativeFinish = Prepare_Table(NewActionNegative);

            Microsoft.Office.Interop.Excel.Application excel;
            Workbook workbook;

            Create_Excel_Application Application = new Create_Excel_Application();
            excel = Application.Create_Application();

            Create_Excel_WorkBooks Workbooks = new Create_Excel_WorkBooks();
            workbook = Workbooks.Create_WorkBooks(excel);

            Create_Excel_WorkSheet Excel_worksheet = new Create_Excel_WorkSheet();
            worksheet = Excel_worksheet.Create_WorkSheet(workbook, "DM 2019");
            worksheet.Application.ActiveWindow.Zoom = 85;


            Action_WorkSheet(worksheet, NewActionPozitiveFinish, 10);
            Action_WorkSheet(worksheet, NewActionNegativeFinish, 14 + NewActionPozitiveFinish.Rows.Count);

            Save_Excel_WorkBook Save = new Save_Excel_WorkBook(mainProgram);
            Save.Save_WorkBook(excel, workbook);
        }

        private void Action_WorkSheet(Worksheet worksheet, System.Data.DataTable Action, int StartRow)
        {
            Range Cell = worksheet.Range["A1:ZZ100"];
            Cell.Style.Font.Name = "Arial";
            Cell.Style.Font.Size = 12;
            Cell = worksheet.Range["I10:ZZ100"];
            Cell.NumberFormat = "# ##0.000";

            foreach (DataRow Row in Action.Rows)
            {
                for (int counter = 1; counter <= Action.Columns.Count; counter++)
                {
                    Range Cella = worksheet.Cells[StartRow, counter];
                    if (counter > 8 && Row[counter - 1].ToString() !="")
                    {
                        Cella.Value2 = double.Parse(Row[counter - 1].ToString());
                    }
                    else
                    {
                        Cella.Value2 = Row[counter - 1].ToString();
                    }
                }
                StartRow++;
            }
        }

        private System.Data.DataTable Load_Table(System.Data.DataTable ActionList, string Year, string Pozitive)
        {
            System.Data.DataTable Lista = new System.Data.DataTable();
            System.Data.DataTable Frozen = new System.Data.DataTable();
            System.Data.DataTable Kurs = new System.Data.DataTable();
            System.Data.DataTable ANC = new System.Data.DataTable();
            System.Data.DataTable PNC = new System.Data.DataTable();
            DataRow YearFrozen;
            string Rewizja = "";
            string Link;
            bool BU = false;
            bool EA1 = false;
            bool EA2 = false;
            bool EA3 = false;
            decimal KursEuro;

            Lista = ActionList.Clone();

            Link = data_Import.Load_Link("Frozen");
            data_Import.Load_TxtToDataTable(ref Frozen, Link);

            Link = data_Import.Load_Link("Kurs");
            data_Import.Load_TxtToDataTable(ref Kurs, Link);

            Link = data_Import.Load_Link("ANC");
            data_Import.Load_TxtToDataTable(ref ANC, Link);

            Link = data_Import.Load_Link("PNC");
            data_Import.Load_TxtToDataTable(ref PNC, Link);

            YearFrozen = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year)).FirstOrDefault();

            if (YearFrozen["EA3"].ToString() == "Approve" || YearFrozen["EA3"].ToString() == "Open")
            {
                Rewizja = "EA3";
                EA3 = true;
            }
            else if (YearFrozen["EA2"].ToString() == "Approve" || YearFrozen["EA2"].ToString() == "Open")
            {
                Rewizja = "EA2";
                EA2 = true;
            }
            else if (YearFrozen["EA1"].ToString() == "Approve" || YearFrozen["EA1"].ToString() == "Open")
            {
                Rewizja = "EA1";
                EA1 = true;
            }
            else if (YearFrozen["BU"].ToString() == "Approve" || YearFrozen["BU"].ToString() == "Open")
            {
                Rewizja = "BU";
                BU = true;
            }

            KursEuro = decimal.Parse((Kurs.Select(string.Format("Year LIKE '%{0}%'", Year)).FirstOrDefault())["EURO"].ToString());

            System.Windows.Forms.CheckBox Active = (System.Windows.Forms.CheckBox)mainProgram.TabControl.Controls.Find("CB_Active1", true).First();
            System.Windows.Forms.CheckBox Idea = (System.Windows.Forms.CheckBox)mainProgram.TabControl.Controls.Find("CB_Idea1", true).First();

            if (Active.Checked)
            {
                foreach (DataRow ActionRow in ActionList.Rows)
                {
                    if (ActionRow["StartYear"].ToString() == Year && ActionRow["+ czy -"].ToString() == Pozitive && ActionRow["Status"].ToString() == "Active")
                    {
                        //ActionRow.ItemArray = CalcSpecjal(ActionRow, Rewizja, KursEuro, ref ANC, ref PNC).ItemArray;
                        Lista.Rows.Add(ActionRow.ItemArray);
                    }
                    if (ActionRow["StartYear"].ToString() == "BU/" + Year && ActionRow["+ czy -"].ToString() == Pozitive && ActionRow["Status"].ToString() == "Active")
                    {
                        Lista.Rows.Add(ActionRow.ItemArray);
                    }
                }
            }

            if (Idea.Checked)
            {
                foreach (DataRow ActionRow in ActionList.Rows)
                {
                    if (ActionRow["StartYear"].ToString() == Year && ActionRow["+ czy -"].ToString() == Pozitive && ActionRow["Status"].ToString() == "Idea")
                    {
                        Lista.Rows.Add(ActionRow.ItemArray);
                    }
                }
            }
            return Lista;
        }

        private System.Data.DataTable Prepare_Table(System.Data.DataTable Action)
        {
            System.Data.DataTable Finish_Table = new System.Data.DataTable();
            System.Data.DataRow ActionRow;
            string[] Help;

            CreateColumns(ref Finish_Table);
            //ActionRow = Finish_Table.NewRow();

            foreach (DataRow Row in Action.Rows)
            {
                ActionRow = Finish_Table.NewRow();
                ActionRow["Name"] = Row["Name"];
                ActionRow["Description"] = Row["Description"];
                ActionRow["Area"] = Row["Group"];
                ActionRow["Responsible"] = Row["Leader"];
                ActionRow["Platform"] = Row["Platform"];
                ActionRow["Instalation"] = Row["Installation"];

                if (Row["Status"].ToString() == "Active")
                {
                    if (Row["StartYear"].ToString().Length > 4)
                    {
                        ActionRow["Status"] = "OnHold";
                    }
                    else
                    {
                        ActionRow["Status"] = "Ongoing";
                    }
                }
                else if (Row["Status"].ToString() == "Idea")
                {
                    ActionRow["Status"] = "Idea";
                }

                ActionRow["IDCO"] = IDCO(Row["IDCO"].ToString());

                if (Row["BU"].ToString() != "")
                {
                    Help = Row["BU"].ToString().Split('|');
                    ActionRow["BU_Start"] = Help[0].ToString();
                    ActionRow["BU_Saving"] = Help[1].ToString();
                    ActionRow["BU_Stedy_Quantity"] = Help[2].ToString();
                    ActionRow["BU_Stedy_Level"] = Help[3].ToString();
                    ActionRow["BU_Quantity"] = Help[4].ToString();
                    ActionRow["BU_Probability"] = Help[5].ToString();
                    ActionRow["BU_FiscalSaving"] = Help[6].ToString();
                }
                if (Row["EA1"].ToString() != "")
                {
                    Help = Row["EA1"].ToString().Split('|');
                    ActionRow["EA1_Start"] = Help[0].ToString();
                    ActionRow["EA1_Saving"] = Help[1].ToString();
                    ActionRow["EA1_Stedy_Quantity"] = Help[2].ToString();
                    ActionRow["EA1_Stedy_Level"] = Help[3].ToString();
                    ActionRow["EA1_Quantity"] = Help[4].ToString();
                    ActionRow["EA1_Probability"] = Help[5].ToString();
                    ActionRow["EA1_FiscalSaving"] = Help[6].ToString();
                }
                if (Row["EA2"].ToString() != "")
                {
                    Help = Row["EA2"].ToString().Split('|');
                    ActionRow["EA2_Start"] = Help[0].ToString();
                    ActionRow["EA2_Saving"] = Help[1].ToString();
                    ActionRow["EA2_Stedy_Quantity"] = Help[2].ToString();
                    ActionRow["EA2_Stedy_Level"] = Help[3].ToString();
                    ActionRow["EA2_Quantity"] = Help[4].ToString();
                    ActionRow["EA2_Probability"] = Help[5].ToString();
                    ActionRow["EA2_FiscalSaving"] = Help[6].ToString();
                }
                if (Row["EA3"].ToString() != "")
                {
                    Help = Row["EA3"].ToString().Split('|');
                    ActionRow["EA3_Start"] = Help[0].ToString();
                    ActionRow["EA3_Saving"] = Help[1].ToString();
                    ActionRow["EA3_Stedy_Quantity"] = Help[2].ToString();
                    ActionRow["EA3_Stedy_Level"] = Help[3].ToString();
                    ActionRow["EA3_Quantity"] = Help[4].ToString();
                    ActionRow["EA3_Probability"] = Help[5].ToString();
                    ActionRow["EA3_FiscalSaving"] = Help[6].ToString();
                }
                Finish_Table.Rows.Add(ActionRow);
            }

            return Finish_Table;
        }

        private void CreateColumns(ref System.Data.DataTable Action)
        {
            Action.Columns.Add("Name");
            Action.Columns.Add("Description");
            Action.Columns.Add("Area");
            Action.Columns.Add("Responsible");
            Action.Columns.Add("Platform");
            Action.Columns.Add("Instalation");
            Action.Columns.Add("Status");
            Action.Columns.Add("IDCO");
            Action.Columns.Add("BU_Start");
            Action.Columns.Add("BU_Saving");
            Action.Columns.Add("BU_Stedy_Quantity");
            Action.Columns.Add("BU_Stedy_Level");
            Action.Columns.Add("BU_Quantity");
            Action.Columns.Add("BU_Probability");
            Action.Columns.Add("BU_FiscalSaving");
            Action.Columns.Add("EA1_Start");
            Action.Columns.Add("EA1_Saving");
            Action.Columns.Add("EA1_Stedy_Quantity");
            Action.Columns.Add("EA1_Stedy_Level");
            Action.Columns.Add("EA1_Quantity");
            Action.Columns.Add("EA1_Probability");
            Action.Columns.Add("EA1_FiscalSaving");
            Action.Columns.Add("EA2_Start");
            Action.Columns.Add("EA2_Saving");
            Action.Columns.Add("EA2_Stedy_Quantity");
            Action.Columns.Add("EA2_Stedy_Level");
            Action.Columns.Add("EA2_Quantity");
            Action.Columns.Add("EA2_Probability");
            Action.Columns.Add("EA2_FiscalSaving");
            Action.Columns.Add("EA3_Start");
            Action.Columns.Add("EA3_Saving");
            Action.Columns.Add("EA3_Stedy_Quantity");
            Action.Columns.Add("EA3_Stedy_Level");
            Action.Columns.Add("EA3_Quantity");
            Action.Columns.Add("EA3_Probability");
            Action.Columns.Add("EA3_FiscalSaving");
            Action.Columns.Add("USE_Quantity");
            Action.Columns.Add("USE_Savings");
        }

        private readonly Dictionary<string, string> IDCOList = new Dictionary<string, string> { };

        private string IDCO(string IDCOCheck)
        {
            string Final_IDCO = "";
            string[] Help;
            string[] Help2;

            Help = IDCOCheck.Split('/');

            for (int counter = 0; counter < Help.Length - 1; counter++)
            {
                Help2 = Help[counter].Split('|');
                if(!IDCOList.ContainsKey(Help2[1].ToString()))
                {
                    IDCOList.Add(Help2[1].ToString(), Help2[1].ToString());
                }
            }

            foreach (KeyValuePair<string, string> DictionaryValue in IDCOList)
            {
                Final_IDCO = Final_IDCO + DictionaryValue.Value + "/";
            }

            IDCOList.Clear();

            return Final_IDCO;
        }

        private string StartMonth(string Rewizion)
        {
            string[] Help = Rewizion.Split('/');

            for (int counter = 0; counter < 12; counter++)
            {
                if (Help[counter] != "")
                {
                    return counter.ToString();
                }
            }

            return "0";
        }
    }
}
