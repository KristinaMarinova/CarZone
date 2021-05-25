using Microsoft.EntityFrameworkCore;

namespace WebCarsProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new RequestSaverConfiguration());
            builder.ApplyConfiguration(new LikeConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new DescriptionConfiguration());
            builder.ApplyConfiguration(new ViewConfiguration());

            builder.Entity<UserType>().HasData(new UserType { TypeOfUser = "Admin", Id = 1 });
            builder.Entity<UserType>().HasData(new UserType { TypeOfUser = "User", Id = 2 });

            builder.Entity<Color>().HasData(new Color { Id = 1, Name = "Black" });
            builder.Entity<Color>().HasData(new Color { Id = 2, Name = "Grey" });
            builder.Entity<Color>().HasData(new Color { Id = 3, Name = "White" });
            builder.Entity<Color>().HasData(new Color { Id = 4, Name = "Red" });
            builder.Entity<Color>().HasData(new Color { Id = 5, Name = "Blue" });
            builder.Entity<Color>().HasData(new Color { Id = 6, Name = "Green" });
            builder.Entity<Color>().HasData(new Color { Id = 7, Name = "Yellow" });
            builder.Entity<Color>().HasData(new Color { Id = 8, Name = "Pink" });
            builder.Entity<Color>().HasData(new Color { Id = 9, Name = "Purple" });
            builder.Entity<Color>().HasData(new Color { Id = 10, Name = "Brown" });


            builder.Entity<Fuel>().HasData(new Fuel { Id = 1, Name = "Petrol" });
            builder.Entity<Fuel>().HasData(new Fuel { Id = 2, Name = "Gas" });
            builder.Entity<Fuel>().HasData(new Fuel { Id = 3, Name = "Diesel" });
            builder.Entity<Fuel>().HasData(new Fuel { Id = 4, Name = "Hybrid" });

            builder.Entity<Transmission>().HasData(new Transmission { Id = 1, Name = "Automatic" });
            builder.Entity<Transmission>().HasData(new Transmission { Id = 2, Name = "Manual" });

            builder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "Bmw" });
            builder.Entity<Brand>().HasData(new Brand { Id = 2, Name = "Audi" });
            builder.Entity<Brand>().HasData(new Brand { Id = 3, Name = "Mercedes" });
            builder.Entity<Brand>().HasData(new Brand { Id = 4, Name = "Honda" });
            builder.Entity<Brand>().HasData(new Brand { Id = 5, Name = "Opel" });
            builder.Entity<Brand>().HasData(new Brand { Id = 6, Name = "Peugeot" });
            builder.Entity<Brand>().HasData(new Brand { Id = 7, Name = "Skoda" });
            builder.Entity<Brand>().HasData(new Brand { Id = 8, Name = "Ford" });
            builder.Entity<Brand>().HasData(new Brand { Id = 9, Name = "Mitsubishi" });
            builder.Entity<Brand>().HasData(new Brand { Id = 10, Name = "Saab" });
            builder.Entity<Brand>().HasData(new Brand { Id = 11, Name = "Toyota" });

        }

        public virtual DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<View> Views { get; set; }
        public virtual DbSet<RequestSaver> RequestSavers { get; set; }
    }
}