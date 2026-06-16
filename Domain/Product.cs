using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Controla el stock físico, procedencia y caducidad de las materias primas e insumos de la cevichería.
    /// </summary>
    public class Product
    {
        #region Properties
        public int Product_Id { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int? Supplier_Id { get; set; }
        public int Category_Id { get; set; }
        public decimal Current_Stock { get; set; } = 0m;
        public decimal Minimum_Stock { get; set; } = 0m;
        public DateTime? Expiration_Date { get; set; }
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public Product() { }
        #endregion

        #region Business Rules
        public bool RequiresRestock()
        {
            return Current_Stock <= Minimum_Stock;
        }
        #endregion

        #region Persistence Methods
        public bool ExistsByName(string productName, int currentId = 0)
        {
            string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Product WHERE Product_Name = @Name AND Product_Id <> @Id AND Enable = 1) THEN 1 ELSE 0 END";
            using SelectQuery select = new SelectQuery();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", SqlDbType.VarChar) { Value = productName.Trim() },
                new SqlParameter("@Id", SqlDbType.Int) { Value = currentId }
            };
            return select.IsDuplicate(sql, parameters);
        }

        public bool InsertProduct()
        {
            string sql = @"INSERT INTO Product (Category_Id, Supplier_Id, Product_Name, Current_Stock, Minimum_Stock, Expiration_Date, Enable)
                           VALUES (@CategoryId, @SupplierId, @Name, @CurrentStock, @MinimumStock, @Expiration, 1)";
            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@SupplierId", SqlDbType.Int) { Value = (object)this.Supplier_Id ?? DBNull.Value },
                new SqlParameter("@Name", SqlDbType.VarChar) { Value = this.Product_Name.Trim() },
                new SqlParameter("@CurrentStock", SqlDbType.Decimal) { Value = this.Current_Stock },
                new SqlParameter("@MinimumStock", SqlDbType.Decimal) { Value = this.Minimum_Stock },
                new SqlParameter("@Expiration", SqlDbType.Date) { Value = (object)this.Expiration_Date ?? DBNull.Value }
            };
            return insert.ExecuteInsert(sql, parameters) > 0;
        }

        public bool UpdateProduct()
        {
            string sql = @"UPDATE Product SET Category_Id = @CategoryId, Supplier_Id = @SupplierId, Product_Name = @Name,
                           Current_Stock = @CurrentStock, Minimum_Stock = @MinimumStock, Expiration_Date = @Expiration 
                           WHERE Product_Id = @Id AND Enable = 1";
            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Product_Id },
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@SupplierId", SqlDbType.Int) { Value = (object)this.Supplier_Id ?? DBNull.Value },
                new SqlParameter("@Name", SqlDbType.VarChar) { Value = this.Product_Name.Trim() },
                new SqlParameter("@CurrentStock", SqlDbType.Decimal) { Value = this.Current_Stock },
                new SqlParameter("@MinimumStock", SqlDbType.Decimal) { Value = this.Minimum_Stock },
                new SqlParameter("@Expiration", SqlDbType.Date) { Value = (object)this.Expiration_Date ?? DBNull.Value }
            };
            return update.ExecuteUpdate(sql, parameters) > 0;
        }

        public bool DeleteProduct()
        {
            string sql = "UPDATE Product SET Enable = 0 WHERE Product_Id = @Id";
            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Product_Id }
            };
            return delete.ExecuteDelete(sql, parameters) > 0;
        }
        #endregion
    }

}
