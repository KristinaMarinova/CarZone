using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.Interfaces;

namespace CarZone.Controllers
{
    [Route("api/Cars/{carId:int}/description")]
    [ApiController]
    public class HistoryDescriptionControler : ControllerBase
    {

        private readonly IHisoryDescriptionService descriptionService;
        public HistoryDescriptionControler(IHisoryDescriptionService descriptionService)
        {
            this.descriptionService = descriptionService;
        }

        [HttpGet]
        public IEnumerable<Description> GetAllHistory(int carId)
        {
            return descriptionService.GetAllHistoryDescriptions(carId);
        }
        
        [HttpGet("{id:int}")]
        public Description GetById(int id)
        {
            return descriptionService.GetById(id);
        }

        [HttpPost]
        public void PostDescription(int carId, List<Description> descriptionList)
        {
            descriptionService.AddHistoryDescription(carId, descriptionList);
        }

        [HttpPut]
        public Task UpdateDescription(int carId, List<Description> description)
            => descriptionService.UpdateDescription(carId, description);

        [HttpDelete("{id:int}")]
        public void DeleteDescription(int id)
        {
            descriptionService.DeleteHistoryDescription(id);
        }

    }
}
