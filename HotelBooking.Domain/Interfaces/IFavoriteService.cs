using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces
{
    public interface IFavoriteService
    {
        Task CreateFavorite(FavoriteDTO favorite);       
        Task<FavoriteResponseDTO> GetFavoriteByClientId(int clientId);
        Task DeleteFavorite(int id);
    }
}
