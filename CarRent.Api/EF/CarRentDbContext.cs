using Microsoft.EntityFrameworkCore;
namespace CarRent.Api.EF
{
    public class CarRentDbContext : DbContext
    {

        public virtual DbSet<CarEntity> CarEntity { get; set; }
        public virtual DbSet<CarClassEntity> CarClassEntity { get; set; }
        public virtual DbSet<CarMakeEntity> CarMakeEntity { get; set; }
        public virtual DbSet<CarTypeEntity> CarTypeEntity { get; set; }
        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<PlaceEntity> PlaceEntity { get; set; }
        public virtual DbSet<ReservationEntity> ReservationEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseMySQL("server=localhost;port=3306;user=root;password=admin;database=carrent");
            }
        }
        
    }
}
