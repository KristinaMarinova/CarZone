using System.Collections.Generic;
using WebCarsProject.Data;
using WebCarsProject.Models;
using WebCarsProject.Models.DTOs;

namespace WebCarsProject.Services
{
    public interface ICarService
    {
        IEnumerable<CarDTO> CarsByQueryAsync(CarFilter filter);
        IEnumerable<CarDTO> GetAllCars();
        CarDTO GetCarById(int id);
        Car AddCar(Car car);
        void UpdateCarAsync(int id, Car car);
        void DeleteCarByIdAsync(int id);
        void IncrementViews(int id);
        public int GetCountOfViews(int carId);
        IEnumerable<CarDTO> GetUsersLikedCars();
    }
}