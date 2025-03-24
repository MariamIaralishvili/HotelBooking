using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    /// <summary>
    /// Creates a new room type.
    /// </summary>
    /// <param name="roomType">Room type data transfer object.</param>
    /// <returns>Returns an Ok result if successful.</returns>
    [HttpPost(nameof(CreateRoomType))]
    public async Task<IActionResult> CreateRoomType(RoomTypeDTO roomType)
    {
        await roomTypeService.CreateRoomType(roomType);
        return Ok("Room type created successfully.");
    }

    /// <summary>
    /// Retrieves a room type by its ID.
    /// </summary>
    /// <param name="id">Room type ID.</param>
    /// <returns>Returns the room type details or NotFound if not found.</returns>
    [HttpGet(nameof(GetRoomTypeById))]
    public async Task<IActionResult> GetRoomTypeById(int id)
    {
        var roomType = await roomTypeService.GetRoomTypeById(id);
        if (roomType == null)
            return NotFound($"Room type with ID {id} not found.");

        return Ok(roomType);
    }

    /// <summary>
    /// Retrieves all room types.
    /// </summary>
    /// <returns>Returns a list of room types or NotFound if none exist.</returns>
    [HttpGet(nameof(GetAllRoomType))]
    public async Task<IActionResult> GetAllRoomType()
    {
        var roomTypes = await roomTypeService.GetAllRoomType();
        if (roomTypes == null || !roomTypes.Any())
            return NotFound("No room types found.");

        return Ok(roomTypes);
    }

    /// <summary>
    /// Updates an existing room type.
    /// </summary>
    /// <param name="id">Room type ID.</param>
    /// <param name="roomType">Updated room type data.</param>
    /// <returns>Returns Ok if successful or NotFound if the room type does not exist.</returns>
    [HttpPut(nameof(UpdateRoomType))]
    public async Task<IActionResult> UpdateRoomType(int id, RoomTypeDTO roomType)
    {
        var existingRoomType = await roomTypeService.GetRoomTypeById(id);
        if (existingRoomType == null)
            return NotFound($"Room type with ID {id} not found.");

        await roomTypeService.UpdateRoomType(id, roomType);
        return Ok("Room type updated successfully.");
    }

    /// <summary>
    /// Deletes a room type by its ID.
    /// </summary>
    /// <param name="id">Room type ID.</param>
    /// <returns>Returns Ok if successful or NotFound if the room type does not exist.</returns>
    [HttpDelete(nameof(DeleteRoomType))]
    public async Task<IActionResult> DeleteRoomType(int id)
    {
        var existingRoomType = await roomTypeService.GetRoomTypeById(id);
        if (existingRoomType == null)
            return NotFound($"Room type with ID {id} not found.");

        await roomTypeService.DeleteRoomType(id);
        return Ok("Room type deleted successfully.");
    }
}
