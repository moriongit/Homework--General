namespace WebApplication2.ExternalServices.Interfaces
{
	public interface IEmailService
	{
		 void Send(string toMail, string header,string body, bool isHtml = true)
		{
			throw new NotImplementedException();
		}
	}
}
