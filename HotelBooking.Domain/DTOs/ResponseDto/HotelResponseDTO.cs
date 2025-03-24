namespace HotelBooking.Domain.DTOs.ResponseDto
{
    public class HotelResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string? Image { get; set; }
    }
}
