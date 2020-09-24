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
    public class GenreController : ControllerBase
    {
        //Henter data fra DatabaseContext
        private readonly DatabaseContext _context;

        public GenreController(DatabaseContext context)
        {
            _context = context;
        }

        //GET: api/genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.genres.ToListAsync();
        }

        // GET: api/genre/genrename
        [HttpGet("genreName")]
        public async Task<ActionResult<Genre>> GetGenreName()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var genre = await _context.genres.Where(c => c.genreName == "Thriller").ToListAsync();
            return Ok(genre);
        }

        // GET: api/genre/description
        [HttpGet("genreDec")]
        public async Task<ActionResult<Genre>> GetGenreDec()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var genre = await _context.genres.Where(c => c.genreDescription == "Gyser er drab på drab").ToListAsync();
            return Ok(genre);
        }

        //GET: api/genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }


        // PUT: api/genre/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/genre
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Genre>> PostMovie(Genre genre)
        {
            _context.genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/genre/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            var genre = await _context.genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.genres.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }
        private bool GenreExists(int id)
        {
            return _context.genres.Any(e => e.GenreId == id);
        }
    }
}
