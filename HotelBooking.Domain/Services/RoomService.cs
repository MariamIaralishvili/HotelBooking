using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure.Repositories;


namespace HotelBooking.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }


        public async Task CreateRoom(RoomDTO room)
        {
            if(room == null)
            {
                throw new ArgumentNullException("Room Is Empty.");
            }
            var map = mapper.Map<Room>(room);
            await roomRepository.CreateRoom(map);
        }

        public async Task DeleteRoom(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id Less Than 0.");
            }
            await roomRepository.DeleteRoom(id);
        }

        public async Task<IEnumerable<RoomResponseDTO>> GetAllRoom()
        {
            var result = await roomRepository.GetAllRoom();
            var map = mapper.Map<IEnumerable<RoomResponseDTO>>(result);
            return map;
        }

        public async Task<RoomResponseDTO> GetRoomById(int id)
        {
            var result = await roomRepository.GetRoomById(id);
            var map = mapper.Map<RoomResponseDTO>(result);
            return map;
        }

        public async Task UpdateRoom(int id, RoomDTO room)
        {
            var map = mapper.Map<Room>(room);
            await roomRepository.UpdateRoom(id, map);
        }

        public async Task<RoomResponseDTO> GetByHotelId(int hotelId)
        {
            var result = await roomRepository.GetAllRoom();
            var hot = result.Where(r => r.HotelId == hotelId).FirstOrDefault();
            var map = mapper.Map<RoomResponseDTO>(hot);
            return map;
        }
    }
}
