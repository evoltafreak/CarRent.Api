using System;
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
    public class ReservationApiTests : IntegrationTests
    {

        [Test]
        public async Task TestAddReservation()
        {
            // Arrange
            Reservation reservation = mockReservation();
            var putContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/reservation", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        [Test]
        public async Task TestDeleteReservationById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/reservation/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }
        
        [Test]
        public async Task TestReadAllReservations()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<List<Reservation>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content[0].ReservationNr);
        }
        
        [Test]
        public async Task TestReadReservationById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsAsync<Reservation>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.AreEqual("45FKDF", content.ReservationNr);
        }
        
        [Test]
        public async Task TestUpdateReservation()
        {
            // Arrange
            Reservation reservation = mockReservation();
            reservation.IdReservation = 1;
            var postContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/reservation", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var content = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(content);
        }

        private Reservation mockReservation()
        {
            return new Reservation
            {
                Days = 10,
                Price = 1000,
                IsLease = true,
                ReservationNr = "XYZ123",
                PickUpDate = DateTime.Now,
                Car = new Car {IdCar = 1},
                Customer = new Customer {IdCustomer = 1}
            };
        }

    }
}
