using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace CevicheSys_Pro_2
{
    public class Cash_Closure
    {
        /*__________________________________________________________/*
         * Clase para representar el cierre de caja diario.
         * Se puede usar para almacenar en base de datos o generar reportes.
         *__________________________________________________________*/
        public int Closure_Id { get; set; }
        public DateTime Closure_Date { get; set; }
        public int User_Id { get; set; }       // Quién hace el arqueo
        public double Initial_Cash { get; set; }   // Con cuánto se abrió caja (Caja Chica)
        public double Calculated_Income { get; set; } // Lo que el sistema dice que hay (Ventas - Gastos)
        public double Real_Cash { get; set; }   // Lo que el usuario contó físicamente (Modo Manual)
        public double Cash_Discrepancy { get; set; }       // Diferencia (Efectivo Real - Ingresos Calculados)
        public string Notes_Remarks { get; set; }   // Percances o recordatorios

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "cash_closures.json");

        public static List<Cash_Closure> List()
        {
            string directory = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!File.Exists(PathArchivo)) return new List<Cash_Closure>();
            return JsonSerializer.Deserialize<List<Cash_Closure>>(File.ReadAllText(PathArchivo)) ?? new List<Cash_Closure>();
        }

        /// <summary>
        /// Realiza el cálculo automático de lo que debería haber en caja en el día actual.
        /// </summary>
        public static double CalculateTheoreticalCash(double initialCash)
        {
            DateTime startOfDay = DateTime.Today;
            DateTime endOfDay = DateTime.Today.AddDays(1).AddTicks(-1);

            // Sumar ventas en efectivo (asumiendo que tarjeta va directo al banco)
            // Llama a la clase Sale (Venta) traducida previamente
            double cashSales = Sale.List()
                .Where(v => v.Record_Date >= startOfDay && v.Record_Date <= endOfDay && v.Payment_Method == "Efectivo")
                .Sum(v => v.Total_Amount);

            // Restar egresos/gastos pagados con dinero de la caja chica
            // Llama a la clase Expense (Gasto) traducida arriba
            double pettyCashExpenses = Expense.List()
                .Where(g => g.Expense_Date >= startOfDay && g.Expense_Date <= endOfDay)
                .Sum(g => g.Amount);

            return initialCash + cashSales - pettyCashExpenses;
        }

        public bool RegisterClosure()
        {
            List<Cash_Closure> list = List();
            this.Closure_Id = list.Count > 0 ? list.Max(c => c.Closure_Id) + 1 : 1;
            this.Cash_Discrepancy = this.Real_Cash - this.Calculated_Income;
            this.Closure_Date = DateTime.Now;

            list.Add(this);
            File.WriteAllText(PathArchivo, JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }));
            return true;
        }
    }
}