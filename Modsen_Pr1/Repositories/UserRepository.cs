using Modsen_Pr1.Models;
using Microsoft.EntityFrameworkCore ;
using Modsen_Pr1.Repositories.Interfaces;

namespace Modsen_Pr1.Repositories ;

public class UserRepository : IUserRepository
{
    private readonly EventInfoContext _context;
	public UserRepository(EventInfoContext context)
	{
        _context = context;
	}

    public async Task<User?> GetAsync(int id)
        => await _context.Users.FirstOrDefaultAsync(x => id == x.Id);

    public async Task<User?> AddAsync(User user)
    {
        var entity = (await _context.Users.AddAsync(user)).Entity;
        var resSave = await _context.SaveChangesAsync() > 0;

        if (!resSave) return null;

        return entity;
    }
    
    public async Task<User?> DeleteAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id); ;

        if (user is null) return null;
        _context.Remove(user);
        var resSave = await _context.SaveChangesAsync() > 0;

        if (!resSave) return null;

        return user;
    }

    public async Task<User?> UpdateAsync(int id, User user)
    {
        var old = await _context.Users.FirstOrDefaultAsync(u => u.Id == id); ;

        if (old is null) return null;
        _context.Update(user);
        var resSave = await _context.SaveChangesAsync() > 0;

        if (!resSave) return null;

        return user;
    }

    public Task<User?> GetAsync(string userName, string password) =>
        _context.Users.FirstOrDefaultAsync(x => x.Login == userName && x.Password == password);
    
}
