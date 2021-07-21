using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using CarZone.Data;
using CarZone.Models;
using CarZone.Models.DTOs;

namespace CarZone.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext context;
        private readonly UserContext userContext;
        public CarService(AppDbContext context, UserContext userContext
        )
        {
            this.context = context;
            this.userContext = userContext;
        }
        public IEnumerable<CarDTO> CarsByQueryAsync(CarFilter filter)
        {
            var result = context.Cars
                .FilterCars(filter).Select(CarDTO.SelectExpression);
            return result;
        }
        public IEnumerable<CarDTO> GetAllCars()
        {
            var userId = userContext.UserId;

            return context.Cars.Where(x => x.CreatedTime != null)
                .OrderByDescending(x => x.CreatedTime)
                .Select(CarDTO.SelectExpression);
        }
        public CarDTO GetCarById(int id)
        {
            var carDto = context.Cars
             .Where(e => e.Id == id)
             .Select(CarDTO.SelectExpression)
             .SingleOrDefault();

            return carDto;
        }
        public Car AddCar(Car car)
        {
            car.UserId = userContext.UserId;
            context.Entry(car).State = EntityState.Added;
            context.SaveChanges();
            return car;
        }
        public void UpdateCarAsync(int id, Car car)
        {
            var existingCar = context.Cars.Where(c => c.Id == id).SingleOrDefault();

            if (existingCar != null)
            {
                existingCar.Fuel = car.Fuel;
                existingCar.Km = car.Km;
                existingCar.Model = car.Model;
                existingCar.Brand = car.Brand;
                existingCar.CarPic = car.CarPic;
                existingCar.Color = car.Color;
                existingCar.Fuel = car.Fuel;
                existingCar.IsAvailable = car.IsAvailable;
                existingCar.Price = car.Price;
                existingCar.Year = car.Year;
                existingCar.Horsepower = car.Horsepower;
                existingCar.Transmission = car.Transmission;
            }
            context.SaveChanges();
        }
        public void DeleteCarByIdAsync(int id)
        {
            var carToDelete = context.Cars.Where(e => e.Id == id).SingleOrDefault();
            context.Cars.Remove(carToDelete);
            context.SaveChanges();
        }

        public IEnumerable<CarDTO> GetUsersLikedCars()
        {
            var result = context.Likes.Where(x => x.UserId == userContext.UserId)
                .Select(e => new CarDTO {
                    Id = e.CarId,
                    Brand = e.Car.Brand,
                    Model = e.Car.Model,
                    CarPic = e.Car.CarPic,
                    Price = e.Car.Price
                }).ToList();

            return result;
        }
    }

    public static class CarQueryExtensions
    {
        public static IQueryable<Car> FilterCars(this IQueryable<Car> query, CarFilter filter)
        {
            if (filter.BrandId.HasValue && filter.BrandId != 0)
            {
                query = query.Where(c => c.Brand.Id == filter.BrandId);
            }
            if (!string.IsNullOrWhiteSpace(filter.Model))
            {
                query = query.Where(c => c.Model.Contains(filter.Model));
            }
            if (filter.FuelId.HasValue && filter.FuelId != 0)
            {
                query = query.Where(c => c.Fuel.Id == filter.FuelId);
            }
            if (filter.ColorId.HasValue && filter.ColorId != 0)
            {
                query = query.Where(c => c.Color.Id == filter.ColorId);
            }
            if (filter.TransmissionId.HasValue && filter.TransmissionId != 0)
            {
                query = query.Where(c => c.Transmission.Id == filter.TransmissionId);
            }

            return query.Skip(filter.Offset).Take(filter.Limit);
        }
    }
}