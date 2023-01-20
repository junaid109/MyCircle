namespace MyCircle.API.Contracts
{
	public interface IEmailService
	{
		Task SendEmailAsync(string email, string subject, string message, string sender, string apiKey);
		
		

	}
}
