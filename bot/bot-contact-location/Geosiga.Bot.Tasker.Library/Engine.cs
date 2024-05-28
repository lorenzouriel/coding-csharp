using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Resources;

namespace Geosiga.Bot.Tasker.Library
{
    public static class Engine
    {
        public static TelegramBotClient Bot { get; private set; }

        public static void Start(string token)
        {
            Bot = new TelegramBotClient(token);

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnReceiveError += Bot_OnReceiveError;

            Bot.StartReceiving();

            Console.WriteLine($"Start listening for bot with token {token}");
            Console.ReadLine();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text)
                return;

            var chatId = message.Chat.Id;
            var messageText = message.Text.Split(' ').First();

            if (messageText.Equals(Resources.StartCommand))
            {
                await RequestContact(chatId);
                return;
            }

            if (messageText.Equals(Resources.RestartCommand))
            {
                await RestartChat(chatId);
                return;
            }

            await Usage(chatId);
        }

        private static async Task RequestContact(long chatId)
        {
            var requestReplyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    KeyboardButton.WithRequestContact(Resources.RequestContactButtonText)
                }
            })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.RequestContactText,
                replyMarkup: requestReplyKeyboard
            );

            Bot.OnMessage -= ContactHandler;
            Bot.OnMessage += ContactHandler;

            async void ContactHandler(object sender, MessageEventArgs e)
            {
                var userMessage = e.Message;
                if (userMessage == null || userMessage.Type != MessageType.Contact)
                    return;

                var firstName = userMessage.Contact.FirstName;
                var phoneNumber = userMessage.Contact.PhoneNumber;

                var chat = new Chat
                {
                    HasWorkerInfo = true,
                    WorkerName = firstName,
                    WorkerPhone = phoneNumber
                };

                await WelcomeMessage(chatId, firstName);
                await RequestLocation(chatId, chat);
            }
        }

        private static async Task WelcomeMessage(long chatId, string taskerName)
        {
            string message = string.Format(Resources.WelcomeMessage, taskerName);
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: message
            );
        }

        private static async Task RequestLocation(long chatId, Chat chat)
        {
            var requestReplyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    KeyboardButton.WithRequestLocation(Resources.RequestLocationButtonText)
                }
            })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.RequestLocationText,
                replyMarkup: requestReplyKeyboard
            );

            Bot.OnMessage -= LocationHandler;
            Bot.OnMessage += LocationHandler;

            async void LocationHandler(object sender, MessageEventArgs e)
            {
                var userMessage = e.Message;
                if (userMessage == null || userMessage.Type != MessageType.Location)
                    return;

                var latitude = userMessage.Location.Latitude;
                var longitude = userMessage.Location.Longitude;

                chat.WorkerLatitude = latitude;
                chat.WorkerLongitude = longitude;

                await Bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Localização salva:\nLatitude: {latitude}\nLongitude: {longitude}"
                );

                // Bot.StopReceiving();
            }
        }

        private static async Task RestartChat(long chatId)
        {
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.RestartMessage
            );
        }

        private static async Task Usage(long chatId)
        {
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.StartMessage
            );
        }

        private static void Bot_OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            Console.WriteLine(Resources.ErrorMessage);
        }
    }
}