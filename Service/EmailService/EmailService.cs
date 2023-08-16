using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Model.DTO;

namespace Hotel.Services.EmailService;

public class EmailService :IEmailService
{
    
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void SendEmail(EmailDTO req)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("fmergix@gmail.com"));
        email.To.Add(MailboxAddress.Parse(req.Recipient));
        email.Subject = req.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = req.Body };
        
        var username = _configuration.GetSection("AppSettings:Username").Value;
        var password = _configuration.GetSection("AppSettings:Password").Value;
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com",587,SecureSocketOptions.StartTls);
        smtp.Authenticate(username,password);
        smtp.Send(email);
        smtp.Disconnect(true);
        
    }
}