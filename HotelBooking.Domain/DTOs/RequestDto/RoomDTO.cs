namespace HotelBooking.Domain.DTOs.RequestDto
{
    public class RoomDTO
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Image { get; set; }
    }
}
