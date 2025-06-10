using ContactSystem.Application.Interfaces;
using ContactSystem.Domain.Entities;


namespace ContactSystem.Infrastructure.Persistance.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRoleRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> InsertUserRoleAsync(UserRole userRole)
    {
        await _appDbContext.UserRoles.AddAsync(userRole);
        await _appDbContext.SaveChangesAsync();
        return userRole.UserRoleId;
    }

    public async Task UpdateUserRoleAsync(UserRole userRole)
    {
        _appDbContext.UserRoles.Update(userRole);
        await _appDbContext.SaveChangesAsync();
    }
}
