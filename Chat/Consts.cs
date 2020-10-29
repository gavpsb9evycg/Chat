using System;

namespace Chat
{
    public class Consts
    {
        public class Server
        {
            /// <summary>
            /// Server host
            /// </summary>
            public const string Host = "127.0.0.1";

            /// <summary>
            /// Server port
            /// </summary>
            public const int Port = 8891;

            public class Message
            {
                /// <summary>
                /// Message: The server is running. Waiting for connections...
                /// </summary>
                public const string Welcome = "The server is running. Waiting for connections..."; // / Der server läuft. Warten auf verbindungen...
            }
        }

        public class Client
        {
            /// <summary>
            /// Client UserName
            /// </summary>
            public const string UserName = "UserName4";

            public class Message
            {
                /// <summary>
                /// Message: Welcome
                /// </summary>
                public const string Welcome = "Welcome, "; // / Willkommen

                /// <summary>
                /// Message: Enter your message
                /// </summary>
                public const string EnterYourMessage = "Enter your message: "; // / Geben Sie Ihre Nachricht ein

                /// <summary>
                /// Message: Connection is interrupted
                /// </summary>
                public const string ConnectionInterrupted = "Connection is interrupted"; // / Verbindung wird unterbrochen

                /// <summary>
                /// Message: entered the chat
                /// </summary>
                public const string EnteredChat = " entered the chat"; // / betraten den Chat

                /// <summary>
                /// Message: left chat
                /// </summary>
                public const string LeftChat = ": left chat"; // / verließ den Chat
            }
        }
    }
}
