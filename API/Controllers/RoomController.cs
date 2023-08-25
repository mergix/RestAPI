using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using Hotel.Services;
using Hotel.Services.RoomService;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Newtonsoft.Json;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService ;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserService _userService;

    public RoomController(IRoomService roomService, IUserService userService,IRoomRepository roomRepository)
    {
        _roomService = roomService;
        _roomRepository = roomRepository;
        _userService = userService;

    }

    [HttpGet("/allRooms")]
    public IActionResult GetRoomsList()
    {
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.RoleType != Role.Customer && user.RoleType != Role.Admin)
        // {
        //     return Unauthorized();
        // }
        return  Ok(_roomService.GetRoomList());
    }
    
    [HttpGet("/room/{id}")]
    public async Task<ActionResult<Room>> GetRoomById(Guid id)
    {
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.RoleType != Role.Admin && user.RoleType != Role.Customer)
        // {
        //     return Unauthorized();
        // }
        
        return await _roomService.GetRoomById(id);
    }
    
    [HttpPost("/CreateRoom")]
    public async Task<ActionResult<Room>> CreateRoom([FromBody] CreateRoomDTO room)
    {
       
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        var newRoom = await _roomService.CreateRoom(room);
        return Ok(newRoom);
    }
    
    [HttpPut("{id}")]
    public async  Task<ActionResult> UpdateRoom(Guid id, [FromBody] CreateRoomDTO room)
    {
        
        var jwt = Request.Cookies["token"];
        
        if (jwt == null)
        {
            return Ok("No cookie");
        }
    
        var token = _userService.Verify(jwt);
        
        var userEmail = token.Issuer;
        
    
        var user = _userService.emailExists(userEmail);
        if (user.roleType != Role.admin)
        {
            return Unauthorized();
        }
        
        if (id != room.roomId)
        {
            return BadRequest();
        }
    
        _roomService.UpdateRoom(room);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRoom(Guid id)
    {
        
        
        var jwt = Request.Cookies["token"];
    
        var token = _userService.Verify(jwt);
        
        var userEmail = token.Issuer;
        
    
        var user = _userService.emailExists(userEmail);
        if (user.roleType != Role.admin)
        {
            return Unauthorized();
        }
        
        var roomToDelete = await _roomService.GetRoomById(id);
        if (roomToDelete == null)
            return NotFound();
        
         _roomService.DeleteRoom(roomToDelete.Id);
        return NoContent();
    }
    
    
    [HttpGet("/allRoomTypes")]
    public async Task<ActionResult> GetRoomTypeList()
    {
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.RoleType != Role.Customer && user.RoleType != Role.Admin)
        // {
        //     return Unauthorized();
        // }
        return  Ok(_roomService.GetRoomTypeList());
    }
    
    [HttpGet("/roomType/{id}")]
    public async Task<ActionResult<RoomType>> GetRoomTypeById(Guid id)
    {
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.RoleType != Role.Admin && user.RoleType != Role.Customer)
        // {
        //     return Unauthorized();
        // }
        
        return await _roomService.GetRoomTypeById(id);
    }
    
    [HttpPost("CreateRoomType")]
    public async Task<ActionResult<RoomType>> CreateRoomType([FromBody] RoomType room)
    {
       
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        var newRoom = await _roomService.CreateRoomType(room);
        return Ok(newRoom);
    }
    
    [HttpPut("/putRoomType/{id}")]
    public async  Task<ActionResult> UpdateRoomType(Guid id, [FromBody] RoomType room)
    {
        
        // var jwt = Request.Cookies["token"];
        //
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        if (id != room.Id)
        {
            return BadRequest();
        }
    
        _roomService.UpdateRoomType(room);
        return NoContent();
    }
    
    [HttpDelete("/deleteRoomType{id}")]
    public async Task<ActionResult> DeleteRoomType(Guid id)
    {
        
        //
        // var jwt = Request.Cookies["token"];
        //
        // var token = _userService.Verify(jwt);
        //
        // var userEmail = token.Issuer;
        //
        //
        // var user = _userService.emailExists(userEmail);
        // if (user.roleType != Role.admin)
        // {
        //     return Unauthorized();
        // }
        
        var roomToDelete = await _roomService.GetRoomTypeById(id);
        if (roomToDelete == null)
            return NotFound();
        
         _roomService.DeleteRoomType(roomToDelete.Id);
        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveFile(FileUpload fileObj)
    {

        RoomType roomType = JsonConvert.DeserializeObject<RoomType>(fileObj.roomType);

        if (fileObj.file.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
            fileObj.file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            roomType.RoomPicture = fileBytes;

            roomType = _roomRepository.SaveRoomTypePic(roomType);

            if (roomType.Id != null)
            {
                return Ok("Saved");
            }

            }
        }

        return Ok("failed");
    }
    
    
    public byte[] GetImage(string sBase64String)
    {
        byte[] bytes = null;
        if (!string.IsNullOrEmpty(sBase64String))
        {
            bytes = Convert.FromBase64String(sBase64String);
        }

        return bytes;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetSavedRoomType(Guid id)
    {
        var roomType = _roomRepository.getRoomTypeById(id);
        roomType.RoomPicture = this.GetImage(Convert.ToBase64String(roomType.RoomPicture));
        return Ok(roomType);
    }
    
    

    
}