using ContactSystem.Domain.Entities;

namespace ContactSystem.Application.Interfaces;

public interface IUserRoleRepository
{
    Task<long> InsertUserRoleAsync(UserRole userRole);
    Task UpdateUserRoleAsync(UserRole userRole);
}
