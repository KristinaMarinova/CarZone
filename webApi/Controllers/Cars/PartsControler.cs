using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.Interfaces;

namespace CarZone.Controllers
{
    [Route("api/Cars/{carId:int}/description")]
    [ApiController]
    public class PartsControler : ControllerBase
    {

        private readonly IPartService descriptionService;
        public PartsControler(IPartService descriptionService)
        {
            this.descriptionService = descriptionService;
        }

        [HttpGet]
        public IEnumerable<Part> GetAllHistory(int carId)
        {
            return descriptionService.GetAllParts(carId);
        }
        
        [HttpGet("{id:int}")]
        public Part GetById(int id)
        {
            return descriptionService.GetById(id);
        }

        [HttpPost]
        public void PostDescription(int carId, List<Part> descriptionList)
        {
            descriptionService.AddPart(carId, descriptionList);
        }

        [HttpPut]
        public Task UpdateDescription(int carId, List<Part> description)
            => descriptionService.UpdatePart(carId, description);

        [HttpDelete("{id:int}")]
        public void DeleteDescription(int id)
        {
            descriptionService.DeletePart(id);
        }

    }
}
