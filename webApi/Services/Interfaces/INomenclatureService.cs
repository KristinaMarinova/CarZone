using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Services
{
    public interface INomenclatureService<TNomenclature>
        where TNomenclature : Nomenclature
    {
        IEnumerable<TNomenclature> GetAll();
        IEnumerable<TNomenclature> GetFiltered(string textFilter, int limit, int offset);
        Task<TNomenclature> GetByIdAsync(int id);
        TNomenclature Add(TNomenclature model);
        Task<TNomenclature> UpdateAsync(int id, TNomenclature model);
        void Delete(int id);
    }
}
