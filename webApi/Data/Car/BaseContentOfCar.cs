using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCarsProject.Data
{
    public class BaseContentOfCar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
    public class BaseDescriptionConfiguration : IEntityTypeConfiguration<BaseContentOfCar>
    {
        public void Configure(EntityTypeBuilder<BaseContentOfCar> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
