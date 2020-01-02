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

        protected Users()
        {
        }

        public static Users Singleton()
        {
            if (_instance == null)
            {
                _instance = new Users();
            }
            return _instance;
        }
    }
}
