using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarZone.Data;
using CarZone.Models;
using CarZone.Models.DTOs;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;

        public CarsController(
            ICarService carService
        )
        {
            this.carService = carService;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IEnumerable<CarDTO> CarsByQuery([FromQuery] CarFilter filter)
        {
            return carService.CarsByQueryAsync(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<CarDTO> GetCars()
        {
            return carService.GetAllCars();
        }

        [HttpGet("{id:int}")]
        public CarDTO GetCar(int id)
        {
            return carService.GetCarById(id);
        }


        [HttpPut("{id:int}")]
        public void PutCar(int id, Car car)
        {
            carService.UpdateCarAsync(id, car);
        }

        [HttpPost]
        public Car PostCar(Car car)
        {
            return carService.AddCar(car);
        }

        [HttpDelete("{id:int}")]
        public void DeleteCar(int id)
        {
            carService.DeleteCarByIdAsync(id);
        }


        [HttpGet("Liked")]
        public IEnumerable<CarDTO> GetUsersLikedCars()
        {
            return carService.GetUsersLikedCars();
        }
    }
}