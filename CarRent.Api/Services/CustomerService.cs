using CarRent.Api.Repositories;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public class CustomerService: ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IPlaceRepository _placeRepository;

        public CustomerService(ICustomerRepository customerRepository, IPlaceRepository placeRepository)
        {
            _customerRepository = customerRepository;
            _placeRepository = placeRepository;
        }

        public long AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public int DeleteByCustomerId(long idCar)
        {
            return _customerRepository.DeleteCustomerById(idCar);
        }

        public List<Customer> ReadAllCustomer()
        {
            List<Customer> customerList =  _customerRepository.ReadAllCustomer();
            foreach(Customer customer in customerList)
            {
                customer.Place = _placeRepository.ReadPlaceById(customer.Place.IdPlace);
            }

            return customerList;
        }

        public Customer ReadCustomerById(long idCar)
        {
            Customer customer = _customerRepository.ReadCustomerById(idCar);
            if (customer != null)
            {
                customer.Place = _placeRepository.ReadPlaceById(customer.Place.IdPlace);
            }
            return customer;
        }

        public long UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
