using CarZone.Data;
using CarZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarZone.Controllers.Cars
{
    [Route("api/Cars/{carId:int}/pics")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureService picService;
        public PicturesController(IPictureService picService)
        {
            this.picService = picService;
        }

        [HttpGet]
        public async Task<List<Picture>> GetAllCarPics(int carId)
        {
            return await picService.GetAllPicturesAsync(carId);
        }

        [HttpPost]
        public async Task PostPicture(int carId, List<Picture> picList)
        {
            await picService.AddPicturesAsync(carId, picList);
        }

        [HttpPut]
        public Task UpdatePics(int carId, List<Picture> pics)
        {
            return picService.UpdatePicturesAsync(carId, pics);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteDescription(int id)
        {
            await picService.DeletePicAsync(id);
        }
    }
}
