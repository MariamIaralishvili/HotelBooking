using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure.Repositories;


namespace HotelBooking.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository usersRepositori;
        private readonly IMapper mapper;

        public UserService (IUserRepository usersRepositori, IMapper mapper)
        {
            this.usersRepositori = usersRepositori;
            this.mapper = mapper;
        }

        public async Task CreateUser(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User Is Empty.");
            }
            var map = mapper.Map<User>(user);
            await usersRepositori.CreateUser(map);
        }

        public async Task DeleteUser(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id Less Than 0.");
            }
            await usersRepositori.DeleteUser(id);
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllUser()
        {
            var result = await usersRepositori.GetAllUser();
            var map = mapper.Map<IEnumerable<UserResponseDTO>>(result);
            return map;
        }

        public async Task<UserResponseDTO> GetUserById(int id)
        {
            var result = await usersRepositori.GetUserById(id);
            var map = mapper.Map<UserResponseDTO>(result);
            return map;
        }

        public async Task UpdateUser(int id, UserDTO user)
        {
            var map = mapper.Map<User>(user);
            await usersRepositori.UpdateUser(id, map);
        }
    }
}
