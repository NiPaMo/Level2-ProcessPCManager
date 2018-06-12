using System;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace Process_PC_Manager
{
    public partial class MainWindow : Window
    {
        BrushConverter converter = new BrushConverter();

        PingReply reply;
        Config config; 
        Timer timer = new Timer();

        int timeout = 100;
        int interval = 60;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = interval*1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            LoadConfig();
        }

        private void LoadConfig()
        {
            config = new Config();

            Selection.Items.Clear();

            foreach (var name in config.GetConfigs())
            {
                Selection.Items.Add(name);
            }

            Selection.SelectedItem = config.GetFileName();

            foreach (var name in config.GetHostName())
            {
                PingAsync(name);
            }

            Interval.Text = interval.ToString();
            Timeout.Text = timeout.ToString();

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
            PC12_HostName.Content = config.GetHostName(11);
            PC12_NickName.Content = config.GetNickName(11);
            PC13_HostName.Content = config.GetHostName(12);
            PC13_NickName.Content = config.GetNickName(12);
            PC14_HostName.Content = config.GetHostName(13);
            PC14_NickName.Content = config.GetNickName(13);
            PC15_HostName.Content = config.GetHostName(14);
            PC15_NickName.Content = config.GetNickName(14);
            PC16_HostName.Content = config.GetHostName(15);
            PC16_NickName.Content = config.GetNickName(15);
            PC17_HostName.Content = config.GetHostName(16);
            PC17_NickName.Content = config.GetNickName(16);
            PC18_HostName.Content = config.GetHostName(17);
            PC18_NickName.Content = config.GetNickName(17);
            PC19_HostName.Content = config.GetHostName(18);
            PC19_NickName.Content = config.GetNickName(18);
            PC20_HostName.Content = config.GetHostName(19);
            PC20_NickName.Content = config.GetNickName(19);
        }
     
        private async void PingAsync(string hostName)
        {
            Ping ping = new Ping();

            try
            {
                reply = await ping.SendPingAsync(hostName, timeout);
                ReplySucess(hostName);
            }
            catch (Exception e)
            {
                ReplyFailure(hostName);
                Console.WriteLine(e.Message);
                Console.WriteLine(reply.Status);
            }
        }

        private void ReplySucess(string hostName)
        {
            if (hostName.Equals(PC1_HostName.Content.ToString()))
            {
                PC1_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC1_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC2_HostName.Content.ToString()))
            {
                PC2_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC2_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC3_HostName.Content.ToString()))
            {
                PC3_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC3_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC4_HostName.Content.ToString()))
            {
                PC4_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC4_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC5_HostName.Content.ToString()))
            {
                PC5_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC5_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC6_HostName.Content.ToString()))
            {
                PC6_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC6_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC7_HostName.Content.ToString()))
            {
                PC7_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC7_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC8_HostName.Content.ToString()))
            {
                PC8_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC8_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC9_HostName.Content.ToString()))
            {
                PC9_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC9_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC10_HostName.Content.ToString()))
            {
                PC10_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC10_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC11_HostName.Content.ToString()))
            {
                PC11_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC11_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC12_HostName.Content.ToString()))
            {
                PC12_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC12_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC13_HostName.Content.ToString()))
            {
                PC13_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC13_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC14_HostName.Content.ToString()))
            {
                PC14_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC14_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC15_HostName.Content.ToString()))
            {
                PC15_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC15_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC16_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC16_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC17_HostName.Content.ToString()))
            {
                PC17_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC17_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC18_HostName.Content.ToString()))
            {
                PC18_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC18_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC19_HostName.Content.ToString()))
            {
                PC19_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC19_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            else if (hostName.Equals(PC20_HostName.Content.ToString()))
            {
                PC20_Status.Fill = (Brush)converter.ConvertFromString("#145A32");
                PC20_Data.Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
        }

        private void ReplyFailure(string hostName)
        {
            if (hostName.Equals(PC1_HostName.Content.ToString()))
            {
                PC1_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC1_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC2_HostName.Content.ToString()))
            {
                PC2_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC2_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC3_HostName.Content.ToString()))
            {
                PC3_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC3_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC4_HostName.Content.ToString()))
            {
                PC4_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC4_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC5_HostName.Content.ToString()))
            {
                PC5_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC5_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC6_HostName.Content.ToString()))
            {
                PC6_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC6_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC7_HostName.Content.ToString()))
            {
                PC7_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC7_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC8_HostName.Content.ToString()))
            {
                PC8_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC8_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC9_HostName.Content.ToString()))
            {
                PC9_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC9_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC10_HostName.Content.ToString()))
            {
                PC10_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC10_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC11_HostName.Content.ToString()))
            {
                PC11_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC11_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC12_HostName.Content.ToString()))
            {
                PC12_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC12_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC13_HostName.Content.ToString()))
            {
                PC13_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC13_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC14_HostName.Content.ToString()))
            {
                PC14_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC14_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC15_HostName.Content.ToString()))
            {
                PC15_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC15_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC16_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC16_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC17_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC17_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC18_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC18_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC19_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC19_Data.Content = "Offline";
            }
            else if (hostName.Equals(PC16_HostName.Content.ToString()))
            {
                PC20_Status.Fill = (Brush)converter.ConvertFromString("#641E16");
                PC20_Data.Content = "Offline";
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                foreach (var name in config.GetHostName())
                {
                    PingAsync(name);
                }
            });

        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configuration = new ConfigurationWindow();
            configuration.Show();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                interval = Int32.Parse(Interval.Text);
                timer.Stop();
                timer.Interval = interval*1000;
                timer.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format for interval");
            }

            try
            {
                timeout = Int32.Parse(Timeout.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format for timeout");
            }
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            ManageWindow manage = new ManageWindow();
            manage.Show();

            LoadConfig();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            config.SetFileName(Selection.SelectedItem.ToString());
            LoadConfig();
        }
    }
}
