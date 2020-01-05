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
        public const int CLIENTPORT = 62222;
        public const int MYPORT = 65444;

        
        private List<Client> _clients;
        private Thread _executionThread;
        private UdpClient _myUdpClientSender;
        private UdpClient _myUdpClientReciver;
        //private Socket _serverChatSocket;
        public void Initialize()
        {
            _clients = new List<Client>();
            _myUdpClientReciver = new UdpClient(MYPORT);
            _myUdpClientSender = new UdpClient();

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
            _myUdpClientSender.Close();
            _myUdpClientReciver.Close();
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
            IPEndPoint remoteclient = new IPEndPoint(IPAddress.Any, 62222);
            _myUdpClientReciver.Client.ReceiveTimeout = 150;
            _myUdpClientSender.Client.ReceiveTimeout = 150;

            while (true)
            {
                byte[] buffer;
                try
                {
                    buffer = _myUdpClientReciver.Receive(ref remoteclient);
                    _myUdpClientSender.Send(Encoding.UTF8.GetBytes("true"), 4, remoteclient.Address.ToString(), CLIENTPORT);
                    message = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("From: {0}", remoteclient.ToString());
                    Console.WriteLine(" Message: {0} ", message);


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
