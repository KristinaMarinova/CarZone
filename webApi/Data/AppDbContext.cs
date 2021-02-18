using Microsoft.EntityFrameworkCore;
using WebCarsProject.Data;

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

            builder.Entity<UserType>().HasData(new UserType { TypeOfUser = "Admin", Id = 1 });
            builder.Entity<UserType>().HasData(new UserType { TypeOfUser = "User", Id = 2 });

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                UserName = "ivan777",
                Email = "ivan@abv.bg",
                Password = "123456",
                UserTypeID = 1,
                PicPath = "https://st2.depositphotos.com/2498595/6618/v/950/depositphotos_66187233-stock-illustration-profile-outline-symbol-dark-on.jpg",
                Phone = "0877585858"
            });
            builder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Peho",
                LastName = "Petrov",
                UserName = "pesho123",
                Email = "pesho@gmai.com",
                Password = "123456",
                UserTypeID = 2,
                PicPath = "https://www.pavilionweb.com/wp-content/uploads/2017/03/man-300x300.png",
                Phone = "0877587777"
            });
            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "Gosho",
                LastName = "Georgiev",
                UserName = "gosho321",
                Email = "gosho321@gmai.com",
                Password = "123456",
                UserTypeID = 2,
                PicPath = "https://img.icons8.com/bubbles/2x/user-male.png",
                Phone = "0877587777"
            });

            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                Name = "BMW"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 2,
                Name = "Audi"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 3,
                Name = "Mercedes"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 4,
                Name = "Honda"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 5,
                Name = "Peugeot"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 6,
                Name = "Opel"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 7,
                Name = "Skoda"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 8,
                Name = "Ford"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 9,
                Name = "Mitsubishi"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 11,
                Name = "Mazda"
            });
            builder.Entity<Brand>().HasData(new Brand
            {
                Id = 12,
                Name = "Toyota"
            });

            builder.Entity<Color>().HasData(new Color
            {
                Id = 1,
                Name = "Red"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 2,
                Name = "White"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 3,
                Name = "Blue"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 4,
                Name = "Green "
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 5,
                Name = "Grey"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 6,
                Name = "Yellow"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 7,
                Name = "Pink"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 8,
                Name = "Brown"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 9,
                Name = "Purple"
            });
            builder.Entity<Color>().HasData(new Color
            {
                Id = 10,
                Name = "Black"
            });

            builder.Entity<Transmission>().HasData(new Transmission
            {
                Id = 1,
                Name = "Automatic"
            });
            builder.Entity<Transmission>().HasData(new Transmission
            {
                Id = 2,
                Name = "Manual"
            });

            builder.Entity<Fuel>().HasData(new Fuel
            {
                Id = 1,
                Name = "LPG"
            });
            builder.Entity<Fuel>().HasData(new Fuel
            {
                Id = 2,
                Name = "Petrol"
            });
            builder.Entity<Fuel>().HasData(new Fuel
            {
                Id = 3,
                Name = "Diesel"
            });
            builder.Entity<Fuel>().HasData(new Fuel
            {
                Id = 4,
                Name = "Hybrid"
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 1,
                CarPic = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/10best-cars-group-cropped-1542126037.jpg",
                Km = 70000,
                FuelId = 1, // todo
                BrandId = 1,
                Model = "M235i",
                Price = 99000.00,
                Year = 2020,
                UserId = 1,
                ColorId = 1,
                Horsepower = 100,
                TransmissionId = 1,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 2,
                CarPic = "https://g1-bg.cars.bg/2020-07-14_2/5f0ddd0737b7786f0443bd62o.jpg",
                Km = 178000,
                FuelId = 3,
                BrandId = 1,
                ColorId = 2,
                Horsepower = 101,
                TransmissionId = 2,
                Model = "320",
                Price = 8000.00,
                Year = 2006,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 3,
                CarPic = "https://g1-bg.cars.bg/2020-08-24_2/5f43bca61b09d640386585d2b.jpg",
                Km = 91000,
                FuelId = 3,
                BrandId = 5,
                ColorId = 2,
                Horsepower = 101,
                TransmissionId = 2,
                Model = "3008",
                Price = 39999.00,
                Year = 2017,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 4,
                CarPic = "https://g1-bg.cars.bg/2020-11-09_2/5fa95efcdf6eec09ae410d12b.jpg",
                Km = 286000,
                FuelId = 3,
                BrandId = 1,
                ColorId = 2,
                Horsepower = 150,
                TransmissionId = 1,
                Model = "E60",
                Price = 16700.00,
                Year = 2009,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 5,
                CarPic = "https://g1-bg.cars.bg/2020-07-06_2/5f0352cd072750288a141af2b.jpg",
                Km = 76000,
                FuelId = 1,
                BrandId = 1,
                Model = "320",
                ColorId = 3,
                Horsepower = 160,
                TransmissionId = 1,
                Price = 25300.00,
                Year = 2015,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 6,
                CarPic = "https://g1-bg.cars.bg/2020-11-22_2/5fba75c4d87c677584246302o.jpg",
                Km = 235000,
                FuelId = 3,
                BrandId = 3,
                Model = "C 220",
                TransmissionId = 2,
                ColorId = 5,
                Horsepower = 170,
                Price = 9000,
                Year = 2007,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 7,
                CarPic = "https://g1-bg.cars.bg/2017-11-28_1/17824566o.jpg",
                Km = 188000,
                FuelId = 3,
                BrandId = 3,
                Model = "C 220",
                TransmissionId = 1,
                ColorId = 10,
                Horsepower = 170,
                Price = 27900,
                Year = 2014,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 8,
                CarPic = "https://g1-bg.cars.bg/2020-06-23_2/5ef1c5866d1c2d269e2cbc14o.jpg",
                Km = 26000,
                FuelId = 3,
                BrandId = 3,
                Model = "GLC 250",
                TransmissionId = 1,
                ColorId = 1,
                Horsepower = 204,
                Price = 95000,
                Year = 2017,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 9,
                CarPic = "https://g1-bg.cars.bg/2020-05-24_2/5eca6436267dcc48fc0eedb2o.jpg",
                Km = 84000,
                FuelId = 2,
                BrandId = 3,
                Model = "E 400",
                TransmissionId = 1,
                ColorId = 5,
                Horsepower = 333,
                Price = 84900,
                Year = 2017,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 10,
                CarPic = "https://g1-bg.cars.bg/2020-08-02_2/5f27262e9a1ae76752044183o.jpg",
                Km = 155000,
                FuelId = 2,
                BrandId = 3,
                Model = "C 63",
                TransmissionId = 1,
                ColorId = 2,
                Horsepower = 500,
                Price = 59900,
                Year = 2010,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 11,
                CarPic = "https://g1-bg.cars.bg/2020-11-18_1/5fb47bb365020349af41da42o.jpg",
                Km = 25000,
                FuelId = 2,
                BrandId = 3,
                Model = "GT",
                TransmissionId = 1,
                ColorId = 6,
                Horsepower = 510,
                Price = 174999,
                Year = 2016,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 12,
                CarPic = "https://g1-bg.cars.bg/2020-06-06_2/5edb8a8f752df425d624b483o.jpg",
                Km = 167000,
                FuelId = 3,
                BrandId = 4,
                Model = "Accord",
                TransmissionId = 2,
                ColorId = 5,
                Horsepower = 150,
                Price = 15800,
                Year = 2010,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 13,
                CarPic = "https://g1-bg.cars.bg/2019-08-02_2/31305837o.jpg",
                Km = 40181,
                FuelId = 2,
                BrandId = 4,
                Model = "Civic ",
                TransmissionId = 1,
                ColorId = 5,
                Horsepower = 161,
                Price = 26750,
                Year = 2017,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 14,
                CarPic = "https://g1-bg.cars.bg/2020-04-07_2/5e8c8f30794ff050e3105964o.jpg",
                Km = 23000,
                FuelId = 2,
                BrandId = 4,
                Model = "Civic ",
                TransmissionId = 1,
                ColorId = 5,
                Horsepower = 182,
                Price = 39900,
                Year = 2018,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 15,
                CarPic = "https://g1-bg.cars.bg/2020-10-16_1/5f895bf06cb0a84db67d7fb2o.jpg",
                Km = 75600,
                FuelId = 3,
                BrandId = 4,
                Model = "CR-v",
                TransmissionId = 1,
                ColorId = 1,
                Horsepower = 160,
                Price = 46990,
                Year = 2015,
                UserId = 3,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 16,
                CarPic = "https://g1-bg.cars.bg/2020-10-31_1/5f9cd80b8f564d2c9926e5e2o.jpg",
                Km = 62000,
                FuelId = 2,
                BrandId = 5,
                Model = "508",
                TransmissionId = 1,
                ColorId = 1,
                Horsepower = 225,
                Price = 66000,
                Year = 2019,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 17,
                CarPic = "https://g1-bg.cars.bg/2020-09-11_1/5f5b210107c8b8427b4ee022o.jpg",
                Km = 4000,
                FuelId = 4,
                BrandId = 12,
                Model = "Camry",
                TransmissionId = 1,
                ColorId = 10,
                Horsepower = 218,
                Price = 67990,
                Year = 2020,
                UserId = 2,
                IsAvailable = true
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 18,
                CarPic = "https://g1-bg.cars.bg/2020-11-13_2/5fae87399b9c727e493ad622b.jpg",
                Km = 180000,
                FuelId = 1,
                BrandId = 1,
                Model = "530",
                TransmissionId = 2,
                ColorId = 3,
                Horsepower = 140,
                Price = 21300.00,
                Year = 2011,
                UserId = 2,
                IsAvailable = true
            });
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
        public virtual DbSet<RequestSaver> RequestSavers { get; set; }
    }
}