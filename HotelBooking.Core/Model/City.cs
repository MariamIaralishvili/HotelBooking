using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("Cities")]
public class City
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Hotel> Hotels { get; set; }
}
