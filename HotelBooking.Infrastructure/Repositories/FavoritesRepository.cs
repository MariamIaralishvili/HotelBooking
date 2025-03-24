using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;

namespace HotelBooking.Infrastructure.Repositories;

public class FavoritesRepository : IFavoriteRepository
{
    private readonly HotelBookingContext context;

    public FavoritesRepository(HotelBookingContext context)
    {
        this.context = context;
    }

    public async Task CreateFavorite(Favorite favorite)
    {
        context.Favorites.Add(favorite);
        await context.SaveChangesAsync();
    }

    public async Task DeleteFavorite(int id)
    {
        var fav = context.Favorites.ToList().Where(x => x.Id == id).FirstOrDefault();
        if (fav == null) throw new ArgumentException();
        context.Favorites.Remove(fav);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Favorite>> GetAllFavorite()
    {
        return context.Favorites.ToList();
    }

    public async Task<Favorite> GetFavoriteById(int id)
    {
        var favoriteRoom = context.Favorites.ToList().Where(x => x.Id == id).FirstOrDefault();
        return favoriteRoom;
    }

    public async Task UpdateFavorite(int id, Favorite favorite)
    {
        var fav = context.Favorites.ToList().Where(x => x.Id == id).FirstOrDefault();
        fav.Rooms = favorite.Rooms;
        await context.SaveChangesAsync();
    }
}
