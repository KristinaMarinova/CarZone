using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCarsProject.Data
{
    public class Description : BaseContentOfCar
    {
        public string Detail { get; set; }
        public string DescriptionDetail { get; set; }
    }
    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
