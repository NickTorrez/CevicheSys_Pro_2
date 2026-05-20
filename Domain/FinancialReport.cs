using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class FinancialReport
    {
        private DateTime _startDate;
        private DateTime _endDate;

        /// <summary>
        /// Constructor que inicializa el filtro de tiempo del reporte.
        /// </summary>
        /// <param name="startDate">Fecha desde donde inicia el filtro.</param>
        /// <param name="endDate">Fecha límite del filtro.</param>
        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            // Ajustamos las horas para que abarque desde el primer segundo del día inicial 
            // hasta el último milisegundo del día final seleccionado.
            _startDate = startDate.Date;
            _endDate = endDate.Date.AddDays(1).AddTicks(-1);
        }

        /* ===================================================================== */
        /* 1. PANELES NUMÉRICOS PRINCIPALES                                      */
        /* ===================================================================== */

        public double CalculateTotalIncome()
        {
            return Sale.List()
                .Where(v => v.Record_Date >= _startDate && v.Record_Date <= _endDate)
                .Sum(v => v.Total_Amount);
        }

        public double CalculateTotalExpenses()
        {
            return Expense.List()
                .Where(g => g.Expense_Date >= _startDate && g.Expense_Date <= _endDate)
                .Sum(g => g.Amount);
        }

        public double CalculateTotalProfit()
        {
            return CalculateTotalIncome() - CalculateTotalExpenses();
        }

        /* ===================================================================== */
        /* 2. PANELES ANALÍTICOS SECUNDARIOS                                     */
        /* ===================================================================== */

        /// <summary>
        /// Analiza los detalles de ventas en el periodo de tiempo y retorna el objeto Platillo con más demanda.
        /// </summary>
        public Dish GetMostSoldDish()
        {
            // Filtramos los IDs de ventas que caen en el rango de fechas para optimizar la búsqueda
            var ventasEnRango = Sale.List()
                .Where(v => v.Record_Date >= _startDate && v.Record_Date <= _endDate)
                .Select(v => v.Sale_Id)
                .ToHashSet();

            // Agrupamos los detalles por Dish_Id y sumamos la cantidad total vendida
            var topPlatilloGrupo = Sale_Detail.List()
                .Where(d => ventasEnRango.Contains(d.Sale_Id))
                .GroupBy(d => d.Dish_Id)
                .Select(grupo => new { Dish_Id = grupo.Key, TotalUnidades = grupo.Sum(d => d.Quantity) })
                .OrderByDescending(x => x.TotalUnidades)
                .FirstOrDefault();

            if (topPlatilloGrupo != null)
            {
                // Retornamos el objeto completo del platillo encontrado
                return Dish.List().FirstOrDefault(p => p.Dish_Id == topPlatilloGrupo.Dish_Id);
            }

            return null; // En caso de que no existan ventas en ese periodo
        }

        /// <summary>
        /// Analiza la tabla de gastos en el periodo e indica cuál es el concepto que más veces se repitió.
        /// </summary>
        public string GetMostFrequentExpense()
        {
            var topGasto = Expense.List()
                .Where(g => g.Expense_Date >= _startDate && g.Expense_Date <= _endDate)
                .GroupBy(g => g.Description)
                .Select(grupo => new { Description = grupo.Key, Conteo = grupo.Count() })
                .OrderByDescending(x => x.Conteo)
                .FirstOrDefault();

            return topGasto != null ? topGasto.Description : "Sin registros";
        }

        /* ===================================================================== */
        /* 3. HISTORIAL DE VENTAS DETALLADO (Combinación Multi-Tabla)           */
        /* ===================================================================== */

        /// <summary>
        /// Cruza los datos de Sale_Detail, Sale, Dish y User para desplegar la auditoría completa.
        /// </summary>
        public List<DetailedSaleDTO> GetSalesHistory()
        {
            var listaVentas = Sale.List().Where(v => v.Record_Date >= _startDate && v.Record_Date <= _endDate).ToList();
            var listaDetalles = Sale_Detail.List();
            var listaPlatillos = Dish.List();
            var listaUsuarios = User.List();

            // Realizamos un JOIN relacional usando LINQ
            var consultaHistorial = from d in listaDetalles
                                    join v in listaVentas on d.Sale_Id equals v.Sale_Id
                                    join p in listaPlatillos on d.Dish_Id equals p.Dish_Id
                                    join u in listaUsuarios on v.User_Id equals u.User_Id
                                    orderby v.Record_Date descending
                                    select new DetailedSaleDTO
                                    {
                                        Sale_Id = v.Sale_Id,
                                        Date = v.Record_Date,
                                        Customer = v.Customer_Name,
                                        Dish_Type = p.Dish_Type,
                                        Size = p.Size,
                                        Price = p.Price,
                                        Quantity = d.Quantity,
                                        Total_Amount = p.Price * d.Quantity,
                                        Payment_Method = v.Payment_Method,
                                        Purchase_Type = v.Purchase_Type,
                                        Auditor_User = u.Username // Nombre del usuario con sesión activa que procesó la transacción
                                    };

            return consultaHistorial.ToList();
        }
    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class DetailedSaleDTO
    {
        public int Sale_Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Dish_Type { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total_Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Purchase_Type { get; set; }
        public string Auditor_User { get; set; }
    }
}
