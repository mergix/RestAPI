namespace Model.DTO;

public class RegisterRequestDTO
{
    public string firstName { get; set; }
     
    public string lastName { get; set; }
    public string userEmail { get; set; }
    public string userPasswordHash  { get; set; }
    
    public Int64 phoneNo { get; set; }
    
    public string address { get; set; }
    
    public string address2 { get; set; }
    
    public string address3 { get; set; }
}