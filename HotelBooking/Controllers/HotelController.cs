using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        /// <summary>
        /// Create new Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateHotel))]
        public async Task CreateHotel(HotelDTO hotel)
        {
            await hotelService.CreateHotel(hotel);
        }

        [HttpGet(nameof(GetHotelById))]
        public async Task<HotelResponseDTO> GetHotelById(int id)
        {
            return await hotelService.GetHotelById(id);
        }

        [HttpGet(nameof(GetAllHotel))]
        public async Task<IEnumerable<HotelResponseDTO>> GetAllHotel()
        {
            return await hotelService.GetAllHotel();
        }

        [HttpPut(nameof(UpdateHotel))]
        public async Task UpdateHotel(int id, HotelDTO hotel)
        {
            await hotelService.UpdateHotel(id, hotel);
        }

        [HttpDelete(nameof(DeleteHotel))]
        public async Task DeleteHotel(int id)
        {
            await hotelService.DeleteHotel(id);
        }
    }
}
