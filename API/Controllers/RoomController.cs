using Hotel.Services;
using Hotel.Services.RoomService;
using HotelApp.Models;
using HotelApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService ;
    private readonly IUserService _userService;

    public RoomController(IRoomService roomService, IUserService userService)
    {
        _roomService = roomService;
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

    
}