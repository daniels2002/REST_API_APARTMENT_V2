using Microsoft.EntityFrameworkCore;

namespace REST_API_APARTMENT.Models
{
    public static class AppDbInitializer
    {
        private static Random r = new Random();

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HouseContext>();

                EnsureInitializedAsync(context).GetAwaiter().GetResult();
            }
        }

        private static async Task EnsureInitializedAsync(HouseContext context)
        {
            var databaseExists = await context.Database.CanConnectAsync();

            if (!databaseExists)
            {
                await context.Database.MigrateAsync();

                if (!context.Houses.Any())
                {
                    context.Houses.AddRange(new House()
                    {
                        Street = "Lidotaju iela",
                        City = "Jelgava",
                        State = "Zemgale",
                        Postcode = 3007,
                    });
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
                        Birth_time = new DateTimeOffset(),
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