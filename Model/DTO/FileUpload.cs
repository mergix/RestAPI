using Microsoft.AspNetCore.Http;

namespace Model.DTO;

public class FileUpload
{
    public IFormFile file { get; set; }
    
    public string roomType { get; set; }
}