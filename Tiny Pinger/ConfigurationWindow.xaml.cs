using System;
using System.IO;
using System.Windows;

namespace Tiny_Pinger
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        Config config;

        public ConfigurationWindow()
        {
            InitializeComponent();

            config = new Config();
            LoadConfig();
        }

        private void LoadConfig()
        {
            PC1_HostName.Text = config.GetHostName(0);
            PC1_NickName.Text = config.GetNickName(0);
            PC2_HostName.Text = config.GetHostName(1);
            PC2_NickName.Text = config.GetNickName(1);
            PC3_HostName.Text = config.GetHostName(2);
            PC3_NickName.Text = config.GetNickName(2);
            PC4_HostName.Text = config.GetHostName(3);
            PC4_NickName.Text = config.GetNickName(3);
            PC5_HostName.Text = config.GetHostName(4);
            PC5_NickName.Text = config.GetNickName(4);
            PC6_HostName.Text = config.GetHostName(5);
            PC6_NickName.Text = config.GetNickName(5);
            PC7_HostName.Text = config.GetHostName(6);
            PC7_NickName.Text = config.GetNickName(6);
            PC8_HostName.Text = config.GetHostName(7);
            PC8_NickName.Text = config.GetNickName(7);
            PC9_HostName.Text = config.GetHostName(8);
            PC9_NickName.Text = config.GetNickName(8);
            PC10_HostName.Text = config.GetHostName(9);
            PC10_NickName.Text = config.GetNickName(9);
            PC11_HostName.Text = config.GetHostName(10);
            PC11_NickName.Text = config.GetNickName(10);
        }

        private void ApplyConfig()
        {
            config.SetHostName(PC1_HostName.Text, 0);
            config.SetNickName(PC1_NickName.Text, 0);
            config.SetHostName(PC2_HostName.Text, 1);
            config.SetNickName(PC2_NickName.Text, 1);
            config.SetHostName(PC3_HostName.Text, 2);
            config.SetNickName(PC3_NickName.Text, 2);
            config.SetHostName(PC4_HostName.Text, 3);
            config.SetNickName(PC4_NickName.Text, 3);
            config.SetHostName(PC5_HostName.Text, 4);
            config.SetNickName(PC5_NickName.Text, 4);
            config.SetHostName(PC6_HostName.Text, 5);
            config.SetNickName(PC6_NickName.Text, 5);
            config.SetHostName(PC7_HostName.Text, 6);
            config.SetNickName(PC7_NickName.Text, 6);
            config.SetHostName(PC8_HostName.Text, 7);
            config.SetNickName(PC8_NickName.Text, 7);
            config.SetHostName(PC9_HostName.Text, 8);
            config.SetNickName(PC9_NickName.Text, 8);
            config.SetHostName(PC10_HostName.Text, 9);
            config.SetNickName(PC10_NickName.Text, 9);
            config.SetHostName(PC11_HostName.Text, 10);
            config.SetNickName(PC11_NickName.Text, 10);
        }


        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            ApplyConfig();
            config.SetConfig();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            config.GetConfig();
            LoadConfig();
        }
    }
}
