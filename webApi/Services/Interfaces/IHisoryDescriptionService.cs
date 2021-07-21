using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Services.Interfaces
{
    public interface IHisoryDescriptionService
    {
        IEnumerable<Description> GetAllHistoryDescriptions(int carId);
        Description GetById(int id);
        void AddHistoryDescription(int carId, List<Description> description);
        Task UpdateDescription(int carId, List<Description> description);
        void DeleteHistoryDescription(int descriptionId);
    }
}
