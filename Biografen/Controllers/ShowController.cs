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
    public class ShowController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ShowController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/show
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShow()
        {
            return await _context.shows.ToListAsync();
        }

        // GET: api/show/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var admin = await _context.shows.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/show/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.showId)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
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

        // POST: api/show
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.showId }, show);
        }

        // DELETE: api/show/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            var show = await _context.shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.shows.Remove(show);
            await _context.SaveChangesAsync();

            return show;
        }

        private bool ShowExists(int id)
        {
            return _context.shows.Any(e => e.showId == id);
        }
    }
}
