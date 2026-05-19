using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class DetalleVenta
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Detalle;
        private int _cantidad;
        private int _id_Venta;    // Llave Foránea hacia Venta
        private int _id_Platillo; // Llave Foránea hacia Platillo

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */

        public int Id_Detalle { get => _id_Detalle; set => _id_Detalle = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public int Id_Venta { get => _id_Venta; set => _id_Venta = value; }
        public int Id_Platillo { get => _id_Platillo; set => _id_Platillo = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public DetalleVenta()
        {
        }

        public DetalleVenta(int id, int cantidad, int idVenta, int idPlatillo)
        {
            _id_Detalle = id;
            _cantidad = cantidad;
            _id_Venta = idVenta;
            _id_Platillo = idPlatillo;
        }
        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "detalles_ventas.json");

        public static List<DetalleVenta> Listar()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<DetalleVenta>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<DetalleVenta>>(json) ?? new List<DetalleVenta>();
        }

        public bool Guardar() // Guarda o actualiza un detalle de venta en el archivo JSON
        {
            List<DetalleVenta> lista = Listar();

            if (this.Id_Detalle == 0)
            {
                this.Id_Detalle = lista.Count > 0 ? lista.Max(d => d.Id_Detalle) + 1 : 1; // Asigna un nuevo ID incremental
                lista.Add(this); // Agrega el nuevo detalle a la lista
            }
            else
            {
                int index = lista.FindIndex(d => d.Id_Detalle == this.Id_Detalle); // Busca el índice del detalle existente
                if (index != -1) lista[index] = this; // Actualiza el detalle existente
                else return false; // No se encontró el detalle para actualizar
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Eliminar(int id) // Elimina un detalle de venta por su ID del archivo JSON
        {
            List<DetalleVenta> lista = Listar();
            int index = lista.FindIndex(d => d.Id_Detalle == id); // Busca el índice del detalle a eliminar
            if (index != -1)// Si se encuentra el detalle, se elimina de la lista y se actualiza el archivo JSON
            {
                lista.RemoveAt(index); // Elimina el detalle de la lista
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });// Serializa la lista actualizada a JSON
                File.WriteAllText(PathArchivo, json);// Escribe el JSON actualizado en el archivo
                return true;
            }
            return false;
        }

        /* ===================================================================== */
        /* MÉTODOS DE FILTRADO                                                   */
        /* ===================================================================== */

        // Trae los detalles específicos vinculados a una factura/boucher única
        public static List<DetalleVenta> ObtenerDetallesPorVenta(int idVenta)
        {
            return Listar().Where(d => d.Id_Venta == idVenta).ToList();
        }
    }
}