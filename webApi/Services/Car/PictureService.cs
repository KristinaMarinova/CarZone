using CarZone.Data;
using CarZone.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarZone.Services
{
    public class PictureService : IPictureService
    {
        private readonly AppDbContext context;
        public PictureService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Picture>> GetAllPicturesAsync(int carId)
        {
            return await context.Pictures
                .Where(x => x.CarId == carId)
                .ToListAsync();
        }

        public async Task<Picture> GetByIdAsync(int id)
        {
            return await context.Pictures
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task AddPicturesAsync(int carId, List<Picture> pics)
        {
            foreach (var pic in pics)
            {
                pic.CarId = carId;
                context.Pictures.Add(pic);
            }

            await context.SaveChangesAsync();
        }

        public async Task DeletePicAsync(int picId)
        {
            var picToDelete = context.Pictures
                .Where(e => e.Id == picId).
                SingleOrDefault();

            context.Pictures.Remove(picToDelete);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePicturesAsync(int carId, List<Picture> pics)
        {
            var existingPics = await context.Pictures
                .Where(c => c.CarId == carId)
                .ToListAsync();

            var forAdd = pics.Where(e => !existingPics.Any(x => x.Id == e.Id));

            if (forAdd.Any())
            {
                foreach (var item in forAdd)
                {
                    item.CarId = carId;
                }

                context.Pictures.AddRange(forAdd);
            }

            var forDelete = existingPics.Where(e => !pics.Any(d => d.Id == e.Id));
            if (forDelete.Any())
            {
                context.Pictures.RemoveRange(forDelete);
            }

            var forUpdate = existingPics.Where(e => pics.Any(d => d.Id == e.Id));
            foreach (var item in forUpdate)
            {
                var updatedValue = pics.Single(e => e.Id == item.Id);
                item.Paths = updatedValue.Paths;
            }

            await context.SaveChangesAsync();
        }
    }
}
