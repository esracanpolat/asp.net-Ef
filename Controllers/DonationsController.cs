using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly DntionDbContext _context;

        public DonationsController(DntionDbContext context)
        {
            _context = context;
        }

        // GET: api/Donations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donations>>> Getdonations()
        {
            return await _context.donations.ToListAsync();
        }

        // GET: api/Donations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donations>> GetDonations(int id)
        {
            var donations = await _context.donations.FindAsync(id);

            if (donations == null)
            {
                return NotFound();
            }

            return donations;
        }

        // PUT: api/Donations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonations(int id, Donations donations)
        {
            donations.id = id;
       
            _context.Entry(donations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationsExists(id))
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

        // POST: api/Donations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donations>> PostDonations(Donations donations)
        {
            _context.donations.Add(donations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonations", new { id = donations.id }, donations);
        }

        // DELETE: api/Donations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donations>> DeleteDonations(int id)
        {
            var donations = await _context.donations.FindAsync(id);
            if (donations == null)
            {
                return NotFound();
            }

            _context.donations.Remove(donations);
            await _context.SaveChangesAsync();

            return donations;
        }

        private bool DonationsExists(int id)
        {
            return _context.donations.Any(e => e.id == id);
        }
    }
}
