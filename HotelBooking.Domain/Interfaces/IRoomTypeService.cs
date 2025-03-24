using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomTypeService
    {
        Task CreateRoomType(RoomTypeDTO roomType);
        Task UpdateRoomType(int id, RoomTypeDTO roomType);
        Task<RoomTypeResponseDTO> GetRoomTypeById(int id);
        Task<IEnumerable<RoomTypeResponseDTO>> GetAllRoomType();
        Task DeleteRoomType(int id);
    }
}
