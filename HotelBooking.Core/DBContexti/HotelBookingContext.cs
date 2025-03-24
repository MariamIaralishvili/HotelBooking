using HotelBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Core.DBContexti
{
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> ops) : base(ops) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<BookedRoom> BookedRooms { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
