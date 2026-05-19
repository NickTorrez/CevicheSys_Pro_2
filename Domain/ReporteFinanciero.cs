using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class ReporteFinanciero
    {
        private DateTime _fechaInicio;
        private DateTime _fechaFin;

        /// <summary>
        /// Constructor que inicializa el filtro de tiempo del reporte.
        /// </summary>
        /// <param name="fechaInicio">Fecha desde donde inicia el filtro.</param>
        /// <param name="fechaFin">Fecha límite del filtro.</param>
        public ReporteFinanciero(DateTime fechaInicio, DateTime fechaFin)
        {
            // Ajustamos las horas para que abarque desde el primer segundo del día inicial 
            // hasta el último milisegundo del día final seleccionado.
            _fechaInicio = fechaInicio.Date;
            _fechaFin = fechaFin.Date.AddDays(1).AddTicks(-1);
        }

        /* ===================================================================== */
        /* 1. PANELES NUMÉRICOS PRINCIPALES                                      */
        /* ===================================================================== */

        public double CalcularIngresosTotales()
        {
            return Venta.Listar()
                .Where(v => v.Fecha_Registro >= _fechaInicio && v.Fecha_Registro <= _fechaFin)
                .Sum(v => v.Total_Pagar);
        }

        public double CalcularEgresosTotales()
        {
            return Gasto.Listar()
                .Where(g => g.Fecha >= _fechaInicio && g.Fecha <= _fechaFin)
                .Sum(g => g.Monto);
        }

        public double CalcularGananciasTotales()
        {
            return CalcularIngresosTotales() - CalcularEgresosTotales();
        }

        /* ===================================================================== */
        /* 2. PANELES ANALÍTICOS SECUNDARIOS                                     */
        /* ===================================================================== */

        /// <summary>
        /// Analiza los detalles de ventas en el periodo de tiempo y retorna el objeto Platillo con más demanda.
        /// </summary>
        public Platillo ObtenerPlatilloMasVendido()
        {
            // Filtramos los IDs de ventas que caen en el rango de fechas para optimizar la búsqueda
            var ventasEnRango = Venta.Listar()
                .Where(v => v.Fecha_Registro >= _fechaInicio && v.Fecha_Registro <= _fechaFin)
                .Select(v => v.Id_Venta)
                .ToHashSet();

            // Agrupamos los detalles por Id_Platillo y sumamos la cantidad total vendida
            var topPlatilloGrupo = DetalleVenta.Listar()
                .Where(d => ventasEnRango.Contains(d.Id_Venta))
                .GroupBy(d => d.Id_Platillo)
                .Select(grupo => new { Id_Platillo = grupo.Key, TotalUnidades = grupo.Sum(d => d.Cantidad) })
                .OrderByDescending(x => x.TotalUnidades)
                .FirstOrDefault();

            if (topPlatilloGrupo != null)
            {
                // Retornamos el objeto completo del platillo encontrado
                return Platillo.Listar().FirstOrDefault(p => p.Id_Platillo == topPlatilloGrupo.Id_Platillo);
            }

            return null; // En caso de que no existan ventas en ese periodo
        }

        /// <summary>
        /// Analiza la tabla de gastos en el periodo e indica cuál es el concepto que más veces se repitió.
        /// </summary>
        public string ObtenerGastoMasFrecuente()
        {
            var topGasto = Gasto.Listar()
                .Where(g => g.Fecha >= _fechaInicio && g.Fecha <= _fechaFin)
                .GroupBy(g => g.Concepto)
                .Select(grupo => new { Concepto = grupo.Key, Conteo = grupo.Count() })
                .OrderByDescending(x => x.Conteo)
                .FirstOrDefault();

            return topGasto != null ? topGasto.Concepto : "Sin registros";
        }

        /* ===================================================================== */
        /* 3. HISTORIAL DE VENTAS DETALLADO (Combinación Multi-Tabla)           */
        /* ===================================================================== */

        /// <summary>
        /// Cruza los datos de Detalle_Venta, Venta, Platillo y Usuario para desplegar la auditoría completa.
        /// </summary>
        public List<VentaDetalladaDTO> ObtenerHistorialVentas()
        {
            var listaVentas = Venta.Listar().Where(v => v.Fecha_Registro >= _fechaInicio && v.Fecha_Registro <= _fechaFin).ToList();
            var listaDetalles = DetalleVenta.Listar();
            var listaPlatillos = Platillo.Listar();
            var listaUsuarios = Usuario.Listar();

            // Realizamos un JOIN relacional usando LINQ
            var consultaHistorial = from d in listaDetalles
                                    join v in listaVentas on d.Id_Venta equals v.Id_Venta
                                    join p in listaPlatillos on d.Id_Platillo equals p.Id_Platillo
                                    join u in listaUsuarios on v.Id_Usuario equals u.Id_Usuario
                                    orderby v.Fecha_Registro descending
                                    select new VentaDetalladaDTO
                                    {
                                        Id_Venta = v.Id_Venta,
                                        Fecha = v.Fecha_Registro,
                                        Cliente = v.Nombre_Cliente,
                                        Tipo_Platillo = p.Tipo_Platillo,
                                        Tamaño = p.Tamaño,
                                        Precio = p.Precio,
                                        Cantidad = d.Cantidad,
                                        Total_Pagar = p.Precio * d.Cantidad,
                                        Metodo_Pago = v.Metodo_Pago,
                                        Tipo_Compra = v.Tipo_Compra,
                                        Usuario_Auditor = u.Nombre_Usuario // Nombre del usuario con sesión activa que procesó la transacción
                                    };

            return consultaHistorial.ToList();
        }
    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class VentaDetalladaDTO
    {
        public int Id_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Tipo_Platillo { get; set; }
        public string Tamaño { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Total_Pagar { get; set; }
        public string Metodo_Pago { get; set; }
        public string Tipo_Compra { get; set; }
        public string Usuario_Auditor { get; set; }
    }
}
