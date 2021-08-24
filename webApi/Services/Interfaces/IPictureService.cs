using CarZone.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarZone.Services.Interfaces
{
    public interface IPictureService
    {
        Task<List<Picture>> GetAllPicturesAsync(int carId);
        Task<Picture> GetByIdAsync(int id);
        Task AddPicturesAsync(int carId, List<Picture> pics);
        Task UpdatePicturesAsync(int id, List<Picture> pics);
        Task DeletePicAsync(int picId);
    }
}
