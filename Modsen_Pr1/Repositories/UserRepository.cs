using Modsen_Pr1.Models;
using Microsoft.EntityFrameworkCore ;
using Modsen_Pr1.Repositories.Interfaces;

namespace Modsen_Pr1.Repositories ;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;
	public UserRepository(AppContext context)
	{
        _context = context;
	}

    public async Task<User?> GetAsync(int id)
        => await _context.Users.FirstOrDefaultAsync(x => id == x.Id);

    public async Task<List<User>> GetAllAsync() =>
        await _context.Users.Select(x => x).ToListAsync();

    public async Task<User?> AddAsync(User user)
    {
        var entity = (await _context.Users.AddAsync(user)).Entity;
        var resSave = await _context.SaveChangesAsync() > 0;

        if (!resSave) return null;

        return entity;
    }

    public async Task<User?> UpdateAsync(int id, User user)
    {
        var old = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (old is null) return null;
        
        old.Login = user.Login;
        old.Password = user.Password;

        _context.Entry(old).State = EntityState.Modified;

        var resSave = await _context.SaveChangesAsync() > 0;

        if (!resSave) return null;

        return old;
    }

    public Task<User?> GetAsync(string userName, string password) =>
        _context.Users.FirstOrDefaultAsync(x => x.Login == userName && x.Password == password);
    
}
