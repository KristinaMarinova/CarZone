using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.Interfaces;

namespace CarZone.Services
{
    public class HisoryDescriptionService : IHisoryDescriptionService
    {
        private readonly AppDbContext context;
        private readonly UserContext user;
        public HisoryDescriptionService(AppDbContext context, UserContext user)
        {
            this.context = context;
            this.user = user;
        }

        public IEnumerable<Description> GetAllHistoryDescriptions(int carId)
        {
            var d = this.context.Descriptions.Where(x => x.CarId == carId).ToList();
            return d;
        }

        public Description GetById(int id)
        {
            return context.Descriptions.Where(x => x.Id == id).SingleOrDefault();
        }

        public void AddHistoryDescription(int carId, List<Description> descriptionList)
        {
            foreach (var description in descriptionList)
            {
                description.UserId = user.UserId;
                description.CarId = carId;
                context.Descriptions.Add(description);
            }
            context.SaveChanges();
        }

        public async Task UpdateDescription(int carId, List<Description> description)
        {
            var existingHistoryDetails = await context.Descriptions
                .Where(c => c.CarId == carId)
                .ToListAsync();

            var forAdd = description.Where(e => !existingHistoryDetails.Any(ehd => ehd.Id == e.Id));


            if (forAdd.Any())
            {
                foreach (var item in forAdd)
                {
                    item.CarId = carId;
                    item.UserId = user.UserId;
                }
                context.Descriptions.AddRange(forAdd);
            }

            var forDelete = existingHistoryDetails.Where(e => !description.Any(d => d.Id == e.Id));
            if (forDelete.Any())
            {
                context.Descriptions.RemoveRange(forDelete);
            }

            var forUpdate = existingHistoryDetails.Where(e => description.Any(d => d.Id == e.Id));
            foreach (var item in forUpdate)
            {
                var updatedValue = description.Single(e => e.Id == item.Id);
                item.Detail = updatedValue.Detail;
                item.DescriptionDetail = updatedValue.DescriptionDetail;
            }

            await context.SaveChangesAsync();
        }

        public void DeleteHistoryDescription(int descriptionId)
        {
            var descriptionToDelete = context.Descriptions.Where(e => e.Id == descriptionId).SingleOrDefault();
            context.Descriptions.Remove(descriptionToDelete);
            context.SaveChanges();
        }
    }
}
