using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.DTO.Appartment_DTO;
using REST_API_APARTMENT.Models;
using REST_API_APARTMENT.Validation;

namespace REST_API_APARTMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentsController : ControllerBase
    {
        private readonly HouseContext _context;
        private readonly IMapper _mapper;
        private readonly AppartmentValidation validator;

        public AppartmentsController(HouseContext context)
        {
            // Instance injection

            _context = context;
            _mapper = _mapper = MapperConfig.InitializeAutomapper();
            this.validator = new AppartmentValidation();
        }

        // GET: api/Appartments
        [HttpGet]
        public async Task<ActionResult<List<AppartmentDTO>>> GetAppartments()
        {
            if (_context.Appartments == null)
            {
                return NotFound();
            }

            var db = await _context.Appartments.ToListAsync();

            // Destination  // Source
            var response = _mapper.Map<List<AppartmentDTO>>(db);

            return response;
        }

        // GET: api/Appartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appartment>> GetAppartment(int id)
        {
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

            var appartmentDTO = _mapper.Map<AppartmentDTO>(appartment);
            var validationResult = validator.Validate(appartmentDTO);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }

            _context.Appartments.Update(appartment);
            await _context.SaveChangesAsync();

            return Ok($"Appartment Nr {appartment.Id}  updated :)");
        }

        // POST: api/Appartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appartment>> PostAppartment(Appartment appartment)
        {
            var appartmentDTO = _mapper.Map<AppartmentDTO>(appartment);

            var validationResult = validator.Validate(appartmentDTO);
            if (!validationResult.IsValid)
            {
                // Return validation errors
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }

            _context.Appartments.Add(appartment);
            await _context.SaveChangesAsync();

            return Ok("Appartment created successfully :) ");
        }

        // DELETE: api/Appartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppartment(int id)
        {
            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            //_context.Appartments.Remove(appartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}