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
    public class ReservationApiTests : IntegrationTests
    {

        [Test]
        public async Task TestAddReservation()
        {
            // Arrange
            var putContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Reservation>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PutAsync(BaseUrl + "/reservation", putContent);
            HttpStatusCode httpStatusCode = response.StatusCode;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpStatusCode);
        }

        [Test]
        public async Task TestDeleteReservationById()
        {
            // Arrange
            var response = await TestClient.DeleteAsync(BaseUrl + "/reservation/1");
            // Act
            var content = await response.Content.ReadAsAsync<List<Reservation>>();
            // Assert
            Assert.AreEqual(content[0].ReservationNr, "ADFDF");
        }
        
        [Test]
        public async Task TestReadAllReservations()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation");
            var content = await response.Content.ReadAsAsync<List<Reservation>>();
            // Assert
            Assert.AreEqual("45FKDF", content[0].ReservationNr);
        }
        
        [Test]
        public async Task TestReadReservationById()
        {
            // Arrange
            // Act
            var response = await TestClient.GetAsync(BaseUrl + "/reservation/1");
            var content = await response.Content.ReadAsAsync<Reservation>();
            // Assert
            Assert.AreEqual("45FKDF", content.ReservationNr);
        }
        
        [Test]
        public async Task TestUpdateReservation()
        {
            // Arrange
            var postContent = new StringContent(JsonConvert.SerializeObject(A.Fake<Reservation>()), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync(BaseUrl + "/reservation", postContent);
            var content = await response.Content.ReadAsAsync<List<Reservation>>();
            // Assert
            Assert.AreEqual(content[0].ReservationNr, "ADFDF");
        }

    }
}
