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
        private readonly string _token = "";
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
                    InlineKeyboardButton.WithCallbackData("OS", "OS"),
                    InlineKeyboardButton.WithCallbackData("Foto do Serviço", "Foto do Serviço"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Aparelho Retirado", "Aparelho Retirado"),
                    InlineKeyboardButton.WithCallbackData("Aparelho Instalado", "Aparelho Instalado"),
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
                new KeyboardButton[] { "OS", "Foto do Serviço" },
                new KeyboardButton[] { "Aparelho Retirado", "Aparelho Instalado" }
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
//        static async Task SendDocument(Message message)
//        {
//            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
//{
//                new KeyboardButton[] { "Ordem de Serviço Assinada", "Foto do Serviço" },
//            })
//            {
//                ResizeKeyboard = true
//            };

//            await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

//            const string filePath = @"C:\Users\eriks\Desktop\erik.jpg";
//            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

//            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

//            await botClient.SendPhotoAsync(
//                chatId: message.Chat.Id,
//                photo: new InputOnlineFile(fileStream, fileName),
//                replyMarkup: replyKeyboardMarkup

//            );
//        }

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
                phoneNumber: "+5511947788209",
                firstName: "Lorenzo Uriel",
                vCard: "BEGIN:VCARD\n" +
                       "VERSION:3.0\n" +
                       "N:Uriel;Lorenzo\n" +
                       "ORG:Scruffy-looking nerf herder\n" +
                       "TEL;TYPE=voice,work,pref:+11947788209\n" +
                       "EMAIL:lorenzouriel394@gmail.com\n" +
                       "END:VCARD"
            );
        }

        private static async Task SendStaticSimpleContact(Message message)
        {
            await botClient.SendContactAsync(
                chatId: message.Chat.Id,
                phoneNumber: "+5511947788209",
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
                title: "Rua Alexandre Bonício",
                address: "Rua Alexandre Bonício, 609 - Alves Dias"
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
