using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Framework
{
    class GroupingPNC
    {
        private readonly decimal _Year;
        private readonly decimal _Month;
        private readonly string _Rev;
        private DataTable PNC = new DataTable();
        private DataTable SumPNC = new DataTable();

        public GroupingPNC(decimal Year, decimal Month)
        {

            _Year = Year;
            _Month = Month;
        }

        public GroupingPNC(decimal Year, string Rev)
        {
            _Year = Year;
            _Rev = Rev;
        }

        public void GrupingPNC_Month()
        {
            decimal All = 0;
            decimal DMD = 0;
            decimal D45 = 0;
            decimal DMD_FS = 0;
            decimal D45_FS = 0;
            decimal DMD_FI = 0;
            decimal D45_FI = 0;
            decimal DMD_BI = 0;
            decimal D45_BI = 0;
            decimal DMD_FSBU = 0;
            decimal D45_FSBU = 0;

            Data_Import.Singleton().Load_TxtToDataTable2(ref PNC, "PNCMonth");

            Data_Import.Singleton().Load_TxtToDataTable2(ref SumPNC, "SumPNC");

            if (!PNC.Columns.Contains(_Month.ToString() + "/" + _Year.ToString()))
            {
                MessageBox.Show("Missing Data for: " + _Month.ToString() + "/" + _Year.ToString(), "Attention!");
                return;
            }

            if (SumPNC.Columns.Contains(_Month.ToString() + "/" + _Year.ToString()))
            {
                SumPNC.Columns.Remove(_Month.ToString() + "/" + _Year.ToString());
            }
            SumPNC.Columns.Add(_Month.ToString() + "/" + _Year.ToString());

            foreach (DataRow PNCRow in PNC.Rows)
            {
                if (PNCRow[_Month.ToString() + "/" + _Year.ToString()] != null && PNCRow[_Month.ToString() + "/" + _Year.ToString()].ToString() != "")
                {
                    decimal Value = decimal.Parse(PNCRow[_Month.ToString() + "/" + _Year.ToString()].ToString());
                    string PNC = PNCRow["PNC"].ToString();

                    //Dodanie do sumy wszystkich PNC
                    All += Value;

                    //Rozbiecie na DMD i D45
                    if (PNC.Remove(0, 3).Remove(1, 5) == "5")
                    {
                        //Dodanie do Sumy DMD
                        DMD += Value;

                        //Sprawdzenie czy FS, FI, BI/BU lub FSBU

                        switch (PNC.Remove(0,4).Remove(1,4))
                        {
                            case "1":
                                DMD_FS += Value;
                                break;
                            case "2":
                                DMD_BI += Value;
                                break;
                            case "3":
                                DMD_FI += Value;
                                break;
                            case "4":
                                DMD_FSBU += Value;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //Dodanie do Sumy D45
                        D45 += Value;

                        switch (PNC.Remove(0, 4).Remove(1, 4))
                        {
                            case "5":
                                D45_FS += Value;
                                break;
                            case "6":
                                D45_BI += Value;
                                break;
                            case "7":
                                D45_FI += Value;
                                break;
                            case "8":
                                D45_FSBU += Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            foreach( DataRow Row in SumPNC.Rows)
            {
                switch (Row["PNC"].ToString())
                {
                    case "All":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = All;
                        break;
                    case "DMD":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = DMD;
                        break;
                    case "D45":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = D45;
                        break;
                    case "DMD_FS":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = DMD_FS;
                        break;
                    case "D45_FS":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = D45_FS;
                        break;
                    case "DMD_FI":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = DMD_FI;
                        break;
                    case "D45_FI":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = D45_FI;
                        break;
                    case "DMD_BI":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = DMD_BI;
                        break;
                    case "D45_BI":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = D45_BI;
                        break;
                    case "DMD_FSBU":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = DMD_FSBU;
                        break;
                    case "D45_FSBU":
                        Row[_Month.ToString() + "/" + _Year.ToString()] = D45_FSBU;
                        break;
                    default:
                        break;
                }
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref SumPNC, "SumPNC");
        }

        public void GrupingPNC_Revision()
        {
            int StartMonth;
            decimal All = 0;
            decimal DMD = 0;
            decimal D45 = 0;
            decimal DMD_FS = 0;
            decimal D45_FS = 0;
            decimal DMD_FI = 0;
            decimal D45_FI = 0;
            decimal DMD_BI = 0;
            decimal D45_BI = 0;
            decimal DMD_FSBU = 0;
            decimal D45_FSBU = 0;

            Data_Import.Singleton().Load_TxtToDataTable2(ref PNC, "PNC");

            Data_Import.Singleton().Load_TxtToDataTable2(ref SumPNC, "SumPNCBU");

            switch (_Rev)
            {
                case "BU":
                    StartMonth = 1;
                    break;
                case "EA1":
                    StartMonth = 3;
                    break;
                case "EA2":
                    StartMonth = 6;
                    break;
                case "EA3":
                    StartMonth = 9;
                    break;
                default:
                    StartMonth = 0;
                    break;
            }
            if (StartMonth == 0)
                return;

            for (; StartMonth <= 12; StartMonth++)
            {
                if (!PNC.Columns.Contains(_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()))
                {
                    MessageBox.Show("Missing Data for: " + _Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString(), "Attention!");
                    return;
                }

                if (SumPNC.Columns.Contains(_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()))
                {
                    SumPNC.Columns.Remove(_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString());
                }
                SumPNC.Columns.Add(_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString());

                foreach (DataRow PNCRow in PNC.Rows)
                {
                    if (PNCRow[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] != null && PNCRow[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()].ToString() != "")
                    {
                        decimal Value = decimal.Parse(PNCRow[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()].ToString());
                        string PNC = PNCRow["BUPNC"].ToString();

                        //Dodanie do sumy wszystkich PNC
                        All += Value;

                        //Rozbiecie na DMD i D45
                        if (PNC.Remove(0, 3).Remove(1, 5) == "5")
                        {
                            //Dodanie do Sumy DMD
                            DMD += Value;

                            //Sprawdzenie czy FS, FI, BI/BU lub FSBU

                            switch (PNC.Remove(0, 4).Remove(1, 4))
                            {
                                case "1":
                                    DMD_FS += Value;
                                    break;
                                case "2":
                                    DMD_BI += Value;
                                    break;
                                case "3":
                                    DMD_FI += Value;
                                    break;
                                case "4":
                                    DMD_FSBU += Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            //Dodanie do Sumy D45
                            D45 += Value;

                            switch (PNC.Remove(0, 4).Remove(1, 4))
                            {
                                case "5":
                                    D45_FS += Value;
                                    break;
                                case "6":
                                    D45_BI += Value;
                                    break;
                                case "7":
                                    D45_FI += Value;
                                    break;
                                case "8":
                                    D45_FSBU += Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                foreach (DataRow Row in SumPNC.Rows)
                {
                    switch (Row["PNC"].ToString())
                    {
                        case "All":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = All;
                            break;
                        case "DMD":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = DMD;
                            break;
                        case "D45":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = D45;
                            break;
                        case "DMD_FS":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = DMD_FS;
                            break;
                        case "D45_FS":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = D45_FS;
                            break;
                        case "DMD_FI":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = DMD_FI;
                            break;
                        case "D45_FI":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = D45_FI;
                            break;
                        case "DMD_BI":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = DMD_BI;
                            break;
                        case "D45_BI":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = D45_BI;
                            break;
                        case "DMD_FSBU":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = DMD_FSBU;
                            break;
                        case "D45_FSBU":
                            Row[_Rev + "/" + StartMonth.ToString() + "/" + _Year.ToString()] = D45_FSBU;
                            break;
                        default:
                            break;
                    }
                }

                All = 0;
                DMD = 0;
                D45 = 0;
                DMD_BI = 0;
                DMD_FI = 0;
                DMD_FS = 0;
                DMD_FSBU = 0;
                D45_BI = 0;
                D45_FI = 0;
                D45_FS = 0;
                D45_FSBU = 0;
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref SumPNC, "SumPNCBU");
        }

    }
}
