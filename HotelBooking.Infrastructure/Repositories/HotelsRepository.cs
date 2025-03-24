using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;

namespace HotelBooking.Infrastructure.Repositories
{
    public class HotelsRepository : IHotelRepository
    {
        private readonly HotelBookingContext context;

        public HotelsRepository(HotelBookingContext context)
        {
            this.context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            context.Hotels.Add(hotel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = context.Hotels.ToList().Where(h => h.Id == id).FirstOrDefault();
            if (hotel == null) throw new ArgumentException();
            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllHotel()
        {
            return context.Hotels.ToList();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var hotel = context.Hotels.ToList().Where(io => io.Id == id).FirstOrDefault();
            return hotel;
        }

        public async Task UpdateHotel(int id, Hotel hotel)
        {
            var hot = context.Hotels.ToList().Where(io => io.Id == id).FirstOrDefault();
            hot.Name = hotel.Name;
            await context.SaveChangesAsync();
        }
    }
}
