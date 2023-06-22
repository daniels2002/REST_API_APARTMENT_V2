using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adding DBContext Class

           
            builder.Services.AddDbContext<HouseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Settings")));

            // Add services to the container.
            builder.Services.AddControllers();
          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            AppDbInitialer.Seed(app);
            app.Run();
        }
    }
}