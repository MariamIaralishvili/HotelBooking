using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces;

public interface ICityRepository
{
    Task Create(City city);
    Task Update(int id, City city);
    Task<City> GetById (int id);
    Task<IEnumerable<City>> GetAll ();
    Task DeleteById (int id);   
}
