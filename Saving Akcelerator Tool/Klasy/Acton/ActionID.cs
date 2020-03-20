using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Acton
{
    class ActionID : IDAction
    {
        private static ActionID _instance;
        private static readonly object syncRoot = new object();

        public static ActionID Singleton
        {
            get
            {
                if(_instance ==null)
                {
                    lock(syncRoot)
                        if(_instance == null)
                        {
                            _instance = new ActionID();
                        }
                }
                return _instance;
            }
        }

    }
}
