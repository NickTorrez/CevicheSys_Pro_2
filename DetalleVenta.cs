using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class DetalleVenta
    {
        // Campos privados para seguir el estándar de RRHH
        private int _idPlatillo;
        private int _cantidad;
        private double _subtotal;

        // Propiedades
        public int IdPlatillo { get => _idPlatillo; set => _idPlatillo = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }

        // Constructor sin parámetros
        public DetalleVenta() { }

        // Constructor con parámetros para asegurar que no haya líneas de venta vacías
        public DetalleVenta(int idPlatillo, int cantidad, double precio)
        {
            this._idPlatillo = idPlatillo;
            this._cantidad = cantidad;
            this.PrecioUnitario = precio;
            this._subtotal = cantidad * precio;
        }
    }
}