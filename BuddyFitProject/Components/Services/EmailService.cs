using SendGrid.Helpers.Mail;
using SendGrid;
using BuddyFitProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyFitProject.Components.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            string resetCode = GenerateRandomCode();
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail, "Dear BuddyFitter");
            var plainTextContent = $"{resetCode}";
            var htmlContent = $"<strong>{resetCode}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        private string GenerateRandomCode()
        {
            const string chars = "0123456789";
            Random random = new();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
