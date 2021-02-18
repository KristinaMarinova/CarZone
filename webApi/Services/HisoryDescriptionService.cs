using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCarsProject.Data;
using WebCarsProject.Services.Interfaces;

namespace WebCarsProject.Services
{
    public class HisoryDescriptionService : IHisoryDescriptionService
    {
        private readonly AppDbContext _context;
        private readonly UserContext _user;
        public HisoryDescriptionService(AppDbContext context, UserContext user)
        {
            _context = context;
            _user = user;
        }

        public IEnumerable<Description> GetAllHistoryDescriptions(int carId)
        {
            var d = this._context.Descriptions.Where(x => x.CarId == carId).ToList();
            return d;
        }

        public Description GetById(int id)
        {
            return _context.Descriptions.Where(x => x.Id == id).SingleOrDefault();
        }

        public void AddHistoryDescription(int carId, List<Description> descriptionList)
        {
            foreach (var description in descriptionList)
            {
                description.UserId = _user.UserId;
                description.CarId = carId;
                _context.Descriptions.Add(description);
            }
            _context.SaveChanges();
        }

        public async Task UpdateDescription(int carId, List<Description> description)
        {
            var existingHistoryDetails = await _context.Descriptions
                .Where(c => c.CarId == carId)
                .ToListAsync();

            var forAdd = description.Where(e => !existingHistoryDetails.Any(ehd => ehd.Id == e.Id));


            if (forAdd.Any())
            {
                foreach (var item in forAdd)
                {
                    item.CarId = carId;
                    item.UserId = _user.UserId;
                }
                _context.Descriptions.AddRange(forAdd);
            }

            var forDelete = existingHistoryDetails.Where(e => !description.Any(d => d.Id == e.Id));
            if (forDelete.Any())
            {
                _context.Descriptions.RemoveRange(forDelete);
            }

            var forUpdate = existingHistoryDetails.Where(e => description.Any(d => d.Id == e.Id));
            foreach (var item in forUpdate)
            {
                var updatedValue = description.Single(e => e.Id == item.Id);
                item.Detail = updatedValue.Detail;
                item.DescriptionDetail = updatedValue.DescriptionDetail;
            }

            await _context.SaveChangesAsync();
        }

        public void DeleteHistoryDescription(int descriptionId)
        {
            var descriptionToDelete = _context.Descriptions.Where(e => e.Id == descriptionId).SingleOrDefault();
            _context.Descriptions.Remove(descriptionToDelete);
            _context.SaveChanges();
        }
    }
}
