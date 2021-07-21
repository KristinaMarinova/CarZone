using Microsoft.AspNetCore.Mvc;
using CarZone.Data;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : NomenclatureController<Transmission>
    {
        public TransmissionsController(INomenclatureService<Transmission> service) 
            : base(service)
        {
        }
    }
}