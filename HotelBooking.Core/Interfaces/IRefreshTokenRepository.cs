using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces;

public interface IRefreshTokenRepository
{
    Task Create(RefreshToken city);
    Task Update(RefreshToken city);
    Task<RefreshToken> GetByToken(string token);
}
