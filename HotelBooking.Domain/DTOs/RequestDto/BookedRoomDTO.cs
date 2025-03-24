namespace HotelBooking.Domain.DTOs.RequestDto
{
    public class BookedRoomDTO
    {
       public int UserId { get; set; }
       public int RoomId { get; set; }
       public DateTime CheckIn { get; set; }
       public DateTime CheckOut { get; set; }
       //public decimal TotalPrice { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime? UpdatedAt { get; set; }
    }
}
