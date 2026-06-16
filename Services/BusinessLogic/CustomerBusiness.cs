using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para la gestión de clientes.
    /// </summary>
    public class CustomerBusiness
    {
        #region Propiedades
        private readonly Customer _customer;
        #endregion

        #region Constructores
        public CustomerBusiness()
        {
            _customer = new Customer();
        }
        #endregion

        #region Métodos
        public int InsertCustomer(Customer newCustomer)
        {
            try
            {
                if (newCustomer == null) return 1;
                if (!newCustomer.ValidateIdentification()) return 2;

                newCustomer.Full_Name = newCustomer.Full_Name.Trim();
                newCustomer.Phone = newCustomer.Phone?.Trim() ?? string.Empty;
                newCustomer.Enable = true;

                return newCustomer.AddCustomer() > 0 ? 0 : 5;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de inserción de cliente.", ex);
            }
        }

        public int UpdateCustomer(Customer modifiedCustomer)
        {
            try
            {
                if (modifiedCustomer == null || modifiedCustomer.Customer_Id <= 0) return 1;
                if (!modifiedCustomer.ValidateIdentification()) return 2;

                modifiedCustomer.Full_Name = modifiedCustomer.Full_Name.Trim();
                modifiedCustomer.Phone = modifiedCustomer.Phone?.Trim() ?? string.Empty;

                return modifiedCustomer.UpdateCustomer() > 0 ? 0 : 5;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de actualización de cliente.", ex);
            }
        }

        public int DisableCustomer(int id)
        {
            try
            {
                if (id <= 0) return 1;
                return _customer.DisableCustomer(id) > 0 ? 0 : 5;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de baja al cliente.", ex);
            }
        }

        public List<Customer> ListCustomers()
        {
            try
            {
                return _customer.ListAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo en la lectura de clientes.", ex);
            }
        }
        #endregion
    }
}
