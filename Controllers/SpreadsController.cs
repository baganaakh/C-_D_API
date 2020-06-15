using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminAPI2.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpreadsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public SpreadsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Spreads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spreads>>> GetSpreads()
        {
            return await _context.Spreads.ToListAsync();
        }

        // GET: api/Spreads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spreads>> GetSpreads(int id)
        {
            var spreads = await _context.Spreads.FindAsync(id);

            if (spreads == null)
            {
                return NotFound();
            }

            return spreads;
        }

        // PUT: api/Spreads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpreads(int id, Spreads spreads)
        {
            if (id != spreads.Id)
            {
                return BadRequest();
            }

            _context.Entry(spreads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpreadsExists(id))
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

        // POST: api/Spreads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Spreads>> PostSpreads(Spreads spreads)
        {
            _context.Spreads.Add(spreads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpreads", new { id = spreads.Id }, spreads);
        }

        // DELETE: api/Spreads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spreads>> DeleteSpreads(int id)
        {
            var spreads = await _context.Spreads.FindAsync(id);
            if (spreads == null)
            {
                return NotFound();
            }

            _context.Spreads.Remove(spreads);
            await _context.SaveChangesAsync();

            return spreads;
        }

        private bool SpreadsExists(int id)
        {
            return _context.Spreads.Any(e => e.Id == id);
        }
    }
}
