using System.ComponentModel.DataAnnotations;
using Npgsql.Internal.TypeHandlers;

namespace HotelApp.Models;

public class RoomType:Base_Entity
{
    // [Key]
    // public Guid roomTypeId { get; set; }
    
    public string roomtypeName { get; set; }
    
    public byte[] RoomPicture { get; set; }
    
    public decimal? cost { get; set; }
    
    public string? description { get; set; }
    
}