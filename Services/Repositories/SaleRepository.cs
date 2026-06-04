using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.Repositories
{
    public class SaleRepository
    {
        private readonly string _connectionString;
        public SaleRepository(string connectionString) => _connectionString = connectionString;

        public int InsertSaleHeader(Sale sale)
        {
            string query = @"INSERT INTO Venta (Nombre_Cliente, Metodo_Pago, Tipo_Compra, Total_Pagar, Fecha_Registro, Id_Usuario, Enable) 
                             VALUES (@cust, @pay, @type, @total, @date, @userId, @enable);
                             SELECT SCOPE_IDENTITY();";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cust", sale.Customer_Name);
                cmd.Parameters.AddWithValue("@pay", sale.Payment_Method);
                cmd.Parameters.AddWithValue("@type", sale.Purchase_Type);
                cmd.Parameters.AddWithValue("@total", sale.Total_Amount);
                cmd.Parameters.AddWithValue("@date", sale.Record_Date);
                cmd.Parameters.AddWithValue("@userId", sale.User_Id);
                cmd.Parameters.AddWithValue("@enable", sale.Enable);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool InsertSaleDetail(Sale_Detail detail)
        {
            string query = "INSERT INTO Detalle_Venta (Id_Venta, Id_Platillo, Cantidad) VALUES (@saleId, @dishId, @qty)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@saleId", detail.Sale_Id);
                cmd.Parameters.AddWithValue("@dishId", detail.Dish_Id);
                cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
