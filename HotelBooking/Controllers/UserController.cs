using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IAuthService authService;

    public UserController(IUserService userService, IAuthService authService)
    {
        this.userService = userService;
        this.authService = authService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="user">User data transfer object.</param>
    /// <returns>Returns a success response or BadRequest if registration fails.</returns>
    [AllowAnonymous] //avtorizaciis moxsna
    [HttpPost(nameof(RegisterUser))]
    public async Task<IActionResult> RegisterUser(UserDTO user)
    {
        var res = await authService.Register(user);
        return res is null ? BadRequest("Registration failed.") : Ok(res);
    }

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="user">Login request data.</param>
    /// <returns>Returns a token if successful or BadRequest if authentication fails.</returns>
    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        var res = await authService.Login(user);
        return res is null ? BadRequest("Invalid login credentials.") : Ok(res);
    }

    /// <summary>
    /// Refreshes an access token using a refresh token.
    /// </summary>
    /// <param name="refreshToken">Refresh token.</param>
    /// <returns>Returns a new token if successful or BadRequest if the token is invalid.</returns>
    [AllowAnonymous]
    [HttpPost(nameof(RefreshToken))]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var res = await authService.RefreshToken(refreshToken);
        return res is null ? BadRequest("Invalid refresh token.") : Ok(res);
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns>Returns the user details or NotFound if the user does not exist.</returns>
    [HttpGet(nameof(GetUserById))]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);
        if (user == null)
            return NotFound($"User with ID {id} not found.");

        return Ok(user);
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>Returns a list of users or NotFound if no users exist.</returns>
    [HttpGet(nameof(GetAllUser))]
    public async Task<IActionResult> GetAllUser()
    {
        var users = await userService.GetAllUser();
        if (users == null || !users.Any())
            return NotFound("No users found.");

        return Ok(users);
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="user">Updated user data.</param>
    /// <returns>Returns Ok if successful or NotFound if the user does not exist.</returns>
    [HttpPut(nameof(UpdateUser))]
    public async Task<IActionResult> UpdateUser(int id, UserDTO user)
    {
        var existingUser = await userService.GetUserById(id);
        if (existingUser == null)
            return NotFound($"User with ID {id} not found.");

        await userService.UpdateUser(id, user);
        return Ok("User updated successfully.");
    }

    /// <summary>
    /// Deletes a user by their ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns>Returns Ok if successful or NotFound if the user does not exist.</returns>
    [HttpDelete(nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var existingUser = await userService.GetUserById(id);
        if (existingUser == null)
            return NotFound($"User with ID {id} not found.");

        await userService.DeleteUser(id);
        return Ok("User deleted successfully.");
    }

    /// <summary>
    /// Signs out a user.
    /// </summary>
    /// <param name="userId">User ID.</param>
    /// <returns>Returns true if successful, otherwise false.</returns>
    [HttpGet(nameof(SignOut))]
    public async Task<IActionResult> SignOut(int userId)
    {
        var result = await authService.SignOut(userId);
        return result ? Ok("User signed out successfully.") : BadRequest("Sign-out failed.");
    }

}
