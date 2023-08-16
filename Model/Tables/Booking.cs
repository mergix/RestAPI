using System.ComponentModel.DataAnnotations.Schema;
using HotelApp.Models.Enums;

namespace HotelApp.Models;
using System.ComponentModel.DataAnnotations;

public class Booking:Base_Entity
{
    [Key]
    public Guid bookingId { get; set; }
    
    
    
    public Room room { get; set; }
    
    public User user { get; set; }
    
    public orderState status { get; set; }
    
    public DateTime dateIn { get; set; }
    
    public DateTime dateOut { get; set; }
}