using System;
using System.Net.Sockets;
using System.Text;
using Chat;

namespace ConsoleChat
{
    /// <summary>
    /// ConsoleClientObject class
    /// </summary>
    public class ConsoleClientObject : ClientObject
    {
        public ConsoleClientObject(TcpClient tcpClient, ConsoleServerObject serverObject) : base(tcpClient, serverObject, false)
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Write message
        /// </summary>
        public override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
