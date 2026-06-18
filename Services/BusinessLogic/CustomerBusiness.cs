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
        private readonly Customer _customerDomain = new Customer();
        #endregion

        #region Métodos
        public int InsertCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                throw new ArgumentNullException(nameof(newCustomer), "Los datos del cliente están vacíos.");

            if (!newCustomer.ValidateIdentification())
                throw new ArgumentException("El nombre del cliente es obligatorio y debe tener al menos 3 caracteres.");

            return newCustomer.InsertCustomer();
        }

        public int UpdateCustomer(Customer existingCustomer)
        {
            if (existingCustomer == null || existingCustomer.Customer_Id <= 0)
                throw new ArgumentException("El cliente proporcionado es inválido para actualización.");

            if (!existingCustomer.ValidateIdentification())
                throw new ArgumentException("El nombre del cliente es obligatorio y debe tener al menos 3 caracteres.");

            return existingCustomer.UpdateCustomer();
        }

        public int DeleteCustomer(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Se requiere un ID de cliente válido para dar de baja.");

            Customer customerToDelete = new Customer { Customer_Id = id };
            return customerToDelete.DeleteCustomer();
        }

        public List<Customer> ListCustomers()
        {
            return _customerDomain.ListAllCustomers();
        }
        #endregion
    }
}
