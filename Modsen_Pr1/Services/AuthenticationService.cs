using System.Security.Claims ;
using Modsen_Pr1.Models ;
using Microsoft.AspNetCore.Authentication;

namespace Modsen_Pr1.Services ;

public class AuthenticationService : IAuthenticationService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public AuthenticationService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public User? CurrentUser => CreateUserFromClaims( _httpContextAccessor.HttpContext! ) ;

	private User? CreateUserFromClaims(HttpContext httpContext)
	{
		var claims      = httpContext.User.Claims.ToList();
		var idClaims    = claims.FirstOrDefault( c => c.Type == ClaimTypes.NameIdentifier ) ;
		var nameClaims  = claims.FirstOrDefault( c => c.Type == ClaimTypes.Name ) ;

		if ( idClaims is null || nameClaims is null)
			return null ;

		return new User { Id = int.Parse( idClaims.Value ) , Login = nameClaims.Value } ;
	}
}
