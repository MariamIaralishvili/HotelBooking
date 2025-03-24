using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
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


    [AllowAnonymous] //xsnis autorizacias
    [HttpPost(nameof(RegisterUser))]
    public async Task<IActionResult> RegisterUser(UserDTO user)
    {
        var res = await authService.Register(user);
        return res is null ? BadRequest(res) : Ok(res);
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        var res = await authService.Login(user);
        return res is null ? BadRequest(res) : Ok(res);
    }

    [AllowAnonymous]
    [HttpPost(nameof(RefreshToken))]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var res = await authService.RefreshToken(refreshToken);
        return res is null ? BadRequest(res) : Ok(res);
    }

    [HttpGet(nameof(GetUserById))]
    public async Task<UserResponseDTO> GetUserById(int id)
    {
        return await userService.GetUserById(id);
    }

    [HttpGet(nameof(GetAllUser))]
    public async Task<IEnumerable<UserResponseDTO>> GetAllUser()
    {
        return await userService.GetAllUser();
    }

    [HttpPut(nameof(UpdateUser))]
    public async Task UpdateUser(int id, UserDTO user)
    {
        await userService.UpdateUser(id, user);
    }

    [HttpDelete(nameof(DeleteUser))]
    public async Task DeleteUser(int id)
    {
        await userService.DeleteUser(id);
    }

    [HttpGet]
    [Route("{userId:int}")]
    public async Task<bool> SignOut(int userId)
    {
        return await authService.SignOut(userId);
    }

}
