using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;

namespace CarRent.Api.Entities
{
    public class CarRentDbContext : DbContext
    {

        public CarRentDbContext(DbContextOptions<CarRentDbContext> options) : base(options)
        {
            foreach(var ext in options.Extensions)
            {
                if (ext.GetType() == typeof(InMemoryOptionsExtension))
                {
                    CarTypeEntity.Add(new CarTypeEntity
                    {
                        IdCarType = 1,
                        CarType = "Limousine"
                    });
                    CarMakeEntity.Add(new CarMakeEntity()
                    {
                        IdCarMake = 1,
                        CarMake = "Mitsubishi"
                    });
                    CarClassEntity.Add(new CarClassEntity()
                    {
                        IdCarClass = 1,
                        CarClass = "Luxusklasse"
                    });
                }
            }
        }

        public virtual DbSet<CarEntity> CarEntity { get; set; }
        public virtual DbSet<CarClassEntity> CarClassEntity { get; set; }
        public virtual DbSet<CarMakeEntity> CarMakeEntity { get; set; }
        public virtual DbSet<CarTypeEntity> CarTypeEntity { get; set; }
        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<PlaceEntity> PlaceEntity { get; set; }
        public virtual DbSet<ReservationEntity> ReservationEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             
         }
         
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             
         }
        
    }
}
