using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modsen_Pr1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modsen_Pr1.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class UserController : ControllerBase
	{

		private readonly EventInfoContext _context;

		public UserController(EventInfoContext context)
		{
			_context = context;
			
		}

        [HttpGet]
		public async Task<ActionResult<string>> Get(string userName, string password)
		{
			var user = _context.Users.FirstOrDefault(u => u.Login == userName && u.Password == password);

			if (user == null) { return NotFound(); }

			var claims = new[]
			{
			new Claim( ClaimTypes.NameIdentifier , user.Login ),
		};

			var token = new JwtSecurityToken
			(
				issuer: "https://localhost:7207",
				audience: "https://localhost:7207",
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(30),
				notBefore: DateTime.UtcNow,
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(
							"111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111")),
					SecurityAlgorithms.HmacSha256)
			);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return Ok(tokenString);
		}
	}
}
