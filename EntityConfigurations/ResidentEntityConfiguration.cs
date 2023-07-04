using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REST_API_APARTMENT.Models
{
    public class ResidentEntityConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder
                .Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Name).IsRequired();
            builder
                .Property(b => b.Surname).IsRequired();
            builder
                .Property(b => b.Person_code).IsRequired();
            builder
                .Property(b => b.Birth_time).IsRequired();
            builder
                .Property(b => b.Telephone).IsRequired();
            builder
                .Property(b => b.Email).IsRequired();
            builder
                .Property(b => b.AppartmentId).IsRequired();
        }
    }
}