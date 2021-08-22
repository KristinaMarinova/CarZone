using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Services.Interfaces
{
    public interface IPartService
    {
        Task<List<Part>> GetAllPartsAsync(int carId);
        Part GetById(int id);
        Task AddPartAsync(int carId, List<Part> parts);
        Task UpdatePart(int carId, List<Part> parts);
        void DeletePart(int descriptionId);
    }
}
