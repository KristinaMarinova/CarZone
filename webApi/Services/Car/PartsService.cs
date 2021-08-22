using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.Interfaces;

namespace CarZone.Services
{
    public class PartsService : IPartService
    {
        private readonly AppDbContext context;
        private readonly UserContext user;
        public PartsService(AppDbContext context, UserContext user)
        {
            this.context = context;
            this.user = user;
        }

        public async Task<List<Part>> GetAllPartsAsync(int carId)
        {
           return await context.Parts.Where(x => x.CarId == carId).ToListAsync();
        }

        public Part GetById(int id)
        {
            return context.Parts.Where(x => x.Id == id).SingleOrDefault();
        }

        public async Task AddPartAsync(int carId, List<Part> parts)
        {
            foreach (var part in parts)
            {
                part.UserId = user.UserId;
                part.CarId = carId;
                context.Parts.Add(part);
            }

            await context.SaveChangesAsync() ;
        }

        public async Task UpdatePart(int carId, List<Part> description)
        {
            var existingHistoryDetails = await context.Parts
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
                context.Parts.AddRange(forAdd);
            }

            var forDelete = existingHistoryDetails.Where(e => !description.Any(d => d.Id == e.Id));
            if (forDelete.Any())
            {
                context.Parts.RemoveRange(forDelete);
            }

            var forUpdate = existingHistoryDetails.Where(e => description.Any(d => d.Id == e.Id));
            foreach (var item in forUpdate)
            {
                var updatedValue = description.Single(e => e.Id == item.Id);
                item.Name = updatedValue.Name;
                item.Description= updatedValue.Description;
            }

            await context.SaveChangesAsync();
        }

        public void DeletePart(int descriptionId)
        {
            var descriptionToDelete = context.Parts.Where(e => e.Id == descriptionId).SingleOrDefault();
            context.Parts.Remove(descriptionToDelete);
            context.SaveChanges();
        }
    }
}
