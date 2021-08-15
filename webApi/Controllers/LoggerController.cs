using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarZone.Data;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly AppLogContext context;

        public LoggerController(AppLogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLogsAsync()
        {
            return await context.Logs.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Log>> GetLogByIdAsync(int id)
        {
            var requestSaver = await context.Logs.FindAsync(id);

            if (requestSaver == null)
            {
                return NotFound();
            }

            return requestSaver;
        }
    }
}
