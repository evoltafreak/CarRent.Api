using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
            Assert.AreEqual(content[0].Firstname, "Max");
        }
        
    }
}
