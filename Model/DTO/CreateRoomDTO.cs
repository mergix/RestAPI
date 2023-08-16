using HotelApp.Models;
using HotelApp.Models.Enums;

namespace Model.DTO;

public class CreateRoomDTO
{
    public Guid roomId { get; set; }
   
    public int roomNo { get; set; }
    
    public Guid roomTypeId { get; set; }
    
    public  roomState status { get; set; }
}