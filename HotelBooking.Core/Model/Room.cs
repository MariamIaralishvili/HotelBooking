using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("Rooms")]
public class Room
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Hotels")]
    public int HotelId { get; set; }
    public Hotel Hotels { get; set; }

    [ForeignKey("RoomType")]
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }

    public int RoomNumber { get; set; }
    public decimal Price { get; set; }
    public bool IsAvialable { get; set; } = true;
    public int Capacity { get; set; } //max stumrebis raodenoba
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Image { get; set; }
    public List<BookedRoom> BookedRooms { get; set; }
    public List<Favorite> Favorites { get; set; }
}
