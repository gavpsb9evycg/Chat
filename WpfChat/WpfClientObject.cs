using Chat;
using System.Net.Sockets;

namespace WpfChat
{
    /// <summary>
    /// WpfClientObject class.
    /// </summary>
    public class WpfClientObject : ClientObject
    {
        private readonly ChatWindow chatWindow;

        public WpfClientObject(TcpClient tcpClient, WpfServerObject serverObject, ChatWindow chatWindow) : base(tcpClient, serverObject, true)
        {
            this.chatWindow = chatWindow;
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
