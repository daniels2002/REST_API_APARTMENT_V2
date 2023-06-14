using static System.Runtime.InteropServices.JavaScript.JSType;

namespace REST_API_APARTMENT.Models
{
    public class AppDbInitialer
    {
        Random r  = new Random();
        public static void Seed(IApplicationBuilder applicationBuilder)//static class or own server 
        {
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HouseContext>();//context reference
                

                if (!context.Houses.Any())
                {
                    context.Houses.AddRange(new House()
                    {
                        Street = "Lidotaju iela",
                        City = "Jelgava",
                        State= "Zemgale",
                        Postcode=3007
                    });
                    context.SaveChanges();
                }

                if (!context.Appartments.Any())
                {
                    context.Appartments.AddRange(new Appartment()
                    {
                        Number =1,
                        Floor=5,
                        Rooms=6,
                        Residents=7,
                        LivingSpace=150.8,
                        TotalSpace=200.5,
                        HouseId=1

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
