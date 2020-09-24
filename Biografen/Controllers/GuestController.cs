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
    public class GuestController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GuestController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/guest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            return await _context.guests.ToListAsync();
        }

        // GET: api/guest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var guest = await _context.guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }
        // PUT: api/guest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(int id, Guest guest)
        {
            if (id != guest.guestId)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
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


        // POST: api/guest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(Guest guest)
        {
            _context.guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuest", new { id = guest.guestId }, guest);
        }

        // DELETE: api/guest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guest>> DeleteGuest(int id)
        {
            var guest = await _context.guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.guests.Remove(guest);
            await _context.SaveChangesAsync();

            return guest;
        }
        private bool GuestExists(int id)
        {
            return _context.guests.Any(e => e.guestId == id);
        }

    }
}