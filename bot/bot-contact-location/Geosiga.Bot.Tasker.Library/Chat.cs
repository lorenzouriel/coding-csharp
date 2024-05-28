using Geosiga.Bot.Tasker.Library.Models;

namespace Geosiga.Bot.Tasker.Library
{
    /// <summary>
    /// Represents a chat session within the tasker library.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// The active service order associated with the chat.
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// The asset related to the service order.
        /// </summary>
        public Asset Asset { get; set; }

        /// <summary>
        /// The device(s) associated with the service.
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// The worker responsible for interacting with the chat.
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// The reason for the service.
        /// </summary>
        public Reason Reason { get; set; }
    }
}
