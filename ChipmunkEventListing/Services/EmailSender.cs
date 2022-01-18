using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChipmunkEventListing.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string mail = "chipmunkseventlisting@gmail.com";
            string password = "ChipmunkEvent2021!";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(mail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;
            // setting up the Smtp Client
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(mail, password),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }

    }
}