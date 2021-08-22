using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.Interfaces;

namespace CarZone.Controllers
{
    [Route("api/Cars/{carId:int}/part")]
    [ApiController]
    public class PartsControler : ControllerBase
    {

        private readonly IPartService partService;
        public PartsControler(IPartService partService)
        {
            this.partService = partService;
        }

        [HttpGet]
        public async Task<List<Part>> GetAllHistoryAsync(int carId)
        {
            return await partService.GetAllPartsAsync(carId);
        }
        
        [HttpGet("{id:int}")]
        public Part GetById(int id)
        {
            return partService.GetById(id);
        }

        [HttpPost]
        public async Task PostDescriptionAsync(int carId, List<Part> descriptionList)
        {
            await partService.AddPartAsync(carId, descriptionList);
        }

        [HttpPut]
        public Task UpdateDescription(int carId, List<Part> description)
        {
            return partService.UpdatePart(carId, description);
        }

        [HttpDelete("{id:int}")]
        public void DeleteDescription(int id)
        {
            partService.DeletePart(id);
        }

    }
}
