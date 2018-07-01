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
    public class GrelistsController : ControllerBase
    {
        private readonly gresimpleContext _context;

        public GrelistsController(gresimpleContext context)
        {
            _context = context;
        }

        // GET: api/Grelists
        [HttpGet]
        public IEnumerable<Grelists> GetGrelists()
        {
            return _context.Grelists;
        }

        // GET: api/Grelists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrelists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grelists = await _context.Grelists.FindAsync(id);

            if (grelists == null)
            {
                return NotFound();
            }

            return Ok(grelists);
        }

        // PUT: api/Grelists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrelists([FromRoute] int id, [FromBody] Grelists grelists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grelists.Id)
            {
                return BadRequest();
            }

            _context.Entry(grelists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrelistsExists(id))
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

        // POST: api/Grelists
        [HttpPost]
        public async Task<IActionResult> PostGrelists([FromBody] Grelists grelists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grelists.Add(grelists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrelists", new { id = grelists.Id }, grelists);
        }

        // DELETE: api/Grelists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrelists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grelists = await _context.Grelists.FindAsync(id);
            if (grelists == null)
            {
                return NotFound();
            }

            _context.Grelists.Remove(grelists);
            await _context.SaveChangesAsync();

            return Ok(grelists);
        }

        private bool GrelistsExists(int id)
        {
            return _context.Grelists.Any(e => e.Id == id);
        }
    }
}