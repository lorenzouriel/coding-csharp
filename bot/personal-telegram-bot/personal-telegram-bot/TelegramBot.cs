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
        Task BotHandler(); // Alteração da assinatura para retornar uma Task
    }

    public class TelegramService : ITelegramService
    {
        private readonly string _token = "7036690871:AAGLjF9FEkvslxqHbNX3mMDLlVSQ7iFYf4Q";
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
                    //case "/photo":
                    //    await SendDocument(message);
                    //    break;
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
                    InlineKeyboardButton.WithCallbackData("1.1", "11"),
                    InlineKeyboardButton.WithCallbackData("1.2", "12"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData("2.1", "21"),
                    InlineKeyboardButton.WithCallbackData("2.2", "22"),
                }
            });
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Choose",
                replyMarkup: inlineKeyboard
            );
        }

        private static async Task SendReplyKeyboard(Message message)
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "1.1", "1.2" },
                new KeyboardButton[] { "2.1", "2.2" },
            })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Choose",
                replyMarkup: replyKeyboardMarkup
            );
        }

        //private static async Task SendDocument(Message message)
        //{
        //    await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

        //    const string filePath = @"C:\Users\eriks\Desktop\erik.jpg";
        //    using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        //    var fileName = Path.GetFileName(filePath);
        //    await botClient.SendPhotoAsync(
        //        chatId: message.Chat.Id,
        //        photo: new Telegram.Bot.Types.InputFiles.InputOnlineFile(fileStream, fileName),
        //        caption: "Bonitão você hein!"
        //    );
        //}

        private static async Task RequestContactAndLocation(Message message)
        {
            var requestReplyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                KeyboardButton.WithRequestLocation("Location"),
                KeyboardButton.WithRequestContact("Contact"),
            });
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Who or Where are you?",
                replyMarkup: requestReplyKeyboard
            );
        }

        private static async Task SendStaticFullContact(Message message)
        {
            await botClient.SendContactAsync(
                chatId: message.Chat.Id,
                phoneNumber: "+1234567890",
                firstName: "Han",
                vCard: "BEGIN:VCARD\n" +
                       "VERSION:3.0\n" +
                       "N:Solo;Han\n" +
                       "ORG:Scruffy-looking nerf herder\n" +
                       "TEL;TYPE=voice,work,pref:+1234567890\n" +
                       "EMAIL:hansolo@mfalcon.com\n" +
                       "END:VCARD"
            );
        }

        private static async Task SendStaticSimpleContact(Message message)
        {
            await botClient.SendContactAsync(
                chatId: message.Chat.Id,
                phoneNumber: "+1234567890",
                firstName: "Han",
                lastName: "Solo"
            );
        }

        private static async Task SendStaticFullLocation(Message message)
        {
            await botClient.SendVenueAsync(
                chatId: message.Chat.Id,
                latitude: 50.0840172f,
                longitude: 14.418288f,
                title: "Man Hanging out",
                address: "Husova, 110 00 Staré Město, Czechia"
            );
        }

        private static async Task SendStaticLocationSimple(Message message)
        {
            await botClient.SendLocationAsync(
                chatId: message.Chat.Id,
                latitude: 50.0840172f,
                longitude: 14.418288f
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
            const string usage = "Olá, segue nossas opções:\n" +
                                 "/inline   - mostra ooções na linha\n" +
                                 "/keyboard - mostra um teclado personalizado com opções\n" +
                                 "/photo    - envia uma foto\n" +
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
