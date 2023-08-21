using System.ComponentModel.DataAnnotations;
using HotelApp.Models.Enums;

namespace HotelApp.Models;

public class Order:Base_Entity
{
    // [Key]
    // public Guid orderId { get; set; }
    public Booking booking { get; set; }
    public int quantity { get; set; }
    public decimal cost { get; set; }
    public orderState status { get; set; }

    
}