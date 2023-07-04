using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.EntityConfigurations;

namespace REST_API_APARTMENT.Models
{
    //this class holds all Dbsets and logic for interaction with db
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //
        // - Explicit Entities configurations
        //
        // - Need to be apply configuration to program ovveride method
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResidentEntityConfiguration());

            modelBuilder.ApplyConfiguration(new AppartmentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new HouseEntityConfiguration());
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}