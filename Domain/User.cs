using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _user_Id;
        private string _username;
        private string _password;
        private string _role; // "Admin" o "Vendedor"

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int User_Id { get => _user_Id; set => _user_Id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Role { get => _role; set => _role = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public User()
        {
            _username = string.Empty;
            _password = string.Empty;
            _role = string.Empty;
        }

        public User(int id, string username, string password, string role)
        {
            _user_Id = id;
            _username = username;
            _password = password;
            _role = role;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");// Ruta unificada y limpia en la carpeta Data

        // Obtener todos los usuarios de la base de datos JSON
        public static List<User> List()
        {
            if (!File.Exists(PathArchivo)) // Si el archivo no existe, se crea con usuarios por defecto
            {
                // Credenciales por defecto iniciales solicitadas por las funciones
                var listaPorDefecto = new List<User>
                {
                    new User(1, "admin", "admin123", "Admin"),
                    new User(2, "vendedor", "vendedor123", "Vendedor")
                };
                string json = JsonSerializer.Serialize(listaPorDefecto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return listaPorDefecto;
            }

            string jsonExistente = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<User>>(jsonExistente) ?? new List<User>();
        }

        // Método para validar credenciales en la pantalla de Login
        public static User Authenticate(string username, string password)
        {
            return List().FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }

    }
}