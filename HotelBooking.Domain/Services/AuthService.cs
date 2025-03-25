using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace HotelBooking.Domain.Services;

public class AuthService:IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IMapper mapper, IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<bool> SignOut(int userId)
    {
       var user=await  _userRepository.GetUserById(userId);
        if(user is not null)
        {
            foreach (var item in user.RefreshTokens)
            {
                if (!item.IsInvoked)
                {
                    item.IsInvoked = true;
                    await _refreshTokenRepository.Update(item);
                }
            }
            return true;
        }
        return false;
    }

    public async Task<AuthResponse> RefreshToken(string refreshToken)
    {
        var res=await _refreshTokenRepository.GetByToken(refreshToken);
        if(res is not null)
        {
            res.IsInvoked = true;
            await _refreshTokenRepository.Update(res);

            var user=await _userRepository.GetUserById(res.UserId);

            return new AuthResponse
            {
                AuthToken = GenerateAuthToken(user),
                RefreshToken = GenerateRefreshToken(),
            };
        }
        throw new ArgumentNullException("Refresh token is not valid, try sign in ");
    }

    public async Task<AuthResponse> Login(LoginRequest req)
    {
        var user = await _userRepository
            .FindAsync(i => i.Email == req.Email);
        if (user is not null)
        {
            if (!VerifyPassword(req.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Password is not correct");
            }

            var refresh = GenerateRefreshToken();

            await _refreshTokenRepository.Create(new RefreshToken
            {
                IsInvoked = false,
                UserId = user.Id,
                RefreshTokenValue = refresh
            });

            return new AuthResponse
            {
                AuthToken = GenerateAuthToken(user),
                RefreshToken = refresh,
            };
        }
        throw new UnauthorizedAccessException("No such a user exist");
    }

    public async Task<AuthResponse> Register(UserDTO user)
    {
        var result = await _userRepository.FindAsync(i => i.Email == user.Email);

        if (result is not null)
        {
            throw new ArgumentException("User already exist");
        }
        user.Password=HashPassword(user.Password);
        var newUser = await _userRepository.CreateUser(_mapper.Map<User>(user));

        var token = GenerateAuthToken(result ?? _mapper.Map<User>(user));
        var refreshToken = GenerateRefreshToken();
        await _refreshTokenRepository.Create(new RefreshToken
        {
            IsInvoked = false,
            UserId = newUser,
            RefreshTokenValue = refreshToken
        });

        return new AuthResponse
        {
            AuthToken = token,
            RefreshToken = refreshToken,
        };
    }

    #region Helper methods
    private string GenerateAuthToken(User user)
    {
        var claims = new List<Claim>() //tokenshi iqneba dashifruli eseni
        {
            new Claim("Name",user.FirstName),
            new Claim("Surname",user.LastName),
            new Claim("Email",user.Email),
            new Claim("sub",user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kHBajhuwuqdjkdfjdfjdfhjdhdf")); //tokenis gaxsnistvis sachiro
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //am algoritmit shifravs
        var token = new JwtSecurityToken(
            issuer: "Www.BookingHotel.com", //saitis misamarti
            audience: "Www.BookingHotel.com", //saitis misamarti 
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30), //tokeni iqneba 30 wuti validuri
            signingCredentials: credentials
        );
        var jwtString = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtString;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        return Convert.ToBase64String(randomNumber);
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        string hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return hashedPassword;
    }

    private bool VerifyPassword(string enteredPassword, string storedHash)
    {
        using var sha256 = SHA256.Create();
        string computedHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword)));
        return computedHash == storedHash;
    }
    #endregion
}
