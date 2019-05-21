using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LetsChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client myClient;
        public MainWindow()
        {
            InitializeComponent();
            ConnectButton.Click += ConnectButton_Click;
            SendMessageButton.Click += SendMessageButton_Click;
        }


        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            myClient = new Client();
            myClient.Connect();
            ConnectButton.IsEnabled = false;
        }
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            myClient.SendMessage();
        }

    }
}
