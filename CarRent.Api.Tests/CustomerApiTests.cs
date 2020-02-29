using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
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
            var response = await TestClient.GetAsync(BaseUrl + "/customer");
            // Act
            var content = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual("Max", content[0].Firstname);
        }
        
        [Test]
        public async Task TestAddCustomer()
        {
            // Arrange
            var putContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Customer>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/customer", putContent);
            var content = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual("Ernst", content[0].Firstname);
        }

        [Test]
        public async Task TestDeleteCustomerById()
        {
            // Arrange
            var response = await TestClient.DeleteAsync(BaseUrl + "/customer/1");
            // Act
            var content = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual(content[0].Firstname, "ADFDF");
        }

        [Test]
        public async Task TestReadCustomerById()
        {
            // Arrange
            var response = await TestClient.GetAsync(BaseUrl + "/customer/1");
            // Act
            var content = await response.Content.ReadAsAsync<Customer>();
            // Assert
            Assert.AreEqual("Max", content.Firstname);
        }
        
        [Test]
        public async Task TestUpdateCustomer()
        {
            // Arrange
            var postContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Customer>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/customer", postContent);
            var content = await response.Content.ReadAsAsync<List<Customer>>();
            // Assert
            Assert.AreEqual(content[0].Firstname, "Ernst");
        }
        
    }
}
