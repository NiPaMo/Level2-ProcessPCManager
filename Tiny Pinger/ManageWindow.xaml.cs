using System;
using System.Windows;
using System.Management;
using System.Collections.Generic;

namespace Process_PC_Manager
{
    public partial class ManageWindow : Window
    {
        ManagementScope scope;
        Config config = new Config();
        PasswordPromptWindow prompt = new PasswordPromptWindow();

        List<String> views = new List<string> { "Properties", "Processes" };

        string hostName;

        public ManageWindow()
        {
            prompt.ShowDialog();

            if (prompt.GetCancel())
                this.Close();

            InitializeComponent();

            foreach (var name in config.GetHostName())
            {
                if (name != "")
                HostName.Items.Add(name);
            }
            HostName.SelectedIndex = 0;

            foreach (var view in views)
            {
                ViewBox.Items.Add(view);
            }
        }

        private void PropertiesView()
        {
            // Query system for Operating System information
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            try
            {
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Details.Text = "Computer Name\t:  " + m["CSName"] + "\n" +
                                   "Status       \t:  " + m["Status"] + "\n" +
                                   "OS Name      \t:  " + m["Caption"] + "\n" +
                                   "Service Pack \t:  " + m["CSDVersion"] + "\n" +
                                   "Version      \t:  " + m["Version"] + "\n" +
                                   "Build Number \t:  " + m["BuildNumber"] + "\n" +
                                   "Architecture \t:  " + m["OSArchitecture"] + "\n" +
                                   "Serial Number\t:  " + m["SerialNumber"] + "\n";
                }
            }
            catch (ManagementException ex)
            {
                // Display error to user
                MessageBox.Show(ex.Message.ToString(), "Data Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProcessesView()
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Process");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            Details.Text = queryCollection.Count + " Active Processes\n\n";
            foreach (ManagementObject m in queryCollection)
            {
                // Display the remote computer information
                Details.Text += m["ProcessID"] + " :\t" + m["Name"] + "\n";
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            hostName = HostName.Text;

            ConnectionOptions options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Packet,
                EnablePrivileges = true,
                Username = hostName + "\\" + prompt.GetUsername(),
                Password = prompt.GetPassword()
            };

            try
            {
                scope = new ManagementScope("\\\\" + hostName + ".maprocess.corp.aksteel.com\\root\\cimv2", options);
                scope.Connect();
            }
            catch (UnauthorizedAccessException)
            {
                // Display error to user
                MessageBox.Show("Error connecting to " + hostName + "\nCheck username and password", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            ViewBox.Items.Clear();

            foreach (var view in views)
            {
                ViewBox.Items.Add(view);
            }

            ViewLabel.Visibility = Visibility.Visible;
            ViewBox.Visibility = Visibility.Visible;
        }

        private void ViewBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (ViewBox.SelectedItem.ToString())
            {
                case "Properties":
                    PropertiesView();
                    break;

                case "Processes":
                    ProcessesView();
                    break;

                default:
                    break;
            }
        }

        private void HostName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Details.Text = "";
            ViewLabel.Visibility = Visibility.Hidden;
            ViewBox.Visibility = Visibility.Hidden;
        }
    }
}
