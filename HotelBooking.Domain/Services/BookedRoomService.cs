using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Domain.Services;

public class BookedRoomService : IBookedRoomService
{
    private readonly IBookedRoomRepository bookedRoomsRepository;
    private readonly IRoomRepository roomRepository;
    private readonly IMapper mapper;

    public BookedRoomService(IBookedRoomRepository bookedRoomsRepository, IMapper mapper, IRoomRepository roomRepository)
    {
        this.bookedRoomsRepository = bookedRoomsRepository;
        this.mapper = mapper;
        this.roomRepository = roomRepository;
    }

    public async Task<IEnumerable<BookedRoomResponseDTO>> GetAllBookedRoom()
    {
        var result = await bookedRoomsRepository.GetAllBookedRoom();
        var map = mapper.Map<IEnumerable<BookedRoomResponseDTO>>(result);
        return map;
    }

    public async Task<BookedRoomResponseDTO> GetBookedRoomByClientId(int clientId)
    {
        var result = await bookedRoomsRepository.GetAllBookedRoom();
        var reservedByClientId = result.Where(x => x.UserId == clientId).FirstOrDefault();
        var map = mapper.Map<BookedRoomResponseDTO>(reservedByClientId);
        return map;
    }

    public async Task<BookedRoomResponseDTO> GetBookedRoomByRoomId(int roomId)
    {
        var result = await bookedRoomsRepository.GetAllBookedRoom();
        var reservedByRoomId = result.Where(x => x.RoomId == roomId).FirstOrDefault();
        var map = mapper.Map<BookedRoomResponseDTO>(reservedByRoomId);
        return map;
    }

    public async Task<bool> ReservedRoom(BookedRoomDTO booked)
    {
        var room = await roomRepository.GetRoomById(booked.RoomId);

        // 1. tu arsebobs otaxi da aris vargisi javshnistvis
        if (room == null || !room.IsAvialable)
            return false;

        // 2. aris tu ara dakavebuli am periodshi aqtiur javshnebs vamowmeb
        bool isBooked = await bookedRoomsRepository.IsRoomAvailable(booked.RoomId, booked.CheckIn, booked.CheckOut);
        if (isBooked)
            return false;

        // 3. fasis gamotvla
        var map = mapper.Map<BookedRoom>(booked);
        int daysBooked = (booked.CheckOut.Date - booked.CheckIn.Date).Days;
        map.TotalPrice = (daysBooked > 0 ? daysBooked : 1) * room.Price;
        map.IsActive = true;

        // 4. javshnis gantavseba
        await bookedRoomsRepository.CreateBookedRoom(map);

        return true;
    }

    /// <summary>
    /// javshnis gauqmeba
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="reserveId"></param>
    /// <returns></returns>
    public async Task<bool> CancelBookedRoom(int roomId, int reserveId)
    {
        var reserve = await bookedRoomsRepository.GetBookedRoomById(reserveId);
        if (reserve is null || !reserve.IsActive)
            return false;

        //  javshnis  gauqmeba anu isactive gavxadot false
        await bookedRoomsRepository.SoftDelete(reserve.Id);

        return true;
    }
}