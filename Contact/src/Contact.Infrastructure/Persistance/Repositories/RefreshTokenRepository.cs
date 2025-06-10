using ContactSystem.Application.Interfaces;
using ContactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UserContacts.Core.Errors;

namespace ContactSystem.Infrastructure.Persistance.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext _appDbContext;

    public RefreshTokenRepository(AppDbContext myDbContext)
    {
        _appDbContext = myDbContext;
    }
    public async Task InsertRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _appDbContext.RefreshTokens.AddAsync(refreshToken);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveRefreshTokenAsync(string token)
    {
        var rToken = await _appDbContext.RefreshTokens
           .FirstOrDefaultAsync(rt => rt.Token == token);
        if (rToken == null)
        {
            throw new KeyNotFoundException($"Refresh token {token} not found.");
        }
        _appDbContext.RefreshTokens.Remove(rToken);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId)
    {
        var token = await _appDbContext.RefreshTokens
           .FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId);
        if (token == null)
        {
            throw new KeyNotFoundException($"Refresh token {refreshToken} for user ID {userId} not found.");
        }
        return token;
    }

    public async Task UpdateRefreshTokenAsync(RefreshToken refreshToken)
    {
        var existingToken = await _appDbContext.RefreshTokens
           .FirstOrDefaultAsync(t => t.Token == refreshToken.Token && t.UserId == refreshToken.UserId);
        if (existingToken == null)
        {
            throw new EntityNotFoundException($"Refresh token {refreshToken.Token} not found for user {refreshToken.UserId}");
        }
        existingToken.IsRevoked = refreshToken.IsRevoked;

        existingToken.ExpirationDate = refreshToken.ExpirationDate;

        _appDbContext.RefreshTokens.Update(existingToken);
        await _appDbContext.SaveChangesAsync();
    }
}
