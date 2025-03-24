using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    /// <summary>
    /// Creates a new room.
    /// </summary>
    /// <param name="room">Room data transfer object.</param>
    /// <returns>Returns an Ok result if successful.</returns>
    [HttpPost(nameof(CreateRoom))]
    public async Task<IActionResult> CreateRoom(RoomDTO room)
    {
        await roomService.CreateRoom(room);
        return Ok("Room created successfully.");
    }

    /// <summary>
    /// Retrieves a room by its ID.
    /// </summary>
    /// <param name="id">Room ID.</param>
    /// <returns>Returns the room details or NotFound if not found.</returns>
    [HttpGet(nameof(GetRoomById))]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await roomService.GetRoomById(id);
        if (room == null)
            return NotFound($"Room with ID {id} not found.");

        return Ok(room);
    }

    /// <summary>
    /// Retrieves rooms by hotel ID.
    /// </summary>
    /// <param name="hotelId">Hotel ID.</param>
    /// <returns>Returns the list of rooms for the hotel or NotFound if none exist.</returns>
    [HttpGet(nameof(GetByHotelId))]
    public async Task<IActionResult> GetByHotelId(int hotelId)
    {
        var rooms = await roomService.GetByHotelId(hotelId);
        if (rooms == null)
            return NotFound($"No rooms found for hotel with ID {hotelId}.");

        return Ok(rooms);
    }

    /// <summary>
    /// Retrieves all rooms.
    /// </summary>
    /// <returns>Returns a list of rooms or NotFound if none exist.</returns>
    [HttpGet(nameof(GetAllRoom))]
    public async Task<IActionResult> GetAllRoom()
    {
        var rooms = await roomService.GetAllRoom();
        if (rooms == null || !rooms.Any())
            return NotFound("No rooms found.");

        return Ok(rooms);
    }

    /// <summary>
    /// Updates an existing room.
    /// </summary>
    /// <param name="id">Room ID.</param>
    /// <param name="room">Updated room data.</param>
    /// <returns>Returns Ok if successful or NotFound if the room does not exist.</returns>
    [HttpPut(nameof(UpdateRoom))]
    public async Task<IActionResult> UpdateRoom(int id, RoomDTO room)
    {
        var existingRoom = await roomService.GetRoomById(id);
        if (existingRoom == null)
            return NotFound($"Room with ID {id} not found.");

        await roomService.UpdateRoom(id, room);
        return Ok("Room updated successfully.");
    }

    /// <summary>
    /// Deletes a room by its ID.
    /// </summary>
    /// <param name="id">Room ID.</param>
    /// <returns>Returns Ok if successful or NotFound if the room does not exist.</returns>
    [HttpDelete(nameof(DeleteRoom))]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var existingRoom = await roomService.GetRoomById(id);
        if (existingRoom == null)
            return NotFound($"Room with ID {id} not found.");

        await roomService.DeleteRoom(id);
        return Ok("Room deleted successfully.");
    }
}
