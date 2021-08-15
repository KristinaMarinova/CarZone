using Microsoft.EntityFrameworkCore;
using CarZone.Data.Configurations;

namespace CarZone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new BaseContentOfCarConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new FuelConfiguration());
            builder.ApplyConfiguration(new TransmissionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileImg> ProfileImgs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
    }
}