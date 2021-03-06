/*
 * OpenAPI car rent
 *
 * car rent api
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OpenAPI.Attributes;
using Microsoft.AspNetCore.Authorization;
using OpenAPI.Models;

namespace OpenAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class CustomerApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a new customer</remarks>
        /// <param name="customer">Customer object</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Customer not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/api/customer")]
        [ValidateModelState]
        public abstract IActionResult AddCustomer([FromBody]Customer customer);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Delete an existing customer</remarks>
        /// <param name="idCustomer">The id of the customer</param>
        /// <response code="400">Invalid customer value</response>
        [HttpDelete]
        [Route("/api/customer/{idCustomer}")]
        [ValidateModelState]
        public abstract IActionResult DeleteCustomerById([FromRoute][Required]long idCustomer);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Read all customers</remarks>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/api/customer")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Customer>))]
        public abstract IActionResult ReadAllCustomers();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Read customer by idCustomer</remarks>
        /// <param name="idCustomer">The id of the customer</param>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/api/customer/{idCustomer}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(Customer))]
        public abstract IActionResult ReadCustomerById([FromRoute][Required]long idCustomer);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Update an existing customer</remarks>
        /// <param name="customer">Customer object</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Customer not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPost]
        [Route("/api/customer")]
        [ValidateModelState]
        public abstract IActionResult UpdateCustomer([FromBody]Customer customer);
    }
}
