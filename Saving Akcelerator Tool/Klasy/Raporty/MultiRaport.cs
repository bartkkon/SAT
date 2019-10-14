using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;


namespace Saving_Accelerator_Tool
{
    class MultiRaport
    {
        private readonly Data_Import ImportData;
        private readonly MainProgram mainProgram;
        private readonly decimal Year;
        private readonly Dictionary<string, bool> Preferencje = new Dictionary<string, bool> { };
        private readonly Dictionary<string, bool> Akcje = new Dictionary<string, bool> { };
        private readonly Dictionary<string, int> Month = new Dictionary<string, int>()
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
        private readonly Dictionary<int, string> Month2 = new Dictionary<int, string>()
        {
            {0,"January" },
            {1, "February"},
            {2, "March" },
            {3, "April" },
            {4, "May" },
            {5, "June" },
            {6, "July" },
            {7, "August" },
            {8, "Septemner" },
            {9, "October"},
            {10, "November" },
            {11, "December" },
            {12, "TOT" },
        };


        public MultiRaport(MainProgram mainProgram, Data_Import ImportData, Dictionary<string, bool> Akcje, Dictionary<string, bool> Preferencje, decimal Year)
        {
            this.mainProgram = mainProgram;
            this.ImportData = ImportData;
            this.Preferencje = Preferencje;
            this.Akcje = Akcje;
            this.Year = Year;
        }

        public void GeneretedMutliRaport()
        {
            Excel.Application Raport;
            Excel.Workbook RaportWorkBook;
            Excel.Worksheet MultiAction;
            Excel.Worksheet MultiSum;
            DataTable ElectronicActual = new DataTable();
            DataTable MechanicActual = new DataTable();
            DataTable NVRActual = new DataTable();
            DataTable ElectronicCarry = new DataTable();
            DataTable MechanicalCarry = new DataTable();
            DataTable NVRCarry = new DataTable();
            DataTable Action = new DataTable();
            DataRow[] ActionRewizion = null;
            DataTable ActionR = new DataTable();
            DataTable History = new DataTable();
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            double[] ElectronicA = new double[13];
            double[] ElectronicC = new double[13];
            double[] MechanicA = new double[13];
            double[] MechanicC = new double[13];
            double[] NVRA = new double[13];
            double[] NVRC = new double[13];
            int ColumnForSavings = 0;
            string Link;
            int MonthA = 0;
            string Rew = "";
            int Start = 4;

            Link = ImportData.Load_Link("Frozen");
            ImportData.Load_TxtToDataTable(ref Frozen, Link);
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            Link = ImportData.Load_Link("History");
            ImportData.Load_TxtToDataTable(ref History, Link);

            for (int counter = 12; counter > 1; counter--)
            {
                if (FrozenRow[counter.ToString()].ToString() == "Approve")
                {
                    MonthA = counter;
                    break;
                }
            }

            if (MonthA == 0)
            {
                Preferencje["Actual"] = false;
            }

            if (Preferencje["Actual"])
            {
                Rew = "Actual";
                ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", Month.ToString() + "/" + Year.ToString())).ToArray();
            }
            else if (Preferencje["BU"])
            {
                if (FrozenRow["BU"].ToString() == "Approve")
                {
                    Rew = "BU";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "BU/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA1"])
            {
                if (FrozenRow["EA1"].ToString() == "Approve")
                {
                    Rew = "EA1";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA1/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA2"])
            {
                if (FrozenRow["EA2"].ToString() == "Approve")
                {
                    Rew = "EA2";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA2/" + Year.ToString())).ToArray();
                }
            }
            else if (Preferencje["EA3"])
            {
                if (FrozenRow["EA3"].ToString() == "Approve")
                {
                    Rew = "EA3";
                    ActionRewizion = History.Select(string.Format("History LIKE '%{0}%'", "EA3/" + Year.ToString())).ToArray();
                }
            }

            if (Rew == "")
            {
                MessageBox.Show("NO Data avalible for Report");
                return;
            }

            if (Year > DateTime.Now.Year)
            {
                Preferencje["Actual"] = false;
            }

            ActionR = History.Clone();

            foreach (DataRow Row in ActionRewizion)
            {
                ActionR.ImportRow(Row);
            }

            if (Preferencje["Electronic"] && Preferencje["Current Action"])
            {
                CreateColumn(ref ElectronicActual);
                AddActiontoTable(ref ActionR, ref ElectronicActual, "Electronic", Year, true, MonthA);
                SumAction(ref ElectronicActual);
                ElectronicA = SumAllDevision(ElectronicActual);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicActual.Columns["S1"].Ordinal + 2;
                }

            }
            if (Preferencje["Mechanic"] && Preferencje["Current Action"])
            {
                CreateColumn(ref MechanicActual);
                AddActiontoTable(ref ActionR, ref MechanicActual, "Mechanic", Year, true, MonthA);
                SumAction(ref MechanicActual);
                MechanicA = SumAllDevision(MechanicActual);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicActual.Columns["S1"].Ordinal + 2;
                }
            }
            if (Preferencje["NVR"] && Preferencje["Current Action"])
            {
                CreateColumn(ref NVRActual);
                AddActiontoTable(ref ActionR, ref NVRActual, "NVR", Year, true, MonthA);
                SumAction(ref NVRActual);
                NVRA = SumAllDevision(NVRActual);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicActual.Columns["S1"].Ordinal + 2;
                }
            }
            if (Preferencje["Electronic"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref ElectronicCarry);
                AddActiontoTable(ref ActionR, ref ElectronicCarry, "Electronic", Year - 1, false, MonthA);
                SumAction(ref ElectronicCarry);
                ElectronicC = SumAllDevision(ElectronicCarry);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicCarry.Columns["S1"].Ordinal + 2;
                }
            }
            if (Preferencje["Mechanic"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref MechanicalCarry);
                AddActiontoTable(ref ActionR, ref MechanicalCarry, "Mechanic", Year - 1, false, MonthA);
                SumAction(ref MechanicalCarry);
                MechanicC = SumAllDevision(MechanicalCarry);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicActual.Columns["S1"].Ordinal + 2;
                }
            }
            if (Preferencje["NVR"] && Preferencje["Carry Action"])
            {
                CreateColumn(ref NVRCarry);
                AddActiontoTable(ref ActionR, ref NVRCarry, "NVR", Year - 1, false, MonthA);
                SumAction(ref NVRCarry);
                NVRC = SumAllDevision(NVRCarry);
                if (Preferencje["Savings"])
                {
                    ColumnForSavings = ElectronicActual.Columns["S1"].Ordinal + 2;
                }
            }

            Create_Excel_Application _Application = new Create_Excel_Application();
            Raport = _Application.Create_Application();
            Raport.Visible = false;
            Raport.DisplayAlerts = false;
            Raport.ScreenUpdating = false;
            Raport.DisplayStatusBar = false;
            Raport.EnableEvents = false;

            Create_Excel_WorkBooks _WorkBooks = new Create_Excel_WorkBooks();
            RaportWorkBook = _WorkBooks.Create_WorkBooks(Raport);

            if (Preferencje["WS Action"])
            {
                Create_Excel_WorkSheet _WorkSheet = new Create_Excel_WorkSheet();
                MultiAction = _WorkSheet.Create_WorkSheet(RaportWorkBook, "DM " + Year.ToString());
                MultiAction.Application.ActiveWindow.Zoom = 85;
                MultiAction.DisplayPageBreaks = false;
                Raport.Windows.Application.ActiveWindow.DisplayGridlines = false;
                Raport.Calculation = Excel.XlCalculation.xlCalculationManual;
                Raport.ErrorCheckingOptions.NumberAsText = false;

                int ColumnUse = MultiActionColumn(MultiAction) - 1;

                if (Preferencje["Carry Action"])
                {
                    Start = CarryOverHeadre(MultiAction, ColumnUse, Start, "CARRY OVER", ElectronicC, MechanicC, NVRC, ColumnForSavings);
                    if (Preferencje["Electronic"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Electronic", ElectronicC, ColumnForSavings);
                        Start = AddTableToWorksheet2(ElectronicCarry, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                    if (Preferencje["Mechanic"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Mechanic", MechanicC, ColumnForSavings);
                        Start = AddTableToWorksheet2(MechanicalCarry, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                    if (Preferencje["NVR"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Aesthetics", NVRC, ColumnForSavings);
                        Start = AddTableToWorksheet2(NVRCarry, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                }
                Start += 2;
                if (Preferencje["Current Action"])
                {
                    Start = CarryOverHeadre(MultiAction, ColumnUse, Start, "NEW ACTION", ElectronicA, MechanicA, NVRA, ColumnForSavings);
                    if (Preferencje["Electronic"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Electronic", ElectronicA, ColumnForSavings);
                        Start = AddTableToWorksheet2(ElectronicActual, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                    if (Preferencje["Mechanic"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Mechanic", MechanicA, ColumnForSavings);
                        Start = AddTableToWorksheet2(MechanicActual, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                    if (Preferencje["NVR"])
                    {
                        Start = DevisionHeader(MultiAction, ColumnUse, Start, "Aesthetics", NVRA, ColumnForSavings);
                        Start = AddTableToWorksheet2(NVRActual, MultiAction, Start, ColumnUse);
                        Start += 2;
                    }
                }
            }
            if (Preferencje["WS Summ"])
            {
                Create_Excel_WorkSheet _WorkSheet = new Create_Excel_WorkSheet();
                MultiSum = _WorkSheet.Create_WorkSheet(RaportWorkBook, "Chart PLN");
                MultiSum.Application.ActiveWindow.Zoom = 85;
                MultiSum.DisplayPageBreaks = false;
                Raport.Windows.Application.ActiveWindow.DisplayGridlines = false;
                Raport.Calculation = Excel.XlCalculation.xlCalculationManual;
                Raport.ErrorCheckingOptions.NumberAsText = false;

                ColumnSum(MultiSum);

                int StartAdding = 8;

                ColoringSum(MultiSum, StartAdding, "BU");
                SumActualRewizion(MultiSum, StartAdding + 2, ElectronicA, ElectronicC, MechanicA, MechanicC, NVRA, NVRC);

                StartAdding += 7;
                ColoringSum(MultiSum, StartAdding, "EA1");

                StartAdding += 7;
                ColoringSum(MultiSum, StartAdding, "EA2");

                StartAdding += 7;
                ColoringSum(MultiSum, StartAdding, "EA3");

                StartAdding += 7;
                ColoringSum(MultiSum, StartAdding, "ACTUAL");
            }

            Remove_Empty_Sheet EmptySheet = new Remove_Empty_Sheet();
            EmptySheet.Remove_Empty(Raport, RaportWorkBook);

            Save_Excel_WorkBook Save = new Save_Excel_WorkBook(mainProgram);
            Save.Save_WorkBook(Raport, RaportWorkBook);

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Do sumowania akcji aby stworzyć podsumowanie

        private void SumActualRewizion(Excel.Worksheet MultiSum,int Start, double[] ElectronicA, double[] ElectronicC, double[] MechanicA, double[] MechanicC, double[] NVRA, double[] NVRC)
        {
            double[] Actual = new double[14];
            double[] Carry = new double[14];
            double[] Suma = new double[14];
            string Link;
            double Euro = 0;
            DataTable Kurs = new DataTable();
            DataRow KursEuro;

            for (int counter = 0; counter < 13; counter++)
            {
                Actual[counter] = ElectronicA[counter] + MechanicA[counter] + NVRA[counter];
                Carry[counter] = ElectronicC[counter] + MechanicC[counter] + NVRC[counter];
                Suma[counter] = Actual[counter] + Carry[counter];
            }

            Link = ImportData.Load_Link("Kurs");
            ImportData.Load_TxtToDataTable(ref Kurs, Link);

            KursEuro = Kurs.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (KursEuro != null)
            {
                Euro = double.Parse(KursEuro["EURO"].ToString());
                Actual[13] = Actual[12] / Euro;
                Carry[13] = Carry[12] / Euro;
                Suma[13] = Actual[13] + Carry[13];
            }

            ColoringSum(MultiSum, 8, "BU");

            Excel.Range CellStart = MultiSum.Cells[Start, 3];
            Excel.Range CellFinish = MultiSum.Cells[Start, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = Carry.Select(x => x.ToString()).ToArray();
            for (int counter = 3; counter<=16; counter++)
            {
                ConvertToNumber(MultiSum, counter, Start, Start);
            }
            MultiSum.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";

            CellStart = MultiSum.Cells[Start +1, 3];
            CellFinish = MultiSum.Cells[Start + 1, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = Actual.Select(x => x.ToString()).ToArray();
            for (int counter = 3; counter <= 16; counter++)
            {
                ConvertToNumber(MultiSum, counter, Start+1, Start+1);
            }
            MultiSum.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";

            CellStart = MultiSum.Cells[Start + 2, 3];
            CellFinish = MultiSum.Cells[Start + 2, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = Suma.Select(x => x.ToString()).ToArray();
            for (int counter = 3; counter <= 16; counter++)
            {
                ConvertToNumber(MultiSum, counter, Start + 2, Start + 2);
            }
            MultiSum.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";
        }

        private void ColumnSum(Excel.Worksheet MultiSum)
        {
            for (int counter = 2; counter <= 16; counter++)
            {
                MultiSum.Columns[counter].ColumnWidth = 12.50;
                MultiSum.Columns[counter].Font.Name = "Arial";
                MultiSum.Columns[counter].Font.Size = 9;
            }

            MultiSum.Rows.RowHeight = 15;

        }

        private void ColoringSum(Excel.Worksheet MultiSum, int Start, string Rew)
        {
            string[] Information = new string[14] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "TOT", "TOT [€]" };

            Excel.Range CellStart = MultiSum.Cells[Start, 3];
            Excel.Range CellFinish = MultiSum.Cells[Start, 14];
            MultiSum.Range[CellStart, CellFinish].Merge();
            MultiSum.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiSum.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;


            MultiSum.Cells[Start, 3].Font.Color = Color.White;
            MultiSum.Cells[Start, 3].Font.Bold = true;

            if (Rew != "ACTUAL")
            {
                MultiSum.Cells[Start, 3].Value2 = Rew + " TOTAL FORECASTED EC SAVINGS";
                if (Rew == "BU")
                    MultiSum.Cells[Start, 3].Interior.Color = Color.FromArgb(128, 128, 128);
                else if (Rew == "EA1")
                    MultiSum.Cells[Start, 3].Interior.Color = Color.FromArgb(150, 54, 52);
                else if (Rew == "EA2")
                    MultiSum.Cells[Start, 3].Interior.Color = Color.FromArgb(151, 71, 6);
                else if (Rew == "EA3")
                    MultiSum.Cells[Start, 3].Interior.Color = Color.FromArgb(128, 128, 128);
            }
            else
            {
                MultiSum.Cells[Start, 3].Value2 = Rew + " TOTAL EC SAVINGS";
                MultiSum.Cells[Start, 3].Interior.Color = Color.FromArgb(226, 107, 10);
            }

            Start++;
            CellStart = MultiSum.Cells[Start, 3];
            CellFinish = MultiSum.Cells[Start, 16];
            MultiSum.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiSum.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Font.Color = Color.White;
            MultiSum.Range[CellStart, CellFinish].Font.Bold = true;
            MultiSum.Range[CellStart, CellFinish].Value2 = Information;

            if (Rew == "BU")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(128, 128, 128);
            else if (Rew == "EA1")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(150, 54, 52);
            else if (Rew == "EA2")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(151, 71, 6);
            else if (Rew == "EA3")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(128, 128, 128);
            else if (Rew == "ACTUAL")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(226, 107, 10);

            Start++;
            MultiSum.Cells[Start, 2].Value2 = "ECI CO";

            CellStart = MultiSum.Cells[Start, 2];
            CellFinish = MultiSum.Cells[Start, 16];
            MultiSum.Range[CellStart, CellFinish].Font.Bold = false;
            MultiSum.Range[CellStart, CellFinish].Font.Color = Color.Black;
            MultiSum.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiSum.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

            Start++;
            MultiSum.Cells[Start, 2].Value2 = "ECI NA";

            CellStart = MultiSum.Cells[Start, 2];
            CellFinish = MultiSum.Cells[Start, 16];
            MultiSum.Range[CellStart, CellFinish].Font.Bold = false;
            MultiSum.Range[CellStart, CellFinish].Font.Color = Color.Black;
            MultiSum.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiSum.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

            if (Rew == "BU")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(217,217,217);
            else if (Rew == "EA1")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(218,150,148);
            else if (Rew == "EA2")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(230,184,183);
            else if (Rew == "EA3")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(191,191,191);
            else if (Rew == "ACTUAL")
                MultiSum.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(252,213,180);

            Start++;
            MultiSum.Cells[Start, 2].Value2 = "ECI TOTAL";

            CellStart = MultiSum.Cells[Start, 2];
            CellFinish = MultiSum.Cells[Start, 16];
            MultiSum.Range[CellStart, CellFinish].Font.Bold = true;
            MultiSum.Range[CellStart, CellFinish].Font.Color = Color.Black;
            MultiSum.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiSum.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiSum.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

        }

        private void SummAllRewizion(Excel.Worksheet MultiSum, DataRow[] ActionApprove, DataTable ElectronicA, DataTable ElectronicC, DataTable MechanicA, DataTable MechanicC, DataTable NVRA, DataTable NVRC)
        {
            DataTable BU = new DataTable();
            DataTable EA1 = new DataTable();
            DataTable EA2 = new DataTable();
            DataTable EA3 = new DataTable();
            DataTable Actual = new DataTable();
            DataTable Action = new DataTable();
            DataRow FinalRow;
            DataTable Kurs = new DataTable();
            DataRow KursEuro;
            string Link;
            double Euro = 0;


            AddColumnToSum(ref BU);
            AddColumnToSum(ref EA1);
            AddColumnToSum(ref EA2);
            AddColumnToSum(ref EA3);
            AddColumnToSum(ref Actual);

            foreach (DataRow Row in ActionApprove)
            {
                if (Akcje.ContainsKey(Row["Name"].ToString()))
                {
                    if (Akcje[Row["Name"].ToString()])
                    {
                        string[] BUActual = Row["CalcBUSaving"].ToString().Split('/');
                        string[] EA1Actual = Row["CalcEA1Saving"].ToString().Split('/');
                        string[] EA2Actual = Row["CalcEA2Saving"].ToString().Split('/');
                        string[] EA3Actual = Row["CalcEA3Saving"].ToString().Split('/');
                        string[] USEActual = Row["CalcUSESaving"].ToString().Split('/');

                        string[] BUCarry = Row["CalcBUSavingCarry"].ToString().Split('/');
                        string[] EA1Carry = Row["CalcEA1SavingCarry"].ToString().Split('/');
                        string[] EA2Carry = Row["CalcEA2SavingCarry"].ToString().Split('/');
                        string[] EA3Carry = Row["CalcEA3SavingCarry"].ToString().Split('/');
                        string[] USECarry = Row["CalcUSESavingCarry"].ToString().Split('/');

                        for (int counter = 0; counter < 13; counter++)
                        {
                            if (BUCarry[counter].ToString() != "")
                            {
                                FinalRow = BU.Rows[0];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(BUCarry[counter].ToString());
                            }
                            if (BUActual[counter].ToString() != "")
                            {
                                FinalRow = BU.Rows[1];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(BUActual[counter].ToString());
                            }
                            if (EA1Carry[counter].ToString() != "")
                            {
                                FinalRow = EA1.Rows[0];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA1Carry[counter].ToString());
                            }
                            if (EA1Actual[counter].ToString() != "")
                            {
                                FinalRow = EA1.Rows[1];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA1Actual[counter].ToString());
                            }
                            if (EA2Carry[counter].ToString() != "")
                            {
                                FinalRow = EA2.Rows[0];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA2Carry[counter].ToString());
                            }
                            if (EA2Actual[counter].ToString() != "")
                            {
                                FinalRow = EA2.Rows[1];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA2Actual[counter].ToString());
                            }
                            if (EA3Carry[counter].ToString() != "")
                            {
                                FinalRow = EA3.Rows[0];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA3Carry[counter].ToString());
                            }
                            if (EA3Actual[counter].ToString() != "")
                            {
                                FinalRow = EA3.Rows[1];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(EA3Actual[counter].ToString());
                            }
                            if (USECarry[counter].ToString() != "")
                            {
                                FinalRow = Actual.Rows[0];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(USECarry[counter].ToString());
                            }
                            if (USEActual[counter].ToString() != "")
                            {
                                FinalRow = Actual.Rows[1];
                                FinalRow[counter] = double.Parse(FinalRow[counter].ToString()) + double.Parse(USEActual[counter].ToString());
                            }
                        }
                    }
                }
            }
            Link = ImportData.Load_Link("Kurs");
            ImportData.Load_TxtToDataTable(ref Kurs, Link);

            KursEuro = Kurs.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();
            if (KursEuro != null)
                Euro = double.Parse(KursEuro["EURO"].ToString());


            SumRewizionTable(ref BU, Euro);
            SumRewizionTable(ref EA1, Euro);
            SumRewizionTable(ref EA2, Euro);
            SumRewizionTable(ref EA3, Euro);
            SumRewizionTable(ref Actual, Euro);
            Excel.Range CellStart = MultiSum.Cells[10, 3];
            Excel.Range CellFinish = MultiSum.Cells[10, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = BU.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            CellStart = MultiSum.Cells[11, 3];
            CellFinish = MultiSum.Cells[11, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = BU.Rows[1].ItemArray.Select(x => x.ToString()).ToArray();
            CellStart = MultiSum.Cells[12, 3];
            CellFinish = MultiSum.Cells[12, 16];
            MultiSum.Range[CellStart, CellFinish].Value2 = BU.Rows[2].ItemArray.Select(x => x.ToString()).ToArray();

        }

        private void AddSumtoWorkaheet(Excel.Worksheet ActionSum, DataTable BU, DataTable EA1, DataTable EA2, DataTable EA3, DataTable Actual)
        {
            string[,] Information = new string[4, 15] { { "", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "TOT", "TOT [€]" }, { "ECI CO", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, { "ECI NA", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, { "ECI TOTAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, };
        }


        private void SumRewizionTable(ref DataTable Rewision, double Euro)
        {
            DataRow Carry = Rewision.Rows[0];
            DataRow Actual = Rewision.Rows[1];
            DataRow Sum = Rewision.Rows[2];

            Carry[13] = Math.Round(double.Parse(Carry[12].ToString()) / Euro, 0, MidpointRounding.AwayFromZero);
            Actual[13] = Math.Round(double.Parse(Actual[12].ToString()) / Euro, 0, MidpointRounding.AwayFromZero);

            for (int counter = 0; counter < 14; counter++)
            {
                Sum[counter] = double.Parse(Carry[counter].ToString()) + double.Parse(Actual[counter].ToString());
            }
        }

        private void AddColumnToSum(ref DataTable Table)
        {
            //Table.Columns.Add("Name");
            Table.Columns.Add("1");
            Table.Columns.Add("2");
            Table.Columns.Add("3");
            Table.Columns.Add("4");
            Table.Columns.Add("5");
            Table.Columns.Add("6");
            Table.Columns.Add("7");
            Table.Columns.Add("8");
            Table.Columns.Add("9");
            Table.Columns.Add("10");
            Table.Columns.Add("11");
            Table.Columns.Add("12");
            Table.Columns.Add("Sum");
            Table.Columns.Add("SumE");

            Table.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Table.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Table.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            //DataRow Row1 = Table.NewRow();
            //Row1["Name"] = "Carry";
            //Table.Rows.Add(Row1);
            //Row1 = Table.NewRow();
            //Row1["Name"] = "NewAction";
            //Table.Rows.Add(Row1);
            //Row1 = Table.NewRow();
            //Row1["Name"] = "Total";
            //Table.Rows.Add(Row1);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private int AddTableToWorksheet2(DataTable Table, Excel.Worksheet worksheet, int Start, int ColumnCount)
        {
            int RowCount = Table.Rows.Count;
            int ColumnCountTable = Table.Columns.Count;
            int QuantityColumn = 0;
            int SavingsColumn = 0;
            int ECCColumn = 0;
            int counter = 0;
            string[,] AllAction = new string[RowCount, ColumnCountTable];

            if (Preferencje["Quantity"])
            {
                QuantityColumn = Table.Columns["Q1"].Ordinal + 1;
            }
            if (Preferencje["Savings"])
            {
                SavingsColumn = Table.Columns["S1"].Ordinal + 1;
            }
            if (Preferencje["ECCC"])
            {
                ECCColumn = Table.Columns["E1"].Ordinal + 1;
            }

            foreach (DataRow Row in Table.Rows)
            {
                string[] ArryTable = Row.ItemArray.Select(x => x.ToString()).ToArray();
                for (int counter2 = 0; counter2 < ColumnCountTable; counter2++)
                {
                    AllAction[counter, counter2] = ArryTable[counter2];
                }
                counter++;
            }

            Excel.Range CellStart = worksheet.Cells[Start, 2];
            Excel.Range CellFinish = worksheet.Cells[Start + RowCount - 1, ColumnCount];

            worksheet.Range[CellStart, CellFinish].Value2 = AllAction;
            ActionRowFormatingMultiLine(worksheet, Start, Start + RowCount, ColumnCount);

            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                {
                    int column = Table.Columns["ANC Old"].Ordinal + 2;
                    ConvertToNumber(worksheet, column, Start, Start + RowCount - 1);
                    Center(worksheet, column, Start, Start + RowCount - 1);
                }
                if (Preferencje["Old STK"])
                {
                    int column = Table.Columns["Old STK"].Ordinal + 2;
                    ConvertToNumber(worksheet, column, Start, Start + RowCount - 1);
                    Center(worksheet, column, Start, Start + RowCount - 1);
                }
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                {
                    int column = Table.Columns["ANC New"].Ordinal + 2;
                    ConvertToNumber(worksheet, column, Start, Start + RowCount - 1);
                    Center(worksheet, column, Start, Start + RowCount - 1);
                }
                if (Preferencje["New STK"])
                {
                    int column = Table.Columns["New STK"].Ordinal + 2;
                    ConvertToNumber(worksheet, column, Start, Start + RowCount - 1);
                    Center(worksheet, column, Start, Start + RowCount - 1);
                }
            }
            if (Preferencje["Delta"])
            {
                int column = Table.Columns["Delta"].Ordinal + 2;
                ConvertToNumber(worksheet, column, Start, Start + RowCount - 1);
                Center(worksheet, column, Start, Start + RowCount - 1);
            }
            if (Preferencje["Quantity"])
            {
                int column = Table.Columns["Q1"].Ordinal + 1;
                for (int counter2 = 1; counter2 <= 13; counter2++)
                    ConvertToNumber(worksheet, column + counter2, Start, Start + RowCount - 1);

                NumberFormatiog(worksheet, column + 1, column + 12, Start, Start + RowCount - 1);
                NumberFormationgTotal(worksheet, column + 13, Start, Start + RowCount - 1);
            }
            if (Preferencje["Savings"])
            {
                int column = Table.Columns["S1"].Ordinal + 1;
                for (int counter2 = 1; counter2 <= 13; counter2++)
                    ConvertToNumber(worksheet, column + counter2, Start, Start + RowCount - 1);

                NumberFormatiog(worksheet, column + 1, column + 12, Start, Start + RowCount - 1);
                NumberFormationgTotal(worksheet, column + 13, Start, Start + RowCount - 1);
            }
            if (Preferencje["ECCC"])
            {
                int column = Table.Columns["E1"].Ordinal + 1;
                for (int counter2 = 1; counter2 <= 13; counter2++)
                    ConvertToNumber(worksheet, column + counter2, Start, Start + RowCount - 1);

                NumberFormatiog(worksheet, column + 1, column + 12, Start, Start + RowCount - 1);
                NumberFormationgTotal(worksheet, column + 13, Start, Start + RowCount - 1);
            }

            GroupingAction(worksheet, Table, Start);

            return Start + RowCount;
        }

        //Grupowanie akcji
        private void GroupingAction(Excel.Worksheet MultiAction, DataTable Table, int Start)
        {
            int ActionRowStart = 0;
            int ActionRowFinish = 0;
            bool First = true;

            foreach (DataRow Row in Table.Rows)
            {
                if (Row["Name"].ToString() != "")
                {
                    if (First)
                    {
                        ActionRowStart = Table.Rows.IndexOf(Row);
                        First = false;
                    }
                    else
                    {
                        ActionRowFinish = Table.Rows.IndexOf(Row) - 1;
                        if (ActionRowStart != ActionRowFinish)
                        {
                            Excel.Range Rows = MultiAction.Rows[(Start + ActionRowStart + 1).ToString() + ":" + (Start + ActionRowFinish).ToString(), Type.Missing];
                            Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            Rows.Hidden = true;
                            Rows.OutlineLevel = 2;
                        }
                        ActionRowStart = Table.Rows.IndexOf(Row);
                    }
                }
            }
            if (ActionRowStart != (Table.Rows.Count - 1))
            {
                ActionRowFinish = Table.Rows.Count - 1;
                Excel.Range Rows = MultiAction.Rows[(Start + ActionRowStart + 1).ToString() + ":" + (Start + ActionRowFinish).ToString(), Type.Missing];
                Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Rows.Hidden = true;
                Rows.OutlineLevel = 2;
            }
        }

        //Dodanie tabeli do raportu
        private int AddTableToWorksheet(DataTable Table, Excel.Worksheet worksheet, int Start, int ColumnCount)
        {
            int RowCount = Table.Rows.Count;
            int QuantityColumn = 0;
            int SavingsColumn = 0;
            int ECCColumn = 0;

            if (Preferencje["Quantity"])
            {
                QuantityColumn = Table.Columns["Q1"].Ordinal + 1;
            }
            if (Preferencje["Savings"])
            {
                SavingsColumn = Table.Columns["S1"].Ordinal + 1;
            }
            if (Preferencje["ECCC"])
            {
                ECCColumn = Table.Columns["E1"].Ordinal + 1;
            }



            foreach (DataRow Row in Table.Rows)
            {
                Excel.Range CellStart = worksheet.Cells[Start, 2];
                Excel.Range CellFinish = worksheet.Cells[Start, ColumnCount];

                string[] ArryTable = Row.ItemArray.Select(x => x.ToString()).ToArray();
                worksheet.Range[CellStart, CellFinish].Value2 = ArryTable;

                ActionRowFormating(worksheet, Start, ColumnCount);

                if (Preferencje["Quantity"])
                {
                    for (int counter = 1; counter <= 13; counter++)
                    {
                        if (Row["Q" + counter.ToString()].ToString() == "")
                            EmptyCellCalculation(worksheet, Start, QuantityColumn + counter);
                    }
                }
                if (Preferencje["Savings"])
                {
                    for (int counter = 1; counter <= 13; counter++)
                    {
                        if (Row["S" + counter.ToString()].ToString() == "")
                            EmptyCellCalculation(worksheet, Start, SavingsColumn + counter);
                    }
                }
                if (Preferencje["ECCC"])
                {
                    for (int counter = 1; counter <= 13; counter++)
                    {
                        if (Row["E" + counter.ToString()].ToString() == "")
                            EmptyCellCalculation(worksheet, Start, ECCColumn + counter);
                    }
                }

                Start++;
            }

            return Start;
        }

        //Dodanie akcji do odpowiednich tabel
        private void AddActiontoTable(ref DataTable ActionRewizion, ref DataTable Tabela, string Devision, decimal YearToCalc, bool Actual, int MonthA)
        {
            foreach (KeyValuePair<string, bool> Akcja in Akcje)
            {
                DataRow ActionRow = ActionRewizion.NewRow();

                foreach (DataRow ActionRows in ActionRewizion.Rows)
                {
                    if (ActionRows["Name"].ToString() == Akcja.Key)
                    {
                        ActionRow.ItemArray = ActionRows.ItemArray;
                        break;
                    }
                }

                if (Akcja.Value)
                {
                    if (ActionRow["StartYear"].ToString() == YearToCalc.ToString())
                    {
                        if (Preferencje[Devision] && ActionRow["Group"].ToString() == Devision)
                        {
                            if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                            {
                                if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, !Actual);
                                    }
                                }
                                else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, !Actual);
                                    }
                                }
                            }
                            else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                            {
                                if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, !Actual);
                                    }
                                }
                                else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                {
                                    if (Akcje[ActionRow["Name"].ToString()])
                                    {
                                        CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, !Actual);
                                    }
                                }
                            }
                        }
                    }
                    if (Actual && !Preferencje["Actual"])
                    {
                        if (ActionRow["StartYear"].ToString() == "BU/" + Year.ToString())
                        {
                            if (Preferencje[Devision] && ActionRow["Group"].ToString() == Devision)
                            {
                                if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, false);
                                        }
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, false);
                                        }
                                    }
                                }
                                else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, false);
                                        }
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        if (Akcje[ActionRow["Name"].ToString()])
                                        {
                                            CreateRowAction(ActionRow, ref Tabela, "Ongoing", MonthA, false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        //Dodanie pojedynczej akcji do tabli która jest już zdefiniowana przez wybór użytkownika
        private void CreateRowAction(DataRow ActionRow, ref DataTable FinalActions, string Status, int MonthA, bool CarryOver)
        {
            if (ActionRow["Calculate"].ToString() == "ANC")
            {
                ANC _ANC = new ANC(ImportData, Preferencje);
                _ANC.PrepareANC(ActionRow, ref FinalActions, MonthA, CarryOver, Status);
            }
            else if (ActionRow["Calculate"].ToString() == "ANCSpec")
            {
                ANCSpec _ANCSpec = new ANCSpec(ImportData, Preferencje);
                _ANCSpec.PrepareANCSpec(ActionRow, ref FinalActions, MonthA, CarryOver, Status);
            }
            else if (ActionRow["Calculate"].ToString() == "PNC")
            {
                PNC _PNC = new PNC(ImportData, Preferencje);
                _PNC.PrepareANCSpec(ActionRow, ref FinalActions, MonthA, CarryOver, Status);
            }
            else if (ActionRow["Calculate"].ToString() == "PNCSpec")
            {
                PNCSpec _PNCSpec = new PNCSpec(ImportData, Preferencje);
                _PNCSpec.PrepareANCSpec(ActionRow, ref FinalActions, MonthA, CarryOver, Status);
            }

        }

        //Tworzenie column do DataTable dla poszczególnych devizji
        private void CreateColumn(ref DataTable Devision)
        {
            Devision.Columns.Add("Name");
            if (Preferencje["Description"])
            {
                Devision.Columns.Add("Description");
            }
            if (Preferencje["Status"])
            {
                Devision.Columns.Add("Status");
            }
            if (Preferencje["Platform"])
            {
                Devision.Columns.Add("Platform");
            }
            if (Preferencje["Old ANC"])
            {
                if (Preferencje["ANC Old"])
                {
                    Devision.Columns.Add("ANC Old");
                }
                if (Preferencje["Old IDCO"])
                {
                    Devision.Columns.Add("Old IDCO");
                }
                if (Preferencje["Old STK"])
                {
                    Devision.Columns.Add("Old STK");
                }
            }
            if (Preferencje["New ANC"])
            {
                if (Preferencje["ANC New"])
                {
                    Devision.Columns.Add("ANC New");
                }
                if (Preferencje["New IDCO"])
                {
                    Devision.Columns.Add("New IDCO");
                }
                if (Preferencje["New STK"])
                {
                    Devision.Columns.Add("New STK");
                }
            }
            if (Preferencje["Delta"])
            {
                Devision.Columns.Add("Delta");
            }

            if (Preferencje["Quantity"])
            {
                Devision.Columns.Add("Empty1");
                Devision.Columns.Add("Empty2");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("Q" + counter.ToString());
                }
            }

            if (Preferencje["Savings"])
            {
                Devision.Columns.Add("Empty3");
                Devision.Columns.Add("Empty4");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("S" + counter.ToString());
                }
            }

            if (Preferencje["ECCC"])
            {
                Devision.Columns.Add("Empty5");
                Devision.Columns.Add("Empty6");

                for (int counter = 1; counter < 14; counter++)
                {
                    Devision.Columns.Add("E" + counter.ToString());
                }
            }
        }

        //Ustawianie szerokości kolumn w Worksheet z akcjami 
        private int MultiActionColumn(Excel.Worksheet MultiAction)
        {
            int Column = 3;
            MultiAction.Columns[1].ColumnWidth = 4.88;
            MultiAction.Columns[2].ColumnWidth = 52.38;
            MultiAction.Rows[1].RowHeight = 37.50;
            MultiAction.Rows[2].RowHeight = 29.25;
            MultiAction.Rows[3].RowHeight = 53.25;
            AddHearetToTable(MultiAction, 2, "Name", "", false, true);

            if (Preferencje["Description"])
            {
                MultiAction.Columns[Column].ColumnWidth = 43.75;
                AddHearetToTable(MultiAction, Column, "Description", "", false, true);
                Column++;
            }
            if (Preferencje["Status"])
            {
                MultiAction.Columns[Column].ColumnWidth = 10.88;
                AddHearetToTable(MultiAction, Column, "Status", "", false, true);
                Column++;
            }
            if (Preferencje["Platform"])
            {
                MultiAction.Columns[Column].ColumnWidth = 8.88;
                AddHearetToTable(MultiAction, Column, "Platform", "", false, true);
                Column++;
            }
            if (Preferencje["Old ANC"])
            {
                int Small = 0;
                if (Preferencje["ANC Old"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    AddHearetToTable(MultiAction, Column, "ANC", "", false, true);
                    Small++;
                    Column++;
                }
                if (Preferencje["Old IDCO"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    AddHearetToTable(MultiAction, Column, "IDCO", "", false, true);
                    Small++;
                    Column++;
                }
                if (Preferencje["Old STK"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.75;
                    AddHearetToTable(MultiAction, Column, "STD", "", false, true);
                    Small++;
                    Column++;
                }
                if (Small != 0)
                {
                    AddHearetToTable(MultiAction, Column - Small, "", "Old ANC", false, true);
                    ScaleCells(MultiAction, Column, Small);
                }
            }
            if (Preferencje["New ANC"])
            {
                int Small = 0;
                if (Preferencje["ANC New"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    AddHearetToTable(MultiAction, Column, "ANC", "", false, true);
                    Small++;
                    Column++;
                }
                if (Preferencje["New IDCO"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 14.63;
                    AddHearetToTable(MultiAction, Column, "IDCO", "", false, true);
                    Small++;
                    Column++;
                }
                if (Preferencje["New STK"])
                {
                    MultiAction.Columns[Column].ColumnWidth = 6.75;
                    AddHearetToTable(MultiAction, Column, "STD", "", false, true);
                    Small++;
                    Column++;
                }
                if (Small != 0)
                {
                    AddHearetToTable(MultiAction, Column - Small, "", "Old ANC", false, true);
                    ScaleCells(MultiAction, Column, Small);
                }
            }
            if (Preferencje["Delta"])
            {
                MultiAction.Columns[Column].ColumnWidth = 8.75;
                AddHearetToTable(MultiAction, Column, "SAVING DW BU", "", false, true);
                Column++;
            }

            if (Preferencje["Quantity"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 7.40;
                    if (counter == 0)
                        AddHearetToTable(MultiAction, Column, Month2[counter], "DELIVERY QUANTITY", true, false);
                    else
                        AddHearetToTable(MultiAction, Column, Month2[counter], "", true, false);
                    Column++;
                }
                ScaleCells(MultiAction, Column, 13);
            }

            if (Preferencje["Savings"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 7.9;
                    if (counter == 0)
                        AddHearetToTable(MultiAction, Column, Month2[counter], "DELIVERY SAVINGS", true, false);
                    else
                        AddHearetToTable(MultiAction, Column, Month2[counter], "", true, false);
                    Column++;
                }
                ScaleCells(MultiAction, Column, 13);
            }

            if (Preferencje["ECCC"])
            {
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;
                MultiAction.Columns[Column].ColumnWidth = 1.63;
                Column++;

                for (int counter = 0; counter < 13; counter++)
                {
                    MultiAction.Columns[Column].ColumnWidth = 7.40;
                    if (counter == 0)
                        AddHearetToTable(MultiAction, Column, Month2[counter], "DELIVERY ECCC", true, false);
                    else
                        AddHearetToTable(MultiAction, Column, Month2[counter], "", true, false);
                    Column++;
                }
                ScaleCells(MultiAction, Column, 13);
            }

            return Column;
        }

        private void AddHearetToTable(Excel.Worksheet MultiAction, int column, string BottomText, string UpperText, bool Rotate, bool CenterTop)
        {

            //Top
            MultiAction.Cells[2, column].Style.Orientation = Excel.XlOrientation.xlHorizontal;
            MultiAction.Cells[2, column].Interior.Color = Color.FromArgb(242, 242, 242);
            MultiAction.Cells[2, column].Font.Color = Color.Black;
            MultiAction.Cells[2, column].Font.Size = 16;
            MultiAction.Cells[2, column].Font.Bold = true;
            MultiAction.Cells[2, column].Font.Name = "Arial";
            MultiAction.Cells[2, column].Style.WrapText = true;
            MultiAction.Cells[2, column].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiAction.Cells[2, column].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[2, column].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[2, column].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[2, column].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;

            if (UpperText != "")
                MultiAction.Cells[2, column].Value2 = UpperText;

            if (CenterTop)
                MultiAction.Cells[2, column].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Botton
            MultiAction.Cells[3, column].Interior.Color = Color.FromArgb(248, 203, 173);
            if (BottomText != "")
                MultiAction.Cells[3, column].Value2 = BottomText;

            if (Rotate)
            {
                MultiAction.Cells[3, column].Style.Orientation = Excel.XlOrientation.xlUpward;
            }

            MultiAction.Cells[3, column].Font.Size = 8;
            MultiAction.Cells[3, column].Font.Bold = true;
            MultiAction.Cells[3, column].Font.Name = "Arial";
            MultiAction.Cells[3, column].Style.WrapText = true;
            MultiAction.Cells[3, column].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiAction.Cells[3, column].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            MultiAction.Cells[3, column].Font.Color = Color.Black;
            MultiAction.Cells[3, column].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[3, column].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[3, column].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Cells[3, column].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
        }

        private void ScaleCells(Excel.Worksheet MultiAction, int column, int UpperScaleCount)
        {
            MultiAction.Range[MultiAction.Cells[2, column - UpperScaleCount], MultiAction.Cells[2, column - 1]].Merge();
        }

        private int CarryOverHeadre(Excel.Worksheet MultiAction, int ColumnUSE, int StartRow, string What, double[] Electronic, double[] Mechanic, double[] NVR, int ColumnForSavings)
        {
            Excel.Range CellStart = MultiAction.Cells[StartRow, 2];
            Excel.Range CellFinish = MultiAction.Cells[StartRow + 1, ColumnUSE];
            CellStart.Style.Orientation = Excel.XlOrientation.xlHorizontal;
            MultiAction.Range[CellStart, CellFinish].Font.Name = "Arial";
            MultiAction.Range[CellStart, CellFinish].Font.Size = 8;
            MultiAction.Rows[StartRow].RowHeight = 25.50;
            MultiAction.Rows[StartRow + 1].RowHeight = 12.75;
            CellStart.Value2 = What;
            CellStart.Font.Bold = true;
            CellStart.Font.Underline = true;
            CellStart.Font.Size = 10;
            MultiAction.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(250, 191, 143);
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

            if (Preferencje["Savings"])
            {
                double[] AllDevision = new double[13];
                CellStart = MultiAction.Cells[StartRow, ColumnForSavings];
                CellFinish = MultiAction.Cells[StartRow, ColumnForSavings + 12];

                for (int counter = 0; counter < 13; counter++)
                {
                    AllDevision[counter] = Electronic[counter] + Mechanic[counter] + NVR[counter];

                }
                string[] ArryTable = AllDevision.Select(x => x.ToString()).ToArray();
                MultiAction.Range[CellStart, CellFinish].Value2 = ArryTable;
                for (int counter = 0; counter < 13; counter++)
                {
                    Excel.Range Cell = MultiAction.Cells[StartRow, ColumnForSavings + counter];
                    if (MultiAction.Range[Cell, Cell].Find("*") != null)
                        MultiAction.Range[Cell, Cell].TextToColumns();
                }

                MultiAction.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";
            }

            return StartRow += 2;
        }

        private int DevisionHeader(Excel.Worksheet MultiAction, int ColumnUse, int StartRow, string Devision, double[] SumTable, int ColumforSavings)
        {
            Excel.Range CellStart = MultiAction.Cells[StartRow, 2];
            Excel.Range CellFinish = MultiAction.Cells[StartRow, ColumnUse];
            MultiAction.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(250, 191, 143);
            MultiAction.Range[CellStart, CellFinish].Font.Name = "Arial";
            MultiAction.Range[CellStart, CellFinish].Font.Size = 8;
            MultiAction.Rows[StartRow].RowHeight = 12.75;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

            CellStart.Value2 = Devision;
            CellStart.Font.Bold = true;
            CellStart.Font.Underline = true;
            CellStart.Font.Size = 10;

            if (Preferencje["Savings"])
            {
                CellStart = MultiAction.Cells[StartRow, ColumforSavings];
                CellFinish = MultiAction.Cells[StartRow, ColumforSavings + 12];
                string[] ArryTable = SumTable.Select(x => x.ToString()).ToArray();
                MultiAction.Range[CellStart, CellFinish].Value2 = ArryTable;


                for (int counter = 0; counter < 13; counter++)
                {
                    Excel.Range Cell = MultiAction.Cells[StartRow, ColumforSavings + counter];
                    if (MultiAction.Range[Cell, Cell].Find("*") != null)
                        MultiAction.Range[Cell, Cell].TextToColumns();
                }
                MultiAction.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";
            }
            return StartRow += 1;
        }

        private void ActionRowFormating(Excel.Worksheet MultiAction, int Row, int ColumnCount)
        {
            Excel.Range CellStart = MultiAction.Cells[Row, 2];
            Excel.Range CellFinish = MultiAction.Cells[Row, ColumnCount];
            MultiAction.Rows[Row].RowHeight = 9.75;
            MultiAction.Rows[Row].Font.Name = "Arial";
            MultiAction.Rows[Row].Font.Size = 8;
            MultiAction.Rows[Row].Font.Color = Color.Black;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
        }

        private void ActionRowFormatingMultiLine(Excel.Worksheet MultiAction, int RowStart, int RowFinish, int ColumnCount)
        {
            Excel.Range CellStart = MultiAction.Cells[RowStart, 2];
            Excel.Range CellFinish = MultiAction.Cells[RowFinish, ColumnCount];
            MultiAction.Range[CellStart, CellFinish].RowHeight = 9.75;
            MultiAction.Range[CellStart, CellFinish].Font.Name = "Arial";
            MultiAction.Range[CellStart, CellFinish].Font.Size = 8;
            MultiAction.Range[CellStart, CellFinish].Font.Color = Color.Black;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            MultiAction.Range[CellStart, CellFinish].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
        }

        private void EmptyCellCalculation(Excel.Worksheet MultiAction, int Row, int Column)
        {
            Excel.Range CellToChange = MultiAction.Cells[Row, Column];

            CellToChange.Interior.Color = Color.FromArgb(217, 217, 217);
        }

        private void TotalCellCalculation(Excel.Worksheet MultiAction, int Row, int Column)
        {
            Excel.Range CellToChange = MultiAction.Cells[Row, Column];

            CellToChange.Interior.Color = Color.FromArgb(226, 107, 10);
        }

        private void ConvertToNumber(Excel.Worksheet MultiAction, int ColumnStart, int RowStart, int RowFinish)
        {
            Excel.Range CellStart = MultiAction.Cells[RowStart, ColumnStart];
            Excel.Range CellFinish = MultiAction.Cells[RowFinish, ColumnStart];
            if (MultiAction.Range[CellStart, CellFinish].Find("*") != null)
                MultiAction.Range[CellStart, CellFinish].TextToColumns();
        }

        private void NumberFormatiog(Excel.Worksheet MultiAction, int ColumnStart, int ColumnFinish, int RowStart, int RowFinish)
        {
            Excel.Range CellStart = MultiAction.Cells[RowStart, ColumnStart];
            Excel.Range CellFinish = MultiAction.Cells[RowFinish, ColumnFinish];
            MultiAction.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";
            Excel.FormatCondition format = (Excel.FormatCondition)MultiAction.Range[CellStart, CellFinish].FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=ISBLANK(RC)");
            format.Interior.Color = Color.FromArgb(208, 206, 206);
        }

        private void NumberFormationgTotal(Excel.Worksheet MultiAction, int ColumnFinish, int RowStart, int RowFinish)
        {
            Excel.Range CellStart = MultiAction.Cells[RowStart, ColumnFinish];
            Excel.Range CellFinish = MultiAction.Cells[RowFinish, ColumnFinish];
            MultiAction.Range[CellStart, CellFinish].NumberFormat = "# ### ##0";
            MultiAction.Range[CellStart, CellFinish].Interior.Color = Color.FromArgb(250, 191, 143);
        }

        private void Center (Excel.Worksheet MultiAction, int ColumnStart, int RowStart, int RowFinish)
        {
            Excel.Range CellStart = MultiAction.Cells[RowStart, ColumnStart];
            Excel.Range CellFinish = MultiAction.Cells[RowFinish, ColumnStart];
            MultiAction.Range[CellStart, CellFinish].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        }

        private void SumAction(ref DataTable Action)
        {
            DataRow Master = null;
            bool FirstTime = false;

            foreach (DataRow Row in Action.Rows)
            {
                if (Row["Name"].ToString() != "")
                {
                    if (Master != null)
                    {
                        for (int counter = 1; counter <= 13; counter++)
                        {
                            if (Preferencje["Quantity"])
                                if (Master["Q" + counter.ToString()].ToString() == "0")
                                {
                                    Master["Q" + counter.ToString()] = "";
                                }
                            if (Preferencje["Savings"])
                                if (Master["S" + counter.ToString()].ToString() == "0")
                                {
                                    Master["S" + counter.ToString()] = "";
                                }
                            if (Preferencje["ECCC"])
                                if (Master["E" + counter.ToString()].ToString() == "0")
                                {
                                    Master["E" + counter.ToString()] = "";
                                }

                        }
                    }
                    Master = Row;
                    FirstTime = true;
                }
                else
                {
                    if (FirstTime)
                    {
                        for (int counter = 1; counter <= 13; counter++)
                        {
                            if (Preferencje["Quantity"])
                            {
                                Master["Q" + counter.ToString()] = 0;
                            }
                            if (Preferencje["Savings"])
                            {
                                Master["S" + counter.ToString()] = 0;
                            }
                            if (Preferencje["ECCC"])
                            {
                                Master["E" + counter.ToString()] = 0;
                            }
                        }
                        FirstTime = false;
                    }
                    if (Master != null)
                    {
                        for (int counter = 1; counter <= 13; counter++)
                        {
                            if (Preferencje["Quantity"])
                            {
                                if (Row["Q" + counter.ToString()].ToString() != "")
                                    Master["Q" + counter.ToString()] = double.Parse(Master["Q" + counter.ToString()].ToString()) + double.Parse(Row["Q" + counter.ToString()].ToString());
                            }
                            if (Preferencje["Savings"])
                            {
                                if (Row["S" + counter.ToString()].ToString() != "")
                                    Master["S" + counter.ToString()] = double.Parse(Master["S" + counter.ToString()].ToString()) + double.Parse(Row["S" + counter.ToString()].ToString());
                            }
                            if (Preferencje["ECCC"])
                            {
                                if (Row["E" + counter.ToString()].ToString() != "")
                                    Master["E" + counter.ToString()] = double.Parse(Master["E" + counter.ToString()].ToString()) + double.Parse(Row["E" + counter.ToString()].ToString());
                            }
                        }
                    }
                    if(Action.Rows.IndexOf(Row) == Action.Rows.Count-1)
                    {
                        for (int counter = 1; counter <= 13; counter++)
                        {
                            if (Preferencje["Quantity"])
                                if (Master["Q" + counter.ToString()].ToString() == "0")
                                {
                                    Master["Q" + counter.ToString()] = "";
                                }
                            if (Preferencje["Savings"])
                                if (Master["S" + counter.ToString()].ToString() == "0")
                                {
                                    Master["S" + counter.ToString()] = "";
                                }
                            if (Preferencje["ECCC"])
                                if (Master["E" + counter.ToString()].ToString() == "0")
                                {
                                    Master["E" + counter.ToString()] = "";
                                }

                        }
                    }
                }

            }
        }

        private double[] SumAllDevision(DataTable Action)
        {
            double[] Devision = new double[13];

            foreach (DataRow Row in Action.Rows)
            {
                if (Row["Name"].ToString() != "")
                {
                    for (int counter = 1; counter <= 13; counter++)
                    {
                        if (Row["S" + counter].ToString() != "")
                            Devision[counter - 1] = Devision[counter - 1] + double.Parse(Row["S" + counter].ToString());
                    }
                }
            }
            return Devision;
        }
    }
}
