using Blog.Entity.DTOs.Email;

namespace Blog.Service.Services.Abstractions
{
    public interface IMailService
    {
        Task<string> SendContactEmail(EmailSendDto emailSendDto);
    }
}
