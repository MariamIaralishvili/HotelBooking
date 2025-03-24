using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelsRepository;
        private readonly IMapper mapper;

        public HotelService(IHotelRepository hotelsRepository, IMapper mapper)
        {
            this.hotelsRepository = hotelsRepository;
            this.mapper = mapper;
        }

        public async Task CreateHotel(HotelDTO hotel)
        {
            if (hotel == null)
            {
                throw new ArgumentNullException("Hotel Is Empty.");
            }
            var map = mapper.Map<Hotel>(hotel);
            await hotelsRepository.CreateHotel(map);
        }

        public async Task DeleteHotel(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id Less Than 0.");
            }
            await hotelsRepository.DeleteHotel(id);
        }

        public async Task<IEnumerable<HotelResponseDTO>> GetAllHotel()
        {
            var result = await hotelsRepository.GetAllHotel();
            var map = mapper.Map<IEnumerable<HotelResponseDTO>>(result);
            return map;
        }

        public async Task<HotelResponseDTO> GetHotelById(int id)
        {
            if (id < 0) return null;

            var result = await hotelsRepository.GetHotelById(id);
            var map = mapper.Map<HotelResponseDTO>(result);
            return map;
        }

        public async Task UpdateHotel(int id, HotelDTO hotel)
        {
            var map = mapper.Map<Hotel>(hotel);
            await hotelsRepository.UpdateHotel(id, map);
        }
    }
}
