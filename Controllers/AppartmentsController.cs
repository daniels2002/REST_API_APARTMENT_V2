using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentsController : ControllerBase
    {
        private readonly HouseContext _context;

        public AppartmentsController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/Appartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appartment>>> GetAppartments()
        {
          if (_context.Appartments == null)
          {
              return NotFound();
          }
            return await _context.Appartments.ToListAsync();
        }

        // GET: api/Appartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appartment>> GetAppartment(int id)
        {
          if (_context.Appartments == null)
          {
              return NotFound();
          }
            var appartment = await _context.Appartments.FindAsync(id);

            if (appartment == null)
            {
                return NotFound();
            }

            return appartment;
        }

        // PUT: api/Appartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppartment(int id, Appartment appartment)
        {
            if (id != appartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppartmentExists(id))
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

        // POST: api/Appartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appartment>> PostAppartment(Appartment appartment)
        {
          if (_context.Appartments == null)
          {
              return Problem("Entity set 'HouseContext.Appartments'  is null.");
          }
            _context.Appartments.Add(appartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppartment", new { id = appartment.Id }, appartment);
        }

        // DELETE: api/Appartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppartment(int id)
        {
            if (_context.Appartments == null)
            {
                return NotFound();
            }
            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            _context.Appartments.Remove(appartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppartmentExists(int id)
        {
            return (_context.Appartments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
