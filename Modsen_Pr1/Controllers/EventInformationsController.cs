using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInformationsController : ControllerBase
    {
        private readonly EventInfoContext _context;
        private readonly IMapper _mapper;
        
        public EventInformationsController(EventInfoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/EventInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventInfoResponse>>> GetEventInformations()
        {

            if (_context.EventInformations == null)
            {
                return NotFound();
            }
            var events = await _context.EventInformations.ToListAsync();
            var response = _mapper.Map<IEnumerable<EventInfoResponse>>(events);
            return Ok(response);
        }

        // GET: api/EventInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventInformation>> GetEventInformation(int id)
        {
            if (_context.EventInformations == null)
            {
                return NotFound();
            }
            var eventInformation = await _context.EventInformations.FindAsync(id);

            if (eventInformation == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<EventInfoResponse>(eventInformation);
            return Ok(response);
        }

        // PUT: api/EventInformations/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEventInformation(int id, EventInfoCreateRequest eventInformation)
        {
            var model = _mapper.Map<EventInformation>(eventInformation);

            model.Id = id;

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventInformationExists(id))
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

        // POST: api/EventInformations
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EventInfoResponse>> PostEventInformation(EventInfoCreateRequest eventInformation)
        {
            if (_context.EventInformations == null)
            {
                return Problem("Entity set 'EventInfoContext.EventInformations'  is null.");
            }
            var model = _mapper.Map<EventInformation>(eventInformation);

            _context.EventInformations.Add(model);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<EventInfoResponse>(model);

            return CreatedAtAction("GetEventInformation", new { id = response.Id }, response);
        }

        // DELETE: api/EventInformations/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEventInformation(int id)
        {
            if (_context.EventInformations == null)
            {
                return NotFound();
            }
            var eventInformation = await _context.EventInformations.FindAsync(id);
            if (eventInformation == null)
            {
                return NotFound();
            }

            _context.EventInformations.Remove(eventInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventInformationExists(int id)
        {
            return (_context.EventInformations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
