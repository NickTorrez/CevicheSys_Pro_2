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
        private User user;

        public UserBusiness()
        {
            user = new User();
        }

        /// <summary>
        /// Valida las credenciales de acceso.
        /// </summary>
        public User AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return user.Authenticate(username, password);
        }

        public int InsertUser(User newUser)
        {
            // Filtros de negocio
            if (newUser == null) return 1; // Error genérico de objeto nulo
            if (string.IsNullOrWhiteSpace(newUser.Username)) return 2; // El usuario es obligatorio
            if (string.IsNullOrWhiteSpace(newUser.Password)) return 3; // La contraseña es obligatoria

            // Ejecución del dominio
            if (newUser.AddUser() > 0)
                return 0; // Éxito
            else
                return 4; // Error al insertar en la base de datos
        }

        public int UpdateUser(User modifiedUser)
        {
            if (modifiedUser == null || modifiedUser.User_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedUser.Username)) return 2;

            if (modifiedUser.UpdateUser() > 0)
                return 0; // Éxito
            else
                return 4; // Error al actualizar en la base de datos
        }

        public int DisableUser(int id)
        {
            if (id <= 0) return 1;

            if (user.DisableUser(id) > 0)
                return 0;
            else
                return 4;
        }

        public List<User> ListUsers()
        {
            return user.ListAllUsers();
        }
    }
    
}
