using Modsen_Pr1.Models ;

namespace Modsen_Pr1.Repositories.Interfaces ;

public interface IUserRepository 
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetAsync(int id);
    Task<User?> GetAsync(string userName, string password);
    Task<User?> AddAsync(User user);
    Task<User?> UpdateAsync(int id, User user);
}
