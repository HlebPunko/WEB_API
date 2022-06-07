using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;
using Modsen_Pr1.Services;
using System.Reflection;

namespace Modsen_Pr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInformationsController : ControllerBase
    {
        private readonly IEventInfoService _eventInfoService;
        private readonly IMapper _mapper;
        
        public EventInformationsController(IEventInfoService eventInfoService, IMapper mapper)
        {
            _eventInfoService = eventInfoService;
            _mapper = mapper;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EventInfoResponse>>> GetAll()
		{
			var response = await _eventInfoService.GetAllAsync();
			return response.Match<ActionResult<IEnumerable<EventInfoResponse>>>(
				success => Ok(_mapper.Map<IEnumerable<EventInfoResponse>>(success)),
				failure => BadRequest(failure));
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<EventInfoResponse>> Get(int id)
		{
			var result = await _eventInfoService.GetAsync(id);

			return result.Match<ActionResult<EventInfoResponse>>(
				success => Ok(_mapper.Map<EventInfoResponse>(success)),
				failure => BadRequest(failure));
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<EventInfoResponse>> Post([FromBody] EventInfoCreateRequest eventInfo)
		{
			var mapped = _mapper.Map<EventInformation>(eventInfo);
			var result = await _eventInfoService.AddAsync(mapped);

			return result.Match<ActionResult<EventInfoResponse>>(
				success => Ok(_mapper.Map<EventInfoResponse>(success)),
				failure => BadRequest(failure));
		}

		[HttpPut]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<EventInfoResponse>> Put(int id, [FromBody] EventInfoCreateRequest eventInfo)
		{
			var mapped = _mapper.Map<EventInformation>(eventInfo);
			var result = await _eventInfoService.UpdateAsync(id, mapped);

			return result.Match<ActionResult<EventInfoResponse>>(
				success => Ok(_mapper.Map<EventInfoResponse>(success)),
				failure => BadRequest(failure));
		}

		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<EventInfoResponse>> Delete(int id)
		{
			var result = await _eventInfoService.DeleteAsync(id);

			return result.Match<ActionResult<EventInfoResponse>>(
				success => Ok(_mapper.Map<EventInfoResponse>(success)),
				failure => BadRequest(failure));
		}

		
	}
}
