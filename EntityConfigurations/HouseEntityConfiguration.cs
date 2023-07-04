using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT.EntityConfigurations
{
    public class HouseEntityConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder
                .Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Street).IsRequired();
            builder
                .Property(b => b.City).IsRequired();
            builder
                .Property(b => b.State).IsRequired();
            builder
                .Property(b => b.Postcode).IsRequired();
        }
    }
}