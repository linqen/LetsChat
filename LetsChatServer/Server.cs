using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace LetsChatServer
{
    class Server
    {
        public const int BUFFERSIZE = 1024;

        private List<Client> _clients;
        private Thread _executionThread;
        private UdpClient myUdpClient;
        //private Socket _serverChatSocket;
        public void Initialize()
        {
            _clients = new List<Client>();
            myUdpClient = new UdpClient(65444);

            _executionThread = new Thread(ServerWork);
            _executionThread.Start();
            //_serverChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
        }
        public void Shutdown()
        {
            for (int i = 0; i < _clients.Count(); i++)
            {
                //NotifyClients Server go down
            }
            _executionThread.Abort();
            myUdpClient.Close();
            //_serverChatSocket.Disconnect(true);
        }
        public void Reboot()
        {
            Shutdown();
            Initialize();
        }

        private void ServerWork()
        {
            //byte[] buffer = new byte[BUFFERSIZE];
            string message;
            IPEndPoint remoteclient = new IPEndPoint(IPAddress.Any, 65444);
            myUdpClient.Client.ReceiveTimeout = 150;
            while (true)
            {
                byte[] buffer;
                try
                {
                    buffer = myUdpClient.Receive(ref remoteclient);
                    message = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("From: {0}", remoteclient.ToString());
                    Console.WriteLine(" Message: {0} ", message);

                    int i = 2;

                }
                catch(SocketException e)
                {
                    Thread.Sleep(500);
                }

                //Listen to sockets
            }
        }

        private void OnClientConnect()
        {

        }
        private void OnClientDisconnect()
        {

        }
        private void OnClientTimeout()
        {

        }
        private void ShowMessage()
        {

        }
    }
}
