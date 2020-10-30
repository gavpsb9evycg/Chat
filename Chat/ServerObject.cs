using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chat
{
    /// <summary>
    /// ServerObject abstract class.
    /// </summary>
    public abstract class ServerObject : Message
    {
        private static TcpListener tcpListener;

        /// <summary>
        /// All client connections.
        /// </summary>
        private List<ClientObject> clients = new List<ClientObject>();

        /// <summary>
        /// Add client connection.
        /// </summary>
        public void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }

        /// <summary>
        /// Remove client connection.
        /// </summary>
        public void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);

            if (client != null)
                clients.Remove(client);
        }

        /// <summary>
        /// Listen and accept client connections.
        /// </summary>
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, Consts.Server.Port);
                tcpListener.Start();

                WriteMessage(Consts.Server.Message.Welcome);

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = GetClientObject(tcpClient);

                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));

                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Get client object.
        /// </summary>
        public abstract ClientObject GetClientObject(TcpClient tcpClient);

        /// <summary>
        /// Broadcast a message to all connected clients.
        /// </summary>
        public void BroadcastMessage(string message, string id, bool isBroadcastToAll)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);

            for (var i = 0; i < clients.Count; i++)
            {
                if (isBroadcastToAll)
                {
                    clients[i].Stream.Write(data, 0, data.Length);
                }
                else
                {
                    // If client id is not equal to sender id.
                    if (clients[i].Id != id)
                    {
                        clients[i].Stream.Write(data, 0, data.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Disconnect all clients.
        /// </summary>
        public void Disconnect()
        {
            // Stop server.
            tcpListener.Stop();

            for (var i = 0; i < clients.Count; i++)
            {
                // Disconnect client.
                clients[i].Close();
            }

            Environment.Exit(0);
        }
    }
}
