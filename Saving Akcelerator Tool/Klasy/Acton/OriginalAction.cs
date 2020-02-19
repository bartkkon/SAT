using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    public class OriginalAction : Action
    {
        private static OriginalAction _instance;
        private static readonly object syncRoot = new object();

        public static OriginalAction Value
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                        if (_instance == null)
                        {
                            _instance = new OriginalAction();
                        }
                }
                return _instance;
            }
        }

        public static OriginalAction Delete
        {
            get
            {
                if (_instance != null)
                {
                    lock (syncRoot)
                        if (_instance != null)
                        {
                            _instance = null;
                        }
                }
                return _instance;
            }
        }
    }
}
