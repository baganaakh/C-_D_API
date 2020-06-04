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
    public class ActiveSessionsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public ActiveSessionsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ActiveSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveSessions>>> GetActiveSessions()
        {
            return await _context.ActiveSessions.ToListAsync();
        }

        // GET: api/ActiveSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveSessions>> GetActiveSessions(int id)
        {
            var activeSessions = await _context.ActiveSessions.FindAsync(id);

            if (activeSessions == null)
            {
                return NotFound();
            }

            return activeSessions;
        }

        // PUT: api/ActiveSessions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveSessions(int id, ActiveSessions activeSessions)
        {
            if (id != activeSessions.Id)
            {
                return BadRequest();
            }

            _context.Entry(activeSessions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveSessionsExists(id))
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

        // POST: api/ActiveSessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActiveSessions>> PostActiveSessions(ActiveSessions activeSessions)
        {
            _context.ActiveSessions.Add(activeSessions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActiveSessions", new { id = activeSessions.Id }, activeSessions);
        }

        // DELETE: api/ActiveSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActiveSessions>> DeleteActiveSessions(int id)
        {
            var activeSessions = await _context.ActiveSessions.FindAsync(id);
            if (activeSessions == null)
            {
                return NotFound();
            }

            _context.ActiveSessions.Remove(activeSessions);
            await _context.SaveChangesAsync();

            return activeSessions;
        }

        private bool ActiveSessionsExists(int id)
        {
            return _context.ActiveSessions.Any(e => e.Id == id);
        }
    }
}
