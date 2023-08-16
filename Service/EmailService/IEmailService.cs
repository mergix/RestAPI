
using Model.DTO;

namespace Hotel.Services.EmailService;

public interface IEmailService
{
    public void SendEmail(EmailDTO req);
}