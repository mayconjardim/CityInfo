namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {

        private string _mailTo = "admin@teste.com";
        private string _mailFrom = "noreply@teste.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Email Cloud de {_mailFrom} para {_mailTo}, "
                + $"with {nameof(CloudMailService)}.");
            Console.WriteLine($"Assunto: {subject}");
            Console.WriteLine($"Mensagem: {message}");
        }


    }
}