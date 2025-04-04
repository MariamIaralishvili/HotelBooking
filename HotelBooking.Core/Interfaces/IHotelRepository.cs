using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces
{
    public interface IHotelRepository
    {
        Task CreateHotel(Hotel hotel);
        Task UpdateHotel(int id, Hotel hotel);
        Task<Hotel> GetHotelById(int id);
        Task<IEnumerable<Hotel>> GetAllHotel();
        Task DeleteHotel(int id);
        Task<IEnumerable<Hotel>> GetHotelByCityId(int cityId);
    }
}
