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

        #region Security Methods

        public bool ExistsByName(string productName, int currentProductId)
        {
            string sql = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Product WHERE Product_Name = @Product_Name AND Product_Id <> @Product_Id AND Enable = 1) THEN 1 ELSE 0 END;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Product_Name", SqlDbType.VarChar, 100) { Value = productName },
                new SqlParameter("@Product_Id", SqlDbType.Int) { Value = currentProductId }
            };

            using (SelectQuery select = new SelectQuery())
            {
                return select.IsDuplicate(sql, parameters);
            }
        }

        #endregion

        #region Persistence Methods

        public DataTable ListAllProducts()
        {
            string sql = "SELECT p.Product_Id, p.Product_Name, c.Category_Name, " +
                         "ISNULL(s.First_Name + ' ' + s.Last_Name, 'Sin Proveedor') AS Supplier_Name, " +
                         "p.Current_Stock, p.Minimum_Stock, p.Expiration_Date, p.Category_Id, p.Supplier_Id " +
                         "FROM Product p " +
                         "INNER JOIN Category c ON p.Category_Id = c.Category_Id " +
                         "LEFT JOIN Supplier s ON p.Supplier_Id = s.Supplier_Id " +
                         "WHERE p.Enable = 1 ORDER BY p.Product_Name ASC;";

            using (SelectQuery select = new SelectQuery())
            {
                return select.ExecuteSelect(sql);
            }
        }

        public int InsertProduct()
        {
            string sql = "INSERT INTO Product (Category_Id, Supplier_Id, Product_Name, Current_Stock, Minimum_Stock, Expiration_Date, Enable) " +
                         "VALUES (@Category_Id, @Supplier_Id, @Product_Name, @Current_Stock, @Minimum_Stock, @Expiration_Date, @Enable);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Category_Id", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@Supplier_Id", SqlDbType.Int) { Value = (object?)this.Supplier_Id ?? DBNull.Value },
                new SqlParameter("@Product_Name", SqlDbType.VarChar, 100) { Value = this.Product_Name },
                new SqlParameter("@Current_Stock", SqlDbType.Decimal) { Value = this.Current_Stock },
                new SqlParameter("@Minimum_Stock", SqlDbType.Decimal) { Value = this.Minimum_Stock },
                new SqlParameter("@Expiration_Date", SqlDbType.Date) { Value = (object?)this.Expiration_Date ?? DBNull.Value },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (InsertCommand cmd = new InsertCommand())
            {
                return cmd.ExecuteInsert(sql, parameters);
            }
        }

        public int UpdateProduct()
        {
            string sql = "UPDATE Product SET Category_Id = @Category_Id, Supplier_Id = @Supplier_Id, Product_Name = @Product_Name, " +
                         "Current_Stock = @Current_Stock, Minimum_Stock = @Minimum_Stock, Expiration_Date = @Expiration_Date, " +
                         "Enable = @Enable WHERE Product_Id = @Product_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Product_Id", SqlDbType.Int) { Value = this.Product_Id },
                new SqlParameter("@Category_Id", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@Supplier_Id", SqlDbType.Int) { Value = (object?)this.Supplier_Id ?? DBNull.Value },
                new SqlParameter("@Product_Name", SqlDbType.VarChar, 100) { Value = this.Product_Name },
                new SqlParameter("@Current_Stock", SqlDbType.Decimal) { Value = this.Current_Stock },
                new SqlParameter("@Minimum_Stock", SqlDbType.Decimal) { Value = this.Minimum_Stock },
                new SqlParameter("@Expiration_Date", SqlDbType.Date) { Value = (object?)this.Expiration_Date ?? DBNull.Value },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }

        public int DeleteProduct()
        {
            string sql = "UPDATE Product SET Enable = 0 WHERE Product_Id = @Product_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Product_Id", SqlDbType.Int) { Value = this.Product_Id }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }
        #endregion
    }

}
