using Telegram.Bot;

var botClient = new TelegramBotClient("6261428381:AAEMLcnwz-ZoXDk1cAS7qbtTZXiRef4Rz1E");

var me = await botClient.GetMeAsync();
Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
