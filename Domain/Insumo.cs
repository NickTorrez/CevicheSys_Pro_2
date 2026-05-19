using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Insumo
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _idInsumo;
        private string _nombre;
        private double _stockActual;
        private DateTime _fechaVencimiento;
        private string _origen;
        private int _idCategoria; // Relación con la clase Categoria

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int IdInsumo { get => _idInsumo; set => _idInsumo = value; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del insumo es obligatorio.");
                _nombre = value;
            }
        }

        public double StockActual
        {
            get => _stockActual;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El stock no puede ser negativo.");
                _stockActual = value;
            }
        }

        public DateTime FechaVencimiento { get => _fechaVencimiento; set => _fechaVencimiento = value; }
        public string Origen { get => _origen; set => _origen = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Insumo()
        {
            _nombre = string.Empty;
            _origen = string.Empty;
            _fechaVencimiento = DateTime.Now;
        }

        public Insumo(int id, string nombre, double stock, DateTime vencimiento, string origen, int idCat)
        {
            this._idInsumo = id;
            this._nombre = nombre;
            this._stockActual = stock;
            this._fechaVencimiento = vencimiento;
            this._origen = origen;
            this._idCategoria = idCat;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Lógica de Negocio                                          */
        /* --------------------------------------------------------------------- */

        //Actualización de Stock (Para cuando se realice una venta)
        public void DescontarStock(double cantidad)
        {
            if (cantidad > _stockActual)
                throw new Exception($"Stock insuficiente para {_nombre}. Disponible: {_stockActual}");

            _stockActual -= cantidad;
        }

        //Alerta de Frescura
        public bool EstaProximoAVencer()
        {
            // Retorna true si faltan 2 días o menos para que venza
            TimeSpan diferencia = _fechaVencimiento - DateTime.Today;
            return diferencia.TotalDays <= 2 && diferencia.TotalDays >= 0;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */

        private static string GetFilePath()// Método para obtener la ruta del archivo JSON
        {
            var baseDirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var projectRoot = baseDirInfo.Parent?.Parent?.Parent;
            if (projectRoot == null) throw new Exception("Ruta base no encontrada.");

            string dataFolder = Path.Combine(projectRoot.FullName, "Data");
            if (!Directory.Exists(dataFolder)) Directory.CreateDirectory(dataFolder);

            return Path.Combine(dataFolder, "insumos.json");
        }

        public bool Guardar()// Método para guardar o actualizar el insumo en el archivo JSON
        {
            try
            {
                string filePath = GetFilePath();
                List<Insumo> lista = Listar();

                int index = lista.FindIndex(i => i.IdInsumo == this.IdInsumo);
                if (index != -1)
                    lista[index] = this;
                else
                    lista.Add(this);

                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el insumo: {ex.Message}");
            }
        }

        public static List<Insumo> Listar()// Método para listar todos los insumos desde el archivo JSON
        {
            try
            {
                string path = GetFilePath();
                if (!File.Exists(path)) return new List<Insumo>();

                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Insumo>>(json) ?? new List<Insumo>();
            }
            catch { return new List<Insumo>(); }
        }
    }
}