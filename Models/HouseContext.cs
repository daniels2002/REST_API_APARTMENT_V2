using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace REST_API_APARTMENT.Models
{
    // Why HouseContext? This class holds all DbSets and logic for interaction with database
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}