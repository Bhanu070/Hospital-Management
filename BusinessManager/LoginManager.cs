using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using  DataLayer;

namespace BusinessManager
{
    // Created By Javed Akhtar
   public class LoginManager
    {
        public static void Add(Login login)
        {
            if (login == null)
                throw new ArgumentException("Login is null.");
            LoginDB.Add(login);
        }

        public static void Update(Login login)
        {
            if (login == null)
                throw new ArgumentException("Login is null.");
            if (login.Id == null || login.Id == default(Guid))
                throw new ArgumentException("Login.Id value not set.");
            LoginDB.Update(login);
        }

        public static void UpdatePassword(Login login)
        {
            if (login == null)
                throw new ArgumentException("rresult is null.");
            if (login.Id == null || login.Id == default(Guid))
                throw new ArgumentException("login.Id value not set.");
            LoginDB.UpdatePassword(login);
        }


        public static void Delete(Login login)
        {
            if (login == null)
                throw new ArgumentException("Login is null.");
            if (login.Id == null || login.Id == default(Guid))
                throw new ArgumentException("Login.Id value not set.");
            LoginDB.Delete(login);
        }
        public static Login GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Login login = null;
            login = LoginDB.GetById(id);
            return login;
        }

        public static List<Login> GetAll()
        {
            return LoginDB.GetAll();
        }
        public static List<Login> GetAllDelete()
        {
            return LoginDB.GetAllDelete();
        }
        public static Login RecoverPassword(string Email)
        {
            if (Email == default(string))
                throw new ArgumentException("Email is set to default value.");
            Login login = null;
            login = LoginDB.RecoverPassword(Email);
            return login;
        }

        public static Login Login(string Name, string Password)
        {
            return LoginDB.Login(Name, Password);
        }

        public static Login GetById_UserWise(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Login login = null;
            login = LoginDB.GetById_UserWise(id);
            return login;
        }
    }
}
