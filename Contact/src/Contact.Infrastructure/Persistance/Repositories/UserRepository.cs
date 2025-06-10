using ContactSystem.Application.Interfaces;
using ContactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSystem.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository

{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task DeleteUserAsync(long userId)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.UserId == userId);
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<long> InsertUserAsync(User user)
    {
       
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<ICollection<User>> SelectAllUsersAsync(int skip, int take)
    {
        return await _appDbContext.Users
               .Skip(skip)
               .Take(take)
               .ToListAsync();
    }

    public async Task<User> SelectUserByIdAsync(long id)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        if (user == null)
        {
            throw new KeyNotFoundException($"user with id {id}  is not found");
        }
        return user;
    }

    public async Task<User?> SelectUserByUserNameAsync(string userName)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        return user;

    }

    public async Task UpdateUserRoleAsync(long userId, UserRole userRole)
    {
        var user = await SelectUserByIdAsync(userId);
        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
    }
}
