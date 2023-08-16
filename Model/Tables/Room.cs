using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using HotelApp.Models.Enums;

namespace HotelApp.Models;
using System.ComponentModel.DataAnnotations;

public class Room:Base_Entity
{
    [Key]
    public Guid roomId { get; set; }
   
    public int roomNo { get; set; }
    
    public RoomType roomType { get; set; }
    
    public  roomState status { get; set; }
    

    
}