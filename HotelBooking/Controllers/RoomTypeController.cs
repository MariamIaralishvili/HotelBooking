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
public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService roomTypeService;

    public RoomTypeController(IRoomTypeService roomTypeService)
    {
        this.roomTypeService = roomTypeService;
    }

    [HttpPost(nameof(CreateRoomType))]
    public async Task CreateRoomType(RoomTypeDTO roomType)
    {
        await roomTypeService.CreateRoomType(roomType);
    }

    [HttpGet(nameof(GetRoomTypeById))]
    public async Task<RoomTypeResponseDTO> GetRoomTypeById(int id)
    {
        return await roomTypeService.GetRoomTypeById(id);
    }

    [HttpGet(nameof(GetAllRoomType))]
    public async Task<IEnumerable<RoomTypeResponseDTO>> GetAllRoomType()
    {
        return await roomTypeService.GetAllRoomType();
    }

    [HttpPut(nameof(UpdateRoomType))]
    public async Task UpdateRoomType(int id, RoomTypeDTO roomType)
    {
        await roomTypeService.UpdateRoomType(id, roomType);
    }

    [HttpDelete(nameof(DeleteRoomType))]
    public async Task DeleteRoomType(int id)
    {
        await roomTypeService.DeleteRoomType(id);
    }
}
