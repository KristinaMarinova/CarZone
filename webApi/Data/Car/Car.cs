using System;
using System.Collections.Generic;

namespace CarZone.Data
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
        public virtual ICollection<Part> Parts { get; set; }
    }
}