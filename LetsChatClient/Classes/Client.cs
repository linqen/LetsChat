using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace LetsChatClient
{

    class Client
    {
        public const int BUFFERSIZE = 1024;
        public const int MYPORT = 62222;
        public const int SERVERPORT = 65444;
        public const string SERVERIP = "127.0.0.1";

        private UdpClient myUdpClient;

        public Client()
        {
            
        }
        public bool Connect()
        {
            myUdpClient = new UdpClient(MYPORT);

            return true;
        }
        public bool Disconnect()
        {

            return true;
        }
        public void SendMessage()
        {
            string message = "Hello World!";
            byte[] bytedMessage = Encoding.UTF8.GetBytes(message);
            IPAddress ipAddress;
            IPAddress.TryParse(SERVERIP, out ipAddress);
            IPEndPoint endpoint = new IPEndPoint(ipAddress, SERVERPORT);
            myUdpClient.Send(bytedMessage, bytedMessage.Length, endpoint);
        }
        public void ReceiveMessages()
        {

        }
    }
}
