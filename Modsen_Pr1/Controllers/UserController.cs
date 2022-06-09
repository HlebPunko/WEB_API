using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;
using Modsen_Pr1.Services;

namespace Modsen_Pr1.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("allUsers")]
		[Authorize]
		public async Task<ActionResult<IEnumerable<User>>> GetAll()
		{
			var response = await _userService.GetAllAsync();
			return response.Match<ActionResult<IEnumerable<User>>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpPost]
		[Route("register")]
		public async Task<ActionResult<UserResponse>> Post([FromBody] UserCreateRequest user)
		{
			var mapped = _mapper.Map<User>(user);
			var result = await _userService.AddAsync(mapped);

			return result.Match<ActionResult<UserResponse>>(
				success => Ok(_mapper.Map<UserResponse>(success)),
				failure => BadRequest(failure));
		}

		[HttpPut]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<UserResponse>> Put(int id, [FromBody] UserCreateRequest user)
		{
			var mapped = _mapper.Map<User>(user);
			var result = await _userService.UpdateAsync(id, mapped);

			return result.Match<ActionResult<UserResponse>>(
				success => Ok(_mapper.Map<UserResponse>(success)),
				failure => BadRequest(failure));
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
		{
			var mapped = _mapper.Map<User>(authRequest);
			var result = await _userService.LoginAsync(mapped);
			
			return result.Match<ActionResult<AuthResponse>>(
				success => Ok(new AuthResponse { Token = success, Login = mapped.Login}),
				failure => BadRequest(failure));
		}
	}
}
