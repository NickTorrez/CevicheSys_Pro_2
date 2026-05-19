using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class Receta
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos Privados (Encapsulamiento)                         */
        /* --------------------------------------------------------------------- */
        private int _id_Receta;
        private int _id_Platillo;         // Llave Foránea hacia Platillo
        private int _id_Producto;         // Llave Foránea hacia Producto (Insumo)
        private double _cantidad_Utilizada; // Cantidad, peso o proporción requerida

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Receta()
        {
        }

        public Receta(int id, int idPlatillo, int idProducto, double cantidadUtilizada)
        {
            _id_Receta = id;
            _id_Platillo = idPlatillo;
            _id_Producto = idProducto;
            _cantidad_Utilizada = cantidadUtilizada;
        }

        /* --------------------------------------------------------------------- */
        /* Propiedades Públicas (Getters y Setters)                              */
        /* --------------------------------------------------------------------- */
        public int Id_Receta { get => _id_Receta; set => _id_Receta = value; }
        public int Id_Platillo { get => _id_Platillo; set => _id_Platillo = value; }
        public int Id_Producto { get => _id_Producto; set => _id_Producto = value; }
        public double Cantidad_Utilizada { get => _cantidad_Utilizada; set => _cantidad_Utilizada = value; }

        /* --------------------------------------------------------------------- */
        /* Métodos de Simulación de Persistencia (Similares a tu estructura)     */
        /* --------------------------------------------------------------------- */
        // Ruta unificada y limpia en la carpeta Data
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "recetas.json");

        public static List<Receta> Listar()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Receta>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Receta>>(json) ?? new List<Receta>();
        }

        public bool Guardar()
        {
            List<Receta> lista = Listar();

            if (this.Id_Receta == 0)
            {
                this.Id_Receta = lista.Count > 0 ? lista.Max(r => r.Id_Receta) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(r => r.Id_Receta == this.Id_Receta);
                if (index != -1) lista[index] = this;
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Eliminar(int id)
        {
            List<Receta> lista = Listar();
            int index = lista.FindIndex(r => r.Id_Receta == id);
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
        public static List<Receta> ObtenerInsumosPorPlatillo(int idPlatillo)
        {
            return Listar().Where(r => r.Id_Platillo == idPlatillo).ToList();
        }
    }
}