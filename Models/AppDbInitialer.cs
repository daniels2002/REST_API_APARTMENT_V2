using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace REST_API_APARTMENT.Models
{
    public class AppDbInitialer
    {
        // ???
        private Random r = new Random();

        // Сomments should not be on the same line as the code
        public static void Seed(IApplicationBuilder applicationBuilder)//static class or own server
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HouseContext>();//context reference

                // Adding data to an empty table on every run is a bit of a weird idea
                // You can try something like this:

                //public async Task EnsureInitializedAsync()
                //{
                //    var databaseExists = await _dbContext.Database.CanConnectAsync();

                //    if (!databaseExists)
                //    {
                //        _dbContext.Database.Migrate();
                //        SEED
                //    }
                //}

                /// But before adding such code remove Database.EnsureCreated() from
                /// <see cref="HouseContext(DbContextOptions{HouseContext})"/>

                if (!context.Houses.Any())
                {
                    context.Houses.AddRange(new House()
                    {
                        Street = "Lidotaju iela",
                        City = "Jelgava",
                        State = "Zemgale",
                        Postcode = 3007
                    });
                    // No need to save the data after each operation with the context. once at the end is enough
                    context.SaveChanges();
                }

                if (!context.Appartments.Any())
                {
                    context.Appartments.AddRange(new Appartment()
                    {
                        Number = 1,
                        Floor = 5,
                        Rooms = 6,
                        Residents = 7,
                        LivingSpace = 150.8,
                        TotalSpace = 200.5,
                        HouseId = 1
                    });
                    context.SaveChanges();
                }

                if (!context.Residents.Any())
                {
                    context.Residents.AddRange(new Resident()
                    {
                        Name = "Janis",
                        Surname = "Berzs",
                        Person_code = "120802-20028",
                        Birth_time = new DateTime(1995, 12, 31),
                        Telephone = 20232342,
                        Email = "janis.berzs@gamail.com",
                        AppartmentId = 1
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}