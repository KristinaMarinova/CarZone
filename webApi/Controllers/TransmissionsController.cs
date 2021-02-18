using Microsoft.AspNetCore.Mvc;
using WebCarsProject.Data;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
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