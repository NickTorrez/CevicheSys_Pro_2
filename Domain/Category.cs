using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Catálogo maestro utilizado para clasificar de manera estandarizada tanto los insumos como los gastos.
    /// </summary>
    public class Category
    {
        #region Properties
        public int Category_Id { get; set; }
        public string Category_Name { get; set; } = string.Empty;
        public string Target_Module { get; set; } = string.Empty;
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public Category() { }
        #endregion

        #region Persistence Methods
        public bool ExistsByName(string categoryName, string targetModule, int currentId = 0)
        {
            string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Category WHERE Category_Name = @Name AND Target_Module = @Module AND Category_Id <> @Id AND Enable = 1) THEN 1 ELSE 0 END";
            using SelectQuery select = new SelectQuery();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = categoryName.Trim() },
                new SqlParameter("@Module", SqlDbType.VarChar, 20) { Value = targetModule.Trim() },
                new SqlParameter("@Id", SqlDbType.Int) { Value = currentId }
            };
            return select.IsDuplicate(sql, parameters);
        }

        public int InsertCategory()
        {
            string sql = "INSERT INTO Category (Category_Name, Target_Module, Enable) VALUES (@Name, @Module, 1)";
            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = this.Category_Name.Trim() },
                new SqlParameter("@Module", SqlDbType.VarChar, 20) { Value = this.Target_Module.Trim() }
            };
            return insert.ExecuteInsert(sql, parameters);
        }

        public int UpdateCategory()
        {
            string sql = "UPDATE Category SET Category_Name = @Name, Target_Module = @Module WHERE Category_Id = @Id AND Enable = 1";
            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = this.Category_Name.Trim() },
                new SqlParameter("@Module", SqlDbType.VarChar, 20) { Value = this.Target_Module.Trim() }
            };
            return update.ExecuteUpdate(sql, parameters);
        }

        public int DeleteCategory()
        {
            string sql = "UPDATE Category SET Enable = 0 WHERE Category_Id = @Id";
            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Category_Id }
            };
            return delete.ExecuteDelete(sql, parameters);
        }

        public DataTable ListAllCategories()
        {
            using (SelectQuery select = new SelectQuery())
                return select.ExecuteSelect("SELECT Category_Id, Category_Name FROM Category WHERE Enable = 1 AND Target_Module = 'Gastos'");
        }

        #endregion
    }
}