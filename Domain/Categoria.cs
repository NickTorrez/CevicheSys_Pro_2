using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class Categoria
    {
        // Campos privados 
        private int _id_Categoria;
        private string _nombre_Categoria;
        private string _modulo_Aplica; // Debe ser estrictamente "Inventario" o "Gastos"

        // Propiedades públicas
        public int Id_Categoria { get => _id_Categoria; set => _id_Categoria = value; }
        public string Nombre_Categoria { get => _nombre_Categoria; set => _nombre_Categoria = value; }
        public string Modulo_Aplica { get => _modulo_Aplica; set => _modulo_Aplica = value; }


        // Constructor sin parámetros (Útil para serialización JSON)
        public Categoria()
        {
            _nombre_Categoria = string.Empty;
            _modulo_Aplica = string.Empty;
        }

        public Categoria(int id, string nombreCategoria, string moduloAplica)
        {
            _id_Categoria = id;
            _nombre_Categoria = nombreCategoria;
            _modulo_Aplica = moduloAplica;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (Basados en el modelo de RRHH)                */
        /* --------------------------------------------------------------------- */

        /*private static string GetFilePath()// Este método construye la ruta completa al archivo JSON donde se almacenarán las categorías.
        {
            var baseDirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            // Ajuste de niveles para llegar a la carpeta raíz donde está /Data
            var projectRoot = baseDirInfo.Parent?.Parent?.Parent;
            if (projectRoot == null) throw new Exception("No se encontró la raíz del proyecto.");

            string dataFolder = Path.Combine(projectRoot.FullName, "Data");
            if (!Directory.Exists(dataFolder)) Directory.CreateDirectory(dataFolder);

            return Path.Combine(dataFolder, "categorias.json");
        }/*/

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "categorias.json");
        public static List<Categoria> Listar()
        {
            if (!File.Exists(PathArchivo)) // Si el archivo no existe, lo creamos con una lista por defecto
            {
                // Pre-cargamos clasificaciones sugeridas por el documento de funciones
                var listaPorDefecto = new List<Categoria>
                {
                    new Categoria(1, "Mariscos", "Inventario"),
                    new Categoria(2, "Ingredientes", "Inventario"),
                    new Categoria(3, "Envases", "Inventario"),
                    new Categoria(4, "Plásticos", "Inventario"),
                    new Categoria(5, "Compras de Insumos", "Gastos"),
                    new Categoria(6, "Servicios", "Gastos"),
                    new Categoria(7, "Mantenimiento", "Gastos"),
                    new Categoria(8, "Otros", "Gastos")
                };
                string json = JsonSerializer.Serialize(listaPorDefecto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return listaPorDefecto;
            }

            string jsonExistente = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Categoria>>(jsonExistente) ?? new List<Categoria>();
        }

        // Método clave para filtrar dinámicamente los ComboBoxes de tus pantallas WinForms
        public static List<Categoria> ObtenerCategoriasPorModulo(string modulo)
        {
            return Listar()
                .Where(c => c.Modulo_Aplica.Equals(modulo, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool Guardar()
        {
            List<Categoria> lista = Listar();

            if (this.Id_Categoria == 0)
            {
                this.Id_Categoria = lista.Count > 0 ? lista.Max(c => c.Id_Categoria) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(c => c.Id_Categoria == this.Id_Categoria);
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