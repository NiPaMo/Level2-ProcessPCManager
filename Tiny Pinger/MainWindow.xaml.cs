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

        Config config;
        PingReply reply;

        public MainWindow()
        {
            InitializeComponent();

            config = new Config();
            LoadConfig();
        }

        private void LoadConfig()
        {
            PC1_HostName.Content = config.GetHostName(0);
            PC1_NickName.Content = config.GetNickName(0);
            PC2_HostName.Content = config.GetHostName(1);
            PC2_NickName.Content = config.GetNickName(1);
            PC3_HostName.Content = config.GetHostName(2);
            PC3_NickName.Content = config.GetNickName(2);
            PC4_HostName.Content = config.GetHostName(3);
            PC4_NickName.Content = config.GetNickName(3);
            PC5_HostName.Content = config.GetHostName(4);
            PC5_NickName.Content = config.GetNickName(4);
            PC6_HostName.Content = config.GetHostName(5);
            PC6_NickName.Content = config.GetNickName(5);
            PC7_HostName.Content = config.GetHostName(6);
            PC7_NickName.Content = config.GetNickName(6);
            PC8_HostName.Content = config.GetHostName(7);
            PC8_NickName.Content = config.GetNickName(7);
            PC9_HostName.Content = config.GetHostName(8);
            PC9_NickName.Content = config.GetNickName(8);
            PC10_HostName.Content = config.GetHostName(9);
            PC10_NickName.Content = config.GetNickName(9);
            PC11_HostName.Content = config.GetHostName(10);
            PC11_NickName.Content = config.GetNickName(10);
        }

        private void GetReply(string hostName)
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

            reply = pingSender.Send(hostName, timeout, buffer, options);
        }

        private void Ping(string hostName)
        {
            GetReply(hostName);

            if (reply.Status == IPStatus.Success)
            {
                ReplySucess(hostName);
            }
            else
            {
                ReplyFailure(hostName);
            }
        }

        private void ReplySucess(string hostName)
        {
            if (hostName.Equals(PC1_HostName.Content.ToString()))
            {
                PC1_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC1_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC2_HostName.Content.ToString()))
            {
                PC2_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC2_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC3_HostName.Content.ToString()))
            {
                PC3_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC3_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC4_HostName.Content.ToString()))
            {
                PC4_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC4_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC5_HostName.Content.ToString()))
            {
                PC5_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC5_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC6_HostName.Content.ToString()))
            {
                PC6_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC6_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC7_HostName.Content.ToString()))
            {
                PC7_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC7_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC8_HostName.Content.ToString()))
            {
                PC8_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC8_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC9_HostName.Content.ToString()))
            {
                PC9_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC9_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC10_HostName.Content.ToString()))
            {
                PC10_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC10_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC11_HostName.Content.ToString()))
            {
                PC11_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC11_Data.Content = reply.Status.ToString() + "\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
        }

        private void ReplyFailure(string hostName)
        {
            if (hostName.Equals(PC1_HostName.Content.ToString()))
            {
                PC1_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC1_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC2_HostName.Content.ToString()))
            {
                PC2_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC2_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC3_HostName.Content.ToString()))
            {
                PC3_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC3_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC4_HostName.Content.ToString()))
            {
                PC4_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC4_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC5_HostName.Content.ToString()))
            {
                PC5_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC5_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC6_HostName.Content.ToString()))
            {
                PC6_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC6_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC7_HostName.Content.ToString()))
            {
                PC7_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC7_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC8_HostName.Content.ToString()))
            {
                PC8_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC8_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC9_HostName.Content.ToString()))
            {
                PC9_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC9_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC10_HostName.Content.ToString()))
            {
                PC10_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC10_Data.Content = reply.Status.ToString();
            }
            else if (hostName.Equals(PC11_HostName.Content.ToString()))
            {
                PC11_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC11_Data.Content = reply.Status.ToString();
            }
        }

        private void Ping_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                Ping(config.GetHostName(i).ToString());
            }
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configuration = new ConfigurationWindow();
            configuration.Show();
        }
    }
}