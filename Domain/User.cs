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
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _user_Id;
        private string _username;
        private string _password;
        private string _role;

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
        public User() { }
        public User(int id, string username, string password, string role)
        {
            _user_Id = id; _username = username; _password = password; _role = role;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */

        public static List<User> List()
        {
            var list = new List<User>();
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol FROM Usuario";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new User(
                    Convert.ToInt32(row["Id_Usuario"]),
                    row["Nombre_Usuario"].ToString(),
                    row["Contraseña"].ToString(),
                    row["Rol"].ToString()
                ));
            }
            return list;
        }

        public static User Authenticate(string username, string password)
        {
            string query = "SELECT Id_Usuario, Nombre_Usuario, Contraseña, Rol FROM Usuario WHERE Nombre_Usuario = @user AND Contraseña = @pass";
            SqlParameter[] p = { new SqlParameter("@user", username), new SqlParameter("@pass", password) };

            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query, p);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User(Convert.ToInt32(row["Id_Usuario"]), row["Nombre_Usuario"].ToString(), row["Contraseña"].ToString(), row["Rol"].ToString());
            }
            return null;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@user", this.Username),
                new SqlParameter("@pass", this.Password),
                new SqlParameter("@rol", this.Role)
            };

            if (this.User_Id == 0)
            {
                string query = "INSERT INTO Usuario (Nombre_Usuario, Contraseña, Rol) VALUES (@user, @pass, @rol)";
                using var insert = new InsertCommand();
                this.User_Id = insert.ExecuteInsertReturnId(query, p);
                return true;
            }
            else
            {
                string query = "UPDATE Usuario SET Nombre_Usuario=@user, Contraseña=@pass, Rol=@rol WHERE Id_Usuario=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.User_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
                return true;
            }
        }

    }
}