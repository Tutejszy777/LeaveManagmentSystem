
using System.Net.Mail;

namespace LeaveManagmentSystem.Web.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var FromAddress = _configuration["EmailSetting:DefaultEmailAddress"];
            var smtpServer = _configuration["EmailSetting:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSetting:Port"]);
            var message = new MailMessage
            {
                From = new MailAddress(FromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(smtpServer, smtpPort);
            await client.SendMailAsync(message);
        }
    }
}
