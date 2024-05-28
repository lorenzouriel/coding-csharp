using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Resources;
using Geosiga.Bot.Tasker.Library.Models;

namespace Geosiga.Bot.Tasker.Library
{
    /// <summary>
    /// Class that represents the Telegram bot engine.
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// TelegramBot client used to communicate with the Telegram API.
        /// </summary>
        public static TelegramBotClient Bot { get; private set; }

        /// <summary>
        /// Method to start bot execution.
        /// </summary>
        /// <param name="token">Bot Access Token.</param>
        public static void Start(string token)
        {
            Bot = new TelegramBotClient(token);

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnReceiveError += Bot_OnReceiveError;

            Bot.StartReceiving();

            //Console.WriteLine($"Iniciando a escuta para o bot com token {token}");
            Console.ReadLine();
        }

        /// <summary>
        /// Event handler for new messages received by the bot.
        /// </summary>
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

        /// <summary>
        /// Method for requesting user contact.
        /// </summary>
        private static async Task RequestContact(long chatId)
        {
            // Create a response keyboard with a contact request button.
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

            // Defines an event handler for receiving the contact
            Bot.OnMessage -= ContactHandler;
            Bot.OnMessage += ContactHandler;

            // Event handler to process incoming contact
            async void ContactHandler(object sender, MessageEventArgs e)
            {
                var userMessage = e.Message;
                if (userMessage == null || userMessage.Type != MessageType.Contact)
                    return;

                var firstName = userMessage.Contact.FirstName;
                var phoneNumber = userMessage.Contact.PhoneNumber;

                // Creates a new chat object with worker information
                var chat = new Chat
                {
                    Worker = new Worker
                    {
                        HasWorkerInfo = true,
                        WorkerName = firstName,
                        WorkerPhone = phoneNumber
                    }
                };

                // Sends welcome message and requests location
                await WelcomeMessage(chatId, firstName);
                await RequestLocation(chatId, chat);

                // Remove event handler after use
                Bot.OnMessage -= ContactHandler;
            }
        }

        /// <summary>
        /// Method for sending welcome message.
        /// </summary>
        private static async Task WelcomeMessage(long chatId, string taskerName)
        {
            string message = string.Format(Resources.WelcomeMessage, taskerName);
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: message
            );
        }

        /// <summary>
        /// Method for requesting the user's location.
        /// </summary>
        private static async Task RequestLocation(long chatId, Chat chat)
        {
            // Create a response keyboard with location request button
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

            // Defines an event handler for receiving the location
            Bot.OnMessage -= LocationHandler;
            Bot.OnMessage += LocationHandler;

            // Event handler to process the received location
            async void LocationHandler(object sender, MessageEventArgs e)
            {
                var userMessage = e.Message;
                if (userMessage == null || userMessage.Type != MessageType.Location)
                    return;

                var latitude = userMessage.Location.Latitude;
                var longitude = userMessage.Location.Longitude;

                chat.Worker.WorkerLatitude = latitude;
                chat.Worker.WorkerLongitude = longitude;

                await Bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Localização salva:\nLatitude: {latitude}\nLongitude: {longitude}"
                );

                // Remove o manipulador de eventos após o uso
                Bot.OnMessage -= LocationHandler;
            }
        }

        /// <summary>
        /// Method to restart the conversation with the user.
        /// </summary>
        private static async Task RestartChat(long chatId)
        {
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.RestartMessage
            );
        }

        /// <summary>
        /// Method for sending initial use message and capturing out-of-scope messages.
        /// </summary>
        private static async Task Usage(long chatId)
        {
            await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: Resources.ErrorMessage //StartMessage
            );
        }

        /// <summary>
        /// Event handler to handle receive errors.
        /// </summary>
        private static void Bot_OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            Console.WriteLine(Resources.ErrorMessage);
        }
    }
}
