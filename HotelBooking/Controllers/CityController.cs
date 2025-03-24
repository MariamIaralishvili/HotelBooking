using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
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
    /// qalaqis damateba
    /// </summary>
    /// <param name="city"></param>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task Create(CityDTO city)
    {
        await cityService.Create(city);
    }

    [HttpGet(nameof(GetById))]
    public async Task<CityResponseDTO> GetById(int id)
    {
        return await cityService.GetById(id);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IEnumerable<CityResponseDTO>> GetAll()
    {
        return await cityService.GetAll();
    }

    [HttpPut(nameof(Update))]
    public async Task Update(int id, CityDTO city)
    {
        await cityService.Update(id, city);
    }

    [HttpDelete(nameof(DeleteById))]
    public async Task DeleteById(int id)
    {
        await cityService.DeleteById(id);
    }
}
