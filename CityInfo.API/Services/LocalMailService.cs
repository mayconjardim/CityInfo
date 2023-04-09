namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {

        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAdress"];
            _mailFrom = configuration["mailSettings:noreply@mail.com"];
        }


        public void Send(string subject, string message)
        {
            Console.WriteLine($"Email de {_mailFrom} para {_mailTo}, "
                + $"with {nameof(LocalMailService)}.");
            Console.WriteLine($"Assunto: {subject}");
            Console.WriteLine($"Mensagem: {message}");
        }


    }
}
