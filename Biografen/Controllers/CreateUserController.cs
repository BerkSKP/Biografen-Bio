using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biografen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Biografen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class createUserController : ControllerBase
    {
        //henter data fra DatabaseContext 
        private readonly DatabaseContext _context;
        public createUserController(DatabaseContext context)
        {
            _context = context;
        }
        //GET: Api/createuser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateUser>>> GetCreateUser()
        {
            return await _context.createUsers.ToListAsync();
        }
        //Get: api/createuser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateUser>> GetCreateUser(int id)
        {
            var createuser = await _context.createUsers.FindAsync(id);
            if (createuser == null)
            {
                return NotFound();
            }
            return createuser;
        }
        // PUT: api/createuser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreateUser(int id, CreateUser created)
        {
            if (id != created.createuserId)
            {
                return BadRequest();
            }
            _context.Entry(created).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/createuser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CreateUser>> PostCreateUser(CreateUser create)
        {
            _context.createUsers.Add(create);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCinemaHall", new { id = create.createuserId }, create);
        }
        // DELETE: api/createuser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CreateUser>> DeleteCrateUser(int id)
        {
            var createUser = await _context.createUsers.FindAsync(id);
            if (createUser == null)
            {
                return NotFound();
            }
            _context.createUsers.Remove(createUser);
            await _context.SaveChangesAsync();
            return createUser;
        }
        private bool CreateUserExists(int id)
        {
            return _context.createUsers.Any(e => e.createuserId == id);
        }
    }
}