using AutoMapper;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;

namespace HotelBooking.Domain.Mapper;

public class Mapperi: Profile
{
    public Mapperi()
    {
        CreateMap<BookedRoomDTO, BookedRoom>().ReverseMap();
        CreateMap<CityDTO, City>().ReverseMap();
        CreateMap<FavoriteDTO, Favorite>().ReverseMap();
        CreateMap<HotelDTO, Hotel>().ReverseMap();
        CreateMap<RoomDTO, Room>().ReverseMap();
        CreateMap<RoomTypeDTO, RoomType>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();


        CreateMap<BookedRoomResponseDTO, BookedRoom>().ReverseMap();
        CreateMap<CityResponseDTO, City>().ReverseMap();
        CreateMap<FavoriteResponseDTO, Favorite>().ReverseMap();
        CreateMap<HotelResponseDTO, Hotel>().ReverseMap();
        CreateMap<RoomResponseDTO, Room>().ReverseMap();
        CreateMap<RoomTypeResponseDTO, RoomType>().ReverseMap();
        CreateMap<UserResponseDTO, User>().ReverseMap();
    }
}
