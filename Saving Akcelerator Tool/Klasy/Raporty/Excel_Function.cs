using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace Saving_Accelerator_Tool
{
    class Excel_Function
    {
        Worksheet worksheet;

        public Excel_Function(Worksheet worksheet)
        {
            this.worksheet = worksheet;
        }

        public void Add_Cells(int Row, int Column, string Name, int Size, bool Bold, string Font, bool Middel)
        {
            Range Cell = worksheet.Cells[Row, Column];
            Cell.Value = Name;
            Cell.Style.Font.Size = Size;
            Cell.Font.Bold = Bold;
            Cell.Style.Font.Name = Font;
            if (Middel)
            {
                Cell.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
        }

        public void Add_Cells(string Cell, string Name, int Size, bool Bold, string Font, bool Middel)
        {
            Range Cells = worksheet.Cells[Cell];
            Cells.Value = Name;
            Cells.Style.Font.Size = Size;
            Cells.Font.Bold = Bold;
            Cells.Style.Font.Name = Font;
            if (Middel)
            {
                Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
        }

        public void Cells_Borders(int Row, int Column, bool Top, bool TopBig, bool Botton, bool BottonBig, bool Right, bool RightBig, bool Left, bool LeftBig)
        {
            Range Cell = worksheet.Cells[Row, Column];

            if (Top)
            {
                Cell.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                if (TopBig)
                {
                    Cell.Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
                }
            }
            if (Botton)
            {
                Cell.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                if (BottonBig)
                {
                    Cell.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
                }
            }
            if (Right)
            {
                Cell.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                if (RightBig)
                {
                    Cell.Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
                }
            }
            if (Left)
            {
                Cell.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                if (LeftBig)
                {
                    Cell.Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
                }
            }
        }

        public void Cells_Borders(string Cell, bool Top, bool TopBig, bool Botton, bool BottonBig, bool Right, bool RightBig, bool Left, bool LeftBig)
        {
            Range Cells = worksheet.Cells[Cell];

            if (Top)
            {
                Cells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                if (TopBig)
                {
                    Cells.Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
                }
            }
            if (Botton)
            {
                Cells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                if (BottonBig)
                {
                    Cells.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
                }
            }
            if (Right)
            {
                Cells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                if (RightBig)
                {
                    Cells.Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
                }
            }
            if (Left)
            {
                Cells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                if (LeftBig)
                {
                    Cells.Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
                }
            }
        }

        public void Range_Borders(string StartCell, string StopCell, bool BigBorderOutside, bool BigBorderInside)
        {
            Range Cell = worksheet.Range[StartCell, StopCell];
            Cell.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            Cell.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            Cell.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            Cell.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            Cell.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            Cell.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

            if (BigBorderOutside)
            {
                Cell.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
                Cell.Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
                Cell.Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
                Cell.Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
            }
            if (BigBorderInside)
            {
                Cell.Borders[XlBordersIndex.xlInsideHorizontal].Weight = 3;
                Cell.Borders[XlBordersIndex.xlInsideVertical].Weight = 3;
            }
        }

        public void Columns_Width(string Column, double Widht)
        {
            worksheet.Columns[Column].ColumnWidth = Widht;
        }
    }
}
