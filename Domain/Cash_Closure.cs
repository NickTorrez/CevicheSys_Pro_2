using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Cash_Closure
    {

        private int _closure_Id;
        private DateTime _closure_Date;
        private int _user_Id;
        private double _initial_Cash;
        private double _calculated_Income;
        private double _real_Cash;
        private string _notes_Remarks;

        /*__________________________________________________________/*
         * Clase para representar el cierre de caja diario.
         * Se puede usar para almacenar en base de datos o generar reportes.
         *__________________________________________________________*/
        public int Closure_Id { get => _closure_Id; set => _closure_Id = value; }
        public DateTime Closure_Date { get => _closure_Date; set => _closure_Date = value; }
        public int User_Id { get => _user_Id; set => _user_Id = value; }
        public double Initial_Cash { get => _initial_Cash; set => _initial_Cash = value; }
        public double Calculated_Income { get => _calculated_Income; set => _calculated_Income = value; }
        public double Real_Cash { get => _real_Cash; set => _real_Cash = value; }
        public string Notes_Remarks { get => _notes_Remarks; set => _notes_Remarks = value; }

        /* --------------------------------------------------------------------- */
        /* METODOS                                                               */
        /* --------------------------------------------------------------------- */

        // APLICACIÓN DE 3NF: El descuadre ya no se guarda, se calcula al vuelo mediante la propiedad
        public double Cash_Discrepancy
        {
            get { return this.Real_Cash - this.Calculated_Income; }
        }

        public bool RegisterClosure()
        {
            string query = "INSERT INTO CierreCaja (Fecha, Fondo_Inicial, Ingresos_Calculados, Efectivo_Real, Observaciones, Id_Usuario) VALUES (@fec, @ini, @calc, @real, @obs, @usr)";
            SqlParameter[] p = {
                new SqlParameter("@fec", DateTime.Now),
                new SqlParameter("@ini", this.Initial_Cash),
                new SqlParameter("@calc", this.Calculated_Income),
                new SqlParameter("@real", this.Real_Cash),
                new SqlParameter("@obs", string.IsNullOrEmpty(this.Notes_Remarks) ? DBNull.Value : this.Notes_Remarks),
                new SqlParameter("@usr", this.User_Id)
            };

            using var insert = new InsertCommand();
            this.Closure_Id = insert.ExecuteInsertReturnId(query, p);
            return true;
        }
    }
}