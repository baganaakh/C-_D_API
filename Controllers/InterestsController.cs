﻿using System;
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
    public class InterestsController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public InterestsController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Interests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interests>>> GetInterests()
        {
            return await _context.Interests.ToListAsync();
        }

        // GET: api/Interests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interests>> GetInterests(int id)
        {
            var interests = await _context.Interests.FindAsync(id);

            if (interests == null)
            {
                return NotFound();
            }

            return interests;
        }

        // PUT: api/Interests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterests(int id, Interests interests)
        {
            if (id != interests.Id)
            {
                return BadRequest();
            }

            _context.Entry(interests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestsExists(id))
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

        // POST: api/Interests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interests>> PostInterests(Interests interests)
        {
            _context.Interests.Add(interests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterests", new { id = interests.Id }, interests);
        }

        // DELETE: api/Interests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interests>> DeleteInterests(int id)
        {
            var interests = await _context.Interests.FindAsync(id);
            if (interests == null)
            {
                return NotFound();
            }

            _context.Interests.Remove(interests);
            await _context.SaveChangesAsync();

            return interests;
        }

        private bool InterestsExists(int id)
        {
            return _context.Interests.Any(e => e.Id == id);
        }
    }
}
