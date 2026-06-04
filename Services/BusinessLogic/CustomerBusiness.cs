using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Repositories;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Reglas de negocio para Clientes. Depende directamente de la clase concreta CustomerRepository.
    /// </summary>
    /// </summary>
    public class CustomerBusiness
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerBusiness(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> ObtainAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer ObtainCustomerById(int id)
        {
            if (id <= 0) throw new ArgumentException("El identificador del cliente proporcionado no es válido.");
            return _customerRepository.GetById(id);
        }

        public bool RegisterCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            if (!customer.ValidateIdentification())
            {
                throw new InvalidOperationException("Las reglas de validación nominales para el cliente no se han cumplido.");
            }

            return _customerRepository.Insert(customer);
        }

        public bool ModifyCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (customer.CustomerId <= 0) throw new ArgumentException("El identificador del cliente no es válido para su modificación.");

            if (!customer.ValidateIdentification())
            {
                throw new InvalidOperationException("Las modificaciones nominales del cliente no cumplen los requerimientos del sistema.");
            }

            return _customerRepository.Update(customer);
        }

        public bool RemoveCustomer(int id)
        {
            if (id <= 0) throw new ArgumentException("El identificador del cliente a eliminar no es válido.");
            return _customerRepository.Delete(id);
        }
    }
}
