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
    public class BoardsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public BoardsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Boards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boards>>> GetBoards()
        {
            return await _context.Boards.ToListAsync();
        }

        // GET: api/Boards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boards>> GetBoards(short id)
        {
            var boards = await _context.Boards.FindAsync(id);

            if (boards == null)
            {
                return NotFound();
            }

            return boards;
        }

        // PUT: api/Boards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoards(short id, Boards boards)
        {
            if (id != boards.Id)
            {
                return BadRequest();
            }

            _context.Entry(boards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardsExists(id))
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

        // POST: api/Boards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Boards>> PostBoards(Boards boards)
        {
            _context.Boards.Add(boards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoards", new { id = boards.Id }, boards);
        }

        // DELETE: api/Boards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boards>> DeleteBoards(short id)
        {
            var boards = await _context.Boards.FindAsync(id);
            if (boards == null)
            {
                return NotFound();
            }

            _context.Boards.Remove(boards);
            await _context.SaveChangesAsync();

            return boards;
        }

        private bool BoardsExists(short id)
        {
            return _context.Boards.Any(e => e.Id == id);
        }
    }
}
