using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigurrations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Age)
                .IsRequired();
        }
    }
}
