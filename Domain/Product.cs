using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Product
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _product_Id;
        private string _product_Name;
        private double _current_Stock;
        private DateTime? _expiration_Date;
        private int _category_Id;
        private int _supplier_Id;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Product_Id { get => _product_Id; set => _product_Id = value; }
        public string Product_Name { get => _product_Name; set => _product_Name = value; }
        public double Current_Stock { get => _current_Stock; set => _current_Stock = value; }
        public DateTime? Expiration_Date { get => _expiration_Date; set => _expiration_Date = value; }
        public int Category_Id { get => _category_Id; set => _category_Id = value; }
        public int Supplier_Id { get => _supplier_Id; set => _supplier_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Product()
        {
            _product_Name = string.Empty;
        }

        public Product(int id, string productName, int supplierId, int categoryId, double currentStock, DateTime? expirationDate)
        {
            _product_Id = id;
            _product_Name = productName;
            _supplier_Id = supplierId;
            _category_Id = categoryId;
            _current_Stock = currentStock;
            _expiration_Date = expirationDate;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos                                                               */
        /* --------------------------------------------------------------------- */
        public static List<Product> List()
        {
            var list = new List<Product>();
            string query = "SELECT Id_Producto, Nombre, Stock_Actual, Fecha_Vencimiento, Id_Categoria, Id_Proveedor FROM Producto";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Product
                {
                    Product_Id = Convert.ToInt32(row["Id_Producto"]),
                    Product_Name = row["Nombre"].ToString(),
                    Current_Stock = Convert.ToDouble(row["Stock_Actual"]),
                    Expiration_Date = row["Fecha_Vencimiento"] != DBNull.Value ? Convert.ToDateTime(row["Fecha_Vencimiento"]) : (DateTime?)null,
                    Category_Id = Convert.ToInt32(row["Id_Categoria"]),
                    Supplier_Id = Convert.ToInt32(row["Id_Proveedor"])
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@nom", this.Product_Name),
                new SqlParameter("@stock", this.Current_Stock),
                new SqlParameter("@venc", this.Expiration_Date.HasValue ? this.Expiration_Date.Value : DBNull.Value),
                new SqlParameter("@cat", this.Category_Id),
                new SqlParameter("@prov", this.Supplier_Id)
            };

            if (this.Product_Id == 0)
            {
                string query = "INSERT INTO Producto (Nombre, Stock_Actual, Fecha_Vencimiento, Id_Categoria, Id_Proveedor) VALUES (@nom, @stock, @venc, @cat, @prov)";
                using var insert = new InsertCommand();
                this.Product_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Producto SET Nombre=@nom, Stock_Actual=@stock, Fecha_Vencimiento=@venc, Id_Categoria=@cat, Id_Proveedor=@prov WHERE Id_Producto=@id";
                var pUp = new List<SqlParameter>(p) { new SqlParameter("@id", this.Product_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUp.ToArray());
            }
            return true;
        }
    }

}
