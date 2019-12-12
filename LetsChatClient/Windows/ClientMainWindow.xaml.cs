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
using LetsChatClient.Classes;

namespace LetsChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientController _clientController;
        public MainWindow()
        {
            InitializeComponent();
            ConnectButton.Click += ConnectButton_Click;
            SendMessageButton.Click += SendMessageButton_Click;


            ConnectButton.IsEnabled = true;
            MessageBox.IsEnabled = false;
            SendMessageButton.IsEnabled = false;

        }


        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            _clientController = new ClientController();
            if (_clientController.Connect(SelectedName.Text))
            {
                SelectedName.IsEnabled = false;
                ConnectButton.IsEnabled = false;
                MessageBox.IsEnabled = true;
                SendMessageButton.IsEnabled = true;
            }

        }
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            _clientController.SendMessage(MessageBox.Text);
            MessageBox.Clear();
        }

    }
}
