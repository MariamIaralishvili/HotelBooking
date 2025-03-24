using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("RefreshTokens")]
public class RefreshToken
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId {  get; set; }
    public User User { get; set; }
    public required string RefreshTokenValue { get; set; }
    public bool IsInvoked { get; set; } = false;
}
