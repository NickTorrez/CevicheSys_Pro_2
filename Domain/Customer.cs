using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad que representa a los clientes de la cevichería. Hereda de Person.
    /// </summary>
    public class Customer : Person
    {
        #region Propiedades
        public int Customer_Id { get; set; }
        public string Full_Name { get; set; }
        #endregion

        #region Constructores
        public Customer() : base()
        {
            Full_Name = string.Empty;
        }

        public Customer(int customerId, string fullName, string phone, bool enable) : base(phone, enable)
        {
            Customer_Id = customerId;
            Full_Name = fullName;
        }
        #endregion

        #region Métodos
        public override bool ValidateIdentification()
        {
            return !string.IsNullOrWhiteSpace(Full_Name) && Full_Name.Trim().Length >= 3;
        }

        public List<Customer> ListAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            string sql = "SELECT Customer_Id, Full_Name, Phone, Enable FROM Customer WHERE Enable = 1";

            using SelectQuery select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Customer(
                    Convert.ToInt32(row["Customer_Id"]),
                    row["Full_Name"].ToString(),
                    row["Phone"].ToString(),
                    Convert.ToBoolean(row["Enable"])
                ));
            }
            return list;
        }

        public int InsertCustomer()
        {
            string sql = "INSERT INTO Customer (Full_Name, Phone, Enable) VALUES (@name, @phone, 1)";
            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = {
                // Longitudes exactas definidas (100 y 20)
                new SqlParameter("@name", SqlDbType.VarChar, 100) { Value = this.Full_Name.Trim() },
                new SqlParameter("@phone", SqlDbType.VarChar, 20) { Value = (object)this.Phone ?? DBNull.Value }
            };
            return insert.ExecuteInsert(sql, parameters);
        }

        public int UpdateCustomer()
        {
            string sql = "UPDATE Customer SET Full_Name = @name, Phone = @phone WHERE Customer_Id = @id AND Enable = 1";
            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int) { Value = this.Customer_Id },
                new SqlParameter("@name", SqlDbType.VarChar, 100) { Value = this.Full_Name.Trim() },
                new SqlParameter("@phone", SqlDbType.VarChar, 20) { Value = (object)this.Phone ?? DBNull.Value }
            };
            return update.ExecuteUpdate(sql, parameters);
        }

        public int DeleteCustomer()
        {
            string sql = "UPDATE Customer SET Enable = 0 WHERE Customer_Id = @id";
            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int) { Value = this.Customer_Id }
            };
            return delete.ExecuteDelete(sql, parameters);
        }

        #endregion
    }
}