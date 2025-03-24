using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly HotelBookingContext _context;

    public RefreshTokenRepository(HotelBookingContext _context)
    {
        this._context = _context;
    }

    public async Task Create(RefreshToken token)
    {
        await _context.RefreshTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken> GetByToken(string token)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(io => io.RefreshTokenValue == token && io.IsInvoked == false);
    }

    public async Task Update(RefreshToken city)
    {
        _context.RefreshTokens.Update(city);
        await _context.SaveChangesAsync();
    }
}
