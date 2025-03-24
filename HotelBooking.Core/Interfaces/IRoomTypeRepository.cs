using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task CreateRoomType(RoomType roomType);
        Task UpdateRoomType(int id, RoomType roomType);
        Task<RoomType> GetRoomTypeById(int id);
        Task<IEnumerable<RoomType>> GetAllRoomType();
        Task DeleteRoomType(int id);
    }
}
