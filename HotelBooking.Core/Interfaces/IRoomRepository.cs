using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces
{
    public interface IRoomRepository
    {
        Task CreateRoom(Room room);
        Task UpdateRoom(int id, Room room);
        Task<Room> GetRoomById(int id);
        Task<IEnumerable<Room>> GetAllRoom();
        Task DeleteRoom(int id);
        Task UpdateAvaliable(int roomId, bool isAvaliable);
        Task<IEnumerable<Room>> GetAllRoomsFreeForReserve(DateTime startDate, DateTime endDate);
    }
}
