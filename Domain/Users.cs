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
    public class Users
    {
        #region Properties
        public int User_Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public Users() { }

        public Users(int userId, string username, string password, string role, bool enable)
        {
            this.User_Id = userId;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Enable = enable;
        }
        #endregion

        #region Validation Methods
        public bool ExistsByUsername(string username, int currentUserId)
        {
            string sql = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE Username = @Username AND User_Id <> @User_Id AND Enable = 1) THEN 1 ELSE 0 END;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = username },
                new SqlParameter("@User_Id", SqlDbType.Int) { Value = currentUserId }
            };

            using (SelectQuery select = new SelectQuery())
            {
                return select.IsDuplicate(sql, parameters);
            }
        }

        /// <summary>
        /// Valida internamente que el formato del nombre de usuario cumpla con los requisitos mínimos.
        /// </summary>
        public Users Authenticate(string username, string password)
        {
            string sql = "SELECT User_Id, Username, Password, Role, Enable FROM Users WHERE Username = @Username AND Password = @Password AND Enable = 1;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = username },
                new SqlParameter("@Password", SqlDbType.VarChar, 255) { Value = password }
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable table = select.ExecuteSelect(sql, parameters);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    return new Users
                    {
                        User_Id = Convert.ToInt32(row["User_Id"]),
                        Username = row["Username"].ToString() ?? string.Empty,
                        Password = row["Password"].ToString() ?? string.Empty,
                        Role = row["Role"].ToString() ?? string.Empty,
                        Enable = Convert.ToBoolean(row["Enable"])
                    };
                }
                return null!;
            }
        }
        #endregion

        #region Methods CRUD
        public DataTable ListAllUsers()
        {
            string sql = "SELECT User_Id, Username, Role, Enable FROM Users WHERE Enable = 1 ORDER BY Username ASC;";
            using (SelectQuery select = new SelectQuery())
            {
                return select.ExecuteSelect(sql);
            }
        }

        public int InsertUser()
        {
            string sql = "INSERT INTO Users (Username, Password, Role, Enable) VALUES (@Username, @Password, @Role, @Enable);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = this.Username },
                new SqlParameter("@Password", SqlDbType.VarChar, 255) { Value = this.Password },
                new SqlParameter("@Role", SqlDbType.VarChar, 20) { Value = this.Role },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (InsertCommand cmd = new InsertCommand())
            {
                return cmd.ExecuteInsert(sql, parameters);
            }
        }

        public int UpdateUser()
        {
            string sql = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role, Enable = @Enable WHERE User_Id = @User_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@User_Id", SqlDbType.Int) { Value = this.User_Id },
                new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = this.Username },
                new SqlParameter("@Password", SqlDbType.VarChar, 255) { Value = this.Password },
                new SqlParameter("@Role", SqlDbType.VarChar, 20) { Value = this.Role },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }

        public int DeleteUser()
        {
            // Eliminación lógica estandarizada del registro cambiando el estado de disponibilidad (Enable) a false
            string sql = "UPDATE Users SET Enable = 0 WHERE User_Id = @User_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@User_Id", SqlDbType.Int) { Value = this.User_Id }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }
        #endregion

    }
}