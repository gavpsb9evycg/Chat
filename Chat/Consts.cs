namespace Chat
{
    public static class Consts
    {
        public static class Server
        {
            /// <summary>
            /// Server host.
            /// </summary>
            public const string Host = "127.0.0.1";

            /// <summary>
            /// Server port.
            /// </summary>
            public const int Port = 8891;

            public class Message
            {
                public const string Welcome = "The server is running. Waiting for connections...";
            }
        }

        public static class Client
        {
            public const string UserName = "UserName4";

            public static class Message
            {
                public const string Welcome = "Welcome, ";
                public const string EnterYourMessage = "Enter your message: ";
                public const string ConnectionInterrupted = "Connection is interrupted";
                public const string EnteredChat = " entered the chat";
                public const string LeftChat = ": left chat";
            }
        }
    }
}
