using Chat;

namespace WpfChat
{
    /// <summary>
    /// WpfChatClient class.
    /// </summary>
    public class WpfChatClient : ChatClient
    {
        private readonly ChatWindow chatWindow;
        private string messageEntered;

        public WpfChatClient(ChatWindow chatWindow)
        {
            this.chatWindow = chatWindow;
            this.chatWindow.MessageEntered += (s, e) =>
            {
                this.messageEntered = e;
                SendMessage();
            };
        }

        /// <summary>
        /// Send message.
        /// </summary>
        public override void SendMessage()
        {
            if(messageEntered == null)
                return;

            WriteStream(messageEntered);
        }

        /// <summary>
        /// Write message.
        /// </summary>
        public override void WriteMessage(string message)
        {
            chatWindow.AddMessage(message);
        }
    }
}
