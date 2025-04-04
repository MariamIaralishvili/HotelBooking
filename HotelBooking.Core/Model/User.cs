using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<BookedRoom> BookedRooms { get; set; }
    public List<Favorite> Favorites { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public List<Review> Reviews { get; set; }
}
