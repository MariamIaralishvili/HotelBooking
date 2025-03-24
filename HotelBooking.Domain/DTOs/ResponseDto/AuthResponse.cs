namespace HotelBooking.Domain.DTOs.ResponseDto;

public class AuthResponse
{
    public string AuthToken { get; set; } //tokenis informacia, deshifraciis mere info shegvidzlia amovighot
    public string RefreshToken { get; set; }
}
