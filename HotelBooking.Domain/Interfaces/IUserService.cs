using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDTO user);
        Task UpdateUser(int id, UserDTO user);
        Task<UserResponseDTO> GetUserById(int id);
        Task<IEnumerable<UserResponseDTO>> GetAllUser();
        Task DeleteUser(int id);
    }
}
