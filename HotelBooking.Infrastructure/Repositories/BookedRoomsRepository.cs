using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class BookedRoomsRepository : IBookedRoomRepository
    {
        private readonly HotelBookingContext context;

        public BookedRoomsRepository(HotelBookingContext context)
        {
            this.context = context;
        }

        public async Task CreateBookedRoom(BookedRoom bookedRoom)
        {
            context.BookedRooms.Add(bookedRoom);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookedRoom(int id)
        {
            var room = context.BookedRooms.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (room == null) throw new ArgumentException();
            context.BookedRooms.Remove(room);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookedRoom>> GetAllBookedRoom()
        {
            return context.BookedRooms.ToList();
        }

        public async Task<BookedRoom> GetBookedRoomById(int id)
        {
            var bookedRoom = context.BookedRooms.ToList().Where(x => x.Id == id).FirstOrDefault();
            return bookedRoom;
        }

        /// <summary>
        /// statusis shecvla, roca davacenseleb javshans
        /// </summary>
        /// <param name="reserveId"></param>
        /// <returns></returns>
        public async Task SoftDelete(int reserveId)
        {
            var bookedRoom = context.BookedRooms.ToList().Where(reserve => reserve.Id == reserveId).FirstOrDefault();
            if(bookedRoom is not null)
            {
                bookedRoom.IsActive = false;
            }
            await context.SaveChangesAsync();      
        }

        public async Task UpdateBookedRoom(int id, BookedRoom room)
        {
            var bookedRoom = context.BookedRooms.ToList().Where(x => x.Id == id).FirstOrDefault();
            bookedRoom.CheckOut = room.CheckOut;
            bookedRoom.CheckIn = room.CheckIn;
            bookedRoom.RoomId = room.Id;
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            return !await context.BookedRooms.AnyAsync(b => b.RoomId == roomId && b.IsActive &&  //aqtiuri javshnevs vamowmebt
                ((checkIn >= b.CheckIn && checkIn < b.CheckOut) ||
                 (checkOut > b.CheckIn && checkOut <= b.CheckOut) ||
                 (checkIn <= b.CheckIn && checkOut >= b.CheckOut)));
        }
    }
}
