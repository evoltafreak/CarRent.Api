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

        [Test, Order(1)]
        public async Task TestAddReservation()
        {
            // Arrange
            Reservation reservation = mockReservation();
            var putContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/reservation", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idReservation = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idReservation);
            Assert.IsTrue(idReservation > 0);
        }

        [Test, Order(2)]
        public async Task TestReadReservationById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var reservation = await response.Content.ReadAsAsync<Reservation>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(reservation);
            Assert.AreEqual(10, reservation.Days);
            Assert.AreEqual(1000, reservation.Price);
            Assert.AreEqual("XYZ123", reservation.ReservationNr);
            Assert.AreEqual(true, reservation.IsLease);
        }
        
        [Test, Order(3)]
        public async Task TestUpdateReservation()
        {
            // Arrange
            Reservation reservation = mockReservation();
            reservation.IdReservation = 1;
            var postContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/reservation", postContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            var idReservation = await response.Content.ReadAsAsync<long>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(idReservation);
            Assert.IsTrue(idReservation > 0);
        }
        
        [Test, Order(4)]
        public async Task TestReadAllReservations()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var reservationList = await response.Content.ReadAsAsync<List<Reservation>>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.IsNotNull(reservationList);
            Assert.IsTrue(reservationList.Count > 0);
            Assert.AreEqual(10, reservationList[0].Days);
            Assert.AreEqual(1000, reservationList[0].Price);
            Assert.AreEqual("XYZ123", reservationList[0].ReservationNr);
            Assert.AreEqual(true, reservationList[0].IsLease);
        }
        
        [Test, Order(5)]
        public async Task TestDeleteReservationById()
        {
            // Arrange
            // Act
            var response = await TestClient.DeleteAsync(BaseUrl + "/reservation/1");
            HttpStatusCode httpStatusCode = response.StatusCode;
            var deleted = await response.Content.ReadAsAsync<int>();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
            Assert.NotNull(deleted);
            Assert.AreEqual(1, deleted);
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
