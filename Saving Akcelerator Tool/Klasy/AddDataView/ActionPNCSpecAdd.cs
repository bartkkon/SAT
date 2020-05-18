using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AddDataView
{
    class ActionPNCSpecAdd
    {

        public static bool Load(string[] NewTable)
        {
            var PNCForm = MainProgram.Self.actionView.PNCListView;
            DataTable PNCTable = PNCForm.GetDataTable();

            if (PNCTable.Columns.Count <= 1)
            {
                PNCTable.Columns.Clear();
                PNCTable.Columns.Add("PNC");
                PNCTable.Columns.Add("OLD ANC");
                PNCTable.Columns.Add("OLD Q");
                PNCTable.Columns.Add("NEW ANC");
                PNCTable.Columns.Add("NEW Q");
                PNCTable.Columns.Add("OLD STK");
                PNCTable.Columns.Add("NEW STK");
                PNCTable.Columns.Add("Delta");
            }

            if (PNCTable.Rows.Count > 0)
            {
                DialogResult Result = MessageBox.Show("Do you want replease exist PNC List?", "Warning!", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    PNCTable.Rows.Clear();
                }
                else
                {
                    DialogResult Result2 = MessageBox.Show("Do you want Add to exist PNC List?", "Warning!", MessageBoxButtons.YesNo);
                    if (Result2 == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            //Sprawdzenie czy dane są prawidłowo przygotowane przez użytkownika
            if (!ProtectionData(NewTable[0]))
                return false;


            foreach (string OneRow in NewTable)
            {
                string[] SpecificRow = OneRow.Split(';');

                if (SpecificRow.Length != 1)
                {
                    DataRow NewRow = PNCTable.NewRow();
                    NewRow["PNC"] = SpecificRow[0];

                    if (SpecificRow[1] != string.Empty)
                        NewRow["OLD ANC"] = "ECCC(" + SpecificRow[1] + ")";

                    PNCTable.Rows.Add(NewRow);

                    int Limit = (SpecificRow.Length - 4) / 2;

                    for (int counter = 2; counter <= Limit; counter++)
                    {

                        NewRow = PNCTable.NewRow();
                        NewRow["OLD ANC"] = SpecificRow[counter];
                        NewRow["OLD Q"] = SpecificRow[counter + 1];
                        NewRow["NEW ANC"] = SpecificRow[counter + Limit + 1];
                        NewRow["NEW Q"] = SpecificRow[counter + Limit + 2];
                        if (!(NewRow["OLD ANC"].ToString() == string.Empty && NewRow["NEW ANC"].ToString() == string.Empty))
                            PNCTable.Rows.Add(NewRow);
                        counter++;
                    }
                }
            }

            DataTable PNCTableDuplicate = PNCTable.Clone();
            bool CanAdd = false;

            foreach (DataRow Row in PNCTable.Rows)
            {
                if (Row["PNC"].ToString() != string.Empty)
                {
                    if (!PNCTableDuplicate.AsEnumerable().Any(u => u.Field<string>("PNC") == Row["PNC"].ToString()))
                    //if (!PNCTableDuplicate.AsEnumerable().Any(u => u.ToString() == Row[0].ToString()))
                    {
                        PNCTableDuplicate.Rows.Add(Row.ItemArray);
                        CanAdd = true;
                    }
                    else
                    {
                        CanAdd = false;
                    }
                }
                else
                {
                    if (CanAdd)
                    {
                        PNCTableDuplicate.Rows.Add(Row.ItemArray);
                    }
                }
            }

            if (!PNCSpecSTK.Find(PNCTableDuplicate))
                return false;

            return true;
        }

        private static bool ProtectionData(string RowToTest)
        {
            string[] FirstRow = RowToTest.Split(';');


            if ((FirstRow.Length % 2) != 0)
            {
                WrongData();
                return false;
            }
            if (FirstRow[FirstRow.Length / 2] != string.Empty)
            {
                WrongData();
                return false;
            }
            if (FirstRow[FirstRow.Length - 1] != string.Empty)
            {
                WrongData();
                return false;
            }
            if (FirstRow.Length < 8)
            {
                WrongData();
                return false;
            }
            if (FirstRow[2].Length != 9 && FirstRow[2].Length != 0)
            {
                WrongData();
                return false;
            }
            if (FirstRow[3].Length == 9)
            {
                WrongData();
                return false;
            }
            if (FirstRow[(FirstRow.Length / 2) + 1].Length != 9 && FirstRow[(FirstRow.Length / 2) + 1].Length != 0)
            {
                WrongData();
                return false;
            }
            if (FirstRow[(FirstRow.Length / 2) + 2].Length == 9)
            {
                WrongData();
                return false;
            }

            return true;
        }
        private static void WrongData()
        {
            MessageBox.Show("It's somenthg wrong with your data. Be sure that you use data from Template." +
                    Environment.NewLine +
                    "If you have still problem please contact with administrator",
                    "Warning!");
        }
    }
}
