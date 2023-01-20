using MyCircle.API.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MyCircle.API.Services
{
	public class EmailService : IEmailService
	{
		public SendGridClient client { get; set; }

		public Task SendEmailAsync(string email, string subject, string message, string sender, string apiKey)
		{
			client = new SendGridClient(apiKey);
			{
				var msg = new SendGridMessage()
				{
					From = new EmailAddress(email, sender),
					Subject = subject,
					PlainTextContent = message,
					HtmlContent = message
				};
				msg.AddTo(new EmailAddress(email));
				return client.SendEmailAsync(msg);
			}
		}
	}
}
