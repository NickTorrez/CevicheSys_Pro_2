using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString) => _connectionString = connectionString;

        public User Authenticate(string username, string password)
        {
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol, Enable FROM Usuario WHERE Nombre_Usuario = @user AND Contraseña = @pass AND Enable = 1";
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
            return null;
        }
    }
}
