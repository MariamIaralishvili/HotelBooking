using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces
{
    public interface IHotelService
    {
        Task CreateHotel(HotelDTO hotel);
        Task UpdateHotel(int id, HotelDTO hotel);
        Task<HotelResponseDTO> GetHotelById(int id);
        Task<IEnumerable<HotelResponseDTO>> GetAllHotel();
        Task DeleteHotel(int id);
    }
}
