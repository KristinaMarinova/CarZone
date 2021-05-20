using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCarsProject.Data;
using WebCarsProject.Models;
using WebCarsProject.Models.DTOs;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(
            ICarService carService
        )
        {
            _carService = carService;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IEnumerable<CarDTO> CarsByQuery([FromQuery] CarFilter filter)
        {
            return _carService.CarsByQueryAsync(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<CarDTO> GetCars()
        {
            return _carService.GetAllCars();
        }

        [HttpGet("{id:int}")]
        public CarDTO GetCar(int id)
        {
            return _carService.GetCarById(id);
        }

        [HttpPost("{id:int}/IncrementViews")]
        public void IncrementViews(int id)
        {
            _carService.IncrementViews(id);
        }

        [HttpPut("{id:int}")]
        public void PutCar(int id, Car car)
        {
            _carService.UpdateCarAsync(id, car);
        }

        [HttpPost]
        public Car PostCar(Car car)
        {
            return _carService.AddCar(car);
        }

        [HttpDelete("{id:int}")]
        public void DeleteCar(int id)
        {
            _carService.DeleteCarByIdAsync(id);
        }

        [HttpGet("{carId:int}/Views")]
        public int GetCountOfLikes(int carId)
        {
            return _carService.GetCountOfViews(carId);
        }

        [HttpGet("Liked")]
        public IEnumerable<CarDTO> GetUsersLikedCars()
        {
            return _carService.GetUsersLikedCars();
        }
    }
}