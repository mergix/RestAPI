namespace HotelApp.Models;
using System.ComponentModel.DataAnnotations;

public class Base_Entity
{
    
    [Key]
    public Guid Id { get; set; }
    public DateTime lastModified { get; set; }
}