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
    public class SecuritiesController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public SecuritiesController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Securities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Securities>>> GetSecurities()
        {
            return await _context.Securities.ToListAsync();
        }

        // GET: api/Securities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Securities>> GetSecurities(int id)
        {
            var securities = await _context.Securities.FindAsync(id);

            if (securities == null)
            {
                return NotFound();
            }

            return securities;
        }

        // PUT: api/Securities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecurities(int id, Securities securities)
        {
            if (id != securities.Id)
            {
                return BadRequest();
            }

            _context.Entry(securities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecuritiesExists(id))
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

        // POST: api/Securities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Securities>> PostSecurities(Securities securities)
        {
            _context.Securities.Add(securities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecurities", new { id = securities.Id }, securities);
        }

        // DELETE: api/Securities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Securities>> DeleteSecurities(int id)
        {
            var securities = await _context.Securities.FindAsync(id);
            if (securities == null)
            {
                return NotFound();
            }

            _context.Securities.Remove(securities);
            await _context.SaveChangesAsync();

            return securities;
        }

        private bool SecuritiesExists(int id)
        {
            return _context.Securities.Any(e => e.Id == id);
        }
    }
}
