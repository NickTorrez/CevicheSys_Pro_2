using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CevicheSys_Pro_2._0
{
    public class Autenticación
    {
        // No requiere constructor complejo, solo lógica de validación
        public string ValidarAcceso(string usuario, string password)
        {
            return "Admin";  // Retorna "Admin" o "Trabajador" para el Login 
        }
    }
}