using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCarsProject.Data;

namespace WebCarsProject.Models.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string CarPic { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }
        public Fuel Fuel { get; set; }
        public Color Color { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public int ViewCount { get; set; }
        public int LikesCount { get; set; }
        public Transmission Transmission { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public List<Description> Description { get; set; }

        public static Expression<Func<Car, CarDTO>> SelectExpression
        {
            get
            {
                return e => new CarDTO
                {
                    Id = e.Id,
                    Fuel = e.Fuel,
                    Km = e.Km,
                    Horsepower = e.Horsepower,
                    LikesCount = e.LikesCount,
                    CarPic = e.CarPic,
                    Price = e.Price,
                    Transmission = e.Transmission,
                    Model = e.Model,
                    Color = e.Color,
                    Year = e.Year,
                    UserId = e.UserId,
                    Brand = e.Brand,    
                    Description = e.Descriptions.ToList()
                };
            }
        }
    }
}
