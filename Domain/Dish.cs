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
        public int Dish_Id { get; set; }
        public string Dish_Type { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }        // ACTUALIZADO: Manejo financiero preciso
        public bool Is_Available { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Crea una instancia predeterminada de un Platillo.
        /// </summary>
        public Dish()
        {
            Dish_Type = string.Empty;
            Size = string.Empty;
            Price = 0.0m;
            Is_Available = true;
            Enable = true;
        }

        /// <summary>
        /// Crea un platillo asignando todos sus atributos comerciales.
        /// </summary>
        public Dish(int dishId, string dishType, string size, decimal price, bool isAvailable, bool enable = true)
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

        /// <summary>
        /// Obtiene el menú activo para su visualización en el Punto de Venta.
        /// </summary>
        public List<Dish> ListAllDishes()
        {
            var list = new List<Dish>();
            string query = "SELECT Dish_Id, Dish_Type, Size, Price, Is_Available, Enable FROM Dish WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Dish(
                        Convert.ToInt32(row["Dish_Id"]),
                        row["Dish_Type"].ToString(),
                        row["Size"].ToString(),
                        Convert.ToDecimal(row["Price"]),
                        Convert.ToBoolean(row["Is_Available"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        /// <summary>
        /// Registra el platillo configurado en el catálogo.
        /// </summary>
        public int AddDish()
        {
            string query = "INSERT INTO Dish (Dish_Type, Size, Price, Is_Available, Enable) VALUES (@type, @size, @price, @avail, @enable)";
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

        /// <summary>
        /// Aplica los cambios de precio, tamaño o disponibilidad al registro.
        /// </summary>
        public int UpdateDish()
        {
            string query = "UPDATE Dish SET Dish_Type = @type, Size = @size, Price = @price, Is_Available = @avail WHERE Dish_Id = @id";
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

        /// <summary>
        /// Retira el platillo del menú activo.
        /// </summary>
        public int DisableDish(int id)
        {
            string query = "UPDATE Dish SET Enable = 0 WHERE Dish_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

    }
}