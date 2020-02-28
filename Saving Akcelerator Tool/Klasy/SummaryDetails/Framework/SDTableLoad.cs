﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework
{
    public class SDTableLoad
    {
        private DataGridView _Actual;
        private DataGridView _CarryOver;

        public SDTableLoad()
        {
            LoadToTable();
        }

        private void LoadToTable()
        {
            DataTable Actions = new DataTable();
            string[] Klucz;
            string ActionKey;
            int StartMonth;
            string Revision;

            _Actual = MainProgram.Self.sdTableAllView.ObjectTableActual();
            _CarryOver = MainProgram.Self.sdTableAllView.ObjectTableCarryOver();
            decimal Year = MainProgram.Self.sdOptions1.GetYear();
            bool Active = MainProgram.Self.sdOptions1.GetActive();
            bool Idea = MainProgram.Self.sdOptions1.GetIdea();
            string Leader = MainProgram.Self.sdOptions1.GetLeader();
            string Devision = MainProgram.Self.sdOptions1.GetDevision();
            bool Savings = MainProgram.Self.sdTableAllView.GetSavings() ;
            bool Quantity = MainProgram.Self.sdTableAllView.GetQauntity();
            bool ECCC = MainProgram.Self.sdTableAllView.GetECCC();
            bool Positive = MainProgram.Self.sdOptions1.GetPositive();
            bool Negative = MainProgram.Self.sdOptions1.GetNegative();

            _Actual.Rows.Clear();
            _CarryOver.Rows.Clear();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Actions, "Action");

            StartMonth = WhatCanBePresented(Year);
            Revision = WhatRevisionApprove(Year);

            //Tworzenie kluczy
             Klucz = CreateKey(Active, Idea, Year, Leader, Devision, Positive, Negative);

            foreach (DataRow ActionRow in Actions.Rows)
            {

                ActionKey = CreateActionKey(ActionRow, Active, Idea, Devision, Leader, Positive, Negative, Year);

                if (Klucz[0] == ActionKey || Klucz[1] == ActionKey || Klucz[2] == ActionKey)
                {
                    LoadActionSD(ActionRow, false, Savings, Quantity, ECCC, StartMonth, Revision);
                }
                else if (Klucz[3] == ActionKey)
                {
                    LoadActionSD(ActionRow, true, Savings, Quantity, ECCC, StartMonth, Revision);
                }
            }


            _CarryOver.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            _CarryOver.Columns["Option"].DefaultCellStyle.BackColor = Color.White;
            _CarryOver.Columns["Sum"].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);

            _Actual.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            _Actual.Columns["Option"].DefaultCellStyle.BackColor = Color.White;
            _Actual.Columns["Sum"].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
        }

        private void LoadActionSD(DataRow actionRow, bool CarryBool, bool Savings, bool Quantity, bool ECCC, int StartMonth, string Revision)
        {
            DataGridView Table;
            DataGridViewCellStyle Style = new DataGridViewCellStyle();

            int TableRowIndex;
            string Carry;
            int ChangeCalc;
            bool AddRow = false;
            int Color = 2;

            if (CarryBool)
            {
                Table = _CarryOver;
                Carry = "Carry";
            }
            else
            {
                Table = _Actual;
                Carry = "";
            }

            Style.Font = new Font(Table.Font, FontStyle.Bold);

            if (StartMonth == 0)
            {
                ChangeCalc = 12;
            }
            else if (StartMonth == -1)
            {
                ChangeCalc = 0;
            }
            else if (StartMonth > 0)
            {
                ChangeCalc = StartMonth;
            }
            else
            {
                return;
            }

            TableRowIndex = Table.Rows.Add();
            RowFormat(Table.Rows[TableRowIndex], 1);
            Table.Rows[TableRowIndex].Cells["Name"].Value = actionRow["Name"].ToString();
            if (Savings)
            {
                Table.Rows[TableRowIndex].Cells["Option"].Value = "S:";
                AddValuetoTable(actionRow, Table.Rows[TableRowIndex], ChangeCalc, "Saving", Carry, Revision, Style);
                AddRow = true;
            }
            if (Quantity)
            {
                if (AddRow)
                {
                    TableRowIndex = Table.Rows.Add();
                    RowFormat(Table.Rows[TableRowIndex], Color);
                    Color++;
                }
                Table.Rows[TableRowIndex].Cells["Option"].Value = "Q:";
                AddValuetoTable(actionRow, Table.Rows[TableRowIndex], ChangeCalc, "Quantity", Carry, Revision, Style);
                AddRow = true;
            }
            if (ECCC)
            {
                if (AddRow)
                {
                    TableRowIndex = Table.Rows.Add();
                    RowFormat(Table.Rows[TableRowIndex], Color);
                }
                Table.Rows[TableRowIndex].Cells["Option"].Value = "ECCC:";
                AddValuetoTable(actionRow, Table.Rows[TableRowIndex], ChangeCalc, "ECCC", Carry, Revision, Style);
            }


        }

        private void RowFormat(DataGridViewRow Row, int v)
        {
            Row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (v == 2)
            {
                Row.DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            }
            else if (v == 3)
            {
                Row.DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            }
        }

        private void AddValuetoTable(DataRow ActionRow, DataGridViewRow AddAction, int Change, string What, string CarryOver, string Rev, DataGridViewCellStyle Style)
        {
            string[] Actual = (ActionRow["CalcUSE" + What + CarryOver].ToString()).Split('/');
            string[] Plan = (ActionRow["Calc" + Rev + What + CarryOver].ToString()).Split('/');

            for (int counter = 1; counter <= Change; counter++)
            {
                if (Actual[counter - 1] != "")
                {
                    AddAction.Cells[counter.ToString()].Value = decimal.Parse(Actual[counter - 1]);
                    AddAction.Cells[counter.ToString()].Style = Style;
                }

            }
            for (int counter = Change + 1; counter < 13; counter++)
            {
                if (Plan[counter - 1] != "")
                    AddAction.Cells[counter.ToString()].Value = decimal.Parse(Plan[counter - 1]);
            }

            SumRow(AddAction, Style);
        }

        private void SumRow(DataGridViewRow addAction, DataGridViewCellStyle style)
        {
            decimal Suma = 0;
            for (int counter = 1; counter <= 12; counter++)
            {
                if (addAction.Cells[counter.ToString()].Value != null)
                {
                    Suma += decimal.Parse(addAction.Cells[counter.ToString()].Value.ToString());
                }
            }
            if (Suma != 0)
            {
                addAction.Cells["Sum"].Value = Suma;
                addAction.Cells["Sum"].Style = style;

            }
        }

        private string WhatRevisionApprove(decimal Year)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenYear;
            string Revision = "";

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
            FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            if(FrozenYear == null)
            {
                FrozenYear = Frozen.NewRow();
                foreach(DataColumn Column in Frozen.Columns)
                {
                    if (Column.ColumnName == "Year")
                        FrozenYear[Column] = Year;
                    else
                        FrozenYear[Column] = "Close";
                }
                Frozen.Rows.Add(FrozenYear);
                Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");
            }

            if (Year < DateTime.UtcNow.Year)
            {
                Revision = "USE";
            }
            else if (Year > DateTime.UtcNow.Year)
            {
                if (FrozenYear["BU"].ToString() == "Approve" || FrozenYear["BU"].ToString() == "Open")
                    Revision = "BU";
                else
                    Revision = "BU";
            }
            else
            {
                if (FrozenYear["BU"].ToString() == "Approve" || FrozenYear["BU"].ToString() == "Open")
                    Revision = "BU";
                if (FrozenYear["EA1"].ToString() == "Approve" || FrozenYear["EA1"].ToString() == "Open")
                    Revision = "EA1";
                if (FrozenYear["EA2"].ToString() == "Approve" || FrozenYear["EA2"].ToString() == "Open")
                    Revision = "EA2";
                if (FrozenYear["EA3"].ToString() == "Approve" || FrozenYear["EA3"].ToString() == "Open")
                    Revision = "EA3";
            }

            return Revision;
        }

        private int WhatCanBePresented(decimal Year)
        {
            //Wartości od 1 do 12 - miesiąc w aktualnym roku;
            //Wartość 0 - Poprzedni rok (tylko Actual)
            //Wartość -1 - Nastęny rok, tylko BU
            int StartMonth = -5;
            DataTable Frozen = new DataTable();
            DataRow FrozenYear;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            if (Year < DateTime.UtcNow.Year)
            {
                StartMonth = 0;
            }
            else if (Year > DateTime.UtcNow.Year)
            {
                StartMonth = -1;
            }
            else
            {
                FrozenYear = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();
                for (int counter = 1; counter <= 12; counter++)
                {
                    if (FrozenYear[counter.ToString()].ToString() == "Approve" || FrozenYear[counter.ToString()].ToString() == "Open")
                    {
                        StartMonth = counter;
                    }
                }
                if (StartMonth == -5 && Year == DateTime.UtcNow.Year)
                {
                    StartMonth = -1;
                }
            }

            return StartMonth;
        }

        private string[] CreateKey(bool Active, bool Idea, decimal Year, string Leader, string Devision, bool Positive, bool Negative)
        {

            //Budowanie klucza do odczytu czy daną akcje wyświetlić czy nie
            //Klucz słada się nastęująco:
            // 1. Rok akcji
            // 2. Czy jest Active czy Idea (Jak obie to All)
            // 3. Z jakiej devizji ma być akcja (Jak wszystkie to All)
            // 4. Kto jest liderem (Jak wszyscy to All) 
            string[] Key = new string[4];

            Key[0] = Year.ToString() + "/";
            Key[1] = "BU/" + Year.ToString() + "/";
            Key[2] = "SA/" + Year.ToString() + "/";
            Key[3] = (Year - 1).ToString() + "/";

            if (Active && Idea)
            {
                Key[0] += "All/";
                Key[1] += "All/";
                Key[2] += "All/";
                Key[3] += "All/";
            }
            else if (Active)
            {
                Key[0] += "Active/";
                Key[1] += "Active/";
                Key[2] += "Active/";
                Key[3] += "Active/";
            }
            else if (Idea)
            {
                Key[0] += "Idea/";
                Key[1] += "Idea/";
                Key[2] += "Idea/";
                Key[3] += "Idea/";
            }

            if (Devision == "All")
            {
                Key[0] += "All/";
                Key[1] += "All/";
                Key[2] += "All/";
                Key[3] += "All/";
            }
            else
            {
                Key[0] += Devision + "/";
                Key[1] += Devision + "/";
                Key[2] += Devision + "/";
                Key[3] += Devision + "/";
            }

            if (Leader == "All")
            {
                Key[0] += "All/";
                Key[1] += "All/";
                Key[2] += "All/";
                Key[3] += "All/";
            }
            else
            {
                Key[0] += Leader + "/";
                Key[1] += Leader + "/";
                Key[2] += Leader + "/";
                Key[3] += Leader + "/";
            }

            if (Positive && Negative)
            {
                Key[0] += "All/";
                Key[1] += "All/";
                Key[2] += "All/";
                Key[3] += "All/";
            }
            else
            {
                if (Positive)
                {
                    Key[0] += "Pozytywna/";
                    Key[1] += "Pozytywna/";
                    Key[2] += "Pozytywna/";
                    Key[3] += "Pozytywna/";
                }
                else if (Negative)
                {
                    Key[0] += "Negatywna/";
                    Key[1] += "Negatywna/";
                    Key[2] += "Negatywna/";
                    Key[3] += "Negatywna/";
                }
            }

            return Key;
        }

        private string CreateActionKey(DataRow ActionRow, bool Active, bool Idea, string Devision, string Leader, bool Positive, bool Negative, decimal Year)
        {
            //Budowanie klucza do odczytu czy daną akcje wyświetlić czy nie
            //Klucz słada się nastęująco:
            // 1. Rok akcji
            // 2. Czy jest Active czy Idea (Jak obie to All)
            // 3. Z jakiej devizji ma być akcja (Jak wszystkie to All)
            // 4. Kto jest liderem (Jak wszyscy to All) 
            string ActionKey;

            ActionKey = ActionRow["StartYear"].ToString() + "/";

            if (Active && Idea)
                ActionKey += "All/";
            else
                ActionKey += ActionRow["Status"].ToString() + "/";

            if (Devision == "All")
                ActionKey += "All/";
            else
                ActionKey += ActionRow["Group"].ToString() + "/";

            if (Leader == "All")
                ActionKey += "All/";
            else
                ActionKey += ActionRow["Leader"].ToString() + "/";

            if (Positive && Negative)
                ActionKey += "All/";
            else
                ActionKey += ActionRow["+ czy -"].ToString() + "/";

            //Jeśli akcja w poprzednim roku rozpoczeła się w Styczniu to w bierzącym roku akcja nie jest już Carry Over.
            if (ActionRow["StartYear"].ToString() == (Year - 1).ToString())
            {
                if (ActionRow["StartMonth"].ToString() == "January")
                {
                    ActionKey = "NO";
                }
            }

            return ActionKey;
        }
    }
}
