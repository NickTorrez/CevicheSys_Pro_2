using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class Category
    {
        // Campos privados 
        private int _category_Id;
        private string _category_Name;
        private string _target_Module; // Debe ser estrictamente "Inventario" o "Gastos"

        // Propiedades públicas
        public int Category_Id { get => _category_Id; set => _category_Id = value; }
        public string Category_Name { get => _category_Name; set => _category_Name = value; }
        public string Target_Module { get => _target_Module; set => _target_Module = value; }

        // Constructor sin parámetros (Útil para serialización JSON)
        public Category()
        {
            _category_Name = string.Empty;
            _target_Module = string.Empty;
        }

        public Category(int id, string categoryName, string targetModule)
        {
            _category_Id = id;
            _category_Name = categoryName;
            _target_Module = targetModule;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (Basados en el modelo de RRHH)                */
        /* --------------------------------------------------------------------- */

        // Ruta unificada y limpia en la carpeta Data
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "categories.json");

        public static List<Category> List()
        {
            if (!File.Exists(PathArchivo)) // Si el archivo no existe, lo creamos con una lista por defecto
            {
                // Pre-cargamos clasificaciones sugeridas por el documento de funciones
                var listaPorDefecto = new List<Category>
                {
                    new Category(1, "Mariscos", "Inventario"),
                    new Category(2, "Ingredientes", "Inventario"),
                    new Category(3, "Envases", "Inventario"),
                    new Category(4, "Plásticos", "Inventario"),
                    new Category(5, "Compras de Insumos", "Gastos"),
                    new Category(6, "Servicios", "Gastos"),
                    new Category(7, "Mantenimiento", "Gastos"),
                    new Category(8, "Otros", "Gastos")
                };
                string json = JsonSerializer.Serialize(listaPorDefecto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return listaPorDefecto;
            }

            string jsonExistente = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Category>>(jsonExistente) ?? new List<Category>();
        }

        // Método clave para filtrar dinámicamente los ComboBoxes de tus pantallas WinForms
        public static List<Category> GetCategoriesByModule(string module)
        {
            return List()
                .Where(c => c.Target_Module.Equals(module, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool Save()
        {
            List<Category> lista = List();

            if (this.Category_Id == 0)
            {
                this.Category_Id = lista.Count > 0 ? lista.Max(c => c.Category_Id) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(c => c.Category_Id == this.Category_Id);
                if (index != -1)
                {
                    lista[index] = this;
                }
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

    }
}