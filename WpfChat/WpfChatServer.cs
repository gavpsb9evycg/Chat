using Chat;

namespace WpfChat
{
    /// <summary>
    /// WpfChatServer class.
    /// </summary>
    public class WpfChatServer : ChatServer
    {
        private readonly ChatWindow chatWindow;

        public WpfChatServer(ChatWindow chatWindow)
        {
            this.chatWindow = chatWindow;
        }

        /// <summary>
        /// Get server object.
        /// </summary>
        public override ServerObject GetServerObject()
        {
            return new WpfServerObject(chatWindow);
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
