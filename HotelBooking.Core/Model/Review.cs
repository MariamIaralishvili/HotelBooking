using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table ("Reviews")]
public class Review
{
   [Key]
   public int Id { get; set; }

   [ForeignKey("Users")]
   public int UserId { get; set; }
   public User Users { get; set; }

   [ForeignKey("Rooms")]
   public int RoomId { get; set; }
   public Room Rooms { get; set; }

   public int Rating { get; set; }
   public int Comment { get; set; }
   public int CreatedAt { get; set; }

}

