using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        this.favoriteService = favoriteService;
    }

    /// <summary>
    /// Adds a room to the client's favorites.
    /// </summary>
    /// <param name="favorite">Favorite room details.</param>
    /// <returns>Success or failure message.</returns>
    [HttpPost(nameof(CreateFavorite))]
    public async Task<IActionResult> CreateFavorite([FromBody] FavoriteDTO favorite)
    {
        if (favorite == null || favorite.UserId <= 0 || favorite.RoomId <= 0)
            return BadRequest("Invalid favorite details.");

        await favoriteService.CreateFavorite(favorite);
        return Ok("Room successfully added to favorites.");
    }

    /// <summary>
    /// Retrieves the favorite rooms of a client.
    /// </summary>
    /// <param name="clientId">Client ID.</param>
    /// <returns>List of favorite rooms.</returns>
    [HttpGet(nameof(GetFavoriteByClientId))]
    public async Task<IActionResult> GetFavoriteByClientId(int clientId)
    {
        if (clientId <= 0)
            return BadRequest("Invalid client ID.");

        var result = await favoriteService.GetFavoriteByClientId(clientId);
        if (result == null)
            return NotFound($"No favorites found for client ID {clientId}.");

        return Ok(result);
    }

    /// <summary>
    /// Removes a room from the client's favorites.
    /// </summary>
    /// <param name="id">Favorite entry ID.</param>
    /// <returns>Success or failure message.</returns>
    [HttpDelete(nameof(DeleteFavorite))]
    public async Task<IActionResult> DeleteFavorite(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid favorite ID.");

        var exists = await favoriteService.GetFavoriteByClientId(id);
        if (exists == null)
            return NotFound($"Favorite entry with ID {id} not found.");

        await favoriteService.DeleteFavorite(id);
        return Ok("Favorite successfully removed.");
    }
}
