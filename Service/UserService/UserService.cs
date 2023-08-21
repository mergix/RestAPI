using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Hotel.Services.PasswordService;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTO;


namespace Hotel.Services;

public class UserService : IUserService
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;
    
    public UserService(IUserRepository userRepository,IConfiguration configuration,IHttpContextAccessor httpContextAccessor,IPasswordHasher passwordHasher)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<IEnumerable<User>> GetUserList()
    {
        var userlist =  _userRepository.GetAllUsersByDateModified();
        
        
        return userlist;
    }

    public async Task<User> GetUserById(Guid id)
    {
        return _userRepository.FindByUserId(id);
    }

    public  User emailExists(string email)
    {
        {
            return _userRepository.checkEmail(email);
        }
    }
    

    public async Task<UserResponseDTO> LoginUser(LoginRequestDTO user)
    {
        var existingUser =  _userRepository.checkEmail(user.UserEmail);
        var result = _passwordHasher.Verify(existingUser.UserPasswordHash,user.UserPassword);


        if (existingUser == null)
        {
            var noUser = new UserResponseDTO()
            {
                UserEmail = "No User"
            };

            return noUser;
        }

        if (result == false)
        {
            var wrongpwd = new UserResponseDTO()
            {
                UserEmail = "Invalid password"
            };

            return wrongpwd;
        }
        
        
        var viewModel = new UserResponseDTO()
        {
            UserId = existingUser.Id,
            UserEmail = existingUser.UserEmail,
            RoleType = existingUser.roleType
        };
        

        return viewModel;
    }
    
    public async Task<UserResponseDTO> LoginAdmin(LoginRequestDTO user)
    {
        var existingUser =  _userRepository.LoginAdmin(user.UserEmail,user.UserPassword);

        if (existingUser == null)
        {
            var noUser = new UserResponseDTO()
            {
                UserEmail = "No User"
            };

            return noUser;
        }
        
        
        var viewModel = new UserResponseDTO()
        {
            UserId = existingUser.Id,
            UserEmail = existingUser.UserEmail
        };
        return viewModel;
    }

    public async Task<UserResponseDTO> CreateUser(RegisterRequestDTO model)
    {
        var existingUser = _userRepository.checkEmail(model.userEmail);
        
        var passwordhash = _passwordHasher.Hash(model.userPasswordHash);

        var ms = "fff";

        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            firstName = model.firstName,
            lastName = model.lastName,
            UserEmail = model.userEmail,
            UserPasswordHash = passwordhash,
            roleType = Role.user,
            // paymentInfo = null,
            // profileImage = Convert.ToBase64String(),
            address = model.address + ","+ model.address2 + ","+ model.address3,
            phoneNo = model.phoneNo,
            lastModified = DateTime.UtcNow,
            
        };
        
        if (existingUser != null)
        {
            return null;
        }
        
        _userRepository.Add(newUser); 
        


        var viewModel = new UserResponseDTO()
        {
            UserId = newUser.Id,
            UserEmail = newUser.UserEmail
        };

        return viewModel;
    }
    
    public async Task<UserResponseDTO> CreateAdmin(RegisterRequestDTO model)
    {
        var existingUser = _userRepository.checkEmail(model.userEmail);

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            firstName = model.firstName,
            lastName = model.lastName,
            UserEmail = model.userEmail,
            UserPasswordHash = model.userPasswordHash,
            lastModified = DateTime.UtcNow,
            roleType = Role.admin
            
        };
        
        if (existingUser != null)
        {
            return null;
        }
        
        _userRepository.Add(newUser); 

        var viewModel = new UserResponseDTO()
        {
            UserId = newUser.Id,
            UserEmail = newUser.UserEmail
        };

        return viewModel;
    }

    public void  UpdateUser(User user)
    {
        _userRepository.Update(user);
    }
    

    public  void  DeleteUser(Guid id)
    {
      _userRepository.Delete(id);
    }
    
    
    public dynamic CreateToken(LoginRequestDTO user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var header = new JwtHeader(credentials);

        var payload = new JwtPayload(user.UserEmail,
            null, 
            null,
            null, 
            DateTime.Now.AddHours(2)); 
        
        
        var securityToken = new JwtSecurityToken(header, payload);

        var jwt =  new JwtSecurityTokenHandler().WriteToken(securityToken);
        _httpContextAccessor.HttpContext.Response.Cookies.Append("token",jwt,
            new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddHours(2),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            }
        );
        
        return jwt;
    }
    
    public JwtSecurityToken Verify(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
        tokenHandler.ValidateToken(jwt, new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false
        }, out SecurityToken validatedToken);

        return (JwtSecurityToken) validatedToken;
    }
    

}