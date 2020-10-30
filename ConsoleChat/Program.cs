//#define SERVER
#define CLIENT

namespace ConsoleChat
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #if (SERVER)
                // Start chat server.
                new ConsoleChatServer().Start();
            #endif

            #if (CLIENT)
                // Start chat client.
                new ConsoleChatClient().Start();
            #endif
        }
    }
}
