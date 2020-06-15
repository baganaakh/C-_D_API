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
    public class MarketMakersController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public MarketMakersController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MarketMakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketMakers>>> GetMarketMakers()
        {
            return await _context.MarketMakers.ToListAsync();
        }

        // GET: api/MarketMakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketMakers>> GetMarketMakers(int id)
        {
            var marketMakers = await _context.MarketMakers.FindAsync(id);

            if (marketMakers == null)
            {
                return NotFound();
            }

            return marketMakers;
        }

        // PUT: api/MarketMakers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketMakers(int id, MarketMakers marketMakers)
        {
            if (id != marketMakers.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketMakers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketMakersExists(id))
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

        // POST: api/MarketMakers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketMakers>> PostMarketMakers(MarketMakers marketMakers)
        {
            _context.MarketMakers.Add(marketMakers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketMakers", new { id = marketMakers.Id }, marketMakers);
        }

        // DELETE: api/MarketMakers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketMakers>> DeleteMarketMakers(int id)
        {
            var marketMakers = await _context.MarketMakers.FindAsync(id);
            if (marketMakers == null)
            {
                return NotFound();
            }

            _context.MarketMakers.Remove(marketMakers);
            await _context.SaveChangesAsync();

            return marketMakers;
        }

        private bool MarketMakersExists(int id)
        {
            return _context.MarketMakers.Any(e => e.Id == id);
        }
    }
}
