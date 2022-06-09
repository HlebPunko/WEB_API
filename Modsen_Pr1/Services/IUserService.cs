using LanguageExt.Common;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Services
{
    public interface IUserService
    {
        Task <Result<IEnumerable<User>>> GetAllAsync ();
        Task<Result<User>> AddAsync(User user);
        Task<Result<User>> UpdateAsync(int id, User user);
        Task<Result<string>> LoginAsync(User user);
    }
}
