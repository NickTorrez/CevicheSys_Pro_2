using CevicheSys_Pro_2;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de la lógica de negocio para la gestión de usuarios.
    /// </summary>
    public class UserBusiness
    {
        private readonly Users _userDomain = new Users();

        public Users AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("El nombre de usuario es requerido para la autenticación.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña de acceso es requerida para la autenticación.");

            Users user = _userDomain.Authenticate(username.Trim(), password);
            if (user == null)
                throw new InvalidOperationException("Credenciales inválidas o el usuario se encuentra deshabilitado.");

            return user;
        }

        public DataTable ListUsers()
        {
            return _userDomain.ListAllUsers();
        }

        public void InsertUser(Users newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser), "El objeto de usuario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(newUser.Username))
                throw new ArgumentException("El nombre de usuario es un campo obligatorio.");

            if (string.IsNullOrWhiteSpace(newUser.Password))
                throw new ArgumentException("La contraseña de acceso es obligatoria.");

            if (string.IsNullOrWhiteSpace(newUser.Role))
                throw new ArgumentException("Debe asignar un rol válido al usuario.");

            if (_userDomain.ExistsByUsername(newUser.Username.Trim(), 0))
                throw new ArgumentException($"El nombre de usuario '{newUser.Username}' ya se encuentra registrado.");

            newUser.Username = newUser.Username.Trim();
            newUser.Enable = true;

            int rowsAffected = newUser.InsertUser();
            if (rowsAffected <= 0)
                throw new Exception("Ocurrió un error inesperado en el almacenamiento de datos; el usuario no fue registrado.");
        }

        public void UpdateUser(Users existingUser)
        {
            if (existingUser == null)
                throw new ArgumentNullException(nameof(existingUser), "El objeto de usuario a actualizar no puede ser nulo.");

            if (existingUser.User_Id <= 0)
                throw new ArgumentException("El ID del usuario proporcionado no es válido.");

            if (string.IsNullOrWhiteSpace(existingUser.Username))
                throw new ArgumentException("El nombre de usuario no puede ser un valor vacío.");

            if (string.IsNullOrWhiteSpace(existingUser.Role))
                throw new ArgumentException("Debe especificar un rol de sistema para la actualización.");

            if (_userDomain.ExistsByUsername(existingUser.Username.Trim(), existingUser.User_Id))
                throw new ArgumentException($"El nombre de usuario '{existingUser.Username}' ya está siendo utilizado por otra cuenta.");

            existingUser.Username = existingUser.Username.Trim();

            int rowsAffected = existingUser.UpdateUser();
            if (rowsAffected <= 0)
                throw new Exception("No se pudo actualizar la información del usuario en la base de datos.");
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Debe especificar un ID de usuario válido para la eliminación lógica.");

            Users userToDelete = new Users { User_Id = userId };
            int rowsAffected = userToDelete.DeleteUser();

            if (rowsAffected <= 0)
                throw new Exception("No se pudo completar la deshabilitación lógica del usuario especificado.");
        }
    }

}
