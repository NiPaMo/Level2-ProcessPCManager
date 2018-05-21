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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            PingReply reply = pingSender.Send(PCList[0], timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                PC1.Background = (Brush)converter.ConvertFromString("#145A32");
                PC1.Text = reply.Address.ToString() + "\n" +
                    reply.RoundtripTime + "\n";
            }
            else
            {
                PC1.Background = (Brush)converter.ConvertFromString("#641E16");
            }
        }
    }
}
