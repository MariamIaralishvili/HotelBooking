using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("BookedRooms")]
public class BookedRoom
{
    [Key]
    public int Id { get; set; }


    [ForeignKey("Users")]
    public int UserId { get; set; }
    public User Users { get; set; }


    [ForeignKey("Rooms")]
    public int RoomId { get; set; }
    public Room Rooms { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true; //javshani aqtiuria tu ara
}
