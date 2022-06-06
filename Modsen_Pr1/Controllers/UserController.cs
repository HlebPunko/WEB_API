using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modsen_Pr1.Models;
using Modsen_Pr1.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modsen_Pr1.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("register")]

		public async Task<ActionResult<User>> Post([FromBody] User user)
		{
			var result = await _userService.AddAsync(user);

			return result.Match<ActionResult<User>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
		{
			var result = await _userService.UpdateAsync(id, user);

			return result.Match<ActionResult<User>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult<User>> Delete(int id)
		{
			var result = await _userService.DeleteAsync(id);

			return result.Match<ActionResult<User>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<string>> Login(User user)
		{
			var result = await _userService.LoginAsync(user);

			return result.Match<ActionResult<string>>(
				success => Ok(success),
				failure => BadRequest(failure));
		}

	}
}
