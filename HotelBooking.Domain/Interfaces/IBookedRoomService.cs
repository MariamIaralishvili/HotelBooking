using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;


namespace HotelBooking.Domain.Interfaces;

 public interface IBookedRoomService
 {
    Task <IEnumerable<BookedRoomResponseDTO>> GetAllBookedRoom();
    Task<BookedRoomResponseDTO> GetBookedRoomByClientId(int clientId);
    Task<BookedRoomResponseDTO> GetBookedRoomByRoomId(int roomId);
    Task<bool> ReservedRoom(BookedRoomDTO booked);
    Task<bool> CancelBookedRoom(int roomId, int reserveId);
 }
