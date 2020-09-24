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
    public class StaffController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StaffController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.staffs.ToListAsync();
        }

        // GET: api/staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/staff/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.staffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/staff
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Staff>> PostAdministrator(Staff staff)
        {
            _context.staffs.Add(staff);
           await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.staffId }, staff);
        }

        // DELETE: api/staff/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> DeleteStaff(int id)
        {
            var staff = await _context.staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        private bool StaffExists(int id)
        {
            return _context.staffs.Any(e => e.staffId == id);
        }
    }
}
