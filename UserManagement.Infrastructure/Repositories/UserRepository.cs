using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.Include(u => u.UserRoles)
                                   .ThenInclude(ur => ur.Role)
                                   .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.Include(u => u.UserRoles)
                                   .ThenInclude(ur => ur.Role)
                                   .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
