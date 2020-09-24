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
    public class MovieController : ControllerBase
    {
        //Henter data fra DatabaseContext
        private readonly DatabaseContext _context;

        public MovieController(DatabaseContext context)
        {
            _context = context;
        }

        //GET: api/movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var test = _context.movies.ToList();
            return test;
                // await _context.movies.ToListAsync();
        }

        // GET: api/movie/moviename
        [HttpGet("moviename")]
        public async Task<ActionResult<Movie>> GetMovie()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var movie = await _context.movies.Where(c => c.movieName =="Titanic").ToListAsync();
            return Ok(movie);
        }

        // GET: api/movie/movietime
        [HttpGet("movietime")]
        public async Task<ActionResult<Movie>> GetMovieTime()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var movietime = await _context.movies.Where(c => c.movietime == 1.45).ToListAsync();
            return Ok(movietime);
        }

        // GET: api/movie/movielist
        //[HttpGet("movielist")]
        //public async Task<ActionResult<Movie>> GetList()
        //{
        //    //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
        //    var list = await _context.movies.Where(c => c.movieList > 49).ToListAsync();
        //    return Ok(list);
        //}

        //GET: api/movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }


        // PUT: api/movie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.movieID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/movie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.movieID }, movie);
        }

        // DELETE: api/movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
        private bool MovieExists(int id)
        {
            return _context.movies.Any(e => e.movieID == id);
        }

    }
}
