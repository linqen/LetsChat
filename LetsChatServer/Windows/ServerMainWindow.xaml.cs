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

namespace LetsChatServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Server _server;
        public MainWindow()
        {
            InitializeComponent();
            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            StopButton.IsEnabled = false;
            StatusLabel.Content = "Off";
            StatusLabel.Foreground = Brushes.Red;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopServer();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            StatusLabel.Content = "Off";
            StatusLabel.Foreground = Brushes.Red;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartServer();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            StatusLabel.Content = "On";
            StatusLabel.Foreground = Brushes.Green;
        }

        private void StartServer()
        {
            _server = new Server();
            _server.Initialize();
        }
        private void StopServer()
        {
            _server.Shutdown();
        }
        private void RebootServer()
        {
            _server.Reboot();
        }
    }
}
