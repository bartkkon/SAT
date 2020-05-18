using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access;
using System.Windows.Forms;
using System.Globalization;
using Saving_Accelerator_Tool.Controllers.Excptions;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class AddPersonController
    {
        public static bool AddUser()
        {
            while (true)
            {
                try
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
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static UserDB ReturnUser(string UserLogin)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();

                    UserDB user = context.Users.Where(u => u.Login == UserLogin).FirstOrDefault();

                    if (user != null)
                        return user;

                    return null;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static bool DeleteUser(string UserLogin)
        {
            while (true)
            {
                try
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
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void UpdatePerson(UserDB UpdateUsers)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    context.Users.Update(UpdateUsers);
                    context.SaveChanges();
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void Refresh()
        {
            while (true)
            {
                try
                {
                    var users = GetUsers();

                    MainProgram.Self.addPersonView.ClearAllLogin();

                    foreach (var user in users)
                    {
                        MainProgram.Self.addPersonView.SetAllLogin(user.Login);
                    }
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static void PersonLoad(string SelectedLogin)
        {
            while (true)
            {
                try
                {
                    var context = new DataBaseConnectionContext();
                    UserDB user = context.Users.Where(u => u.Login == SelectedLogin).FirstOrDefault();

                    _ = new LoadPerson(user);
                    return;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }

        public static IEnumerable<UserDB> GetUsers()
        {
            while (true)
            {
                try
                {
                    var _context = new DataBaseConnectionContext();
                    List<UserDB> users = new List<UserDB>();
                    foreach (UserDB user in _context.Users)
                    {
                        users.Add(user);
                    }
                    return users;
                }
                catch
                {
                    NoConnection.Info();
                }
            }
        }
    }
}
