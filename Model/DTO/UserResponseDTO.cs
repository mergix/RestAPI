using HotelApp.Models.Enums;

namespace Model.DTO;

public class UserResponseDTO
{
    public Guid UserId { get; set; }
    public string UserEmail { get; set; }
    
    public string Token { get; set; }
    
    public Role RoleType { get; set; }
}