namespace TesteBotTelegram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crie uma instância do seu serviço e chame o método BotHandler
            var telegramService = new Service.TelegramService();
            telegramService.BotHandler();

            // Mantém o console aberto até que uma tecla seja pressionada
            Console.ReadLine();
        }
    }
}
