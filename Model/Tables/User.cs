using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HotelApp.Models.Enums;


namespace HotelApp.Models;

public class User:Base_Entity
{
    [Key]
    public Guid UserId { get; set; }
    
    public string firstName { get; set; }
     
    public string lastName { get; set; }

    public string UserEmail { get; set; }
    
    
    public string UserPasswordHash  { get; set; } 
    
    public Gender? gender { get; set; }
    
    // public byte? [] profileImage {get; set; }
    
    public string address { get; set; }
    
    public Int64 phoneNo { get; set; }
    
    public Payment? paymentInfo { get; set; }
    
    public Role roleType { get; set; }
    
 
}