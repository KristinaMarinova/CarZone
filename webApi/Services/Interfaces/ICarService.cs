using System.Collections.Generic;
using CarZone.Data;
using CarZone.Models;
using CarZone.Models.DTOs;

namespace CarZone.Services
{
    public interface ICarService
    {
        IEnumerable<CarDTO> CarsByQueryAsync(CarFilter filter);
        IEnumerable<CarDTO> GetAllCars();
        CarDTO GetCarById(int id);
        Car AddCar(Car car);
        void UpdateCarAsync(int id, Car car);
        void DeleteCarByIdAsync(int id);
        //void IncrementViews(int id);
        //public int GetCountOfViews(int carId);
        IEnumerable<CarDTO> GetUsersLikedCars();
    }
}