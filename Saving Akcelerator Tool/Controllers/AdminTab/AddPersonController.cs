using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class AddPersonController
    {
        public static bool AddUser()
        {
            var context = new DataBaseConnectionContext();
            var user = new UserDB
            {
                Login = MainProgram.Self.addPersonView.GetUserName(),
            };
            context.Add(user);
            context.SaveChanges();
            return true;
        }

        public static UserDB ReturnUser(string UserLogin)
        {
            var context = new DataBaseConnectionContext();
            UserDB user = context.Users.Where(u => u.Login == UserLogin).FirstOrDefault();

            if (user != null)
                return user;

            return null;
        }

        public static bool DeleteUser(string UserLogin)
        {
            var context = new DataBaseConnectionContext();
            UserDB user = context.Users.Where(u => u.Login == UserLogin).FirstOrDefault();

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public static void UpdatePerson(UserDB UpdateUsers)
        {
            var context = new DataBaseConnectionContext();
            context.Users.Update(UpdateUsers);
            context.SaveChanges();
        }

        public static void Refresh()
        {
            var users = GetUsers();

            MainProgram.Self.addPersonView.ClearAllLogin();

            foreach (var user in users)
            {
                MainProgram.Self.addPersonView.SetAllLogin(user.Login);
            }
        }

        public static void PersonLoad(string SelectedLogin)
        {
            var context = new DataBaseConnectionContext();
            UserDB user = context.Users.Where(u => u.Login == SelectedLogin).FirstOrDefault();

            _ = new LoadPerson(user);
        }

        private static IEnumerable<UserDB> GetUsers()
        {
            var _context = new DataBaseConnectionContext();
            List<UserDB> users = new List<UserDB>();
            foreach (UserDB user in _context.Users)
            {
                users.Add(user);
            }
            return users;
        }
    }
}
