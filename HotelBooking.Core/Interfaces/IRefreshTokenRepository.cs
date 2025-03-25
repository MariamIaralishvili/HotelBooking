using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces;

public interface IRefreshTokenRepository
{
    Task Create(RefreshToken token);
    Task Update(RefreshToken token);
    Task<RefreshToken> GetByToken(string token);
}
