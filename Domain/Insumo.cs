using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Insumo
    {
        //Propiedades
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public double StockActual { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Origen { get; set; }

        //Constructor sin Parametros
        public Insumo() { }

        // Constructor con parámetros: Obliga a registrar la fecha de vencimiento para las Alertas de Frescura
        public Insumo(string nombre, double stock, DateTime vencimiento, string origen)
        {
            this.Nombre = nombre;
            this.StockActual = stock;
            this.FechaVencimiento = vencimiento;
            this.Origen = origen;
        }

        public void ActualizarStock(int idInsumo, double cantidad, string tipoMovimiento)
        {

        }

        public List<Insumo> ObtenerAlertasFrescura()
        {
            return new List<Insumo>(); // Devuelve productos próximos a vencer 
        }
    }
}