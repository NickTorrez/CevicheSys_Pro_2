using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Venta
    {
        //Propiedades
        public DateTime FechaHora { get; set; }
        public string MetodoPago { get; set; } // Efectivo, Transferencia o Mixto 
        public string TipoServicio { get; set; } // Local o Delivery 
        public double MontoTotal { get; set; }

        //Constructor sin Parametros
        public Venta() { }

        // Constructor con parámetros para asegurar que la venta tenga origen y forma de pago
        public Venta(DateTime fecha, string metodo, string servicio, double total)
        {
            this.FechaHora = fecha;
            this.MetodoPago = metodo;
            this.TipoServicio = servicio;
            this.MontoTotal = total;
        }

        public int ProcesarVenta(List<DetalleVenta> articulos, double total, string metodoPago, string tipoServicio)
        {
            NotificarDescuentoStock(1, 1); // Llamada interna al confirmar 
            return 1; // Devuelve número de factura
        }

        private void NotificarDescuentoStock(int idPlatillo, int cantidad) 
        {
        
        }
    }
}