using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.TransmissionId).IsRequired();
            builder.Property(x => x.FuelId).IsRequired();
            builder.Property(x => x.ColorId).IsRequired();
            builder.Property(x => x.Model).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Km).IsRequired();
            builder.Property(x => x.IsAvailable).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Cars).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
