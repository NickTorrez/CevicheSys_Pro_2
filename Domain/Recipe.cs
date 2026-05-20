using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class Recipe
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos Privados (Encapsulamiento)                         */
        /* --------------------------------------------------------------------- */
        private int _recipe_Id;
        private int _dish_Id;             // Llave Foránea hacia Dish
        private int _product_Id;          // Llave Foránea hacia Product (Insumo)
        private double _quantity_Used;    // Cantidad, peso o proporción requerida

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
        /* Propiedades Públicas (Getters y Setters)                              */
        /* --------------------------------------------------------------------- */
        public int Recipe_Id { get => _recipe_Id; set => _recipe_Id = value; }
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }
        public int Product_Id { get => _product_Id; set => _product_Id = value; }
        public double Quantity_Used { get => _quantity_Used; set => _quantity_Used = value; }

        /* --------------------------------------------------------------------- */
        /* Métodos de Simulación de Persistencia (Similares a tu estructura)     */
        /* --------------------------------------------------------------------- */
        // Ruta unificada y limpia en la carpeta Data
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "recipes.json");

        public static List<Recipe> List()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Recipe>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
        }

        public bool Save()
        {
            List<Recipe> lista = List();

            if (this.Recipe_Id == 0)
            {
                this.Recipe_Id = lista.Count > 0 ? lista.Max(r => r.Recipe_Id) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(r => r.Recipe_Id == this.Recipe_Id);
                if (index != -1) lista[index] = this;
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id)
        {
            List<Recipe> lista = List();
            int index = lista.FindIndex(r => r.Recipe_Id == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }

        /* ===================================================================== */
        /* MÉTODOS DE CONSULTA INTERRELACIONAL                                   */
        /* ===================================================================== */

        // Filtra y expone los ingredientes/proporciones asociados a un platillo en específico
        public static List<Recipe> GetIngredientsByDish(int dishId)
        {
            return List().Where(r => r.Dish_Id == dishId).ToList();
        }
    }
}