using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Proveedor
    {
        // Campos privados (Siguiendo el ejemplo de RRHH)
        private string _nombre;
        private string _dni;

        //Propiedades
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int AniosRelacion { get; set; }
        

        // Constructor sin parámetros
        public Proveedor() { }

        // Constructor con parámetros: Garantiza que los datos de contacto existan desde el inicio
        public Proveedor(string nombre, string dni, string telefono, string direccion)
        {
            this.Nombre = nombre;
            this.DNI = dni;
            this.Telefono = telefono;
            this.Direccion = direccion;
        }

        public bool RegistrarProveedor(string nombre, string dni, string telefono, string direccion)
        {
            return true; // Firma del método solicitada [cite: 3]
        }
    }
}