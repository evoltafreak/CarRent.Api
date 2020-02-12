using CarRent.Api.Repositories;
using CarRent.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IReservationService, ReservationService> ();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            //services.AddDbContext(options => options.UseMySQL("Server=localhost; database=carrent; UID=root; password=admin"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
            );
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
