using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarsProject.Data;

namespace WebCarsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestSaversController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequestSaversController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestSaver>>> GetRequestSavers()
        {
            return await _context.RequestSavers.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RequestSaver>> GetRequestSaver(int id)
        {
            var requestSaver = await _context.RequestSavers.FindAsync(id);

            if (requestSaver == null)
            {
                return NotFound();
            }

            return requestSaver;
        }
    }
}
