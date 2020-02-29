using System.Collections.Generic;
using System.Net;
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
    public class CarApiTests : IntegrationTests
    {

        [Test]
        public async Task TestReadAllCars()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car");
            var content = await response.Content.ReadAsAsync<List<Car>>();
            // Assert
            Assert.AreEqual("Colt", content[0].CarName);
        }
        
        [Test]
        public async Task TestAddCar()
        {
            // Arrange
            var putContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Car>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/car", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
        }

        [Test]
        public async Task TestDeleteCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/car/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
        }

        [Test]
        public async Task TestReadCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/1");
            var content = await response.Content.ReadAsAsync<Car>();
            // Assert
            Assert.AreEqual("Colt", content.CarName);
        }
        
        [Test]
        public async Task TestUpdateCar()
        {
            // Arrange
            var postContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Car>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/car", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
        }

    }
}
