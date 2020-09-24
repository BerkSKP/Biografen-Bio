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
    public class CinemaHallController : ControllerBase
    {
        //henter data fra DatabaseContext 
        private readonly DatabaseContext _context;
        public CinemaHallController(DatabaseContext context)
        {
            _context = context;
        }
        //GET: Api/cinemahall
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaHall>>> GetCinemaHalls()
        {
            return await _context.cinemaHalls.ToListAsync();
        }

        // GET: api/cinema/movie
        [HttpGet("moviename")]
        public async Task<ActionResult<CinemaHall>> GetMovieName()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var mName = await _context.cinemaHalls.Where(c => c.movieName == "Titanic").ToListAsync();
            return Ok(mName);
        }

        //Get: api/cinemahall/5
        [HttpGet("{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaHall>> GetCinemaHalls(int id)
        {
            var cinemaHall = await _context.cinemaHalls.FindAsync(id);
            if (cinemaHall == null)
            {
                return NotFound();
            }
            return cinemaHall;
        }
        // PUT: api/cinemahall/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinemaHall(int id, CinemaHall cinema)
        {
            if (id != cinema.cinemahallId)
            {
                return BadRequest();
            }
            _context.Entry(cinema).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaHallExists(id))
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

        // POST: api/cinemahall
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CinemaHall>> PostCinemaHall(CinemaHall cinemaHall)
        {
            _context.cinemaHalls.Add(cinemaHall);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCinemaHall", new { id = cinemaHall.cinemahallId }, cinemaHall);
        }
        // DELETE: api/cinemahall/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CinemaHall>> DeleteCinemaHall(int id)
        {
            var cinemahall = await _context.cinemaHalls.FindAsync(id);
            if (cinemahall == null)
            {
                return NotFound();
            }
            _context.cinemaHalls.Remove(cinemahall);
            await _context.SaveChangesAsync();
            return cinemahall;
        }
        private bool CinemaHallExists(int id)
        {
            return _context.cinemaHalls.Any(e => e.cinemahallId == id);
        }
    }
}