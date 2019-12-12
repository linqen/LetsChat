using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsChatClient.Classes
{
    class ClientController
    {
        private Client _client;
        public ClientController()
        {
            _client = new Client(this);
        }

        public bool Connect(string name)
        {
            byte[] bytedName = Encoding.UTF8.GetBytes(name);
            return _client.Connect(bytedName);
        }
        public bool Disconnect()
        {
            _client.Disconnect();

            return true;
        }
        public void SendMessage(string message)
        {
            byte[] bytedMessage = Encoding.UTF8.GetBytes(message);
            _client.SendMessage(bytedMessage);
        }
        public void ReceiveMessages()
        {

        }
    }
}
