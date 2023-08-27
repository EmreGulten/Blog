using Blog.Entity.DTOs.Email;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Blog.Service.Services.Concrete
{
    public class MailService : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailService(IOptions<SmtpSettings> options)
        {
            _smtpSettings = options.Value;
        }
        
        public async Task<string> SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress("emregulten035@gmail.com") },
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = $"Gönderen Kişi: {emailSendDto.Name}, Gönderen E-Posta Adresi:{emailSendDto.Email} , Gönderen Tel.No : {emailSendDto.Phone}<br/>{emailSendDto.Message}"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            await smtpClient.SendMailAsync(mailMessage);
            return "E-Postanız başarıyla gönderilmiştir.";

        }
    }
}
