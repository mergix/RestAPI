
using Hotel.Services;
using Hotel.Services.EmailService;
using Hotel.Services.PasswordService;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;


namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly IPasswordHasher _passwordHasher;

    public UserController(IUserService userService,IEmailService emailService,IPasswordHasher passwordHasher)
    {
        _userService = userService;
        _emailService = emailService;
        _passwordHasher = passwordHasher;
    }


    [HttpPost]
    public IActionResult PostUser([FromBody] RegisterRequestDTO user)
    {
    
        // var passwordhash = _passwordHasher.Hash(user.userPasswordHash);
        // var gg = new User
        // {
        //     userId = Guid.NewGuid(),
        //     firstName = user.firstName,
        //     lastName = user.lastName,
        //     userEmail = user.userEmail,
        //     userPasswordHash = passwordhash,
        //     roleType = Role.user,
        //     address = user.address + user.address2 + user.address3,
        //     phoneNo = user.phoneNo,
        //     lastModified = DateTime.UtcNow,
        //     
        // };
        
        var newUser =  _userService.CreateUser(user);
        var testemail = new EmailDTO()
        {
            Recipient = user.userEmail,
            Body = "Thank you for registering with us here at spectrum hotels",
            Subject = "Account Created"
        };
        // _emailService.SendEmail(testemail);
        return Ok(newUser);
    }
    
    [HttpPost("/Login")]
    public IActionResult LoginUser([FromBody] LoginRequestDTO user)
    {
       var  UserLoginInfo =  _userService.LoginUser(user);
    
       _userService.CreateToken(user);
       
       var token = _userService.CreateToken(user);
    
       var UserLoginWithToken = new UserResponseDTO()
       {
           UserId = UserLoginInfo.Result.UserId,
           UserEmail = UserLoginInfo.Result.UserEmail,
           Token = token,
           RoleType = UserLoginInfo.Result.RoleType
       };
       return Ok(UserLoginWithToken);
    } 
    
    [HttpGet]
    public IActionResult GetUsersList()
    {
        var jwt = Request.Cookies["token"];
        
        if (jwt == null)
        {
            return Ok("No cookie");
        }
    
        var token = _userService.Verify(jwt);
        
        var userEmail = token.Issuer;
        
    
        var user = _userService.emailExists(userEmail);
        if (user.roleType != Role.user && user.roleType != Role.admin)
        {
            return Unauthorized();
        }
        
        return  Ok(_userService.GetUserList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        
        var jwt = Request.Cookies["token"];
        if (jwt == null)
        {
            return Ok("No cookie");
        }
    
        var token = _userService.Verify(jwt);
        
        var userEmail = token.Issuer;
        
    
        var user = _userService.emailExists(userEmail);
        if (user.roleType != Role.user && user.roleType != Role.admin)
        {
            return Unauthorized();
        }
        
        return  Ok(_userService.GetUserById(id));
    }
    
    
    [HttpPost("/LoginAdmin")]
    public IActionResult LoginAdmin([FromBody] LoginRequestDTO user)
    {
        var  UserLoginInfo =  _userService.LoginAdmin(user);
    
        _userService.CreateToken(user);
        return Ok(UserLoginInfo);
    }
    
    [HttpPost("/Admin")]
    public IActionResult PostAdmin([FromBody] RegisterRequestDTO admin)
    {
        // var jwt = Request.Cookies["token"];
        // if (jwt == null)
        // {
        //     return Ok("No cookie");
        // }
    
        // var token = _userService.Verify(jwt);
        
        // var userEmail = token.Issuer;
        
    
        // var user = _userService.emailExists(userEmail);
        // if (user.RoleType != Role.Admin)
        // {
        //     return Unauthorized();
        // }
        
        var newUser =  _userService.CreateAdmin(admin);
        return Ok(newUser);
    }
    
    [HttpPut]
    public IActionResult PutUser(Guid id, [FromBody] User user)
    {
    
    
        var jwt = Request.Cookies["token"];
        if (jwt == null)
        {
            return Ok("No cookie");
        }
    
        var token = _userService.Verify(jwt);
        
        var userEmail = token.Issuer;
        
    
        var cust = _userService.emailExists(userEmail);
        if (cust.roleType != Role.admin)
        {
            return Unauthorized();
        }
        if (id != user.Id)
        {
            return BadRequest();
        }
         _userService.UpdateUser(user);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteUser(Guid id)
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
        
        var userToDelete = await _userService.GetUserById(id);
        if (userToDelete == null)
            return NotFound();
    
         _userService.DeleteUser(userToDelete.Id);
        return NoContent();
    }
    
    
}