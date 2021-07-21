using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Configurations
{
    public class BaseContentOfCarConfiguration : IEntityTypeConfiguration<BaseCar>
    {
        public void Configure(EntityTypeBuilder<BaseCar> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}