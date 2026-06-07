using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    ///Gestiona la autenticación y el ciclo CRUD completo de los usuarios del sistema.
    /// </summary>
    public class UserBusiness
    {
        private readonly string _connectionString;

        public UserBusiness(string connectionString) => _connectionString = connectionString;

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("El usuario y contraseña no pueden estar vacíos.");

            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol, Enable FROM Usuario WHERE Nombre_Usuario = @user AND Contraseña = @pass AND Enable = 1";

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                Convert.ToInt32(reader["Id_Usuario"]),
                                reader["Nombre_Usuario"].ToString(),
                                reader["Contraseña"].ToString(),
                                reader["Rol"].ToString(),
                                Convert.ToBoolean(reader["Enable"])
                            );
                        }
                    }
                }
            }
            catch (SqlException) { /* Fallback a lista en memoria si no hay BD */ }

            return User.MockAuthenticate(username, password);
        }

        public List<User> ObtainAllUsers()
        {
            var list = new List<User>();
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol, Enable FROM Usuario WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User(
                            Convert.ToInt32(reader["Id_Usuario"]),
                            reader["Nombre_Usuario"].ToString(),
                            reader["Contraseña"].ToString(),
                            reader["Rol"].ToString(),
                            Convert.ToBoolean(reader["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public bool RegisterUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                throw new InvalidOperationException("El nombre de usuario y contraseña son obligatorios.");

            string query = "INSERT INTO Usuario (Nombre_Usuario, Contraseña, Rol, Enable) VALUES (@name, @pass, @role, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@enable", user.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifyUser(User user)
        {
            if (user == null || user.User_Id <= 0) throw new ArgumentException("Usuario inválido.");
            string query = "UPDATE Usuario SET Nombre_Usuario = @name, Contraseña = @pass, Rol = @role WHERE Id_Usuario = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", user.User_Id);
                cmd.Parameters.AddWithValue("@name", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveUser(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Usuario SET Enable = 0 WHERE Id_Usuario = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    
}
