using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class RoomsRepository : IRoomRepository
    {
        private readonly HotelBookingContext context;

        public RoomsRepository(HotelBookingContext context)
        {
            this.context = context;
        }

        public async Task CreateRoom(Room room)
        {
            context.Rooms.Add(room);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = context.Rooms.ToList().Where(io => io.Id == id).FirstOrDefault();
            if (room == null) throw new ArgumentException();
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return context.Rooms.ToList();
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = context.Rooms.ToList().Where(io => io.Id == id).FirstOrDefault();
            return room;
        }

        public async Task UpdateRoom(int id, Room room)
        {
            var rooms = context.Rooms.ToList().Where(io => io.Id == id).FirstOrDefault();
            room.RoomNumber = rooms.RoomNumber; //????????????????????
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// javshnisas da dacenselebisas otaxis statusis cvlileba
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="isAvaliable"></param>
        /// <returns></returns>
        public async Task UpdateAvaliable(int roomId, bool isAvaliable)
        {
            var room = context.Rooms.Where(io => io.Id == roomId).FirstOrDefault();
            if (room is not null)
            {
                room.IsAvialable = isAvaliable;
            }
            await context.SaveChangesAsync();
        }
    }
}
