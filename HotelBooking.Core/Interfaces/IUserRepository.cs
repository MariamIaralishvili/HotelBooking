using System.Linq.Expressions;
using HotelBooking.Core.Model;

namespace HotelBooking.Core.Interfaces;

public interface IUserRepository
{
    Task<int> CreateUser(User user);
    Task UpdateUser(int id, User user);
    Task<User> GetUserById(int id);
    Task<IEnumerable<User>> GetAllUser();
    Task DeleteUser(int id);
    Task<User> FindAsync(Expression<Func<User, bool>> predicate);
}