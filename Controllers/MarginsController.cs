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
    public class MarginsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public MarginsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Margins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Margins>>> GetMargins()
        {
            return await _context.Margins.ToListAsync();
        }

        // GET: api/Margins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Margins>> GetMargins(long id)
        {
            var margins = await _context.Margins.FindAsync(id);

            if (margins == null)
            {
                return NotFound();
            }

            return margins;
        }

        // PUT: api/Margins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMargins(long id, Margins margins)
        {
            if (id != margins.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(margins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarginsExists(id))
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

        // POST: api/Margins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Margins>> PostMargins(Margins margins)
        {
            _context.Margins.Add(margins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMargins", new { id = margins.ContractId }, margins);
        }

        // DELETE: api/Margins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Margins>> DeleteMargins(long id)
        {
            var margins = await _context.Margins.FindAsync(id);
            if (margins == null)
            {
                return NotFound();
            }

            _context.Margins.Remove(margins);
            await _context.SaveChangesAsync();

            return margins;
        }

        private bool MarginsExists(long id)
        {
            return _context.Margins.Any(e => e.ContractId == id);
        }
    }
}
