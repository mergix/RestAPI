using Hotel.DatabaseContext;
using HotelApp.Models;
using HotelApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class RoomRepository :IRoomRepository
{
    
    private readonly ApplicationDbContext _db;
    
    public RoomRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    public void AddRoom(Room room)
    {
        _db.Room.Add(room);
        _db.SaveChanges();
    }
    
    public void UpdateRoom(Room room)
    {
        _db.Room.Update(room);
        _db.SaveChanges();
    }
    
    public Room getRoomById(Guid id)
    {
        var roomById = _db.Room.Include(r => r.roomType).FirstOrDefault(p => p.Id == id);
        return roomById ;
    }

    public void DeleteRoom(Guid id)
    {
        var deleteRoom =  _db.Room.Find(id);
        _db.Room.Remove(deleteRoom);
        _db.SaveChanges();
    }
    
    public void AddRoomType(RoomType room)
    {
        _db.RoomType.Add(room);
        _db.SaveChanges();
    }
    
    public void UpdateRoomType(RoomType room)
    {
        _db.RoomType.Update(room);
        _db.SaveChanges();
    }
    
    public RoomType getRoomTypeById(Guid id)
    {
        var roomById = _db.RoomType.FirstOrDefault(p => p.Id == id);
        return roomById ;
    }

    public void DeleteRoomType(Guid id)
    {
        var deleteRoom =  _db.RoomType.Find(id);
        _db.RoomType.Remove(deleteRoom);
        _db.SaveChanges();
    }

    public IEnumerable<Room> GetAllRoomsByLastModified()
    {
        return _db.Room.Include(r => r.roomType).OrderByDescending(r => r.lastModified).ToList();
    }
    
    public IEnumerable<RoomType> GetAllRoomTypesByLastModified()
    {
        return _db.RoomType.OrderByDescending(r => r.lastModified).ToList();
    }

    public IEnumerable<Room> GetAllByBookedRooms()
    {
        return _db.Room
            .Where(r=> r.status == roomState.Booked)
            .OrderByDescending(r => r.lastModified).ToList();
    }
  
    
    
    public void UpdateNoSave(Room room)
    {
         var gg =_db.Room.FirstOrDefault(x => x.Id == room.Id);
         gg.status = roomState.Booked;
        _db.Room.Update(gg);
        _db.SaveChanges();
    }

}