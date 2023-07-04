using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT.EntityConfigurations
{
    public class AppartmentEntityTypeConfiguration : IEntityTypeConfiguration<Appartment>
    {
        public void Configure(EntityTypeBuilder<Appartment> builder)
        {
            builder
                .Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Number).IsRequired();
            builder
                .Property(b => b.Floor).IsRequired();
            builder
                .Property(b => b.Rooms).IsRequired();
            builder
                .Property(b => b.Residents).IsRequired();
            builder
                .Property(b => b.LivingSpace).IsRequired();
            builder
                .Property(b => b.TotalSpace).IsRequired();
            builder
                .Property(b => b.HouseId).IsRequired();
        }
    }
}