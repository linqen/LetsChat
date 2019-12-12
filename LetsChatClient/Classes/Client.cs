using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace LetsChatClient.Classes
{

    class Client
    {
        public const int BUFFERSIZE = 1024;
        public const int MYPORT = 62222;
        public const int SERVERPORT = 65444;
        public const string SERVERIP = "127.0.0.1";

        private UdpClient _myUdpClientSender;
        private UdpClient _myUdpClientReciver;
        private ClientController _myController;
        private IPAddress ipAddress;
        private IPEndPoint endpoint;
        public Client(ClientController clientController)
        {
            _myController = clientController;
        }
        public bool Connect(byte[] name)
        {
            _myUdpClientReciver = new UdpClient(MYPORT);
            
            _myUdpClientSender = new UdpClient();
            IPAddress.TryParse(SERVERIP, out ipAddress);
            endpoint = new IPEndPoint(ipAddress, SERVERPORT);
            _myUdpClientSender.Send(name, name.Length, endpoint);

            bool clientAccepted = false;
            try
            {
                //TODO: A location of the server thread needs to be done here, when the server receive new client
                _myUdpClientReciver.Client.ReceiveTimeout = 5000; //Timeout setted to five seconds
                byte[] confirmationMessage = _myUdpClientReciver.Receive(ref endpoint);
                string confirmationMessageString = Encoding.UTF8.GetString(confirmationMessage);
                Boolean.TryParse(confirmationMessageString, out clientAccepted);

            }catch(SocketException e)
            {
                clientAccepted = false;
            }
            _myUdpClientSender.Client.ReceiveTimeout = 0;

            return clientAccepted;
        }
        public bool Disconnect()
        {

            return true;
        }
        public void SendMessage(byte[] message)
        {
            _myUdpClientSender.Send(message, message.Length, endpoint);
        }
        private void ReceiveMessages()
        {

            _myController.ReceiveMessages();
        }
    }
}
