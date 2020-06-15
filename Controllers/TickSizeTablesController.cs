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
    public class TickSizeTablesController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public TickSizeTablesController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TickSizeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TickSizeTable>>> GetTickSizeTable()
        {
            return await _context.TickSizeTable.ToListAsync();
        }

        // GET: api/TickSizeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TickSizeTable>> GetTickSizeTable(int id)
        {
            var tickSizeTable = await _context.TickSizeTable.FindAsync(id);

            if (tickSizeTable == null)
            {
                return NotFound();
            }

            return tickSizeTable;
        }

        // PUT: api/TickSizeTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickSizeTable(int id, TickSizeTable tickSizeTable)
        {
            if (id != tickSizeTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(tickSizeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TickSizeTableExists(id))
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

        // POST: api/TickSizeTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TickSizeTable>> PostTickSizeTable(TickSizeTable tickSizeTable)
        {
            _context.TickSizeTable.Add(tickSizeTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickSizeTable", new { id = tickSizeTable.Id }, tickSizeTable);
        }

        // DELETE: api/TickSizeTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TickSizeTable>> DeleteTickSizeTable(int id)
        {
            var tickSizeTable = await _context.TickSizeTable.FindAsync(id);
            if (tickSizeTable == null)
            {
                return NotFound();
            }

            _context.TickSizeTable.Remove(tickSizeTable);
            await _context.SaveChangesAsync();

            return tickSizeTable;
        }

        private bool TickSizeTableExists(int id)
        {
            return _context.TickSizeTable.Any(e => e.Id == id);
        }
    }
}
