using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.DTO.Resident_DTO;
using REST_API_APARTMENT.Models;
using REST_API_APARTMENT.Validation;

namespace REST_API_APARTMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly HouseContext _context;
        private readonly IMapper _mapper;
        private readonly ResidentValidation validator;

        public ResidentsController(HouseContext context)
        {
            _context = context;
            _mapper = _mapper = MapperConfig.InitializeAutomapper();
            this.validator = new ResidentValidation();
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<List<Resident>>> GetResidents()
        {
            if (_context.Residents == null)
            {
                return NotFound();
            }
            var db = await _context.Residents.ToListAsync();
            var response = _mapper.Map<List<Resident>>(db);
            return response;
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
            if (_context.Residents == null)
            {
                return NotFound();
            }
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return resident;
        }

        // PUT: api/Residents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return BadRequest();
            }

            var residentDTO = _mapper.Map<ResidentDTO>(resident);
            var validationResult = validator.Validate(residentDTO);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }

            _context.Entry(resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Resident Nr {resident.Id} updated :)");
        }

        // POST: api/Residents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(Resident resident)
        {
            var residentDTO = _mapper.Map<ResidentDTO>(resident);
            var validationResult = validator.Validate(residentDTO);
            if (!validationResult.IsValid)
            {
                // Return validation errors
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
            return Ok("Resident created successfully :) ");
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            if (_context.Residents == null)
            {
                return NotFound();
            }
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentExists(int id)
        {
            return (_context.Residents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}