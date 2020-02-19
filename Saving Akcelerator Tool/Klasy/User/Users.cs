using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.User
{
    public class Users : User
    {
        private static Users _instance;
        private static readonly object syncRoot = new object();

        protected Users()
        {
        }

        public static Users Singleton
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                        if (_instance == null)
                        {
                            _instance = new Users();
                            _ = new CreateUsers(Data_Import.Singleton().Load_Access());
                        }
                }
                return _instance;
            }
        }
    }
}
