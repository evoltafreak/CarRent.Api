using CarRent.Api.Repositories;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public class CustomerService: ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void DeleteByCustomerId(long idCar)
        {
            _customerRepository.DeleteCustomerById(idCar);
        }

        public List<Customer> ReadAllCustomer()
        {
            return _customerRepository.ReadAllCustomer();
        }

        public Customer ReadCustomerById(long idCar)
        {
            return _customerRepository.ReadCustomerById(idCar);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
