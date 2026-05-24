using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Helpers
{
    public static class Session
    {
        // Guardará el objeto completo del usuario que logueó con éxito
        public static User ActiveUser { get; set; }
    }
}
