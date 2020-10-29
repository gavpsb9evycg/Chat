using Chat;
using System.Net.Sockets;

namespace WpfChat
{
    /// <summary>
    /// WpfServerObject class
    /// </summary>
    public class WpfServerObject : ServerObject
    {
        private ChatWindow chatWindow;

        public WpfServerObject(ChatWindow chatWindow)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            this.chatWindow = chatWindow;
        }

        /// <summary>
        /// Get client object
        /// </summary>
        public override ClientObject GetClientObject(TcpClient tcpClient)
        {
            return new WpfClientObject(tcpClient, this, chatWindow);
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
