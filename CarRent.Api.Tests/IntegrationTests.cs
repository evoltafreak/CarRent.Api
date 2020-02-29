using System.Net.Http;
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
                        services.RemoveAll(typeof(DbContext));
                        services.AddDbContext<DbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }

    }
}
