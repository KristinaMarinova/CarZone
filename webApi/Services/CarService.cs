using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebCarsProject.Data;
using WebCarsProject.Models;
using WebCarsProject.Models.DTOs;

namespace WebCarsProject.Services
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

            var isViewExist = context.Views.Where(x => x.UserId == userContext.UserId && x.CarId == id).ToList().Count > 0;
            if (!isViewExist)
            {
                context.Views.Add(new View {
                    CarId = id,
                    UserId = userContext.UserId
                });
                carDto.ViewCount++;
                context.SaveChanges();
            }

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
        public void IncrementViews(int id) //todo
        {
            var car = context.Cars.Find(id);
            //car.ViewCount++;
            context.SaveChanges();
        }
        public int GetCountOfViews(int carId) //todo
        {
            //return context.Cars.Where(x => x.Id == carId).SingleOrDefault().ViewCount;
            return 1;
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

        //public IEnumerable<newCarDTO> GetNewCars()
        //{
        //    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        //    HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.cars.bg/");

        //    var price = doc.DocumentNode.SelectNodes("//h6[@class='card__title mdc-typography mdc-typography--headline6 price']").ToArray();
        //    var title = doc.DocumentNode.SelectNodes("//h5[@class='card__title mdc-typography mdc-typography--headline5 observable']").ToArray();
        //    var info = doc.DocumentNode.SelectNodes("//div[@class='card__secondary mdc-typography mdc-typography--body1 black']").ToArray();
        //    var description = doc.DocumentNode.SelectNodes("//div[@class='card__secondary mdc-typography mdc-typography--body2']").ToArray();

        //    var href = doc.DocumentNode.SelectNodes("//a[@class='d-grid no-decoration']").ToArray();
        //    var links = new List<string>();

        //    foreach (var item in href)
        //    {
        //        var i = item.OuterHtml.Split("list-link=");
        //        string f = i[0].Remove(0, 9);
        //        f = f.Remove(f.Length - 2, 2);

        //        links.Add(f);
        //    }

        //    var carsList = new List<newCarDTO>();

        //    for (int i = 0; i < price.Length; i++)
        //    {
        //        carsList.Add(new newCarDTO
        //        {
        //            Price = price[i].InnerText.TrimStart().TrimEnd().ToString(),
        //            Title = title[i].InnerText.TrimStart().TrimEnd().ToString(),
        //            Info = info[i].InnerText.TrimStart().TrimEnd().ToString(),
        //            Description = description[i].InnerText.TrimStart().TrimEnd().ToString(),
        //            Link = links[i]
        //        });
        //    }

        //    return carsList;
        //}
        //public newCarDTO GetNewCarById(string id)
        //{
        //    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        //    HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.cars.bg/offer/" + id);

        //    var title = doc.DocumentNode
        //        .SelectNodes("//div[@style='float:left; font-size: 1.5em; padding-top: 3px;']")
        //        .SingleOrDefault().InnerText;

        //    var textAfterTite = doc.DocumentNode.SelectNodes("//div[@class='text-copy']").ToArray();
        //    var description = doc.DocumentNode.SelectNodes("//div[@class='description text-copy' ]").SingleOrDefault().InnerText;
        //    var imgListUrl =  GetUrlPicList(id);
        //    var price = doc.DocumentNode.SelectNodes("//div[@class='offer-price']").SingleOrDefault().InnerText;

        //    return null;
        //}
        //public List<string> GetUrlPicList(string id)
        //{
        //    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

        //    HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.cars.bg/offer/" + id);

        //    var images = doc.DocumentNode.SelectNodes("//img[@class='owl-lazy']").ToArray();
        //    var imgListUrl = new List<string>();

        //    foreach (var i in images)
        //    {
        //        var imgArr = i.OuterHtml.Split(" class");
        //        string img = imgArr[0].Remove(0, 15);
        //        img = img.Remove(img.Length - 1, 1);

        //        imgListUrl.Add(img);
        //    }

        //    return imgListUrl;
        //}
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