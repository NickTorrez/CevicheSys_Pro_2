using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Platillo
    {
        // Campos privados
        private string _nombre;
        private double _precio;

        //Propiedades
        public int IdPlatillo { get; set; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public bool Disponible { get; set; }

        //Cosntructor sin parámetros
        public Platillo() { }

        // Constructor con parámetros 
        public Platillo(string nombre, double precio, bool disponible)
        {
            this._nombre = nombre;
            this._precio = precio;
            this.Disponible = disponible;
        }

        public bool CambiarDisponibilidad(int idPlatillo, bool estado)
        {
            return true; // Basado en la existencia de ingredientes en almacén 
        }
    }
}