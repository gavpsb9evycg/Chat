using System;
using System.Threading;

namespace Chat
{
    /// <summary>
    /// ChatServer abstract class
    /// </summary>
    public abstract class ChatServer : Message
    {
        private static ServerObject server;
        private static Thread listenThread;

        /// <summary>
        /// Start chat server
        /// </summary>
        public void Start()
        {
            try
            {
                server = GetServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                server.Disconnect();
            }
        }

        /// <summary>
        /// Get server object
        /// </summary>
        public abstract ServerObject GetServerObject();
    }
}
