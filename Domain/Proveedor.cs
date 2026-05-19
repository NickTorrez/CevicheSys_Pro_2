using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Proveedor
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Proveedor;
        private string _cedula_Ruc;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        private string _correo;
        private string _tipo_Productos; // Ej: "Mariscos", "Envases Plásticos"
        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Proveedor()
        {
            _cedula_Ruc = string.Empty;
            _nombre = string.Empty;
            _apellido = string.Empty;
            _direccion = string.Empty;
            _telefono = string.Empty;
            _correo = string.Empty;
            _tipo_Productos = string.Empty;
        }

        public Proveedor(int id, string cedulaRuc, string nombre, string apellido, string direccion, string telefono, string correo, string tipoProductos)
        {
            _id_Proveedor = id;
            _cedula_Ruc = cedulaRuc;
            _nombre = nombre;
            _apellido = apellido;
            _direccion = direccion;
            _telefono = telefono;
            _correo = correo;
            _tipo_Productos = tipoProductos;
        }

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Id_Proveedor { get => _id_Proveedor; set => _id_Proveedor = value; }
        public string Cedula_Ruc { get => _cedula_Ruc; set => _cedula_Ruc = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Tipo_Productos { get => _tipo_Productos; set => _tipo_Productos = value; }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "proveedores.json");

        /// <summary>
        ///     Obtiene la lista de proveedores deserializando el contenido JSON almacenado en PathArchivo.
        /// </summary>
        /// <remarks>Puede lanzar excepciones de E/S o de deserialización si la lectura del archivo falla
        /// o el formato JSON es inválido. El archivo debe contener un arreglo JSON de objetos Proveedor.</remarks>
        /// <returns>Lista de Proveedor cargada desde el archivo; devuelve una lista vacía si el archivo no existe o si la
        /// deserialización produce null.</returns>

        public static List<Proveedor> Listar()
        {
            if (!File.Exists(PathArchivo)) return new List<Proveedor>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Proveedor>>(json) ?? new List<Proveedor>();
        }

        public bool Guardar()
        {
            List<Proveedor> lista = Listar();

            // Si es un nuevo registro (Id == 0), autogeneramos el ID e insertamos
            if (this.Id_Proveedor == 0)
            {
                // Regla: Evitar duplicados de cédula o RUC
                if (lista.Any(p => p.Cedula_Ruc.Equals(this.Cedula_Ruc, StringComparison.OrdinalIgnoreCase)))
                {
                    return false; // Retorna falso indicando que ya existe
                }

                this.Id_Proveedor = lista.Count > 0 ? lista.Max(p => p.Id_Proveedor) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                // Si ya tiene ID, es una edición de datos
                int index = lista.FindIndex(p => p.Id_Proveedor == this.Id_Proveedor);
                if (index != -1)
                {
                    lista[index] = this;
                }
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Eliminar(int id)
        {
            List<Proveedor> lista = Listar();
            int index = lista.FindIndex(p => p.Id_Proveedor == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }
    }

}
