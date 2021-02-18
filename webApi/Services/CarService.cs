using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebCarsProject.Data;
using WebCarsProject.Models;
using WebCarsProject.Models.DTOs;

namespace WebCarsProject.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly UserContext _userContext;
        public CarService(AppDbContext context, UserContext userContext
        )
        {
            _context = context;
            _userContext = userContext;
        }
        public IEnumerable<CarDTO> GetAllCars()
        {
            var userId = _userContext.UserId;

            return _context.Cars.Where(x => x.CreatedTime != null)
                .OrderByDescending(x => x.CreatedTime)
                .Select(e => new CarDTO
                {
                    Id = e.Id,
                    Fuel = e.Fuel,
                    Km = e.Km,
                    Horsepower = e.Horsepower,
                    LikesCount = e.LikesCount,
                    CarPic = e.CarPic,
                    Brand = e.Brand,
                    Price = e.Price,
                    Transmission = e.Transmission,
                    Model = e.Model,
                    ViewCount = e.ViewCount,
                    Color = e.Color,
                    Year = e.Year
                });
        }
        public CarDTO GetCarById(int id)
        {
            var carDto = _context.Cars
                .Where(e => e.Id == id)
                .Select(CarDTO.SelectExpression)
                .SingleOrDefault();
            return carDto;
        }
        public Car AddCar(Car car)
        {
            car.UserId = _userContext.UserId;
            TrimWhiteSpaces(car);
            _context.Entry(car).State = EntityState.Added;
            _context.SaveChanges();
            return car;
        }
        public void UpdateCarAsync(int id, Car car)
        {
            var existingCar = _context.Cars.Where(c => c.Id == id).SingleOrDefault();

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
            _context.SaveChanges();
        }
        public void DeleteCarByIdAsync(int id)
        {
            var carToDelete = _context.Cars.Where(e => e.Id == id).SingleOrDefault();
            _context.Cars.Remove(carToDelete);
            _context.SaveChanges();
        }
        public IEnumerable<CarDTO> CarsByQueryAsync(CarFilter filter)
        {
            var result = _context.Cars
                .FilterCars(filter).Select(e => new CarDTO
                {
                    Id = e.Id,
                    Fuel = e.Fuel,
                    Km = e.Km,
                    Horsepower = e.Horsepower,
                    LikesCount = e.LikesCount,
                    CarPic = e.CarPic,
                    Brand = e.Brand,
                    Price = e.Price,
                    Transmission = e.Transmission,
                    Model = e.Model,
                    ViewCount = e.ViewCount,
                    Color = e.Color,
                    Year = e.Year
                });
            return result;
        }

        public IEnumerable<CarDTO> GetUsersLikedCars()
        {
            var result =  _context.Likes.Where(x => x.UserId == _userContext.UserId)
                .Select(e => new CarDTO
                {
                    Id = e.CarId,
                    Brand = e.Car.Brand,
                    Model = e.Car.Model,
                    CarPic = e.Car.CarPic,
                    Price = e.Car.Price
                }).ToList();

            return result;
        }

        public void IncrementViews(int id)
        {
            var car = _context.Cars.Find(id);
            car.ViewCount++;
            _context.SaveChanges();
        }
        public int GetCountOfViews(int carId)
        {
            return _context.Cars.Where(x => x.Id == carId).SingleOrDefault().ViewCount;
        }
        private void TrimWhiteSpaces(Car car)
        {
            car.Model = car.Model.Trim();
            car.CarPic = car.CarPic.Trim();
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
                query = query.Where(c => c.Model == filter.Model);
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