using Microsoft.AspNetCore.Mvc;
using WebCarsProject.Data;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
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