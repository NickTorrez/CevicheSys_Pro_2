using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Gasto
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Gasto;
        private string _concepto;
        private double _monto;
        private DateTime _fecha;
        private int _id_Categoria; // Llave foránea hacia Categoria (Modulo_Aplica == "Gastos")

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Id_Gasto { get => _id_Gasto; set => _id_Gasto = value; }
        public string Concepto { get => _concepto; set => _concepto = value; }
        public double Monto { get => _monto; set => _monto = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int Id_Categoria { get => _id_Categoria; set => _id_Categoria = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Gasto()
        {
            _concepto = string.Empty;
            _fecha = DateTime.Now;
        }

        public Gasto(int id, string concepto, double monto, DateTime fecha, int idCategoria)
        {
            _id_Gasto = id;
            _concepto = concepto;
            _monto = monto;
            _fecha = fecha;
            _id_Categoria = idCategoria;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "gastos.json");

        public static List<Gasto> Listar()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Gasto>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Gasto>>(json) ?? new List<Gasto>();
        }

        public bool Guardar()
        {
            List<Gasto> lista = Listar();

            if (this.Id_Gasto == 0)
            {
                this.Id_Gasto = lista.Count > 0 ? lista.Max(g => g.Id_Gasto) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                int index = lista.FindIndex(g => g.Id_Gasto == this.Id_Gasto);
                if (index != -1) lista[index] = this;
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Eliminar(int id)
        {
            List<Gasto> lista = Listar();
            int index = lista.FindIndex(g => g.Id_Gasto == id);
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