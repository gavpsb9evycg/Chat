using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chat
{
    /// <summary>
    /// ChatClient abstract class
    /// </summary>
    public abstract class ChatClient : Message
    {
        private static TcpClient client;
        private static NetworkStream stream;

        /// <summary>
        /// Start chat client
        /// </summary>
        public void Start()
        {
            try
            {
                client = new TcpClient();
                client.Connect(Consts.Server.Host, Consts.Server.Port);
                stream = client.GetStream();

                byte[] data = Encoding.Unicode.GetBytes(Consts.Client.UserName);
                stream.Write(data, 0, data.Length);

                //start a new thread to receive data
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                
                WriteMessage(Consts.Client.Message.Welcome + Consts.Client.UserName);

                WriteMessage(Consts.Client.Message.EnterYourMessage);
                SendMessage();
            }
            catch (Exception ex)
            {
                WriteMessage(ex.Message);
            }
            finally
            {
                //Disconnect();
            }
        }

        /// <summary>
        /// Send client message
        /// </summary>
        public abstract void SendMessage();

        /// <summary>
        /// Write stream
        /// </summary>
        public void WriteStream(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Receive client message
        /// </summary>
        public void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    //buffer for received data
                    byte[] data = new byte[64];

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    WriteMessage(message);
                }
                catch
                {
                    WriteMessage(Consts.Client.Message.ConnectionInterrupted);
                    Disconnect();
                }
            }
        }

        /// <summary>
        /// Disconnect client
        /// </summary>
        public void Disconnect()
        {
            //close stream
            if (stream != null)
                stream.Close();

            //close client
            if (client != null)
                client.Close();
            
            //close process
            //Environment.Exit(0);
        }
    }
}
