using System.Linq;
using CarZone.Data;

namespace CarZone.Models
{
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
