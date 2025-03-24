using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Domain.Services;

public class CityService : ICityService
{
    private readonly ICityRepository citiesRepository;
    private readonly IMapper mapperi;


    public CityService(ICityRepository citiesRepository, IMapper mapperi)
    {
        this.citiesRepository = citiesRepository;
        this.mapperi = mapperi;
    }

    public async Task Create(CityDTO city)
    {
        if (city == null)
        {
            throw new ArgumentNullException("City Is Empty.");
        }
        var map = mapperi.Map<City>(city);
        await citiesRepository.Create(map);
    }

    public async Task DeleteById(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("Id Less Than 0."); 
        }
        await citiesRepository.DeleteById(id);
    }

    public async Task<IEnumerable<CityResponseDTO>> GetAll()
    {
        var result = await citiesRepository.GetAll();
        var map = mapperi.Map<IEnumerable<CityResponseDTO>>(result);
        return map;
    }

    public async Task<CityResponseDTO> GetById(int id)
    {
        if (id < 0) return null;
        
        var result = await citiesRepository.GetById(id);
        var map = mapperi.Map<CityResponseDTO>(result);
        return map;
    }

    public async Task Update(int id, CityDTO city)
    {
        var mapCity = mapperi.Map<City>(city);
        await citiesRepository.Update(id, mapCity);
    }
}
