using System.Collections.Generic;
using CarRent.Api.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers;
using OpenAPI.Models;

namespace CarRent.Api.Controllers
{

    public class CustomerApiCtrl : CustomerApiController
    {

        private readonly ICustomerService _customerService;

        public CustomerApiCtrl(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public override IActionResult AddCustomer(Customer customer)
        {
            long idCustomer = _customerService.AddCustomer(customer);
            return StatusCode(200, idCustomer);
        }

        public override IActionResult DeleteCustomerById(long idCustomer)
        {
            int deleted = _customerService.DeleteByCustomerId(idCustomer);
            return StatusCode(200, deleted);
        }

        public override IActionResult ReadAllCustomers()
        {
            List<Customer> customerList = _customerService.ReadAllCustomer();
            return StatusCode(200, customerList);
        }

        public override IActionResult ReadCustomerById(long idCustomer)
        {
            Customer customer = _customerService.ReadCustomerById(idCustomer);
            return customer == null ? StatusCode(404, null) : StatusCode(200, customer);
        }

        public override IActionResult UpdateCustomer(Customer customer)
        {
            long idCustomer = _customerService.UpdateCustomer(customer);
            return StatusCode(200, idCustomer);
        }
    }
}
