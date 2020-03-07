using System.Net.Http;
using CarRent.Api.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CarRent.Api.IntegrationTests
{
    public class IntegrationTests
    {

        protected readonly string BaseUrl = "https://localhost:5001/api";
        protected readonly HttpClient TestClient;
        
        protected IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => { builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(CarRentDbContext));
                        services.AddDbContext<CarRentDbContext>(options => { options.UseInMemoryDatabase("TestDb").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }

    }
}
