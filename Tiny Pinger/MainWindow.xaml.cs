using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Tiny_Pinger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrushConverter converter = new BrushConverter();

        string[] PCList = new string[10];
 
        public MainWindow()
        {
            InitializeComponent();

            PCList[0] = "MAL2HSM17";
        }

        private void Ping_Click(object sender, RoutedEventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            PingReply reply = pingSender.Send(PCList[0], timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                PC1_Data.Background = (Brush)converter.ConvertFromString("#145A32");
                PC1_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else
            {
                PC1_Data.Background = (Brush)converter.ConvertFromString("#641E16");
                PC1_Data.Content = reply.Status.ToString();
            }
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configuration = new ConfigurationWindow();
            configuration.Show();
        }
    }
}
