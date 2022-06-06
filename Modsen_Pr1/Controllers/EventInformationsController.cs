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
		public async Task<ActionResult<IEnumerable<EventInformation>>> GetAll()
		{
			var response = await _eventInfoService.GetAllAsync();
			return response.Match<ActionResult<IEnumerable<EventInformation>>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<EventInformation>> Get(int id)
		{
			var result = await _eventInfoService.GetAsync(id);

			return result.Match<ActionResult<EventInformation>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<EventInformation>> Post([FromBody] EventInformation eventInfo)
		{
			var result = await _eventInfoService.AddAsync(eventInfo);

			return result.Match<ActionResult<EventInformation>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpPut]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<EventInformation>> Put(int id, [FromBody] EventInformation eventInfo)
		{
			var result = await _eventInfoService.UpdateAsync(id, eventInfo);

			return result.Match<ActionResult<EventInformation>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<EventInformation>> Delete(int id)
		{
			var result = await _eventInfoService.DeleteAsync(id);

			return result.Match<ActionResult<EventInformation>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		
	}
}
