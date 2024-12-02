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
        public EmailService(IConfiguration configuration, ValidateUserService resetPasswordService)
        {
            _configuration = configuration;
            this.resetPasswordService = resetPasswordService;
        }

        public async Task SendEmailResetPassword(string toEmail, string subject, string body, string resetcode)
        {
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail, "Dear BuddyFitter");
            var plainTextContent = $"{resetcode}";
            var htmlContent = $"<strong>{resetcode}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendEmailValidateEmail(string toEmail, string subject, string body, string validatecode)
        {
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail, "Dear BuddyFitter");
            var plainTextContent = $"{validatecode}";
            var htmlContent = $"<strong>{validatecode}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
