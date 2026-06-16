using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.UI.Catalogs;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de la lógica de negocio para la gestión de usuarios.
    /// </summary>
    public class UserBusiness
    {
        private readonly User _userDomain = new User();

        public User AuthenticateUser(string username, string password)
        {
            // Validación básica de nulidad antes de tocar la base de datos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // Llamada al método de persistencia en la clase Domain (User.cs)
            // Este método ejecuta el SELECT y devuelve una instancia de User o null.
            return _userDomain.Authenticate(username.Trim(), password);
        }

        public System.Collections.Generic.List<User> ListUsers()
        {
            return _userDomain.ListAllUsers();
        }

        /// <summary>
        /// Valida y procesa el registro de un nuevo usuario en el sistema.
        /// </summary>
        /// <returns>
        /// 0 = Éxito.
        /// 1 = El objeto de usuario es nulo.
        /// 2 = Nombre de usuario o contraseña vacíos.
        /// 3 = Formato de nombre de usuario inválido.
        /// 4 = El nombre de usuario ya se encuentra registrado.
        /// 5 = Error al guardar en la base de datos.
        /// </returns>
        public int InsertUser(User newUser)
        {
            // 1. Validación de nulidad estructural
            if (newUser == null) return 1;

            // 2. Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(newUser.Username) || string.IsNullOrWhiteSpace(newUser.Password))
                return 2;

            // 3. Validación de formatos internos de la entidad
            if (!newUser.ValidateUsernameFormat())
                return 3;

            // 4. Validación de regla de negocio (No duplicados en BD)
            // Se usa una instancia limpia o el método estático/instancia de la entidad de dominio
            if (_userDomain.ExistsByUsername(newUser.Username))
                return 4;

            // 5. Si pasa todas las reglas, se ordena al dominio persistir los datos
            bool success = newUser.InsertUser();

            return success ? 0 : 5;
        }

        /// <summary>
        /// Valida y procesa la modificación de un usuario existente.
        /// </summary>
        /// <returns>
        /// 0 = Éxito.
        /// 1 = El objeto es nulo o ID inválido.
        /// 2 = Nombre de usuario o Rol vacíos.
        /// 4 = El nombre de usuario ya está ocupado por otra cuenta.
        /// 5 = Error al actualizar en la base de datos.
        /// </returns>
        public int UpdateUser(User existingUser)
        {
            if (existingUser == null || existingUser.User_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(existingUser.Username) || string.IsNullOrWhiteSpace(existingUser.Role)) return 2;

            // Validar que el nuevo nombre no choque con otro usuario de la BD
            if (_userDomain.ExistsByUsername(existingUser.Username, existingUser.User_Id))
                return 4;

            bool success = existingUser.UpdateUser();
            return success ? 0 : 5;
        }

        /// <summary>
        /// Coordina la eliminación lógica de un usuario.
        /// </summary>
        public int DeleteUser(int userId)
        {
            if (userId <= 0) return 1;

            User userToDelete = new User { User_Id = userId };
            bool success = userToDelete.DeleteUser();

            return success ? 0 : 5;
        }
    }

}
