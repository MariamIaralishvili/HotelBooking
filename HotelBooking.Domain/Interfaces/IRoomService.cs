using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomService
    {
        Task CreateRoom(RoomDTO room);
        Task UpdateRoom(int id, RoomDTO room);
        Task<RoomResponseDTO> GetRoomById(int id);
        Task<IEnumerable<RoomResponseDTO>> GetAllRoom();
        Task DeleteRoom(int id);
        Task<RoomResponseDTO> GetByHotelId(int hotelId);
        Task UpdateAvailable(int roomId, bool isAvailable);
    }
}
