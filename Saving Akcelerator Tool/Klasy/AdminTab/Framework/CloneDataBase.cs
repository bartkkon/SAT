using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework
{
    public class CloneDataBase
    {

        public CloneDataBase()
        {
            CloneBase();
        }


        private void CloneBase()
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
            Temp2 += Date;
            File.Move(Temp1, Temp2);
        }
    }
}
