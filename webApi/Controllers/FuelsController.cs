using Microsoft.AspNetCore.Mvc;
using CarZone.Data;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : NomenclatureController<Fuel>
    {
        public FuelsController(INomenclatureService<Fuel> service) 
            : base(service)
        {
        }
    }
}