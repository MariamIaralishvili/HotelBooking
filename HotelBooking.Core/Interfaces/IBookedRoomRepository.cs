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
        Task<IEnumerable<BookedRoom>> GetReservedRoomData(DateTime startDate, DateTime endDate);
        Task<int> GetTotalNumberOfBookingForAClient(int clientId);
        Task<BookedRoom> GetLastReservationByClient(int clientId);
        Task<BookedRoom> GetLastReservationForRoom(int roomId);
    }
}
