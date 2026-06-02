using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Sale
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _sale_Id;
        private int _customer_Id; // Cambio 3NF: En lugar de Customer_Name
        private string _payment_Method;
        private string _purchase_Type;
        private double _total_Amount;
        private DateTime _record_Date;
        private int _user_Id;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Sale_Id { get => _sale_Id; set => _sale_Id = value; }
        public int Customer_Id { get => _customer_Id; set => _customer_Id = value; }
        public string Payment_Method { get => _payment_Method; set => _payment_Method = value; }
        public string Purchase_Type { get => _purchase_Type; set => _purchase_Type = value; }
        public double Total_Amount { get => _total_Amount; set => _total_Amount = value; }
        public DateTime Record_Date { get => _record_Date; set => _record_Date = value; }
        public int User_Id { get => _user_Id; set => _user_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale()
        {
            _customer_Id = 0;
            _payment_Method = string.Empty;
            _purchase_Type = string.Empty;
            _record_Date = DateTime.Now;
        }

        public Sale(int id, int customerId, string paymentMethod, string purchaseType, double totalAmount, DateTime recordDate, int userId)
        {
            _sale_Id = id;
            _customer_Id = customerId;
            _payment_Method = paymentMethod;
            _purchase_Type = purchaseType;
            _total_Amount = totalAmount;
            _record_Date = recordDate;
            _user_Id = userId;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@cli", this.Customer_Id),
                new SqlParameter("@pago", this.Payment_Method),
                new SqlParameter("@tipo", this.Purchase_Type),
                new SqlParameter("@total", this.Total_Amount),
                new SqlParameter("@fecha", this.Record_Date),
                new SqlParameter("@usr", this.User_Id)
            };

            if (this.Sale_Id == 0)
            {
                string query = "INSERT INTO Venta (Id_Cliente, Metodo_Pago, Tipo_Compra, Total_Pagar, Fecha_Registro, Id_Usuario) VALUES (@cli, @pago, @tipo, @total, @fecha, @usr)";
                using var insert = new InsertCommand();
                this.Sale_Id = insert.ExecuteInsertReturnId(query, p);
                return true;
            }
            return false;
        }

        public bool SaveWithDetails(List<Sale_Detail> details)
        {
            // 1. Guardar la cabecera en SQL
            this.Save();

            // 2. Guardar detalles
            foreach (var detalle in details)
            {
                detalle.Sale_Id = this.Sale_Id;

                string qDet = "INSERT INTO Detalle_Venta (Cantidad, Id_Venta, Id_Platillo) VALUES (@cant, @ven, @plat)";
                using var insertDet = new InsertCommand();
                insertDet.ExecuteInsert(qDet, new[] {
                    new SqlParameter("@cant", detalle.Quantity),
                    new SqlParameter("@ven", detalle.Sale_Id),
                    new SqlParameter("@plat", detalle.Dish_Id)
                });

                // 3. Descuento Automático de Inventario vía SQL Directo (Mucho más óptimo)
                string qDesc = @"
                    UPDATE p SET p.Stock_Actual = p.Stock_Actual - (r.Cantidad_Utilizada * @cantComprada)
                    FROM Producto p
                    INNER JOIN Receta r ON p.Id_Producto = r.Id_Producto
                    WHERE r.Id_Platillo = @plat";

                using var updateStock = new UpdateCommand();
                updateStock.ExecuteUpdate(qDesc, new[] {
                    new SqlParameter("@cantComprada", detalle.Quantity),
                    new SqlParameter("@plat", detalle.Dish_Id)
                });
            }
            return true;
        }
    }
}
