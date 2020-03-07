using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenAPI.Models;

namespace CarRent.Api.IntegrationTests
{
    [TestFixture]
    public class CustomerApiTests : IntegrationTests
    {

        [Test, Order(1)]
        public async Task TestAddCustomer()
        {
            // Arrange
            Customer customer = mockCustomer();
            var putContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/customer", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idCustomer = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idCustomer);
            Assert.IsTrue(idCustomer > 0);
        }
        
        [Test, Order(2)]
        public async Task TestReadCustomerById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/customer/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var customer = await response.Content.ReadAsAsync<Customer>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(customer);
            Assert.AreEqual("Max", customer.Firstname);
            Assert.AreEqual("Mustermann", customer.Lastname);
            Assert.AreEqual("Musterstrasse", customer.Address);
            Assert.AreEqual("1a", customer.AddressNr);
        }
        
        [Test, Order(3)]
        public async Task TestUpdateCustomer()
        {
            // Arrange
            Customer customer = mockCustomer();
            customer.IdCustomer = 1;
            customer.Firstname = "Maximilian";
            var postContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/customer", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idCustomer = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idCustomer);
            Assert.IsTrue(idCustomer > 0);
        }
        
        [Test, Order(4)]
        public async Task TestReadAllCustomers()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/customer");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var customerList = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(customerList);
            Assert.IsTrue(customerList.Count > 0);
            Assert.AreEqual("Maximilian", customerList[0].Firstname);
            Assert.AreEqual("Mustermann", customerList[0].Lastname);
            Assert.AreEqual("Musterstrasse", customerList[0].Address);
            Assert.AreEqual("1a", customerList[0].AddressNr);
        }
        
        
        [Test, Order(5)]
        public async Task TestDeleteCustomerById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/customer/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var deleted = await response.Content.ReadAsAsync<int>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(deleted);
            Assert.AreEqual(1, deleted);
        }
        
        private Customer mockCustomer()
        {
            return new Customer
            {
                Firstname = "Max",
                Lastname = "Mustermann",
                Address = "Musterstrasse",
                AddressNr = "1a",
                Place = new Place {IdPlace = 1}
            };
        }
        
    }
}
