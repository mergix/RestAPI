using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;

using Model.DTO;
using Newtonsoft.Json;


namespace Hotel.Services.RoomService;

public interface IRoomService
{
    public  Task<IEnumerable<Room>> GetRoomList();
    
    public  Task<IEnumerable<RoomType>> GetRoomTypeList();
    
    
    public  Task<Room> CreateRoom( CreateRoomDTO model);
    
    public  void UpdateRoom(CreateRoomDTO model);
    
    public  void DeleteRoom(Guid id);
    
    public  Task<Room> GetRoomById(Guid id);
    
    public  Task<RoomType> CreateRoomType( FileUpload model);
    
    public  void UpdateRoomType(RoomType model);
    
    public  void DeleteRoomType(Guid id);
    
    public  Task<RoomType> GetRoomTypeById(Guid id);
}

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
            Id = Guid.NewGuid(),
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
            Id = model.roomId,
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
    
    public async Task<RoomType> CreateRoomType(FileUpload model)
    {
        //
        RoomType roomType = JsonConvert.DeserializeObject<RoomType>(model.roomType);
        
        // RoomType roomType = JsonConvert.DeserializeObject<RoomType>(model.ro);
        byte[] fileBytes = new byte[] { };

        if (model.file.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                model.file.CopyTo(ms);
                 fileBytes = ms.ToArray();
                // roomType.RoomPicture = fileBytes;
                
                // roomType = _roomRepository.SaveRoomTypePic(roomType);



            }
        }

       // var  Id = Guid.NewGuid();
        
        var newRoom = new RoomType()
        {
            Id = Guid.NewGuid(),
            roomtypeName = roomType.roomtypeName,
            cost = roomType.cost,
            lastModified = DateTime.UtcNow,
            description = roomType.description,
            RoomPicture = fileBytes ,
        };
        _roomRepository.AddRoomType(newRoom);
        return newRoom ;
    }

    public void  UpdateRoomType(RoomType model)
    {
        
        var editRoom = new RoomType()
        {
            Id = model.Id,
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