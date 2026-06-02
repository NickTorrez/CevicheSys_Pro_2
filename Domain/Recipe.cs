using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Recipe
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos Privados (Encapsulamiento)                         */
        /* --------------------------------------------------------------------- */
        private int _recipe_Id;
        private int _dish_Id;
        private int _product_Id;
        private double _quantity_Used;

        /* '--------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Recipe_Id { get => _recipe_Id; set => _recipe_Id = value; }
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }
        public int Product_Id { get => _product_Id; set => _product_Id = value; }
        public double Quantity_Used { get => _quantity_Used; set => _quantity_Used = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Recipe()
        {
        }

        public Recipe(int id, int dishId, int productId, double quantityUsed)
        {
            _recipe_Id = id;
            _dish_Id = dishId;
            _product_Id = productId;
            _quantity_Used = quantityUsed;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos                                                              */
        /* --------------------------------------------------------------------- */
        public static List<Recipe> List()
        {
            var list = new List<Recipe>();
            string query = "SELECT Id_Receta, Cantidad_Utilizada, Id_Platillo, Id_Producto FROM Receta";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Recipe
                {
                    Recipe_Id = Convert.ToInt32(row["Id_Receta"]),
                    Quantity_Used = Convert.ToDouble(row["Cantidad_Utilizada"]),
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"]),
                    Product_Id = Convert.ToInt32(row["Id_Producto"])
                });
            }
            return list;
        }

        // Optimización: Ahora el motor SQL filtra los datos, no la memoria RAM
        public static List<Recipe> GetIngredientsByDish(int dishId)
        {
            var list = new List<Recipe>();
            string query = "SELECT Id_Receta, Cantidad_Utilizada, Id_Platillo, Id_Producto FROM Receta WHERE Id_Platillo = @id";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query, new[] { new SqlParameter("@id", dishId) });

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Recipe
                {
                    Recipe_Id = Convert.ToInt32(row["Id_Receta"]),
                    Quantity_Used = Convert.ToDouble(row["Cantidad_Utilizada"]),
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"]),
                    Product_Id = Convert.ToInt32(row["Id_Producto"])
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@cant", this.Quantity_Used),
                new SqlParameter("@plat", this.Dish_Id),
                new SqlParameter("@prod", this.Product_Id)
            };

            if (this.Recipe_Id == 0)
            {
                string query = "INSERT INTO Receta (Cantidad_Utilizada, Id_Platillo, Id_Producto) VALUES (@cant, @plat, @prod)";
                using var insert = new InsertCommand();
                this.Recipe_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Receta SET Cantidad_Utilizada=@cant, Id_Platillo=@plat, Id_Producto=@prod WHERE Id_Receta=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.Recipe_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
            }
            return true;
        }
    }
}