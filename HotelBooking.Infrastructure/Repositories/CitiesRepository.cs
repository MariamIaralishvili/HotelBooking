using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;

namespace HotelBooking.Infrastructure.Repositories;

public class CitiesRepository : ICityRepository
{
    private readonly HotelBookingContext context;

    public CitiesRepository(HotelBookingContext context)
    {
        this.context = context;
    }

    public async Task Create(City city)
    {
        context.Cities.Add(city);
        await context.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var city = context.Cities.ToList().Where(io => io.Id == id).FirstOrDefault();
        if (city == null) throw new ArgumentException();
        context.Cities.Remove(city);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<City>> GetAll()
    {
        return context.Cities.ToList();
    }

    public async Task<City> GetById(int id)
    {
        var city = context.Cities.ToList().Where(io => io.Id == id).FirstOrDefault();
        return city;
    }

    public async Task Update(int id, City city)
    {
        var ct = context.Cities.ToList().Where(io => io.Id == id).FirstOrDefault();
        ct.Name = city.Name;
        await context.SaveChangesAsync();
    }
}
