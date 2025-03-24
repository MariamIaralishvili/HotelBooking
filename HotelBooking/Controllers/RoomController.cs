using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RoomController : ControllerBase
{
    private readonly IRoomService roomService;

    public RoomController(IRoomService roomService)
    {
        this.roomService = roomService;
    }

    [HttpPost(nameof(CreateRoom))]
    public async Task CreateRoom(RoomDTO room)
    {
        await roomService.CreateRoom(room);
    }

    [HttpGet(nameof(GetRoomById))]
    public async Task<RoomResponseDTO> GetRoomById(int id)
    {
        return await roomService.GetRoomById(id);
    }

    [HttpGet(nameof(GetByHotelId))]
    public async Task<RoomResponseDTO> GetByHotelId(int hotelId)
    {
        return await roomService.GetByHotelId(hotelId);
    }

    [HttpGet(nameof(GetAllRoom))]
    public async Task<IEnumerable<RoomResponseDTO>> GetAllRoom()
    {
        return await roomService.GetAllRoom();
    }

    [HttpPut(nameof(UpdateRoom))]
    public async Task UpdateRoom(int id, RoomDTO room)
    {
        await roomService.UpdateRoom(id, room);
    }

    [HttpDelete(nameof(DeleteRoom))]
    public async Task DeleteRoom(int id)
    {
        await roomService.DeleteRoom(id);
    }
}
