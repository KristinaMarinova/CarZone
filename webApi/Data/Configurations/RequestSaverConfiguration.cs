using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Configurations
{
    public class RequestSaverConfiguration : IEntityTypeConfiguration<RequestSaver>
    {
        public void Configure(EntityTypeBuilder<RequestSaver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
