using Modsen_Pr1.Models;

namespace Modsen_Pr1.Services;

public interface IAuthenticationService
{
	User? CurrentUser { get ; }
}
