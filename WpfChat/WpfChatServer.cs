using Chat;

namespace WpfChat
{
    /// <summary>
    /// WpfChatServer class
    /// </summary>
    public class WpfChatServer : ChatServer
    {
        private ChatWindow chatWindow;

        public WpfChatServer(ChatWindow chatWindow)
        {
            this.chatWindow = chatWindow;
        }

        /// <summary>
        /// Get server object
        /// </summary>
        public override ServerObject GetServerObject()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            return new WpfServerObject(chatWindow);
        }

        /// <summary>
        /// Write message
        /// </summary>
        public override void WriteMessage(string message)
        {
            chatWindow.AddMessage(message);
        }
    }
}
