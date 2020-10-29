using System;
using System.Net.Sockets;
using System.Text;
using Chat;

namespace WpfChat
{
    /// <summary>
    /// WpfClientObject class
    /// </summary>
    public class WpfClientObject : ClientObject
    {
        private ChatWindow chatWindow;

        public WpfClientObject(TcpClient tcpClient, WpfServerObject serverObject, ChatWindow chatWindow) : base(tcpClient, serverObject, true)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            this.chatWindow = chatWindow;
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
