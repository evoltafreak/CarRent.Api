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

        [Test]
        public async Task TestReadAllCustomers()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/customer");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.AreEqual("Max", content[0].Firstname);
        }
        
        [Test]
        public async Task TestAddCustomer()
        {
            // Arrange
            Customer customer = mockCustomer();
            var putContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/customer", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsAsync<long>().Result;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(content > 0);
        }

        [Test]
        public async Task TestDeleteCustomerById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/customer/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        [Test]
        public async Task TestReadCustomerById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/customer/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<Customer>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.AreEqual("Max", content.Firstname);
        }
        
        [Test]
        public async Task TestUpdateCustomer()
        {
            // Arrange
            Customer customer = mockCustomer();
            customer.IdCustomer = 1;
            var postContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/customer", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        private Customer mockCustomer()
        {
            Customer customer = new Customer();
            customer.Firstname = "Max";
            customer.Lastname = "Mustermann";
            customer.Address = "Musterstrasse";
            customer.AddressNr = "1a";
            customer.Place = new Place();
            customer.Place.IdPlace = 1;
            return customer;
        }
        
    }
}
