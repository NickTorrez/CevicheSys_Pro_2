using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Motor Transaccional: Permite facturar, consultar el historial y anular ventas erróneas.
    /// </summary>
    public class SaleBusiness
    {
        private readonly string _connectionString;

        public SaleBusiness(string connectionString) => _connectionString = connectionString;

        public List<Sale> ObtainAllSales()
        {
            var list = new List<Sale>();
            string query = "SELECT Id_Venta, Nombre_Cliente, Metodo_Pago, Tipo_Compra, Total_Pagar, Fecha_Registro, Id_Usuario, Enable FROM Venta WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Sale(
                            Convert.ToInt32(r["Id_Venta"]),
                            r["Nombre_Cliente"].ToString(),
                            r["Metodo_Pago"].ToString(),
                            r["Tipo_Compra"].ToString(),
                            Convert.ToDouble(r["Total_Pagar"]),
                            Convert.ToDateTime(r["Fecha_Registro"]),
                            Convert.ToInt32(r["Id_Usuario"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public bool ProcessSale(Sale sale, List<Sale_Detail> details)
        {
            if (details == null || details.Count == 0) return false;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string qHeader = @"INSERT INTO Venta (Nombre_Cliente, Metodo_Pago, Tipo_Compra, Total_Pagar, Fecha_Registro, Id_Usuario, Enable) 
                                   VALUES (@cust, @pay, @type, @total, @date, @userId, @enable);
                                   SELECT SCOPE_IDENTITY();";
                int newSaleId;
                using (var cmd = new SqlCommand(qHeader, conn))
                {
                    cmd.Parameters.AddWithValue("@cust", sale.Customer_Name);
                    cmd.Parameters.AddWithValue("@pay", sale.Payment_Method);
                    cmd.Parameters.AddWithValue("@type", sale.Purchase_Type);
                    cmd.Parameters.AddWithValue("@total", sale.Total_Amount);
                    cmd.Parameters.AddWithValue("@date", sale.Record_Date);
                    cmd.Parameters.AddWithValue("@userId", sale.User_Id);
                    cmd.Parameters.AddWithValue("@enable", sale.Enable);
                    newSaleId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (newSaleId <= 0) return false;

                foreach (var detail in details)
                {
                    detail.Sale_Id = newSaleId;
                    string qDetail = "INSERT INTO Detalle_Venta (Id_Venta, Id_Platillo, Cantidad) VALUES (@saleId, @dishId, @qty)";
                    using (var cmd = new SqlCommand(qDetail, conn))
                    {
                        cmd.Parameters.AddWithValue("@saleId", detail.Sale_Id);
                        cmd.Parameters.AddWithValue("@dishId", detail.Dish_Id);
                        cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                        cmd.ExecuteNonQuery();
                    }

                    // Descargo automático de Inventario
                    string qRecipe = "SELECT Id_Producto, Quantity_Used FROM Receta WHERE Id_Platillo = @dishId AND Enable = 1";
                    var recipeItems = new List<(int ProductId, double Quantity)>();
                    using (var cmd = new SqlCommand(qRecipe, conn))
                    {
                        cmd.Parameters.AddWithValue("@dishId", detail.Dish_Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipeItems.Add((Convert.ToInt32(reader["Id_Producto"]), Convert.ToDouble(reader["Quantity_Used"])));
                            }
                        }
                    }

                    foreach (var item in recipeItems)
                    {
                        double totalDeduction = item.Quantity * detail.Quantity;
                        string qUpdateStock = "UPDATE Producto SET Stock_Actual = Stock_Actual - @deduction WHERE Id_Producto = @prodId";
                        using (var cmd = new SqlCommand(qUpdateStock, conn))
                        {
                            cmd.Parameters.AddWithValue("@deduction", totalDeduction);
                            cmd.Parameters.AddWithValue("@prodId", item.ProductId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Anula una venta aplicándole un borrado lógico (Enable = 0) por auditoría.
        /// </summary>
        public bool VoidSale(int saleId)
        {
            if (saleId <= 0) throw new ArgumentException("ID de venta inválido.");
            string query = "UPDATE Venta SET Enable = 0 WHERE Id_Venta = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", saleId);
                conn.Open();
                // Aquí podrías agregar un UPDATE inverso a la tabla Producto para devolver el inventario anulado.
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
