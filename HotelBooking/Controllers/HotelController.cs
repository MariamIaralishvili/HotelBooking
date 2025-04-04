using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HotelController : ControllerBase
{
    private readonly IHotelService hotelService;

    public HotelController(IHotelService hotelService)
    {
        this.hotelService = hotelService;
    }

    /// <summary>
    /// Creates a new hotel.
    /// </summary>
    /// <param name="hotel">Hotel data transfer object.</param>
    /// <returns>Returns an Ok result if successful.</returns>
    [HttpPost(nameof(CreateHotel))]
    public async Task<IActionResult> CreateHotel(HotelDTO hotel)
    {
        await hotelService.CreateHotel(hotel);
        return Ok("Hotel created successfully.");
    }

    /// <summary>
    /// Retrieves a hotel by its ID.
    /// </summary>
    /// <param name="id">Hotel ID.</param>
    /// <returns>Returns the hotel details or NotFound if not found.</returns>
    [HttpGet(nameof(GetHotelById))]
    public async Task<IActionResult> GetHotelById(int id)
    {
        var hotel = await hotelService.GetHotelById(id);
        if (hotel == null)
            return NotFound($"Hotel with ID {id} not found.");

        return Ok(hotel);
    }

    /// <summary>
    /// Retrieves all hotels.
    /// </summary>
    /// <returns>Returns a list of hotels or NotFound if none exist.</returns>
    [HttpGet(nameof(GetAllHotel))]
    public async Task<IActionResult> GetAllHotel()
    {
        var hotels = await hotelService.GetAllHotel();
        if (hotels == null || !hotels.Any())
            return NotFound("No hotels found.");

        return Ok(hotels);
    }

    /// <summary>
    /// Updates an existing hotel.
    /// </summary>
    /// <param name="id">Hotel ID.</param>
    /// <param name="hotel">Updated hotel data.</param>
    /// <returns>Returns Ok if successful or NotFound if the hotel does not exist.</returns>
    [HttpPut(nameof(UpdateHotel))]
    public async Task<IActionResult> UpdateHotel(int id, HotelDTO hotel)
    {
        var existingHotel = await hotelService.GetHotelById(id);
        if (existingHotel == null)
            return NotFound($"Hotel with ID {id} not found.");

        await hotelService.UpdateHotel(id, hotel);
        return Ok("Hotel updated successfully.");
    }

    /// <summary>
    /// Deletes a hotel by its ID.
    /// </summary>
    /// <param name="id">Hotel ID.</param>
    /// <returns>Returns Ok if successful or NotFound if the hotel does not exist.</returns>
    [HttpDelete(nameof(DeleteHotel))]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var existingHotel = await hotelService.GetHotelById(id);
        if (existingHotel == null)
            return NotFound($"Hotel with ID {id} not found.");

        await hotelService.DeleteHotel(id);
        return Ok("Hotel deleted successfully.");
    }

    /// <summary>
    /// Retrieves a hotel by city ID.
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetHotelByCityId))]
    public async Task<IActionResult> GetHotelByCityId(int cityId)
    {
        var hotel = await hotelService.GetHotelByCityId(cityId);
        if (hotel == null)
            return NotFound($"Hotel with ID {cityId} not found.");

        return Ok(hotel);
    }
}
