using Microsoft.AspNetCore.Mvc;
using CarZone.Data;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : NomenclatureController<Color>
    {
        public ColorsController(INomenclatureService<Color> service) 
            : base(service)
        {
        }
    }
}