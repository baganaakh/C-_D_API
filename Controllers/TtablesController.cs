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
    public class TtablesController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public TtablesController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Ttables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ttable>>> GetTtable()
        {
            return await _context.Ttable.ToListAsync();
        }

        // GET: api/Ttables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ttable>> GetTtable(long id)
        {
            var ttable = await _context.Ttable.FindAsync(id);

            if (ttable == null)
            {
                return NotFound();
            }

            return ttable;
        }

        // PUT: api/Ttables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtable(long id, Ttable ttable)
        {
            if (id != ttable.Id)
            {
                return BadRequest();
            }

            _context.Entry(ttable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtableExists(id))
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

        // POST: api/Ttables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ttable>> PostTtable(Ttable ttable)
        {
            _context.Ttable.Add(ttable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTtable", new { id = ttable.Id }, ttable);
        }

        // DELETE: api/Ttables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ttable>> DeleteTtable(long id)
        {
            var ttable = await _context.Ttable.FindAsync(id);
            if (ttable == null)
            {
                return NotFound();
            }

            _context.Ttable.Remove(ttable);
            await _context.SaveChangesAsync();

            return ttable;
        }

        private bool TtableExists(long id)
        {
            return _context.Ttable.Any(e => e.Id == id);
        }
    }
}
