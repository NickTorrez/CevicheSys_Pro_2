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
    /// Administra el catálogo del menú, permitiendo su creación, edición, y listado general.
    /// </summary>
    public class DishBusiness
    {
        private readonly string _connectionString;

        public DishBusiness(string connectionString) => _connectionString = connectionString;

        public List<Dish> ObtainMenu()
        {
            var list = new List<Dish>();
            string query = "SELECT Id_Platillo, Tipo_Platillo, Tamaño, Precio, Is_Available, Enable FROM Platillo WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Dish(
                            Convert.ToInt32(r["Id_Platillo"]),
                            r["Tipo_Platillo"].ToString(),
                            r["Tamaño"].ToString(),
                            Convert.ToDouble(r["Precio"]),
                            Convert.ToBoolean(r["Is_Available"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public List<Dish> ObtainAvailableMenu() => ObtainMenu().FindAll(d => d.Is_Available);

        public bool RegisterDish(Dish dish)
        {
            if (dish == null) throw new ArgumentNullException(nameof(dish));
            if (dish.Price <= 0) throw new ArgumentException("El precio debe ser mayor a cero.");

            string query = "INSERT INTO Platillo (Tipo_Platillo, Tamaño, Precio, Is_Available, Enable) VALUES (@type, @size, @price, @avail, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@type", dish.Dish_Type);
                cmd.Parameters.AddWithValue("@size", dish.Size);
                cmd.Parameters.AddWithValue("@price", dish.Price);
                cmd.Parameters.AddWithValue("@avail", dish.Is_Available);
                cmd.Parameters.AddWithValue("@enable", dish.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifyDish(Dish dish)
        {
            if (dish == null || dish.Dish_Id <= 0) throw new ArgumentException("Platillo inválido.");

            string query = "UPDATE Platillo SET Tipo_Platillo = @type, Tamaño = @size, Precio = @price, Is_Available = @avail WHERE Id_Platillo = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", dish.Dish_Id);
                cmd.Parameters.AddWithValue("@type", dish.Dish_Type);
                cmd.Parameters.AddWithValue("@size", dish.Size);
                cmd.Parameters.AddWithValue("@price", dish.Price);
                cmd.Parameters.AddWithValue("@avail", dish.Is_Available);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveDish(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Platillo SET Enable = 0 WHERE Id_Platillo = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
