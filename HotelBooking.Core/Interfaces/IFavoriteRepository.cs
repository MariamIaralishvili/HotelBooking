using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces;

public interface IFavoriteRepository
{
    Task CreateFavorite(Favorite favorite);
    Task UpdateFavorite(int id, Favorite favorite);
    Task<Favorite> GetFavoriteById(int id);
    Task<IEnumerable<Favorite>> GetAllFavorite();
    Task DeleteFavorite(int id);
}
