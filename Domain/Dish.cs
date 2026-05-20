using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

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
        private double _price; // DECIMAL(10,2) mapeado a double para facilitar operaciones en C#
        private bool _availability;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }
        public string Dish_Type { get => _dish_Type; set => _dish_Type = value; }
        public string Size { get => _size; set => _size = value; }
        public double Price { get => _price; set => _price = value; }

        // Control de inventario en mostrador (true = Venta permitida)
        public bool Availability { get => _availability; set => _availability = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Dish()
        {
            _dish_Type = string.Empty;
            _size = string.Empty;
            _availability = true; // Por defecto al crear un registro, está disponible.
        }

        public Dish(int id, string dishType, string size, double price, bool availability = true)
        {
            _dish_Id = id;
            _dish_Type = dishType;
            _size = size;
            _price = price;
            _availability = availability;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        // Ruta unificada y limpia en la carpeta Data
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "dishes.json"); // Ruta unificada y limpia en la carpeta Data

        public static List<Dish> List() // Lee el archivo JSON y devuelve la lista de platillos
        {
            string directorio = Path.GetDirectoryName(PathArchivo); // Asegura que el directorio exista antes de intentar leer el archivo
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);// Crea el directorio si no existe

            if (!File.Exists(PathArchivo)) return new List<Dish>(); // Si el archivo no existe, devuelve una lista vacía
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Dish>>(json) ?? new List<Dish>();
        }

        public bool Save()
        {
            List<Dish> lista = List();

            if (this.Dish_Id == 0)
            {
                this.Dish_Id = lista.Count > 0 ? lista.Max(p => p.Dish_Id) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(p => p.Dish_Id == this.Dish_Id);
                if (index != -1) lista[index] = this;
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id)
        {
            List<Dish> lista = List();
            int index = lista.FindIndex(p => p.Dish_Id == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }

    }
}