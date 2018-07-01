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
    public class GrelistviewsController : ControllerBase
    {
        private readonly gresimpleContext _context;

        public GrelistviewsController(gresimpleContext context)
        {
            _context = context;
        }

        // GET: api/Grelistviews
        [HttpGet]
        public IEnumerable<Grelistview> GetGrelistview()
        {
            return _context.Grelistview;
        }

        // GET: api/Grelistviews/frankenstein
        [HttpGet("{ListName}")]
        public  IActionResult GetGrelistview([FromRoute] string ListName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var grelistview = await _context.Grelistview.FindAsync(word);
            var grelistview =  _context.Grelistview.Where(x=>x.ListName == ListName);

            if (grelistview == null)
            {
                return NotFound();
            }

            return Ok(grelistview);
        }

        // GET: api/Grelistviews/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGrelistview([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var grelistview = await _context.Grelistview.FindAsync(id);

        //    if (grelistview == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(grelistview);
        //}

        // PUT: api/Grelistviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrelistview([FromRoute] int id, [FromBody] Grelistview grelistview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grelistview.Id)
            {
                return BadRequest();
            }

            _context.Entry(grelistview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrelistviewExists(id))
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

        // POST: api/Grelistviews
        [HttpPost]
        public async Task<IActionResult> PostGrelistview([FromBody] Grelistview grelistview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grelistview.Add(grelistview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrelistview", new { id = grelistview.Id }, grelistview);
        }

        // DELETE: api/Grelistviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrelistview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grelistview = await _context.Grelistview.FindAsync(id);
            if (grelistview == null)
            {
                return NotFound();
            }

            _context.Grelistview.Remove(grelistview);
            await _context.SaveChangesAsync();

            return Ok(grelistview);
        }

        private bool GrelistviewExists(int id)
        {
            return _context.Grelistview.Any(e => e.Id == id);
        }
    }
}