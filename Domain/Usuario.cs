using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Usuario
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Usuario;
        private string _nombre_Usuario;
        private string _contraseña;
        private string _rol; // "Admin" o "Vendedor"

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Id_Usuario { get => _id_Usuario; set => _id_Usuario = value; }
        public string Nombre_Usuario { get => _nombre_Usuario; set => _nombre_Usuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Rol { get => _rol; set => _rol = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Usuario()
        {
            _nombre_Usuario = string.Empty;
            _contraseña = string.Empty;
            _rol = string.Empty;
        }

        public Usuario(int id, string nombreUsuario, string contraseña, string rol)
        {
            _id_Usuario = id;
            _nombre_Usuario = nombreUsuario;
            _contraseña = contraseña;
            _rol = rol;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "usuarios.json");// Ruta unificada y limpia en la carpeta Data

        // Obtener todos los usuarios de la base de datos JSON
        public static List<Usuario> Listar()
        {
            if (!File.Exists(PathArchivo)) // Si el archivo no existe, se crea con usuarios por defecto
            {
                // Credenciales por defecto iniciales solicitadas por las funciones
                var listaPorDefecto = new List<Usuario>
                {
                    new Usuario(1, "admin", "admin123", "Admin"),
                    new Usuario(2, "vendedor", "vendedor123", "Vendedor")
                };
                string json = JsonSerializer.Serialize(listaPorDefecto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return listaPorDefecto;
            }

            string jsonExistente = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Usuario>>(jsonExistente) ?? new List<Usuario>();
        }

        // Método para validar credenciales en la pantalla de Login
        public static Usuario Autenticar(string username, string password)
        {
            return Listar().FirstOrDefault(u => u.Nombre_Usuario.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Contraseña == password);
        }

    }
}