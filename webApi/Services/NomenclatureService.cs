using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Services
{
    public class NomenclatureService<TNomenclature> : INomenclatureService<TNomenclature>
        where TNomenclature : Nomenclature
    {
        protected readonly AppDbContext context;
        public NomenclatureService(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<TNomenclature> GetAll()
        {
            return context.Set<TNomenclature>().OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<TNomenclature> GetFiltered(string textFilter, int limit, int offset)
        {
            var query = context.Set<TNomenclature>()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(textFilter))
            {
                query = query.Where(e => e.Name.Trim().ToLower().Contains(textFilter.Trim().ToLower()));
            }

            return query.OrderBy(e => e.Id)
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public TNomenclature Add(TNomenclature model)
        {
            context.Set<TNomenclature>().Add(model);
            context.SaveChanges();

            return model;
        }
        public async Task<TNomenclature> GetByIdAsync(int id)
        {
            return await context.FindAsync<TNomenclature>(id);
        }
        public async Task<TNomenclature> UpdateAsync(int id, TNomenclature model)
        {
            var existingItem = context.Find<TNomenclature>(id);

            if (existingItem != null)
            {
                existingItem.Name = model.Name;
                await context.SaveChangesAsync();
            }
            return model;
        }
        public void Delete(int id)
        {
            var itemToDelete = context.Find<TNomenclature>(id);
            context.Remove(itemToDelete);
            context.SaveChanges();
        }
    }
}
