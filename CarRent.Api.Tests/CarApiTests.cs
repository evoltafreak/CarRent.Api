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

        [Test, Order(1)]
        public async Task TestAddCar()
        {
            // Arrange
            Car car = mockCar();
            var putContent = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/car", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idCar = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idCar);
            Assert.IsTrue(idCar > 0);
        }
        
        [Test, Order(2)]
        public async Task TestReadCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var car = await response.Content.ReadAsAsync<Car>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(car);
            Assert.AreEqual("Colt", car.CarName);
            Assert.AreEqual("XYZ", car.CarNr);
        }
        
        [Test, Order(3)]
        public async Task TestUpdateCar()
        {
            // Arrange
            Car car = mockCar();
            car.CarName = "ASX";
            car.IdCar = 1;
            var postContent = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/car", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idCar = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idCar);
            //Assert.IsTrue(idCar > 0);
        }
        
        [Test, Order(4)]
        public async Task TestReadAllCars()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var carList = await response.Content.ReadAsAsync<List<Car>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsNotNull(carList);
            Assert.IsTrue(carList.Count > 0);
            Assert.AreEqual("ASX", carList[0].CarName);
            Assert.AreEqual("XYZ", carList[0].CarNr);
        }
        

        [Test, Order(5)]
        public async Task TestDeleteCarById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/car/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var deleted = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsNotNull(deleted);
            Assert.AreEqual(1, deleted);
        }

        [Test, Order(6)]
        public async Task TestReadAllCarTypes()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carType");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var carTypeList = await response.Content.ReadAsAsync<List<CarType>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(carTypeList.Count > 0);
            Assert.AreEqual("Limousine", carTypeList[0]._CarType);
        }
        
        [Test, Order(7)]
        public async Task TestReadAllCarMakes()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carMake");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var carMakeList = await response.Content.ReadAsAsync<List<CarMake>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(carMakeList.Count > 0);
            Assert.AreEqual("Mitsubishi", carMakeList[0]._CarMake);
        }
        
        [Test, Order(8)]
        public async Task TestReadAllCarClasses()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/car/carClass");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var carClassList = await response.Content.ReadAsAsync<List<CarClass>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsTrue(carClassList.Count > 0);
            Assert.AreEqual("Luxusklasse", carClassList[0]._CarClass);
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
