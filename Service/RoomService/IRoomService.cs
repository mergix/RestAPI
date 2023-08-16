using HotelApp.Models;
using Model.DTO;

namespace Hotel.Services.RoomService;

public interface IRoomService
{
    public  Task<IEnumerable<Room>> GetRoomList();
    
    public  Task<IEnumerable<RoomType>> GetRoomTypeList();
    
    
    public  Task<Room> CreateRoom( CreateRoomDTO model);
    
    public  void UpdateRoom(CreateRoomDTO model);
    
    public  void DeleteRoom(Guid id);
    
    public  Task<Room> GetRoomById(Guid id);
    
    public  Task<RoomType> CreateRoomType( RoomType model);
    
    public  void UpdateRoomType(RoomType model);
    
    public  void DeleteRoomType(Guid id);
    
    public  Task<RoomType> GetRoomTypeById(Guid id);
}