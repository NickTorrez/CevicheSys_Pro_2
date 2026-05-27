using Microsoft.Data.SqlClient;
using System.Data;

namespace CevicheSys_Pro_2.DataConnect
{
    /// <summary>
    /// Subclase para ejecutar operaciones INSERT.
    /// Puede devolver el ID generado (IDENTITY) del nuevo registro.
    /// </summary>
    public class InsertCommand : DatabaseConnection
    {
        public InsertCommand() : base() { }
        public InsertCommand(string connectionString) : base(connectionString) { }
        /// <summary>
        /// Ejecuta un INSERT y devuelve el número de filas afectadas.
        /// </summary>
        /// <param name="query">Sentencia INSERT parametrizada.</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>Número de filas insertadas (generalmente 1).</returns>
        public int ExecuteInsert(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                OpenConnection();
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                return _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar INSERT: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Ejecuta un INSERT y devuelve el ID (IDENTITY) del nuevo registro.
        /// Agrega automáticamente SELECT SCOPE_IDENTITY() a la consulta.
        /// </summary>
        /// <param name="query">Sentencia INSERT (sin SELECT SCOPE_IDENTITY).</param>
        /// <param name="parameters">Parámetros SQL.</param>
        /// <returns>ID del nuevo registro insertado, o -1 si falla.</returns>
        public int ExecuteInsertReturnId(string query, SqlParameter[]? parameters = null)
        {
            // Concatenar SELECT SCOPE_IDENTITY() para obtener el ID generado
            string queryWithId = query.TrimEnd().TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";
            try
            {
                OpenConnection();
                _command = new SqlCommand(queryWithId, _connection);
                _command.CommandType = CommandType.Text;
                if (parameters is not null)
                    _command.Parameters.AddRange(parameters);
                object? result = _command.ExecuteScalar();
                return result is not null ? Convert.ToInt32(result) : -1;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL al ejecutar INSERT con ID: {ex.Message}", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
