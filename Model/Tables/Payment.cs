using System.ComponentModel.DataAnnotations;
using HotelApp.Models.Enums;

namespace HotelApp.Models;

public class Payment:Base_Entity
{
    [Key]
    public Guid paymentId { get; set; }
    public Booking booking { get; set; }
    public int amount { get; set; }
    public String paymentType { get; set; }
    public String paymentDetails { get; set; }
    public payState status { get; set; }

        
}