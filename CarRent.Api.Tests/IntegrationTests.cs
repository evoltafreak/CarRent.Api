using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CarRent.Api.IntegrationTests
{
    public class IntegrationTests
    {

        protected readonly string BaseUrl = "https://localhost:5001/api";
        protected readonly HttpClient TestClient;
        
        protected IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }

    }
}
