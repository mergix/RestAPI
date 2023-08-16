using System.IdentityModel.Tokens.Jwt;
using HotelApp.Models;
using Model.DTO;

namespace Hotel.Services;

public interface IUserService
{
    public  Task<IEnumerable<User>> GetUserList();

    public  Task<User> GetUserById(Guid id);

    public  User emailExists(string email);

    public  Task<UserResponseDTO> LoginUser(LoginRequestDTO user);
    
    public  Task<UserResponseDTO> LoginAdmin(LoginRequestDTO user);

    public  Task<UserResponseDTO> CreateUser(RegisterRequestDTO model);
    
    public  Task<UserResponseDTO> CreateAdmin(RegisterRequestDTO model);

    public void UpdateUser(User user);

    public void DeleteUser(Guid id);

    public dynamic CreateToken(LoginRequestDTO user);

    public JwtSecurityToken Verify(string jwt);
}