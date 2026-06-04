using CevicheSys_Pro_2.Helpers;
using CevicheSys_Pro_2.Services.Persistence;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        /* Métodos de Validación Interna                                         */
        /* --------------------------------------------------------------------- */
        public bool IsAdmin()
        {
            return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
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