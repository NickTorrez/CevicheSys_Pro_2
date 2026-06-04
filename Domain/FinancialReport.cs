using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.UI.Catalogs;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Clase de dominio que modela la estructura y el comportamiento lógico de un reporte financiero.
    /// para un rango de fechas determinado.
    /// </summary>
    public class FinancialReport
    {
        /* --------------------------------------------------------------------- */
        /* Atributos y Propiedades de Control de Tiempo                          */
        /* --------------------------------------------------------------------- */
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        /* --------------------------------------------------------------------- */
        /* Propiedades de los Paneles Numéricos Principales                     */
        /* --------------------------------------------------------------------- */
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }

        /// <summary>
        /// Propiedad calculada en base a las reglas de negocio del dominio: Ganancia = Ingresos - Gastos.
        /// </summary>
        public double TotalProfit => TotalIncome - TotalExpenses;

        /* --------------------------------------------------------------------- */
        /* Propiedades de los Paneles Analíticos Secundarios                     */
        /* --------------------------------------------------------------------- */
        public Dish MostSoldDish { get; set; }
        public string MostFrequentExpense { get; set; }

        /* --------------------------------------------------------------------- */
        /* Listas de Detalles para Componentes de UI                             */
        /* --------------------------------------------------------------------- */
        public List<DetailedSaleDTO> SalesHistory { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructor                                                           */
        /* --------------------------------------------------------------------- */
        /// <summary>
        /// Inicializa el reporte financiero normalizando el filtro de tiempo.
        /// </summary>
        /// <param name="startDate">Fecha desde donde inicia el filtro.</param>
        /// <param name="endDate">Fecha límite del filtro.</param>
        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate.Date;
            EndDate = endDate.Date.AddDays(1).AddTicks(-1); // Incluye el último día completo

            // Inicializamos la lista para evitar referencias nulas en el dominio
            SalesHistory = new List<DetailedSaleDTO>();
            MostFrequentExpense = "Sin registros";
        }
    }

    /* ===================================================================== */
    /* ESTRUCTURA DTO SOPORTE DE REPORTES                                    */
    /* ===================================================================== */

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