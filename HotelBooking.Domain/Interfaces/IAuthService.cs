using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Register(UserDTO user);
    Task<AuthResponse> Login(LoginRequest req);
    Task<AuthResponse> RefreshToken(string refreshToken);
    Task<bool> SignOut(int userId);
}
