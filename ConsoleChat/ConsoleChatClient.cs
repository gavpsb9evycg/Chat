using System;
using System.Text;
using Chat;

namespace ConsoleChat
{
    /// <summary>
    /// ConsoleChatClient class.
    /// </summary>
    public class ConsoleChatClient : ChatClient
    {
        public ConsoleChatClient()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Send message.
        /// </summary>
        public override void SendMessage()
        {
            while (true)
            {
                string message = Console.ReadLine();
                WriteStream(message);
            }
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
