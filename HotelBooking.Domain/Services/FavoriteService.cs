using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.Domain.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository favoritesRepositori;
    private readonly IMapper mapper;

    public FavoriteService(IFavoriteRepository favoritesRepositori, IMapper mapper)
    {
        this.favoritesRepositori = favoritesRepositori;
        this.mapper = mapper;
    }

    public async Task CreateFavorite(FavoriteDTO favorite)
    {
        if (favorite == null)
        {
            throw new ArgumentNullException("Favorites Is Empty.");
        }
        var map = mapper.Map<Favorite>(favorite);
        await favoritesRepositori.CreateFavorite(map);
    }

    public async Task DeleteFavorite(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id Less Than 0.");
        }
        await favoritesRepositori.DeleteFavorite(id);
    } 

    public async Task<FavoriteResponseDTO> GetFavoriteByClientId(int clientId)
    {
        var result = await favoritesRepositori.GetAllFavorite();
        var getFavorite = result.Where(x => x.UserId == clientId);
        var map = mapper.Map<FavoriteResponseDTO>(getFavorite);
        return map;
    }
}
