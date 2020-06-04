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
    public class RefPricesController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public RefPricesController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RefPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefPrice>>> GetRefPrice()
        {
            return await _context.RefPrice.ToListAsync();
        }

        // GET: api/RefPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefPrice>> GetRefPrice(long id)
        {
            var refPrice = await _context.RefPrice.FindAsync(id);

            if (refPrice == null)
            {
                return NotFound();
            }

            return refPrice;
        }

        // PUT: api/RefPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefPrice(long id, RefPrice refPrice)
        {
            if (id != refPrice.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(refPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefPriceExists(id))
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

        // POST: api/RefPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RefPrice>> PostRefPrice(RefPrice refPrice)
        {
            _context.RefPrice.Add(refPrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RefPriceExists(refPrice.ContractId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRefPrice", new { id = refPrice.ContractId }, refPrice);
        }

        // DELETE: api/RefPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RefPrice>> DeleteRefPrice(long id)
        {
            var refPrice = await _context.RefPrice.FindAsync(id);
            if (refPrice == null)
            {
                return NotFound();
            }

            _context.RefPrice.Remove(refPrice);
            await _context.SaveChangesAsync();

            return refPrice;
        }

        private bool RefPriceExists(long id)
        {
            return _context.RefPrice.Any(e => e.ContractId == id);
        }
    }
}
