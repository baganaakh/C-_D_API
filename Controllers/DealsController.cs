using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminAPI2.Models;

namespace AdminAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public DealsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Deals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deals>>> GetDeals()
        {
            return await _context.Deals.ToListAsync();
        }

        // GET: api/Deals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deals>> GetDeals(long id)
        {
            var deals = await _context.Deals.FindAsync(id);

            if (deals == null)
            {
                return NotFound();
            }

            return deals;
        }

        // PUT: api/Deals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeals(long id, Deals deals)
        {
            if (id != deals.Id)
            {
                return BadRequest();
            }

            _context.Entry(deals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealsExists(id))
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

        // POST: api/Deals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Deals>> PostDeals(Deals deals)
        {
            _context.Deals.Add(deals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeals", new { id = deals.Id }, deals);
        }

        // DELETE: api/Deals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deals>> DeleteDeals(long id)
        {
            var deals = await _context.Deals.FindAsync(id);
            if (deals == null)
            {
                return NotFound();
            }

            _context.Deals.Remove(deals);
            await _context.SaveChangesAsync();

            return deals;
        }

        private bool DealsExists(long id)
        {
            return _context.Deals.Any(e => e.Id == id);
        }
    }
}
