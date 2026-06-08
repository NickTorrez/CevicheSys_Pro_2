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
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Dish_Id { get; set; }          // Id_Platillo (PK)
        public string Dish_Type { get; set; }     // Tipo_Platillo (Ej: Pescado, Camarón)
        public string Size { get; set; }          // Tamaño (Ej: 12 onz, 25 onz)
        public double Price { get; set; }         // Precio en Córdobas
        public bool Is_Available { get; set; }    // Disponibilidad diaria (1 = Disponible, 0 = Agotado)
        public bool Enable { get; set; }          // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Dish()
        {
            Dish_Type = string.Empty;
            Size = string.Empty;
            Price = 0.0;
            Is_Available = true;
            Enable = true;
        }

        public Dish(int dishId, string dishType, string size, double price, bool isAvailable, bool enable = true)
        {
            Dish_Id = dishId;
            Dish_Type = dishType;
            Size = size;
            Price = price;
            Is_Available = isAvailable;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        public List<Dish> ListAllDishes()
        {
            var list = new List<Dish>();
            string query = "SELECT Id_Platillo, Tipo_Platillo, Tamaño, Precio, Is_Available, Enable FROM Platillo WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Dish(
                        Convert.ToInt32(row["Id_Platillo"]),
                        row["Tipo_Platillo"].ToString(),
                        row["Tamaño"].ToString(),
                        Convert.ToDouble(row["Precio"]),
                        Convert.ToBoolean(row["Is_Available"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddDish()
        {
            string query = "INSERT INTO Platillo (Tipo_Platillo, Tamaño, Precio, Is_Available, Enable) VALUES (@type, @size, @price, @avail, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@type", this.Dish_Type),
                new SqlParameter("@size", this.Size),
                new SqlParameter("@price", this.Price),
                new SqlParameter("@avail", this.Is_Available),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateDish()
        {
            string query = "UPDATE Platillo SET Tipo_Platillo = @type, Tamaño = @size, Precio = @price, Is_Available = @avail WHERE Id_Platillo = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", this.Dish_Id),
                new SqlParameter("@type", this.Dish_Type),
                new SqlParameter("@size", this.Size),
                new SqlParameter("@price", this.Price),
                new SqlParameter("@avail", this.Is_Available)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableDish(int id)
        {
            string query = "UPDATE Platillo SET Enable = 0 WHERE Id_Platillo = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

    }
}