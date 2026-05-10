using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Egreso
    {
        //Propiedades
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }

        // Constructor sin parámetros
        public Egreso() { }

        // Constructor con parámetros para registrar gastos operativos
        public Egreso(string concepto, double monto, DateTime fecha)
        {
            this.Concepto = concepto;
            this.Monto = monto;
            this.Fecha = fecha;
        }

        public bool RegistrarGasto(string concepto, double monto, DateTime fecha, string observaciones)
        {
            return true; // Registro de gastos operativos
        }
    }
}