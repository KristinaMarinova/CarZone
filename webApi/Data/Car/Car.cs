using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace WebCarsProject.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string CarPic { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }
        public int FuelId { get; set; }
        public int ColorId { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public int ViewCount { get; set; }
        public int LikesCount { get; set; }
        public int TransmissionId { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public int UserId { get; set; }
        public Fuel Fuel { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        public Transmission Transmission { get; set; }
        public User User { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }

    }
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
        }
    }
}