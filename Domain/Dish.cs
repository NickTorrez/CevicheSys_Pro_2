using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Dish
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _dish_Id;
        private string _dish_Type;
        private string _size;
        private double _price;
        private bool _availability;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }
        public string Dish_Type { get => _dish_Type; set => _dish_Type = value; }
        public string Size { get => _size; set => _size = value; }
        public double Price { get => _price; set => _price = value; }
        public bool Availability { get => _availability; set => _availability = value; }


        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Dish()
        {

        }

        public Dish(int id, string dishType, string size, double price, bool isAvailable = true)
        {
            _dish_Id = id;
            _dish_Type = dishType;
            _size = size;
            _price = price;
            _availability = isAvailable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos                                        */
        /* --------------------------------------------------------------------- */
        public static List<Dish> List()
        {
            var list = new List<Dish>();
            string query = "SELECT Id_Platillo, Tipo_Platillo, Tamaño, Precio, Disponibilidad FROM Platillo";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Dish
                {
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"]),
                    Dish_Type = row["Tipo_Platillo"].ToString(),
                    Size = row["Tamaño"].ToString(),
                    Price = Convert.ToDouble(row["Precio"]),
                    Availability = Convert.ToBoolean(row["Disponibilidad"])
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@tipo", this.Dish_Type),
                new SqlParameter("@tam", this.Size),
                new SqlParameter("@precio", this.Price),
                new SqlParameter("@disp", this.Availability)
            };

            if (this.Dish_Id == 0)
            {
                string query = "INSERT INTO Platillo (Tipo_Platillo, Tamaño, Precio, Disponibilidad) VALUES (@tipo, @tam, @precio, @disp)";
                using var insert = new InsertCommand();
                this.Dish_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Platillo SET Tipo_Platillo=@tipo, Tamaño=@tam, Precio=@precio, Disponibilidad=@disp WHERE Id_Platillo=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.Dish_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
            }
            return true;
        }

    }
}