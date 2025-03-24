using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Model;

[Table("Hotels")]
public class Hotel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }


    [ForeignKey("Cities")]
    public int CityId { get; set; }
    public City Cities { get; set; }

    public string? Image { get; set; }
    public List<Room> Rooms { get; set; }
}
