using System.Collections.Generic;
using System.Threading.Tasks;
using WebCarsProject.Data;

namespace WebCarsProject.Services
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
