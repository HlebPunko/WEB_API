using LanguageExt.Common;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Services
{
    public interface IUserService
    {
        Task<Result<User>> AddAsync(User user);
        Task<Result<User>> UpdateAsync(int id, User user);
        Task<Result<User>> DeleteAsync(int id);
        Task<Result<string>> LoginAsync(User user);
    }
}
