using Microsoft.AspNetCore.Mvc;
using WebCarsProject.Data;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
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