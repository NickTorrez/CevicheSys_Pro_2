using CevicheSys_Pro_2.Services.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Almacena la información de acceso y los privilegios asignados al personal de la cevichería.
    /// </summary>
    public class User
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad (Mapeo SQL Server)                          */
        /* --------------------------------------------------------------------- */
        public int User_Id { get; set; }        // Id_Usuario (PK)
        public string Username { get; set; }    // Nombre_Usuario
        public string Password { get; set; }    // Contraseña
        public string Role { get; set; }        // Rol ("Admin" o "Vendedor")
        public bool Enable { get; set; }       // Enable (Borrado lógico)

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa una nueva instancia de la clase User con valores por defecto.
        /// </summary>
        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
            Enable = true;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase User con los datos especificados.
        /// </summary>
        public User(int userId, string username, string password, string role, bool enable = true)
        {
            User_Id = userId;
            Username = username;
            Password = password;
            Role = role;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Validación e Internos                                      */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Verifica si el usuario actual posee privilegios de Administrador.
        /// </summary>
        public bool IsAdmin()
        {
            return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Aplica criptografía SHA-256 a la cadena de texto proporcionada para proteger contraseñas.
        /// </summary>
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                foreach (byte item in bytes)
                    builder.Append(item.ToString("x2"));

                return builder.ToString();
            }
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD SQL Server)                             */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Autentica al usuario comparando el Hash de su contraseña con el registro en base de datos.
        /// </summary>
        public User Authenticate(string username, string password)
        {
            string query = @"SELECT User_Id, Username, Password, Role, Enable
                             FROM Users
                             WHERE Username = @user AND Password = @pass AND Enable = 1";

            SqlParameter[] parameters =
            {
                new SqlParameter("@user", username),
                new SqlParameter("@pass", ComputeSha256Hash(password))
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return new User(
                    Convert.ToInt32(row["User_Id"]),
                    row["Username"].ToString(),
                    row["Password"].ToString(),
                    row["Role"].ToString(),
                    Convert.ToBoolean(row["Enable"])
                );
            }
        }

        /// <summary>
        /// Recupera la lista completa de usuarios activos en el sistema.
        /// </summary>
        public List<User> ListAllUsers()
        {
            List<User> list = new List<User>();
            string query = "SELECT User_Id, Username, Password, Role, Enable FROM Users WHERE Enable = 1";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new User(
                        Convert.ToInt32(row["User_Id"]),
                        row["Username"].ToString(),
                        row["Password"].ToString(),
                        row["Role"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }

            return list;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos aplicando encriptación a la contraseña.
        /// </summary>
        public int AddUser()
        {
            string query = @"INSERT INTO Users (Username, Password, Role, Enable)
                             VALUES (@username, @password, @role, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@username", Username),
                new SqlParameter("@password", ComputeSha256Hash(Password)),
                new SqlParameter("@role", Role),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente, sobreescribiendo su Hash de contraseña.
        /// </summary>
        public int UpdateUser()
        {
            string query = @"UPDATE Users
                             SET Username = @username, Password = @password, Role = @role
                             WHERE User_Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", User_Id),
                new SqlParameter("@username", Username),
                new SqlParameter("@password", ComputeSha256Hash(Password)),
                new SqlParameter("@role", Role)
            };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }

        /// <summary>
        /// Desactiva lógicamente a un usuario en el sistema.
        /// </summary>
        public int DisableUser(int id)
        {
            string query = "UPDATE Users SET Enable = 0 WHERE User_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
        /* --------------------------------------------------------------------- */
        /* #region ESPACIO TEMPORAL (SIMULACIÓN PARA PRUEBAS DE LOGIN DE UI)     */
        /* --------------------------------------------------------------------- */
        #region Espacio Temporal de Pruebas en RAM

        // Esta lista estática almacena tus usuarios de prueba temporalmente mientras diseñas las vistas.
        private static readonly List<User> _mockUsers = new List<User>
        {
            new User(1, "admin", "admin123", "Admin"),
            new User(2, "vendedor", "vendedor123", "Vendedor"),
            new User(3, "elias", "caja2026", "Vendedor"),
            new User(4, "milton", "superadmin", "Admin")
        };

        /// <summary>
        /// Método provisional para autenticar credenciales desde la pantalla de Login sin tocar la Base de Datos.
        /// </summary>
        public static User MockAuthenticate(string username, string password)
        {
            return _mockUsers.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password &&
                u.Enable);
        }

        /// <summary>
        /// Devuelve todos los usuarios simulados actuales para cargarlos en DataGridViews de prueba si es necesario.
        /// </summary>
        public static List<User> GetMockUsers()
        {
            return _mockUsers;
        }
        #endregion

    }
}