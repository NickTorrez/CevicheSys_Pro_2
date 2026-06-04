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
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Product_Id { get; set; }            // Id_Producto (PK) 
        public string Product_Name { get; set; }       // Nombre 
        public int Supplier_Id { get; set; }           // Id_Proveedor (FK) 
        public int Category_Id { get; set; }           // Id_Categoria (FK) 
        public double Current_Stock { get; set; }      // Stock_Actual (Manejado con double para libras/fracciones)
        public double Minimum_Stock { get; set; }      // Umbral para disparar alertas de stock bajo 
        public DateTime? Expiration_Date { get; set; } // Fecha_Vencimiento (Nullable para productos no perecederos) 
        public bool Enable { get; set; }               // Enable 

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Product()
        {
            Product_Name = string.Empty;
            Current_Stock = 0.0;
            Minimum_Stock = 0.0;
            Enable = true;
        }

        public Product(int productId, string productName, int supplierId, int categoryId,
                       double currentStock, double minimumStock, DateTime? expirationDate, bool enable = true)
        {
            Product_Id = productId;
            Product_Name = productName;
            Supplier_Id = supplierId;
            Category_Id = categoryId;
            Current_Stock = currentStock;
            Minimum_Stock = minimumStock;
            Expiration_Date = expirationDate;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Reglas Operativas                                                     */
        /* --------------------------------------------------------------------- */
        public bool RequiresRestock()
        {
            return Current_Stock <= Minimum_Stock;
        }
    }

}
