using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.Models;
using REST_API_APARTMENT.Validation;

namespace REST_API_APARTMENT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ------------------------------- S  E  R  V  I  C  E  S  ----------------------------------------//

            // Adding DBContext Class
            builder.Services.AddDbContext<HouseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Settings")));

            //  Adding FluentValidation
            builder.Services.AddTransient<AppartmentValidation>();
            builder.Services.AddTransient<HouseValidation>();
            builder.Services.AddTransient<ResidentValidation>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //  Adding AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // -------------------------------------------------------------------------------------------------//
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Adding the seed
            AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}