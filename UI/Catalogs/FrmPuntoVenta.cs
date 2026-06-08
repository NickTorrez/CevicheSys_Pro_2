using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CevicheSys_Pro_2.Domain;                       // Para mapear entidades en las tablas/vistas
using CevicheSys_Pro_2.Services.BusinessLogic;       // Para llamar a los controladores de negocio
using CevicheSys_Pro_2.Helpers;                    // Para formateos, validaciones, etc.
using CevicheSys_Pro_2;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        public FrmPuntoVenta()
        {
            InitializeComponent();
        }
    }
}
