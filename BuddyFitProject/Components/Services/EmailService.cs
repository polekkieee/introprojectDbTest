using SendGrid.Helpers.Mail;
using SendGrid;
using BuddyFitProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyFitProject.Components.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        ValidateUserService resetPasswordService;
        public EmailService(IConfiguration configuration, ValidateUserService resetPasswordService) //Contructor that initialize the configuration and the resetpasswordservice
        {
            _configuration = configuration;
            this.resetPasswordService = resetPasswordService;
        }

        public async Task SendEmailResetPassword(string toEmail, string subject, string body, string resetcode) //Logic to send email, this code was originally from chatgpt, but I had to change it significantly. I tested it by trying to send an email again and again, until I fixed all the errors and it worked.
        {
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]); //Creates a sendgrid client
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail);
            var plainTextContent = $"{resetcode}"; //Defines the plaintext content of the email 
            var htmlContent = $"<strong>{resetcode}</strong>"; //Defines the HTML content
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent); //Creates the email message
            var response = await client.SendEmailAsync(msg); //Sends the email
        }
    }
}
