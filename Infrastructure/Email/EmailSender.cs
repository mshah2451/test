using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Email
{
    public class EmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string userEmail, string emailSubject, string msg)
        {
          var config=  _config["SendGrid:Key"];
            config = "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";
            var client = new SendGridClient(config);
            var message = new SendGridMessage
            {
                From = new EmailAddress("trycatchlearn@outlook.com", _config["Sendgrid:User"]),
                Subject = emailSubject,
                PlainTextContent = msg,
                HtmlContent = msg
            };
            message.AddTo(new EmailAddress(userEmail));
            message.SetClickTracking(false, false);

            await client.SendEmailAsync(message);
        }
    }
}