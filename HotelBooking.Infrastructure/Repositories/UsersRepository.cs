using System.Linq.Expressions;
using HotelBooking.Core.DBContexti;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly HotelBookingContext context;

        public UsersRepository(HotelBookingContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var userId = context.Users.Where(io=>io.Email ==  user.Email).FirstOrDefault();
            if (userId == null) { return 0; }
            return userId.Id;
        }

        public async Task DeleteUser(int id)
        {
            var user = context.Users.ToList().Where(io => io.Id == id).FirstOrDefault();
            if (user == null) throw new ArgumentException();
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return context.Users.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = context.Users.Include(io=>io.RefreshTokens).Where(io => io.Id == id).FirstOrDefault();
            return user;
        }

        public async Task UpdateUser(int id, User user)
        {
            var us = context.Users.ToList().Where(io => io.Id == id).FirstOrDefault();
            user.Phone = us.Phone;           //sworia?
            await context.SaveChangesAsync();
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await context.Users.FirstOrDefaultAsync(predicate);
        }
    }
}
