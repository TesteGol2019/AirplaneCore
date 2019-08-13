using AirplaneCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneCore.Infrastructure.EntityConfigurations
{
    public class AirplaneEntityTypeConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.ToTable("Airplane");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Model).IsRequired();
            builder.Property(m => m.Passengers).IsRequired();
            builder.Property(m => m.CreationDate).IsRequired();
        }
    }
}
