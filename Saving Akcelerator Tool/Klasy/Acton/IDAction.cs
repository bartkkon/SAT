using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    class IDAction
    {
        //Bierzące ID Akcji załadowanej, Jęśli jest nowa akcja będzei 0
        public int ID { get; set; }
        public string Status { get; set; }
        //Jęśli została wproadzona jakaś zmiana w górnym panelu akcji to wartość jest ustawiana na true
        public bool ActionModification { get; set; }
        //Jeśli została wprowadzona jakaś zmiana w ANC liście to wartość ustawiana na true
        public bool ANCModification { get; set; }
        //Jeśli został zmieniony system liczenia to wartość jest ustawiona na true
        public bool CalcModification { get; set; }
        //Jeśli została wprowazona zmiana w liczeniu Mass lub zostało zmienione na Mass to watość jest ustawiona na True
        public bool MassModification { get; set; }
        //Jęli zostały prowadzone jakieś zmiany w PNC list to wartość jest ustawiana na true.
        //Jeśli został pierwszy raz wybrany ten sposób liczenia 
        public bool PNCModification { get; set; }
        //Jęli zostały prowadzone jakieś zmiany w PNC list to wartość jest ustawiana na true.
        //Jeśli został pierwszy raz wybrany ten sposób liczenia 
        public bool PNCSpecModification { get; set; }
    }
}
