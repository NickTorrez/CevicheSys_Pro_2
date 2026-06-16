using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    ///Controlador de lógica de negocio para la gestión de usuarios y autenticación.
    /// </summary>
    public class UserBusiness
    {
        private readonly User user = new User();

        public User AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return user.Authenticate(username.Trim(), password);
        }

        public int InsertUser(User newUser)
        {
            if (newUser == null) return 1;
            if (string.IsNullOrWhiteSpace(newUser.Username)) return 2;
            if (string.IsNullOrWhiteSpace(newUser.Password)) return 3;
            if (string.IsNullOrWhiteSpace(newUser.Role)) return 4;

            newUser.Username = newUser.Username.Trim();
            newUser.Role = newUser.Role.Trim();
            newUser.Enable = true;

            return newUser.AddUser() > 0 ? 0 : 5;
        }

        public int UpdateUser(User modifiedUser)
        {
            if (modifiedUser == null || modifiedUser.User_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedUser.Username)) return 2;
            if (string.IsNullOrWhiteSpace(modifiedUser.Password)) return 3;
            if (string.IsNullOrWhiteSpace(modifiedUser.Role)) return 4;

            modifiedUser.Username = modifiedUser.Username.Trim();
            modifiedUser.Role = modifiedUser.Role.Trim();

            return modifiedUser.UpdateUser() > 0 ? 0 : 5;
        }

        public int DisableUser(int id)
        {
            if (id <= 0) return 1;
            return user.DisableUser(id) > 0 ? 0 : 5;
        }

        public List<User> ListUsers()
        {
            return user.ListAllUsers();
        }
    }
    
}
