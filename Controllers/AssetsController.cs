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
    public class AssetsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public AssetsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assets>>> GetAssets()
        {
            return await _context.Assets.ToListAsync();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assets>> GetAssets(int id)
        {
            var assets = await _context.Assets.FindAsync(id);

            if (assets == null)
            {
                return NotFound();
            }

            return assets;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssets(int id, Assets assets)
        {
            if (id != assets.Id)
            {
                return BadRequest();
            }

            _context.Entry(assets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsExists(id))
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

        // POST: api/Assets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Assets>> PostAssets(Assets assets)
        {
            _context.Assets.Add(assets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssets", new { id = assets.Id }, assets);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assets>> DeleteAssets(int id)
        {
            var assets = await _context.Assets.FindAsync(id);
            if (assets == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(assets);
            await _context.SaveChangesAsync();

            return assets;
        }

        private bool AssetsExists(int id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
    }
}
