using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.gresimple.Model;

namespace gresimple.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreusersController : ControllerBase
    {
        private readonly gresimpleContext _context;

        public GreusersController(gresimpleContext context)
        {
            _context = context;
        }

        // GET: api/Greusers
        [HttpGet]
        public IEnumerable<Greusers> GetGreusers()
        {
            return _context.Greusers;
        }

        // GET: api/Greusers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGreusers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var greusers = await _context.Greusers.FindAsync(id);

            if (greusers == null)
            {
                return NotFound();
            }

            return Ok(greusers);
        }

        // PUT: api/Greusers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreusers([FromRoute] string id, [FromBody] Greusers greusers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greusers.Email)
            {
                return BadRequest();
            }

            _context.Entry(greusers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreusersExists(id))
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

        // POST: api/Greusers
        [HttpPost]
        public async Task<IActionResult> PostGreusers([FromBody] Greusers greusers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Greusers.Add(greusers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GreusersExists(greusers.Email))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGreusers", new { id = greusers.Email }, greusers);
        }

        // DELETE: api/Greusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGreusers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var greusers = await _context.Greusers.FindAsync(id);
            if (greusers == null)
            {
                return NotFound();
            }

            _context.Greusers.Remove(greusers);
            await _context.SaveChangesAsync();

            return Ok(greusers);
        }

        private bool GreusersExists(string id)
        {
            return _context.Greusers.Any(e => e.Email == id);
        }
    }
}