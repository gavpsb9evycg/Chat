using System;
using System.Net.Sockets;
using System.Text;

namespace Chat
{
    /// <summary>
    /// ClientObject abstract class.
    /// </summary>
    public abstract class ClientObject : Message
    {
        /// <summary>
        /// Client id.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Client stream.
        /// </summary>
        public NetworkStream Stream { get; private set; }

        private string userName;
        private readonly TcpClient client;
        private readonly ServerObject server;
        private readonly bool isBroadcastToAll;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject, bool isBroadcastToAll)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            this.isBroadcastToAll = isBroadcastToAll;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();

                // Get username.
                String message = GetMessage();
                userName = message;

                message = userName + Consts.Client.Message.EnteredChat;

                // Send a message about entering the chat to all connected users.
                server.BroadcastMessage(message, this.Id, isBroadcastToAll);
                WriteMessage(message);

                // We receive messages from the client in an endless loop.
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = $"{userName}: {message}";
                        WriteMessage(message);
                        server.BroadcastMessage(message, this.Id, isBroadcastToAll);
                    }
                    catch
                    {
                        message = userName + Consts.Client.Message.LeftChat;
                        WriteMessage(message);
                        server.BroadcastMessage(message, this.Id, isBroadcastToAll);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteMessage(ex.Message);
            }
            finally
            {
                // In case of exiting the loop, close the resources.
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        /// <summary>
        /// Get incoming message and convert to string.
        /// </summary>
        private string GetMessage()
        {
            // Buffer for received data.
            var data = new byte[64];
            
            var builder = new StringBuilder();

            do
            {
                Int32 bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        /// <summary>
        /// Close connection.
        /// </summary>
        public void Close()
        {
            if (Stream != null)
                Stream.Close();

            if (client != null)
                client.Close();
        }
    }
}
