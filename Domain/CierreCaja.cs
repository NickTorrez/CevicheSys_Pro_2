using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class CierreCaja
    {
        /*__________________________________________________________/*
         * Clase para representar el cierre de caja diario.
         * Se puede usar para almacenar en base de datos o generar reportes.
         *__________________________________________________________*/
        public int Id_Cierre { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Usuario { get; set; }       // Quién hace el arqueo
        public double Fondo_Inicial { get; set; }   // Con cuánto se abrió caja (Caja Chica)
        public double Ingresos_Calculados { get; set; } // Lo que el sistema dice que hay (Ventas - Gastos)
        public double Efectivo_Real { get; set; }   // Lo que el usuario contó físicamente (Modo Manual)
        public double Descuadre { get; set; }       // Diferencia (Efectivo Real - Ingresos Calculados)
        public string Observaciones { get; set; }   // Percances o recordatorios

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "cierres_caja.json");

        public static List<CierreCaja> Listar()
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);
            if (!File.Exists(PathArchivo)) return new List<CierreCaja>();
            return JsonSerializer.Deserialize<List<CierreCaja>>(File.ReadAllText(PathArchivo)) ?? new List<CierreCaja>();
        }

        /// <summary>
        /// Realiza el cálculo automático de lo que debería haber en caja en el día actual.
        /// </summary>
        public static double CalcularEfectivoTeorico(double fondoInicial)
        {
            DateTime inicioDia = DateTime.Today;
            DateTime finDia = DateTime.Today.AddDays(1).AddTicks(-1);

            // Sumar ventas en efectivo (asumiendo que tarjeta va directo al banco)
            double ventasEfectivo = Venta.Listar()
                .Where(v => v.Fecha_Registro >= inicioDia && v.Fecha_Registro <= finDia && v.Metodo_Pago == "Efectivo")
                .Sum(v => v.Total_Pagar);

            // Restar egresos/gastos pagados con dinero de la caja chica
            double gastosCaja = Gasto.Listar()
                .Where(g => g.Fecha >= inicioDia && g.Fecha <= finDia)
                .Sum(g => g.Monto);

            return fondoInicial + ventasEfectivo - gastosCaja;
        }

        public bool RegistrarCierre()
        {
            List<CierreCaja> lista = Listar();
            this.Id_Cierre = lista.Count > 0 ? lista.Max(c => c.Id_Cierre) + 1 : 1;
            this.Descuadre = this.Efectivo_Real - this.Ingresos_Calculados;
            this.Fecha = DateTime.Now;

            lista.Add(this);
            File.WriteAllText(PathArchivo, JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true }));
            return true;
        }
    }
}