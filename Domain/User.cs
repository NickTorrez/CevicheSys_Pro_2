using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

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
        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
            Enable = true;
        }

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
        public bool IsAdmin()
        {
            return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD SQL Server)                             */
        /* --------------------------------------------------------------------- */

        public User Authenticate(string username, string password)
        {
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol, Enable FROM Usuario WHERE Nombre_Usuario = @user AND Contraseña = @pass AND Enable = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@user", username),
                new SqlParameter("@pass", password)
            };

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new User(
                        Convert.ToInt32(row["Id_Usuario"]),
                        row["Nombre_Usuario"].ToString(),
                        row["Contraseña"].ToString(),
                        row["Rol"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    );
                }
            }
            return null; // Credenciales incorrectas
        }

        public List<User> ListAllUsers()
        {
            var list = new List<User>();
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol, Enable FROM Usuario WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new User(
                        Convert.ToInt32(row["Id_Usuario"]),
                        row["Nombre_Usuario"].ToString(),
                        row["Contraseña"].ToString(),
                        row["Rol"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddUser()
        {
            string query = "INSERT INTO Usuario (Nombre_Usuario, Contraseña, Rol, Enable) VALUES (@username, @password, @role, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@username", this.Username),
                new SqlParameter("@password", this.Password),
                new SqlParameter("@role", this.Role),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateUser()
        {
            string query = "UPDATE Usuario SET Nombre_Usuario = @username, Contraseña = @password, Rol = @role WHERE Id_Usuario = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", this.User_Id),
                new SqlParameter("@username", this.Username),
                new SqlParameter("@password", this.Password),
                new SqlParameter("@role", this.Role)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableUser(int id)
        {
            string query = "UPDATE Usuario SET Enable = 0 WHERE Id_Usuario = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
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