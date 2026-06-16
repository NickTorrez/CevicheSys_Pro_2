using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Almacena los productos finales disponibles en el menú configurados por tamaño y costo comercial.
    /// </summary>
    public class Dish
    {
        #region Properties
        public int Dish_Id { get; set; }
        public string Dish_Type { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0m;
        public bool Is_Available { get; set; } = true;
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public Dish() 
        {
 
        }

        public Dish(int dishId, string dishType, string size, decimal price, bool isAvailable, bool enable = true)
        {
            Dish_Id = dishId;
            Dish_Type = dishType;
            Size = size;
            Price = price;
            Is_Available = isAvailable;
            Enable = enable;
        }

        #endregion

        #region Persistence Methods
        public bool ExistsByTypeAndSize(string type, string size, int currentId = 0)
        {
            string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Dish WHERE Dish_Type = @Type AND Size = @Size AND Dish_Id <> @Id AND Enable = 1) THEN 1 ELSE 0 END";
            using SelectQuery select = new SelectQuery();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Type", SqlDbType.VarChar) { Value = type.Trim() },
                new SqlParameter("@Size", SqlDbType.VarChar) { Value = size.Trim() },
                new SqlParameter("@Id", SqlDbType.Int) { Value = currentId }
            };
            return select.IsDuplicate(sql, parameters);
        }

        public bool InsertDish()
        {
            string sql = @"INSERT INTO Dish (Dish_Type, Size, Price, Is_Available, Enable) 
                           VALUES (@Type, @Size, @Price, @Available, 1)";
            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Type", SqlDbType.VarChar) { Value = this.Dish_Type.Trim() },
                new SqlParameter("@Size", SqlDbType.VarChar) { Value = this.Size.Trim() },
                new SqlParameter("@Price", SqlDbType.Decimal) { Value = this.Price },
                new SqlParameter("@Available", SqlDbType.Bit) { Value = this.Is_Available }
            };
            return insert.ExecuteInsert(sql, parameters) > 0;
        }

        public bool UpdateDish()
        {
            string sql = @"UPDATE Dish SET Dish_Type = @Type, Size = @Size, Price = @Price, Is_Available = @Available 
                           WHERE Dish_Id = @Id AND Enable = 1";
            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Dish_Id },
                new SqlParameter("@Type", SqlDbType.VarChar) { Value = this.Dish_Type.Trim() },
                new SqlParameter("@Size", SqlDbType.VarChar) { Value = this.Size.Trim() },
                new SqlParameter("@Price", SqlDbType.Decimal) { Value = this.Price },
                new SqlParameter("@Available", SqlDbType.Bit) { Value = this.Is_Available }
            };
            return update.ExecuteUpdate(sql, parameters) > 0;
        }

        public bool DeleteDish()
        {
            string sql = "UPDATE Dish SET Enable = 0 WHERE Dish_Id = @Id";
            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Dish_Id }
            };
            return delete.ExecuteDelete(sql, parameters) > 0;
        }
        #endregion
    }
}