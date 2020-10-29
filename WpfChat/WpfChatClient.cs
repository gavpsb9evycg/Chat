using System;
using Chat;

namespace WpfChat
{
    /// <summary>
    /// WpfChatClient class
    /// </summary>
    public class WpfChatClient : ChatClient
    {
        private ChatWindow chatWindow;
        private string messageEntered;

        public WpfChatClient(ChatWindow chatWindow)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            this.chatWindow = chatWindow;
            this.chatWindow.MessageEntered += OnMessageEntered;
        }

        private void OnMessageEntered(object sender, string messageEntered)
        {
            this.messageEntered = messageEntered;
            SendMessage();
        }

        /// <summary>
        /// Send message
        /// </summary>
        public override void SendMessage()
        {
            if(messageEntered == null)
                return;

            WriteStream(messageEntered);
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
