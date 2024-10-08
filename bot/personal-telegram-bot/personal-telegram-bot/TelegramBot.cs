using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TesteBotTelegram.Service
{
    public interface ITelegramService
    {
        Task BotHandler();
    }

    public class TelegramService : ITelegramService
    {
        private readonly string _token = "6261428381:AAEMLcnwz-ZoXDk1cAS7qbtTZXiRef4Rz1E";
        static ITelegramBotClient botClient = null!;

        public async Task BotHandler()
        {
            botClient = new TelegramBotClient(_token);

            var me = await botClient.GetMeAsync();
            Console.Title = me.Username;

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions
            );

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message?.Type == MessageType.Text)
            {
                var message = update.Message;

                switch (message.Text.Split(' ').First())
                {
                    case "/inline":
                        await SendInlineKeyboard(message);
                        break;
                    case "/keyboard":
                        await SendReplyKeyboard(message);
                        break;
                    case "/request":
                        await RequestContactAndLocation(message);
                        break;
                    case "/contactFull":
                        await SendStaticFullContact(message);
                        break;
                    case "/contactSimple":
                        await SendStaticSimpleContact(message);
                        break;
                    case "/locationFull":
                        await SendStaticFullLocation(message);
                        break;
                    case "/locationSimple":
                        await SendStaticLocationSimple(message);
                        break;
                    case "/about":
                        await AboutBot(message);
                        break;
                    default:
                        await Usage(message);
                        break;
                }
            }
            else if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery != null)
            {
                var callbackQuery = update.CallbackQuery;
                await botClient.AnswerCallbackQueryAsync(
                    callbackQueryId: callbackQuery.Id,
                    text: $"Received answer {callbackQuery.Data}"
                );

                await botClient.SendTextMessageAsync(
                    chatId: callbackQuery.Message!.Chat.Id,
                    text: $"Received send {callbackQuery.Data}"
                );
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Received error: {exception.Message}");
            return Task.CompletedTask;
        }

        private static async Task SendInlineKeyboard(Message message)
        {
            await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            await Task.Delay(500);

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Opção 1", "Opção 1"),
                    InlineKeyboardButton.WithCallbackData("Opção 2", "Opção 2"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Opção 3", "Opção 3"),
                    InlineKeyboardButton.WithCallbackData("Opção 4", "Opção 4"),
                }
            });
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "ChoOpção 1e",
                replyMarkup: inlineKeyboard
            );
        }

        private static async Task SendReplyKeyboard(Message message)
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "Opção 1", "Opção 2" },
                new KeyboardButton[] { "Opção 3", "Opção 4" }
            })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Escolha o tipo de foto que será enviado:",
                replyMarkup: replyKeyboardMarkup
            );
        }

        private static async Task RequestContactAndLocation(Message message)
        {
            var requestReplyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                KeyboardButton.WithRequestLocation("Location"),
                KeyboardButton.WithRequestContact("Contact"),
            });
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Quem é você e onde você está?",
                replyMarkup: requestReplyKeyboard
            );
        }

        private static async Task SendStaticFullContact(Message message)
        {
            await botClient.SendContactAsync(
                chatId: message.Chat.Id,
                phoneNumber: "+55119999999999",
                firstName: "Lorenzo Uriel",
                vCard: "BEGIN:VCARD\n" +
                       "VERSION:3.0\n" +
                       "N:Uriel;Lorenzo\n" +
                       "ORG:Scruffy-looking nerf herder\n" +
                       "TEL;TYPE=voice,work,pref:+11999999999\n" +
                       "EMAIL:seuemail@gmail.com\n" +
                       "END:VCARD"
            );
        }

        private static async Task SendStaticSimpleContact(Message message)
        {
            await botClient.SendContactAsync(
                chatId: message.Chat.Id,
                phoneNumber: "+5511999999999",
                firstName: "Lorenzo",
                lastName: "Uriel"
            );
        }

        private static async Task SendStaticFullLocation(Message message)
        {
            await botClient.SendVenueAsync(
                chatId: message.Chat.Id,
                latitude: -23.723301f,
                longitude: -46.584602f,
                title: "Rua Doida Cara",
                address: "Rua Doida Cara, 609 - Dias Alves"
            );
        }

        private static async Task SendStaticLocationSimple(Message message)
        {
            await botClient.SendLocationAsync(
                chatId: message.Chat.Id,
                latitude: -23.723301f,
                longitude: -46.584602f
            );
        }

        private static async Task AboutBot(Message message)
        {
            var me = await botClient.GetMeAsync();
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Meu username é: {me.Username} e meu nome é {me.FirstName} {me.LastName}"
            );
        }

        private static async Task Usage(Message message)
        {
            const string usage = "Olá, segue nOpção 1sas opções:\n" +
                                 "/inline   - mOpção 1tra ooções na linha\n" +
                                 "/keyboard - mOpção 1tra um teclado personalizado com opções\n" +
                                 "/request  - pede pra escolher entre enviar o contato ou a localização\n" +
                                 "/contactFull - envia um contato estático com card\n" +
                                 "/contactSimple - envia um contato estático simples\n" +
                                 "/locationFull - envia a localização completa\n" +
                                 "/locationSimple - envia a localização simples\n" +
                                 "/about - sobre o bot";
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }
    }
}
