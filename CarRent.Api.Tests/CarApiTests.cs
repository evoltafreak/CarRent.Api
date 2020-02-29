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
    public class CarApiTests : IntegrationTests
    {

        [Test]
        public async Task TestReadAllCars()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<Car>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.AreEqual("Colt", content[0].CarName);
        }
        
        [Test]
        public async Task TestAddCar()
        {
            // Arrange
            Car car = mockCar();
            var putContent = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/car", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        [Test]
        public async Task TestDeleteCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/car/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        [Test]
        public async Task TestReadCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<Car>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.AreEqual("Colt", content.CarName);
        }
        
        [Test]
        public async Task TestUpdateCar()
        {
            // Arrange
            Car car = mockCar();
            car.IdCar = 1;
            var postContent = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/car", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        [Test]
        public async Task TestReadAllCarTypes()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carType");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<CarType>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(content.Count > 0);
            Assert.AreEqual("Limousine", content[0]._CarType);
        }
        
        [Test]
        public async Task TestReadAllCarMakes()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carMake");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<CarMake>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(content.Count > 0);
            Assert.AreEqual("Mitsubishi", content[0]._CarMake);
        }
        
        [Test]
        public async Task TestReadAllClasses()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carClass");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<CarClass>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(content.Count > 0);
            Assert.AreEqual("Luxusklasse", content[0]._CarClass);
        }
        
        private Car mockCar()
        {
            return new Car
            {
                CarName = "Colt",
                CarNr = "XYZ",
                CarType = new CarType {IdCarType = 1},
                CarMake = new CarMake {IdCarMake = 1},
                CarClass = new CarClass {IdCarClass = 1}
            };
        }

    }
}
