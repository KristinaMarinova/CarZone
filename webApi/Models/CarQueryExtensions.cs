using System.Linq;
using CarZone.Data;

namespace CarZone.Models
{
    public static class CarQueryExtensions
    {
        public static IQueryable<Car> FilterCars(IQueryable<Car> query, CarFilter filter)
        {
            //if (filter.Brand.Id != 0)
            //{
            //    query = query.Where(c => c.Brand.Id == filter.Brand.Id);
            //}
            //if (!string.IsNullOrWhiteSpace(filter.Model))
            //{
            //    query = query.Where(c => c.Model == filter.Model);
            //}
            //if (filter.Fuel.Id != 0)
            //{
            //    query = query.Where(c => c.Fuel.Id == filter.Fuel.Id);
            //}
            //if (filter.Color.Id != 0)
            //{
            //    query = query.Where(c => c.Color.Id == filter.Color.Id);
            //}

            return query.Skip(filter.Offset).Take(filter.Limit);
        }
    }
}
