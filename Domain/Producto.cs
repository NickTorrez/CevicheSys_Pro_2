using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Producto
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Producto;
        private string _nombre;
        private int _id_Proveedor;   // Llave Foránea hacia Proveedor
        private int _id_Categoria;   // Llave Foránea hacia Categoria
        private double _stock_Actual; // Usamos double por si manejas libras/fracciones (Ej: 2.5 kg de pescado)
        private double _stock_Minimo; // Umbral personalizado para disparar alertas de stock bajo
        private DateTime? _fecha_Vencimiento; // Nullable (?) para productos no perecederos

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Id_Producto { get => _id_Producto; set => _id_Producto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Id_Proveedor { get => _id_Proveedor; set => _id_Proveedor = value; }
        public int Id_Categoria { get => _id_Categoria; set => _id_Categoria = value; }
        public double Stock_Actual { get => _stock_Actual; set => _stock_Actual = value; }
        public double Stock_Minimo { get => _stock_Minimo; set => _stock_Minimo = value; }
        public DateTime? Fecha_Vencimiento { get => _fecha_Vencimiento; set => _fecha_Vencimiento = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Producto()
        {
            _nombre = string.Empty;
        }

        public Producto(int id, string nombre, int idProveedor, int idCategoria, double stockActual, double stockMinimo, DateTime? fechaVencimiento)
        {
            _id_Producto = id;
            _nombre = nombre;
            _id_Proveedor = idProveedor;
            _id_Categoria = idCategoria;
            _stock_Actual = stockActual;
            _stock_Minimo = stockMinimo;
            _fecha_Vencimiento = fechaVencimiento;
        }



        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "inventory.json");

        public static List<Producto> Listar()
        {
            // Garantiza la existencia segura de la carpeta Data antes de leer/escribir
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Producto>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
        }

        public bool Guardar()
        {
            List<Producto> lista = Listar();

            if (this.Id_Producto == 0)
            {
                this.Id_Producto = lista.Count > 0 ? lista.Max(p => p.Id_Producto) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(p => p.Id_Producto == this.Id_Producto);
                if (index != -1) lista[index] = this;
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Eliminar(int id)
        {
            List<Producto> lista = Listar();
            int index = lista.FindIndex(p => p.Id_Producto == id);
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
        /* MÉTODOS DE CONTROL OPERATIVO (ALERTAS)                                */
        /* ===================================================================== */

        // Alerta de Stock Bajo: Filtra productos cuya existencia está en o por debajo del mínimo establecido
        public static List<Producto> ObtenerStockBajo()
        {
            return Listar().Where(p => p.Stock_Actual <= p.Stock_Minimo).ToList();
        }

        // Alerta de Frescura: Filtra productos próximos a vencer según un margen de días (Por defecto 3 días)
        public static List<Producto> ObtenerProximosAVencer(int diasMargen = 3)
        {
            return Listar()
                .Where(p => p.Fecha_Vencimiento.HasValue &&
                            p.Fecha_Vencimiento.Value.Date >= DateTime.Today &&
                            (p.Fecha_Vencimiento.Value.Date - DateTime.Today).TotalDays <= diasMargen)
                .ToList();
        }
    }

}
