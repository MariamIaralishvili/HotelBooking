using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;

namespace HotelBooking.Domain.Interfaces;

public interface ICityService
{
    Task Create(CityDTO city);
    Task Update(int id, CityDTO city);
    Task<CityResponseDTO> GetById(int id);
    Task<IEnumerable<CityResponseDTO>> GetAll();
    Task DeleteById(int id);
}
