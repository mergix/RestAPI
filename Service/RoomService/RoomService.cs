using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.Enums;
using Model.DTO;

namespace Hotel.Services.RoomService;

public class RoomService:IRoomService
{
   
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    
    public RoomService(IRoomRepository roomRepository,IBookingRepository bookingRepository) 
    { 
        
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
    }


    public async Task<IEnumerable<Room>> GetRoomList()
    {
        // _bookingRepository.UnBookDate();
                      return _roomRepository.GetAllRoomsByLastModified();
    }

    public async Task<Room> GetRoomById(Guid id)
    {
        // _bookingRepository.UnBookDate();
        return _roomRepository.getRoomById(id);
    }
    
    public async Task<IEnumerable<RoomType>> GetRoomTypeList()
    {
        // _bookingRepository.UnBookDate();
        return _roomRepository.GetAllRoomTypesByLastModified();
    }

    public async Task<RoomType> GetRoomTypeById(Guid id)
    {
        // _bookingRepository.UnBookDate();
        return _roomRepository.getRoomTypeById(id);
    }

    public async Task<Room> CreateRoom(CreateRoomDTO model)
    {
        var newRoom = new Room
        {
            roomId = Guid.NewGuid(),
            roomType = _roomRepository.getRoomTypeById(model.roomTypeId),
            lastModified = DateTime.UtcNow,
            roomNo = model.roomNo,
            status = model.status
        };
       _roomRepository.AddRoom(newRoom);
        return newRoom ;
    }

    public void  UpdateRoom(CreateRoomDTO model)
    {
        
        var editRoom = new Room()
        {
            roomId = model.roomId,
            roomType = _roomRepository.getRoomTypeById(model.roomTypeId),
            lastModified = DateTime.UtcNow,
            roomNo = model.roomNo,
            status = model.status
        };
        
        _roomRepository.UpdateRoom(editRoom);

        
    }

    public void DeleteRoom(Guid id)
    {
        _roomRepository.DeleteRoom(id);
    }
    
    public async Task<RoomType> CreateRoomType(RoomType model)
    {
        var newRoom = new RoomType()
        {
            roomTypeId = model.roomTypeId,
            roomtypeName = model.roomtypeName,
            cost = model.cost,
            lastModified = DateTime.UtcNow,
            description = model.description,
            RoomPicture = model.RoomPicture,
        };
        _roomRepository.AddRoomType(newRoom);
        return newRoom ;
    }

    public void  UpdateRoomType(RoomType model)
    {
        
        var editRoom = new RoomType()
        {
            roomTypeId = model.roomTypeId,
            roomtypeName = model.roomtypeName,
            cost = model.cost,
            lastModified = DateTime.UtcNow,
            description = model.description,
            RoomPicture = model.RoomPicture,
        };
        
        _roomRepository.UpdateRoomType(editRoom);

        
    }

    public void DeleteRoomType(Guid id)
    {
        _roomRepository.DeleteRoomType(id);
    }
}