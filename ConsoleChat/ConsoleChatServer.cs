using System;
using System.Text;
using Chat;

namespace ConsoleChat
{
    /// <summary>
    /// ConsoleChatServer class.
    /// </summary>
    public class ConsoleChatServer : ChatServer
    {
        /// <summary>
        /// Get server object.
        /// </summary>
        public override ServerObject GetServerObject()
        {
            Console.OutputEncoding = Encoding.UTF8;
            return new ConsoleServerObject();
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
