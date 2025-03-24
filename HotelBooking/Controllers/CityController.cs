using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CityController : ControllerBase
{
    private readonly ICityService cityService;

    public CityController(ICityService cityService)
    {
        this.cityService = cityService;     
    }

    /// <summary>
    /// Creates a new city.
    /// </summary>
    /// <param name="city">City data transfer object.</param>
    /// <returns>Returns an Ok result if successful.</returns>
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(CityDTO city)
    {
        await cityService.Create(city);
        return Ok("City created successfully.");
    }

    /// <summary>
    /// Retrieves a city by its ID.
    /// </summary>
    /// <param name="id">City ID.</param>
    /// <returns>Returns the city details or NotFound if not found.</returns>
    [HttpGet(nameof(GetById))]
    public async Task<IActionResult> GetById(int id)
    {
        var city = await cityService.GetById(id);
        if (city == null)
            return NotFound($"City with ID {id} not found.");

        return Ok(city);
    }

    /// <summary>
    /// Retrieves all cities.
    /// </summary>
    /// <returns>Returns a list of cities or NotFound if none exist.</returns>
    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
    {
        var cities = await cityService.GetAll();
        if (cities == null || !cities.Any())
            return NotFound("No cities found.");

        return Ok(cities);
    }

    /// <summary>
    /// Updates an existing city.
    /// </summary>
    /// <param name="id">City ID.</param>
    /// <param name="city">Updated city data.</param>
    /// <returns>Returns Ok if successful or NotFound if city does not exist.</returns>
    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update(int id, CityDTO city)
    {
        var existingCity = await cityService.GetById(id);
        if (existingCity == null)
            return NotFound($"City with ID {id} not found.");

        await cityService.Update(id, city);
        return Ok("City updated successfully.");
    }

    /// <summary>
    /// Deletes a city by its ID.
    /// </summary>
    /// <param name="id">City ID.</param>
    /// <returns>Returns Ok if successful or NotFound if city does not exist.</returns>
    [HttpDelete(nameof(DeleteById))]
    public async Task<IActionResult> DeleteById(int id)
    {
        var existingCity = await cityService.GetById(id);
        if (existingCity == null)
            return NotFound($"City with ID {id} not found.");

        await cityService.DeleteById(id);
        return Ok("City deleted successfully.");
    }
}
