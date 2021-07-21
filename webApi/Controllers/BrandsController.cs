using Microsoft.AspNetCore.Mvc;
using CarZone.Data;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : NomenclatureController<Brand>
    {
        public BrandsController(INomenclatureService<Brand> service)
            : base(service)
        {
        }
    }
}