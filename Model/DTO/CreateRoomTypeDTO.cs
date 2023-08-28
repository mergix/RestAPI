using Microsoft.AspNetCore.Http;

namespace Model.DTO;

public class CreateRoomTypeDTO
{
    
    public Guid roomTypeId { get; set; }
    
    public string roomtypeName { get; set; }
    
    public IFormFile Picture { get; set; }
    
    public decimal? cost { get; set; }
    
    public string? description { get; set; }
}