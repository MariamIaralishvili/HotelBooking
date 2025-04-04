using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookedRoomController : ControllerBase
{
    private readonly IBookedRoomService bookedRoomService;

    public BookedRoomController(IBookedRoomService bookedRoomService)
    {
        this.bookedRoomService = bookedRoomService;
    }

    /// <summary>
    /// Gets all booked rooms.
    /// </summary>
    /// <returns>List of booked rooms.</returns>
    [HttpGet(nameof(GetAllBookedRoom))]
    public async Task<IActionResult> GetAllBookedRoom()
    {
        var result = await bookedRoomService.GetAllBookedRoom();
        if (result == null)
            return NotFound("No booked rooms found.");

        return Ok(result);
    }

    /// <summary>
    /// Gets a booked room by client ID.
    /// </summary>
    /// <param name="clientId">Client ID.</param>
    /// <returns>Booked room details.</returns>
    [HttpGet(nameof(GetBookedRoomByClientId))]
    public async Task<IActionResult> GetBookedRoomByClientId(int clientId)
    {
        if (clientId <= 0)
            return BadRequest("Invalid client ID.");

        var result = await bookedRoomService.GetBookedRoomByClientId(clientId);
        if (result == null)
            return NotFound($"No booked room found for client ID {clientId}.");

        return Ok(result);
    }

    /// <summary>
    /// Gets a booked room by room ID.
    /// </summary>
    /// <param name="roomId">Room ID.</param>
    /// <returns>Booked room details.</returns>
    [HttpGet(nameof(GetBookedRoomByRoomId))]
    public async Task<IActionResult> GetBookedRoomByRoomId(int roomId)
    {
        if (roomId <= 0)
            return BadRequest("Invalid room ID.");

        var result = await bookedRoomService.GetBookedRoomByRoomId(roomId);
        if (result == null)
            return NotFound($"No booked room found for room ID {roomId}.");

        return Ok(result);
    }

    /// <summary>
    /// Reserves a room.
    /// </summary>
    /// <param name="booked">Booking details.</param>
    /// <returns>Success or failure of the booking.</returns>
    [HttpPost(nameof(ReservedRoom))]
    public async Task<IActionResult> ReservedRoom([FromBody] BookedRoomDTO booked)
    {
        if (booked == null || booked.RoomId <= 0)
            return BadRequest("Invalid booking details.");

        var success = await bookedRoomService.ReservedRoom(booked);
        if (!success)
            return BadRequest("Room reservation failed. It may already be booked.");

        return Ok("Room successfully reserved.");
    }

    /// <summary>
    /// Cancels a booked room.
    /// </summary>
    /// <param name="roomId">Room ID.</param>
    /// <param name="reserveId">Reservation ID.</param>
    /// <returns>Success or failure message.</returns>
    [HttpPost(nameof(CancelBookedRoom))]
    public async Task<IActionResult> CancelBookedRoom(int roomId, int reserveId)
    {
        if (roomId <= 0 || reserveId <= 0)
            return BadRequest("Invalid room ID or reservation ID.");

        var success = await bookedRoomService.CancelBookedRoom(roomId, reserveId);
        if (!success)
            return NotFound($"No reservation found with ID {reserveId}.");

        return Ok("Reservation successfully canceled.");
    }

    /// <summary>
    /// Get Reserved Rooms Data.
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetReservedRoomData))]
    public async Task<IActionResult> GetReservedRoomData(DateTime startDate, DateTime endDate)
    {
        var result = await bookedRoomService.GetReservedRoomData(startDate, endDate);
        if (result == null)
            return NotFound("No booked rooms found.");

        return Ok(result);
    }

    /// <summary>
    /// Get Total Number Of Booking For A Client.
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetTotalNumberOfBookingForAClient))]
    public async Task<IActionResult> GetTotalNumberOfBookingForAClient(int clientId)
    {
        var result = await bookedRoomService.GetTotalNumberOfBookingForAClient(clientId);
        if (result <= 0)
            return NotFound("No Number Of Booking found.");

        return Ok(result);
    }

    /// <summary>
    /// Get Last Reservation By Client.
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetLastReservationByClient))]
    public async Task<IActionResult> GetLastReservationByClient(int clientId)
    {
        var result = await bookedRoomService.GetLastReservationByClient(clientId);
        if (result == null)
            return NotFound("No Reserve found.");

        return Ok(result);
    }

    /// <summary>
    /// Get Last Reservation For Room.
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetLastReservationForRoom))]
    public async Task<IActionResult> GetLastReservationForRoom(int roomId)
    {
        var result = await bookedRoomService.GetLastReservationForRoom(roomId);
        if (result == null)
            return NotFound("No Reserve found.");

        return Ok(result);
    }
}
