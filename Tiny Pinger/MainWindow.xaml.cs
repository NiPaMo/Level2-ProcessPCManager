using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Process_PC_Manager
{
    public partial class MainWindow : Window
    {
        BrushConverter converter = new BrushConverter();

        PingReply reply;
        Config config;
        Version version;
        List<Label> labelsHostName;
        List<Label> labelsNickName;
        List<Label> labelsData;
        List<Rectangle> rectsStatus;
        Timer timer = new Timer();

        int timeout = 100;
        int interval = 60;

        public MainWindow()
        {
            InitializeComponent();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                Version.Content = version.ToString();
            }

            timer.Interval = interval*1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            LoadConfig();
        }

        private void LoadConfig()
        {
            ChildControls ccChildren = new ChildControls();
            labelsHostName = new List<Label>();
            labelsNickName = new List<Label>();
            labelsData = new List<Label>();
            rectsStatus = new List<Rectangle>();

            int i;

            foreach (object o in ccChildren.GetChildren(Parent, 5))
            {
                if (o.GetType() == typeof(Label))
                {
                    switch (((Label)o).Uid)
                    {
                        case "HOSTNAME":
                            labelsHostName.Add((Label)o);
                            break;

                        case "NICKNAME":
                            labelsNickName.Add((Label)o);
                            break;

                        case "DATA":
                            labelsData.Add((Label)o);
                            break;

                        default:
                            break;
                    }
                }
                else if (o.GetType() == typeof(Rectangle))
                {
                    rectsStatus.Add((Rectangle)o);
                }
            }


            config = new Config();

            Selection.Items.Clear();

            foreach (var name in config.GetConfigs())
            {
                Selection.Items.Add(name);
            }

            Selection.SelectedItem = config.GetFileName();

            i = 0;
            foreach (var name in config.GetHostName())
            {
                if (name != "")
                {
                    PingAsync(name, i);
                    i++;
                }
            }

            if (i != 19)
            {
                while (i < 20)
                {
                    labelsData[i].Content = "";
                    rectsStatus[i].Fill = (Brush)converter.ConvertFromString("#FFF");
                    i++;
                }
            }

            i = 0;
            foreach (var label in labelsHostName)
            {
                if (config.GetHostName(i) != null)
                    label.Content = config.GetHostName(i);
                else
                    label.Content = "";
                i++;
            }

            i = 0;
            foreach (var label in labelsNickName)
            {
                if (config.GetNickName(i) != null)
                    label.Content = config.GetNickName(i);
                else
                    label.Content = "";
                i++;
            }

            Time.Content = DateTime.Now.ToString("HH:mm:ss:ff");
            Interval.Text = interval.ToString();
            Timeout.Text = timeout.ToString();
        }
     
        private async void PingAsync(string hostName, int index)
        {
            Ping ping = new Ping();

            try
            {
                reply = await ping.SendPingAsync(hostName, timeout);

                // Sucessful reply
                rectsStatus[index].Fill = (Brush)converter.ConvertFromString("#145A32");
                labelsData[index].Content = "Online\n"
                    + reply.Address.ToString() + "\n"
                    + reply.RoundtripTime.ToString() + " ms";
            }
            catch
            {
                // Unsucessful reply
                rectsStatus[index].Fill = (Brush)converter.ConvertFromString("#641E16");
                labelsData[index].Content = "Offline";
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int i = 0;
            this.Dispatcher.Invoke(() =>
            {
                foreach (var name in config.GetHostName())
                {
                    if (name != "")
                    {
                        PingAsync(name, i);
                        i++;
                    }
                }

                if (i != 19)
                {
                    while (i < 20)
                    {
                        labelsData[i].Content = "";
                        rectsStatus[i].Fill = (Brush)converter.ConvertFromString("#FFF");
                        i++;
                    }
                }

                Time.Content = DateTime.Now.ToString("HH:mm:ss:ff");
            });

        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow configuration = new ConfigurationWindow();
            configuration.Show();

            configuration.Closed += Configuration_Closed;
        }

        private void Configuration_Closed(object sender, EventArgs e)
        {
            LoadConfig();
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
            try
            {
                manage.Show();
                LoadConfig();
            }
            catch
            {

            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            config.SetFileName(Selection.SelectedItem.ToString());

            LoadConfig();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the " + config.GetFileName() + "\nconfiguration list?", "Comfirm Action", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Delete the list name from the file and reload the results
                config.RemoveConfigList();
                LoadConfig();
            }
        }
    }
}
