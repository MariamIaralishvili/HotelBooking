using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;

namespace HotelBooking.Infrastructure.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly HotelBookingContext context;

    public RoomTypeRepository(HotelBookingContext context)
    {
        this.context = context;
    }


    public async Task CreateRoomType(RoomType roomType)
    {
        context.RoomType.Add(roomType);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRoomType(int id)
    {
        var roomType = context.RoomType.ToList().Where(r => r.Id == id).FirstOrDefault();
        if (roomType == null) throw new ArgumentException();
        context.RoomType.Remove(roomType);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoomType>> GetAllRoomType()
    {
        return context.RoomType.ToList();
    }

    public async Task<RoomType> GetRoomTypeById(int id)
    {
        var roomType = context.RoomType.ToList().Where(io => io.Id == id).FirstOrDefault();
        return roomType;
    }

    public async Task UpdateRoomType(int id, RoomType roomType)
    {
        var type = context.RoomType.ToList().Where(io => io.Id == id).FirstOrDefault();
        roomType.Name = type.Name;
        await context.SaveChangesAsync();
    }
}
