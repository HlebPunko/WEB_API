using LanguageExt.Common;
using Microsoft.IdentityModel.Tokens;
using Modsen_Pr1.Models;
using Modsen_Pr1.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modsen_Pr1.Services
{
    public class UserService : IUserService
	{
        private readonly IUserRepository _repository;
		public static readonly string SecretKey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJOMZ4zY";
		public static readonly string Issuer = "https://localhost:7207";
		public static readonly string Audience = "https://localhost:7207";

		public UserService(IUserRepository repository)
        {
			_repository = repository;
        }

        public async Task<Result<string>> LoginAsync(User user)
		{
			var entity = await _repository.GetAsync(user.Login, user.Password);

			if (entity is null)
				return new Result<string>(new ArgumentException());

			var token = GenerateToken(entity);

			return new Result<string>(token);
		}

		private static string GenerateToken(User user)
		{
			var claims = new[]
			{
			new Claim( ClaimTypes.Name , user.Login ),
			new Claim( ClaimTypes.NameIdentifier , user.Id.ToString() ),
		};

			var token = new JwtSecurityToken
			(
				issuer: Issuer,
				audience: Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(30),
				notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
						SecretKey)),
                SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenString;
		}

		public async Task<Result<IEnumerable<User>>> GetAllAsync()
        {
			try
			{
				var res = await _repository.GetAllAsync();

				if (res is null) return  new Result<IEnumerable<User>>(new ArgumentException());

				return new Result<IEnumerable<User>>(res);
			}
			catch (Exception ex) { return new Result<IEnumerable<User>>(ex); }
			

        }

		public async Task<Result<User>> AddAsync(User entity)
		{
			try
			{
				var addedEntity = await _repository.AddAsync(entity);

				if (addedEntity is null) return new Result<User>(new ArgumentException());

				return new Result<User>(addedEntity);
			}
			catch (Exception ex) { return new Result<User>(ex); }
		}
		public async Task<Result<User>> GetAsync(int id)
		{
			try
			{
				var result = await _repository.GetAsync(id);

				if (result is null) return new Result<User>(new ArgumentException());

				return new Result<User>(result);
			}
			catch (Exception ex) { return new Result<User>(ex); }
		}

		public async Task<Result<User>> UpdateAsync(int id, User entity)
		{
			try 
			{
				var updatedEntity = await _repository.UpdateAsync(id, entity);
				

				if (updatedEntity is null) return new Result<User>(new ArgumentException());

				return new Result<User>(updatedEntity);
			}
			catch (Exception ex) { return new Result<User>(ex); }
		}
	}

}