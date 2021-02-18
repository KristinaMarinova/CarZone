using Microsoft.AspNetCore.Mvc;
using WebCarsProject.Data;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
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