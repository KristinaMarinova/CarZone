using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarZone.Data;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Role>>> GetUserTypes()
        //{
        //    return await _context.Roles.ToListAsync();
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Role>> GetUserType(int id)
        //{
        //    var userType = await _context.Roles.FindAsync(id);

        //    if (userType == null)
        //    {
        //        return NotFound();
        //    }

        //    return userType;
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> PutUserType(int id, Role userType)
        //{
        //    if (id != userType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userType).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<Role>> PostUserType(Role userType)
        //{
        //    _context.Roles.Add(userType);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserType", new { id = userType.Id }, userType);
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Role>> DeleteUserType(int id)
        //{
        //    var userType = await _context.Roles.FindAsync(id);
        //    if (userType == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Roles.Remove(userType);
        //    await _context.SaveChangesAsync();

        //    return userType;
        //}

        //private bool UserTypeExists(int id)
        //{
        //    return _context.Roles.Any(e => e.Id == id);
        //}
    }
}
