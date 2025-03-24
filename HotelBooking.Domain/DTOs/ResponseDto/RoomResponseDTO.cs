namespace HotelBooking.Domain.DTOs.ResponseDto
{
    public class RoomResponseDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvialable { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Image { get; set; }
    }
}
