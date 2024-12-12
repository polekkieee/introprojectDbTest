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
        public EmailService(IConfiguration configuration, ValidateUserService resetPasswordService) //Contructor the initialize the configuration and resetpasswordservice
        {
            _configuration = configuration;
            this.resetPasswordService = resetPasswordService;
        }

        public async Task SendEmailResetPassword(string toEmail, string subject, string body, string resetcode) //Logic to send email, this code was originally from chatgpt, but I had to change it significantly
        {
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]); //Create a sendgrid client
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail, "Dear BuddyFitter");
            var plainTextContent = $"{resetcode}"; //Defining the plaintext content of the email 
            var htmlContent = $"<strong>{resetcode}</strong>"; //Defining the HTML content
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent); //Create the email message
            var response = await client.SendEmailAsync(msg); //Send the email
        }
    }
}
