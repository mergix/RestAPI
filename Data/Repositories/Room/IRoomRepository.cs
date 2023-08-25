using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IRoomRepository
{
    void AddRoom(Room room);
    void UpdateRoom(Room room);
    
    
    Room getRoomById(Guid id);
    void DeleteRoom(Guid id);
    
    void AddRoomType(RoomType room);
    RoomType SaveRoomTypePic(RoomType room);
    void UpdateRoomType(RoomType room);
    
    
    RoomType getRoomTypeById(Guid id);
    void DeleteRoomType(Guid id);
    
    IEnumerable<Room> GetAllRoomsByLastModified();
    IEnumerable<RoomType> GetAllRoomTypesByLastModified();
    
    IEnumerable<Room> GetAllByBookedRooms();
    
    void UpdateNoSave(Room room);
}