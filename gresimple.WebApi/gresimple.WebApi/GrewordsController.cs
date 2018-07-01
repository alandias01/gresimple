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
    public class GrewordsController : ControllerBase
    {
        private readonly gresimpleContext _context;

        public GrewordsController(gresimpleContext context)
        {
            _context = context;
        }

        // GET: api/Grewords
        [HttpGet]
        public IEnumerable<Grewords> GetGrewords()
        {
            return _context.Grewords;
        }

        // GET: api/Grewords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrewords([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grewords = await _context.Grewords.FindAsync(id);

            if (grewords == null)
            {
                return NotFound();
            }

            return Ok(grewords);
        }

        // PUT: api/Grewords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrewords([FromRoute] int id, [FromBody] Grewords grewords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grewords.Id)
            {
                return BadRequest();
            }

            _context.Entry(grewords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrewordsExists(id))
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

        // POST: api/Grewords
        [HttpPost]
        public async Task<IActionResult> PostGrewords([FromBody] Grewords grewords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grewords.Add(grewords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrewords", new { id = grewords.Id }, grewords);
        }

        // DELETE: api/Grewords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrewords([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grewords = await _context.Grewords.FindAsync(id);
            if (grewords == null)
            {
                return NotFound();
            }

            _context.Grewords.Remove(grewords);
            await _context.SaveChangesAsync();

            return Ok(grewords);
        }

        private bool GrewordsExists(int id)
        {
            return _context.Grewords.Any(e => e.Id == id);
        }
    }
}