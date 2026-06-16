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
        #region Properties
        public int User_Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public User() { }

        public User(int userId, string username, string password, string role, bool enable)
        {
            this.User_Id = userId;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Enable = enable;
        }
        #endregion

        #region Validation Methods
        /// <summary>
        /// Valida internamente que el formato del nombre de usuario cumpla con los requisitos mínimos.
        /// </summary>
        public bool ValidateUsernameFormat()
        {
            if (string.IsNullOrWhiteSpace(this.Username) || this.Username.Length < 4)
                return false;

            return true;
        }
        #endregion

        #region Security Methods
        private string ComputeSha256Hash(string rawData)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawData));
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                foreach (byte item in bytes)
                    builder.Append(item.ToString("x2"));
                return builder.ToString();
            }
        }
        #endregion

        /// <summary>
        /// Autentica al usuario comparando el Hash de su contraseña con el registro en base de datos.
        /// </summary>
        public User Authenticate(string username, string password)
        {
            string sql = @"SELECT User_Id, Username, Password, Role, Enable 
                           FROM Users 
                           WHERE Username = @user AND Password = @pass AND Enable = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar) { Value = username.Trim() },
                new SqlParameter("@pass", SqlDbType.VarChar) { Value = ComputeSha256Hash(password) }
            };

            using SelectQuery select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(sql, parameters);

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

        /// <summary>
        /// Recupera la lista completa de usuarios activos en el sistema.
        /// </summary>
        public System.Collections.Generic.List<User> ListAllUsers()
        {
            System.Collections.Generic.List<User> list = new System.Collections.Generic.List<User>();
            string sql = "SELECT User_Id, Username, Password, Role, Enable FROM Users WHERE Enable = 1";

            using SelectQuery select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(sql);

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
            return list;
        }

        #region Persistence Methods (Active Record Style)
        /// <summary>
        /// Comprueba si ya existe un usuario con el mismo Username en la base de datos.
        /// </summary>
        public bool ExistsByUsername(string username, int currentUserId = 0)
        {
            string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Users WHERE Username = @Username AND User_Id <> @UserId AND Enable = 1) THEN 1 ELSE 0 END";

            // Se utiliza la instrucción 'using' para asegurar la recolección de los recursos del comando
            using SelectQuery select = new SelectQuery();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar) { Value = username.Trim() },
                new SqlParameter("@UserId", SqlDbType.Int) { Value = currentUserId }
            };

            // Suponiendo que IsDuplicate o un método equivalente del profe Lawdee que ejecuta un ExecuteScalar
            return select.IsDuplicate(sql, parameters);
        }

        /// <summary>
        /// Inserta el registro del objeto actual en la base de datos.
        /// </summary>
        public bool InsertUser()
        {
            string sql = "INSERT INTO Users (Username, Password, Role, Enable) VALUES (@Username, @Password, @Role, 1)";

            using InsertCommand insert = new InsertCommand();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar) { Value = this.Username.Trim() },
                new SqlParameter("@Password", SqlDbType.VarChar) { Value = this.Password }, // Aquí puede ir el Hash SHA256 aplicado
                new SqlParameter("@Role", SqlDbType.VarChar) { Value = this.Role }
            };

            // Retorna verdadero si las filas afectadas son mayores a 0
            return insert.ExecuteInsert(sql, parameters) > 0;
        }

        /// <summary>
        /// Actualiza los datos del usuario actual.
        /// </summary>
        public bool UpdateUser()
        {
            string sql = "UPDATE Users SET Username = @Username, Role = @Role WHERE User_Id = @UserId AND Enable = 1";

            using UpdateCommand update = new UpdateCommand();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", SqlDbType.Int) { Value = this.User_Id },
                new SqlParameter("@Username", SqlDbType.VarChar) { Value = this.Username.Trim() },
                new SqlParameter("@Role", SqlDbType.VarChar) { Value = this.Role }
            };

            return update.ExecuteUpdate(sql, parameters) > 0;
        }

        /// <summary>
        /// Realiza un borrado lógico cambiando el estado 'Enable' a 0.
        /// </summary>
        public bool DeleteUser()
        {
            string sql = "UPDATE Users SET Enable = 0 WHERE User_Id = @UserId";

            using DeleteCommand delete = new DeleteCommand();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", SqlDbType.Int) { Value = this.User_Id }
            };

            return delete.ExecuteDelete(sql, parameters) > 0;
        }
        #endregion
    
    }
}