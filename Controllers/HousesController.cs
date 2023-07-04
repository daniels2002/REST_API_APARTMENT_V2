using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_APARTMENT.DTO.House_DTO;
using REST_API_APARTMENT.Models;
using REST_API_APARTMENT.Validation;

namespace REST_API_APARTMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly HouseContext _context;
        private readonly IMapper _mapper;
        private readonly HouseValidation validator;

        public HousesController(HouseContext context)
        {
            _context = context;
            _mapper = _mapper = MapperConfig.InitializeAutomapper();
            this.validator = new HouseValidation();
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<List<HouseDTO>>> GetHouses()
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var db = await _context.Houses.ToListAsync();
            var response = _mapper.Map<List<HouseDTO>>(db);
            return response;
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }
            return house;
        }

        // PUT: api/Houses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            var houseDTO = _mapper.Map<HouseDTO>(house);
            var validationResult = validator.Validate(houseDTO);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok($" House Nr {house.Id}  updated :)");
        }

        // POST: api/Houses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            var houseDTO = _mapper.Map<HouseDTO>(house);
            var validationresult = validator.Validate(houseDTO);
            if (!validationresult.IsValid)
            {
                // Return validation errors
                var errorMessages = validationresult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(string.Join(", ", errorMessages));
            }
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            return Ok("House created successfully");
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HouseExists(int id)
        {
            return (_context.Houses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}