using System;
using System.Net.Sockets;
using System.Text;
using Chat;

namespace ConsoleChat
{
    /// <summary>
    /// ConsoleServerObject class.
    /// </summary>
    public class ConsoleServerObject : ServerObject
    {
        public ConsoleServerObject()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Get client object.
        /// </summary>
        public override ClientObject GetClientObject(TcpClient tcpClient)
        {
            return new ConsoleClientObject(tcpClient, this);
        }

        /// <summary>
        /// Write message.
        /// </summary>
        public override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
