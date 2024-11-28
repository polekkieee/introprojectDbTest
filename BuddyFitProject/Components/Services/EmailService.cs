using SendGrid.Helpers.Mail;
using SendGrid;

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
            var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);
            var from = new EmailAddress("e.s.hemmers@students.uu.nl", "Liesbeth");
            var to = new EmailAddress(toEmail, "Dear BuddyFitter");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
