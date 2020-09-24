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
    public class BillingController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BillingController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/billing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billings>>> GetBillings()
        {
            return await _context.billings.ToListAsync();
        }

        // GET: api/billing/cardnumber
        [HttpGet("cardNumber")]
        public async Task<ActionResult<Billings>> GetCard()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var card = await _context.billings.Where(c => c.cardNumber >= 1).ToListAsync();
            return Ok(card);
        }

        // GET: api/billing/cardname
        [HttpGet("cardName")]
        public async Task<ActionResult<Billings>> GetCardName()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var cardName = await _context.billings.Where(c => c.cardName == "Emil Boye").ToListAsync();
            return Ok(cardName);
        }

        // GET: api/billing/seat
        [HttpGet("seatChoice")]
        public async Task<ActionResult<Billings>> GetseatChoice()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var seatChoice = await _context.billings.Where(c => c.seatChoice > 49).ToListAsync();
            return Ok(seatChoice);
        }
        
        // GET: api/billing/moviename
        [HttpGet("movieName")]
        public async Task<ActionResult<Billings>> GetMovieName()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var moviename = await _context.billings.Where(c => c.movieName == "Abduction").ToListAsync();
            return Ok(moviename);
        }

        // GET: api/billing/date
        //[HttpGet("Date")]
        //public async Task<ActionResult<Billings>> GetDate()
        //{
        //    //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
        //    var date = await _context.billings.Where(c => c.Date == 2020-07-12).ToListAsync();
        //    return Ok(date);
        //}

        // GET: api/billing/time
        [HttpGet("time")]
        public async Task<ActionResult<Billings>> GetTime()
        {
            //Await = Midlertidig tråd, den venter på der kommer noget ned i databasen. card bliver returned fordi det er den der styre await lige der.
            var time = await _context.billings.Where(c => c.time == 10.00).ToListAsync();
            return Ok(time);
        }

        // GET: api/billing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Billings>> GetBilling(int id)
        {
            var billing = await _context.billings.FindAsync(id);

            if (billing == null)
            {
                return NotFound();
            }

            return billing;
        }

        // PUT: api/billing/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilling(int id, Billings billing)
        {
            if (id != billing.billingsId)
            {
                return BadRequest();
            }

            _context.Entry(billing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingExists(id))
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

        // POST: api/billing
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Billings>> PostBilling(Billings billing)
        {
            _context.billings.Add(billing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBilling", new { id = billing.billingsId }, billing);
        }

        // DELETE: api/billing/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Billings>> DeleteBilling(int id)
        {
            var billing = await _context.billings.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }

            _context.billings.Remove(billing);
            await _context.SaveChangesAsync();



            return billing;
        }

        private bool BillingExists(int id)
        {
            return _context.billings.Any(e => e.billingsId == id);
        }
    }
}
