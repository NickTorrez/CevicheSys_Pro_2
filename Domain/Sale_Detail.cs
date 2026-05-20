using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Sale_Detail
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _detail_Id;
        private int _quantity;
        private int _sale_Id;    // Llave Foránea hacia Sale
        private int _dish_Id;    // Llave Foránea hacia Dish

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */

        public int Detail_Id { get => _detail_Id; set => _detail_Id = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int Sale_Id { get => _sale_Id; set => _sale_Id = value; }
        public int Dish_Id { get => _dish_Id; set => _dish_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale_Detail()
        {
        }

        public Sale_Detail(int id, int quantity, int saleId, int dishId)
        {
            _detail_Id = id;
            _quantity = quantity;
            _sale_Id = saleId;
            _dish_Id = dishId;
        }
        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "sale_details.json");

        public static List<Sale_Detail> List()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Sale_Detail>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Sale_Detail>>(json) ?? new List<Sale_Detail>();
        }

        public bool Save() // Guarda o actualiza un detalle de venta en el archivo JSON
        {
            List<Sale_Detail> lista = List();

            if (this.Detail_Id == 0)
            {
                this.Detail_Id = lista.Count > 0 ? lista.Max(d => d.Detail_Id) + 1 : 1; // Asigna un nuevo ID incremental
                lista.Add(this); // Agrega el nuevo detalle a la lista
            }
            else
            {
                int index = lista.FindIndex(d => d.Detail_Id == this.Detail_Id); // Busca el índice del detalle existente
                if (index != -1) lista[index] = this; // Actualiza el detalle existente
                else return false; // No se encontró el detalle para actualizar
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id) // Elimina un detalle de venta por su ID del archivo JSON
        {
            List<Sale_Detail> lista = List();
            int index = lista.FindIndex(d => d.Detail_Id == id); // Busca el índice del detalle a eliminar
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
        public static List<Sale_Detail> GetDetailsBySale(int saleId)
        {
            return List().Where(d => d.Sale_Id == saleId).ToList();
        }
    }
}