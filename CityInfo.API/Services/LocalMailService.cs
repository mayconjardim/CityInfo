namespace CityInfo.API.Services
{
    public class LocalMailService
    {

        private string _mailTo = "admin@teste.com";
        private string _mailFrom = "noreply@teste.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Email de {_mailFrom} para {_mailTo}, "
                + $"with {nameof(LocalMailService)}.");
            Console.WriteLine($"Assunto: {subject}");
            Console.WriteLine($"Mensagem: {message}");
        }


    }
}
