using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenAPI.Models;

namespace CarRent.Api.IntegrationTests
{
    [TestFixture]
    public class CarApiTests : IntegrationTests
    {

        [Test]
        public async Task TestReadAllCars()
        {
            // Arrange
            var response = await TestClient.GetAsync(BaseUrl + "/car");
            
            // Act
            var content = await response.Content.ReadAsAsync<List<Car>>();

            // Assert
            Assert.AreEqual(content[0].CarName, "Colt");
        }
        
    }
}
