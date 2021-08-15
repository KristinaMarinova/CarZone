using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Services.Interfaces
{
    public interface IPartService
    {
        IEnumerable<Part> GetAllParts(int carId);
        Part GetById(int id);
        void AddPart(int carId, List<Part> description);
        Task UpdatePart(int carId, List<Part> description);
        void DeletePart(int descriptionId);
    }
}
