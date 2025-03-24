using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces
{
    public interface IBookedRoomRepository
    {
        Task CreateBookedRoom(BookedRoom bookedRoom);
        Task DeleteBookedRoom(int id);
        Task UpdateBookedRoom(int id, BookedRoom bookedRoom);
        Task<BookedRoom> GetBookedRoomById(int id);
        Task<IEnumerable<BookedRoom>> GetAllBookedRoom();
        Task SoftDelete(int id);
        Task<bool> IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
    }
}
