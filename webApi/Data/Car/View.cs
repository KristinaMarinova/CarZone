using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCarsProject.Data
{
    public class View
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class ViewConfiguration : IEntityTypeConfiguration<View>
    {
        public void Configure(EntityTypeBuilder<View> builder)
        {
            builder.ToTable("Views");
            builder.HasKey(x => x.Id);
        }
    }
}
