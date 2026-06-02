using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Sale_Detail
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _detail_Id;
        private int _quantity;
        private int _sale_Id;
        private int _dish_Id;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */

        public int Detail_Id { get => _detail_Id; set => _detail_Id = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int Sale_Id { get => _sale_Id; set => _sale_Id = value; }
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale_Detail()
        {
        }

        public Sale_Detail(int id, int quantity, int saleId, int dishId)
        {
            _detail_Id = id;
            _quantity = quantity;
            _sale_Id = saleId;
            _dish_Id = dishId;
        }
        /* --------------------------------------------------------------------- */
        /* Métodos                                                               */
        /* --------------------------------------------------------------------- */
        public static List<Sale_Detail> List()
        {
            var list = new List<Sale_Detail>();
            string query = "SELECT Id_Detalle, Cantidad, Id_Venta, Id_Platillo FROM Detalle_Venta";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Sale_Detail
                {
                    Detail_Id = Convert.ToInt32(row["Id_Detalle"]),
                    Quantity = Convert.ToInt32(row["Cantidad"]),
                    Sale_Id = Convert.ToInt32(row["Id_Venta"]),
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"])
                });
            }
            return list;
        }

        // Optimización: Filtrado directo en SQL Server
        public static List<Sale_Detail> GetDetailsBySale(int saleId)
        {
            var list = new List<Sale_Detail>();
            string query = "SELECT Id_Detalle, Cantidad, Id_Venta, Id_Platillo FROM Detalle_Venta WHERE Id_Venta = @id";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query, new[] { new SqlParameter("@id", saleId) });

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Sale_Detail
                {
                    Detail_Id = Convert.ToInt32(row["Id_Detalle"]),
                    Quantity = Convert.ToInt32(row["Cantidad"]),
                    Sale_Id = Convert.ToInt32(row["Id_Venta"]),
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"])
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@cant", this.Quantity),
                new SqlParameter("@venta", this.Sale_Id),
                new SqlParameter("@plat", this.Dish_Id)
            };

            if (this.Detail_Id == 0)
            {
                string query = "INSERT INTO Detalle_Venta (Cantidad, Id_Venta, Id_Platillo) VALUES (@cant, @venta, @plat)";
                using var insert = new InsertCommand();
                this.Detail_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Detalle_Venta SET Cantidad=@cant, Id_Venta=@venta, Id_Platillo=@plat WHERE Id_Detalle=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.Detail_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
            }
            return true;
        }
    }
}